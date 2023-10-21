using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeaselServer.Logger;

namespace WeaselServer.CommandHandler.Resolvers
{
    internal class ActionResolver
    {
        public static void ResolveAction(string command)
        {
            switch(command)
            {
                case "Kuka1":
                    KukaResolver.AddMovement("KukaMovements/MovementList_Pickup.txt");
                    break;

                default:
                    LoggerWorker.LogText("ResolveAction: " + command + "didn't work.");
                    break;
            }
        }
    }
}
