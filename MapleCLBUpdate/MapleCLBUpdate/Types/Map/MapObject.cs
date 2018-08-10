using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleCLBUpdate.Types.Map
{
    internal abstract class MapObject
    {
        public int Id { get; }
        public Position Position { get; internal set; }

        protected MapObject(int id)
        {
            Id = id;
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }

    //internal abstract class MapObject {
    //    internal readonly int Id;
    //    internal Position Position { get; set; }

    //    protected MapObject(int id) {
    //        Id = id;
    //    }

    //    public override int GetHashCode() {
    //        return Id;
    //    }
    //}
}
