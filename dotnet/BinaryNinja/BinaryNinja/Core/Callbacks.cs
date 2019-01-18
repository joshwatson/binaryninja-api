using System.Runtime.InteropServices;

namespace BinaryNinja
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNObjectDestructionCallbacks
    {
        public void* context;
        // The provided pointers have a reference count of zero. Do not add additional references, doing so
        // can lead to a double free. These are provided only for freeing additional state related to the
        // objects passed.
        
        [MarshalAs(UnmanagedType.FunctionPtr)] public Core.DestructBinaryView destructBinaryView;
        [MarshalAs(UnmanagedType.FunctionPtr)] public Core.DestructFileMetadata destructFileMetadata;
        [MarshalAs(UnmanagedType.FunctionPtr)] public Core.DestructFunction destructFunction;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNLogListener
    {
        public void* context;
        [MarshalAs(UnmanagedType.FunctionPtr)] public Core.Log log;
        [MarshalAs(UnmanagedType.FunctionPtr)] public Core.Close close;
        [MarshalAs(UnmanagedType.FunctionPtr)] public Core.GetLogLevel getLogLevel;
	};

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNNavigationHandler
    {
        public void* context;
        [MarshalAs(UnmanagedType.FunctionPtr)] public Core.BNNavigationHandlerGetCurrentView getCurrentView;
        [MarshalAs(UnmanagedType.FunctionPtr)] public Core.BNNavigationHandlerGetCurrentOffset getCurrentOffset;
		[MarshalAs(UnmanagedType.FunctionPtr)] public Core.BNNavigationHandlerNavigate navigate;
	};

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNNameList
    {
        public char** name;
        public char* join;
        public ulong nameCount;
    };

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNNameSpace
    {
        public char** name;
        public char* join;
        public ulong nameCount;
    };

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNQualifiedName
    {
        public char** name;
        public char* join;
        public ulong nameCount;
    };

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNBinaryDataNotification
    {
        void* context;
        void (* dataWritten) (void* ctxt, Core.BNBinaryView* view, ulong offset, ulong len);
		void (* dataInserted) (void* ctxt, Core.BNBinaryView* view, ulong offset, ulong len);
		void (* dataRemoved) (void* ctxt, Core.BNBinaryView* view, ulong offset, ulong len);
		void (* functionAdded) (void* ctxt, Core.BNBinaryView* view, Core.BNFunction* func);
		void (* functionRemoved) (void* ctxt, Core.BNBinaryView* view, Core.BNFunction* func);
		void (* functionUpdated) (void* ctxt, Core.BNBinaryView* view, Core.BNFunction* func);
		void (* functionUpdateRequested) (void* ctxt, Core.BNBinaryView* view, Core.BNFunction* func);
		void (* dataVariableAdded) (void* ctxt, Core.BNBinaryView* view, BNDataVariable* var);
		void (* dataVariableRemoved) (void* ctxt, Core.BNBinaryView* view, BNDataVariable* var);
		void (* dataVariableUpdated) (void* ctxt, Core.BNBinaryView* view, BNDataVariable* var);
		void (* stringFound) (void* ctxt, Core.BNBinaryView* view, BNStringType type, ulong offset, ulong len);
		void (* stringRemoved) (void* ctxt, Core.BNBinaryView* view, BNStringType type, ulong offset, ulong len);
		void (* typeDefined) (void* ctxt, Core.BNBinaryView* view, BNQualifiedName* name, BNType* type);
		void (* typeUndefined) (void* ctxt, Core.BNBinaryView* view, BNQualifiedName* name, BNType* type);
	};

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNFileAccessor
    {
        void* context;
        ulong(*getLength)(void* ctxt);
		ulong(*read)(void* ctxt, void* dest, ulong offset, ulong len);
		ulong(*write)(void* ctxt, ulong offset, void* src, ulong len);
	};

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNCustomBinaryView
    {
        void* context;
        bool (* init) (void* ctxt);
		void (* freeObject) (void* ctxt);
		ulong(*read)(void* ctxt, void* dest, ulong offset, ulong len);
		ulong(*write)(void* ctxt, ulong offset, void* src, ulong len);
		ulong(*insert)(void* ctxt, ulong offset, void* src, ulong len);
		ulong(*remove)(void* ctxt, ulong offset, ulong len);
		BNModificationStatus(*getModification)(void* ctxt, ulong offset);
		bool (* isValidOffset) (void* ctxt, ulong offset);
		bool (* isOffsetReadable) (void* ctxt, ulong offset);
		bool (* isOffsetWritable) (void* ctxt, ulong offset);
		bool (* isOffsetExecutable) (void* ctxt, ulong offset);
		bool (* isOffsetBackedByFile) (void* ctxt, ulong offset);
		ulong(*getNextValidOffset)(void* ctxt, ulong offset);
		ulong(*getStart)(void* ctxt);
		ulong(*getLength)(void* ctxt);
		ulong(*getEntryPoint)(void* ctxt);
		bool (* isExecutable) (void* ctxt);
		BNEndianness(*getDefaultEndianness)(void* ctxt);
		bool (* isRelocatable) (void* ctxt);
		ulong(*getAddressSize)(void* ctxt);
		bool (* save) (void* ctxt, BNFileAccessor* accessor);
	};

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNCustomBinaryViewType
    {
        void* context;
        Core.BNBinaryView* (* create) (void* ctxt, Core.BNBinaryView* data);
		bool (* isValidForData) (void* ctxt, Core.BNBinaryView* data);
	};

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNTransformParameterInfo
    {
        public char* name;
        public char* longName;
        public ulong fixedLength; // Variable length if zero
    };

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNCustomTransform
    {
        void* context;
        BNTransformParameterInfo* (* getParameters) (void* ctxt, ulong* count);
		void (* freeParameters) (BNTransformParameterInfo* params, ulong count);
        bool (* decode) (void* ctxt, BNDataBuffer* input, BNDataBuffer* output, BNTransformParameter* params, ulong paramCount);
        bool (* encode) (void* ctxt, BNDataBuffer* input, BNDataBuffer* output, BNTransformParameter* params, ulong paramCount);
    };

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNInstructionInfo
    {
        ulong length;
        ulong branchCount;
        bool archTransitionByTargetAddr;
        bool branchDelay;
        BNBranchType branchType[BN_MAX_INSTRUCTION_BRANCHES];
        ulong branchTarget[BN_MAX_INSTRUCTION_BRANCHES];
        BNArchitecture* branchArch[BN_MAX_INSTRUCTION_BRANCHES]; // If null, same architecture as instruction
    };

#define MAX_RELOCATION_SIZE 8
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNRelocationInfo
    {
        BNRelocationType type; // BinaryNinja Relocation Type
        bool pcRelative;       // PC Relative or Absolute (subtract address from relocation)
        bool baseRelative;   // Relative to start of module (Add module base to relocation)
        ulong base;       // Base address for this binary view
		ulong size;         // Size of the data to be written
        ulong truncateSize; // After addition/subtraction truncate to
        ulong nativeType; // Base type from relocation entry
        ulong addend;       // Addend value from relocation entry
        bool hasSign;        // Addend should be subtracted
        bool implicitAddend; // Addend should be read from the BinaryView
        bool external;       // Relocation entry points to external symbol
        ulong symbolIndex;  // Index into symbol table
        ulong sectionIndex; // Index into the section table
        ulong address;    // Absolute address or segment offset
        ulong target;     // Target (set automatically)
        bool dataRelocation; // This relocation is effecting data not code
        byte relocationDataCache[MAX_RELOCATION_SIZE];
        [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNRelocationInfo* prev; // Link to relocation another related relocation
		struct BNRelocationInfo* next; // Link to relocation another related relocation
	};

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNInstructionTextToken
    {
        BNInstructionTextTokenType type;
        char* text;
        ulong value;
        ulong size, operand;
        BNInstructionTextTokenContext context;
        byte confidence;
        ulong address;
        char** typeNames;
        ulong namesCount;
    };

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNInstructionTextLine
    {
        BNInstructionTextToken* tokens;
        ulong count;
    };

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNFlagConditionForSemanticClass
    {
        uint semanticClass;
        BNLowLevelILFlagCondition condition;
    };

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNNameAndType
    {
        char* name;
        BNType* type;
        byte typeConfidence;
    };

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNTypeWithConfidence
    {
        BNType* type;
        byte confidence;
    };

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNCustomArchitecture
    {
        void* context;
        void (* init) (void* context, BNArchitecture* obj);
		BNEndianness(*getEndianness)(void* ctxt);
		ulong(*getAddressSize)(void* ctxt);
		ulong(*getDefaultIntegerSize)(void* ctxt);
		ulong(*getInstructionAlignment)(void* ctxt);
		ulong(*getMaxInstructionLength)(void* ctxt);
		ulong(*getOpcodeDisplayLength)(void* ctxt);
		BNArchitecture* (* getAssociatedArchitectureByAddress) (void* ctxt, ulong* addr);
		bool (* getInstructionInfo) (void* ctxt, byte* data, ulong addr, ulong maxLen, BNInstructionInfo* result);
		bool (* getInstructionText) (void* ctxt, byte* data, ulong addr, ulong* len,
                                     BNInstructionTextToken** result, ulong* count);
        void (* freeInstructionText) (BNInstructionTextToken* tokens, ulong count);
		bool (* getInstructionLowLevelIL) (void* ctxt, byte* data, ulong addr, ulong* len, BNLowLevelILFunction* il);
		char* (* getRegisterName) (void* ctxt, uint reg);
		char* (* getFlagName) (void* ctxt, uint flag);
		char* (* getFlagWriteTypeName) (void* ctxt, uint flags);
		char* (* getSemanticFlagClassName) (void* ctxt, uint semClass);
		char* (* getSemanticFlagGroupName) (void* ctxt, uint semGroup);
		uint* (* getFullWidthRegisters) (void* ctxt, ulong* count);
		uint* (* getAllRegisters) (void* ctxt, ulong* count);
		uint* (* getAllFlags) (void* ctxt, ulong* count);
		uint* (* getAllFlagWriteTypes) (void* ctxt, ulong* count);
		uint* (* getAllSemanticFlagClasses) (void* ctxt, ulong* count);
		uint* (* getAllSemanticFlagGroups) (void* ctxt, ulong* count);
		BNFlagRole(*getFlagRole)(void* ctxt, uint flag, uint semClass);
		uint* (* getFlagsRequiredForFlagCondition) (void* ctxt, BNLowLevelILFlagCondition cond,
              uint semClass, ulong* count);
		uint* (* getFlagsRequiredForSemanticFlagGroup) (void* ctxt, uint semGroup, ulong* count);
		BNFlagConditionForSemanticClass* (* getFlagConditionsForSemanticFlagGroup) (void* ctxt, uint semGroup, ulong* count);
		void (* freeFlagConditionsForSemanticFlagGroup) (void* ctxt, BNFlagConditionForSemanticClass* conditions);
		uint* (* getFlagsWrittenByFlagWriteType) (void* ctxt, uint writeType, ulong* count);
		uint(*getSemanticClassForFlagWriteType)(void* ctxt, uint writeType);
		ulong(*getFlagWriteLowLevelIL)(void* ctxt, BNLowLevelILOperation op, ulong size, uint flagWriteType,
           uint flag, BNRegisterOrConstant* operands, ulong operandCount, BNLowLevelILFunction* il);
		ulong(*getFlagConditionLowLevelIL)(void* ctxt, BNLowLevelILFlagCondition cond,
           uint semClass, BNLowLevelILFunction* il);
		ulong(*getSemanticFlagGroupLowLevelIL)(void* ctxt, uint semGroup, BNLowLevelILFunction* il);
		void (* freeRegisterList) (void* ctxt, uint* regs);
		void (* getRegisterInfo) (void* ctxt, uint reg, BNRegisterInfo* result);
		uint(*getStackPointerRegister)(void* ctxt);
		uint(*getLinkRegister)(void* ctxt);
		uint* (* getGlobalRegisters) (void* ctxt, ulong* count);

		char* (* getRegisterStackName) (void* ctxt, uint regStack);
		uint* (* getAllRegisterStacks) (void* ctxt, ulong* count);
		void (* getRegisterStackInfo) (void* ctxt, uint regStack, BNRegisterStackInfo* result);

		char* (* getIntrinsicName) (void* ctxt, uint intrinsic);
		uint* (* getAllIntrinsics) (void* ctxt, ulong* count);
		BNNameAndType* (* getIntrinsicInputs) (void* ctxt, uint intrinsic, ulong* count);
		void (* freeNameAndTypeList) (void* ctxt, BNNameAndType* nt, ulong count);
		BNTypeWithConfidence* (* getIntrinsicOutputs) (void* ctxt, uint intrinsic, ulong* count);
		void (* freeTypeList) (void* ctxt, BNTypeWithConfidence* types, ulong count);

		bool (* assemble) (void* ctxt, char* code, ulong addr, BNDataBuffer* result, char** errors);

        bool (* isNeverBranchPatchAvailable) (void* ctxt, byte* data, ulong addr, ulong len);
        bool (* isAlwaysBranchPatchAvailable) (void* ctxt, byte* data, ulong addr, ulong len);
        bool (* isInvertBranchPatchAvailable) (void* ctxt, byte* data, ulong addr, ulong len);
        bool (* isSkipAndReturnZeroPatchAvailable) (void* ctxt, byte* data, ulong addr, ulong len);
        bool (* isSkipAndReturnValuePatchAvailable) (void* ctxt, byte* data, ulong addr, ulong len);

        bool (* convertToNop) (void* ctxt, byte* data, ulong addr, ulong len);
		bool (* alwaysBranch) (void* ctxt, byte* data, ulong addr, ulong len);
		bool (* invertBranch) (void* ctxt, byte* data, ulong addr, ulong len);
		bool (* skipAndReturnValue) (void* ctxt, byte* data, ulong addr, ulong len, ulong value);
	};

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNBasicBlockEdge
    {
        BNBranchType type;
        BNBasicBlock* target;
        bool backEdge;
        bool fallThrough;
    };

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNPoint
    {
        float x;
        float y;
    };

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNFlowGraphEdge
    {
        BNBranchType type;
        BNFlowGraphNode* target;
        BNPoint* points;
        ulong pointCount;
        bool backEdge;
    };

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNHighlightColor
    {
        BNHighlightColorStyle style;
        BNHighlightStandardColor color;
        BNHighlightStandardColor mixColor;
        byte mix, r, g, b, alpha;
    };

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNDisassemblyTextLine
    {
        ulong addr;
        ulong instrIndex;
        BNInstructionTextToken* tokens;
        ulong count;
        BNHighlightColor highlight;
    };

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNLinearDisassemblyLine
    {
        BNLinearDisassemblyLineType type;
        Core.BNFunction* function;
        BNBasicBlock* block;
        ulong lineOffset;
        BNDisassemblyTextLine contents;
    };

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNLinearDisassemblyPosition
    {
        Core.BNFunction* function;
        BNBasicBlock* block;
        ulong address;
    };

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNReferenceSource
    {
        Core.BNFunction* func;
        BNArchitecture* arch;
        ulong addr;
    };

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNUndoAction
    {
        BNActionType type;
        void* context;
        void (* freeObject) (void* ctxt);
		void (* undo) (void* ctxt, Core.BNBinaryView* data);
		void (* redo) (void* ctxt, Core.BNBinaryView* data);
		char* (* serialize) (void* ctxt);
	};

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNCallingConventionWithConfidence
    {
        BNCallingConvention* convention;
        byte confidence;
    };

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNBoolWithConfidence
    {
        bool value;
        byte confidence;
    };

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNSizeWithConfidence
    {
        ulong value;
        byte confidence;
    };

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNOffsetWithConfidence
    {
        long value;
        byte confidence;
    };

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNMemberScopeWithConfidence
    {
        BNMemberScope value;
        byte confidence;
    };

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNMemberAccessWithConfidence
    {
        BNMemberAccess value;
        byte confidence;
    };

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNParameterVariablesWithConfidence
    {
        BNVariable* vars;
        ulong count;
        byte confidence;
    };

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNRegisterSetWithConfidence
    {
        uint* regs;
        ulong count;
        byte confidence;
    };

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct Core.BNFunctionParameter
    {
        char* name;
        BNType* type;
        byte typeConfidence;
        bool defaultLocation;
        BNVariable location;
    };

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNQualifiedNameAndType
    {
        BNQualifiedName name;
        BNType* type;
    };

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNStructureMember
    {
        BNType* type;
        char* name;
        ulong offset;
        byte typeConfidence;
    };

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNEnumerationMember
    {
        char* name;
        ulong value;
        bool isDefault;
    };

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct Core.BNFunctionRecognizer
    {
        void* context;
        bool (* recognizeLowLevelIL) (void* ctxt, Core.BNBinaryView* data, Core.BNFunction* func, BNLowLevelILFunction* il);
		bool (* recognizeMediumLevelIL) (void* ctxt, Core.BNBinaryView* data, Core.BNFunction* func, BNMediumLevelILFunction* il);
	};

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNCustomRelocationHandler
    {
        void* context;
        void (* freeObject) (void* ctxt);

		bool (* getRelocationInfo) (void* ctxt, Core.BNBinaryView* view, BNArchitecture* arch, BNRelocationInfo* result,
              ulong resultCount);
		bool (* applyRelocation) (void* ctxt, Core.BNBinaryView* view, BNArchitecture* arch, BNRelocation* reloc, byte* dest,
              ulong len);
		ulong(*getOperandForExternalRelocation)(void* ctxt, byte* data, ulong addr, ulong length,
           BNLowLevelILFunction* il, BNRelocation* relocation);
    };

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNTypeParserResult
    {
        BNQualifiedNameAndType* types;
        BNQualifiedNameAndType* variables;
        BNQualifiedNameAndType* functions;
        ulong typeCount, variableCount, functionCount;
    };

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNUpdateChannel
    {
        char* name;
        char* description;
        char* latestVersion;
    };

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNUpdateVersion
    {
        char* version;
        char* notes;
        ulong time;
    };

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNStringReference
    {
        BNStringType type;
        ulong start;
        ulong length;
    };

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNPluginCommand
    {
        char* name;
        char* description;
        BNPluginCommandType type;
        void* context;

        void (* defaultCommand) (void* ctxt, Core.BNBinaryView* view);
		void (* addressCommand) (void* ctxt, Core.BNBinaryView* view, ulong addr);
		void (* rangeCommand) (void* ctxt, Core.BNBinaryView* view, ulong addr, ulong len);
		void (* functionCommand) (void* ctxt, Core.BNBinaryView* view, Core.BNFunction* func);
		void (* lowLevelILFunctionCommand) (void* ctxt, Core.BNBinaryView* view, BNLowLevelILFunction* func);
		void (* lowLevelILInstructionCommand) (void* ctxt, Core.BNBinaryView* view, BNLowLevelILFunction* func, ulong instr);
		void (* mediumLevelILFunctionCommand) (void* ctxt, Core.BNBinaryView* view, BNMediumLevelILFunction* func);
		void (* mediumLevelILInstructionCommand) (void* ctxt, Core.BNBinaryView* view, BNMediumLevelILFunction* func, ulong instr);

		bool (* defaultIsValid) (void* ctxt, Core.BNBinaryView* view);
		bool (* addressIsValid) (void* ctxt, Core.BNBinaryView* view, ulong addr);
		bool (* rangeIsValid) (void* ctxt, Core.BNBinaryView* view, ulong addr, ulong len);
		bool (* functionIsValid) (void* ctxt, Core.BNBinaryView* view, Core.BNFunction* func);
		bool (* lowLevelILFunctionIsValid) (void* ctxt, Core.BNBinaryView* view, BNLowLevelILFunction* func);
		bool (* lowLevelILInstructionIsValid) (void* ctxt, Core.BNBinaryView* view, BNLowLevelILFunction* func, ulong instr);
		bool (* mediumLevelILFunctionIsValid) (void* ctxt, Core.BNBinaryView* view, BNMediumLevelILFunction* func);
		bool (* mediumLevelILInstructionIsValid) (void* ctxt, Core.BNBinaryView* view, BNMediumLevelILFunction* func, ulong instr);
	};

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNCustomCallingConvention
    {
        void* context;

        void (* freeObject) (void* ctxt);

		uint* (* getCallerSavedRegisters) (void* ctxt, ulong* count);
		uint* (* getCalleeSavedRegisters) (void* ctxt, ulong* count);
		uint* (* getIntegerArgumentRegisters) (void* ctxt, ulong* count);
		uint* (* getFloatArgumentRegisters) (void* ctxt, ulong* count);
		void (* freeRegisterList) (void* ctxt, uint* regs);

		bool (* areArgumentRegistersSharedIndex) (void* ctxt);
		bool (* isStackReservedForArgumentRegisters) (void* ctxt);
		bool (* isStackAdjustedOnReturn) (void* ctxt);

		uint(*getIntegerReturnValueRegister)(void* ctxt);
		uint(*getHighIntegerReturnValueRegister)(void* ctxt);
		uint(*getFloatReturnValueRegister)(void* ctxt);
		uint(*getGlobalPointerRegister)(void* ctxt);

		uint* (* getImplicitlyDefinedRegisters) (void* ctxt, ulong* count);
		void (* getIncomingRegisterValue) (void* ctxt, uint reg, Core.BNFunction* func, BNRegisterValue* result);
		void (* getIncomingFlagValue) (void* ctxt, uint flag, Core.BNFunction* func, BNRegisterValue* result);

		void (* getIncomingVariableForParameterVariable) (void* ctxt, BNVariable* var,
              Core.BNFunction* func, BNVariable* result);
        void (* getParameterVariableForIncomingVariable) (void* ctxt, BNVariable* var,
              Core.BNFunction* func, BNVariable* result);
    };

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNVariableNameAndType
    {
        BNVariable var;
        BNType* type;
        char* name;
        bool autoDefined;
        byte typeConfidence;
    };

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNStackVariableReference
    {
        uint sourceOperand;
        byte typeConfidence;
        BNType* type;
        char* name;
        ulong varIdentifier;
        long referencedOffset;
        ulong size;
    };

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNIndirectBranchInfo
    {
        BNArchitecture* sourceArch;
        ulong sourceAddr;
        BNArchitecture* destArch;
        ulong destAddr;
        bool autoDefined;
    };

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNArchitectureAndAddress
    {
        BNArchitecture* arch;
        ulong address;
    };

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNActiveAnalysisInfo
    {
        Core.BNFunction* func;
        ulong analysisTime;
        ulong updateCount;
        ulong submitCount;
    };

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNAnalysisInfo
    {
        BNAnalysisState state;
        ulong analysisTime;
        BNActiveAnalysisInfo* activeInfo;
        ulong count;
    };

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNAnalysisProgress
    {
        BNAnalysisState state;
        ulong count, total;
    };

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNAnalysisParameters
    {
        ulong maxAnalysisTime;
        ulong maxFunctionSize;
        ulong maxFunctionAnalysisTime;
        ulong maxFunctionUpdateCount;
        ulong maxFunctionSubmitCount;
        bool suppressNewAutoFunctionAnalysis;
    };

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNDownloadInstanceOutputCallbacks
    {
        ulong(*writeCallback)(byte* data, ulong len, void* ctxt);
		void* writeContext;
        bool (* progressCallback) (void* ctxt, ulong progress, ulong total);
		void* progressContext;
    };

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNDownloadInstanceCallbacks
    {
        void* context;
        void (* destroyInstance) (void* ctxt);
		int (* performRequest) (void* ctxt, char* url);
    };

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNDownloadProviderCallbacks
    {
        void* context;
        BNDownloadInstance* (* createInstance) (void* ctxt);
	};

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNScriptingInstanceCallbacks
    {
        void* context;
        void (* destroyInstance) (void* ctxt);
		BNScriptingProviderExecuteResult(*executeScriptInput)(void* ctxt, char* input);
        void (* setCurrentBinaryView) (void* ctxt, Core.BNBinaryView* view);
		void (* setCurrentFunction) (void* ctxt, Core.BNFunction* func);
		void (* setCurrentBasicBlock) (void* ctxt, BNBasicBlock* block);
		void (* setCurrentAddress) (void* ctxt, ulong addr);
		void (* setCurrentSelection) (void* ctxt, ulong begin, ulong end);
	};

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNScriptingProviderCallbacks
    {
        void* context;
        BNScriptingInstance* (* createInstance) (void* ctxt);

	};

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNScriptingOutputListener
    {
        void* context;
        void (* output) (void* ctxt, char* text);
        void (* error) (void* ctxt, char* text);
        void (* inputReadyStateChanged) (void* ctxt, BNScriptingProviderInputReadyState state);
	};

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNMainThreadCallbacks
    {
        void* context;
        void (* addAction) (void* ctxt, BNMainThreadAction* action);
	};

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNConstantReference
    {
        long value;
        ulong size;
        bool pointer, intermediate;
    };

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNMetadataValueStore
    {
        ulong size;
        char** keys;
        BNMetadata** values;
    };

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNFormInputField
    {
        BNFormInputFieldType type;
        char* prompt;
        Core.BNBinaryView* view; // For AddressFormField
        ulong currentAddress; // For AddressFormField
        char** choices; // For ChoiceFormField
        ulong count; // For ChoiceFormField
        char* ext; // For OpenFileNameFormField, SaveFileNameFormField
        char* defaultName; // For SaveFileNameFormField
        long intResult;
        ulong addressResult;
        char* stringResult;
        ulong indexResult;
    };

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNInteractionHandlerCallbacks
    {
        void* context;
        void (* showPlainTextReport) (void* ctxt, Core.BNBinaryView* view, char* title, char* contents);
        void (* showMarkdownReport) (void* ctxt, Core.BNBinaryView* view, char* title, char* contents,

            char* plaintext);
        void (* showHTMLReport) (void* ctxt, Core.BNBinaryView* view, char* title, char* contents,

            char* plaintext);
        void (* showGraphReport) (void* ctxt, Core.BNBinaryView* view, char* title, BNFlowGraph* graph);
		void (* showReportCollection) (void* ctxt, char* title, BNReportCollection* reports);
		bool (* getTextLineInput) (void* ctxt, char** result, char* prompt, char* title);
        bool (* getIntegerInput) (void* ctxt, long* result, char* prompt, char* title);
        bool (* getAddressInput) (void* ctxt, ulong* result, char* prompt, char* title,
              Core.BNBinaryView* view, ulong currentAddr);
        bool (* getChoiceInput) (void* ctxt, ulong* result, char* prompt, char* title,

            char** choices, ulong count);
		bool (* getOpenFileNameInput) (void* ctxt, char** result, char* prompt, char* ext);
        bool (* getSaveFileNameInput) (void* ctxt, char** result, char* prompt, char* ext,

            char* defaultName);
        bool (* getDirectoryNameInput) (void* ctxt, char** result, char* prompt, char* defaultName);
        bool (* getFormInput) (void* ctxt, BNFormInputField* fields, ulong count, char* title);
        BNMessageBoxButtonResult(*showMessageBox)(void* ctxt, char* title, char* text,
           BNMessageBoxButtonSet buttons, BNMessageBoxIcon icon);
    };

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNObjectDestructionCallbacks
    {
        void* context;
        // The provided pointers have a reference count of zero. Do not add additional references, doing so
        // can lead to a double free. These are provided only for freeing additional state related to the
        // objects passed.
        void (* destructBinaryView) (void* ctxt, Core.BNBinaryView* view);
		void (* destructFileMetadata) (void* ctxt, BNFileMetadata* file);
		void (* destructFunction) (void* ctxt, Core.BNFunction* func);
	};

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNCustomDataRenderer
    {
        void* context;
        void (* freeObject) (void* ctxt);
		bool (* isValidForData) (void* ctxt, Core.BNBinaryView* view, ulong addr, BNType* type, BNType** typeCtx,
              ulong ctxCount);
		BNDisassemblyTextLine* (* getLinesForData) (void* ctxt, Core.BNBinaryView* view, ulong addr, BNType* type,

            BNInstructionTextToken* prefix, ulong prefixCount, ulong width, ulong* count, BNType** typeCtx,
            ulong ctxCount);
	};

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNAddressRange
    {
        ulong start;
        ulong end;
    };

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNSystemCallInfo
    {
        uint number;
        BNQualifiedName name;
        BNType* type;
    };

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNILBranchInstructionAndDependence
    {
        ulong branch;
        BNILBranchDependence dependence;
    };

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNPerformanceInfo
    {
        char* name;
        double seconds;
    };

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNRegisterStackAdjustment
    {
        uint regStack;
        int adjustment;
        byte confidence;
    };

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNCustomFlowGraph
    {
        void* context;
        void (* prepareForLayout) (void* ctxt);
		void (* populateNodes) (void* ctxt);
		void (* completeLayout) (void* ctxt);
		BNFlowGraph* (* update) (void* ctxt);
	};

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct BNRange
    {
        ulong start;
        ulong end;
    };
}