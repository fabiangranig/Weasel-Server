using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WeaselServer.Logger;
using WeaselServer.Roboter.Kuka;

namespace WeaselServer.CommandHandler.Resolvers
{
    internal class ActionResolver
    {
        private static int _KukaActionID;

        static ActionResolver()
        {
            _KukaActionID = 0;
        }

        public static void ResolveAction(string command)
        {
            switch(command)
            {
                case "Pickup":
                    KukaAction K_Pickup = new KukaAction(_KukaActionID, "KukaMovements/MovementList_Pickup.kmf");
                    _KukaActionID += 1;
                    KukaResolver.AddMovement(K_Pickup);

                    //Wait for action to finish
                    bool switcher = false;
                    while(switcher == false)
                    {
                        //Get new list
                        List<int> FinishedActions = KukaResolver.ReturnFinsihedList();
                        for(int i = 0; i < FinishedActions.Count; i++)
                        {
                            if(K_Pickup.ID == FinishedActions[i])
                            {
                                switcher = true;
                            }
                        }

                        //Timeout before next action
                        Thread.Sleep(300);
                    }
                    break;

                default:
                    LoggerWorker.LogText("ResolveAction: " + command + "didn't work.");
                    break;
            }
        }
    }
}
