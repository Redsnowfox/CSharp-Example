using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleCLBUpdate.Types
{
    public sealed class Settings
    {
        public string Temp = "Settings to come...";

        public Settings() { }

        public Settings(BinaryReader br)
        {
            Temp = br.ReadString();
        }

        public void WriteTo(BinaryWriter bw)
        {
            bw.Write(Temp);
        }
    }
}
