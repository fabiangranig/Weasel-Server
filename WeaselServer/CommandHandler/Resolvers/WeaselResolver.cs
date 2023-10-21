using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WeaselServer.CommandHandler.Handlers;
using WeaselServer.Roboter.Weasels;

namespace WeaselServer.CommandHandler.Resolvers
{
    internal class WeaselResolver
    {
        private static WeaselHandler _WeaselHandler;

        static WeaselResolver()
        {
            _WeaselHandler = new WeaselHandler();
        }

        public static void AddWeaselVirtual(string WeaselCreate)
        {
            _WeaselHandler.AddWeaselVirtual(WeaselCreate);
        }
    }
}
