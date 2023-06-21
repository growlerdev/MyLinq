using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq.Extensions.Tests
{
    internal class TestObject<T>
    {
        public int Qty { get; set; }
        public T Height { get; set; }
        public T Width { get; set; }
        public T Depth { get; set; }
    }
}
