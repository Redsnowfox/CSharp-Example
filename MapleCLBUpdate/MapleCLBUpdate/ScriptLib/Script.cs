using MapleCLBUpdate.MapleClient;
using MapleLib.Packet;
using SharedTools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MapleCLBUpdate.ScriptLib
{
    public abstract class Script
    {
        private readonly List<ushort> headers = new List<ushort>();

        private int refs;
        protected Client client;
        protected bool running;

        protected Script(Client client)
        {
            this.client = client;
        }

        #region Script Commands
        public virtual bool Start()
        {
            return Start(Run);
        }

        public virtual void Stop()
        {
            Interlocked.Decrement(ref refs);
            if (refs == 0)
            {
                headers.ForEach(d => client.RemoveScriptRecv(d));
                headers.Clear();
                running = false;
            }
        }

        private void Run()
        {
            try
            {
                Init();
            }
            catch (InvalidOperationException ex)
            {
                Debug.WriteLine($"Error running {GetType().Name}.  Terminated.");
                Debug.WriteLine(ex.ToString());
            }
        }
        #endregion

        protected bool Start(Action run)
        {
            Interlocked.Increment(ref refs);
            if (running)
            {
                return false;
            }
            running = true;
            Debug.WriteLine($"[SCRIPT] Started {GetType().Name}.");
            run();
            return true;
        }

        #region Scripting Functions
        protected void SendPacket(byte[] packet)
        {
            client.SendPacket(packet);
        }

        protected void SendPacket(PacketWriter w)
        {
            client.SendPacket(w);
        }

        protected void RegisterRecv(ushort header, Action<Client, PacketReader> handler)
        {
            Precondition.Check<InvalidOperationException>(client.AddScriptRecv(header, handler),
                $"Failed to register header {header:X4}.");
            headers.Add(header);
        }

        protected void UnregisterRecv(ushort header)
        {
            headers.Remove(header);
            client.RemoveScriptRecv(header);
        }

        protected abstract void Init();
        #endregion
    }
}
