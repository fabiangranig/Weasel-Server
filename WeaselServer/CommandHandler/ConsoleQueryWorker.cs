using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeaselServer.CommandHandler.Resolvers;
using WeaselServer.General;
using WeaselServer.Logger;

namespace WeaselServer.CommandHandler
{
    internal class ConsoleQueryWorker
    {
        public static void PickHandler(string command)
        {
            //Break command into parts
            string[] split_string = StringManipulation.GetSpaceSplitString(command);

            //Send command to Resolver
            switch (split_string[0])
            {
                case "help":
                    HelpResolver.ConsoleOutputHelpMenu();
                    LoggerWorker.LogText("Showed help text.");
                    break;

                default:
                    NotFoundResolver.ConsoleOutputNotFound(command);
                    LoggerWorker.LogText("Command '" + command + "' not found.");
                    break;
            }
        }
    }
}