using System.Runtime.InteropServices;
using System;

namespace BinaryNinja
{
    public class FileMetadata
    {
        public unsafe readonly Core.BNFileMetadata* handle;

        public string Filename
        {
            get
            {
                unsafe
                {
                    char* str = Core.BNGetFilename(handle);
                    string result = Marshal.PtrToStringAnsi((IntPtr)str);
                    Core.BNFreeString(str);
                    return result;
                }
            }
        }

        public unsafe FileMetadata(Core.BNFileMetadata* file) => this.handle = file;

        public FileMetadata()
        {
            unsafe
            {
                handle = Core.BNCreateFileMetadata();
            }
        }

        public FileMetadata(string filename)
        {
            unsafe
            {
                handle = Core.BNCreateFileMetadata();
                Core.BNSetFilename(handle, filename);
            }
        }

        public static BinaryView OpenExistingDatabase(string path)
        {
            unsafe
            {
                var fmd = new FileMetadata(path);
                var view = Core.BNOpenExistingDatabase(fmd.handle, path);
                
                if (view == null)
                {
                    return null;
                }
                else
                {
                    return new BinaryView(view);
                }
            }
        }
    }
}
