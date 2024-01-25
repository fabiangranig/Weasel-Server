using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public static void AddMovement(KukaAction K_Action)
        {
            _KH.AddItem(K_Action);
        }

        public static List<int> ReturnFinsihedList()
        {
            return _KH.ResolvedActions;
        }

        public static void SetVirtualMode()
        {
            _KH.VirtualMode();
        }

        public static void SetRealMode()
        {
            _KH.RealMode();
        }
    }
}
