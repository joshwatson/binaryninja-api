namespace BinaryNinja
{
    public enum BNPluginLoadOrder
    {
        EarlyPluginLoadOrder,
        NormalPluginLoadOrder,
        LatePluginLoadOrder
    }

    //! Console log levels
    public enum BNLogLevel
    {
        DebugLog = 0,   //! Debug logging level, most verbose logging level
        InfoLog = 1,    //! Information logging level, default logging level
        WarningLog = 2, //! Warning logging level, messages show with warning icon in the UI
        ErrorLog = 3,   //! Error logging level, messages show with error icon in the UI
        AlertLog = 4    //! Alert logging level, messages are displayed with popup message box in the UI
    }

    public enum BNEndianness
    {
        LittleEndian = 0,
        BigEndian = 1
    }

    public enum BNModificationStatus
    {
        Original = 0,
        Changed = 1,
        Inserted = 2
    }

    public enum BNTransformType
    {
        BinaryCodecTransform = 0, // Two-way transform of data, binary input/output
        TextCodecTransform = 1, // Two-way transform of data, encoder output is text
        UnicodeCodecTransform = 2, // Two-way transform of data, encoder output is Unicode string (as UTF8)
        DecodeTransform = 3, // One-way decode only
        BinaryEncodeTransform = 4, // One-way encode only, output is binary
        TextEncodeTransform = 5, // One-way encode only, output is text
        EncryptTransform = 6, // Two-way encryption
        InvertingTransform = 7, // Transform that can be undone by performing twice
        HashTransform = 8 // Hash function
    }

    public enum BNBranchType
    {
        UnconditionalBranch = 0,
        FalseBranch = 1,
        TrueBranch = 2,
        CallDestination = 3,
        FunctionReturn = 4,
        SystemCall = 5,
        IndirectBranch = 6,
        UnresolvedBranch = 127
    }

    public enum BNInstructionTextTokenType
    {
        TextToken = 0,
        InstructionToken = 1,
        OperandSeparatorToken = 2,
        RegisterToken = 3,
        IntegerToken = 4,
        PossibleAddressToken = 5,
        BeginMemoryOperandToken = 6,
        EndMemoryOperandToken = 7,
        FloatingPointToken = 8,
        AnnotationToken = 9,
        CodeRelativeAddressToken = 10,
        ArgumentNameToken = 11,
        HexDumpByteValueToken = 12,
        HexDumpSkippedByteToken = 13,
        HexDumpInvalidByteToken = 14,
        HexDumpTextToken = 15,
        OpcodeToken = 16,
        StringToken = 17,
        CharacterConstantToken = 18,
        KeywordToken = 19,
        TypeNameToken = 20,
        FieldNameToken = 21,
        NameSpaceToken = 22,
        NameSpaceSeparatorToken = 23,
        // The following are output by the analysis system automatically, these should
        // not be used directly by the architecture plugins
        CodeSymbolToken = 64,
        DataSymbolToken = 65,
        LocalVariableToken = 66,
        ImportToken = 67,
        AddressDisplayToken = 68,
        IndirectImportToken = 69,
        ExternalSymbolToken = 70
    }

    public enum BNInstructionTextTokenContext
    {
        NoTokenContext = 0,
        LocalVariableTokenContext = 1,
        DataVariableTokenContext = 2,
        FunctionReturnTokenContext = 3
    }

    public enum BNLinearDisassemblyLineType
    {
        BlankLineType,
        CodeDisassemblyLineType,
        DataVariableLineType,
        HexDumpLineType,
        FunctionHeaderLineType,
        FunctionHeaderStartLineType,
        FunctionHeaderEndLineType,
        FunctionContinuationLineType,
        LocalVariableLineType,
        LocalVariableListEndLineType,
        FunctionEndLineType,
        NoteStartLineType,
        NoteLineType,
        NoteEndLineType,
        SectionStartLineType,
        SectionEndLineType,
        SectionSeparatorLineType,
        NonContiguousSeparatorLineType
    }

    public enum BNSymbolType
    {
        FunctionSymbol = 0,
        ImportAddressSymbol = 1,
        ImportedFunctionSymbol = 2,
        DataSymbol = 3,
        ImportedDataSymbol = 4,
        ExternalSymbol = 5
    }

    public enum BNSymbolBinding
    {
        NoBinding,
        LocalBinding,
        GlobalBinding,
        WeakBinding
    }

    public enum BNActionType
    {
        TemporaryAction = 0,
        DataModificationAction = 1,
        AnalysisAction = 2,
        DataModificationAndAnalysisAction = 3
    }

    public enum BNLowLevelILOperation
    {
        LLIL_NOP,
        LLIL_SET_REG, // Not valid in SSA form (see LLIL_SET_REG_SSA)
        LLIL_SET_REG_SPLIT, // Not valid in SSA form (see LLIL_SET_REG_SPLIT_SSA)
        LLIL_SET_FLAG, // Not valid in SSA form (see LLIL_SET_FLAG_SSA)
        LLIL_SET_REG_STACK_REL, // Not valid in SSA form (see LLIL_SET_REG_STACK_REL_SSA)
        LLIL_REG_STACK_PUSH, // Not valid in SSA form (expanded)
        LLIL_LOAD, // Not valid in SSA form (see LLIL_LOAD_SSA)
        LLIL_STORE, // Not valid in SSA form (see LLIL_STORE_SSA)
        LLIL_PUSH, // Not valid in SSA form (expanded)
        LLIL_POP, // Not valid in SSA form (expanded)
        LLIL_REG, // Not valid in SSA form (see LLIL_REG_SSA)
        LLIL_REG_SPLIT, // Not valid in SSA form (see LLIL_REG_SPLIT_SSA)
        LLIL_REG_STACK_REL, // Not valid in SSA form (see LLIL_REG_STACK_REL_SSA)
        LLIL_REG_STACK_POP, // Not valid in SSA form (expanded)
        LLIL_REG_STACK_FREE_REG, // Not valid in SSA form (see LLIL_REG_STACK_FREE_REL_SSA, LLIL_REG_STACK_FREE_ABS_SSA)
        LLIL_REG_STACK_FREE_REL, // Not valid in SSA from (see LLIL_REG_STACK_FREE_REL_SSA)
        LLIL_CONST,
        LLIL_CONST_PTR,
        LLIL_EXTERN_PTR,
        LLIL_FLOAT_CONST,
        LLIL_FLAG, // Not valid in SSA form (see LLIL_FLAG_SSA)
        LLIL_FLAG_BIT, // Not valid in SSA form (see LLIL_FLAG_BIT_SSA)
        LLIL_ADD,
        LLIL_ADC,
        LLIL_SUB,
        LLIL_SBB,
        LLIL_AND,
        LLIL_OR,
        LLIL_XOR,
        LLIL_LSL,
        LLIL_LSR,
        LLIL_ASR,
        LLIL_ROL,
        LLIL_RLC,
        LLIL_ROR,
        LLIL_RRC,
        LLIL_MUL,
        LLIL_MULU_DP,
        LLIL_MULS_DP,
        LLIL_DIVU,
        LLIL_DIVU_DP,
        LLIL_DIVS,
        LLIL_DIVS_DP,
        LLIL_MODU,
        LLIL_MODU_DP,
        LLIL_MODS,
        LLIL_MODS_DP,
        LLIL_NEG,
        LLIL_NOT,
        LLIL_SX,
        LLIL_ZX,
        LLIL_LOW_PART,
        LLIL_JUMP,
        LLIL_JUMP_TO,
        LLIL_CALL,
        LLIL_CALL_STACK_ADJUST,
        LLIL_TAILCALL,
        LLIL_RET,
        LLIL_NORET,
        LLIL_IF,
        LLIL_GOTO,
        LLIL_FLAG_COND, // Valid only in Lifted IL
        LLIL_FLAG_GROUP, // Valid only in Lifted IL
        LLIL_CMP_E,
        LLIL_CMP_NE,
        LLIL_CMP_SLT,
        LLIL_CMP_ULT,
        LLIL_CMP_SLE,
        LLIL_CMP_ULE,
        LLIL_CMP_SGE,
        LLIL_CMP_UGE,
        LLIL_CMP_SGT,
        LLIL_CMP_UGT,
        LLIL_TEST_BIT,
        LLIL_BOOL_TO_INT,
        LLIL_ADD_OVERFLOW,
        LLIL_SYSCALL,
        LLIL_BP,
        LLIL_TRAP,
        LLIL_INTRINSIC,
        LLIL_UNDEF,
        LLIL_UNIMPL,
        LLIL_UNIMPL_MEM,

        // Floating point
        LLIL_FADD,
        LLIL_FSUB,
        LLIL_FMUL,
        LLIL_FDIV,
        LLIL_FSQRT,
        LLIL_FNEG,
        LLIL_FABS,
        LLIL_FLOAT_TO_INT,
        LLIL_INT_TO_FLOAT,
        LLIL_FLOAT_CONV,
        LLIL_ROUND_TO_INT,
        LLIL_FLOOR,
        LLIL_CEIL,
        LLIL_FTRUNC,
        LLIL_FCMP_E,
        LLIL_FCMP_NE,
        LLIL_FCMP_LT,
        LLIL_FCMP_LE,
        LLIL_FCMP_GE,
        LLIL_FCMP_GT,
        LLIL_FCMP_O,
        LLIL_FCMP_UO,

        // The following instructions are only used in SSA form
        LLIL_SET_REG_SSA,
        LLIL_SET_REG_SSA_PARTIAL,
        LLIL_SET_REG_SPLIT_SSA,
        LLIL_SET_REG_STACK_REL_SSA,
        LLIL_SET_REG_STACK_ABS_SSA,
        LLIL_REG_SPLIT_DEST_SSA, // Only valid within an LLIL_SET_REG_SPLIT_SSA instruction
        LLIL_REG_STACK_DEST_SSA, // Only valid within LLIL_SET_REG_STACK_REL_SSA or LLIL_SET_REG_STACK_ABS_SSA
        LLIL_REG_SSA,
        LLIL_REG_SSA_PARTIAL,
        LLIL_REG_SPLIT_SSA,
        LLIL_REG_STACK_REL_SSA,
        LLIL_REG_STACK_ABS_SSA,
        LLIL_REG_STACK_FREE_REL_SSA,
        LLIL_REG_STACK_FREE_ABS_SSA,
        LLIL_SET_FLAG_SSA,
        LLIL_FLAG_SSA,
        LLIL_FLAG_BIT_SSA,
        LLIL_CALL_SSA,
        LLIL_SYSCALL_SSA,
        LLIL_TAILCALL_SSA,
        LLIL_CALL_PARAM, // Only valid within the LLIL_CALL_SSA, LLIL_SYSCALL_SSA, LLIL_INTRINSIC, LLIL_INTRINSIC_SSA instructions
        LLIL_CALL_STACK_SSA, // Only valid within the LLIL_CALL_SSA or LLIL_SYSCALL_SSA instructions
        LLIL_CALL_OUTPUT_SSA, // Only valid within the LLIL_CALL_SSA or LLIL_SYSCALL_SSA instructions
        LLIL_LOAD_SSA,
        LLIL_STORE_SSA,
        LLIL_INTRINSIC_SSA,
        LLIL_REG_PHI,
        LLIL_REG_STACK_PHI,
        LLIL_FLAG_PHI,
        LLIL_MEM_PHI
    }

    public enum BNLowLevelILFlagCondition
    {
        LLFC_E,
        LLFC_NE,
        LLFC_SLT,
        LLFC_ULT,
        LLFC_SLE,
        LLFC_ULE,
        LLFC_SGE,
        LLFC_UGE,
        LLFC_SGT,
        LLFC_UGT,
        LLFC_NEG,
        LLFC_POS,
        LLFC_O,
        LLFC_NO,
        LLFC_FE,
        LLFC_FNE,
        LLFC_FLT,
        LLFC_FLE,
        LLFC_FGE,
        LLFC_FGT,
        LLFC_FO,
        LLFC_FUO
    }

    public enum BNFlagRole
    {
        SpecialFlagRole = 0,
        ZeroFlagRole = 1,
        PositiveSignFlagRole = 2,
        NegativeSignFlagRole = 3,
        CarryFlagRole = 4,
        OverflowFlagRole = 5,
        HalfCarryFlagRole = 6,
        EvenParityFlagRole = 7,
        OddParityFlagRole = 8,
        OrderedFlagRole = 9,
        UnorderedFlagRole = 10
    }

    public enum BNFunctionGraphType
    {
        NormalFunctionGraph = 0,
        LowLevelILFunctionGraph = 1,
        LiftedILFunctionGraph = 2,
        LowLevelILSSAFormFunctionGraph = 3,
        MediumLevelILFunctionGraph = 4,
        MediumLevelILSSAFormFunctionGraph = 5,
        MappedMediumLevelILFunctionGraph = 6,
        MappedMediumLevelILSSAFormFunctionGraph = 7
    }

    public enum BNDisassemblyOption
    {
        ShowAddress = 0,
        ShowOpcode = 1,
        ExpandLongOpcode = 2,
        ShowVariablesAtTopOfGraph = 3,
        ShowVariableTypesWhenAssigned = 4,
        ShowDefaultRegisterTypes = 5,
        ShowCallParameterNames = 6,
        ShowRegisterHighlight = 7,

        // Linear disassembly options
        GroupLinearDisassemblyFunctions = 64,

        // Debugging options
        ShowFlagUsage = 128
    }

    public enum BNTypeClass
    {
        VoidTypeClass = 0,
        BoolTypeClass = 1,
        IntegerTypeClass = 2,
        FloatTypeClass = 3,
        StructureTypeClass = 4,
        EnumerationTypeClass = 5,
        PointerTypeClass = 6,
        ArrayTypeClass = 7,
        FunctionTypeClass = 8,
        VarArgsTypeClass = 9,
        ValueTypeClass = 10,
        NamedTypeReferenceClass = 11,
        WideCharTypeClass = 12
    }

    public enum BNNamedTypeReferenceClass
    {
        UnknownNamedTypeClass = 0,
        TypedefNamedTypeClass = 1,
        ClassNamedTypeClass = 2,
        StructNamedTypeClass = 3,
        UnionNamedTypeClass = 4,
        EnumNamedTypeClass = 5
    }

    public enum BNStructureType
    {
        ClassStructureType = 0,
        StructStructureType = 1,
        UnionStructureType = 2
    }

    public enum BNMemberScope
    {
        NoScope,
        StaticScope,
        VirtualScope,
        ThunkScope,
        FriendScope
    }

    public enum BNMemberAccess
    {
        NoAccess,
        PrivateAccess,
        ProtectedAccess,
        PublicAccess
    }

    public enum BNReferenceType
    {
        PointerReferenceType = 0,
        ReferenceReferenceType = 1,
        RValueReferenceType = 2,
        NoReference = 3
    }

    public enum BNPointerSuffix
    {
        Ptr64Suffix,
        UnalignedSuffix,
        RestrictSuffix,
        ReferenceSuffix,
        LvalueSuffix
    }

    public enum BNNameType
    {
        NoNameType,
        ConstructorNameType,
        DestructorNameType,
        OperatorNewNameType,
        OperatorDeleteNameType,
        OperatorAssignNameType,
        OperatorRightShiftNameType,
        OperatorLeftShiftNameType,
        OperatorNotNameType,
        OperatorEqualNameType,
        OperatorNotEqualNameType,
        OperatorArrayNameType,
        OperatorArrowNameType,
        OperatorStarNameType,
        OperatorIncrementNameType,
        OperatorDecrementNameType,
        OperatorMinusNameType,
        OperatorPlusNameType,
        OperatorBitAndNameType,
        OperatorArrowStarNameType,
        OperatorDivideNameType,
        OperatorModulusNameType,
        OperatorLessThanNameType,
        OperatorLessThanEqualNameType,
        OperatorGreaterThanNameType,
        OperatorGreaterThanEqualNameType,
        OperatorCommaNameType,
        OperatorParenthesesNameType,
        OperatorTildeNameType,
        OperatorXorNameType,
        OperatorBitOrNameType,
        OperatorLogicalAndNameType,
        OperatorLogicalOrNameType,
        OperatorStarEqualNameType,
        OperatorPlusEqualNameType,
        OperatorMinusEqualNameType,
        OperatorDivideEqualNameType,
        OperatorModulusEqualNameType,
        OperatorRightShiftEqualNameType,
        OperatorLeftShiftEqualNameType,
        OperatorAndEqualNameType,
        OperatorOrEqualNameType,
        OperatorXorEqualNameType,
        VFTableNameType,
        VBTableNameType,
        VCallNameType,
        TypeofNameType,
        LocalStaticGuardNameType,
        StringNameType,
        VBaseDestructorNameType,
        VectorDeletingDestructorNameType,
        DefaultConstructorClosureNameType,
        ScalarDeletingDestructorNameType,
        VectorConstructorIteratorNameType,
        VectorDestructorIteratorNameType,
        VectorVBaseConstructorIteratoreNameType,
        VirtualDisplacementMapNameType,
        EHVectorConstructorIteratorNameType,
        EHVectorDestructorIteratorNameType,
        EHVectorVBaseConstructorIteratorNameType,
        CopyConstructorClosureNameType,
        UDTReturningNameType,
        LocalVFTableNameType,
        LocalVFTableConstructorClosureNameType,
        OperatorNewArrayNameType,
        OperatorDeleteArrayNameType,
        PlacementDeleteClosureNameType,
        PlacementDeleteClosureArrayNameType,
        OperatorReturnTypeNameType,
        RttiTypeDescriptor,
        RttiBaseClassDescriptor,
        RttiBaseClassArray,
        RttiClassHeirarchyDescriptor,
        RttiCompleteObjectLocator,
        OperatorUnaryMinusNameType,
        OperatorUnaryPlusNameType,
        OperatorUnaryBitAndNameType,
        OperatorUnaryStarNameType
    }

    public enum BNCallingConventionName
    {
        NoCallingConvention,
        CdeclCallingConvention,
        PascalCallingConvention,
        ThisCallCallingConvention,
        STDCallCallingConvention,
        FastcallCallingConvention,
        CLRCallCallingConvention,
        EabiCallCallingConvention,
        VectorCallCallingConvention
    }

    public enum BNStringType
    {
        AsciiString = 0,
        Utf16String = 1,
        Utf32String = 2,
        Utf8String = 3
    }

    public enum BNIntegerDisplayType
    {
        DefaultIntegerDisplayType,
        BinaryDisplayType,
        SignedOctalDisplayType,
        UnsignedOctalDisplayType,
        SignedDecimalDisplayType,
        UnsignedDecimalDisplayType,
        SignedHexadecimalDisplayType,
        UnsignedHexadecimalDisplayType,
        CharacterConstantDisplayType,
        PointerDisplayType
    }

    public enum BNRegisterValueType
    {
        UndeterminedValue,
        EntryValue,
        ConstantValue,
        ConstantPointerValue,
        ExternalPointerValue,
        StackFrameOffset,
        ReturnAddressValue,
        ImportedAddressValue,

        // The following are only valid in BNPossibleValueSet
        SignedRangeValue,
        UnsignedRangeValue,
        LookupTableValue,
        InSetOfValues,
        NotInSetOfValues
    }

    public enum BNPluginOrigin
    {
        OfficialPluginOrigin,
        CommunityPluginOrigin,
        OtherPluginOrigin
    }

    public enum BNPluginUpdateStatus
    {
        UpToDatePluginStatus,
        UpdatesAvailablePluginStatus
    }

    public enum BNPluginType
    {
        CorePluginType,
        UiPluginType,
        ArchitecturePluginType,
        BinaryViewPluginType
    }

    public enum BNImplicitRegisterExtend
    {
        NoExtend,
        ZeroExtendToFullWidth,
        SignExtendToFullWidth
    }

    public enum BNMediumLevelILOperation
    {
        MLIL_NOP,
        MLIL_SET_VAR, // Not valid in SSA form (see MLIL_SET_VAR_SSA)
        MLIL_SET_VAR_FIELD, // Not valid in SSA form (see MLIL_SET_VAR_FIELD)
        MLIL_SET_VAR_SPLIT, // Not valid in SSA form (see MLIL_SET_VAR_SPLIT_SSA)
        MLIL_LOAD, // Not valid in SSA form (see MLIL_LOAD_SSA)
        MLIL_LOAD_STRUCT, // Not valid in SSA form (see MLIL_LOAD_STRUCT_SSA)
        MLIL_STORE, // Not valid in SSA form (see MLIL_STORE_SSA)
        MLIL_STORE_STRUCT, // Not valid in SSA form (see MLIL_STORE_STRUCT_SSA)
        MLIL_VAR, // Not valid in SSA form (see MLIL_VAR_SSA)
        MLIL_VAR_FIELD, // Not valid in SSA form (see MLIL_VAR_SSA_FIELD)
        MLIL_VAR_SPLIT, // Not valid in SSA form (see MLIL_VAR_SSA)
        MLIL_ADDRESS_OF,
        MLIL_ADDRESS_OF_FIELD,
        MLIL_CONST,
        MLIL_CONST_PTR,
        MLIL_EXTERN_PTR,
        MLIL_FLOAT_CONST,
        MLIL_IMPORT,
        MLIL_ADD,
        MLIL_ADC,
        MLIL_SUB,
        MLIL_SBB,
        MLIL_AND,
        MLIL_OR,
        MLIL_XOR,
        MLIL_LSL,
        MLIL_LSR,
        MLIL_ASR,
        MLIL_ROL,
        MLIL_RLC,
        MLIL_ROR,
        MLIL_RRC,
        MLIL_MUL,
        MLIL_MULU_DP,
        MLIL_MULS_DP,
        MLIL_DIVU,
        MLIL_DIVU_DP,
        MLIL_DIVS,
        MLIL_DIVS_DP,
        MLIL_MODU,
        MLIL_MODU_DP,
        MLIL_MODS,
        MLIL_MODS_DP,
        MLIL_NEG,
        MLIL_NOT,
        MLIL_SX,
        MLIL_ZX,
        MLIL_LOW_PART,
        MLIL_JUMP,
        MLIL_JUMP_TO,
        MLIL_RET_HINT, // Intermediate stages, does not appear in final forms
        MLIL_CALL, // Not valid in SSA form (see MLIL_CALL_SSA)
        MLIL_CALL_UNTYPED, // Not valid in SSA form (see MLIL_CALL_UNTYPED_SSA)
        MLIL_CALL_OUTPUT, // Only valid within MLIL_CALL, MLIL_SYSCALL, MLIL_TAILCALL family instructions
        MLIL_CALL_PARAM, // Only valid within MLIL_CALL, MLIL_SYSCALL, MLIL_TAILCALL family instructions
        MLIL_RET, // Not valid in SSA form (see MLIL_RET_SSA)
        MLIL_NORET,
        MLIL_IF,
        MLIL_GOTO,
        MLIL_CMP_E,
        MLIL_CMP_NE,
        MLIL_CMP_SLT,
        MLIL_CMP_ULT,
        MLIL_CMP_SLE,
        MLIL_CMP_ULE,
        MLIL_CMP_SGE,
        MLIL_CMP_UGE,
        MLIL_CMP_SGT,
        MLIL_CMP_UGT,
        MLIL_TEST_BIT,
        MLIL_BOOL_TO_INT,
        MLIL_ADD_OVERFLOW,
        MLIL_SYSCALL, // Not valid in SSA form (see MLIL_SYSCALL_SSA)
        MLIL_SYSCALL_UNTYPED, // Not valid in SSA form (see MLIL_SYSCALL_UNTYPED_SSA)
        MLIL_TAILCALL, // Not valid in SSA form (see MLIL_TAILCALL_SSA)
        MLIL_TAILCALL_UNTYPED, // Not valid in SSA form (see MLIL_TAILCALL_UNTYPED_SSA)
        MLIL_INTRINSIC, // Not valid in SSA form (see MLIL_INTRINSIC_SSA)
        MLIL_FREE_VAR_SLOT, // Not valid in SSA from (see MLIL_FREE_VAR_SLOT_SSA)
        MLIL_BP,
        MLIL_TRAP,
        MLIL_UNDEF,
        MLIL_UNIMPL,
        MLIL_UNIMPL_MEM,

        // Floating point
        MLIL_FADD,
        MLIL_FSUB,
        MLIL_FMUL,
        MLIL_FDIV,
        MLIL_FSQRT,
        MLIL_FNEG,
        MLIL_FABS,
        MLIL_FLOAT_TO_INT,
        MLIL_INT_TO_FLOAT,
        MLIL_FLOAT_CONV,
        MLIL_ROUND_TO_INT,
        MLIL_FLOOR,
        MLIL_CEIL,
        MLIL_FTRUNC,
        MLIL_FCMP_E,
        MLIL_FCMP_NE,
        MLIL_FCMP_LT,
        MLIL_FCMP_LE,
        MLIL_FCMP_GE,
        MLIL_FCMP_GT,
        MLIL_FCMP_O,
        MLIL_FCMP_UO,

        // The following instructions are only used in SSA form
        MLIL_SET_VAR_SSA,
        MLIL_SET_VAR_SSA_FIELD,
        MLIL_SET_VAR_SPLIT_SSA,
        MLIL_SET_VAR_ALIASED,
        MLIL_SET_VAR_ALIASED_FIELD,
        MLIL_VAR_SSA,
        MLIL_VAR_SSA_FIELD,
        MLIL_VAR_ALIASED,
        MLIL_VAR_ALIASED_FIELD,
        MLIL_VAR_SPLIT_SSA,
        MLIL_CALL_SSA,
        MLIL_CALL_UNTYPED_SSA,
        MLIL_SYSCALL_SSA,
        MLIL_SYSCALL_UNTYPED_SSA,
        MLIL_TAILCALL_SSA,
        MLIL_TAILCALL_UNTYPED_SSA,
        MLIL_CALL_PARAM_SSA, // Only valid within the MLIL_CALL_SSA, MLIL_SYSCALL_SSA, MLIL_TAILCALL_SSA family instructions
        MLIL_CALL_OUTPUT_SSA, // Only valid within the MLIL_CALL_SSA or MLIL_SYSCALL_SSA, MLIL_TAILCALL_SSA family instructions
        MLIL_LOAD_SSA,
        MLIL_LOAD_STRUCT_SSA,
        MLIL_STORE_SSA,
        MLIL_STORE_STRUCT_SSA,
        MLIL_INTRINSIC_SSA,
        MLIL_FREE_VAR_SLOT_SSA,
        MLIL_VAR_PHI,
        MLIL_MEM_PHI
    }

    public enum BNVariableSourceType
    {
        StackVariableSourceType,
        RegisterVariableSourceType,
        FlagVariableSourceType
    }

    public enum BNRelocationType
    {
        ELFGlobalRelocationType,
        ELFCopyRelocationType,
        ELFJumpSlotRelocationType,
        StandardRelocationType,
        IgnoredRelocation
    }

    public enum BNHighlightColorStyle
    {
        StandardHighlightColor = 0,
        MixedHighlightColor = 1,
        CustomHighlightColor = 2
    }

    public enum BNHighlightStandardColor
    {
        NoHighlightColor = 0,
        BlueHighlightColor = 1,
        GreenHighlightColor = 2,
        CyanHighlightColor = 3,
        RedHighlightColor = 4,
        MagentaHighlightColor = 5,
        YellowHighlightColor = 6,
        OrangeHighlightColor = 7,
        WhiteHighlightColor = 8,
        BlackHighlightColor = 9
    }

    public enum BNUpdateResult
    {
        UpdateFailed = 0,
        UpdateSuccess = 1,
        AlreadyUpToDate = 2,
        UpdateAvailable = 3
    }

    public enum BNPluginCommandType
    {
        DefaultPluginCommand,
        AddressPluginCommand,
        RangePluginCommand,
        FunctionPluginCommand,
        LowLevelILFunctionPluginCommand,
        LowLevelILInstructionPluginCommand,
        MediumLevelILFunctionPluginCommand,
        MediumLevelILInstructionPluginCommand
    }

    public enum BNAnalysisState
    {
        IdleState,
        DisassembleState,
        AnalyzeState,
        ExtendedAnalyzeState
    }

    public enum BNFindFlag
    {
        FindCaseSensitive = 0,
        FindCaseInsensitive = 1
    }

    public enum BNScriptingProviderInputReadyState
    {
        NotReadyForInput,
        ReadyForScriptExecution,
        ReadyForScriptProgramInput
    }

    public enum BNScriptingProviderExecuteResult
    {
        InvalidScriptInput,
        IncompleteScriptInput,
        SuccessfulScriptExecution
    }

    public enum BNMessageBoxIcon
    {
        InformationIcon,
        QuestionIcon,
        WarningIcon,
        ErrorIcon
    }

    public enum BNMessageBoxButtonSet
    {
        OKButtonSet,
        YesNoButtonSet,
        YesNoCancelButtonSet
    }

    public enum BNMessageBoxButtonResult
    {
        NoButton = 0,
        YesButton = 1,
        OKButton = 2,
        CancelButton = 3
    }

    public enum BNFormInputFieldType
    {
        LabelFormField,
        SeparatorFormField,
        TextLineFormField,
        MultilineTextFormField,
        IntegerFormField,
        AddressFormField,
        ChoiceFormField,
        OpenFileNameFormField,
        SaveFileNameFormField,
        DirectoryNameFormField
    }

    public enum BNSegmentFlag
    {
        SegmentExecutable = 1,
        SegmentWritable = 2,
        SegmentReadable = 4,
        SegmentContainsData = 8,
        SegmentContainsCode = 0x10,
        SegmentDenyWrite = 0x20,
        SegmentDenyExecute = 0x40
    }

    public enum BNSectionSemantics
    {
        DefaultSectionSemantics,
        ReadOnlyCodeSectionSemantics,
        ReadOnlyDataSectionSemantics,
        ReadWriteDataSectionSemantics,
        ExternalSectionSemantics
    }

    public enum BNILBranchDependence
    {
        NotBranchDependent,
        TrueBranchDependent,
        FalseBranchDependent
    }

    public enum BNMetadataType
    {
        InvalidDataType,
        BooleanDataType,
        StringDataType,
        UnsignedIntegerDataType,
        SignedIntegerDataType,
        DoubleDataType,
        RawDataType,
        KeyValueDataType,
        ArrayDataType
    }

    public enum BNFunctionAnalysisSkipOverride
    {
        DefaultFunctionAnalysisSkip,
        NeverSkipFunctionAnalysis,
        AlwaysSkipFunctionAnalysis
    }

    public enum BNReportType
    {
        PlainTextReportType,
        MarkdownReportType,
        HTMLReportType,
        FlowGraphReportType
    }

    public enum BNAnalysisSkipReason
    {
        NoSkipReason,
        AlwaysSkipReason,
        ExceedFunctionSizeSkipReason,
        ExceedFunctionAnalysisTimeSkipReason,
        ExceedFunctionUpdateCountSkipReason,
        NewAutoFunctionAnalysisSuppressedReason
    }

    public enum BNSettingsScope
    {
        SettingsInvalidScope = 0,
        SettingsAutoScope = 1,
        SettingsDefaultScope = 2,
        SettingsUserScope = 3,
        SettingsWorkspaceScope = 4,
        SettingsContextScope = 5
    }
}