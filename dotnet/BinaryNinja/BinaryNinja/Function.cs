using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryNinja
{
    public class Function
    {
        private readonly unsafe Core.BNFunction* handle;

        public unsafe Function(Core.BNFunction* function)
        {
            handle = function;
        }
    }
}
