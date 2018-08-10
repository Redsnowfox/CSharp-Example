using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleCLBUpdate.Types.Map
{
    internal class Summon : MapObject{
        internal Summon(int id) : base(id) { }
        public int skillID { get; internal set; }

    }
}
