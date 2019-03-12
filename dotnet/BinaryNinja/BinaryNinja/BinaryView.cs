using System.Collections.Generic;
using System;
using System.Runtime.InteropServices;

namespace BinaryNinja
{
    public class BinaryView
    {
        private static readonly List<BinaryView> registeredInstances = new List<BinaryView>();

        protected bool MustFree { get; } = true;


        public unsafe Core.BNBinaryView* handle { get; }

        #region BinaryView Properties
        public FileMetadata File { get; }

        public BinaryView Parent
        {
            get
            {
                unsafe
                {
                    Core.BNBinaryView* view = Core.BNGetParentView(handle);
                    if (view == null)
                        return null;
                    return new BinaryView(view);
                }
            }
        }

        public string Name
        {
            get
            {
                unsafe
                {
                    char* str = Core.BNGetViewType(handle);
                    string result = Marshal.PtrToStringAnsi((IntPtr)str);
                    Core.BNFreeString(str);
                    return result;
                }

            }
        }

        public bool Modified
        {
            get
            {
                return File.Modified;
            }

            set
            {
                File.Modified = value;
            }
        }

        public bool AnalysisChanged
        {
            get
            {
                return File.AnalysisChanged;
            }
        }
        #endregion

        #region Constructors
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
        #endregion

        #region Destructors
        unsafe ~BinaryView()
        {
            //TODO: unregister notifications
            if (MustFree)
            {
                Core.BNFreeBinaryView(handle);
            }
        }
        #endregion

        #region Perform Methods
        protected virtual ulong PerformRead(out byte[] dest, ulong offset, ulong len) { dest = null; return 0; }
        protected virtual ulong PerformWrite(ulong offset, byte[] data) { return 0; }
        protected virtual ulong PerformInsert(ulong offset, byte[] data) { return 0; }
        protected virtual ulong PerformRemove(ulong offset, ulong len) { return 0; }

        protected virtual ModificationStatus PerformGetModification(ulong offset) { return ModificationStatus.Original; }
        protected virtual ulong PerformGetStart() { return 0; }
        protected virtual ulong PerformGetLength() { return 0; }
        protected virtual ulong PerformGetEntryPoint() { return 0; }
        protected bool PerformIsExecutable() { return false; }
        #endregion

        #region Callbacks
        // TODO: private callback methods
        #endregion

        
        public virtual bool Init() { return true; }

        #region Database Methods
        // TODO: Implement
        public bool HasDatabase {get;}

        public bool CreateDatabase(string path)
        {
            throw new NotImplementedException();
        }

        public bool CreateDatabase(string path, Action<ulong, ulong> progressCallback)
        {
            throw new NotImplementedException();
        }

        public bool SaveAutoSnapshot()
        {
            throw new NotImplementedException();
        }

        public bool SaveAutoSnapshot(Action<ulong, ulong> progressCallback)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Undo Actions
        public void BeginUndoActions()
        {
            throw new NotImplementedException();
        }

        public void AddUndoAction(UndoAction action)
        {
            throw new NotImplementedException();
        }

        public void CommitUndoActions()
        {
            throw new NotImplementedException();
        }

        public bool Undo()
        {
            throw new NotImplementedException();
        }

        public bool Redo()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Navigation
        // TODO: Implement
        public string View { get; set; }

        public ulong CurrentOffset { get; set; }

        public bool Navigate(string view, ulong offset)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Reading and Writing
        public ulong Read(out byte[] dest, ulong offset, ulong len)
        {
            throw new NotImplementedException();
        }

        public DataBuffer ReadBuffer(ulong offset, ulong len)
        {
            throw new NotImplementedException();
        }

        public ulong Write(ulong offset, byte[] data)
        {
            throw new NotImplementedException();
        }

        public ulong WriteBuffer(ulong offset, DataBuffer data)
        {
            throw new NotImplementedException();
        }

        public ulong Insert(ulong offset, byte[] data)
        {
            throw new NotImplementedException();
        }

        public ulong InsertBuffer(ulong offset, DataBuffer data)
        {
            throw new NotImplementedException();
        }

        public ulong Remove(ulong offset, ulong len)
        {
            throw new NotImplementedException();
        }

        public ModificationStatus GetModification(ulong offset)
        {
            throw new NotImplementedException();
        }

        public ModificationStatus[] GetModification(ulong offset, ulong len)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Offset Methods
        public bool IsValidOffset(ulong offset)
        {
            throw new NotImplementedException();
        }

        public bool IsOffsetReadable(ulong offset)
        {
            throw new NotImplementedException();
        }

        public bool IsOffsetWritable(ulong offset)
        {
            throw new NotImplementedException();
        }

        public bool IsOffsetExecutable(ulong offset)
        {
            throw new NotImplementedException();
        }

        public bool IsOffsetBackedByFile(ulong offset)
        {
            throw new NotImplementedException();
        }

        public bool IsOffsetCodeSemantics(ulong offset)
        {
            throw new NotImplementedException();
        }

        public bool IsOffsetWritableSemantics(ulong offset)
        {
            throw new NotImplementedException();
        }

        public bool IsOffsetExternSemantics(ulong offset)
        {
            throw new NotImplementedException();
        }

        public bool GetNextValidOffset(ulong offset)
        {
            throw new NotImplementedException();
        }
        #endregion

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

        public Function[] GetFunctionsContaining(ulong addr)
        {
            var basicBlocks = GetBasicBlocksAt(addr);

            if (basicBlocks.Length == 0)
            {
                return null;
            }
            else
            {
                Function[] result = new Function[basicBlocks.Length];
                uint i = 0;
                foreach (BasicBlock bb in basicBlocks)
                {
                    result[i++] = bb.Function;
                }

                return result;
            }
        }

        public BasicBlock[] GetBasicBlocksAt(ulong addr)
        {
            ulong count;
            BasicBlock[] result;
            unsafe
            {
                var basicBlocks = Core.BNGetBasicBlocksForAddress(this.handle, addr, &count);

                if (count == 0)
                {
                    return null;
                }

                result = new BasicBlock[count];

                for (ulong i = 0; i < count; i++)
                {
                    result[i] = new BasicBlock(basicBlocks[i]);
                }
            }

            return result;

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
