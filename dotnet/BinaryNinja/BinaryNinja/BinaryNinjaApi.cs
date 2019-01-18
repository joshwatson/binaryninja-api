using System;
using System.Runtime.InteropServices;

namespace BinaryNinja
{
    public class BN
    {
        public static void InitCorePlugins()
        {
            Core.BNInitCorePlugins();
        }

        public static void InitUserPlugins()
        {
            Core.BNInitUserPlugins();
        }

        public static void InitRepoPlugins()
        {
            Core.BNInitRepoPlugins();
        }

        public static void SetPluginDirectory(string path)
        {
            Core.BNSetBundledPluginDirectory(path);
        }

        public static void InitPlugins()
        {
            string pluginPath = "C:\\Program Files\\Vector35\\BinaryNinja\\plugins\\";

            SetPluginDirectory(pluginPath);

            Core.BNInitCorePlugins();
            Core.BNInitUserPlugins();
            Core.BNInitRepoPlugins();
        }
    }

}