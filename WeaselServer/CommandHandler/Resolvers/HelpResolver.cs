using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaselServer.CommandHandler.Resolvers
{
    internal class HelpResolver
    {
        public static void ConsoleOutputHelpMenu()
        {
            //Output the help menu
            Console.WriteLine("help -> Shows help menu");
            Console.WriteLine("weasel move [id] [position] -> Moves weasel with corresponding id to entered positon");
        }
    }
}
