using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using MapleCLBUpdate.MapleClient;
using MapleLib;
using MapleLib.Crypto;
using Newtonsoft.Json;
using SharedTools;

namespace MapleCLBUpdate
{
    static class Program
    {
        private static readonly byte[] userKey = { //195.1
            0x29, 0x00, 0x00, 0x00,
            0xF6, 0x00, 0x00, 0x00,
            0x18, 0x00, 0x00, 0x00,
            0x5E, 0x00, 0x00, 0x00,
            0xCA, 0x00, 0x00, 0x00,
            0x5A, 0x00, 0x00, 0x00,
            0x40, 0x00, 0x00, 0x00,
            0x61, 0x00, 0x00, 0x00
        };
        public static readonly IPAddress LoginIp = IPAddress.Parse("8.31.99.143");
        public static readonly short LoginPort = 8484;
        public static readonly AesCipher AesCipher = new AesCipher(userKey);
        public static readonly short gameVersion = 195;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());

        }

    }
}
