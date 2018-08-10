using MapleCLBUpdate.MapleClient;
using MapleCLBUpdate.Types;
using MapleLib.Packet;
using SharedTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MapleCLBUpdate.Packets.Recv.Connection
{
    internal static class Login
    {
        internal static void LoginInfo(Client c, PacketReader r)
        {
            switch (r.ReadByte())
            {
                case 0x00:
                    r.Skip(4);//AccountID
                    r.Skip(1);//nGender
                    r.Skip(1);//nGradeCode
                    r.Skip(4);//nAccountFlags 
                    r.Skip(4);//nVIPGrade
                    //r.Skip(1);//Unknown
                    r.ReadMapleString();//sNexonClubID
                    r.Skip(1);//nPurchaseExp
                    r.Skip(1);//nChatBlockReason
                    r.Skip(8);//dtChatUnblockDate
                    r.ReadMapleString();//sEMailAccount
                    r.Skip(8);//dtRegisterDate
                    r.Skip(4);//nNumOfCharacter
                    c.Account.info.SessionId = r.ReadLong();
                    return;
                case 0x01:
                    c.Disconnect(false,0);
                    //c.Log.Report("Incorrect Password");
                    return;
                case 0x02:
                    c.Disconnect(false,0);
                    //c.Log.Report("Banned R.I.P");
                    break;
                case 0x07:
                    c.Disconnect(true, 120000);
                    Console.WriteLine("Already Logged In");
                    break;
                case 0x09:
                    c.Disconnect(false,0);
                    // End of file crash on real client
                    break;
                default:
                    c.Disconnect(false,0);
                    return;
            }
        }

        internal static void LoginStatus(Client c, PacketReader r){
            switch (r.ReadByte()){
                case 0x00:
                    break;
                case 0x02:
                    Console.WriteLine("Banned R.I.P");
                    c.Disconnect(false, 0);
                    break;
                case 0x01:
                    Console.WriteLine("Wrong Password!");
                    c.Disconnect(false, 0);
                    break;
                case 0x07:
                    Console.WriteLine("Already Logged In!");
                    c.Disconnect(true, 120000);
                    break;
            }
        }
        //This is pointless... UID is given in the second forloop statement..
        internal static void LoadCharlist(Client c, PacketReader r)
        {
            if (r.ReadBool())
            {
                Console.WriteLine("Failed to select world, Disconnecting");
                c.Disconnect(false, 0);
                return;
            }
            r.ReadMapleString();//sWorldType
            r.Skip(4);//nTrunkSlotCount
            r.Skip(1);//bBurningEventBlock
            int deleteCount = r.ReadInt();//nReservedDeleteCharacterCount
            r.Skip(8);//tTimeNow
            for (int i = 0; i < deleteCount; i++)
            {
                r.ReadInt();//dwReservedDeleteCharacterId
                r.ReadLong();//ftReservedDeleteCharacterTime
            }
            r.Skip(1);//bIsEditedList
            Dictionary<byte, int> charMap = new Dictionary<byte, int>();

            int count = r.ReadInt();//nCharacterSelectCount
            for (int i = 0; i < count; i++)
                charMap.Add((byte)i, r.ReadInt());

                //r.ReadInt();//dwCharacterId

            int characterCount = r.ReadByte();
            if (characterCount < 0)
            {
                Console.WriteLine("There are no characters!");
                return;
            }
            //MultiKeyDictionary<byte, string, int> charMap = new MultiKeyDictionary<byte, string, int>(); // slot/ign -> uid
            //for (byte i = 0; i < count; i++)
            //{
            //    /* Character Stats */
            //    var m = r.ReadMapler();
            //    /* Mapler Appearance */
            //    r.SkipAppearance(m);
            //    bool hasRank = r.ReadBool();
            //    if (hasRank)
            //    {
            //        r.Skip(16); // [Rank (4)] [Rank Move (4)] [JobRank (4)] [JobRank Move (4)]
            //    }
            //    if (m.IsZero)
            //    { // Zero
            //        for (int j = 0; j < 6; ++j)
            //        { // I guess Zero has 2 extra appearance?
            //            r.Next(0xFF);
            //        }
            //    }
            //    charMap.Add(i, m.Name.ToLower(), m.Id);
            //}
            try{
                //switch (c.Account.SelectMode){
                //    case SelectMode.SLOT:
                        byte n;
                        byte.TryParse(c.Account.Select, out n);
                        c.Account.info.UserId = charMap[--n];
                        //break;
                    //case SelectMode.NAME:
                    //    c.Account.info.UserId = charMap[c.Account.Select.ToLower()];
                    //    break;
                    //default:
                    //    throw new InvalidOperationException("Selection mode " + c.Account.SelectMode + " is not valid.");
                //}
            }catch{
                Console.WriteLine("Error selecting character!");
                c.Disconnect(false, 0);
            }
            c.SendPacket(Send.Login.SelectCharacter(c.Account));
        }

    }
}
