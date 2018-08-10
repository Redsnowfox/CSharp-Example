using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleCLBUpdate.Types.Map
{
    internal class Player : MapObject
    {
        public string Name { get; internal set; }
        public short Foothold { get; internal set; }
        internal Player(int id) : base(id) { }
    }
}
