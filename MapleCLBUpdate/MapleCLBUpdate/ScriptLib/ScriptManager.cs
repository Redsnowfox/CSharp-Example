using MapleCLBUpdate.MapleClient;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapleCLBUpdate.ScriptLib
{
    public class ScriptManager{
        private readonly Client client;
        private readonly ConcurrentDictionary<Type, Lazy<Script>> scripts;

        public ScriptManager(Client client){
            scripts = new ConcurrentDictionary<Type, Lazy<Script>>();
            this.client = client;
        }

        public TScript Get<TScript>() where TScript : Script{
            var k = typeof(TScript);

            return (TScript)scripts.GetOrAdd(k,
                t => new Lazy<Script>(() => (TScript)Activator.CreateInstance(t, client))).Value;
        }

        public void Release(Type t){
            Lazy<Script> trash;
            scripts.TryRemove(t, out trash);
        }
    }
}

