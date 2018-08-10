using SharedTools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleCLBUpdate.Types{
    public sealed class Account{
        private string username;
        public uint Hwid1 { get; private set; }
        public short Hwid2 { get; private set; }
        public string MacAddress { get; private set; }
        public string LocalSerials { get; private set; }
        public string passport { get; set; }

        public Info info { get; set; }

        public string Username
        {
            get { return username; }
            set
            {
                info = new Info();
                var rng = new Random(value.GetHashCode());
                var temp = rng.Next();
                Hwid1 = (uint)rng.Next();
                Hwid1 = (uint)rng.Next();
                Hwid2 = (short)rng.Next();

                byte[] macBuffer = new byte[6];
                rng.NextBytes(macBuffer);
                // XX-XX-XX-XX-XX-XX
                MacAddress = macBuffer.ToHexString('-');

                byte[] hwidBuffer1 = new byte[6];
                byte[] hwidBuffer2 = new byte[4];
                rng.NextBytes(hwidBuffer1);
                rng.NextBytes(hwidBuffer2);
                // XXXXXXXXXXXX_XXXXXXXX
                LocalSerials = hwidBuffer1.ToHexString() + '_' + hwidBuffer2.ToHexString();

                username = value;
            }
        }

        public string Password { get; set; }
        public string Pic { get; set; }
        public byte Mode { get; set; }
        public string Select { get; set; }

        public byte World { get; set; }
        public byte Channel { get; set; }

        public Account() { }

        public Account(BinaryReader br)
        {
            Username = br.ReadString();
            Password = br.ReadString();
            Pic = br.ReadString();
            Mode = br.ReadByte();
            Select = br.ReadString();
            World = br.ReadByte();
            Channel = br.ReadByte();
        }

        public void WriteTo(BinaryWriter bw)
        {
            bw.Write(Username);
            bw.Write(Password);
            bw.Write(Pic);
            bw.Write((byte)Mode);
            bw.Write(Select);
            bw.Write(World);
            bw.Write(Channel);
        }
    }
}
