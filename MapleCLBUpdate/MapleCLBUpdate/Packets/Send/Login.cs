using MapleCLBUpdate.Types;
using MapleLib.Packet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleCLBUpdate.Packets.Send{
    internal class Login{

        public static byte[] Validate(byte locale, short mapleversion, short subversion){
            var pw = new PacketWriter(SendOps.CLIENT_HELLO);
            pw.WriteByte(locale);
            pw.WriteShort(mapleversion);
            pw.WriteShort(subversion);
            pw.WriteZero(1);
            return pw.ToArray();
        }


        public static byte[] GetServers(){
            var pw = new PacketWriter(SendOps.GET_SERVERS);
            return pw.ToArray();
        }

        public static byte[] ClientLogin(Account account)
        {
            var pw = new PacketWriter(SendOps.SERVER_LOGIN);
            pw.WriteByte(1);//nGameStartMode
            pw.WriteMapleString(account.passport);//Auth
            //Hwid is acutally 16 bytes
            pw.WriteZero(4);
            pw.WriteUInt(account.Hwid1);//Hwid
            pw.WriteZero(6);//Hwid but fuck it
            pw.WriteShort(account.Hwid2);

            pw.WriteZero(4);
            pw.WriteByte(1);//nGameStartMode
            pw.WriteByte(account.World);
            pw.WriteByte(account.Channel);
            //Fix this below as you shouldnt reuse same local IP..
            pw.WriteInt(0);//Local IP Should randomize this..?
            return pw.ToArray();
        }

        public static byte[] SelectCharacter(Account account)
        {
            var pw = new PacketWriter(SendOps.CHAR_SELECT);
            pw.WriteMapleString(account.Pic);
            pw.WriteInt(account.info.UserId);
            pw.WriteBool(true);//Ofline mode = true
            pw.WriteMapleString(account.MacAddress);
            pw.WriteMapleString(account.LocalSerials);
            return pw.ToArray();
        }

        public static byte[] EnterServer(Account account){
            var pw = new PacketWriter(SendOps.PLAYER_LOGGEDIN);
            pw.WriteInt(account.World);
            pw.WriteInt(account.info.UserId);

            pw.WriteZero(4);
            pw.WriteUInt(account.Hwid1);//Hwid
            pw.WriteZero(6);//Hwid ..
            pw.WriteShort(account.Hwid2);

            pw.WriteByte(0);//bIsUserGM
            pw.WriteByte(0);//Unknown
            pw.WriteLong(account.info.SessionId);
            return pw.ToArray();
        }

    }
}
