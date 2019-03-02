using System;
using System.IO;
using System.Text;
using System.Runtime.InteropServices;

namespace BinaryNinja
{
    [StructLayout(LayoutKind.Sequential)]
    public abstract class BinaryViewType
    {
        protected string name, longName;
        public unsafe Core.BNBinaryViewType* handle;

        public unsafe BinaryViewType(Core.BNBinaryViewType* handle)
        {
            this.handle = handle;
        }

        public static bool operator ==(BinaryViewType left, BinaryViewType right)
        {
            unsafe
            {
                return (IntPtr)(left.handle) == (IntPtr)(right.handle);
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || this.GetType() != obj.GetType()) return false;
            return this == (BinaryViewType)obj;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator !=(BinaryViewType left, BinaryViewType right)
        {
            unsafe
            {
                return (IntPtr)(left.handle) != (IntPtr)(right.handle);
            }
        }

        public static CoreBinaryViewType GetByName(string name)
        {
            unsafe
            {
                Core.BNBinaryViewType* type = Core.BNGetBinaryViewTypeByName(name);
                if (type == null)
                    return null;
                return new CoreBinaryViewType(type);
            }
        }

        public static CoreBinaryViewType[] List
        {
            get
            {
                CoreBinaryViewType[] result;

                unsafe
                {
                    ulong count;
                    var types = Core.BNGetBinaryViewTypes(&count);

                    result = new CoreBinaryViewType[count];

                    for (ulong i = 0; i < count; i++)
                    {
                        result[i] = new CoreBinaryViewType(types[i]);
                    }

                    Core.BNFreeBinaryViewTypeList(types);
                }

                return result;
            }
        }

        public string Name
        {
            get
            {
                unsafe
                {
                    char* str = Core.BNGetBinaryViewTypeName(handle);
                    string name = Marshal.PtrToStringAnsi((IntPtr)str);
                    Core.BNFreeString(str);
                    return name;
                }

            }
        }

        public string LongName
        {
            get
            {
                unsafe
                {
                    char* str = Core.BNGetBinaryViewTypeLongName(handle);
                    string name = Marshal.PtrToStringAnsi((IntPtr)str);
                    Core.BNFreeString(str);
                    return name;
                }
            }
        }

        public override string ToString()
        {
            return string.Format("<view type: {0}>", Name);
        }

        public abstract BinaryView Create(BinaryView data);
        public abstract bool IsTypeValidForData(BinaryView data);

        public static BinaryView GetViewOfFile(string filename, bool updateAnalysis = true)
        {
            var sqlite = "SQLite format 3";

            BinaryView view = null;

            if (filename.EndsWith(".bndb"))
            {
                try
                {
                    using (var f = File.OpenRead(filename))
                    {
                        byte[] result = new byte[sqlite.Length];
                        if (f.Read(result, 0, sqlite.Length) != sqlite.Length ||
                            Encoding.Default.GetString(result).Equals(sqlite) == false)
                        {
                            return null;
                        }
                    }
                }
                catch
                {
                    return null;
                }

                view = FileMetadata.OpenExistingDatabase(filename);

                return view;
            }

            // TODO: finish
            return null;
        }
    }

    public class CoreBinaryViewType : BinaryViewType
    {
        public unsafe CoreBinaryViewType(Core.BNBinaryViewType* handle) : base(handle)
        {
        }

        public override BinaryView Create(BinaryView data)
        {
            BinaryView result;
            unsafe
            {
                Core.BNBinaryView* view = Core.BNCreateBinaryViewOfType(handle, data.handle);
                if (view == null)
                {
                    return null;
                }

                result = new BinaryView(view);
            }
            return result;
        }

        public override bool IsTypeValidForData(BinaryView data)
        {
            unsafe
            {
                return Core.BNIsBinaryViewTypeValidForData(handle, data.handle);
            } 
        }

        public BinaryView Open(string src, FileMetadata file = null)
        {
            BinaryView data = BinaryView.Open(src, file);

            if (data == null)
            {
                return null;
            }

            return Create(data);
        }

        public void RegisterArchitecture(uint ident, Endianness endian, Architecture arch)
        {
            unsafe
            {
                Core.BNRegisterArchitectureForViewType(handle, ident, endian, arch.handle);
            }
        }
    }

  //  @classmethod

  //  def get_view_of_file(cls, filename, update_analysis= True):
		//"""
		//``get_view_of_file`` returns the first available, non-Raw `BinaryView` available.

		//:param str filename: Path to filename or bndb
		//:param bool update_analysis: defaults to True.Pass False to not run update_analysis_and_wait.
		//:return: returns a BinaryView object for the given filename.
		//:rtype: BinaryView or None
		//"""

  //     sqlite = b"SQLite format 3"
		//if filename.endswith(".bndb"):

  //          f = open(filename, 'rb')
		//	if f is None or f.read(len(sqlite)) != sqlite:
		//		return None
  //          f.close()

  //          view = binaryninja.filemetadata.FileMetadata().open_existing_database(filename)
		//else:
		//	view = BinaryView.open(filename)

		//if view is None:
		//	return None
		//for available in view.available_view_types:
		//	if available.name != "Raw":
		//		if filename.endswith(".bndb"):
		//			bv = view.get_view_of_type(available.name)
		//		else:
		//			bv = cls[available.name].open(filename)

		//		if bv is None:
		//			raise Exception("Unknown Architecture/Architecture Not Found (check plugins folder)")

		//		if update_analysis:
		//			bv.update_analysis_and_wait()
		//		return bv
		//return None


  //  def get_arch(self, ident, endian) :

  //      arch = core.BNGetArchitectureForViewType(self.handle, ident, endian)
		//if arch is None:
		//	return None
		//return binaryninja.architecture.CoreArchitecture._from_cache(arch)

  //  def register_platform(self, ident, arch, plat) :

  //      core.BNRegisterPlatformForViewType(self.handle, ident, arch.handle, plat.handle)

  //  def register_default_platform(self, arch, plat) :

  //      core.BNRegisterDefaultPlatformForViewType(self.handle, arch.handle, plat.handle)

  //  def get_platform(self, ident, arch) :

  //      plat = core.BNGetPlatformForViewType(self.handle, ident, arch.handle)
		//if plat is None:
		//	return None
		//return binaryninja.platform.Platform(None, plat)
}

