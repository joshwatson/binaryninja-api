from argparse import ArgumentParser, FileType, Namespace
from io import StringIO

from binaryninja import (Architecture, Endianness, FunctionParameter,
                         NamedTypeReferenceClass, Structure, StructureMember,
                         Type, TypeClass, TypeParserResult)

keywords = ['params', 'base', 'ref', 'event']


class GeneratorArchitecture(Architecture):
    name = "generator"
    endianness = Endianness.LittleEndian
    address_size = 8

    def get_instruction_info(self, data, addr):
        return False

    def get_instruction_text(self, data, addr):
        return False


GeneratorArchitecture.register()

opaque_structs = set()

def output_type(out, type_: Type, is_return_type: bool = False, is_callback: bool = False, var_name=''):
    if type_.type_class == TypeClass.BoolTypeClass:
        out.write("bool")
    elif type_.type_class == TypeClass.IntegerTypeClass:
        if type_.width == 1:
            if type_.signed:
                out.write("sbyte")
            else:
                out.write("byte")
        if type_.width == 2:
            if type_.signed:
                out.write("short")
            else:
                out.write("ushort")
        if type_.width == 4:
            if type_.signed:
                out.write("int")
            else:
                out.write("uint")
        if type_.width == 8:
            if type_.signed:
                out.write("long")
            else:
                out.write("ulong")
    elif type_.type_class == TypeClass.FloatTypeClass:
        if type_.width == 4:
            out.write("float")
        else:
            out.write("double")
    elif type_.type_class == TypeClass.NamedTypeReferenceClass:
        if type_.named_type_reference.type_class == NamedTypeReferenceClass.EnumNamedTypeClass:
            name = str(type_.named_type_reference.name)
            if len(name) > 2 and name.startswith('BN'):
                name = name[2:]
            out.write(f'{name}')
        else:
            out.write(f'{type_.named_type_reference.name}')
    elif type_.type_class == TypeClass.PointerTypeClass:
        if is_callback or type_.target.type_class == TypeClass.VoidTypeClass:
            out.write('void*')
        elif (type_.target.type_class == TypeClass.IntegerTypeClass and
                type_.target.width == 1 and type_.target.signed):
            out.write('char*')
        elif type_.target.type_class == TypeClass.FunctionTypeClass:
            out.write('public unsafe delegate ')
            output_type(out, type_, True, True)
            out.write(f' {var_name}Delegate(')
            for i, x in enumerate(type_.target.parameters):
                output_type(out, x.type)
                if i < len(type_.target.parameters) - 1:
                    out.write(
                        f' {x.name if x.name not in keywords else f"_{x.name}"}, ')
                else:
                    out.write(
                        f' {x.name if x.name not in keywords else f"_{x.name}"}')
            out.write(');\n')
        elif type_.target.type_class == TypeClass.NamedTypeReferenceClass:
            name = str(type_.target.named_type_reference.name)
            if type_.target.named_type_reference.type_class == NamedTypeReferenceClass.EnumNamedTypeClass:
                if len(name) > 2 and name.startswith('BN'):
                    name = name[2:]
            elif name in opaque_structs:
                name = '_' + name
            
            out.write(f'{name}*')
        else:
            output_type(out, type_.target)
            out.write('*')
    else:
        out.write(f'{type_}')


