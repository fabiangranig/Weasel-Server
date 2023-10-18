using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaselServer.CommandHandler.Resolvers
{
    internal class NotFoundResolver
    {
        public static void ConsoleOutputNotFound(string command)
        {
            //Output the help menu
            Console.WriteLine("Command '" + command + "' not found.");
        }
    }
}
