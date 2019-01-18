namespace BinaryNinja
{
    public unsafe delegate bool BNCorePluginInitFunction();
    public unsafe delegate void BNCorePluginDependencyFunction();

    public unsafe delegate bool BNLoadPluginCallback(char* repoPath, char* pluginPath, void* ctx);

    public unsafe delegate void ProgressCallback(void* ctxt, ulong progress, ulong total);

}