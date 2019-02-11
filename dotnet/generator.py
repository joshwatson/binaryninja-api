from binaryninja import Architecture, Endianness, Type, TypeClass, NamedTypeReferenceClass, Structure, StructureMember, TypeParserResult, FunctionParameter
from argparse import ArgumentParser, Namespace, FileType

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
                    out.write(f' {x.name if x.name not in keywords else f"_{x.name}"}, ')
                else:
                    out.write(f' {x.name if x.name not in keywords else f"_{x.name}"}')
            out.write(');\n')
        elif type_.target.type_class == TypeClass.NamedTypeReferenceClass:
            out.write(f'{type_.target.named_type_reference.name}*')
        else:
            output_type(out, type_.target)
            out.write('*')
    else:
        out.write(f'{type_}')


def main(args: Namespace):
    header = args.header.read()
    out = args.out
    enum = args.enum

    arch: Architecture = Architecture['generator']

    source: TypeParserResult = arch.standalone_platform.parse_types_from_source(header)

    types = source.types
    vars_ = source.variables
    funcs = source.functions

    out.write(
        '''using System;
using System.Runtime.InteropServices;

namespace BinaryNinja
{
\tpublic class Core
\t{

''')

    enum.write(
        '''
namespace BinaryNinja
{
'''
    )

    out.write('\t\t// Type definitions\n')

    structs_to_process = sorted(list({t for t in types}))

    for name in structs_to_process:
        type_ = types[name]

        if type_.type_class == TypeClass.StructureTypeClass:
            unsafe: bool = None is not next((m for m in type_.structure.members if m.type.type_class == TypeClass.PointerTypeClass), None)

            out.write(f'\t\t[StructLayout(Layout.Sequential)]\n\t\tpublic{" unsafe " if unsafe else " "}struct {name}')

            if len(type_.structure.members) == 0:
                out.write(' { };\n\n')
                continue
            
            out.write('\n\t\t{\n')

            for member in type_.structure.members:
                member: StructureMember
                if (member.type.type_class == TypeClass.PointerTypeClass and
                        member.type.target.width == 1 and
                        member.type.target.signed):
                    out.write(
                        f'\t\t\t[MarshalAs(UnmanagedType.LPStr)] public string {member.name};\n')
                elif (member.type.type_class == TypeClass.PointerTypeClass and
                        member.type.target.type_class == TypeClass.FunctionTypeClass):
                    out.write(
                        f'\t\t\t[MarshalAs(UnmanagedType.FunctionPtr)] public '
                    )
                    is_action = False
                    if member.type.target.return_value.type_class == TypeClass.VoidTypeClass:
                        out.write('Action')
                        is_action = True
                        if len(member.type.target.parameters):
                            out.write('<')
                    else:
                        out.write('Func<')

                    for j, p in enumerate(member.type.target.parameters):
                        output_type(out, p.type)
                        if not is_action or j < len(member.type.target.parameters) - 1:
                            out.write(', ')

                    if not is_action:
                        output_type(out, member.type.target.return_value, True)

                    if not is_action or len(member.type.target.parameters):
                        out.write(f'>')

                    out.write(f' {member.name};\n')

                elif member.type.type_class == TypeClass.ArrayTypeClass:
                    out.write(f'\t\tpublic fixed ')
                    output_type(out, member.type.element_type)
                    out.write(f' {member.name}[{member.type.count:d}];\n')
                else:
                    out.write('\t\t\tpublic ')
                    output_type(out, member.type, var_name=member.name)
                    if member.name in keywords:
                        member.name = f'_{member.name}'
                    out.write(f' {member.name!s};\n')

            out.write('\t\t}\n\n')
        
        elif type_.type_class == TypeClass.EnumerationTypeClass:
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

    for name, type_ in funcs.items():
        out.write('\t\t')
        out.write(r'[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]')
        out.write(f'\n\t\tpublic static extern unsafe ')
        output_type(out, type_.return_value, is_return_type=True)
        out.write(f' {name}(')

        for i, param in enumerate(type_.parameters):
            if (param.type.type_class == TypeClass.PointerTypeClass and 
                    param.type.target.type_class == TypeClass.FunctionTypeClass):
                is_action = False
                if param.type.target.return_value.type_class == TypeClass.VoidTypeClass:
                    out.write('Action')
                    is_action = True
                    if len(param.type.target.parameters):
                        out.write('<')
                else:
                    out.write('Func<')

                for j, p in enumerate(param.type.target.parameters):
                    output_type(out, p.type)
                    if not is_action or j < len(param.type.target.parameters) - 1:
                        out.write(', ')

                if param.type.target.return_value.type_class != TypeClass.VoidTypeClass:
                    output_type(out, param.type.target.return_value, True)

                if not is_action or len(param.type.target.parameters):
                    out.write(f'> ')
            else:
                output_type(out, param.type)
            if i < len(type_.parameters) - 1:
                out.write(f' {param.name if param.name not in keywords else f"_{param.name}"}, ')
            else:
                out.write(f' {param.name if param.name not in keywords else f"_{param.name}"}')

        out.write(');\n')

    out.write('\t}\n}\n')
    enum.write('}\n')

if __name__ == '__main__':
    parser = ArgumentParser('generator.py')
    parser.add_argument('header', type=FileType('r'))
    parser.add_argument('out', type=FileType('w'))
    parser.add_argument('enum', type=FileType('w'))

    args = parser.parse_args()

    main(args)
