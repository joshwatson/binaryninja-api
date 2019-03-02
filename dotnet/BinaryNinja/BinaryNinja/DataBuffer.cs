using System;

namespace BinaryNinja
{
    public class DataBuffer
    {
        public readonly unsafe Core.BNDataBuffer* buffer;

        public unsafe DataBuffer(Core.BNDataBuffer* buffer) => this.buffer = buffer;

        public DataBuffer()
        {
            unsafe
            {
                buffer = Core.BNCreateDataBuffer(null, 0);
            }
        }

        public DataBuffer(byte[] data)
        {
            unsafe
            {
                buffer = Core.BNCreateDataBuffer(data, (ulong)data.Length);
            }
        }

        public DataBuffer(ulong len)
        {
            unsafe
            {
                buffer = Core.BNCreateDataBuffer(null, len);
            }
        }

        unsafe ~DataBuffer()
        {
            Core.BNFreeDataBuffer(buffer);
        }
    }
}
