using MapleCLBUpdate.Types;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleCLBUpdate.MapleClient.Functions
{
    internal static class MapRusher
    {
        // Returns list of portals to traverse to move from source to destination
        internal static List<PortalInfo> Pathfind(int src, int dst)
        {
            List<PortalInfo> directions = new List<PortalInfo>();

            // Already on destination map
            if (src == dst)
            {
                return directions;
            }

            // Can move to map with 1 portal
            ReadOnlyDictionary<int, PortalInfo> curPortals = Resources.Maps.Nodes[src].Portals;
            if (curPortals.ContainsKey(dst))
            {
                directions.Add(curPortals[dst]);
                return directions;
            }

            // Cannot reach destination
            if (!Resources.Maps.Nodes[src].Choice.ContainsKey(dst))
            {
                return directions;
            }

            // Find path to destination
            int cur = src;
            while (cur != dst)
            {
                int next = Resources.Maps.Nodes[cur].Choice[dst];
                directions.Add(Resources.Maps.Nodes[cur].Portals[next]);
                cur = next;
            }

            return directions;
        }

        // Returns list of mapIds that are reachable from the source map
        internal static List<int> Reachable(int src)
        {
            return Resources.Maps.Nodes.ContainsKey(src) ? new List<int>(Resources.Maps.Nodes[src].Choice.Keys)
                                               : new List<int>();
        }
    }
}


