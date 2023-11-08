using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaselServer.CommandHandler.Resolvers
{
    internal class EE_Resolver
    {
        public static void EE_Run()
        {
            string key = "WW91IGZvdW5kIHRoZSBlYXN0ZXJlZWdnIQ==";
            Console.WriteLine(RunKey(key));
        }

        private static string RunKey(string key)
        {
            byte[] bytes = Convert.FromBase64String(key);
            return System.Text.Encoding.UTF8.GetString(bytes);
        }
    }
}
