using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryNinja
{
    public class BasicBlock
    {
        private readonly unsafe Core.BNBasicBlock* handle;

        public Function Function { get; private set; }

        public ulong Length { get; private set; }

        public unsafe BasicBlock(Core.BNBasicBlock* bb)
        {
            handle = bb;
        }
    }
}
