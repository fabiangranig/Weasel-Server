using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeaselServer.CommandHandler.Handlers;
using WeaselServer.Roboter.Kuka;

namespace WeaselServer.CommandHandler.Resolvers
{
    internal class KukaResolver
    {
        private static KukaHandler _KH;

        static KukaResolver()
        {
            _KH = new KukaHandler();
        }

        public static void AddMovement(string item)
        {
            _KH.AddItem(item);
        }
    }
}
