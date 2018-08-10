using MapleCLBUpdate.Packets;
using MapleCLBUpdate.Packets.Send;
using MapleCLBUpdate.ScriptLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MapleCLBUpdate.MapleClient.Scripts
{
    internal sealed class FarmScript : UserScript{
        public FarmScript(Client client) : base(client) { }

        protected override void Init(){
        }

        protected override void Execute(CancellationToken token){
            Console.WriteLine("Starting Script..");
            client.UpdateAction.Report("Farming");
            WaitRecv(RecvOps.FINISH_LOAD);
            Console.WriteLine("Finished Loading..");
            //Does this have to have a different thread?...
            new Thread(async () => {
                Random r = new Random();
                //Small start delay
                await client.PutTaskDelay(2000);
                //Make a trying to CC state
                while (client.State == ClientState.GAME)
                {
                    if (client.Account.info.killCount == 13)
                    {
                        //killcount = killcount + 13;
                        await client.PutTaskDelay(4000);
                        //Thread.Sleep(5000);
                        //Console.WriteLine("Ccing to: " + (client.Account.info.GrabNextCh()) + " Kill count: "+killcount);
                        Console.WriteLine("Auto CS Time!");
                        client.SendPacket(General.EnterCS());
                        client.State = ClientState.CASHSHOP;
                        //client.SendPacket(General.ChangeChannel(client, (byte)client.Account.info.GrabNextCh()));
                        //client.Account.info.killCount = 0;
                        //await client.PutTaskDelay(1000);
                        continue;
                    }
                    if (client.Map.Mobs.Count != 0)
                    {
                        var test = client.Map.Mobs.ElementAt(r.Next(0, client.Map.Mobs.Count)).Value;
                        if (test.waitForAck)
                        {
                            Console.WriteLine("Mob failed to ack before...Despawning");
                            client.Account.info.missCount++;
                            client.Map.DespawnMob(test.Id);
                            continue;
                        }
                        else
                        {
                            test.waitForAck = true;
                        }
                        Console.WriteLine("Going to attack: " + test.Id);
                        client.SendPacket(Attack.KannaSkill(client, test));
                        await client.PutTaskDelay(1200);
                        //This might not be needed!
                        if (client.Account.info.missCount > 20)
                        {
                            Console.WriteLine("Missing to much! Going to CS!");
                            await client.PutTaskDelay(4000);
                            client.SendPacket(General.EnterCS());
                            client.State = ClientState.CASHSHOP;
                            //client.SendPacket(General.ChangeChannel(client, (byte)client.Account.info.GrabNextCh()));
                            //client.Disconnect();
                        }
                    }
                }
            }).Start();

        }
    }
}
