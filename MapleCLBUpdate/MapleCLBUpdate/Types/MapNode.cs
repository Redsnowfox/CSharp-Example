using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleCLBUpdate.Types
{
    internal sealed class PortalInfo
    {
        internal Position Position { get; set; }
        internal string Name { get; set; }
    }

    internal sealed class MapNode
    {
        internal ReadOnlyDictionary<int, PortalInfo> Portals;
        internal ReadOnlyDictionary<int, int> Choice { get; set; }
        internal int Id { get; }

        internal MapNode(int id, ReadOnlyDictionary<int, PortalInfo> portals, ReadOnlyDictionary<int, int> choice)
        {
            Id = id;
            Portals = portals;
            Choice = choice;
        }

        internal MapNode(BinaryReader reader)
        {
            Id = reader.ReadInt32();

            int count = reader.ReadInt32();
            Dictionary<int, PortalInfo> portals = new Dictionary<int, PortalInfo>(count);
            for (int i = 0; i < count; i++)
            {
                int key = reader.ReadInt32();
                portals[key] = new PortalInfo
                {
                    Position = new Position(reader.ReadInt16(), reader.ReadInt16()),
                    Name = reader.ReadString()
                };
            }

            count = reader.ReadInt32();
            Dictionary<int, int> choice = new Dictionary<int, int>(count);
            for (int i = 0; i < count; i++)
            {
                int key = reader.ReadInt32();
                int value = reader.ReadInt32();
                choice[key] = value;
            }

            // Assign Dictionaries
            Portals = new ReadOnlyDictionary<int, PortalInfo>(portals);
            Choice = new ReadOnlyDictionary<int, int>(choice);
        }

        public override bool Equals(object o)
        {
            var map = o as MapNode;
            return Id == map?.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
