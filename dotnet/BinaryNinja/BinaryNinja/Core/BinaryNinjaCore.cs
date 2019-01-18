using System.Runtime.InteropServices;
using System;

namespace BinaryNinja
{
    public class Core
    {
        public struct BNDataBuffer { };
        public struct BNBinaryView { };
        public struct BNBinaryViewType { };
        public struct BNBinaryReader { };
        public struct BNBinaryWriter { };
        public struct BNFileMetadata { };
        public struct BNTransform { };
        public struct BNArchitecture { };
        public struct BNFunction { };
        public struct BNBasicBlock { };
        public struct BNDownloadProvider { };
        public struct BNDownloadInstance { };
        public struct BNFlowGraph { };
        public struct BNFlowGraphNode { };
        public struct BNFlowGraphLayoutRequest { };
        public struct BNSymbol { };
        public struct BNTemporaryFile { };
        public struct BNLowLevelILFunction { };
        public struct BNMediumLevelILFunction { };
        public struct BNType { };
        public struct BNStructure { };
        public struct BNNamedTypeReference { };
        public struct BNEnumeration { };
        public struct BNCallingConvention { };
        public struct BNPlatform { };
        public struct BNAnalysisCompletionEvent { };
        public struct BNDisassemblySettings { };
        public struct BNScriptingProvider { };
        public struct BNScriptingInstance { };
        public struct BNMainThreadAction { };
        public struct BNBackgroundTask { };
        public struct BNRepository { };
        public struct BNRepoPlugin { };
        public struct BNRepositoryManager { };
        public struct BNMetadata { };
        public struct BNReportCollection { };
        public struct BNRelocation { };
        public struct BNSegment { };
        public struct BNSection { };
        public struct BNRelocationInfo { };
        public struct BNRelocationHandler { };
        public struct BNDataRenderer { };
        public struct BNDataRendererContainer { };

        // Opaque pointer for BNObjectDestructionCallbacks
        public struct _BNObjectDestructionCallbacks { };

        // Callback Delegates
        public unsafe delegate void DestructBinaryView(void* ctxt, BNBinaryView* view);
        public unsafe delegate void DestructFileMetadata(void* ctxt, BNFileMetadata* file);
        public unsafe delegate void DestructFunction(void* ctxt, BNFunction* func);

        public unsafe delegate void BNLogListenerLog(void* ctxt, BNLogLevel level, [MarshalAs(UnmanagedType.LPStr)] string msg);
        public unsafe delegate void BNLogListenerClose(void* ctxt);
		public unsafe delegate BNLogLevel BNLogListenerGetLogLevel(void* ctxt);

        public unsafe delegate char* BNNavigationHandlerGetCurrentView(void* ctxt);
		public unsafe delegate ulong BNNavigationHandlerGetCurrentOffset(void* ctxt);
		public unsafe delegate bool BNNavigationHandlerNavigate(void* ctxt, char* view, ulong offset);