def main(args: Namespace):
    header = args.header.read()
    out = args.out
    enum = args.enum
    delegates = args.delegates

    arch: Architecture = Architecture['generator']

    source: TypeParserResult = arch.standalone_platform.parse_types_from_source(
        header)

    types = source.types
    funcs = source.functions

    out.write(
        '''using System.Runtime.InteropServices;

namespace BinaryNinja
{
\tpublic class Core
\t{

''')

    enum.write(
        '''namespace BinaryNinja
{
'''
    )

    delegates.write(
        '''using System.Runtime.InteropServices;

namespace BinaryNinja
{
'''
    )

    out.write('\t\t// Type definitions\n')

    structs_to_process = sorted(list({t for t in types}))
    seen = set()
    delegate_list = {}

    while structs_to_process:
        print(len(structs_to_process))
        current_structs = structs_to_process
        structs_to_process = set()
        for name in current_structs:
            struct_string = StringIO('')

            type_ = types[name]

            if type_.type_class == TypeClass.StructureTypeClass:
                unsafe: bool = None is not next(
                    (
                        m
                        for m in type_.structure.members
                        if m.type.type_class in (
                            TypeClass.ArrayTypeClass, TypeClass.PointerTypeClass
                        )
                    ),
                    None
                )

                struct_string.write(
                    f'\t\t[StructLayout(LayoutKind.Sequential)]\n\t\tpublic{" unsafe " if unsafe else " "}struct {name}')

                if len(type_.structure.members) == 0:
                    struct_string.write(' { };\n\n')
                    struct_string.seek(0)
                    out.write(struct_string.read())
                    seen.add(name)
                    continue

                struct_string.write('\n\t\t{\n')

                need_opaque_struct = False

                for member in type_.structure.members:
                    member: StructureMember
                    if (member.type.type_class == TypeClass.PointerTypeClass and
                            member.type.target.width == 1 and
                            member.type.target.signed):
                        struct_string.write(
                            f'\t\t\tpublic char* {member.name};\n')

                    elif (member.type.type_class == TypeClass.PointerTypeClass and
                            member.type.target.type_class == TypeClass.FunctionTypeClass):
                        need_opaque_struct = True
                        struct_string.write(
                            f'\t\t\t[MarshalAs(UnmanagedType.FunctionPtr)] public {name}_{member.name}Delegate {member.name};\n'
                        )

                        delegate_list[f'{name}_{member.name}Delegate'] = member.type.target

                    elif member.type.type_class == TypeClass.ArrayTypeClass:
                        need_opaque_struct = True
                        if member.type.element_type.type_class == TypeClass.IntegerTypeClass:
                            struct_string.write(f'\t\t\tpublic fixed ')
                        else:
                            struct_string.write(
                                f'\t\t\t[MarshalAs(UnmanagedType.LPArray, SizeConst = {member.type.count})] public ')

                        output_type(struct_string, member.type.element_type)

                        if member.type.element_type.type_class == TypeClass.IntegerTypeClass:
                            struct_string.write(
                                f' {member.name}[{member.type.count:d}];\n')
                        else:
                            struct_string.write(f'[] {member.name};\n')
                    elif (member.type.type_class == TypeClass.PointerTypeClass and
                            member.type.target.type_class == TypeClass.NamedTypeReferenceClass):
                        if (str(member.type.target.named_type_reference.name) not in seen and
                                str(member.type.target.named_type_reference.name) != str(name)):
                            print(
                                f'{name} {member.type.target.named_type_reference.name}*')
                            structs_to_process.add(name)
                            break
                        elif str(member.type.target.named_type_reference.name) in opaque_structs:
                            struct_string.write(
                                f'\t\t\tpublic _{member.type.target.named_type_reference.name}* {member.name};\n')

                    elif member.type.type_class == TypeClass.NamedTypeReferenceClass:
                        if str(member.type.named_type_reference.name) not in seen:
                            print(
                                f'{name} {member.type.named_type_reference.name}')
                            structs_to_process.add(name)
                            break
                        elif str(member.type.named_type_reference.name) in opaque_structs:
                            need_opaque_struct = True
                            struct_string.write(
                                f'\t\t\tpublic {member.type.named_type_reference.name} {member.name};\n')
                    else:
                        struct_string.write('\t\t\tpublic ')
                        output_type(struct_string, member.type,
                                    var_name=member.name)
                        if member.name in keywords:
                            member.name = f'_{member.name}'
                        struct_string.write(f' {member.name!s};\n')
                else:

                    struct_string.write('\t\t}\n\n')

                    if need_opaque_struct:
                        struct_string.write(
                            f'\t\tpublic struct _{name} {{ }};\n\n')
                        opaque_structs.add(str(name))
                        seen.add(f'_{name}')

                    struct_string.seek(0)
                    out.write(struct_string.read())
                    seen.add(name)

            elif type_.type_class == TypeClass.EnumerationTypeClass:
                seen.add(name)
                if len(str(name)) > 2 and str(name).startswith('BN'):
                    name = str(name)[2:]
                enum.write(f'\tpublic enum {name}\n')
                enum.write('\t{\n')
                for i, x in enumerate(type_.enumeration.members):
                    if i < len(type_.enumeration.members) - 1:
                        enum.write(f'\t\t{x.name} = {x.value},\n')
                    else:
                        enum.write(f'\t\t{x.name} = {x.value}\n')
                enum.write('\t}\n')

    out.write('\t\t// Function definitions\n')

    cbs = {}

    for name, type_ in funcs.items():
        out.write('\t\t')
        out.write(
            r'[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]')
        out.write(f'\n\t\tpublic static extern unsafe ')
        
        if (type_.return_value.type_class == TypeClass.PointerTypeClass and
                type_.return_value.target.type_class == TypeClass.NamedTypeReferenceClass and
                type_.return_value.target.named_type_reference.name in opaque_structs):
            out.write(f'_{type_.return_value.target.named_type_reference.name}*')
        else:
            output_type(out, type_.return_value, is_return_type=True)

        out.write(f' {name}(')

        for i, param in enumerate(type_.parameters):
            if (param.type.type_class == TypeClass.PointerTypeClass and
                    param.type.target.type_class == TypeClass.FunctionTypeClass):

                signature = (*param.type.target.parameters, param.type.target.return_value)

                if str(param.name) not in cbs:
                    print(name, param.name)
                    cbs[str(param.name)] = [signature]
                    index_of = 0
                else:
                    for ii, sig in enumerate(cbs[str(param.name)]):
                        if len(sig) != len(signature):
                            continue

                        count = 0
                        for k, p in enumerate(sig[:-1]):
                            if signature[k].type == p.type:
                                count += 1
                        
                        if signature[-1] == sig[-1]:
                            count += 1

                        if count == len(sig):
                            index_of = ii
                            break

                    else:
                        cbs[str(param.name)].append(signature)
                        index_of = ii

                print(name, param.name, index_of)
                out.write(
                    f'[MarshalAs(UnmanagedType.FunctionPtr)] {param.name}Delegate{index_of}')
                delegate_list[f'{param.name}Delegate{index_of}'] = param.type.target

            elif (param.type.type_class == TypeClass.PointerTypeClass and
                    param.type.target.type_class == TypeClass.NamedTypeReferenceClass and
                    str(param.type.target.named_type_reference.name) in opaque_structs):
                out.write(f'_{param.type.target.named_type_reference.name}*')
            elif param.type.type_class == TypeClass.EnumerationTypeClass:
                enum_name = str(param.type.target.named_type_reference.name)
                if len(enum_name) > 2 and enum_name[2:].startswith('BN'):
                    enum_name = enum_name[2:]
                out.write(f'{enum_name}*')
            elif (param.type.type_class == TypeClass.PointerTypeClass and
                    param.type.target.type_class == TypeClass.NamedTypeReferenceClass and
                    param.type.target.named_type_reference.type_class == NamedTypeReferenceClass.EnumNamedTypeClass):
                enum_name = str(param.type.target.named_type_reference.name)
                if len(enum_name) > 2 and enum_name[2:].startswith('BN'):
                    enum_name = enum_name[2:]
                out.write(f'{enum_name}*')
            else:
                output_type(out, param.type)
            if i < len(type_.parameters) - 1:
                out.write(
                    f' {param.name if param.name not in keywords else f"_{param.name}"}, ')
            else:
                out.write(
                    f' {param.name if param.name not in keywords else f"_{param.name}"}')

        out.write(');\n')

    out.write('\t\t// Delegate definitions\n')

    for name, delegate in delegate_list.items():
        out.write('\t\tpublic unsafe delegate ')
        output_type(
            out, delegate.return_value, True)
        out.write(f' {name}(')

        for j, p in enumerate(delegate.parameters):
            output_type(out, p.type)
            if j < len(delegate.parameters) - 1:
                out.write(
                    f' {p.name if p.name not in keywords else f"_{p.name}"}, ')
            else:
                out.write(
                    f' {p.name if p.name not in keywords else f"_{p.name}"}')
        out.write(');\n')

    out.write('\t}\n}\n')
    enum.write('}\n')
    delegates.write('}\n')

    print(*sorted(cbs.items(), key=lambda p: p[0]), sep='\n')

if __name__ == '__main__':
    parser = ArgumentParser('generator.py')
    parser.add_argument('header', type=FileType('r'))
    parser.add_argument('out', type=FileType('w'))
    parser.add_argument('enum', type=FileType('w'))
    parser.add_argument('delegates', type=FileType('w'))

    args = parser.parse_args()

    main(args)
