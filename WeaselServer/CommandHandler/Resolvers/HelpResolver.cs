using System;
using System.Collections.Generic;
using System.Drawing;
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
            Console.WriteLine("kuka move <file> -> Moves Kuka like file");
            Console.WriteLine("weasel create virtual Name(string)-Online(Boolean)-HasBox(Boolean)-BatteryPercentage(INT)-" +
                "LastPositon(INT)-HomePosition(INT)-Color(string)-ColorNumber(INT) -> Creates virtual Weasel");
            Console.WriteLine();
            Console.WriteLine("weasel create real Name(string)-Online(Boolean)-HasBox(Boolean)-BatteryPercentage(INT)-" +
                "LastPositon(INT)-HomePosition(INT)-Color(string)-ColorNumber(INT) -> Creates virtual Weasel");
            Console.WriteLine();
            Console.WriteLine("map show -> shows map");
            Console.WriteLine("map reserve <id> <color>");
            Console.WriteLine("weasel show -> displays all existing weasels");
            Console.WriteLine("weasel move <weaselid> <action:destination:action>");
        }
    }
}
