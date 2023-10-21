using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeaselServer.CommandHandler.Handlers;

namespace WeaselServer.CommandHandler.Resolvers
{
    internal class MapResolver
    {
        public static string ShowMap()
        {
            return MapHandler.ShowMap();
        }

        public static string ShowMapJSON()
        {
            return MapHandler.ShowMapJSON();
        }
    }
}
