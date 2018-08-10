using MapleCLBUpdate.Types;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MapleCLBUpdate.Resources
{
    //Maps isnt updated..
    internal class Maps
    {
        private static readonly Assembly assembly = Assembly.GetExecutingAssembly();

        internal static ReadOnlyDictionary<int, MapNode> Nodes = LoadMaps();
        internal static ReadOnlyDictionary<int, string[]> Names = LoadMapNames();
        internal static ReadOnlyDictionary<string, int[]> SpawnPoints = LoadSpawnPoints();

        private static ReadOnlyDictionary<int, MapNode> LoadMaps()
        {
            using (var file = assembly.GetManifestResourceStream("MapleCLBUpdate.Resources.Map.node.map"))
            {
                if (file == null)
                {
                    throw new FileNotFoundException("Unable to load maps.");
                }
                var br = new BinaryReader(file);

                int count = br.ReadInt32();
                Dictionary<int, MapNode> readMap = new Dictionary<int, MapNode>(count);
                for (int i = 0; i < count; i++)
                {
                    int key = br.ReadInt32();
                    var node = new MapNode(br);
                    readMap.Add(key, node);
                }
                return new ReadOnlyDictionary<int, MapNode>(readMap);
            }
        }

        private static ReadOnlyDictionary<string, int[]> LoadSpawnPoints()
        {
            using (var file = assembly.GetManifestResourceStream("MapleCLBUpdate.Resources.Map.spawnPoints.map"))
            {
                if (file == null)
                {
                    throw new FileNotFoundException("Unable to load map names.");
                }

                Dictionary<string, int[]> spawnPoints = new Dictionary<string, int[]>();

                using (TextReader reader = new StreamReader(file))
                {
                    while (reader.Peek() >= 0)
                    {
                        string text = reader.ReadLine();
                        //Console.WriteLine(text);
                        string[] bits = text.Split(' ');
                        int mapID = Int32.Parse(bits[0]);
                        //Console.Write(mapID + " ");
                        int spawnPoint = Int32.Parse(bits[1]);
                        //Console.Write(spawnPoint + " ");
                        int x = Int32.Parse(bits[2]);
                        //Console.Write(x + " ");
                        int y = Int32.Parse(bits[3]);
                        //Console.Write(y + " ");
                        string key = mapID + "_" + spawnPoint;
                        int[] data = { x, y };
                        spawnPoints[key] = data;
                    }
                }
                return new ReadOnlyDictionary<string, int[]>(spawnPoints);
            }
        }

        private static ReadOnlyDictionary<int, string[]> LoadMapNames()
        {
            using (var file = assembly.GetManifestResourceStream("MapleCLBUpdate.Resources.Map.name.map"))
            {
                if (file == null)
                {
                    throw new FileNotFoundException("Unable to load map names.");
                }
                var br = new BinaryReader(file);

                int count = br.ReadInt32();
                Dictionary<int, string[]> mapNames = new Dictionary<int, string[]>(count);
                for (int i = 0; i < count; i++)
                {
                    int key = br.ReadInt32();
                    string[] name = { br.ReadString(), br.ReadString() };
                    mapNames[key] = name;
                }
                return new ReadOnlyDictionary<int, string[]>(mapNames);
            }
        }
    }
}
