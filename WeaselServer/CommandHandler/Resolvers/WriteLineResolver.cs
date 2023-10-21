using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaselServer.CommandHandler.Resolvers
{
    internal class WriteLineResolver
    {
        public static void WriteLine(string ToWrite)
        {
            Console.WriteLine(ToWrite);
        }
    }
}
