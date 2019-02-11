
namespace BinaryNinja
{
	public enum ActionType
	{
		TemporaryAction = 0,
		DataModificationAction = 1,
		AnalysisAction = 2,
		DataModificationAndAnalysisAction = 3
	}
	public enum AnalysisSkipReason
	{
		NoSkipReason = 0,
		AlwaysSkipReason = 1,
		ExceedFunctionSizeSkipReason = 2,
		ExceedFunctionAnalysisTimeSkipReason = 3,
		ExceedFunctionUpdateCountSkipReason = 4,
		NewAutoFunctionAnalysisSuppressedReason = 5
	}
	public enum AnalysisState
	{
		IdleState = 0,
		DisassembleState = 1,
		AnalyzeState = 2,
		ExtendedAnalyzeState = 3
	}
	public enum BranchType
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
	public enum CallingConventionName
	{
		NoCallingConvention = 0,
		CdeclCallingConvention = 1,
		PascalCallingConvention = 2,
		ThisCallCallingConvention = 3,
		STDCallCallingConvention = 4,
		FastcallCallingConvention = 5,
		CLRCallCallingConvention = 6,
		EabiCallCallingConvention = 7,
		VectorCallCallingConvention = 8
	}
	public enum DisassemblyOption
	{
		ShowAddress = 0,
		ShowOpcode = 1,
		ExpandLongOpcode = 2,
		ShowVariablesAtTopOfGraph = 3,
		ShowVariableTypesWhenAssigned = 4,
		ShowDefaultRegisterTypes = 5,
		ShowCallParameterNames = 6,
		ShowRegisterHighlight = 7,
		GroupLinearDisassemblyFunctions = 64,
		ShowFlagUsage = 128
	}
	public enum Endianness
	{
		LittleEndian = 0,
		BigEndian = 1
	}
	public enum FindFlag
	{
		FindCaseSensitive = 0,
		FindCaseInsensitive = 1
	}
	public enum FlagRole
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
	public enum FormInputFieldType
	{
		LabelFormField = 0,
		SeparatorFormField = 1,
		TextLineFormField = 2,
		MultilineTextFormField = 3,
		IntegerFormField = 4,
		AddressFormField = 5,
		ChoiceFormField = 6,
		OpenFileNameFormField = 7,
		SaveFileNameFormField = 8,
		DirectoryNameFormField = 9
	}
	public enum FunctionAnalysisSkipOverride
	{
		DefaultFunctionAnalysisSkip = 0,
		NeverSkipFunctionAnalysis = 1,
		AlwaysSkipFunctionAnalysis = 2
	}
	public enum FunctionGraphType
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
	public enum HighlightColorStyle
	{
		StandardHighlightColor = 0,
		MixedHighlightColor = 1,
		CustomHighlightColor = 2
	}
	public enum HighlightStandardColor
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
	public enum ILBranchDependence
	{
		NotBranchDependent = 0,
		TrueBranchDependent = 1,
		FalseBranchDependent = 2
	}
	public enum ImplicitRegisterExtend
	{
		NoExtend = 0,
		ZeroExtendToFullWidth = 1,
		SignExtendToFullWidth = 2
	}
	public enum InstructionTextTokenContext
	{
		NoTokenContext = 0,
		LocalVariableTokenContext = 1,
		DataVariableTokenContext = 2,
		FunctionReturnTokenContext = 3
	}
	public enum InstructionTextTokenType
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
		CodeSymbolToken = 64,
		DataSymbolToken = 65,
		LocalVariableToken = 66,
		ImportToken = 67,
		AddressDisplayToken = 68,
		IndirectImportToken = 69,
		ExternalSymbolToken = 70
	}
	public enum IntegerDisplayType
	{
		DefaultIntegerDisplayType = 0,
		BinaryDisplayType = 1,
		SignedOctalDisplayType = 2,
		UnsignedOctalDisplayType = 3,
		SignedDecimalDisplayType = 4,
		UnsignedDecimalDisplayType = 5,
		SignedHexadecimalDisplayType = 6,
		UnsignedHexadecimalDisplayType = 7,
		CharacterConstantDisplayType = 8,
		PointerDisplayType = 9
	}
	public enum LinearDisassemblyLineType
	{
		BlankLineType = 0,
		CodeDisassemblyLineType = 1,
		DataVariableLineType = 2,
		HexDumpLineType = 3,
		FunctionHeaderLineType = 4,
		FunctionHeaderStartLineType = 5,
		FunctionHeaderEndLineType = 6,
		FunctionContinuationLineType = 7,
		LocalVariableLineType = 8,
		LocalVariableListEndLineType = 9,
		FunctionEndLineType = 10,
		NoteStartLineType = 11,
		NoteLineType = 12,
		NoteEndLineType = 13,
		SectionStartLineType = 14,
		SectionEndLineType = 15,
		SectionSeparatorLineType = 16,
		NonContiguousSeparatorLineType = 17
	}
	public enum LogLevel
	{
		DebugLog = 0,
		InfoLog = 1,
		WarningLog = 2,
		ErrorLog = 3,
		AlertLog = 4
	}
	public enum LowLevelILFlagCondition
	{
		LLFC_E = 0,
		LLFC_NE = 1,
		LLFC_SLT = 2,
		LLFC_ULT = 3,
		LLFC_SLE = 4,
		LLFC_ULE = 5,
		LLFC_SGE = 6,
		LLFC_UGE = 7,
		LLFC_SGT = 8,
		LLFC_UGT = 9,
		LLFC_NEG = 10,
		LLFC_POS = 11,
		LLFC_O = 12,
		LLFC_NO = 13,
		LLFC_FE = 14,
		LLFC_FNE = 15,
		LLFC_FLT = 16,
		LLFC_FLE = 17,
		LLFC_FGE = 18,
		LLFC_FGT = 19,
		LLFC_FO = 20,
		LLFC_FUO = 21
	}
	public enum LowLevelILOperation
	{
		LLIL_NOP = 0,
		LLIL_SET_REG = 1,
		LLIL_SET_REG_SPLIT = 2,
		LLIL_SET_FLAG = 3,
		LLIL_SET_REG_STACK_REL = 4,
		LLIL_REG_STACK_PUSH = 5,
		LLIL_LOAD = 6,
		LLIL_STORE = 7,
		LLIL_PUSH = 8,
		LLIL_POP = 9,
		LLIL_REG = 10,
		LLIL_REG_SPLIT = 11,
		LLIL_REG_STACK_REL = 12,
		LLIL_REG_STACK_POP = 13,
		LLIL_REG_STACK_FREE_REG = 14,
		LLIL_REG_STACK_FREE_REL = 15,
		LLIL_CONST = 16,
		LLIL_CONST_PTR = 17,
		LLIL_EXTERN_PTR = 18,
		LLIL_FLOAT_CONST = 19,
		LLIL_FLAG = 20,
		LLIL_FLAG_BIT = 21,
		LLIL_ADD = 22,
		LLIL_ADC = 23,
		LLIL_SUB = 24,
		LLIL_SBB = 25,
		LLIL_AND = 26,
		LLIL_OR = 27,
		LLIL_XOR = 28,
		LLIL_LSL = 29,
		LLIL_LSR = 30,
		LLIL_ASR = 31,
		LLIL_ROL = 32,
		LLIL_RLC = 33,
		LLIL_ROR = 34,
		LLIL_RRC = 35,
		LLIL_MUL = 36,
		LLIL_MULU_DP = 37,
		LLIL_MULS_DP = 38,
		LLIL_DIVU = 39,
		LLIL_DIVU_DP = 40,
		LLIL_DIVS = 41,
		LLIL_DIVS_DP = 42,
		LLIL_MODU = 43,
		LLIL_MODU_DP = 44,
		LLIL_MODS = 45,
		LLIL_MODS_DP = 46,
		LLIL_NEG = 47,
		LLIL_NOT = 48,
		LLIL_SX = 49,
		LLIL_ZX = 50,
		LLIL_LOW_PART = 51,
		LLIL_JUMP = 52,
		LLIL_JUMP_TO = 53,
		LLIL_CALL = 54,
		LLIL_CALL_STACK_ADJUST = 55,
		LLIL_TAILCALL = 56,
		LLIL_RET = 57,
		LLIL_NORET = 58,
		LLIL_IF = 59,
		LLIL_GOTO = 60,
		LLIL_FLAG_COND = 61,
		LLIL_FLAG_GROUP = 62,
		LLIL_CMP_E = 63,
		LLIL_CMP_NE = 64,
		LLIL_CMP_SLT = 65,
		LLIL_CMP_ULT = 66,
		LLIL_CMP_SLE = 67,
		LLIL_CMP_ULE = 68,
		LLIL_CMP_SGE = 69,
		LLIL_CMP_UGE = 70,
		LLIL_CMP_SGT = 71,
		LLIL_CMP_UGT = 72,
		LLIL_TEST_BIT = 73,
		LLIL_BOOL_TO_INT = 74,
		LLIL_ADD_OVERFLOW = 75,
		LLIL_SYSCALL = 76,
		LLIL_BP = 77,
		LLIL_TRAP = 78,
		LLIL_INTRINSIC = 79,
		LLIL_UNDEF = 80,
		LLIL_UNIMPL = 81,
		LLIL_UNIMPL_MEM = 82,
		LLIL_FADD = 83,
		LLIL_FSUB = 84,
		LLIL_FMUL = 85,
		LLIL_FDIV = 86,
		LLIL_FSQRT = 87,
		LLIL_FNEG = 88,
		LLIL_FABS = 89,
		LLIL_FLOAT_TO_INT = 90,
		LLIL_INT_TO_FLOAT = 91,
		LLIL_FLOAT_CONV = 92,
		LLIL_ROUND_TO_INT = 93,
		LLIL_FLOOR = 94,
		LLIL_CEIL = 95,
		LLIL_FTRUNC = 96,
		LLIL_FCMP_E = 97,
		LLIL_FCMP_NE = 98,
		LLIL_FCMP_LT = 99,
		LLIL_FCMP_LE = 100,
		LLIL_FCMP_GE = 101,
		LLIL_FCMP_GT = 102,
		LLIL_FCMP_O = 103,
		LLIL_FCMP_UO = 104,
		LLIL_SET_REG_SSA = 105,
		LLIL_SET_REG_SSA_PARTIAL = 106,
		LLIL_SET_REG_SPLIT_SSA = 107,
		LLIL_SET_REG_STACK_REL_SSA = 108,
		LLIL_SET_REG_STACK_ABS_SSA = 109,
		LLIL_REG_SPLIT_DEST_SSA = 110,
		LLIL_REG_STACK_DEST_SSA = 111,
		LLIL_REG_SSA = 112,
		LLIL_REG_SSA_PARTIAL = 113,
		LLIL_REG_SPLIT_SSA = 114,
		LLIL_REG_STACK_REL_SSA = 115,
		LLIL_REG_STACK_ABS_SSA = 116,
		LLIL_REG_STACK_FREE_REL_SSA = 117,
		LLIL_REG_STACK_FREE_ABS_SSA = 118,
		LLIL_SET_FLAG_SSA = 119,
		LLIL_FLAG_SSA = 120,
		LLIL_FLAG_BIT_SSA = 121,
		LLIL_CALL_SSA = 122,
		LLIL_SYSCALL_SSA = 123,
		LLIL_TAILCALL_SSA = 124,
		LLIL_CALL_PARAM = 125,
		LLIL_CALL_STACK_SSA = 126,
		LLIL_CALL_OUTPUT_SSA = 127,
		LLIL_LOAD_SSA = 128,
		LLIL_STORE_SSA = 129,
		LLIL_INTRINSIC_SSA = 130,
		LLIL_REG_PHI = 131,
		LLIL_REG_STACK_PHI = 132,
		LLIL_FLAG_PHI = 133,
		LLIL_MEM_PHI = 134
	}
	public enum MediumLevelILOperation
	{
		MLIL_NOP = 0,
		MLIL_SET_VAR = 1,
		MLIL_SET_VAR_FIELD = 2,
		MLIL_SET_VAR_SPLIT = 3,
		MLIL_LOAD = 4,
		MLIL_LOAD_STRUCT = 5,
		MLIL_STORE = 6,
		MLIL_STORE_STRUCT = 7,
		MLIL_VAR = 8,
		MLIL_VAR_FIELD = 9,
		MLIL_VAR_SPLIT = 10,
		MLIL_ADDRESS_OF = 11,
		MLIL_ADDRESS_OF_FIELD = 12,
		MLIL_CONST = 13,
		MLIL_CONST_PTR = 14,
		MLIL_EXTERN_PTR = 15,
		MLIL_FLOAT_CONST = 16,
		MLIL_IMPORT = 17,
		MLIL_ADD = 18,
		MLIL_ADC = 19,
		MLIL_SUB = 20,
		MLIL_SBB = 21,
		MLIL_AND = 22,
		MLIL_OR = 23,
		MLIL_XOR = 24,
		MLIL_LSL = 25,
		MLIL_LSR = 26,
		MLIL_ASR = 27,
		MLIL_ROL = 28,
		MLIL_RLC = 29,
		MLIL_ROR = 30,
		MLIL_RRC = 31,
		MLIL_MUL = 32,
		MLIL_MULU_DP = 33,
		MLIL_MULS_DP = 34,
		MLIL_DIVU = 35,
		MLIL_DIVU_DP = 36,
		MLIL_DIVS = 37,
		MLIL_DIVS_DP = 38,
		MLIL_MODU = 39,
		MLIL_MODU_DP = 40,
		MLIL_MODS = 41,
		MLIL_MODS_DP = 42,
		MLIL_NEG = 43,
		MLIL_NOT = 44,
		MLIL_SX = 45,
		MLIL_ZX = 46,
		MLIL_LOW_PART = 47,
		MLIL_JUMP = 48,
		MLIL_JUMP_TO = 49,
		MLIL_RET_HINT = 50,
		MLIL_CALL = 51,
		MLIL_CALL_UNTYPED = 52,
		MLIL_CALL_OUTPUT = 53,
		MLIL_CALL_PARAM = 54,
		MLIL_RET = 55,
		MLIL_NORET = 56,
		MLIL_IF = 57,
		MLIL_GOTO = 58,
		MLIL_CMP_E = 59,
		MLIL_CMP_NE = 60,
		MLIL_CMP_SLT = 61,
		MLIL_CMP_ULT = 62,
		MLIL_CMP_SLE = 63,
		MLIL_CMP_ULE = 64,
		MLIL_CMP_SGE = 65,
		MLIL_CMP_UGE = 66,
		MLIL_CMP_SGT = 67,
		MLIL_CMP_UGT = 68,
		MLIL_TEST_BIT = 69,
		MLIL_BOOL_TO_INT = 70,
		MLIL_ADD_OVERFLOW = 71,
		MLIL_SYSCALL = 72,
		MLIL_SYSCALL_UNTYPED = 73,
		MLIL_TAILCALL = 74,
		MLIL_TAILCALL_UNTYPED = 75,
		MLIL_INTRINSIC = 76,
		MLIL_FREE_VAR_SLOT = 77,
		MLIL_BP = 78,
		MLIL_TRAP = 79,
		MLIL_UNDEF = 80,
		MLIL_UNIMPL = 81,
		MLIL_UNIMPL_MEM = 82,
		MLIL_FADD = 83,
		MLIL_FSUB = 84,
		MLIL_FMUL = 85,
		MLIL_FDIV = 86,
		MLIL_FSQRT = 87,
		MLIL_FNEG = 88,
		MLIL_FABS = 89,
		MLIL_FLOAT_TO_INT = 90,
		MLIL_INT_TO_FLOAT = 91,
		MLIL_FLOAT_CONV = 92,
		MLIL_ROUND_TO_INT = 93,
		MLIL_FLOOR = 94,
		MLIL_CEIL = 95,
		MLIL_FTRUNC = 96,
		MLIL_FCMP_E = 97,
		MLIL_FCMP_NE = 98,
		MLIL_FCMP_LT = 99,
		MLIL_FCMP_LE = 100,
		MLIL_FCMP_GE = 101,
		MLIL_FCMP_GT = 102,
		MLIL_FCMP_O = 103,
		MLIL_FCMP_UO = 104,
		MLIL_SET_VAR_SSA = 105,
		MLIL_SET_VAR_SSA_FIELD = 106,
		MLIL_SET_VAR_SPLIT_SSA = 107,
		MLIL_SET_VAR_ALIASED = 108,
		MLIL_SET_VAR_ALIASED_FIELD = 109,
		MLIL_VAR_SSA = 110,
		MLIL_VAR_SSA_FIELD = 111,
		MLIL_VAR_ALIASED = 112,
		MLIL_VAR_ALIASED_FIELD = 113,
		MLIL_VAR_SPLIT_SSA = 114,
		MLIL_CALL_SSA = 115,
		MLIL_CALL_UNTYPED_SSA = 116,
		MLIL_SYSCALL_SSA = 117,
		MLIL_SYSCALL_UNTYPED_SSA = 118,
		MLIL_TAILCALL_SSA = 119,
		MLIL_TAILCALL_UNTYPED_SSA = 120,
		MLIL_CALL_PARAM_SSA = 121,
		MLIL_CALL_OUTPUT_SSA = 122,
		MLIL_LOAD_SSA = 123,
		MLIL_LOAD_STRUCT_SSA = 124,
		MLIL_STORE_SSA = 125,
		MLIL_STORE_STRUCT_SSA = 126,
		MLIL_INTRINSIC_SSA = 127,
		MLIL_FREE_VAR_SLOT_SSA = 128,
		MLIL_VAR_PHI = 129,
		MLIL_MEM_PHI = 130
	}
	public enum MemberAccess
	{
		NoAccess = 0,
		PrivateAccess = 1,
		ProtectedAccess = 2,
		PublicAccess = 3
	}
	public enum MemberScope
	{
		NoScope = 0,
		StaticScope = 1,
		VirtualScope = 2,
		ThunkScope = 3,
		FriendScope = 4
	}
	public enum MessageBoxButtonResult
	{
		NoButton = 0,
		YesButton = 1,
		OKButton = 2,
		CancelButton = 3
	}
	public enum MessageBoxButtonSet
	{
		OKButtonSet = 0,
		YesNoButtonSet = 1,
		YesNoCancelButtonSet = 2
	}
	public enum MessageBoxIcon
	{
		InformationIcon = 0,
		QuestionIcon = 1,
		WarningIcon = 2,
		ErrorIcon = 3
	}
	public enum MetadataType
	{
		InvalidDataType = 0,
		BooleanDataType = 1,
		StringDataType = 2,
		UnsignedIntegerDataType = 3,
		SignedIntegerDataType = 4,
		DoubleDataType = 5,
		RawDataType = 6,
		KeyValueDataType = 7,
		ArrayDataType = 8
	}
	public enum ModificationStatus
	{
		Original = 0,
		Changed = 1,
		Inserted = 2
	}
	public enum NameType
	{
		NoNameType = 0,
		ConstructorNameType = 1,
		DestructorNameType = 2,
		OperatorNewNameType = 3,
		OperatorDeleteNameType = 4,
		OperatorAssignNameType = 5,
		OperatorRightShiftNameType = 6,
		OperatorLeftShiftNameType = 7,
		OperatorNotNameType = 8,
		OperatorEqualNameType = 9,
		OperatorNotEqualNameType = 10,
		OperatorArrayNameType = 11,
		OperatorArrowNameType = 12,
		OperatorStarNameType = 13,
		OperatorIncrementNameType = 14,
		OperatorDecrementNameType = 15,
		OperatorMinusNameType = 16,
		OperatorPlusNameType = 17,
		OperatorBitAndNameType = 18,
		OperatorArrowStarNameType = 19,
		OperatorDivideNameType = 20,
		OperatorModulusNameType = 21,
		OperatorLessThanNameType = 22,
		OperatorLessThanEqualNameType = 23,
		OperatorGreaterThanNameType = 24,
		OperatorGreaterThanEqualNameType = 25,
		OperatorCommaNameType = 26,
		OperatorParenthesesNameType = 27,
		OperatorTildeNameType = 28,
		OperatorXorNameType = 29,
		OperatorBitOrNameType = 30,
		OperatorLogicalAndNameType = 31,
		OperatorLogicalOrNameType = 32,
		OperatorStarEqualNameType = 33,
		OperatorPlusEqualNameType = 34,
		OperatorMinusEqualNameType = 35,
		OperatorDivideEqualNameType = 36,
		OperatorModulusEqualNameType = 37,
		OperatorRightShiftEqualNameType = 38,
		OperatorLeftShiftEqualNameType = 39,
		OperatorAndEqualNameType = 40,
		OperatorOrEqualNameType = 41,
		OperatorXorEqualNameType = 42,
		VFTableNameType = 43,
		VBTableNameType = 44,
		VCallNameType = 45,
		TypeofNameType = 46,
		LocalStaticGuardNameType = 47,
		StringNameType = 48,
		VBaseDestructorNameType = 49,
		VectorDeletingDestructorNameType = 50,
		DefaultConstructorClosureNameType = 51,
		ScalarDeletingDestructorNameType = 52,
		VectorConstructorIteratorNameType = 53,
		VectorDestructorIteratorNameType = 54,
		VectorVBaseConstructorIteratoreNameType = 55,
		VirtualDisplacementMapNameType = 56,
		EHVectorConstructorIteratorNameType = 57,
		EHVectorDestructorIteratorNameType = 58,
		EHVectorVBaseConstructorIteratorNameType = 59,
		CopyConstructorClosureNameType = 60,
		UDTReturningNameType = 61,
		LocalVFTableNameType = 62,
		LocalVFTableConstructorClosureNameType = 63,
		OperatorNewArrayNameType = 64,
		OperatorDeleteArrayNameType = 65,
		PlacementDeleteClosureNameType = 66,
		PlacementDeleteClosureArrayNameType = 67,
		OperatorReturnTypeNameType = 68,
		RttiTypeDescriptor = 69,
		RttiBaseClassDescriptor = 70,
		RttiBaseClassArray = 71,
		RttiClassHeirarchyDescriptor = 72,
		RttiCompleteObjectLocator = 73,
		OperatorUnaryMinusNameType = 74,
		OperatorUnaryPlusNameType = 75,
		OperatorUnaryBitAndNameType = 76,
		OperatorUnaryStarNameType = 77
	}
	public enum NamedTypeReferenceClass
	{
		UnknownNamedTypeClass = 0,
		TypedefNamedTypeClass = 1,
		ClassNamedTypeClass = 2,
		StructNamedTypeClass = 3,
		UnionNamedTypeClass = 4,
		EnumNamedTypeClass = 5
	}
	public enum PluginCommandType
	{
		DefaultPluginCommand = 0,
		AddressPluginCommand = 1,
		RangePluginCommand = 2,
		FunctionPluginCommand = 3,
		LowLevelILFunctionPluginCommand = 4,
		LowLevelILInstructionPluginCommand = 5,
		MediumLevelILFunctionPluginCommand = 6,
		MediumLevelILInstructionPluginCommand = 7
	}
	public enum PluginLoadOrder
	{
		EarlyPluginLoadOrder = 0,
		NormalPluginLoadOrder = 1,
		LatePluginLoadOrder = 2
	}
	public enum PluginOrigin
	{
		OfficialPluginOrigin = 0,
		CommunityPluginOrigin = 1,
		OtherPluginOrigin = 2
	}
	public enum PluginType
	{
		CorePluginType = 0,
		UiPluginType = 1,
		ArchitecturePluginType = 2,
		BinaryViewPluginType = 3
	}
	public enum PluginUpdateStatus
	{
		UpToDatePluginStatus = 0,
		UpdatesAvailablePluginStatus = 1
	}
	public enum PointerSuffix
	{
		Ptr64Suffix = 0,
		UnalignedSuffix = 1,
		RestrictSuffix = 2,
		ReferenceSuffix = 3,
		LvalueSuffix = 4
	}
	public enum ReferenceType
	{
		PointerReferenceType = 0,
		ReferenceReferenceType = 1,
		RValueReferenceType = 2,
		NoReference = 3
	}
	public enum RegisterValueType
	{
		UndeterminedValue = 0,
		EntryValue = 1,
		ConstantValue = 2,
		ConstantPointerValue = 3,
		ExternalPointerValue = 4,
		StackFrameOffset = 5,
		ReturnAddressValue = 6,
		ImportedAddressValue = 7,
		SignedRangeValue = 8,
		UnsignedRangeValue = 9,
		LookupTableValue = 10,
		InSetOfValues = 11,
		NotInSetOfValues = 12
	}
	public enum RelocationType
	{
		ELFGlobalRelocationType = 0,
		ELFCopyRelocationType = 1,
		ELFJumpSlotRelocationType = 2,
		StandardRelocationType = 3,
		IgnoredRelocation = 4
	}
	public enum ReportType
	{
		PlainTextReportType = 0,
		MarkdownReportType = 1,
		HTMLReportType = 2,
		FlowGraphReportType = 3
	}
	public enum ScriptingProviderExecuteResult
	{
		InvalidScriptInput = 0,
		IncompleteScriptInput = 1,
		SuccessfulScriptExecution = 2
	}
	public enum ScriptingProviderInputReadyState
	{
		NotReadyForInput = 0,
		ReadyForScriptExecution = 1,
		ReadyForScriptProgramInput = 2
	}
	public enum SectionSemantics
	{
		DefaultSectionSemantics = 0,
		ReadOnlyCodeSectionSemantics = 1,
		ReadOnlyDataSectionSemantics = 2,
		ReadWriteDataSectionSemantics = 3,
		ExternalSectionSemantics = 4
	}
	public enum SegmentFlag
	{
		SegmentExecutable = 1,
		SegmentWritable = 2,
		SegmentReadable = 4,
		SegmentContainsData = 8,
		SegmentContainsCode = 16,
		SegmentDenyWrite = 32,
		SegmentDenyExecute = 64
	}
	public enum SettingsScope
	{
		SettingsInvalidScope = 0,
		SettingsAutoScope = 1,
		SettingsDefaultScope = 2,
		SettingsUserScope = 3,
		SettingsWorkspaceScope = 4,
		SettingsContextScope = 5
	}
	public enum StringType
	{
		AsciiString = 0,
		Utf16String = 1,
		Utf32String = 2,
		Utf8String = 3
	}
	public enum StructureType
	{
		ClassStructureType = 0,
		StructStructureType = 1,
		UnionStructureType = 2
	}
	public enum SymbolBinding
	{
		NoBinding = 0,
		LocalBinding = 1,
		GlobalBinding = 2,
		WeakBinding = 3
	}
	public enum SymbolType
	{
		FunctionSymbol = 0,
		ImportAddressSymbol = 1,
		ImportedFunctionSymbol = 2,
		DataSymbol = 3,
		ImportedDataSymbol = 4,
		ExternalSymbol = 5
	}
	public enum TransformType
	{
		BinaryCodecTransform = 0,
		TextCodecTransform = 1,
		UnicodeCodecTransform = 2,
		DecodeTransform = 3,
		BinaryEncodeTransform = 4,
		TextEncodeTransform = 5,
		EncryptTransform = 6,
		InvertingTransform = 7,
		HashTransform = 8
	}
	public enum TypeClass
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
	public enum UpdateResult
	{
		UpdateFailed = 0,
		UpdateSuccess = 1,
		AlreadyUpToDate = 2,
		UpdateAvailable = 3
	}
	public enum VariableSourceType
	{
		StackVariableSourceType = 0,
		RegisterVariableSourceType = 1,
		FlagVariableSourceType = 2
	}
}
