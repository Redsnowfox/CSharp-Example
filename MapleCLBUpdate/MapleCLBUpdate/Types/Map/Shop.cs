using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleCLBUpdate.Types.Map
{
    public enum ShopType : byte
    {
        PERMIT = 5,
        MUSHY = 6
    }

    internal class Shop : MapObject
    {
        public ShopType Type { get; internal set; }
        public short Foothold { get; internal set; }
        public string OwnerName { get; internal set; }
        public int ShopId { get; internal set; }
        public string ShopTitle { get; internal set; }

        internal Shop(int id) : base(id) { }
    }
}