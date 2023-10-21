using System;
using System.Collections.Generic;
using System.Drawing;
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

        public static string ShowMap()
        {
            return _Map.ToString();
        }

        public static string ShowMapJSON()
        {
            return _Map.ToJSON();
        }

        public static void Reserve(int id, Color color)
        {
            _Map.Reserve(id, color);
        }
    }
}
