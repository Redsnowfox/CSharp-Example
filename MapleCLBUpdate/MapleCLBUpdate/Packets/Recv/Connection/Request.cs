using MapleCLBUpdate.MapleClient;
using MapleCLBUpdate.Packets.Send;
using MapleLib.Crypto;
using MapleLib.Packet;
using System;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;


namespace MapleCLBUpdate.Packets.Recv.Connection
{
    internal class Request
    {
        public static void PingPong(Client c, PacketReader r)
        {
            c?.SendPacket(General.Pong());
        }

        public static void OpEncryption(Client c, PacketReader r)
        {
            byte[] aKey = new byte[24];
            string sCharacterID = c.Account.info.UserId.ToString();
            for (int i = 0; i < sCharacterID.Length; i++)
                aKey[i] = (byte)sCharacterID[i];

            //Find a better way
            var output = new SoapHexBinary(SoapHexBinary.Parse(c.Account.Hwid1.ToString("X")).Value.Reverse().ToArray()).ToString();
            String machineID = "00000000" + output;
            int count = 0;
            for (int i = sCharacterID.Length; i < 16; i++){
                aKey[i] = (byte)int.Parse(machineID.Substring(count, 2), NumberStyles.HexNumber);
                count += 2;
            }

            Array.Copy(aKey, 0, aKey, 16, 8);
            int nBlockSize = r.ReadInt();
            int bufferLength = r.ReadInt();
            byte[] aData = new byte[bufferLength];
            aData = r.ReadBytes(bufferLength);

            String sOpcode = TripleDESCipher.Decrypt(aData, aKey);

            int x = 0;
            for (int i = 0; i < 1156; i++){
                int temp = Int32.Parse(sOpcode.Substring(x, 4));
                c.EncryptedHeaders[i] = (ushort)temp;
                x += 4;
            }
        }
    }
}

