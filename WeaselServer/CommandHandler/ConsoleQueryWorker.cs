using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeaselServer.CommandHandler.Resolvers;
using WeaselServer.General;
using WeaselServer.Logger;
using WeaselServer.CommandHandler.Handlers;
using System.Drawing;

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

                case "weasel":
                    if (split_string[1] == "create")
                    {
                        if (split_string[2] == "virtual")
                        {
                            WeaselResolver.AddWeaselVirtual(split_string[3]);
                            LoggerWorker.LogText("Command: " + command);
                            break;
                        }
                    }
                    LoggerWorker.LogText("Command '" + command + "' not found.");
                    break;

                case "kuka":
                    if (split_string[1] == "move")
                    {
                        KukaResolver.AddMovement(split_string[2]);
                        LoggerWorker.LogText("Command: " + command);
                        break;
                    }
                    LoggerWorker.LogText("Command '" + command + "' not found.");
                    break;

                case "map":
                    if (split_string[1] == "show")
                    {
                        WriteLineResolver.WriteLine(MapResolver.ShowMap());
                        LoggerWorker.LogText("Command: " + command);
                        break;
                    }
                    if (split_string[1] == "reserve")
                    {
                        MapResolver.Reserve(Int32.Parse(split_string[2]), Color.FromName(split_string[3]));
                        LoggerWorker.LogText("Command: " + command);
                        break;
                    }
                    LoggerWorker.LogText("Command '" + command + "' not found.");
                    break;

                default:
                    NotFoundResolver.ConsoleOutputNotFound(command);
                    LoggerWorker.LogText("Command '" + command + "' not found.");
                    break;
            }
        }
    }
}