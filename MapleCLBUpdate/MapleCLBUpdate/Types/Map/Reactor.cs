using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleCLBUpdate.Types.Map
{
    internal class Reactor : MapObject
    {
        internal byte Hits { get; set; }

        internal Reactor(int id) : base(id) { }
    }
}
