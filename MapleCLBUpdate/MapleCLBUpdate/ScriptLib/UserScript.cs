using MapleCLBUpdate.MapleClient;
using MapleLib.Packet;
using SharedTools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MapleCLBUpdate.ScriptLib
{
    [Synchronization(true)]
    public abstract class UserScript : Script
    {
        private readonly ScriptManager manager;
        private readonly HashSet<Script> dependencies = new HashSet<Script>();
        private readonly Blocking<PacketReader> reader = new Blocking<PacketReader>();
        private readonly AutoResetEvent waiter = new AutoResetEvent(false);
        private readonly CancellationTokenSource source = new CancellationTokenSource();

        protected UserScript(Client client) : base(client)
        {
            manager = client.ScriptManager;
            Precondition.NotNull(manager);
        }

        #region Script Commands
        public override bool Start()
        {
            return Start(Run);
        }

        public override void Stop()
        {
            source?.Cancel();
            base.Stop();
            foreach (var script in dependencies)
            {
                script.Stop();
            }
        }

        // Wakes up script that is waiting on any header
        public void Wake()
        {
            waiter.Set();
        }

        private void Run()
        {
            try
            {
                Init();
                Task.Run(() => Execute(source.Token), source.Token);
            }
            catch (InvalidOperationException ex)
            {
                Debug.WriteLine($"Error running {GetType().Name}.  Terminated.");
                Debug.WriteLine(ex.ToString());
            }
            manager.Release(GetType());
            running = false;
        }
        #endregion

        #region Scripting Functions
        // Returns 'null' if returnPacket is FALSE, else returns received packet
        protected PacketReader WaitRecv(ushort header, bool returnPacket = false)
        {
            client.WaitScriptRecv(header, reader, returnPacket);
            return reader.Get();
        }
        //TODO: WaitRecv with timeout?

        protected TScript Requires<TScript>() where TScript : Script
        {
            var script = manager.Get<TScript>();
            Precondition.Check<InvalidOperationException>(!(script is UserScript),
                "You cannot require a UserScript.");
            Precondition.Check<InvalidOperationException>(dependencies.Contains(script),
                $"{script.GetType().Name} is already a dependency.");
            script.Start(); // Make sure script is started
            dependencies.Add(script);

            return script;
        }

        protected abstract void Execute(CancellationToken token);
        #endregion
    }
}
