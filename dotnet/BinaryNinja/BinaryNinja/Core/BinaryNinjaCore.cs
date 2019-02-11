using System.Runtime.InteropServices;

namespace BinaryNinja
{
	public class Core
	{

		// Type definitions
		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct BNActiveAnalysisInfo
		{
			public BNFunction* func;
			public ulong analysisTime;
			public ulong updateCount;
			public ulong submitCount;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BNAddressRange
		{
			public ulong start;
			public ulong end;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BNAnalysisCompletionEvent { };

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct BNAnalysisInfo
		{
			public AnalysisState state;
			public ulong analysisTime;
			public BNActiveAnalysisInfo* activeInfo;
			public ulong count;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BNAnalysisParameters
		{
			public ulong maxAnalysisTime;
			public ulong maxFunctionSize;
			public ulong maxFunctionAnalysisTime;
			public ulong maxFunctionUpdateCount;
			public ulong maxFunctionSubmitCount;
			public bool suppressNewAutoFunctionAnalysis;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BNAnalysisProgress
		{
			public AnalysisState state;
			public ulong count;
			public ulong total;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BNArchitecture { };

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct BNArchitectureAndAddress
		{
			public BNArchitecture* arch;
			public ulong address;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BNBackgroundTask { };

		[StructLayout(LayoutKind.Sequential)]
		public struct BNBasicBlock { };

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct BNBasicBlockEdge
		{
			public BranchType type;
			public BNBasicBlock* target;
			public bool backEdge;
			public bool fallThrough;
		}

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct BNBinaryDataNotification
		{
			public void* context;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNBinaryDataNotification_dataWrittenDelegate dataWritten;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNBinaryDataNotification_dataInsertedDelegate dataInserted;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNBinaryDataNotification_dataRemovedDelegate dataRemoved;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNBinaryDataNotification_functionAddedDelegate functionAdded;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNBinaryDataNotification_functionRemovedDelegate functionRemoved;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNBinaryDataNotification_functionUpdatedDelegate functionUpdated;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNBinaryDataNotification_functionUpdateRequestedDelegate functionUpdateRequested;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNBinaryDataNotification_dataVariableAddedDelegate dataVariableAdded;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNBinaryDataNotification_dataVariableRemovedDelegate dataVariableRemoved;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNBinaryDataNotification_dataVariableUpdatedDelegate dataVariableUpdated;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNBinaryDataNotification_stringFoundDelegate stringFound;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNBinaryDataNotification_stringRemovedDelegate stringRemoved;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNBinaryDataNotification_typeDefinedDelegate typeDefined;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNBinaryDataNotification_typeUndefinedDelegate typeUndefined;
		}

		public struct _BNBinaryDataNotification { };

		[StructLayout(LayoutKind.Sequential)]
		public struct BNBinaryReader { };

		[StructLayout(LayoutKind.Sequential)]
		public struct BNBinaryView { };

		[StructLayout(LayoutKind.Sequential)]
		public struct BNBinaryViewType { };

		[StructLayout(LayoutKind.Sequential)]
		public struct BNBinaryWriter { };

		[StructLayout(LayoutKind.Sequential)]
		public struct BNBoolWithConfidence
		{
			public bool value;
			public byte confidence;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BNCallingConvention { };

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct BNCallingConventionWithConfidence
		{
			public BNCallingConvention* convention;
			public byte confidence;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BNConstantReference
		{
			public long value;
			public ulong size;
			public bool pointer;
			public bool intermediate;
		}

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct BNCustomArchitecture
		{
			public void* context;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomArchitecture_initDelegate init;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomArchitecture_getEndiannessDelegate getEndianness;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomArchitecture_getAddressSizeDelegate getAddressSize;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomArchitecture_getDefaultIntegerSizeDelegate getDefaultIntegerSize;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomArchitecture_getInstructionAlignmentDelegate getInstructionAlignment;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomArchitecture_getMaxInstructionLengthDelegate getMaxInstructionLength;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomArchitecture_getOpcodeDisplayLengthDelegate getOpcodeDisplayLength;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomArchitecture_getAssociatedArchitectureByAddressDelegate getAssociatedArchitectureByAddress;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomArchitecture_getInstructionInfoDelegate getInstructionInfo;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomArchitecture_getInstructionTextDelegate getInstructionText;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomArchitecture_freeInstructionTextDelegate freeInstructionText;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomArchitecture_getInstructionLowLevelILDelegate getInstructionLowLevelIL;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomArchitecture_getRegisterNameDelegate getRegisterName;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomArchitecture_getFlagNameDelegate getFlagName;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomArchitecture_getFlagWriteTypeNameDelegate getFlagWriteTypeName;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomArchitecture_getSemanticFlagClassNameDelegate getSemanticFlagClassName;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomArchitecture_getSemanticFlagGroupNameDelegate getSemanticFlagGroupName;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomArchitecture_getFullWidthRegistersDelegate getFullWidthRegisters;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomArchitecture_getAllRegistersDelegate getAllRegisters;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomArchitecture_getAllFlagsDelegate getAllFlags;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomArchitecture_getAllFlagWriteTypesDelegate getAllFlagWriteTypes;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomArchitecture_getAllSemanticFlagClassesDelegate getAllSemanticFlagClasses;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomArchitecture_getAllSemanticFlagGroupsDelegate getAllSemanticFlagGroups;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomArchitecture_getFlagRoleDelegate getFlagRole;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomArchitecture_getFlagsRequiredForFlagConditionDelegate getFlagsRequiredForFlagCondition;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomArchitecture_getFlagsRequiredForSemanticFlagGroupDelegate getFlagsRequiredForSemanticFlagGroup;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomArchitecture_getFlagConditionsForSemanticFlagGroupDelegate getFlagConditionsForSemanticFlagGroup;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomArchitecture_freeFlagConditionsForSemanticFlagGroupDelegate freeFlagConditionsForSemanticFlagGroup;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomArchitecture_getFlagsWrittenByFlagWriteTypeDelegate getFlagsWrittenByFlagWriteType;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomArchitecture_getSemanticClassForFlagWriteTypeDelegate getSemanticClassForFlagWriteType;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomArchitecture_getFlagWriteLowLevelILDelegate getFlagWriteLowLevelIL;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomArchitecture_getFlagConditionLowLevelILDelegate getFlagConditionLowLevelIL;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomArchitecture_getSemanticFlagGroupLowLevelILDelegate getSemanticFlagGroupLowLevelIL;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomArchitecture_freeRegisterListDelegate freeRegisterList;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomArchitecture_getRegisterInfoDelegate getRegisterInfo;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomArchitecture_getStackPointerRegisterDelegate getStackPointerRegister;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomArchitecture_getLinkRegisterDelegate getLinkRegister;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomArchitecture_getGlobalRegistersDelegate getGlobalRegisters;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomArchitecture_getRegisterStackNameDelegate getRegisterStackName;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomArchitecture_getAllRegisterStacksDelegate getAllRegisterStacks;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomArchitecture_getRegisterStackInfoDelegate getRegisterStackInfo;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomArchitecture_getIntrinsicNameDelegate getIntrinsicName;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomArchitecture_getAllIntrinsicsDelegate getAllIntrinsics;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomArchitecture_getIntrinsicInputsDelegate getIntrinsicInputs;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomArchitecture_freeNameAndTypeListDelegate freeNameAndTypeList;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomArchitecture_getIntrinsicOutputsDelegate getIntrinsicOutputs;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomArchitecture_freeTypeListDelegate freeTypeList;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomArchitecture_assembleDelegate assemble;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomArchitecture_isNeverBranchPatchAvailableDelegate isNeverBranchPatchAvailable;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomArchitecture_isAlwaysBranchPatchAvailableDelegate isAlwaysBranchPatchAvailable;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomArchitecture_isInvertBranchPatchAvailableDelegate isInvertBranchPatchAvailable;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomArchitecture_isSkipAndReturnZeroPatchAvailableDelegate isSkipAndReturnZeroPatchAvailable;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomArchitecture_isSkipAndReturnValuePatchAvailableDelegate isSkipAndReturnValuePatchAvailable;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomArchitecture_convertToNopDelegate convertToNop;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomArchitecture_alwaysBranchDelegate alwaysBranch;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomArchitecture_invertBranchDelegate invertBranch;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomArchitecture_skipAndReturnValueDelegate skipAndReturnValue;
		}

		public struct _BNCustomArchitecture { };

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct BNCustomBinaryView
		{
			public void* context;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomBinaryView_initDelegate init;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomBinaryView_freeObjectDelegate freeObject;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomBinaryView_readDelegate read;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomBinaryView_writeDelegate write;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomBinaryView_insertDelegate insert;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomBinaryView_removeDelegate remove;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomBinaryView_getModificationDelegate getModification;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomBinaryView_isValidOffsetDelegate isValidOffset;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomBinaryView_isOffsetReadableDelegate isOffsetReadable;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomBinaryView_isOffsetWritableDelegate isOffsetWritable;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomBinaryView_isOffsetExecutableDelegate isOffsetExecutable;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomBinaryView_isOffsetBackedByFileDelegate isOffsetBackedByFile;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomBinaryView_getNextValidOffsetDelegate getNextValidOffset;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomBinaryView_getStartDelegate getStart;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomBinaryView_getLengthDelegate getLength;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomBinaryView_getEntryPointDelegate getEntryPoint;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomBinaryView_isExecutableDelegate isExecutable;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomBinaryView_getDefaultEndiannessDelegate getDefaultEndianness;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomBinaryView_isRelocatableDelegate isRelocatable;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomBinaryView_getAddressSizeDelegate getAddressSize;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomBinaryView_saveDelegate save;
		}

		public struct _BNCustomBinaryView { };

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct BNCustomBinaryViewType
		{
			public void* context;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomBinaryViewType_createDelegate create;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomBinaryViewType_isValidForDataDelegate isValidForData;
		}

		public struct _BNCustomBinaryViewType { };

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct BNCustomCallingConvention
		{
			public void* context;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomCallingConvention_freeObjectDelegate freeObject;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomCallingConvention_getCallerSavedRegistersDelegate getCallerSavedRegisters;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomCallingConvention_getCalleeSavedRegistersDelegate getCalleeSavedRegisters;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomCallingConvention_getIntegerArgumentRegistersDelegate getIntegerArgumentRegisters;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomCallingConvention_getFloatArgumentRegistersDelegate getFloatArgumentRegisters;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomCallingConvention_freeRegisterListDelegate freeRegisterList;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomCallingConvention_areArgumentRegistersSharedIndexDelegate areArgumentRegistersSharedIndex;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomCallingConvention_isStackReservedForArgumentRegistersDelegate isStackReservedForArgumentRegisters;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomCallingConvention_isStackAdjustedOnReturnDelegate isStackAdjustedOnReturn;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomCallingConvention_getIntegerReturnValueRegisterDelegate getIntegerReturnValueRegister;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomCallingConvention_getHighIntegerReturnValueRegisterDelegate getHighIntegerReturnValueRegister;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomCallingConvention_getFloatReturnValueRegisterDelegate getFloatReturnValueRegister;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomCallingConvention_getGlobalPointerRegisterDelegate getGlobalPointerRegister;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomCallingConvention_getImplicitlyDefinedRegistersDelegate getImplicitlyDefinedRegisters;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomCallingConvention_getIncomingRegisterValueDelegate getIncomingRegisterValue;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomCallingConvention_getIncomingFlagValueDelegate getIncomingFlagValue;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomCallingConvention_getIncomingVariableForParameterVariableDelegate getIncomingVariableForParameterVariable;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomCallingConvention_getParameterVariableForIncomingVariableDelegate getParameterVariableForIncomingVariable;
		}

		public struct _BNCustomCallingConvention { };

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct BNCustomDataRenderer
		{
			public void* context;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomDataRenderer_freeObjectDelegate freeObject;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomDataRenderer_isValidForDataDelegate isValidForData;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomDataRenderer_getLinesForDataDelegate getLinesForData;
		}

		public struct _BNCustomDataRenderer { };

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct BNCustomFlowGraph
		{
			public void* context;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomFlowGraph_prepareForLayoutDelegate prepareForLayout;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomFlowGraph_populateNodesDelegate populateNodes;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomFlowGraph_completeLayoutDelegate completeLayout;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomFlowGraph_updateDelegate update;
		}

		public struct _BNCustomFlowGraph { };

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct BNCustomRelocationHandler
		{
			public void* context;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomRelocationHandler_freeObjectDelegate freeObject;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomRelocationHandler_getRelocationInfoDelegate getRelocationInfo;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomRelocationHandler_applyRelocationDelegate applyRelocation;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomRelocationHandler_getOperandForExternalRelocationDelegate getOperandForExternalRelocation;
		}

		public struct _BNCustomRelocationHandler { };

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct BNCustomTransform
		{
			public void* context;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomTransform_getParametersDelegate getParameters;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomTransform_freeParametersDelegate freeParameters;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomTransform_decodeDelegate decode;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNCustomTransform_encodeDelegate encode;
		}

		public struct _BNCustomTransform { };

		[StructLayout(LayoutKind.Sequential)]
		public struct BNDataBuffer { };

		[StructLayout(LayoutKind.Sequential)]
		public struct BNDataRenderer { };

		[StructLayout(LayoutKind.Sequential)]
		public struct BNDataRendererContainer { };

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct BNDataVariable
		{
			public ulong address;
			public BNType* type;
			public bool autoDiscovered;
			public byte typeConfidence;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BNDisassemblySettings { };

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct BNDisassemblyTextLine
		{
			public ulong addr;
			public ulong instrIndex;
			public BNInstructionTextToken* tokens;
			public ulong count;
			public BNHighlightColor highlight;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BNDownloadInstance { };

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct BNDownloadInstanceCallbacks
		{
			public void* context;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNDownloadInstanceCallbacks_destroyInstanceDelegate destroyInstance;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNDownloadInstanceCallbacks_performRequestDelegate performRequest;
		}

		public struct _BNDownloadInstanceCallbacks { };

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct BNDownloadInstanceOutputCallbacks
		{
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNDownloadInstanceOutputCallbacks_writeCallbackDelegate writeCallback;
			public void* writeContext;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNDownloadInstanceOutputCallbacks_progressCallbackDelegate progressCallback;
			public void* progressContext;
		}

		public struct _BNDownloadInstanceOutputCallbacks { };

		[StructLayout(LayoutKind.Sequential)]
		public struct BNDownloadProvider { };

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct BNDownloadProviderCallbacks
		{
			public void* context;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNDownloadProviderCallbacks_createInstanceDelegate createInstance;
		}

		public struct _BNDownloadProviderCallbacks { };

		[StructLayout(LayoutKind.Sequential)]
		public struct BNEnumeration { };

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct BNEnumerationMember
		{
			[MarshalAs(UnmanagedType.LPStr)] public string name;
			public ulong value;
			public bool isDefault;
		}

		public struct _BNEnumerationMember { };

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct BNFileAccessor
		{
			public void* context;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNFileAccessor_getLengthDelegate getLength;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNFileAccessor_readDelegate read;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNFileAccessor_writeDelegate write;
		}

		public struct _BNFileAccessor { };

		[StructLayout(LayoutKind.Sequential)]
		public struct BNFileMetadata { };

		[StructLayout(LayoutKind.Sequential)]
		public struct BNFlagConditionForSemanticClass
		{
			public uint semanticClass;
			public LowLevelILFlagCondition condition;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BNFlowGraph { };

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct BNFlowGraphEdge
		{
			public BranchType type;
			public BNFlowGraphNode* target;
			public BNPoint* points;
			public ulong pointCount;
			public bool backEdge;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BNFlowGraphLayoutRequest { };

		[StructLayout(LayoutKind.Sequential)]
		public struct BNFlowGraphNode { };

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct BNFormInputField
		{
			public FormInputFieldType type;
			[MarshalAs(UnmanagedType.LPStr)] public string prompt;
			public BNBinaryView* view;
			public ulong currentAddress;
			public char** choices;
			public ulong count;
			[MarshalAs(UnmanagedType.LPStr)] public string ext;
			[MarshalAs(UnmanagedType.LPStr)] public string defaultName;
			public long intResult;
			public ulong addressResult;
			[MarshalAs(UnmanagedType.LPStr)] public string stringResult;
			public ulong indexResult;
		}

		public struct _BNFormInputField { };

		[StructLayout(LayoutKind.Sequential)]
		public struct BNFunction { };

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct BNFunctionParameter
		{
			[MarshalAs(UnmanagedType.LPStr)] public string name;
			public BNType* type;
			public byte typeConfidence;
			public bool defaultLocation;
			public BNVariable location;
		}

		public struct _BNFunctionParameter { };

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct BNFunctionRecognizer
		{
			public void* context;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNFunctionRecognizer_recognizeLowLevelILDelegate recognizeLowLevelIL;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNFunctionRecognizer_recognizeMediumLevelILDelegate recognizeMediumLevelIL;
		}

		public struct _BNFunctionRecognizer { };

		[StructLayout(LayoutKind.Sequential)]
		public struct BNHighlightColor
		{
			public HighlightColorStyle style;
			public HighlightStandardColor color;
			public HighlightStandardColor mixColor;
			public byte mix;
			public byte r;
			public byte g;
			public byte b;
			public byte alpha;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BNILBranchInstructionAndDependence
		{
			public ulong branch;
			public ILBranchDependence dependence;
		}

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct BNIndirectBranchInfo
		{
			public BNArchitecture* sourceArch;
			public ulong sourceAddr;
			public BNArchitecture* destArch;
			public ulong destAddr;
			public bool autoDefined;
		}

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct BNInstructionInfo
		{
			public ulong length;
			public ulong branchCount;
			public bool archTransitionByTargetAddr;
			public bool branchDelay;
			[MarshalAs(UnmanagedType.LPArray, SizeConst = 3)] public BranchType[] branchType;
			public fixed ulong branchTarget[3];
			[MarshalAs(UnmanagedType.LPArray, SizeConst = 3)] public BNArchitecture*[] branchArch;
		}

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct BNInstructionTextLine
		{
			public BNInstructionTextToken* tokens;
			public ulong count;
		}

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct BNInstructionTextToken
		{
			public InstructionTextTokenType type;
			[MarshalAs(UnmanagedType.LPStr)] public string text;
			public ulong value;
			public ulong size;
			public ulong operand;
			public InstructionTextTokenContext context;
			public byte confidence;
			public ulong address;
			public char** typeNames;
			public ulong namesCount;
		}

		public struct _BNInstructionTextToken { };

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct BNInteractionHandlerCallbacks
		{
			public void* context;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNInteractionHandlerCallbacks_showPlainTextReportDelegate showPlainTextReport;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNInteractionHandlerCallbacks_showMarkdownReportDelegate showMarkdownReport;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNInteractionHandlerCallbacks_showHTMLReportDelegate showHTMLReport;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNInteractionHandlerCallbacks_showGraphReportDelegate showGraphReport;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNInteractionHandlerCallbacks_showReportCollectionDelegate showReportCollection;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNInteractionHandlerCallbacks_getTextLineInputDelegate getTextLineInput;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNInteractionHandlerCallbacks_getIntegerInputDelegate getIntegerInput;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNInteractionHandlerCallbacks_getAddressInputDelegate getAddressInput;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNInteractionHandlerCallbacks_getChoiceInputDelegate getChoiceInput;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNInteractionHandlerCallbacks_getOpenFileNameInputDelegate getOpenFileNameInput;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNInteractionHandlerCallbacks_getSaveFileNameInputDelegate getSaveFileNameInput;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNInteractionHandlerCallbacks_getDirectoryNameInputDelegate getDirectoryNameInput;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNInteractionHandlerCallbacks_getFormInputDelegate getFormInput;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNInteractionHandlerCallbacks_showMessageBoxDelegate showMessageBox;
		}

		public struct _BNInteractionHandlerCallbacks { };

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct BNLinearDisassemblyLine
		{
			public LinearDisassemblyLineType type;
			public BNFunction* function;
			public BNBasicBlock* block;
			public ulong lineOffset;
			public BNDisassemblyTextLine contents;
		}

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct BNLinearDisassemblyPosition
		{
			public BNFunction* function;
			public BNBasicBlock* block;
			public ulong address;
		}

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct BNLogListener
		{
			public void* context;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNLogListener_logDelegate log;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNLogListener_closeDelegate close;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNLogListener_getLogLevelDelegate getLogLevel;
		}

		public struct _BNLogListener { };

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct BNLookupTableEntry
		{
			public long* fromValues;
			public ulong fromCount;
			public long toValue;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BNLowLevelILFunction { };

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct BNLowLevelILInstruction
		{
			public LowLevelILOperation operation;
			public ulong size;
			public uint flags;
			public uint sourceOperand;
			public fixed ulong operands[4];
			public ulong address;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BNLowLevelILLabel
		{
			public bool resolved;
			public ulong _ref;
			public ulong operand;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BNMainThreadAction { };

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct BNMainThreadCallbacks
		{
			public void* context;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNMainThreadCallbacks_addActionDelegate addAction;
		}

		public struct _BNMainThreadCallbacks { };

		[StructLayout(LayoutKind.Sequential)]
		public struct BNMediumLevelILFunction { };

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct BNMediumLevelILInstruction
		{
			public MediumLevelILOperation operation;
			public uint sourceOperand;
			public ulong size;
			public fixed ulong operands[5];
			public ulong address;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BNMediumLevelILLabel
		{
			public bool resolved;
			public ulong _ref;
			public ulong operand;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BNMemberAccessWithConfidence
		{
			public MemberAccess value;
			public byte confidence;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BNMemberScopeWithConfidence
		{
			public MemberScope value;
			public byte confidence;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BNMetadata { };

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct BNMetadataValueStore
		{
			public ulong size;
			public char** keys;
			public BNMetadata** values;
		}

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct BNNameAndType
		{
			[MarshalAs(UnmanagedType.LPStr)] public string name;
			public BNType* type;
			public byte typeConfidence;
		}

		public struct _BNNameAndType { };

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct BNNameList
		{
			public char** name;
			[MarshalAs(UnmanagedType.LPStr)] public string join;
			public ulong nameCount;
		}

		public struct _BNNameList { };

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct BNNameSpace
		{
			public char** name;
			[MarshalAs(UnmanagedType.LPStr)] public string join;
			public ulong nameCount;
		}

		public struct _BNNameSpace { };

		[StructLayout(LayoutKind.Sequential)]
		public struct BNNamedTypeReference { };

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct BNNavigationHandler
		{
			public void* context;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNNavigationHandler_getCurrentViewDelegate getCurrentView;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNNavigationHandler_getCurrentOffsetDelegate getCurrentOffset;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNNavigationHandler_navigateDelegate navigate;
		}

		public struct _BNNavigationHandler { };

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct BNObjectDestructionCallbacks
		{
			public void* context;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNObjectDestructionCallbacks_destructBinaryViewDelegate destructBinaryView;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNObjectDestructionCallbacks_destructFileMetadataDelegate destructFileMetadata;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNObjectDestructionCallbacks_destructFunctionDelegate destructFunction;
		}

		public struct _BNObjectDestructionCallbacks { };

		[StructLayout(LayoutKind.Sequential)]
		public struct BNOffsetWithConfidence
		{
			public long value;
			public byte confidence;
		}

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct BNParameterVariablesWithConfidence
		{
			public BNVariable* vars;
			public ulong count;
			public byte confidence;
		}

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct BNPerformanceInfo
		{
			[MarshalAs(UnmanagedType.LPStr)] public string name;
			public double seconds;
		}

		public struct _BNPerformanceInfo { };

		[StructLayout(LayoutKind.Sequential)]
		public struct BNPlatform { };

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct BNPluginCommand
		{
			[MarshalAs(UnmanagedType.LPStr)] public string name;
			[MarshalAs(UnmanagedType.LPStr)] public string description;
			public PluginCommandType type;
			public void* context;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNPluginCommand_defaultCommandDelegate defaultCommand;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNPluginCommand_addressCommandDelegate addressCommand;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNPluginCommand_rangeCommandDelegate rangeCommand;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNPluginCommand_functionCommandDelegate functionCommand;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNPluginCommand_lowLevelILFunctionCommandDelegate lowLevelILFunctionCommand;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNPluginCommand_lowLevelILInstructionCommandDelegate lowLevelILInstructionCommand;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNPluginCommand_mediumLevelILFunctionCommandDelegate mediumLevelILFunctionCommand;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNPluginCommand_mediumLevelILInstructionCommandDelegate mediumLevelILInstructionCommand;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNPluginCommand_defaultIsValidDelegate defaultIsValid;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNPluginCommand_addressIsValidDelegate addressIsValid;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNPluginCommand_rangeIsValidDelegate rangeIsValid;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNPluginCommand_functionIsValidDelegate functionIsValid;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNPluginCommand_lowLevelILFunctionIsValidDelegate lowLevelILFunctionIsValid;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNPluginCommand_lowLevelILInstructionIsValidDelegate lowLevelILInstructionIsValid;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNPluginCommand_mediumLevelILFunctionIsValidDelegate mediumLevelILFunctionIsValid;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNPluginCommand_mediumLevelILInstructionIsValidDelegate mediumLevelILInstructionIsValid;
		}

		public struct _BNPluginCommand { };

		[StructLayout(LayoutKind.Sequential)]
		public struct BNPoint
		{
			public float x;
			public float y;
		}

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct BNPossibleValueSet
		{
			public RegisterValueType state;
			public long value;
			public long offset;
			public BNValueRange* ranges;
			public long* valueSet;
			public BNLookupTableEntry* table;
			public ulong count;
		}

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct BNQualifiedName
		{
			public char** name;
			[MarshalAs(UnmanagedType.LPStr)] public string join;
			public ulong nameCount;
		}

		public struct _BNQualifiedName { };

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct BNQualifiedNameAndType
		{
			public BNQualifiedName name;
			public BNType* type;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BNRange
		{
			public ulong start;
			public ulong end;
		}

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct BNReferenceSource
		{
			public BNFunction* func;
			public BNArchitecture* arch;
			public ulong addr;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BNRegisterInfo
		{
			public uint fullWidthRegister;
			public ulong offset;
			public ulong size;
			public ImplicitRegisterExtend extend;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BNRegisterOrConstant
		{
			public bool constant;
			public uint reg;
			public ulong value;
		}

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct BNRegisterSetWithConfidence
		{
			public uint* regs;
			public ulong count;
			public byte confidence;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BNRegisterStackAdjustment
		{
			public uint regStack;
			public int adjustment;
			public byte confidence;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BNRegisterStackInfo
		{
			public uint firstStorageReg;
			public uint firstTopRelativeReg;
			public uint storageCount;
			public uint topRelativeCount;
			public uint stackTopReg;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BNRegisterValue
		{
			public RegisterValueType state;
			public long value;
			public long offset;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BNRegisterValueWithConfidence
		{
			public BNRegisterValue value;
			public byte confidence;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BNRelocation { };

		[StructLayout(LayoutKind.Sequential)]
		public struct BNRelocationHandler { };

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct BNRelocationInfo
		{
			public RelocationType type;
			public bool pcRelative;
			public bool baseRelative;
			public ulong _base;
			public ulong size;
			public ulong truncateSize;
			public ulong nativeType;
			public ulong addend;
			public bool hasSign;
			public bool implicitAddend;
			public bool external;
			public ulong symbolIndex;
			public ulong sectionIndex;
			public ulong address;
			public ulong target;
			public bool dataRelocation;
			public fixed byte relocationDataCache[8];
			public BNRelocationInfo* prev;
			public BNRelocationInfo* next;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BNRepoPlugin { };

		[StructLayout(LayoutKind.Sequential)]
		public struct BNReportCollection { };

		[StructLayout(LayoutKind.Sequential)]
		public struct BNRepository { };

		[StructLayout(LayoutKind.Sequential)]
		public struct BNRepositoryManager { };

		[StructLayout(LayoutKind.Sequential)]
		public struct BNScriptingInstance { };

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct BNScriptingInstanceCallbacks
		{
			public void* context;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNScriptingInstanceCallbacks_destroyInstanceDelegate destroyInstance;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNScriptingInstanceCallbacks_executeScriptInputDelegate executeScriptInput;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNScriptingInstanceCallbacks_setCurrentBinaryViewDelegate setCurrentBinaryView;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNScriptingInstanceCallbacks_setCurrentFunctionDelegate setCurrentFunction;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNScriptingInstanceCallbacks_setCurrentBasicBlockDelegate setCurrentBasicBlock;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNScriptingInstanceCallbacks_setCurrentAddressDelegate setCurrentAddress;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNScriptingInstanceCallbacks_setCurrentSelectionDelegate setCurrentSelection;
		}

		public struct _BNScriptingInstanceCallbacks { };

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct BNScriptingOutputListener
		{
			public void* context;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNScriptingOutputListener_outputDelegate output;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNScriptingOutputListener_errorDelegate error;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNScriptingOutputListener_inputReadyStateChangedDelegate inputReadyStateChanged;
		}

		public struct _BNScriptingOutputListener { };

		[StructLayout(LayoutKind.Sequential)]
		public struct BNScriptingProvider { };

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct BNScriptingProviderCallbacks
		{
			public void* context;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNScriptingProviderCallbacks_createInstanceDelegate createInstance;
		}

		public struct _BNScriptingProviderCallbacks { };

		[StructLayout(LayoutKind.Sequential)]
		public struct BNSection { };

		[StructLayout(LayoutKind.Sequential)]
		public struct BNSegment { };

		[StructLayout(LayoutKind.Sequential)]
		public struct BNSizeWithConfidence
		{
			public ulong value;
			public byte confidence;
		}

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct BNStackVariableReference
		{
			public uint sourceOperand;
			public byte typeConfidence;
			public BNType* type;
			[MarshalAs(UnmanagedType.LPStr)] public string name;
			public ulong varIdentifier;
			public long referencedOffset;
			public ulong size;
		}

		public struct _BNStackVariableReference { };

		[StructLayout(LayoutKind.Sequential)]
		public struct BNStringReference
		{
			public StringType type;
			public ulong start;
			public ulong length;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BNStructure { };

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct BNStructureMember
		{
			public BNType* type;
			[MarshalAs(UnmanagedType.LPStr)] public string name;
			public ulong offset;
			public byte typeConfidence;
		}

		public struct _BNStructureMember { };

		[StructLayout(LayoutKind.Sequential)]
		public struct BNSymbol { };

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct BNSystemCallInfo
		{
			public uint number;
			public BNQualifiedName name;
			public BNType* type;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BNTemporaryFile { };

		[StructLayout(LayoutKind.Sequential)]
		public struct BNTransform { };

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct BNTransformParameter
		{
			[MarshalAs(UnmanagedType.LPStr)] public string name;
			public BNDataBuffer* value;
		}

		public struct _BNTransformParameter { };

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct BNTransformParameterInfo
		{
			[MarshalAs(UnmanagedType.LPStr)] public string name;
			[MarshalAs(UnmanagedType.LPStr)] public string longName;
			public ulong fixedLength;
		}

		public struct _BNTransformParameterInfo { };

		[StructLayout(LayoutKind.Sequential)]
		public struct BNType { };

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct BNTypeParserResult
		{
			public BNQualifiedNameAndType* types;
			public BNQualifiedNameAndType* variables;
			public BNQualifiedNameAndType* functions;
			public ulong typeCount;
			public ulong variableCount;
			public ulong functionCount;
		}

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct BNTypeWithConfidence
		{
			public BNType* type;
			public byte confidence;
		}

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct BNUndoAction
		{
			public ActionType type;
			public void* context;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNUndoAction_freeObjectDelegate freeObject;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNUndoAction_undoDelegate undo;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNUndoAction_redoDelegate redo;
			[MarshalAs(UnmanagedType.FunctionPtr)] public BNUndoAction_serializeDelegate serialize;
		}

		public struct _BNUndoAction { };

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct BNUpdateChannel
		{
			[MarshalAs(UnmanagedType.LPStr)] public string name;
			[MarshalAs(UnmanagedType.LPStr)] public string description;
			[MarshalAs(UnmanagedType.LPStr)] public string latestVersion;
		}

		public struct _BNUpdateChannel { };

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct BNUpdateVersion
		{
			[MarshalAs(UnmanagedType.LPStr)] public string version;
			[MarshalAs(UnmanagedType.LPStr)] public string notes;
			public ulong time;
		}

		public struct _BNUpdateVersion { };

		[StructLayout(LayoutKind.Sequential)]
		public struct BNValueRange
		{
			public ulong start;
			public ulong end;
			public ulong step;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct BNVariable
		{
			public VariableSourceType type;
			public uint index;
			public long storage;
		}

		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct BNVariableNameAndType
		{
			public BNVariable var;
			public BNType* type;
			[MarshalAs(UnmanagedType.LPStr)] public string name;
			public bool autoDefined;
			public byte typeConfidence;
		}

		public struct _BNVariableNameAndType { };

		// Function definitions
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNAbortAnalysis(BNBinaryView* view);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNAbortFlowGraphLayoutRequest(BNFlowGraphLayoutRequest* graph);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNAnalysisCompletionEvent* BNAddAnalysisCompletionEvent(BNBinaryView* view, void* ctxt, [MarshalAs(UnmanagedType.FunctionPtr)] callbackDelegate callback);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNAddAnalysisOption(BNBinaryView* view, char* name);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNAddArchitectureRedirection(BNArchitecture* arch, BNArchitecture* from, BNArchitecture* to);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNAddAutoSection(BNBinaryView* view, char* name, ulong start, ulong length, SectionSemantics semantics, char* type, ulong align, ulong entrySize, char* linkedSection, char* infoSection, ulong infoData);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNAddAutoSegment(BNBinaryView* view, ulong start, ulong length, ulong dataOffset, ulong dataLength, uint flags);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNAddEntryPointForAnalysis(BNBinaryView* view, BNPlatform* platform, ulong addr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNAddEnumerationMember(BNEnumeration* e, char* name);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNAddEnumerationMemberWithValue(BNEnumeration* e, char* name, ulong value);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNAddFlowGraphNode(BNFlowGraph* graph, BNFlowGraphNode* node);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNAddFlowGraphNodeOutgoingEdge(BNFlowGraphNode* node, BranchType type, BNFlowGraphNode* target);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNAddFunctionForAnalysis(BNBinaryView* view, BNPlatform* platform, ulong addr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNAddGraphReportToCollection(BNReportCollection* reports, BNBinaryView* view, char* title, BNFlowGraph* graph);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNAddHTMLReportToCollection(BNReportCollection* reports, BNBinaryView* view, char* title, char* contents, char* plaintext);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNAddLowLevelILLabelForAddress(BNLowLevelILFunction* func, BNArchitecture* arch, ulong addr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNAddMarkdownReportToCollection(BNReportCollection* reports, BNBinaryView* view, char* title, char* contents, char* plaintext);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNAddOptionalPluginDependency(char* name);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNAddPlainTextReportToCollection(BNReportCollection* reports, BNBinaryView* view, char* title, char* contents);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNAddRelatedPlatform(BNPlatform* platform, BNArchitecture* arch, BNPlatform* related);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNAddRequiredPluginDependency(char* name);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNAddStructureMember(BNStructure* s, BNTypeWithConfidence* type, char* name);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNAddStructureMemberAtOffset(BNStructure* s, BNTypeWithConfidence* type, char* name, ulong offset);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNAddUndoAction(BNBinaryView* view, char* type, _BNUndoAction* action);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNAddUserSection(BNBinaryView* view, char* name, ulong start, ulong length, SectionSemantics semantics, char* type, ulong align, ulong entrySize, char* linkedSection, char* infoSection, ulong infoData);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNAddUserSegment(BNBinaryView* view, ulong start, ulong length, ulong dataOffset, ulong dataLength, uint flags);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNAllocString(char* contents);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char** BNAllocStringList(char** contents, ulong size);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNAlwaysBranch(BNBinaryView* view, BNArchitecture* arch, ulong addr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNAppendDataBuffer(BNDataBuffer* dest, BNDataBuffer* src);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNAppendDataBufferContents(BNDataBuffer* dest, void* src, ulong len);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNApplyAutoDiscoveredFunctionType(BNFunction* func, BNType* type);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNApplyImportedTypes(BNFunction* func, BNSymbol* sym);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNArchitectureAlwaysBranch(BNArchitecture* arch, byte* data, ulong addr, ulong len);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNArchitectureConvertToNop(BNArchitecture* arch, byte* data, ulong addr, ulong len);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNRelocationHandler* BNArchitectureGetRelocationHandler(BNArchitecture* arch, char* viewName);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNArchitectureInvertBranch(BNArchitecture* arch, byte* data, ulong addr, ulong len);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNArchitectureRegisterRelocationHandler(BNArchitecture* arch, char* viewName, BNRelocationHandler* handler);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNArchitectureSkipAndReturnValue(BNArchitecture* arch, byte* data, ulong addr, ulong len, ulong value);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNAreArgumentRegistersSharedIndex(BNCallingConvention* cc);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNAreAutoUpdatesEnabled();
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNAreUpdatesAvailable(char* channel, ulong* expireTime, ulong* serverTime, char** errors);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNAssemble(BNArchitecture* arch, char* code, ulong addr, BNDataBuffer* result, char** errors);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNAssignDataBuffer(BNDataBuffer* dest, BNDataBuffer* src);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNBasicBlockCanExit(BNBasicBlock* block);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNBasicBlockHasUndeterminedOutgoingEdges(BNBasicBlock* block);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNBackgroundTask* BNBeginBackgroundTask(char* initialText, bool canCancel);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNBeginUndoActions(BNFileMetadata* file);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNMetadata* BNBinaryViewQueryMetadata(BNBinaryView* view, char* key);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNBinaryViewRemoveMetadata(BNBinaryView* view, char* key);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNBinaryViewStoreMetadata(BNBinaryView* view, char* key, BNMetadata* value);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNCanCancelBackgroundTask(BNBackgroundTask* task);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNBoolWithConfidence BNCanFunctionReturn(BNFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNCancelAnalysisCompletionEvent(BNAnalysisCompletionEvent* _event);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNCancelBackgroundTask(BNBackgroundTask* task);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNClearDataBuffer(BNDataBuffer* buf);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNCloseFile(BNFileMetadata* file);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNCloseLogs();
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNCommitUndoActions(BNFileMetadata* file);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNConvertToNop(BNBinaryView* view, BNArchitecture* arch, ulong addr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNType* BNCreateArrayType(BNTypeWithConfidence* type, ulong elem);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNCreateAutoStackVariable(BNFunction* func, long offset, BNTypeWithConfidence* type, char* name);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNCreateAutoVariable(BNFunction* func, BNVariable* var, BNTypeWithConfidence* type, char* name, bool ignoreDisjointUses);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNBinaryView* BNCreateBinaryDataView(BNFileMetadata* file);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNBinaryView* BNCreateBinaryDataViewFromBuffer(BNFileMetadata* file, BNDataBuffer* buf);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNBinaryView* BNCreateBinaryDataViewFromData(BNFileMetadata* file, void* data, ulong len);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNBinaryView* BNCreateBinaryDataViewFromFile(BNFileMetadata* file, _BNFileAccessor* accessor);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNBinaryView* BNCreateBinaryDataViewFromFilename(BNFileMetadata* file, char* filename);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNBinaryReader* BNCreateBinaryReader(BNBinaryView* view);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNBinaryView* BNCreateBinaryViewOfType(BNBinaryViewType* type, BNBinaryView* data);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNBinaryWriter* BNCreateBinaryWriter(BNBinaryView* view);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNType* BNCreateBoolType();
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNCallingConvention* BNCreateCallingConvention(BNArchitecture* arch, char* name, _BNCustomCallingConvention* cc);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNBinaryView* BNCreateCustomBinaryView(char* name, BNFileMetadata* file, BNBinaryView* parent, _BNCustomBinaryView* view);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNFlowGraph* BNCreateCustomFlowGraph(_BNCustomFlowGraph* callbacks);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNDataBuffer* BNCreateDataBuffer(void* data, ulong len);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNDataRenderer* BNCreateDataRenderer(_BNCustomDataRenderer* renderer);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNCreateDatabase(BNBinaryView* data, char* path);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNCreateDatabaseWithProgress(BNBinaryView* data, char* path, void* ctxt, [MarshalAs(UnmanagedType.FunctionPtr)] progressDelegate progress);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNCreateDirectory(char* path, bool createSubdirectories);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNDisassemblySettings* BNCreateDisassemblySettings();
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNDownloadInstance* BNCreateDownloadProviderInstance(BNDownloadProvider* provider);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNEnumeration* BNCreateEnumeration();
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNType* BNCreateEnumerationType(BNArchitecture* arch, BNEnumeration* e, ulong width, bool isSigned);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNFileMetadata* BNCreateFileMetadata();
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNType* BNCreateFloatType(ulong width, char* altName);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNFlowGraph* BNCreateFlowGraph();
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNFlowGraphNode* BNCreateFlowGraphNode(BNFlowGraph* graph);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNFlowGraph* BNCreateFunctionGraph(BNFunction* func, FunctionGraphType type, BNDisassemblySettings* settings);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNType* BNCreateFunctionType(BNTypeWithConfidence* returnValue, BNCallingConventionWithConfidence* callingConvention, _BNFunctionParameter* _params, ulong paramCount, BNBoolWithConfidence* varArg, BNOffsetWithConfidence* stackAdjust);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNType* BNCreateIntegerType(ulong width, BNBoolWithConfidence* sign, char* altName);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNLowLevelILFunction* BNCreateLowLevelILFunction(BNArchitecture* arch, BNFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNFlowGraph* BNCreateLowLevelILFunctionGraph(BNLowLevelILFunction* func, BNDisassemblySettings* settings);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNMediumLevelILFunction* BNCreateMediumLevelILFunction(BNArchitecture* arch, BNFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNFlowGraph* BNCreateMediumLevelILFunctionGraph(BNMediumLevelILFunction* func, BNDisassemblySettings* settings);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNMetadata* BNCreateMetadataArray(BNMetadata** data, ulong size);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNMetadata* BNCreateMetadataBooleanData(bool data);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNMetadata* BNCreateMetadataDoubleData(double data);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNMetadata* BNCreateMetadataOfType(MetadataType type);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNMetadata* BNCreateMetadataRawData(byte* data, ulong size);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNMetadata* BNCreateMetadataSignedIntegerData(long data);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNMetadata* BNCreateMetadataStringData(char* data);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNMetadata* BNCreateMetadataUnsignedIntegerData(ulong data);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNMetadata* BNCreateMetadataValueStore(char** keys, BNMetadata** values, ulong size);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNNamedTypeReference* BNCreateNamedType();
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNType* BNCreateNamedTypeReference(BNNamedTypeReference* nt, ulong width, ulong align);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNType* BNCreateNamedTypeReferenceFromType(BNBinaryView* view, _BNQualifiedName* name);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNType* BNCreateNamedTypeReferenceFromTypeAndId(char* id, _BNQualifiedName* name, BNType* type);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNPlatform* BNCreatePlatform(BNArchitecture* arch, char* name);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNType* BNCreatePointerType(BNArchitecture* arch, BNTypeWithConfidence* type, BNBoolWithConfidence* cnst, BNBoolWithConfidence* vltl, ReferenceType refType);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNType* BNCreatePointerTypeOfWidth(ulong width, BNTypeWithConfidence* type, BNBoolWithConfidence* cnst, BNBoolWithConfidence* vltl, ReferenceType refType);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNRelocationHandler* BNCreateRelocationHandler(_BNCustomRelocationHandler* handler);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNReportCollection* BNCreateReportCollection();
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNRepositoryManager* BNCreateRepositoryManager(char* enabledPluginsPath);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNScriptingInstance* BNCreateScriptingProviderInstance(BNScriptingProvider* provider);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNSegment* BNCreateSegment(ulong start, ulong length, ulong dataOffset, ulong dataLength, uint flags, bool autoDefined);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNStructure* BNCreateStructure();
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNType* BNCreateStructureType(BNStructure* s);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNStructure* BNCreateStructureWithOptions(StructureType type, bool packed);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNSymbol* BNCreateSymbol(SymbolType type, char* shortName, char* fullName, char* rawName, ulong addr, SymbolBinding binding, _BNNameSpace* nameSpace);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNTemporaryFile* BNCreateTemporaryFile();
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNTemporaryFile* BNCreateTemporaryFileWithContents(BNDataBuffer* data);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNCreateUserFunction(BNBinaryView* view, BNPlatform* platform, ulong addr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNCreateUserStackVariable(BNFunction* func, long offset, BNTypeWithConfidence* type, char* name);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNCreateUserVariable(BNFunction* func, BNVariable* var, BNTypeWithConfidence* type, char* name, bool ignoreDisjointUses);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNType* BNCreateVoidType();
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNDataBufferToBase64(BNDataBuffer* buf);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNDataBufferToEscapedString(BNDataBuffer* buf);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNDecode(BNTransform* xform, BNDataBuffer* input, BNDataBuffer* output, _BNTransformParameter* _params, ulong paramCount);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNDataBuffer* BNDecodeBase64(char* str);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNDataBuffer* BNDecodeEscapedString(char* str);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNQualifiedName BNDefineAnalysisType(BNBinaryView* view, char* id, _BNQualifiedName* defaultName, BNType* type);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNDefineAutoSymbol(BNBinaryView* view, BNSymbol* sym);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNDefineAutoSymbolAndVariableOrFunction(BNBinaryView* view, BNPlatform* platform, BNSymbol* sym, BNType* type);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNDefineDataVariable(BNBinaryView* view, ulong addr, BNTypeWithConfidence* type);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNDefineImportedFunction(BNBinaryView* view, BNSymbol* importAddressSym, BNFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNDefineRelocation(BNBinaryView* view, BNArchitecture* arch, BNRelocationInfo* info, ulong target, ulong reloc);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNDefineSymbolRelocation(BNBinaryView* view, BNArchitecture* arch, BNRelocationInfo* info, BNSymbol* target, ulong reloc);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNDefineUserAnalysisType(BNBinaryView* view, _BNQualifiedName* name, BNType* type);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNDefineUserDataVariable(BNBinaryView* view, ulong addr, BNTypeWithConfidence* type);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNDefineUserSymbol(BNBinaryView* view, BNSymbol* sym);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNDeleteAutoStackVariable(BNFunction* func, long offset);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNDeleteAutoVariable(BNFunction* func, BNVariable* var);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe int BNDeleteDirectory(char* path, int contentsOnly);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe int BNDeleteFile(char* path);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNDeleteUserStackVariable(BNFunction* func, long offset);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNDeleteUserVariable(BNFunction* func, BNVariable* var);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNDemangleGNU3(BNArchitecture* arch, char* mangledName, BNType** outType, char*** outVarName, ulong* outVarNameElements);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNDemangleMS(BNArchitecture* arch, char* mangledName, BNType** outType, char*** outVarName, ulong* outVarNameElements);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNDeserializeSettings(char* registry, char* contents, BNBinaryView* view, SettingsScope scope);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNDataBuffer* BNDuplicateDataBuffer(BNDataBuffer* buf);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNType* BNDuplicateType(BNType* type);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNEncode(BNTransform* xform, BNDataBuffer* input, BNDataBuffer* output, _BNTransformParameter* _params, ulong paramCount);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNExecuteMainThreadAction(BNMainThreadAction* action);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNMainThreadAction* BNExecuteOnMainThread(void* ctxt, [MarshalAs(UnmanagedType.FunctionPtr)] funcDelegate func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNExecuteOnMainThreadAndWait(void* ctxt, [MarshalAs(UnmanagedType.FunctionPtr)] funcDelegate func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ScriptingProviderExecuteResult BNExecuteScriptInput(BNScriptingInstance* instance, char* input);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNExecuteWorkerProcess(char* path, char** args, BNDataBuffer* input, char** output, char** error, bool stdoutIsText, bool stderrIsText);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNFileSize(char* path, ulong* size);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFinalizeLowLevelILFunction(BNLowLevelILFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFinalizeMediumLevelILFunction(BNMediumLevelILFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNFindNextConstant(BNBinaryView* view, ulong start, ulong constant, ulong* result, BNDisassemblySettings* settings);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNFindNextConstantWithProgress(BNBinaryView* view, ulong start, ulong end, ulong constant, ulong* result, BNDisassemblySettings* settings, void* ctxt, [MarshalAs(UnmanagedType.FunctionPtr)] progressDelegate progress);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNFindNextData(BNBinaryView* view, ulong start, BNDataBuffer* data, ulong* result, FindFlag flags);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNFindNextDataWithProgress(BNBinaryView* view, ulong start, ulong end, BNDataBuffer* data, ulong* result, FindFlag flags, void* ctxt, [MarshalAs(UnmanagedType.FunctionPtr)] progressDelegate progress);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNFindNextText(BNBinaryView* view, ulong start, char* data, ulong* result, BNDisassemblySettings* settings, FindFlag flags);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNFindNextTextWithProgress(BNBinaryView* view, ulong start, ulong end, char* data, ulong* result, BNDisassemblySettings* settings, FindFlag flags, void* ctxt, [MarshalAs(UnmanagedType.FunctionPtr)] progressDelegate progress);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFinishBackgroundTask(BNBackgroundTask* task);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFinishPrepareForLayout(BNFlowGraph* graph);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNFlowGraphHasNodes(BNFlowGraph* graph);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeAddressList(ulong* addrs);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeAddressRanges(BNAddressRange* ranges);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeAnalysisCompletionEvent(BNAnalysisCompletionEvent* _event);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeAnalysisInfo(BNAnalysisInfo* info);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeAnalysisPerformanceInfo(_BNPerformanceInfo* info, ulong count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeArchitectureList(BNArchitecture** archs);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeBackgroundTask(BNBackgroundTask* task);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeBackgroundTaskList(BNBackgroundTask** tasks, ulong count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeBasicBlock(BNBasicBlock* block);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeBasicBlockEdgeList(BNBasicBlockEdge* edges, ulong count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeBasicBlockList(BNBasicBlock** blocks, ulong count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeBinaryReader(BNBinaryReader* stream);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeBinaryView(BNBinaryView* view);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeBinaryViewTypeList(BNBinaryViewType** types);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeBinaryWriter(BNBinaryWriter* stream);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeCallingConvention(BNCallingConvention* cc);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeCallingConventionList(BNCallingConvention** list, ulong count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeCodeReferences(BNReferenceSource* refs, ulong count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeConstantReferenceList(BNConstantReference* refs);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeDataBuffer(BNDataBuffer* buf);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeDataReferences(ulong* refs);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeDataRenderer(BNDataRenderer* renderer);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeDataVariables(BNDataVariable* vars, ulong count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeDemangledName(char*** name, ulong nameElements);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeDisassemblySettings(BNDisassemblySettings* settings);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeDisassemblyTextLines(BNDisassemblyTextLine* lines, ulong count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeDownloadInstance(BNDownloadInstance* instance);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeDownloadProviderList(BNDownloadProvider** providers);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeEnumeration(BNEnumeration* e);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeEnumerationMemberList(_BNEnumerationMember* members, ulong count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeFileMetadata(BNFileMetadata* file);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeFlagConditionsForSemanticFlagGroup(BNFlagConditionForSemanticClass* conditions);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeFlowGraph(BNFlowGraph* graph);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeFlowGraphLayoutRequest(BNFlowGraphLayoutRequest* layout);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeFlowGraphNode(BNFlowGraphNode* node);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeFlowGraphNodeList(BNFlowGraphNode** nodes, ulong count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeFlowGraphNodeOutgoingEdgeList(BNFlowGraphEdge* edges, ulong count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeFormInputResults(_BNFormInputField* fields, ulong count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeFunction(BNFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeFunctionList(BNFunction** funcs, ulong count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeILBranchDependenceList(BNILBranchInstructionAndDependence* branches);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeILInstructionList(ulong* list);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeIndirectBranchList(BNIndirectBranchInfo* branches);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeInstructionText(_BNInstructionTextToken* tokens, ulong count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeInstructionTextLines(BNInstructionTextLine* lines, ulong count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeLinearDisassemblyLines(BNLinearDisassemblyLine* lines, ulong count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeLinearDisassemblyPosition(BNLinearDisassemblyPosition* pos);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeLowLevelILFunction(BNLowLevelILFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeMainThreadAction(BNMainThreadAction* action);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeMediumLevelILFunction(BNMediumLevelILFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeMetadata(BNMetadata* data);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeMetadataArray(BNMetadata** data);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeMetadataRaw(byte* data);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeMetadataValueStore(BNMetadataValueStore* data);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeNameAndTypeList(_BNNameAndType* nt, ulong count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeNameSpace(_BNNameSpace* name);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeNameSpaceList(_BNNameSpace* nameSpace, ulong count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeNamedTypeReference(BNNamedTypeReference* nt);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeOutputTypeList(BNTypeWithConfidence* types, ulong count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeParameterVariables(BNParameterVariablesWithConfidence* vars);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeParseError(char* errorString);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreePlatform(BNPlatform* platform);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreePlatformList(BNPlatform** platform, ulong count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreePlatformOSList(char** list, ulong count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreePlugin(BNRepoPlugin* plugin);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreePluginCommandList(_BNPluginCommand* commands);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreePluginTypes(BNPluginType* r);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreePossibleValueSet(BNPossibleValueSet* value);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeQualifiedName(_BNQualifiedName* name);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeQualifiedNameAndType(BNQualifiedNameAndType* obj);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeQualifiedNameAndTypeArray(BNQualifiedNameAndType* obj, ulong count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeRegisterList(uint* regs);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeRegisterSet(BNRegisterSetWithConfidence* regs);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeRegisterStackAdjustments(BNRegisterStackAdjustment* adjustments);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeRelocation(BNRelocation* reloc);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeRelocationHandler(BNRelocationHandler* handler);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeRelocationRanges(BNRange* ranges);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeReportCollection(BNReportCollection* reports);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeRepository(BNRepository* r);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeRepositoryManager(BNRepositoryManager* r);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeRepositoryManagerRepositoriesList(BNRepository** r);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeRepositoryPluginList(BNRepoPlugin** r);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeScriptingInstance(BNScriptingInstance* instance);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeScriptingProviderList(BNScriptingProvider** providers);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeSection(BNSection* section);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeSectionList(BNSection** sections, ulong count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeSegment(BNSegment* seg);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeSegmentList(BNSegment** segments, ulong count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeStackVariableReferenceList(_BNStackVariableReference* refs, ulong count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeString(char* str);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeStringList(char** strs, ulong count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeStringReferenceList(BNStringReference* strings);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeStructure(BNStructure* s);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeStructureMemberList(_BNStructureMember* members, ulong count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeSymbol(BNSymbol* sym);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeSymbolList(BNSymbol** syms, ulong count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeSystemCallList(BNSystemCallInfo* syscalls, ulong count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeTemporaryFile(BNTemporaryFile* file);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeTransformParameterList(_BNTransformParameterInfo* _params, ulong count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeTransformTypeList(BNTransform** xforms);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeType(BNType* type);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeTypeList(BNQualifiedNameAndType* types, ulong count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeTypeParameterList(_BNFunctionParameter* types, ulong count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeTypeParserResult(BNTypeParserResult* result);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeUpdateChannelList(_BNUpdateChannel* list, ulong count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeUpdateChannelVersionList(_BNUpdateVersion* list, ulong count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeVariableNameAndType(_BNVariableNameAndType* var);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNFreeVariableNameAndTypeList(_BNVariableNameAndType* vars, ulong count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNVariable BNFromVariableIdentifier(ulong id);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNFunctionHasExplicitlyDefinedType(BNFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNBoolWithConfidence BNFunctionHasVariableArguments(BNFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNBoolWithConfidence BNFunctionTypeCanReturn(BNType* type);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNGenerateAutoDebugTypeId(_BNQualifiedName* name);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNGenerateAutoDemangledTypeId(_BNQualifiedName* name);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNGenerateAutoPlatformTypeId(BNPlatform* platform, _BNQualifiedName* name);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNGenerateAutoTypeId(char* source, _BNQualifiedName* name);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNGenerateMediumLevelILSSAForm(BNMediumLevelILFunction* func, bool analyzeConditionals, bool handleAliases, BNVariable* knownNotAliases, ulong knownNotAliasCount, BNVariable* knownAliases, ulong knownAliasCount);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNGetActiveUpdateChannel();
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNGetAddressForDataOffset(BNBinaryView* view, ulong offset, ulong* addr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNGetAddressInput(ulong* result, char* prompt, char* title, BNBinaryView* view, ulong currentAddr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe uint* BNGetAllArchitectureFlagWriteTypes(BNArchitecture* arch, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe uint* BNGetAllArchitectureFlags(BNArchitecture* arch, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe uint* BNGetAllArchitectureIntrinsics(BNArchitecture* arch, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe uint* BNGetAllArchitectureRegisterStacks(BNArchitecture* arch, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe uint* BNGetAllArchitectureRegisters(BNArchitecture* arch, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe uint* BNGetAllArchitectureSemanticFlagClasses(BNArchitecture* arch, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe uint* BNGetAllArchitectureSemanticFlagGroups(BNArchitecture* arch, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNILBranchInstructionAndDependence* BNGetAllMediumLevelILBranchDependence(BNMediumLevelILFunction* func, ulong instr, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNPluginCommand* BNGetAllPluginCommands(ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNAddressRange* BNGetAllocatedRanges(BNBinaryView* view, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNFunction* BNGetAnalysisEntryPoint(BNBinaryView* view);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNFunction* BNGetAnalysisFunction(BNBinaryView* view, BNPlatform* platform, ulong addr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNFunction** BNGetAnalysisFunctionList(BNBinaryView* view, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNFunction** BNGetAnalysisFunctionsForAddress(BNBinaryView* view, ulong addr, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNAnalysisInfo* BNGetAnalysisInfo(BNBinaryView* view);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNAnalysisProgress BNGetAnalysisProgress(BNBinaryView* view);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe AnalysisSkipReason BNGetAnalysisSkipReason(BNFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNType* BNGetAnalysisTypeById(BNBinaryView* view, char* id);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNType* BNGetAnalysisTypeByName(BNBinaryView* view, _BNQualifiedName* name);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNGetAnalysisTypeId(BNBinaryView* view, _BNQualifiedName* name);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNQualifiedNameAndType* BNGetAnalysisTypeList(BNBinaryView* view, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNQualifiedName BNGetAnalysisTypeNameById(BNBinaryView* view, char* id);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetArchitectureAddressSize(BNArchitecture* arch);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNArchitecture* BNGetArchitectureByName(char* name);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNCallingConvention* BNGetArchitectureCallingConventionByName(BNArchitecture* arch, char* name);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNCallingConvention** BNGetArchitectureCallingConventions(BNArchitecture* arch, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNCallingConvention* BNGetArchitectureCdeclCallingConvention(BNArchitecture* arch);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNCallingConvention* BNGetArchitectureDefaultCallingConvention(BNArchitecture* arch);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetArchitectureDefaultIntegerSize(BNArchitecture* arch);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe Endianness BNGetArchitectureEndianness(BNArchitecture* arch);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNCallingConvention* BNGetArchitectureFastcallCallingConvention(BNArchitecture* arch);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetArchitectureFlagConditionLowLevelIL(BNArchitecture* arch, LowLevelILFlagCondition cond, uint semClass, BNLowLevelILFunction* il);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNFlagConditionForSemanticClass* BNGetArchitectureFlagConditionsForSemanticFlagGroup(BNArchitecture* arch, uint semGroup, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNGetArchitectureFlagName(BNArchitecture* arch, uint flag);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe FlagRole BNGetArchitectureFlagRole(BNArchitecture* arch, uint flag, uint semClass);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetArchitectureFlagWriteLowLevelIL(BNArchitecture* arch, LowLevelILOperation op, ulong size, uint flagWriteType, uint flag, BNRegisterOrConstant* operands, ulong operandCount, BNLowLevelILFunction* il);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNGetArchitectureFlagWriteTypeName(BNArchitecture* arch, uint flags);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe uint* BNGetArchitectureFlagsRequiredForFlagCondition(BNArchitecture* arch, LowLevelILFlagCondition cond, uint semClass, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe uint* BNGetArchitectureFlagsRequiredForSemanticFlagGroup(BNArchitecture* arch, uint semGroup, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe uint* BNGetArchitectureFlagsWrittenByFlagWriteType(BNArchitecture* arch, uint writeType, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNArchitecture* BNGetArchitectureForViewType(BNBinaryViewType* type, uint id, Endianness endian);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe uint* BNGetArchitectureGlobalRegisters(BNArchitecture* arch, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetArchitectureInstructionAlignment(BNArchitecture* arch);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNNameAndType* BNGetArchitectureIntrinsicInputs(BNArchitecture* arch, uint intrinsic, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNGetArchitectureIntrinsicName(BNArchitecture* arch, uint intrinsic);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNTypeWithConfidence* BNGetArchitectureIntrinsicOutputs(BNArchitecture* arch, uint intrinsic, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe uint BNGetArchitectureLinkRegister(BNArchitecture* arch);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNArchitecture** BNGetArchitectureList(ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetArchitectureMaxInstructionLength(BNArchitecture* arch);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNGetArchitectureName(BNArchitecture* arch);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetArchitectureOpcodeDisplayLength(BNArchitecture* arch);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe uint BNGetArchitectureRegisterByName(BNArchitecture* arch, char* name);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNRegisterInfo BNGetArchitectureRegisterInfo(BNArchitecture* arch, uint reg);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNGetArchitectureRegisterName(BNArchitecture* arch, uint reg);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe uint BNGetArchitectureRegisterStackForRegister(BNArchitecture* arch, uint reg);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNRegisterStackInfo BNGetArchitectureRegisterStackInfo(BNArchitecture* arch, uint regStack);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNGetArchitectureRegisterStackName(BNArchitecture* arch, uint regStack);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe uint BNGetArchitectureSemanticClassForFlagWriteType(BNArchitecture* arch, uint writeType);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNGetArchitectureSemanticFlagClassName(BNArchitecture* arch, uint semClass);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetArchitectureSemanticFlagGroupLowLevelIL(BNArchitecture* arch, uint semGroup, BNLowLevelILFunction* il);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNGetArchitectureSemanticFlagGroupName(BNArchitecture* arch, uint semGroup);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe uint BNGetArchitectureStackPointerRegister(BNArchitecture* arch);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNPlatform* BNGetArchitectureStandalonePlatform(BNArchitecture* arch);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNCallingConvention* BNGetArchitectureStdcallCallingConvention(BNArchitecture* arch);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNArchitecture* BNGetAssociatedArchitectureByAddress(BNArchitecture* arch, ulong* addr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNPlatform* BNGetAssociatedPlatformByAddress(BNPlatform* platform, ulong* addr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNGetAutoDebugTypeIdSource();
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNGetAutoDemangledTypeIdSource();
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNGetAutoPlatformTypeIdSource(BNPlatform* platform);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNBackgroundTask* BNGetBackgroundAnalysisTask(BNBinaryView* view);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNGetBackgroundTaskProgressText(BNBackgroundTask* task);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNArchitecture* BNGetBasicBlockArchitecture(BNBasicBlock* block);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNDisassemblyTextLine* BNGetBasicBlockDisassemblyText(BNBasicBlock* block, BNDisassemblySettings* settings, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNBasicBlock** BNGetBasicBlockDominanceFrontier(BNBasicBlock* block, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNBasicBlock** BNGetBasicBlockDominatorTreeChildren(BNBasicBlock* block, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNBasicBlock** BNGetBasicBlockDominators(BNBasicBlock* block, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetBasicBlockEnd(BNBasicBlock* block);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNFunction* BNGetBasicBlockFunction(BNBasicBlock* block);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNHighlightColor BNGetBasicBlockHighlight(BNBasicBlock* block);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNBasicBlock* BNGetBasicBlockImmediateDominator(BNBasicBlock* block);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNBasicBlockEdge* BNGetBasicBlockIncomingEdges(BNBasicBlock* block, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetBasicBlockIndex(BNBasicBlock* block);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNBasicBlock** BNGetBasicBlockIteratedDominanceFrontier(BNBasicBlock** blocks, ulong incomingCount, ulong* outputCount);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetBasicBlockLength(BNBasicBlock* block);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNLowLevelILFunction* BNGetBasicBlockLowLevelILFunction(BNBasicBlock* block);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNMediumLevelILFunction* BNGetBasicBlockMediumLevelILFunction(BNBasicBlock* block);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNBasicBlockEdge* BNGetBasicBlockOutgoingEdges(BNBasicBlock* block, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetBasicBlockStart(BNBasicBlock* block);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNBasicBlock** BNGetBasicBlockStrictDominators(BNBasicBlock* block, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNBasicBlock** BNGetBasicBlocksForAddress(BNBinaryView* view, ulong addr, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNBasicBlock** BNGetBasicBlocksStartingAtAddress(BNBinaryView* view, ulong addr, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe Endianness BNGetBinaryReaderEndianness(BNBinaryReader* stream);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetBinaryViewTypeArchitectureConstant(BNArchitecture* arch, char* type, char* name, ulong defaultValue);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNBinaryViewType* BNGetBinaryViewTypeByName(char* name);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNGetBinaryViewTypeLongName(BNBinaryViewType* type);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNGetBinaryViewTypeName(BNBinaryViewType* type);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNBinaryViewType** BNGetBinaryViewTypes(ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNBinaryViewType** BNGetBinaryViewTypesForData(BNBinaryView* data, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe Endianness BNGetBinaryWriterEndianness(BNBinaryWriter* stream);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe uint BNGetBuildId();
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNGetBundledPluginDirectory();
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNRegisterStackAdjustment* BNGetCallRegisterStackAdjustment(BNFunction* func, BNArchitecture* arch, ulong addr, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNRegisterStackAdjustment BNGetCallRegisterStackAdjustmentForRegisterStack(BNFunction* func, BNArchitecture* arch, ulong addr, uint regStack);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNOffsetWithConfidence BNGetCallStackAdjustment(BNFunction* func, BNArchitecture* arch, ulong addr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe uint* BNGetCalleeSavedRegisters(BNCallingConvention* cc, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe uint* BNGetCallerSavedRegisters(BNCallingConvention* cc, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNArchitecture* BNGetCallingConventionArchitecture(BNCallingConvention* cc);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNGetCallingConventionName(BNCallingConvention* cc);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNTypeWithConfidence BNGetChildType(BNType* type);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNGetChoiceInput(ulong* result, char* prompt, char* title, char** choices, ulong count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNReferenceSource* BNGetCodeReferences(BNBinaryView* view, ulong addr, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNReferenceSource* BNGetCodeReferencesInRange(BNBinaryView* view, ulong addr, ulong len, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNGetCommentForAddress(BNFunction* func, ulong addr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong* BNGetCommentedAddresses(BNFunction* func, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNConstantReference* BNGetConstantsReferencedByInstruction(BNFunction* func, BNArchitecture* arch, ulong addr, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetCurrentOffset(BNFileMetadata* file);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNGetCurrentView(BNFileMetadata* file);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe byte BNGetDataBufferByte(BNDataBuffer* buf, ulong offset);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void* BNGetDataBufferContents(BNDataBuffer* buf);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void* BNGetDataBufferContentsAt(BNDataBuffer* buf, ulong offset);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetDataBufferLength(BNDataBuffer* buf);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNDataBuffer* BNGetDataBufferSlice(BNDataBuffer* buf, ulong start, ulong len);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong* BNGetDataReferences(BNBinaryView* view, ulong addr, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong* BNGetDataReferencesInRange(BNBinaryView* view, ulong addr, ulong len, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNDataRendererContainer* BNGetDataRendererContainer();
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNGetDataVariableAtAddress(BNBinaryView* view, ulong addr, BNDataVariable* var);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNDataVariable* BNGetDataVariables(BNBinaryView* view, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNArchitecture* BNGetDefaultArchitecture(BNBinaryView* view);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetDefaultArchitectureFlagConditionLowLevelIL(BNArchitecture* arch, LowLevelILFlagCondition cond, uint semClass, BNLowLevelILFunction* il);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetDefaultArchitectureFlagWriteLowLevelIL(BNArchitecture* arch, LowLevelILOperation op, ulong size, FlagRole role, BNRegisterOrConstant* operands, ulong operandCount, BNLowLevelILFunction* il);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe Endianness BNGetDefaultEndianness(BNBinaryView* view);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNVariable BNGetDefaultIncomingVariableForParameterVariable(BNCallingConvention* cc, BNVariable* var);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNVariable BNGetDefaultParameterVariableForIncomingVariable(BNCallingConvention* cc, BNVariable* var);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNPlatform* BNGetDefaultPlatform(BNBinaryView* view);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNGetDirectoryNameInput(char** result, char* prompt, char* defaultName);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetDisassemblyMaximumSymbolWidth(BNDisassemblySettings* settings);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetDisassemblyWidth(BNDisassemblySettings* settings);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNDownloadProvider* BNGetDownloadProviderByName(char* name);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNDownloadProvider** BNGetDownloadProviderList(ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNGetDownloadProviderName(BNDownloadProvider* provider);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetEndOffset(BNBinaryView* view);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetEntryPoint(BNBinaryView* view);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNEnumerationMember* BNGetEnumerationMembers(BNEnumeration* e, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNGetErrorForDownloadInstance(BNDownloadInstance* instance);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNNameSpace BNGetExternalNameSpace();
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNFileMetadata* BNGetFileForView(BNBinaryView* view);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNBinaryView* BNGetFileViewOfType(BNFileMetadata* file, char* name);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNGetFilename(BNFileMetadata* file);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe uint* BNGetFlagsReadByLiftedILInstruction(BNFunction* func, ulong i, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe uint* BNGetFlagsWrittenByLiftedILInstruction(BNFunction* func, ulong i, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe uint* BNGetFloatArgumentRegisters(BNCallingConvention* cc, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe uint BNGetFloatReturnValueRegister(BNCallingConvention* cc);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNBasicBlock* BNGetFlowGraphBasicBlock(BNFlowGraphNode* node);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe int BNGetFlowGraphHeight(BNFlowGraph* graph);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNLowLevelILFunction* BNGetFlowGraphLowLevelILFunction(BNFlowGraph* graph);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNMediumLevelILFunction* BNGetFlowGraphMediumLevelILFunction(BNFlowGraph* graph);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNFlowGraphNode* BNGetFlowGraphNode(BNFlowGraph* graph, ulong i);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe int BNGetFlowGraphNodeHeight(BNFlowGraphNode* node);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNHighlightColor BNGetFlowGraphNodeHighlight(BNFlowGraphNode* node);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNDisassemblyTextLine* BNGetFlowGraphNodeLines(BNFlowGraphNode* node, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNFlowGraphEdge* BNGetFlowGraphNodeOutgoingEdges(BNFlowGraphNode* node, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe int BNGetFlowGraphNodeWidth(BNFlowGraphNode* node);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe int BNGetFlowGraphNodeX(BNFlowGraphNode* node);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe int BNGetFlowGraphNodeY(BNFlowGraphNode* node);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNFlowGraphNode** BNGetFlowGraphNodes(BNFlowGraph* graph, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNFlowGraphNode** BNGetFlowGraphNodesInRegion(BNFlowGraph* graph, int left, int top, int right, int bottom, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe int BNGetFlowGraphWidth(BNFlowGraph* graph);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNGetFormInput(_BNFormInputField* fields, ulong count, char* title);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe uint* BNGetFullWidthArchitectureRegisters(BNArchitecture* arch, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNPerformanceInfo* BNGetFunctionAnalysisPerformanceInfo(BNFunction* func, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe FunctionAnalysisSkipOverride BNGetFunctionAnalysisSkipOverride(BNFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNArchitecture* BNGetFunctionArchitecture(BNFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNBasicBlock* BNGetFunctionBasicBlockAtAddress(BNFunction* func, BNArchitecture* arch, ulong addr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNBasicBlock** BNGetFunctionBasicBlockList(BNFunction* func, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNInstructionTextLine* BNGetFunctionBlockAnnotations(BNFunction* func, BNArchitecture* arch, ulong addr, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNCallingConventionWithConfidence BNGetFunctionCallingConvention(BNFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNRegisterSetWithConfidence BNGetFunctionClobberedRegisters(BNFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNGetFunctionComment(BNFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNBinaryView* BNGetFunctionData(BNFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNFunction* BNGetFunctionForFlowGraph(BNFlowGraph* graph);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNRegisterValueWithConfidence BNGetFunctionGlobalPointerValue(BNFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNLowLevelILFunction* BNGetFunctionLiftedIL(BNFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNLowLevelILFunction* BNGetFunctionLowLevelIL(BNFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNMediumLevelILFunction* BNGetFunctionMediumLevelIL(BNFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNParameterVariablesWithConfidence BNGetFunctionParameterVariables(BNFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNPlatform* BNGetFunctionPlatform(BNFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNRegisterStackAdjustment* BNGetFunctionRegisterStackAdjustments(BNFunction* func, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNRegisterValueWithConfidence BNGetFunctionRegisterValueAtExit(BNFunction* func, uint reg);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNRegisterSetWithConfidence BNGetFunctionReturnRegisters(BNFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNTypeWithConfidence BNGetFunctionReturnType(BNFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNOffsetWithConfidence BNGetFunctionStackAdjustment(BNFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetFunctionStart(BNFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNSymbol* BNGetFunctionSymbol(BNFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNType* BNGetFunctionType(BNFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNDisassemblyTextLine* BNGetFunctionTypeTokens(BNFunction* func, BNDisassemblySettings* settings, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNVariableNameAndType* BNGetFunctionVariables(BNFunction* func, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe uint BNGetGlobalPointerRegister(BNCallingConvention* cc);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNRegisterValueWithConfidence BNGetGlobalPointerValue(BNBinaryView* view);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNFlowGraph* BNGetGraphForFlowGraphLayoutRequest(BNFlowGraphLayoutRequest* layout);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe uint BNGetHighIntegerReturnValueRegister(BNCallingConvention* cc);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe int BNGetHorizontalFlowGraphNodeMargin(BNFlowGraph* graph);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe uint* BNGetImplicitlyDefinedRegisters(BNCallingConvention* cc, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNRegisterValue BNGetIncomingFlagValue(BNCallingConvention* cc, uint reg, BNFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNRegisterValue BNGetIncomingRegisterValue(BNCallingConvention* cc, uint reg, BNFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNVariable BNGetIncomingVariableForParameterVariable(BNCallingConvention* cc, BNVariable* var, BNFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNIndirectBranchInfo* BNGetIndirectBranches(BNFunction* func, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNIndirectBranchInfo* BNGetIndirectBranchesAt(BNFunction* func, BNArchitecture* arch, ulong addr, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNGetInstallDirectory();
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNHighlightColor BNGetInstructionHighlight(BNFunction* func, BNArchitecture* arch, ulong addr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNGetInstructionInfo(BNArchitecture* arch, byte* data, ulong addr, ulong maxLen, BNInstructionInfo* result);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetInstructionLength(BNBinaryView* view, BNArchitecture* arch, ulong addr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNGetInstructionLowLevelIL(BNArchitecture* arch, byte* data, ulong addr, ulong* len, BNLowLevelILFunction* il);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNGetInstructionText(BNArchitecture* arch, byte* data, ulong addr, ulong* len, BNInstructionTextToken** result, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe uint* BNGetIntegerArgumentRegisters(BNCallingConvention* cc, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe IntegerDisplayType BNGetIntegerConstantDisplayType(BNFunction* func, BNArchitecture* arch, ulong instrAddr, ulong value, ulong operand);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNGetIntegerInput(long* result, char* prompt, char* title);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe uint BNGetIntegerReturnValueRegister(BNCallingConvention* cc);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNNameSpace BNGetInternalNameSpace();
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNLowLevelILLabel* BNGetLabelForLowLevelILSourceInstruction(BNLowLevelILFunction* func, ulong instr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNMediumLevelILLabel* BNGetLabelForMediumLevelILSourceInstruction(BNMediumLevelILFunction* func, ulong instr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe int BNGetLicenseCount();
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetLicenseExpirationTime();
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNGetLicensedUserEmail();
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong* BNGetLiftedILFlagDefinitionsForUse(BNFunction* func, ulong i, uint flag, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong* BNGetLiftedILFlagUsesForDefinition(BNFunction* func, ulong i, uint flag, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetLiftedILForInstruction(BNFunction* func, BNArchitecture* arch, ulong addr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNLinearDisassemblyPosition BNGetLinearDisassemblyPositionForAddress(BNBinaryView* view, ulong addr, BNDisassemblySettings* settings);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNDisassemblyTextLine* BNGetLinesForData(void* ctxt, BNBinaryView* view, ulong addr, BNType* type, _BNInstructionTextToken* prefix, ulong prefixCount, ulong width, ulong* count, BNType** typeCtx, ulong ctxCount);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNBasicBlock* BNGetLowLevelILBasicBlockForInstruction(BNLowLevelILFunction* func, ulong i);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNBasicBlock** BNGetLowLevelILBasicBlockList(BNLowLevelILFunction* func, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNLowLevelILInstruction BNGetLowLevelILByIndex(BNLowLevelILFunction* func, ulong i);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong* BNGetLowLevelILExitsForInstruction(BNFunction* func, BNArchitecture* arch, ulong addr, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetLowLevelILExprCount(BNLowLevelILFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetLowLevelILExprIndex(BNMediumLevelILFunction* func, ulong expr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNGetLowLevelILExprText(BNLowLevelILFunction* func, BNArchitecture* arch, ulong i, BNInstructionTextToken** tokens, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNRegisterValue BNGetLowLevelILExprValue(BNLowLevelILFunction* func, ulong expr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNRegisterValue BNGetLowLevelILFlagValueAfterInstruction(BNLowLevelILFunction* func, uint flag, ulong instr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNRegisterValue BNGetLowLevelILFlagValueAtInstruction(BNLowLevelILFunction* func, uint flag, ulong instr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetLowLevelILForInstruction(BNFunction* func, BNArchitecture* arch, ulong addr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNLowLevelILFunction* BNGetLowLevelILForMediumLevelIL(BNMediumLevelILFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetLowLevelILIndexForInstruction(BNLowLevelILFunction* func, ulong i);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetLowLevelILInstructionCount(BNLowLevelILFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetLowLevelILInstructionForExpr(BNLowLevelILFunction* func, ulong expr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetLowLevelILInstructionIndex(BNMediumLevelILFunction* func, ulong instr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNGetLowLevelILInstructionText(BNLowLevelILFunction* il, BNFunction* func, BNArchitecture* arch, ulong i, BNInstructionTextToken** tokens, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNLowLevelILLabel* BNGetLowLevelILLabelForAddress(BNLowLevelILFunction* func, BNArchitecture* arch, ulong addr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetLowLevelILNonSSAExprIndex(BNLowLevelILFunction* func, ulong expr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNLowLevelILFunction* BNGetLowLevelILNonSSAForm(BNLowLevelILFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetLowLevelILNonSSAInstructionIndex(BNLowLevelILFunction* func, ulong instr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNFunction* BNGetLowLevelILOwnerFunction(BNLowLevelILFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNPossibleValueSet BNGetLowLevelILPossibleExprValues(BNLowLevelILFunction* func, ulong expr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNPossibleValueSet BNGetLowLevelILPossibleFlagValuesAfterInstruction(BNLowLevelILFunction* func, uint flag, ulong instr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNPossibleValueSet BNGetLowLevelILPossibleFlagValuesAtInstruction(BNLowLevelILFunction* func, uint flag, ulong instr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNPossibleValueSet BNGetLowLevelILPossibleRegisterValuesAfterInstruction(BNLowLevelILFunction* func, uint reg, ulong instr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNPossibleValueSet BNGetLowLevelILPossibleRegisterValuesAtInstruction(BNLowLevelILFunction* func, uint reg, ulong instr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNPossibleValueSet BNGetLowLevelILPossibleStackContentsAfterInstruction(BNLowLevelILFunction* func, long offset, ulong len, ulong instr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNPossibleValueSet BNGetLowLevelILPossibleStackContentsAtInstruction(BNLowLevelILFunction* func, long offset, ulong len, ulong instr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNRegisterValue BNGetLowLevelILRegisterValueAfterInstruction(BNLowLevelILFunction* func, uint reg, ulong instr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNRegisterValue BNGetLowLevelILRegisterValueAtInstruction(BNLowLevelILFunction* func, uint reg, ulong instr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetLowLevelILSSAExprIndex(BNLowLevelILFunction* func, ulong expr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetLowLevelILSSAFlagDefinition(BNLowLevelILFunction* func, uint reg, ulong version);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong* BNGetLowLevelILSSAFlagUses(BNLowLevelILFunction* func, uint reg, ulong version, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNRegisterValue BNGetLowLevelILSSAFlagValue(BNLowLevelILFunction* func, uint flag, ulong version);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNLowLevelILFunction* BNGetLowLevelILSSAForm(BNLowLevelILFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetLowLevelILSSAInstructionIndex(BNLowLevelILFunction* func, ulong instr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetLowLevelILSSAMemoryDefinition(BNLowLevelILFunction* func, ulong version);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong* BNGetLowLevelILSSAMemoryUses(BNLowLevelILFunction* func, ulong version, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetLowLevelILSSARegisterDefinition(BNLowLevelILFunction* func, uint reg, ulong version);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong* BNGetLowLevelILSSARegisterUses(BNLowLevelILFunction* func, uint reg, ulong version, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNRegisterValue BNGetLowLevelILSSARegisterValue(BNLowLevelILFunction* func, uint reg, ulong version);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNRegisterValue BNGetLowLevelILStackContentsAfterInstruction(BNLowLevelILFunction* func, long offset, ulong len, ulong instr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNRegisterValue BNGetLowLevelILStackContentsAtInstruction(BNLowLevelILFunction* func, long offset, ulong len, ulong instr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe uint BNGetLowLevelILTemporaryFlagCount(BNLowLevelILFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe uint BNGetLowLevelILTemporaryRegisterCount(BNLowLevelILFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNMediumLevelILFunction* BNGetMappedMediumLevelIL(BNLowLevelILFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetMappedMediumLevelILExprIndex(BNLowLevelILFunction* func, ulong expr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetMappedMediumLevelILInstructionIndex(BNLowLevelILFunction* func, ulong instr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetMaxFunctionSizeForAnalysis(BNBinaryView* view);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNBasicBlock* BNGetMediumLevelILBasicBlockForInstruction(BNMediumLevelILFunction* func, ulong i);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNBasicBlock** BNGetMediumLevelILBasicBlockList(BNMediumLevelILFunction* func, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ILBranchDependence BNGetMediumLevelILBranchDependence(BNMediumLevelILFunction* func, ulong curInstr, ulong branchInstr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNMediumLevelILInstruction BNGetMediumLevelILByIndex(BNMediumLevelILFunction* func, ulong i);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetMediumLevelILExprCount(BNMediumLevelILFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetMediumLevelILExprIndex(BNLowLevelILFunction* func, ulong expr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNGetMediumLevelILExprText(BNMediumLevelILFunction* func, BNArchitecture* arch, ulong i, BNInstructionTextToken** tokens, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNTypeWithConfidence BNGetMediumLevelILExprType(BNMediumLevelILFunction* func, ulong expr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNRegisterValue BNGetMediumLevelILExprValue(BNMediumLevelILFunction* func, ulong expr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNRegisterValue BNGetMediumLevelILFlagValueAfterInstruction(BNMediumLevelILFunction* func, uint flag, ulong instr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNRegisterValue BNGetMediumLevelILFlagValueAtInstruction(BNMediumLevelILFunction* func, uint flag, ulong instr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNMediumLevelILFunction* BNGetMediumLevelILForLowLevelIL(BNLowLevelILFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetMediumLevelILIndexForInstruction(BNMediumLevelILFunction* func, ulong i);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetMediumLevelILInstructionCount(BNMediumLevelILFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetMediumLevelILInstructionForExpr(BNMediumLevelILFunction* func, ulong expr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetMediumLevelILInstructionIndex(BNLowLevelILFunction* func, ulong instr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNGetMediumLevelILInstructionText(BNMediumLevelILFunction* il, BNFunction* func, BNArchitecture* arch, ulong i, BNInstructionTextToken** tokens, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetMediumLevelILNonSSAExprIndex(BNMediumLevelILFunction* func, ulong expr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNMediumLevelILFunction* BNGetMediumLevelILNonSSAForm(BNMediumLevelILFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetMediumLevelILNonSSAInstructionIndex(BNMediumLevelILFunction* func, ulong instr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNFunction* BNGetMediumLevelILOwnerFunction(BNMediumLevelILFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNPossibleValueSet BNGetMediumLevelILPossibleExprValues(BNMediumLevelILFunction* func, ulong expr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNPossibleValueSet BNGetMediumLevelILPossibleFlagValuesAfterInstruction(BNMediumLevelILFunction* func, uint flag, ulong instr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNPossibleValueSet BNGetMediumLevelILPossibleFlagValuesAtInstruction(BNMediumLevelILFunction* func, uint flag, ulong instr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNPossibleValueSet BNGetMediumLevelILPossibleRegisterValuesAfterInstruction(BNMediumLevelILFunction* func, uint reg, ulong instr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNPossibleValueSet BNGetMediumLevelILPossibleRegisterValuesAtInstruction(BNMediumLevelILFunction* func, uint reg, ulong instr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNPossibleValueSet BNGetMediumLevelILPossibleSSAVarValues(BNMediumLevelILFunction* func, BNVariable* var, ulong version, ulong instr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNPossibleValueSet BNGetMediumLevelILPossibleStackContentsAfterInstruction(BNMediumLevelILFunction* func, long offset, ulong len, ulong instr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNPossibleValueSet BNGetMediumLevelILPossibleStackContentsAtInstruction(BNMediumLevelILFunction* func, long offset, ulong len, ulong instr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNRegisterValue BNGetMediumLevelILRegisterValueAfterInstruction(BNMediumLevelILFunction* func, uint reg, ulong instr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNRegisterValue BNGetMediumLevelILRegisterValueAtInstruction(BNMediumLevelILFunction* func, uint reg, ulong instr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetMediumLevelILSSAExprIndex(BNMediumLevelILFunction* func, ulong expr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNMediumLevelILFunction* BNGetMediumLevelILSSAForm(BNMediumLevelILFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetMediumLevelILSSAInstructionIndex(BNMediumLevelILFunction* func, ulong instr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetMediumLevelILSSAMemoryDefinition(BNMediumLevelILFunction* func, ulong version);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong* BNGetMediumLevelILSSAMemoryUses(BNMediumLevelILFunction* func, ulong version, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetMediumLevelILSSAMemoryVersionAtILInstruction(BNMediumLevelILFunction* func, ulong instr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetMediumLevelILSSAVarDefinition(BNMediumLevelILFunction* func, BNVariable* var, ulong version);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong* BNGetMediumLevelILSSAVarUses(BNMediumLevelILFunction* func, BNVariable* var, ulong version, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNRegisterValue BNGetMediumLevelILSSAVarValue(BNMediumLevelILFunction* func, BNVariable* var, ulong version);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetMediumLevelILSSAVarVersionAtILInstruction(BNMediumLevelILFunction* func, BNVariable* var, ulong instr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNRegisterValue BNGetMediumLevelILStackContentsAfterInstruction(BNMediumLevelILFunction* func, long offset, ulong len, ulong instr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNRegisterValue BNGetMediumLevelILStackContentsAtInstruction(BNMediumLevelILFunction* func, long offset, ulong len, ulong instr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong* BNGetMediumLevelILVariableDefinitions(BNMediumLevelILFunction* func, BNVariable* var, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNVariable BNGetMediumLevelILVariableForFlagAtInstruction(BNMediumLevelILFunction* func, uint flag, ulong instr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNVariable BNGetMediumLevelILVariableForRegisterAtInstruction(BNMediumLevelILFunction* func, uint reg, ulong instr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNVariable BNGetMediumLevelILVariableForStackLocationAtInstruction(BNMediumLevelILFunction* func, long offset, ulong instr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong* BNGetMediumLevelILVariableUses(BNMediumLevelILFunction* func, BNVariable* var, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ModificationStatus BNGetModification(BNBinaryView* view, ulong offset);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetModificationArray(BNBinaryView* view, ulong offset, BNModificationStatus* result, ulong len);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe uint* BNGetModifiedArchitectureRegistersOnWrite(BNArchitecture* arch, uint reg, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNNameSpace* BNGetNameSpaces(BNBinaryView* view, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNGetNewAutoFunctionAnalysisSuppressed(BNBinaryView* view);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetNextBasicBlockStartAfterAddress(BNBinaryView* view, ulong addr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetNextDataAfterAddress(BNBinaryView* view, ulong addr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetNextDataVariableAfterAddress(BNBinaryView* view, ulong addr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetNextFunctionStartAfterAddress(BNBinaryView* view, ulong addr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNLinearDisassemblyLine* BNGetNextLinearDisassemblyLines(BNBinaryView* view, BNLinearDisassemblyPosition* pos, BNDisassemblySettings* settings, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetNextValidOffset(BNBinaryView* view, ulong offset);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNGetOpenFileNameInput(char** result, char* prompt, char* ext);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNGetOriginalFilename(BNFileMetadata* file);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNRegisterValue BNGetParameterValueAtInstruction(BNFunction* func, BNArchitecture* arch, ulong addr, BNType* functionType, ulong i);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNRegisterValue BNGetParameterValueAtLowLevelILInstruction(BNFunction* func, ulong instr, BNType* functionType, ulong i);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNVariable BNGetParameterVariableForIncomingVariable(BNCallingConvention* cc, BNVariable* var, BNFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNAnalysisParameters BNGetParametersForAnalysis(BNBinaryView* view);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNBinaryView* BNGetParentView(BNBinaryView* view);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNGetPathRelativeToBundledPluginDirectory(char* path);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNGetPathRelativeToUserDirectory(char* path);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNGetPathRelativeToUserPluginDirectory(char* path);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNArchitecture* BNGetPlatformArchitecture(BNPlatform* platform);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNPlatform* BNGetPlatformByName(char* name);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNCallingConvention** BNGetPlatformCallingConventions(BNPlatform* platform, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNCallingConvention* BNGetPlatformCdeclCallingConvention(BNPlatform* platform);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNCallingConvention* BNGetPlatformDefaultCallingConvention(BNPlatform* platform);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNCallingConvention* BNGetPlatformFastcallCallingConvention(BNPlatform* platform);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNPlatform* BNGetPlatformForViewType(BNBinaryViewType* type, uint id, BNArchitecture* arch);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNType* BNGetPlatformFunctionByName(BNPlatform* platform, _BNQualifiedName* name);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNQualifiedNameAndType* BNGetPlatformFunctions(BNPlatform* platform, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNPlatform** BNGetPlatformList(ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNPlatform** BNGetPlatformListByArchitecture(BNArchitecture* arch, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNPlatform** BNGetPlatformListByOS(char* os, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNPlatform** BNGetPlatformListByOSAndArchitecture(char* os, BNArchitecture* arch, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNGetPlatformName(BNPlatform* platform);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char** BNGetPlatformOSList(ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNCallingConvention* BNGetPlatformStdcallCallingConvention(BNPlatform* platform);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNCallingConvention* BNGetPlatformSystemCallConvention(BNPlatform* platform);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNGetPlatformSystemCallName(BNPlatform* platform, uint number);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNType* BNGetPlatformSystemCallType(BNPlatform* platform, uint number);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNSystemCallInfo* BNGetPlatformSystemCalls(BNPlatform* platform, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNType* BNGetPlatformTypeByName(BNPlatform* platform, _BNQualifiedName* name);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNQualifiedNameAndType* BNGetPlatformTypes(BNPlatform* platform, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNType* BNGetPlatformVariableByName(BNPlatform* platform, _BNQualifiedName* name);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNQualifiedNameAndType* BNGetPlatformVariables(BNPlatform* platform, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetPreviousBasicBlockEndBeforeAddress(BNBinaryView* view, ulong addr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetPreviousBasicBlockStartBeforeAddress(BNBinaryView* view, ulong addr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetPreviousDataBeforeAddress(BNBinaryView* view, ulong addr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetPreviousDataVariableBeforeAddress(BNBinaryView* view, ulong addr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetPreviousFunctionStartBeforeAddress(BNBinaryView* view, ulong addr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNLinearDisassemblyLine* BNGetPreviousLinearDisassemblyLines(BNBinaryView* view, BNLinearDisassemblyPosition* pos, BNDisassemblySettings* settings, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNGetProduct();
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNGetProductType();
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetReaderPosition(BNBinaryReader* stream);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNFunction* BNGetRecentAnalysisFunctionForAddress(BNBinaryView* view, ulong addr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNBasicBlock* BNGetRecentBasicBlockForAddress(BNBinaryView* view, ulong addr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNRegisterValue BNGetRegisterValueAfterInstruction(BNFunction* func, BNArchitecture* arch, ulong addr, uint reg);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNRegisterValue BNGetRegisterValueAtInstruction(BNFunction* func, BNArchitecture* arch, ulong addr, uint reg);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe uint* BNGetRegistersReadByInstruction(BNFunction* func, BNArchitecture* arch, ulong addr, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe uint* BNGetRegistersWrittenByInstruction(BNFunction* func, BNArchitecture* arch, ulong addr, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNPlatform* BNGetRelatedPlatform(BNPlatform* platform, BNArchitecture* arch);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNRange* BNGetRelocationRanges(BNBinaryView* segment, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNRange* BNGetRelocationRangesAtAddress(BNBinaryView* segment, ulong addr, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetReportCollectionCount(BNReportCollection* reports);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNGetReportContents(BNReportCollection* reports, ulong i);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNFlowGraph* BNGetReportFlowGraph(BNReportCollection* reports, ulong i);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNGetReportPlainText(BNReportCollection* reports, ulong i);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNGetReportTitle(BNReportCollection* reports, ulong i);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ReportType BNGetReportType(BNReportCollection* reports, ulong i);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNBinaryView* BNGetReportView(BNReportCollection* reports, ulong i);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNGetRepositoriesDirectory();
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNRepositoryManager* BNGetRepositoryManager();
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNBackgroundTask** BNGetRunningBackgroundTasks(ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNGetSaveFileNameInput(char** result, char* prompt, char* ext, char* defaultName);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ScriptingProviderInputReadyState BNGetScriptingInstanceInputReadyState(BNScriptingInstance* instance);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNScriptingProvider* BNGetScriptingProviderByName(char* name);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNScriptingProvider** BNGetScriptingProviderList(ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNGetScriptingProviderName(BNScriptingProvider* provider);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNSection* BNGetSectionByName(BNBinaryView* view, char* name);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNSection** BNGetSections(BNBinaryView* view, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNSection** BNGetSectionsAt(BNBinaryView* view, ulong addr, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNSegment* BNGetSegmentAt(BNBinaryView* view, ulong addr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNSegment** BNGetSegments(BNBinaryView* view, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNGetSerialNumber();
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNGetSettingsFileName();
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNRegisterValue BNGetStackContentsAfterInstruction(BNFunction* func, BNArchitecture* arch, ulong addr, long offset, ulong size);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNRegisterValue BNGetStackContentsAtInstruction(BNFunction* func, BNArchitecture* arch, ulong addr, long offset, ulong size);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNVariableNameAndType* BNGetStackLayout(BNFunction* func, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNGetStackVariableAtFrameOffset(BNFunction* func, BNArchitecture* arch, ulong addr, long offset, _BNVariableNameAndType* var);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNStackVariableReference* BNGetStackVariablesReferencedByInstruction(BNFunction* func, BNArchitecture* arch, ulong addr, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetStartOffset(BNBinaryView* view);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNStringReference* BNGetStrings(BNBinaryView* view, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNStringReference* BNGetStringsInRange(BNBinaryView* view, ulong start, ulong len, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetStructureAlignment(BNStructure* s);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNStructureMember* BNGetStructureMembers(BNStructure* s, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe StructureType BNGetStructureType(BNStructure* s);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetStructureWidth(BNStructure* s);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetSymbolAddress(BNSymbol* sym);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe SymbolBinding BNGetSymbolBinding(BNSymbol* sym);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNSymbol* BNGetSymbolByAddress(BNBinaryView* view, ulong addr, _BNNameSpace* nameSpace);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNSymbol* BNGetSymbolByRawName(BNBinaryView* view, char* name, _BNNameSpace* nameSpace);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNGetSymbolFullName(BNSymbol* sym);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNNameSpace BNGetSymbolNameSpace(BNSymbol* sym);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNGetSymbolRawName(BNSymbol* sym);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNGetSymbolShortName(BNSymbol* sym);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe SymbolType BNGetSymbolType(BNSymbol* sym);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNSymbol** BNGetSymbols(BNBinaryView* view, ulong* count, _BNNameSpace* nameSpace);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNSymbol** BNGetSymbolsByName(BNBinaryView* view, char* name, ulong* count, _BNNameSpace* nameSpace);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNSymbol** BNGetSymbolsInRange(BNBinaryView* view, ulong start, ulong len, ulong* count, _BNNameSpace* nameSpace);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNSymbol** BNGetSymbolsOfType(BNBinaryView* view, SymbolType type, ulong* count, _BNNameSpace* nameSpace);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNSymbol** BNGetSymbolsOfTypeInRange(BNBinaryView* view, SymbolType type, ulong start, ulong len, ulong* count, _BNNameSpace* nameSpace);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNDataBuffer* BNGetTemporaryFileContents(BNTemporaryFile* file);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNGetTemporaryFilePath(BNTemporaryFile* file);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNGetTextLineInput(char** result, char* prompt, char* title);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetTimeSinceLastUpdateCheck();
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNTransform* BNGetTransformByName(char* name);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNGetTransformGroup(BNTransform* xform);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNGetTransformLongName(BNTransform* xform);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNGetTransformName(BNTransform* xform);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNTransformParameterInfo* BNGetTransformParameterList(BNTransform* xform, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe TransformType BNGetTransformType(BNTransform* xform);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNTransform** BNGetTransformTypeList(ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetTypeAlignment(BNType* type);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNGetTypeAndName(BNType* type, _BNQualifiedName* name);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNCallingConventionWithConfidence BNGetTypeCallingConvention(BNType* type);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe TypeClass BNGetTypeClass(BNType* type);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetTypeElementCount(BNType* type);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNEnumeration* BNGetTypeEnumeration(BNType* type);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNNamedTypeReference* BNGetTypeNamedTypeReference(BNType* type);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetTypeOffset(BNType* type);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNFunctionParameter* BNGetTypeParameters(BNType* type, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe NamedTypeReferenceClass BNGetTypeReferenceClass(BNNamedTypeReference* nt);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNGetTypeReferenceId(BNNamedTypeReference* nt);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNQualifiedName BNGetTypeReferenceName(BNNamedTypeReference* nt);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNOffsetWithConfidence BNGetTypeStackAdjustment(BNType* type);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNGetTypeString(BNType* type, BNPlatform* platform);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNGetTypeStringAfterName(BNType* type, BNPlatform* platform);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNGetTypeStringBeforeName(BNType* type, BNPlatform* platform);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNStructure* BNGetTypeStructure(BNType* type);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNInstructionTextToken* BNGetTypeTokens(BNType* type, BNPlatform* platform, byte baseConfidence, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNInstructionTextToken* BNGetTypeTokensAfterName(BNType* type, BNPlatform* platform, byte baseConfidence, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNInstructionTextToken* BNGetTypeTokensBeforeName(BNType* type, BNPlatform* platform, byte baseConfidence, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetTypeWidth(BNType* type);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNGetUniqueIdentifierString();
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char** BNGetUniqueSectionNames(BNBinaryView* view, char** names, ulong count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNFlowGraph* BNGetUnresolvedStackAdjustmentGraph(BNFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNUpdateVersion* BNGetUpdateChannelVersions(char* channel, ulong* count, char** errors);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNUpdateChannel* BNGetUpdateChannels(ulong* count, char** errors);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNGetUserDirectory();
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNGetUserPluginDirectory();
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNPluginCommand* BNGetValidPluginCommands(BNBinaryView* view, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNPluginCommand* BNGetValidPluginCommandsForAddress(BNBinaryView* view, ulong addr, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNPluginCommand* BNGetValidPluginCommandsForFunction(BNBinaryView* view, BNFunction* func, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNPluginCommand* BNGetValidPluginCommandsForLowLevelILFunction(BNBinaryView* view, BNLowLevelILFunction* func, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNPluginCommand* BNGetValidPluginCommandsForLowLevelILInstruction(BNBinaryView* view, BNLowLevelILFunction* func, ulong instr, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNPluginCommand* BNGetValidPluginCommandsForMediumLevelILFunction(BNBinaryView* view, BNMediumLevelILFunction* func, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNPluginCommand* BNGetValidPluginCommandsForMediumLevelILInstruction(BNBinaryView* view, BNMediumLevelILFunction* func, ulong instr, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNPluginCommand* BNGetValidPluginCommandsForRange(BNBinaryView* view, ulong addr, ulong len, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNGetVariableName(BNFunction* func, BNVariable* var);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNTypeWithConfidence BNGetVariableType(BNFunction* func, BNVariable* var);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNGetVersionString();
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe int BNGetVerticalFlowGraphNodeMargin(BNFlowGraph* graph);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetViewAddressSize(BNBinaryView* view);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetViewLength(BNBinaryView* view);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNGetViewType(BNBinaryView* view);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetWorkerThreadCount();
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNGetWriterPosition(BNBinaryWriter* stream);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNHasFunctions(BNBinaryView* view);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNSymbol* BNImportedFunctionFromImportAddressSymbol(BNSymbol* sym, ulong addr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNInitCorePlugins();
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNDownloadInstance* BNInitDownloadInstance(BNDownloadProvider* provider, _BNDownloadInstanceCallbacks* callbacks);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNInitRepoPlugins();
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNScriptingInstance* BNInitScriptingInstance(BNScriptingProvider* provider, _BNScriptingInstanceCallbacks* callbacks);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNInitUserPlugins();
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNInsertViewBuffer(BNBinaryView* view, ulong offset, BNDataBuffer* data);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNInsertViewData(BNBinaryView* view, ulong offset, void* data, ulong len);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNInstallPendingUpdate(char** errors);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNInvertBranch(BNBinaryView* view, BNArchitecture* arch, ulong addr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNIsAlwaysBranchPatchAvailable(BNBinaryView* view, BNArchitecture* arch, ulong addr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNIsAnalysisChanged(BNFileMetadata* file);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNIsAnalysisTypeAutoDefined(BNBinaryView* view, _BNQualifiedName* name);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNIsArchitectureAlwaysBranchPatchAvailable(BNArchitecture* arch, byte* data, ulong addr, ulong len);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNIsArchitectureGlobalRegister(BNArchitecture* arch, uint reg);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNIsArchitectureInvertBranchPatchAvailable(BNArchitecture* arch, byte* data, ulong addr, ulong len);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNIsArchitectureNeverBranchPatchAvailable(BNArchitecture* arch, byte* data, ulong addr, ulong len);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNIsArchitectureSkipAndReturnValuePatchAvailable(BNArchitecture* arch, byte* data, ulong addr, ulong len);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNIsArchitectureSkipAndReturnZeroPatchAvailable(BNArchitecture* arch, byte* data, ulong addr, ulong len);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNIsBackedByDatabase(BNFileMetadata* file);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNIsBackgroundTaskCancelled(BNBackgroundTask* task);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNIsBackgroundTaskFinished(BNBackgroundTask* task);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNIsBinaryViewTypeArchitectureConstantDefined(BNArchitecture* arch, char* type, char* name);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNIsBinaryViewTypeValidForData(BNBinaryViewType* type, BNBinaryView* data);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNIsCallInstruction(BNFunction* func, BNArchitecture* arch, ulong addr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNIsDisassemblySettingsOptionSet(BNDisassemblySettings* settings, DisassemblyOption option);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNIsEndOfFile(BNBinaryReader* stream);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNIsExecutableView(BNBinaryView* view);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNIsFileModified(BNFileMetadata* file);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNIsFlowGraphLayoutComplete(BNFlowGraph* graph);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNIsFlowGraphLayoutRequestComplete(BNFlowGraphLayoutRequest* layout);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNIsFunctionAnalysisSkipped(BNFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNIsFunctionTooLarge(BNFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNIsFunctionUpdateNeeded(BNFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNIsILBasicBlock(BNBasicBlock* block);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNIsILFlowGraph(BNFlowGraph* graph);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNIsInvertBranchPatchAvailable(BNBinaryView* view, BNArchitecture* arch, ulong addr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNIsLicenseValidated();
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNIsLowLevelILBasicBlock(BNBasicBlock* block);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNIsLowLevelILFlowGraph(BNFlowGraph* graph);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNIsMainThreadActionDone(BNMainThreadAction* action);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNIsMediumLevelILBasicBlock(BNBasicBlock* block);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNIsMediumLevelILFlowGraph(BNFlowGraph* graph);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNIsMediumLevelILSSAVarLive(BNMediumLevelILFunction* func, BNVariable* var, ulong version);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNIsNeverBranchPatchAvailable(BNBinaryView* view, BNArchitecture* arch, ulong addr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNIsOffsetBackedByFile(BNBinaryView* view, ulong offset);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNIsOffsetCodeSemantics(BNBinaryView* view, ulong offset);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNIsOffsetExecutable(BNBinaryView* view, ulong offset);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNIsOffsetExternSemantics(BNBinaryView* view, ulong offset);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNIsOffsetReadable(BNBinaryView* view, ulong offset);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNIsOffsetWritable(BNBinaryView* view, ulong offset);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNIsOffsetWritableSemantics(BNBinaryView* view, ulong offset);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNIsPathDirectory(char* path);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNIsPathRegularFile(char* path);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNIsRelocatable(BNBinaryView* view);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNIsSkipAndReturnValuePatchAvailable(BNBinaryView* view, BNArchitecture* arch, ulong addr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNIsSkipAndReturnZeroPatchAvailable(BNBinaryView* view, BNArchitecture* arch, ulong addr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNIsStackAdjustedOnReturn(BNCallingConvention* cc);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNIsStackReservedForArgumentRegisters(BNCallingConvention* cc);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNIsStructurePacked(BNStructure* s);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNIsStructureUnion(BNStructure* s);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNIsSymbolAutoDefined(BNSymbol* sym);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNBoolWithConfidence BNIsTypeConst(BNType* type);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNIsTypeFloatingPoint(BNType* type);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNBoolWithConfidence BNIsTypeSigned(BNType* type);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNBoolWithConfidence BNIsTypeVolatile(BNType* type);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNIsUIEnabled();
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNIsUpdateInstallationPending();
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNIsValidForData(void* ctxt, BNBinaryView* view, ulong addr, BNType* type, BNType** typeCtx, ulong ctxCount);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNIsValidOffset(BNBinaryView* view, ulong offset);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNIsViewModified(BNBinaryView* view);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe int BNLlvmServicesAssemble(char* src, int dialect, char* triplet, int codeModel, int relocMode, char** outBytes, int* outBytesLen, char** err, int* errLen);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNLlvmServicesAssembleFree(char* outBytes, char* err);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNLlvmServicesInit();
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNLoadPluginForApi(char* pluginApiName, char* repoPath, char* pluginPath);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNLog(LogLevel level, char* fmt);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNLogAlert(char* fmt);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNLogDebug(char* fmt);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNLogError(char* fmt);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNLogInfo(char* fmt);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNLogToFile(LogLevel minimumLevel, char* path, bool append);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNLogToStderr(LogLevel minimumLevel);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNLogToStdout(LogLevel minimumLevel);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNLogWarn(char* fmt);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNLowLevelILAddExpr(BNLowLevelILFunction* func, LowLevelILOperation operation, ulong size, uint flags, ulong a, ulong b, ulong c, ulong d);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNLowLevelILAddExprWithLocation(BNLowLevelILFunction* func, ulong addr, uint sourceOperand, LowLevelILOperation operation, ulong size, uint flags, ulong a, ulong b, ulong c, ulong d);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNLowLevelILAddInstruction(BNLowLevelILFunction* func, ulong expr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNLowLevelILAddLabelList(BNLowLevelILFunction* func, BNLowLevelILLabel** labels, ulong count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNLowLevelILAddOperandList(BNLowLevelILFunction* func, ulong* operands, ulong count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNLowLevelILClearIndirectBranches(BNLowLevelILFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNLowLevelILFreeOperandList(ulong* operands);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNLowLevelILGetCurrentAddress(BNLowLevelILFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNLowLevelILGetInstructionStart(BNLowLevelILFunction* func, BNArchitecture* arch, ulong addr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong* BNLowLevelILGetOperandList(BNLowLevelILFunction* func, ulong expr, ulong operand, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNLowLevelILGoto(BNLowLevelILFunction* func, BNLowLevelILLabel* label);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNLowLevelILGotoWithLocation(BNLowLevelILFunction* func, BNLowLevelILLabel* label, ulong addr, uint sourceOperand);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNLowLevelILIf(BNLowLevelILFunction* func, ulong op, BNLowLevelILLabel* t, BNLowLevelILLabel* f);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNLowLevelILIfWithLocation(BNLowLevelILFunction* func, ulong op, BNLowLevelILLabel* t, BNLowLevelILLabel* f, ulong addr, uint sourceOperand);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNLowLevelILInitLabel(BNLowLevelILLabel* label);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNLowLevelILMarkLabel(BNLowLevelILFunction* func, BNLowLevelILLabel* label);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNLowLevelILSetCurrentAddress(BNLowLevelILFunction* func, BNArchitecture* arch, ulong addr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNLowLevelILSetExprSourceOperand(BNLowLevelILFunction* func, ulong expr, uint operand);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNLowLevelILSetIndirectBranches(BNLowLevelILFunction* func, BNArchitectureAndAddress* branches, ulong count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNMarkBasicBlockAsRecentlyUsed(BNBasicBlock* block);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNMarkFileModified(BNFileMetadata* file);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNMarkFileSaved(BNFileMetadata* file);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNMarkFunctionAsRecentlyUsed(BNFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNMarkMediumLevelILInstructionForRemoval(BNMediumLevelILFunction* func, ulong instr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNMarkdownToHTML(char* contents);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNMediumLevelILAddExpr(BNMediumLevelILFunction* func, MediumLevelILOperation operation, ulong size, ulong a, ulong b, ulong c, ulong d, ulong e);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNMediumLevelILAddExprWithLocation(BNMediumLevelILFunction* func, MediumLevelILOperation operation, ulong addr, uint sourceOperand, ulong size, ulong a, ulong b, ulong c, ulong d, ulong e);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNMediumLevelILAddInstruction(BNMediumLevelILFunction* func, ulong expr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNMediumLevelILAddLabelList(BNMediumLevelILFunction* func, BNMediumLevelILLabel** labels, ulong count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNMediumLevelILAddOperandList(BNMediumLevelILFunction* func, ulong* operands, ulong count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNMediumLevelILFreeOperandList(ulong* operands);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNMediumLevelILGetCurrentAddress(BNMediumLevelILFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNMediumLevelILGetInstructionStart(BNMediumLevelILFunction* func, BNArchitecture* arch, ulong addr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong* BNMediumLevelILGetOperandList(BNMediumLevelILFunction* func, ulong expr, ulong operand, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNMediumLevelILGoto(BNMediumLevelILFunction* func, BNMediumLevelILLabel* label);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNMediumLevelILGotoWithLocation(BNMediumLevelILFunction* func, BNMediumLevelILLabel* label, ulong addr, uint sourceOperand);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNMediumLevelILIf(BNMediumLevelILFunction* func, ulong op, BNMediumLevelILLabel* t, BNMediumLevelILLabel* f);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNMediumLevelILIfWithLocation(BNMediumLevelILFunction* func, ulong op, BNMediumLevelILLabel* t, BNMediumLevelILLabel* f, ulong addr, uint sourceOperand);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNMediumLevelILInitLabel(BNMediumLevelILLabel* label);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNMediumLevelILMarkLabel(BNMediumLevelILFunction* func, BNMediumLevelILLabel* label);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNMediumLevelILSetCurrentAddress(BNMediumLevelILFunction* func, BNArchitecture* arch, ulong addr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNMetadataArrayAppend(BNMetadata* data, BNMetadata* md);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNMetadata** BNMetadataGetArray(BNMetadata* data, ulong* size);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNMetadataGetBoolean(BNMetadata* data);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe double BNMetadataGetDouble(BNMetadata* data);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNMetadata* BNMetadataGetForIndex(BNMetadata* data, ulong index);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNMetadata* BNMetadataGetForKey(BNMetadata* data, char* key);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe byte* BNMetadataGetRaw(BNMetadata* data, ulong* size);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe long BNMetadataGetSignedInteger(BNMetadata* data);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNMetadataGetString(BNMetadata* data);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe MetadataType BNMetadataGetType(BNMetadata* data);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNMetadataGetUnsignedInteger(BNMetadata* data);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNMetadataValueStore* BNMetadataGetValueStore(BNMetadata* data);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNMetadataIsArray(BNMetadata* data);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNMetadataIsBoolean(BNMetadata* data);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNMetadataIsDouble(BNMetadata* data);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNMetadataIsEqual(BNMetadata* lhs, BNMetadata* rhs);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNMetadataIsKeyValueStore(BNMetadata* data);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNMetadataIsRaw(BNMetadata* data);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNMetadataIsSignedInteger(BNMetadata* data);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNMetadataIsString(BNMetadata* data);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNMetadataIsUnsignedInteger(BNMetadata* data);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNMetadataRemoveIndex(BNMetadata* data, ulong index);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNMetadataRemoveKey(BNMetadata* data, char* key);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNMetadataSetValueForKey(BNMetadata* data, char* key, BNMetadata* md);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNMetadataSize(BNMetadata* data);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNNavigate(BNFileMetadata* file, char* view, ulong offset);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNAnalysisCompletionEvent* BNNewAnalysisCompletionEventReference(BNAnalysisCompletionEvent* _event);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNBackgroundTask* BNNewBackgroundTaskReference(BNBackgroundTask* task);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNBasicBlock* BNNewBasicBlockReference(BNBasicBlock* block);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNCallingConvention* BNNewCallingConventionReference(BNCallingConvention* cc);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNDataRenderer* BNNewDataRendererReference(BNDataRenderer* renderer);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNDisassemblySettings* BNNewDisassemblySettingsReference(BNDisassemblySettings* settings);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNDownloadInstance* BNNewDownloadInstanceReference(BNDownloadInstance* instance);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNEnumeration* BNNewEnumerationReference(BNEnumeration* e);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNFileMetadata* BNNewFileReference(BNFileMetadata* file);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNFlowGraphLayoutRequest* BNNewFlowGraphLayoutRequestReference(BNFlowGraphLayoutRequest* layout);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNFlowGraphNode* BNNewFlowGraphNodeReference(BNFlowGraphNode* node);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNFlowGraph* BNNewFlowGraphReference(BNFlowGraph* graph);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNFunction* BNNewFunctionReference(BNFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNLowLevelILFunction* BNNewLowLevelILFunctionReference(BNLowLevelILFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNMainThreadAction* BNNewMainThreadActionReference(BNMainThreadAction* action);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNMediumLevelILFunction* BNNewMediumLevelILFunctionReference(BNMediumLevelILFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNMetadata* BNNewMetadataReference(BNMetadata* data);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNNamedTypeReference* BNNewNamedTypeReference(BNNamedTypeReference* nt);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNPlatform* BNNewPlatformReference(BNPlatform* platform);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNRepoPlugin* BNNewPluginReference(BNRepoPlugin* r);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNRelocationHandler* BNNewRelocationHandlerReference(BNRelocationHandler* handler);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNRelocation* BNNewRelocationReference(BNRelocation* reloc);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNReportCollection* BNNewReportCollectionReference(BNReportCollection* reports);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNRepositoryManager* BNNewRepositoryManagerReference(BNRepositoryManager* r);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNRepository* BNNewRepositoryReference(BNRepository* r);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNScriptingInstance* BNNewScriptingInstanceReference(BNScriptingInstance* instance);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNSection* BNNewSectionReference(BNSection* section);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNSegment* BNNewSegmentReference(BNSegment* seg);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNStructure* BNNewStructureReference(BNStructure* s);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNSymbol* BNNewSymbolReference(BNSymbol* sym);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNTemporaryFile* BNNewTemporaryFileReference(BNTemporaryFile* file);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNType* BNNewTypeReference(BNType* type);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNBinaryView* BNNewViewReference(BNBinaryView* view);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNNotifyDataInserted(BNBinaryView* view, ulong offset, ulong len);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNNotifyDataRemoved(BNBinaryView* view, ulong offset, ulong len);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNNotifyDataWritten(BNBinaryView* view, ulong offset, ulong len);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNNotifyErrorForScriptingInstance(BNScriptingInstance* instance, char* text);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNNotifyInputReadyStateForScriptingInstance(BNScriptingInstance* instance, ScriptingProviderInputReadyState state);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNNotifyOutputForScriptingInstance(BNScriptingInstance* instance, char* text);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNNotifyProgressForDownloadInstance(BNDownloadInstance* instance, ulong progress, ulong total);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNBinaryView* BNOpenExistingDatabase(BNFileMetadata* file, char* path);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNBinaryView* BNOpenExistingDatabaseWithProgress(BNFileMetadata* file, char* path, void* ctxt, [MarshalAs(UnmanagedType.FunctionPtr)] progressDelegate progress);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNParseExpression(BNBinaryView* view, char* expression, ulong* offset, ulong here, char** errorString);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNParseTypeString(BNBinaryView* view, char* text, BNQualifiedNameAndType* result, char** errors);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNParseTypesFromSource(BNPlatform* platform, char* source, char* fileName, BNTypeParserResult* result, char** errors, char** includeDirs, ulong includeDirCount, char* autoTypeSource);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNParseTypesFromSourceFile(BNPlatform* platform, char* fileName, BNTypeParserResult* result, char** errors, char** includeDirs, ulong includeDirCount, char* autoTypeSource);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNParseTypesString(BNBinaryView* view, char* text, BNQualifiedNameAndType** result, ulong* count, char** errors);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNPathExists(char* path);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe int BNPerformDownloadRequest(BNDownloadInstance* instance, char* url, _BNDownloadInstanceOutputCallbacks* callbacks);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNPluginDisable(BNRepoPlugin* p);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNPluginEnable(BNRepoPlugin* p);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNPluginGetApi(BNRepoPlugin* p);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNPluginGetAuthor(BNRepoPlugin* p);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNPluginGetDescription(BNRepoPlugin* p);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNPluginGetLicense(BNRepoPlugin* p);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNPluginGetLicenseText(BNRepoPlugin* p);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNPluginGetLongdescription(BNRepoPlugin* p);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNPluginGetMinimimVersions(BNRepoPlugin* p);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNPluginGetName(BNRepoPlugin* p);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNPluginGetPath(BNRepoPlugin* p);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNPluginType* BNPluginGetPluginTypes(BNRepoPlugin* p, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe PluginUpdateStatus BNPluginGetPluginUpdateStatus(BNRepoPlugin* p);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNPluginGetUrl(BNRepoPlugin* p);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNPluginGetVersion(BNRepoPlugin* p);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNPluginInstall(BNRepoPlugin* p);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNPluginIsEnabled(BNRepoPlugin* p);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNPluginIsInstalled(BNRepoPlugin* p);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNPluginSetEnabled(BNRepoPlugin* p, bool enabled);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNPluginUninstall(BNRepoPlugin* p);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNPrepareToCopyLowLevelILBasicBlock(BNLowLevelILFunction* func, BNBasicBlock* block);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNPrepareToCopyLowLevelILFunction(BNLowLevelILFunction* func, BNLowLevelILFunction* src);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNPrepareToCopyMediumLevelILBasicBlock(BNMediumLevelILFunction* func, BNBasicBlock* block);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNPrepareToCopyMediumLevelILFunction(BNMediumLevelILFunction* func, BNMediumLevelILFunction* src);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNPreprocessSource(char* source, char* fileName, char** output, char** errors, char** includeDirs, ulong includeDirCount);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNRead16(BNBinaryReader* stream, ushort* result);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNRead32(BNBinaryReader* stream, uint* result);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNRead64(BNBinaryReader* stream, ulong* result);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNRead8(BNBinaryReader* stream, byte* result);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNReadBE16(BNBinaryReader* stream, ushort* result);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNReadBE32(BNBinaryReader* stream, uint* result);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNReadBE64(BNBinaryReader* stream, ulong* result);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNReadData(BNBinaryReader* stream, void* dest, ulong len);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNReadLE16(BNBinaryReader* stream, ushort* result);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNReadLE32(BNBinaryReader* stream, uint* result);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNReadLE64(BNBinaryReader* stream, ulong* result);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNDataBuffer* BNReadViewBuffer(BNBinaryView* view, ulong offset, ulong len);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNReadViewData(BNBinaryView* view, void* dest, ulong offset, ulong len);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNReanalyzeAllFunctions(BNBinaryView* view);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNReanalyzeFunction(BNFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNRedo(BNFileMetadata* file);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNArchitecture* BNRegisterArchitecture(char* name, _BNCustomArchitecture* arch);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNArchitecture* BNRegisterArchitectureExtension(char* name, BNArchitecture* _base, _BNCustomArchitecture* arch);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNRegisterArchitectureForViewType(BNBinaryViewType* type, uint id, Endianness endian, BNArchitecture* arch);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNRegisterArchitectureFunctionRecognizer(BNArchitecture* arch, _BNFunctionRecognizer* rec);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNArchitecture* BNRegisterArchitectureHook(BNArchitecture* _base, _BNCustomArchitecture* arch);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNBinaryViewType* BNRegisterBinaryViewType(char* name, char* longName, _BNCustomBinaryViewType* type);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNRegisterCallingConvention(BNArchitecture* arch, BNCallingConvention* cc);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNRegisterDataNotification(BNBinaryView* view, _BNBinaryDataNotification* notify);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNRegisterDefaultPlatformForViewType(BNBinaryViewType* type, BNArchitecture* arch, BNPlatform* platform);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNDownloadProvider* BNRegisterDownloadProvider(char* name, _BNDownloadProviderCallbacks* callbacks);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNRegisterForPluginLoading(char* pluginApiName, [MarshalAs(UnmanagedType.FunctionPtr)] cbDelegate cb, void* ctx);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNRegisterGenericDataRenderer(BNDataRendererContainer* container, BNDataRenderer* renderer);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNRegisterGlobalFunctionRecognizer(_BNFunctionRecognizer* rec);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNRegisterInteractionHandler(_BNInteractionHandlerCallbacks* callbacks);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNRegisterLogListener(_BNLogListener* listener);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNRegisterMainThread(_BNMainThreadCallbacks* callbacks);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNRegisterObjectDestructionCallbacks(_BNObjectDestructionCallbacks* callbacks);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNRegisterPlatform(char* os, BNPlatform* platform);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNRegisterPlatformCallingConvention(BNPlatform* platform, BNCallingConvention* cc);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNRegisterPlatformCdeclCallingConvention(BNPlatform* platform, BNCallingConvention* cc);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNRegisterPlatformDefaultCallingConvention(BNPlatform* platform, BNCallingConvention* cc);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNRegisterPlatformFastcallCallingConvention(BNPlatform* platform, BNCallingConvention* cc);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNRegisterPlatformForViewType(BNBinaryViewType* type, uint id, BNArchitecture* arch, BNPlatform* platform);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNRegisterPlatformStdcallCallingConvention(BNPlatform* platform, BNCallingConvention* cc);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNRegisterPlatformTypes(BNBinaryView* view, BNPlatform* platform);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNRegisterPluginCommand(char* name, char* description, [MarshalAs(UnmanagedType.FunctionPtr)] actionDelegate action, [MarshalAs(UnmanagedType.FunctionPtr)] isValidDelegate isValid, void* context);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNRegisterPluginCommandForAddress(char* name, char* description, [MarshalAs(UnmanagedType.FunctionPtr)] actionDelegate action, [MarshalAs(UnmanagedType.FunctionPtr)] isValidDelegate isValid, void* context);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNRegisterPluginCommandForFunction(char* name, char* description, [MarshalAs(UnmanagedType.FunctionPtr)] actionDelegate action, [MarshalAs(UnmanagedType.FunctionPtr)] isValidDelegate isValid, void* context);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNRegisterPluginCommandForLowLevelILFunction(char* name, char* description, [MarshalAs(UnmanagedType.FunctionPtr)] actionDelegate action, [MarshalAs(UnmanagedType.FunctionPtr)] isValidDelegate isValid, void* context);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNRegisterPluginCommandForLowLevelILInstruction(char* name, char* description, [MarshalAs(UnmanagedType.FunctionPtr)] actionDelegate action, [MarshalAs(UnmanagedType.FunctionPtr)] isValidDelegate isValid, void* context);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNRegisterPluginCommandForMediumLevelILFunction(char* name, char* description, [MarshalAs(UnmanagedType.FunctionPtr)] actionDelegate action, [MarshalAs(UnmanagedType.FunctionPtr)] isValidDelegate isValid, void* context);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNRegisterPluginCommandForMediumLevelILInstruction(char* name, char* description, [MarshalAs(UnmanagedType.FunctionPtr)] actionDelegate action, [MarshalAs(UnmanagedType.FunctionPtr)] isValidDelegate isValid, void* context);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNRegisterPluginCommandForRange(char* name, char* description, [MarshalAs(UnmanagedType.FunctionPtr)] actionDelegate action, [MarshalAs(UnmanagedType.FunctionPtr)] isValidDelegate isValid, void* context);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNRegisterScriptingInstanceOutputListener(BNScriptingInstance* instance, _BNScriptingOutputListener* callbacks);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNScriptingProvider* BNRegisterScriptingProvider(char* name, _BNScriptingProviderCallbacks* callbacks);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNTransform* BNRegisterTransformType(TransformType type, char* name, char* longName, char* group, _BNCustomTransform* xform);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNRegisterTypeSpecificDataRenderer(BNDataRendererContainer* container, BNDataRenderer* renderer);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNRegisterUndoActionType(char* name, void* typeContext, [MarshalAs(UnmanagedType.FunctionPtr)] deserializeDelegate deserialize);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNReleaseAdvancedFunctionAnalysisData(BNFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNReleaseAdvancedFunctionAnalysisDataMultiple(BNFunction* func, ulong count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNArchitecture* BNRelocationGetArchitecture(BNRelocation* reloc);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNRelocationInfo BNRelocationGetInfo(BNRelocation* reloc);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNRelocationGetReloc(BNRelocation* reloc);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNSymbol* BNRelocationGetSymbol(BNRelocation* reloc);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNRelocationGetTarget(BNRelocation* reloc);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNRelocationHandlerApplyRelocation(BNRelocationHandler* handler, BNBinaryView* view, BNArchitecture* arch, BNRelocation* reloc, byte* dest, ulong len);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNRelocationHandlerDefaultApplyRelocation(BNRelocationHandler* handler, BNBinaryView* view, BNArchitecture* arch, BNRelocation* reloc, byte* dest, ulong len);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNRelocationHandlerGetOperandForExternalRelocation(BNRelocationHandler* handler, byte* data, ulong addr, ulong length, BNLowLevelILFunction* il, BNRelocation* relocation);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNRelocationHandlerGetRelocationInfo(BNRelocationHandler* handler, BNBinaryView* data, BNArchitecture* arch, BNRelocationInfo* info, ulong infoCount);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNRemoveAnalysisFunction(BNBinaryView* view, BNFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNRemoveAutoSection(BNBinaryView* view, char* name);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNRemoveAutoSegment(BNBinaryView* view, ulong start, ulong length);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNRemoveEnumerationMember(BNEnumeration* e, ulong idx);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNRemoveStructureMember(BNStructure* s, ulong idx);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNRemoveUserFunction(BNBinaryView* view, BNFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNRemoveUserSection(BNBinaryView* view, char* name);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNRemoveUserSegment(BNBinaryView* view, ulong start, ulong length);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNRemoveViewData(BNBinaryView* view, ulong offset, ulong len);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNRenameAnalysisType(BNBinaryView* view, _BNQualifiedName* oldName, _BNQualifiedName* newName);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNReplaceEnumerationMember(BNEnumeration* e, ulong idx, char* name, ulong value);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNReplaceLowLevelILExpr(BNLowLevelILFunction* func, ulong expr, ulong newExpr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNReplaceMediumLevelILExpr(BNMediumLevelILFunction* func, ulong expr, ulong newExpr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNReplaceMediumLevelILInstruction(BNMediumLevelILFunction* func, ulong instr, ulong expr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNReplaceStructureMember(BNStructure* s, ulong idx, BNTypeWithConfidence* type, char* name);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNRepositoryFreePluginDirectoryList(char** list, ulong count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNRepositoryGetLocalReference(BNRepository* r);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNRepoPlugin* BNRepositoryGetPluginByPath(BNRepository* r, char* pluginPath);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNRepoPlugin** BNRepositoryGetPlugins(BNRepository* r, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNRepositoryGetPluginsPath(BNRepository* r);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNRepositoryGetRemoteReference(BNRepository* r);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNRepositoryGetRepoPath(BNRepository* r);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNRepository* BNRepositoryGetRepositoryByPath(BNRepositoryManager* r, char* repoPath);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNRepositoryGetUrl(BNRepository* r);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNRepositoryIsInitialized(BNRepository* r);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNRepositoryManagerAddRepository(BNRepositoryManager* r, char* url, char* repoPath, char* localReference, char* remoteReference);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNRepositoryManagerCheckForUpdates(BNRepositoryManager* r);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNRepositoryManagerDisablePlugin(BNRepositoryManager* r, char* repoName, char* pluginPath);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNRepositoryManagerEnablePlugin(BNRepositoryManager* r, char* repoName, char* pluginPath);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNRepository* BNRepositoryManagerGetDefaultRepository(BNRepositoryManager* r);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNRepository** BNRepositoryManagerGetRepositories(BNRepositoryManager* r, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNRepositoryManagerInstallPlugin(BNRepositoryManager* r, char* repoName, char* pluginPath);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNRepositoryManagerUninstallPlugin(BNRepositoryManager* r, char* repoName, char* pluginPath);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNRepositoryManagerUpdatePlugin(BNRepositoryManager* r, char* repoName, char* pluginPath);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNRequestAdvancedFunctionAnalysisData(BNFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNRequestFunctionDebugReport(BNFunction* func, char* name);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNSaveAutoSnapshot(BNBinaryView* data);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNSaveAutoSnapshotWithProgress(BNBinaryView* data, void* ctxt, [MarshalAs(UnmanagedType.FunctionPtr)] progressDelegate progress);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSaveLastRun();
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNSaveToFile(BNBinaryView* view, _BNFileAccessor* file);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNSaveToFilename(BNBinaryView* view, char* filename);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNSectionGetAlign(BNSection* section);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNSectionGetEnd(BNSection* section);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNSectionGetEntrySize(BNSection* section);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNSectionGetInfoData(BNSection* section);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNSectionGetInfoSection(BNSection* section);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNSectionGetLength(BNSection* section);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNSectionGetLinkedSection(BNSection* section);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNSectionGetName(BNSection* section);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe SectionSemantics BNSectionGetSemantics(BNSection* section);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNSectionGetStart(BNSection* section);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNSectionGetType(BNSection* section);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNSectionIsAutoDefined(BNSection* section);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSeekBinaryReader(BNBinaryReader* stream, ulong offset);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSeekBinaryReaderRelative(BNBinaryReader* stream, long offset);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSeekBinaryWriter(BNBinaryWriter* stream, ulong offset);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSeekBinaryWriterRelative(BNBinaryWriter* stream, long offset);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNSegmentGetDataEnd(BNSegment* segment);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNSegmentGetDataLength(BNSegment* segment);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNSegmentGetDataOffset(BNSegment* segment);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNSegmentGetEnd(BNSegment* segment);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe uint BNSegmentGetFlags(BNSegment* segment);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNSegmentGetLength(BNSegment* segment);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNRange* BNSegmentGetRelocationRanges(BNSegment* segment, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNRange* BNSegmentGetRelocationRangesAtAddress(BNSegment* segment, ulong addr, ulong* count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNSegmentGetRelocationsCount(BNSegment* segment);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNSegmentGetStart(BNSegment* segment);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNSegmentIsAutoDefined(BNSegment* segment);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSegmentSetDataLength(BNSegment* segment, ulong dataLength);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSegmentSetDataOffset(BNSegment* segment, ulong dataOffset);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSegmentSetFlags(BNSegment* segment, uint flags);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSegmentSetLength(BNSegment* segment, ulong length);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNSerializeSettings(char* registry, BNBinaryView* view, SettingsScope scope);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetActiveUpdateChannel(char* channel);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetArchitectureCdeclCallingConvention(BNArchitecture* arch, BNCallingConvention* cc);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetArchitectureDefaultCallingConvention(BNArchitecture* arch, BNCallingConvention* cc);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetArchitectureFastcallCallingConvention(BNArchitecture* arch, BNCallingConvention* cc);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetArchitectureStdcallCallingConvention(BNArchitecture* arch, BNCallingConvention* cc);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetAutoBasicBlockHighlight(BNBasicBlock* block, BNHighlightColor color);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetAutoCallRegisterStackAdjustment(BNFunction* func, BNArchitecture* arch, ulong addr, BNRegisterStackAdjustment* adjust, ulong count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetAutoCallRegisterStackAdjustmentForRegisterStack(BNFunction* func, BNArchitecture* arch, ulong addr, uint regStack, int adjust, byte confidence);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetAutoCallStackAdjustment(BNFunction* func, BNArchitecture* arch, ulong addr, long adjust, byte confidence);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetAutoFunctionCallingConvention(BNFunction* func, BNCallingConventionWithConfidence* convention);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetAutoFunctionCanReturn(BNFunction* func, BNBoolWithConfidence* returns);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetAutoFunctionClobberedRegisters(BNFunction* func, BNRegisterSetWithConfidence* regs);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetAutoFunctionHasVariableArguments(BNFunction* func, BNBoolWithConfidence* varArgs);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetAutoFunctionParameterVariables(BNFunction* func, BNParameterVariablesWithConfidence* vars);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetAutoFunctionRegisterStackAdjustments(BNFunction* func, BNRegisterStackAdjustment* adjustments, ulong count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetAutoFunctionReturnRegisters(BNFunction* func, BNRegisterSetWithConfidence* regs);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetAutoFunctionReturnType(BNFunction* func, BNTypeWithConfidence* type);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetAutoFunctionStackAdjustment(BNFunction* func, BNOffsetWithConfidence* stackAdjust);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetAutoIndirectBranches(BNFunction* func, BNArchitecture* sourceArch, ulong source, BNArchitectureAndAddress* branches, ulong count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetAutoInstructionHighlight(BNFunction* func, BNArchitecture* arch, ulong addr, BNHighlightColor color);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetAutoUpdatesEnabled(bool enabled);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetBackgroundTaskProgressText(BNBackgroundTask* task, char* text);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetBinaryReaderEndianness(BNBinaryReader* stream, Endianness endian);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetBinaryViewTypeArchitectureConstant(BNArchitecture* arch, char* type, char* name, ulong value);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetBinaryWriterEndianness(BNBinaryWriter* stream, Endianness endian);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetBundledPluginDirectory(char* path);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetCommentForAddress(BNFunction* func, ulong addr, char* comment);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetCurrentPluginLoadOrder(PluginLoadOrder order);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetDataBufferByte(BNDataBuffer* buf, ulong offset, byte val);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetDataBufferContents(BNDataBuffer* buf, void* data, ulong len);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetDataBufferLength(BNDataBuffer* buf, ulong len);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetDefaultArchitecture(BNBinaryView* view, BNArchitecture* arch);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetDefaultPlatform(BNBinaryView* view, BNPlatform* platform);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetDisassemblyMaximumSymbolWidth(BNDisassemblySettings* settings, ulong width);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetDisassemblySettingsOption(BNDisassemblySettings* settings, DisassemblyOption option, bool state);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetDisassemblyWidth(BNDisassemblySettings* settings, ulong width);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetErrorForDownloadInstance(BNDownloadInstance* instance, char* error);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetFileMetadataNavigationHandler(BNFileMetadata* file, _BNNavigationHandler* handler);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetFilename(BNFileMetadata* file, char* name);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetFlowGraphBasicBlock(BNFlowGraphNode* node, BNBasicBlock* block);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetFlowGraphLowLevelILFunction(BNFlowGraph* graph, BNLowLevelILFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetFlowGraphMediumLevelILFunction(BNFlowGraph* graph, BNMediumLevelILFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetFlowGraphNodeHighlight(BNFlowGraphNode* node, BNHighlightColor color);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetFlowGraphNodeLines(BNFlowGraphNode* node, BNDisassemblyTextLine* lines, ulong count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetFlowGraphNodeMargins(BNFlowGraph* graph, int horiz, int vert);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetFunctionAnalysisSkipOverride(BNFunction* func, FunctionAnalysisSkipOverride skip);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetFunctionAutoType(BNFunction* func, BNType* type);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetFunctionComment(BNFunction* func, char* comment);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetFunctionForFlowGraph(BNFlowGraph* graph, BNFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetFunctionTypeCanReturn(BNType* type, BNBoolWithConfidence* canReturn);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetFunctionUserType(BNFunction* func, BNType* type);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetIntegerConstantDisplayType(BNFunction* func, BNArchitecture* arch, ulong instrAddr, ulong value, ulong operand, IntegerDisplayType type);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetMaxFunctionSizeForAnalysis(BNBinaryView* view, ulong size);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetNewAutoFunctionAnalysisSuppressed(BNBinaryView* view, bool suppress);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetOriginalFilename(BNFileMetadata* file, char* name);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetParametersForAnalysis(BNBinaryView* view, BNAnalysisParameters _params);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetPlatformSystemCallConvention(BNPlatform* platform, BNCallingConvention* cc);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetScriptingInstanceCurrentAddress(BNScriptingInstance* instance, ulong addr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetScriptingInstanceCurrentBasicBlock(BNScriptingInstance* instance, BNBasicBlock* block);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetScriptingInstanceCurrentBinaryView(BNScriptingInstance* instance, BNBinaryView* view);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetScriptingInstanceCurrentFunction(BNScriptingInstance* instance, BNFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetScriptingInstanceCurrentSelection(BNScriptingInstance* instance, ulong begin, ulong end);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetStructureAlignment(BNStructure* s, ulong align);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetStructurePacked(BNStructure* s, bool packed);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetStructureType(BNStructure* s, StructureType type);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetStructureWidth(BNStructure* s, ulong width);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetTypeReferenceClass(BNNamedTypeReference* nt, NamedTypeReferenceClass cls);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetTypeReferenceId(BNNamedTypeReference* nt, char* id);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetTypeReferenceName(BNNamedTypeReference* nt, _BNQualifiedName* name);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetUserBasicBlockHighlight(BNBasicBlock* block, BNHighlightColor color);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetUserCallRegisterStackAdjustment(BNFunction* func, BNArchitecture* arch, ulong addr, BNRegisterStackAdjustment* adjust, ulong count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetUserCallRegisterStackAdjustmentForRegisterStack(BNFunction* func, BNArchitecture* arch, ulong addr, uint regStack, int adjust, byte confidence);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetUserCallStackAdjustment(BNFunction* func, BNArchitecture* arch, ulong addr, long adjust, byte confidence);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetUserFunctionCallingConvention(BNFunction* func, BNCallingConventionWithConfidence* convention);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetUserFunctionCanReturn(BNFunction* func, BNBoolWithConfidence* returns);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetUserFunctionClobberedRegisters(BNFunction* func, BNRegisterSetWithConfidence* regs);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetUserFunctionHasVariableArguments(BNFunction* func, BNBoolWithConfidence* varArgs);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetUserFunctionParameterVariables(BNFunction* func, BNParameterVariablesWithConfidence* vars);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetUserFunctionRegisterStackAdjustments(BNFunction* func, BNRegisterStackAdjustment* adjustments, ulong count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetUserFunctionReturnRegisters(BNFunction* func, BNRegisterSetWithConfidence* regs);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetUserFunctionReturnType(BNFunction* func, BNTypeWithConfidence* type);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetUserFunctionStackAdjustment(BNFunction* func, BNOffsetWithConfidence* stackAdjust);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetUserIndirectBranches(BNFunction* func, BNArchitecture* sourceArch, ulong source, BNArchitectureAndAddress* branches, ulong count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetUserInstructionHighlight(BNFunction* func, BNArchitecture* arch, ulong addr, BNHighlightColor color);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNSetWorkerThreadCount(ulong count);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNSettingsGetBool(char* registry, char* id, BNBinaryView* view, BNSettingsScope* scope);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe double BNSettingsGetDouble(char* registry, char* id, BNBinaryView* view, BNSettingsScope* scope);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe long BNSettingsGetInt64(char* registry, char* id, BNBinaryView* view, BNSettingsScope* scope);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNSettingsGetSchema(char* registry);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char* BNSettingsGetString(char* registry, char* id, BNBinaryView* view, BNSettingsScope* scope);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe char** BNSettingsGetStringList(char* registry, char* id, BNBinaryView* view, BNSettingsScope* scope, ulong* inoutSize);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNSettingsGetUInt64(char* registry, char* id, BNBinaryView* view, BNSettingsScope* scope);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNSettingsRegisterGroup(char* registry, char* group, char* title);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNSettingsRegisterSetting(char* registry, char* id, char* properties);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNSettingsReset(char* registry, char* id, BNBinaryView* view, SettingsScope scope);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNSettingsResetAll(char* registry, BNBinaryView* view, SettingsScope scope);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNSettingsSetBool(char* registry, BNBinaryView* view, SettingsScope scope, char* id, bool value);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNSettingsSetDouble(char* registry, BNBinaryView* view, SettingsScope scope, char* id, double value);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNSettingsSetInt64(char* registry, BNBinaryView* view, SettingsScope scope, char* id, long value);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNSettingsSetString(char* registry, BNBinaryView* view, SettingsScope scope, char* id, char* value);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNSettingsSetStringList(char* registry, BNBinaryView* view, SettingsScope scope, char* id, char** value, ulong size);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNSettingsSetUInt64(char* registry, BNBinaryView* view, SettingsScope scope, char* id, ulong value);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNSettingsUpdateBoolProperty(char* registry, char* id, char* property, bool value);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNSettingsUpdateDoubleProperty(char* registry, char* id, char* property, double value);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNSettingsUpdateInt64Property(char* registry, char* id, char* property, long value);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNSettingsUpdateProperty(char* registry, char* id, char* property);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNSettingsUpdateStringListProperty(char* registry, char* id, char* property, char** value, ulong size);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNSettingsUpdateStringProperty(char* registry, char* id, char* property, char* value);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNSettingsUpdateUInt64Property(char* registry, char* id, char* property, ulong value);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNShowGraphReport(BNBinaryView* view, char* title, BNFlowGraph* graph);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNShowHTMLReport(BNBinaryView* view, char* title, char* contents, char* plaintext);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNShowMarkdownReport(BNBinaryView* view, char* title, char* contents, char* plaintext);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe MessageBoxButtonResult BNShowMessageBox(char* title, char* text, MessageBoxButtonSet buttons, MessageBoxIcon icon);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNShowPlainTextReport(BNBinaryView* view, char* title, char* contents);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNShowReportCollection(char* title, BNReportCollection* reports);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNShutdown();
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNSkipAndReturnValue(BNBinaryView* view, BNArchitecture* arch, ulong addr, ulong value);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNFlowGraphLayoutRequest* BNStartFlowGraphLayout(BNFlowGraph* graph, void* ctxt, [MarshalAs(UnmanagedType.FunctionPtr)] funcDelegate func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNToVariableIdentifier(BNVariable* var);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNMemberAccessWithConfidence BNTypeGetMemberAccess(BNType* type);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNMemberScopeWithConfidence BNTypeGetMemberScope(BNType* type);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNQualifiedName BNTypeGetStructureName(BNType* type);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNQualifiedName BNTypeGetTypeName(BNType* nt);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNBoolWithConfidence BNTypeHasVariableArguments(BNType* type);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNTypeSetConst(BNType* type, BNBoolWithConfidence* cnst);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNTypeSetMemberAccess(BNType* type, BNMemberAccessWithConfidence* access);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNTypeSetMemberScope(BNType* type, BNMemberScopeWithConfidence* scope);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNTypeSetTypeName(BNType* type, _BNQualifiedName* name);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNTypeSetVolatile(BNType* type, BNBoolWithConfidence* vltl);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNTypesEqual(BNType* a, BNType* b);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNTypesNotEqual(BNType* a, BNType* b);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNUndefineAnalysisType(BNBinaryView* view, char* id);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNUndefineAutoSymbol(BNBinaryView* view, BNSymbol* sym);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNUndefineDataVariable(BNBinaryView* view, ulong addr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNUndefineUserAnalysisType(BNBinaryView* view, _BNQualifiedName* name);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNUndefineUserDataVariable(BNBinaryView* view, ulong addr);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNUndefineUserSymbol(BNBinaryView* view, BNSymbol* sym);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNUndo(BNFileMetadata* file);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNUnregisterDataNotification(BNBinaryView* view, _BNBinaryDataNotification* notify);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNUnregisterLogListener(_BNLogListener* listener);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNUnregisterObjectDestructionCallbacks(_BNObjectDestructionCallbacks* callbacks);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNUnregisterScriptingInstanceOutputListener(BNScriptingInstance* instance, _BNScriptingOutputListener* callbacks);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNUpdateAnalysis(BNBinaryView* view);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNUpdateAnalysisAndWait(BNBinaryView* view);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNFlowGraph* BNUpdateFlowGraph(BNFlowGraph* graph);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNUpdateLogListeners();
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNUpdateLowLevelILOperand(BNLowLevelILFunction* func, ulong instr, ulong operandIndex, ulong value);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNUpdateMediumLevelILOperand(BNMediumLevelILFunction* func, ulong instr, ulong operandIndex, ulong value);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe UpdateResult BNUpdateToLatestVersion(char* channel, char** errors, [MarshalAs(UnmanagedType.FunctionPtr)] progressDelegate progress, void* context);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe UpdateResult BNUpdateToVersion(char* channel, char* version, char** errors, [MarshalAs(UnmanagedType.FunctionPtr)] progressDelegate progress, void* context);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNUpdatesChecked();
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNWaitForMainThreadAction(BNMainThreadAction* action);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNWasFunctionAutomaticallyDiscovered(BNFunction* func);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNWorkerEnqueue(void* ctxt, [MarshalAs(UnmanagedType.FunctionPtr)] actionDelegate action);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNWorkerInteractiveEnqueue(void* ctxt, [MarshalAs(UnmanagedType.FunctionPtr)] actionDelegate action);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe void BNWorkerPriorityEnqueue(void* ctxt, [MarshalAs(UnmanagedType.FunctionPtr)] actionDelegate action);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNWrite16(BNBinaryWriter* stream, ushort val);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNWrite32(BNBinaryWriter* stream, uint val);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNWrite64(BNBinaryWriter* stream, ulong val);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNWrite8(BNBinaryWriter* stream, byte val);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNWriteBE16(BNBinaryWriter* stream, ushort val);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNWriteBE32(BNBinaryWriter* stream, uint val);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNWriteBE64(BNBinaryWriter* stream, ulong val);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNWriteData(BNBinaryWriter* stream, void* src, ulong len);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNWriteDataForDownloadInstance(BNDownloadInstance* instance, byte* data, ulong len);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNWriteLE16(BNBinaryWriter* stream, ushort val);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNWriteLE32(BNBinaryWriter* stream, uint val);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe bool BNWriteLE64(BNBinaryWriter* stream, ulong val);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNWriteViewBuffer(BNBinaryView* view, ulong offset, BNDataBuffer* data);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe ulong BNWriteViewData(BNBinaryView* view, ulong offset, void* data, ulong len);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNDataBuffer* BNZlibCompress(BNDataBuffer* buf);
		[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
		public static extern unsafe BNDataBuffer* BNZlibDecompress(BNDataBuffer* buf);
	}
}
