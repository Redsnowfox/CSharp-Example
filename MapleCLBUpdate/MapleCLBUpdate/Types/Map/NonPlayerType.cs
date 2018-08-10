using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleCLBUpdate.Types.Map
{
    internal class NonPlayerType : MapObject
    {
        public int NpcId { get; internal set; }
        internal NonPlayerType(int id) : base(id) { }
    }
}