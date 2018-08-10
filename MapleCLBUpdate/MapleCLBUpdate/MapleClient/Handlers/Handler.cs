using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleCLBUpdate.MapleClient.Handlers{
    internal abstract class Handler<T>{
        protected Client client;

        protected Handler(Client client){
            this.client = client;
        }

        protected void SendPacket(params byte[] packet){
            client.SendPacket(packet);
        }

        internal abstract void Handle(object o1, T o2);
    }
}
