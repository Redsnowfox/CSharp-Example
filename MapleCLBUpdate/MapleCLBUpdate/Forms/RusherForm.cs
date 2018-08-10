using MapleCLBUpdate.MapleClient;
using MapleCLBUpdate.MapleClient.Functions;
using MapleCLBUpdate.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapleCLBUpdate.Forms{
    public partial class RusherForm : Form{
        private Client client;

        public RusherForm(){
            InitializeComponent();
        }

        public void SetClient(Client client){
            this.client = client;
        }

        public void Update(int srcMap){
            RushTree.Nodes.Clear();

            List<int> reachable = MapRusher.Reachable(srcMap);
            foreach (int map in reachable)
            {
                string[] names;
                if (!Maps.Names.TryGetValue(map, out names)){
                    continue;
                }

                if (!RushTree.Nodes.ContainsKey(names[0]))
                {
                    RushTree.Nodes.Add(names[0], names[0]);
                }
                RushTree.Nodes[names[0]].Nodes.Add($"{map}: {names[1]}");
            }
            MapStatus.Text = $"{srcMap}";
            SetEnabled(true);
        }

        private void RushTree_MouseDoubleClick(object sender, MouseEventArgs e){
            if (RushTree.SelectedNode == null || RushTree.SelectedNode.Level <= 0)
            {
                return;
            }

            SetEnabled(false);
            //TODO: Fix ghetto parse on dst
            int src = int.Parse(MapStatus.Text);
            int dst = int.Parse(RushTree.SelectedNode.Text.Split(':')[0]);
            client.MapRush.Report(MapRusher.Pathfind(src, dst));
            Update(dst);
        }

        private void SetEnabled(bool enabled){
            RushTree.Enabled = enabled;
            RushList.Enabled = enabled;
        }


    }
}
