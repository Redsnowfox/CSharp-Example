﻿using MapleCLBUpdate.Packets;
using MapleCLBUpdate.Packets.Send;
using MapleCLBUpdate.ScriptLib;
using MapleCLBUpdate.Types.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MapleCLBUpdate.MapleClient.Scripts
{
    internal sealed class NewFarmScript : UserScript
    {
        public NewFarmScript(Client client) : base(client) { }

        protected override void Init()
        {
        }

        protected override void Execute(CancellationToken token)
        {
            Mob oldMob = null;
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
                int attackCount = 1;
                while (client.State == ClientState.GAME) {
                    //if (attackCount > 10)
                    //    break;
                    if (client.Map.Mobs.Count != 0)
                    {
                        //var mob = client.Map.Mobs.ElementAt(r.Next(0, client.Map.Mobs.Count)).Value;
                        var mob = client.Map.Mobs.First().Value;
                        if (mob.waitForAck)
                        {
                            Console.WriteLine("Mob failed to ack before...Despawning");
                            client.Account.info.missCount++;
                            client.Map.DespawnMob(mob.Id);
                            continue;
                        }
                        else
                        {
                            mob.waitForAck = true;
                        }
                        //Spawn a new summon
                        //if (client.Map.Summons.Count == 0){
                        //client.SendPacket(Attack.MonkeyStrike(client, mob, attackCount));
                        //await client.PutTaskDelay(300);
                        //client.SendPacket(Attack.MonkeyAnother(client, attackCount));
                        //await client.PutTaskDelay(300);

                        /*
                        if (client.Account.info.missCount > 20 || attackCount > 150)
                        {
                            await client.PutTaskDelay(4000);
                            Console.WriteLine("Auto CS Time!");
                            client.SendPacket(General.EnterCS());
                            client.State = ClientState.CASHSHOP;
                            client.Account.info.missCount = 0;
                            attackCount = 0;
                            await client.PutTaskDelay(1000);
                            continue;
                            //client.SendPacket(Attack.MonkeyAnother(client, attackCount ));
                            //await client.PutTaskDelay(500);
                        }
                        */

                        Console.WriteLine("Attacking.." + attackCount);
                        client.SendPacket(Attack.BallHur(client, mob));
                        await client.PutTaskDelay(400);

                        if (attackCount % 20 == 0)
                        {
                            client.SendPacket(Familiar.Summon(9960098));
                            await client.PutTaskDelay(50);
                            client.SendPacket(Familiar.Skill(9960098));
                            client.SendPacket(Familiar.Skill(9960098));
                            client.SendPacket(Familiar.Skill(9960098));
                            client.SendPacket(Familiar.Skill(9960098));
                        }

                        /*if (mob != oldMob)
                        {
                            await client.PutTaskDelay(730); //500 = ban for this skill.
                            Console.WriteLine("New Mob..");
                        }
                        else if (mob == oldMob)
                            await client.PutTaskDelay(100); //500 = ban for this skill.
                        else
                        {
                            Console.WriteLine("Fail Safe..!");
                            await client.PutTaskDelay(860); 
                        }
                        oldMob = mob;
                        */
                        //var summon = client.Map.Summons.First().Value;
                        //client.SendPacket(Attack.charmLatch(mob, summon));
                        //client.SendPacket(Attack.KannaSkill(client, null));
                        //await client.PutTaskDelay(100);
                        //client.SendPacket(Attack.CharmAttack(client, mob, summon));
                        //client.Map.DespawnSummons(summon.Id);
                        //await client.PutTaskDelay(1000);
                        attackCount++;
                        //}
                        //}
                        //else
                        //{
                            //var summon = client.Map.Summons.First().Value;
                            //client.SendPacket(Attack.KishinAttack(client, mob, summon));
                            //attackCount++;
                            //await client.PutTaskDelay(1000);
                        //}
                    }

                }
                /*    
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
                        }
                    }
                }
                */

            }).Start();

        }
    }
}