        // String
        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe char* BNAllocString(char* contents);
        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe void BNFreeString(char* str);
        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe char** BNAllocStringList(char** contents, ulong size);
	    [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe void BNFreeStringList(char** strs, ulong count);

        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern void BNShutdown();

        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe char* BNGetVersionString();
        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern uint BNGetBuildId();

        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe char* BNGetSerialNumber();
        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern ulong BNGetLicenseExpirationTime();
        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe bool BNIsLicenseValidated();
        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe char* BNGetLicensedUserEmail();
        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe char* BNGetProduct();
        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe char* BNGetProductType();
        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern int BNGetLicenseCount();
        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern bool BNIsUIEnabled();

        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe void BNRegisterObjectDestructionCallbacks(_BNObjectDestructionCallbacks* callbacks);
        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe void BNUnregisterObjectDestructionCallbacks(_BNObjectDestructionCallbacks* callbacks);

        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe char* BNGetUniqueIdentifierString();

        // Plugin initialization
        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern void BNInitCorePlugins();
        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern void BNInitUserPlugins();
        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern void BNInitRepoPlugins();

        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe char* BNGetInstallDirectory();
        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe char* BNGetBundledPluginDirectory();
        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe void BNSetBundledPluginDirectory([MarshalAs(UnmanagedType.LPStr)] string path);
        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe char* BNGetUserDirectory();
        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe char* BNGetUserPluginDirectory();
        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe char* BNGetRepositoriesDirectory();
        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe char* BNGetSettingsFileName();
        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern void BNSaveLastRun();

        // Architecture

        // File metadata object
        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe BNFileMetadata* BNCreateFileMetadata();
        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe BNFileMetadata* BNNewFileReference(BNFileMetadata* file);
        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe void BNFreeFileMetadata(BNFileMetadata* file);
        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe void BNCloseFile(BNFileMetadata* file);
        //[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        //public static extern unsafe void BNSetFileMetadataNavigationHandler(BNFileMetadata* file, BNNavigationHandler* handler);
        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe bool BNIsFileModified(BNFileMetadata* file);
        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe bool BNIsAnalysisChanged(BNFileMetadata* file);
        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe void BNMarkFileModified(BNFileMetadata* file);
        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe void BNMarkFileSaved(BNFileMetadata* file);

        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe bool BNIsBackedByDatabase(BNFileMetadata* file);
        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe bool BNCreateDatabase(BNBinaryView* data, char* path);
        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe bool BNCreateDatabaseWithProgress(BNBinaryView* data, char* path,
            void* ctxt, ProgressCallback progress);
	    [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe BNBinaryView* BNOpenExistingDatabase(BNFileMetadata* file, char* path);
        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe BNBinaryView* BNOpenExistingDatabaseWithProgress(BNFileMetadata* file, char* path,

        void* ctxt, ProgressCallback progress);
	    [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe bool BNSaveAutoSnapshot(BNBinaryView* data);
        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe bool BNSaveAutoSnapshotWithProgress(BNBinaryView* data, void* ctxt,
            ProgressCallback progress);

        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe char* BNGetOriginalFilename(BNFileMetadata* file);
        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe void BNSetOriginalFilename(BNFileMetadata* file, char* name);

        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe char* BNGetFilename(BNFileMetadata* file);
        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe void BNSetFilename(BNFileMetadata* file, char* name);

        //[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        //public static extern unsafe void BNRegisterUndoActionType(char* name, void* typeContext,
        //    bool (* deserialize) (void* ctxt, const char* data, BNUndoAction* result));
	    [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe void BNBeginUndoActions(BNFileMetadata* file);
        //[DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        //public static extern unsafe void BNAddUndoAction(BNBinaryView* view, char* type, BNUndoAction* action);
	    [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe void BNCommitUndoActions(BNFileMetadata* file);

        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe bool BNUndo(BNFileMetadata* file);
        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe bool BNRedo(BNFileMetadata* file);

        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe char* BNGetCurrentView(BNFileMetadata* file);
        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe ulong BNGetCurrentOffset(BNFileMetadata* file);
        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe bool BNNavigate(BNFileMetadata* file, char* view, ulong offset);

	    [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe BNBinaryView* BNGetFileViewOfType(BNFileMetadata* file, char* name);

        // BinaryView
        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe BNBinaryView* BNNewViewReference(BNBinaryView* view);

        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe void BNFreeBinaryView(BNBinaryView* view);

        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe BNBinaryViewType** BNGetBinaryViewTypes(out ulong count);

        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe BNBinaryViewType* BNGetBinaryViewTypeByName([MarshalAs(UnmanagedType.LPStr)] string name);

        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe void BNFreeBinaryViewTypeList(BNBinaryViewType** types);

        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe char* BNGetBinaryViewTypeName(BNBinaryViewType* type);

        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe char* BNGetBinaryViewTypeLongName(BNBinaryViewType* type);

        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe BNFileMetadata* BNGetFileForView(BNBinaryView* view);

        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe BNBinaryView* BNCreateBinaryViewOfType(BNBinaryViewType* type, BNBinaryView* data);

        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe BNBinaryView* BNCreateBinaryDataView(BNFileMetadata* file);

        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe bool BNIsBinaryViewTypeValidForData(BNBinaryViewType* type, BNBinaryView* data);

        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe BNBinaryView* BNCreateBinaryDataViewFromBuffer(BNFileMetadata* file, BNDataBuffer* data);

        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe BNBinaryView* BNCreateBinaryDataViewFromData(BNFileMetadata* file, [MarshalAs(UnmanagedType.LPArray)] byte[] data, ulong len);

        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe BNBinaryView* BNCreateBinaryDataViewFromFilename(BNFileMetadata* file, [MarshalAs(UnmanagedType.LPStr)] string path);

        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe BNBinaryView* BNCreateBinaryDataViewFromFile(BNFileMetadata* file, BNFileAccessor* accessor);

        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe ulong BNGetViewLength(BNBinaryView* view);

        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe ulong BNGetStartOffset(BNBinaryView* view);

        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe void BNRegisterArchitectureForViewType(BNBinaryViewType* type, ulong ident, BNEndianness endian, BNArchitecture* arch);

        // FileMetadata

        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe void BNSetFilename(BNFileMetadata* file, [MarshalAs(UnmanagedType.LPStr)] string name);

        // DataBuffer
        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe BNDataBuffer* BNCreateDataBuffer(void* data, ulong len);

        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern unsafe void BNFreeDataBuffer(BNDataBuffer* buffer);

        

        // Logging
        //[DllImport("C:\Program Files\Vector35\BinaryNinja\binaryninjacore.dll")]
        //void BNLog(BNLogLevel level, const char* fmt, ...);
        //[DllImport("C:\Program Files\Vector35\BinaryNinja\binaryninjacore.dll")]
        //void BNLogDebug(const char* fmt, ...);
        //[DllImport("C:\Program Files\Vector35\BinaryNinja\binaryninjacore.dll")]
        //void BNLogInfo(const char* fmt, ...);
        //[DllImport("C:\Program Files\Vector35\BinaryNinja\binaryninjacore.dll")]
        //void BNLogWarn(const char* fmt, ...);
        //[DllImport("C:\Program Files\Vector35\BinaryNinja\binaryninjacore.dll")]
        //void BNLogError(const char* fmt, ...);
        //[DllImport("C:\Program Files\Vector35\BinaryNinja\binaryninjacore.dll")]
        //void BNLogAlert(const char* fmt, ...);

        //[DllImport("C:\Program Files\Vector35\BinaryNinja\binaryninjacore.dll")]
        //void BNRegisterLogListener(BNLogListener* listener);
        //[DllImport("C:\Program Files\Vector35\BinaryNinja\binaryninjacore.dll")]
        //void BNUnregisterLogListener(BNLogListener* listener);
        //[DllImport("C:\Program Files\Vector35\BinaryNinja\binaryninjacore.dll")]
        //void BNUpdateLogListeners(void);

        [DllImport("C:\\Program Files\\Vector35\\BinaryNinja\\binaryninjacore.dll")]
        public static extern void BNLogToStdout(BNLogLevel minimumLevel);
        //[DllImport("C:\Program Files\Vector35\BinaryNinja\binaryninjacore.dll")]
        //void BNLogToStderr(BNLogLevel minimumLevel);
        //[DllImport("C:\Program Files\Vector35\BinaryNinja\binaryninjacore.dll")]
        //bool BNLogToFile(BNLogLevel minimumLevel, const char* path, bool append);
        //[DllImport("C:\Program Files\Vector35\BinaryNinja\binaryninjacore.dll")]
        //void BNCloseLogs(void);
    }
}