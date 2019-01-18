using System.Collections.Generic;
using System;

namespace BinaryNinja
{
    public class BinaryView
    {
        public readonly unsafe Core.BNBinaryView* handle;
        public FileMetadata File { get; }
        private static readonly List<BinaryView> registeredInstances = new List<BinaryView>();

        public bool MustFree { get; } = true;

        //
        // Constructors
        //
        public unsafe BinaryView(Core.BNBinaryView* view)
        {
            handle = view;
            File = new FileMetadata(Core.BNGetFileForView(view));
        }

        protected BinaryView(FileMetadata file)
        {
            this.File = file;

            unsafe
            {
                handle = Core.BNCreateBinaryDataView(file.handle);
            }
        }

        protected BinaryView(DataBuffer data, FileMetadata file)
        {
            this.File = file;

            unsafe
            {
                handle = Core.BNCreateBinaryDataViewFromBuffer(file.handle, data.buffer);
            }
        }

        protected BinaryView(byte[] data, FileMetadata file)
        {
            this.File = file;

            unsafe
            {
                this.handle = Core.BNCreateBinaryDataViewFromData(file.handle, data, (ulong)data.Length);
            }
        }

        protected BinaryView(string path, FileMetadata file)
        {
            this.File = file;

            unsafe
            {
                this.handle = Core.BNCreateBinaryDataViewFromFilename(file.handle, path);
            }
        }

        protected BinaryView(FileAccessor accessor, FileMetadata file)
        {
            this.File = file;

            unsafe
            {
                this.handle = Core.BNCreateBinaryDataViewFromFile(this.File.handle, accessor.handle);

            }
        }

        protected BinaryView(string typeName, FileMetadata file, BinaryView parentView)
        {
            throw new NotImplementedException("Creating new BinaryViews is not implemented");
            //if (GetType() == typeof(BinaryView))
            //{
            //    this.file = file;
            //    //TODO: 
            //}
            //else
            //{
            //    unsafe
            //    {
            //        //TODO: callbacks
            //    }

            //    registeredInstances.Add(this);
            //}
        }

        //
        // Destructor
        //
        unsafe ~BinaryView()
        {
            //TODO: unregister notifications
            if (MustFree)
            {
                Core.BNFreeBinaryView(handle);
            }
        }

        //
        // New
        //
        public static BinaryView New(DataBuffer data, FileMetadata file=null)
        {
            file = file ?? new FileMetadata();

            data = data ?? new DataBuffer();

            return new BinaryView(data, file); 
        }

        public static BinaryView New(byte[] data, FileMetadata file=null)
        {
            file = file ?? new FileMetadata();

            return new BinaryView(new DataBuffer(data), file);
        }

        public static BinaryView New(ulong len, FileMetadata file=null)
        {
            file = file ?? new FileMetadata();

            return new BinaryView(new DataBuffer(len), file);
        }

        //
        // Open
        //
        public static BinaryView Open(FileAccessor src, FileMetadata file=null)
        {
            file = file ?? new FileMetadata();

            unsafe
            {
                Core.BNBinaryView* view = Core.BNCreateBinaryDataViewFromFile(file.handle, src.handle);
                if (view == null)
                {
                    return null;
                }

                return new BinaryView(view);
            }
        }

        public static BinaryView Open(string src, FileMetadata file=null)
        {
            file = file ?? new FileMetadata(src);

            unsafe
            {
                Core.BNBinaryView* view = Core.BNCreateBinaryDataViewFromFilename(file.handle, src);
                if (view == null)
                {
                    return null;
                }

                return new BinaryView(view);
            }
        }

        // Properties
        public ulong Start {
            get
            {
                unsafe
                {
                    return Core.BNGetStartOffset(handle);
                }
            }
        }

        public ulong Length
        {
            get
            {
                unsafe
                {
                    return Core.BNGetViewLength(handle);
                }
            }
        }

        public override string ToString()
        {
            return String.Format("[BinaryView: \"{0}\" start: {1:X} length: {2:X}]", File.Filename, Start, Length);
        }
    }
}
