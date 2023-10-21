using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeaselServer.WeaselControllerBackend.Map;

namespace WeaselServer.CommandHandler.Handlers
{
    internal class MapHandler
    {
        private static Map _Map;

        static MapHandler()
        {
            txtParser _txtParser = new txtParser("map.txt");
            _Map = _txtParser.ParseToWeaselMap();
        }
    }
}
