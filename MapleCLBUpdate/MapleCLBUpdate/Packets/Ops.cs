using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleCLBUpdate.Packets
{
    /***************SEND**************
        PONG            - Client response to every PING
         * 
        CLIENT_HELLO    - Sent immediately after handshake (first time)
        SERVER_LOGIN    - Sent when selecting the channel
        CHAR_SELECT     - Sent after entering PIC
        PLAYER_LOGGEDIN - Sent immediately after handshake (rest of the time)
        GET_SERVERS     - Sending this causes server to respond with SERVERLIST
         * 
        CHANGE_MAP      - Sent when using portal or exiting cash shop
        CHANGE_CHANNEL  - Sent when changing channels
         * 
        ENTER_CASH_SHOP - Sent when entering cash shop
         * 
        MOVE_PLAYER     - Sent when moving player
         * 
        NPC_TALK        - Sent when first talking to a NPC
        NPC_TALK_MORE   - Send when continuing chat with NPC

        TRADE           - Send when opening a permit or trade
        USE_MUSHY       - Send when double clicking a mushroom in inventory
        BEFORE_MOVE     - Send before first MOVE_PLAYER [Header][TimeStamp]
         ********************************/

    internal static class SendOps
    {
        public const ushort
            /* login */
            CLIENT_HELLO = 0x67,
            SERVER_LOGIN = 0x6A,
            CHAR_SELECT = 0x6B,
            PLAYER_LOGGEDIN = 0x6E,
            PONG = 0x96,
            GET_SERVERS = 0x72,

            MOVE_BASE = 1,
            ENTER_PORTAL = MOVE_BASE,
            CHANGE_CHANNEL = MOVE_BASE + 1,
            ENTER_CASHSHOP = MOVE_BASE + 6,
            ENTER_AUCTIONHOUSE = MOVE_BASE + 7,
            MOVE_PLAYER = MOVE_BASE + 14,

            RUNE_REQUEST = 823,
            RUNE_LOCATION = 824,
            RUNE_KEY = 825,

            SUMMON_FAMILIAR = 650,
            FAMILIAR_SKILL = 712,

            SUMMON_MONKEY = 0x009F,
            SUMMON = 0x84,
            SUMMON_ATTACK = 0x01A1,
            SUMMON_LATCH = 0x01A3,
            STRIKE_ATTACK = 0x014,
            KANNA_ATTACK = 0x16;

        /* Movement */
        //MOVE_BASE = 0xB4,
        //ENTER_PORTAL = MOVE_BASE,
        //CHANGE_CHANNEL = MOVE_BASE + 0x01,
        //ENTER_STARWORLD = MOVE_BASE + 0x02,
        //ENTER_CASHSHOP = MOVE_BASE + 0x06,
        //ENTER_AUCTIONHOUSE = MOVE_BASE + 0x07,
        //MOVE_PLAYER = MOVE_BASE + 0x11,
        //SPECIAL_PORTAL = 0x0149,

        /* General */
        //ENABLE_ACTIONS = 0x0265,
        //HIT_REACTOR = 0x0390,
        //LOOT_ITEM = 0x038D,
        //DROP_ITEM = 0xF8,
        //DROP_MESO = 0x0142,
        //USE_ITEM = 0x00FD,
        //USE_TELEPORT_SCROLL = 0x0119,
        //FAMILIAR = 0x031B,
        //FAMILIAR_SUMMON = FAMILIAR + 0x01,
        //FAMILIAR_SKILL = 0x035B,
        //HYPER_TELE = 0xFE,//Not updated
        //RANGE_ATTACK = 0xCA,//Might be mele lol
        //MAGIC_ATTACK = 0xCC,
        //FLAME_ATTACK = 0x0296,

        /* Shopping */
        //USE_MUSHY = 0x00E1, //Not updated
        //TRADE = 0x0197,

        /* Mob */
        //MOVE_MOB_CLIENT = 0x036E,

        /* Chat */
        //GENERAL_CHAT = 0xD2,
        //WHISPER = 0x0195,

        //QUEST = 0x0152,

        /* NPC */
        //ENTER_MIRROR = 0x02FF,
        //NPC_SELL_ITEM = 0x00E7,
        //NPC_CHAT = 0x00E4,
        //NPC_CHAT_MORE = NPC_CHAT + 0x02;


    }

    internal static class GameConsts
    {

    }

    /*************RECEIVE************
    PING          - Sent by server, respond with PONG
     * 
    LOGIN_SECOND  - Received after PLAYER_LOGGEDIN (SERVER_LOGIN?)
    CHARLIST      - Received at character select screen
    SERVER_IP     - Received right before connecting to server (first time)
    CHANNEL_IP    - Received right before connecting to channel (rest of the time)
     * 
    SPAWN_PLAYER  - Received when player enters map or when you enter a new map
    REMOVE_PLAYER - Received when player leaves map
    FINISH_LOAD   - Received when client is done loading [HEADER] 
    CHAR_INFO     - Received when client loads Character/Map Info *Very Large Packet*

    LOAD_SEED    - Received when you login [HEADER][4 Bytes] (Not Zeros?)
    LOAD_MUSHY   - Received when client loads mushrooms in FM
    BLUE_POP     - Received when opening a Permit shop
    CLOSE_PERMIT - Received when someone closes a permit
    CLOSE_MUSHY  - Recieved when someone closes a mushroom
    ********************************/

    internal static class RecvOps
    {
        public const ushort
            /* server */
            LOGIN_INFO = 0x08,
            CHARLIST = 0x06,
            SERVER_IP = 0x07,
            LOGIN_STATUS = 0x00,
            CHANNEL_IP = 0x10,
            OP_ENCRYPTION = 0x28,
            PING = 0x11,

            //SERVERLIST = 0x01,

            /* player */
            CHAR_INFO = 0x01D9,
            CC_FAILED = 0x01DF,
            ATTACK_ACK = 0x041C,
            //UPDATE_INVENTORY = 0x49,
            UPDATE_STATUS = 0x68,
            //UPDATE_REACTOR = 0x03C4,
            //SPAWN_REACTOR = 0x0436,
            SEED = 0x01A5,
            SPAWN_SUMMON = 0x03EA,

            /* shop */
            //LOAD_MUSHY = 0x0420,
            //CLOSE_MUSHY = LOAD_MUSHY + 0x02,
            //CLOSE_PERMIT = 0x01F2,
            //UPDATE_SHOP = 0x04D6, 

            /* map */
            SPAWN_PLAYER = 0x023C,
            REMOVE_PLAYER = SPAWN_PLAYER + 0x01,
            //ALL_CHAT = SPAWN_PLAYER + 0x02,
            //SPAWN_ITEM = 0x0423,
            //REMOVE_ITEM = SPAWN_ITEM + 0x02,
            FINISH_LOAD = 0x005C,
            //SPAWN_NPC = 0x0408,
            //DESPAWN_NPC = SPAWN_NPC + 1,
            //CONTROL_NPC = 0x040B,
            //NPC_TALK = 0x02DE,//Not updated
            //NPC_SHOP = 0x0510,//Not updated

            /* Mob */
            MOB_BASE = 0x0407,
            SPAWN_MOB = MOB_BASE,
            REMOVE_MOB = MOB_BASE + 0x01,
            CONTROL_MOB = MOB_BASE + 0x02,
            MOVE_MOB_SERVER = MOB_BASE + 0x07,

            RUNE_RESPONSE = 0x031F,
            RUNE_IN_ACTION = 0x03A9,
            RUNE_INFO = 0x0513; 
    }
}
