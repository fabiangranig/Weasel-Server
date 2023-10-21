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

        public static int[] FreePath(int start, int end, Color weasel_color)
        {
            return _Map.FreePath(start, end, weasel_color);
        }

        public static int[] possibleRoute(int[] route, Color weasel_color)
        {
            return _Map.possibleRoute(route, weasel_color);
        }

        public static int[] RadiusRoute(int[] arr)
        {
            return _Map.RadiusRoute(arr);
        }
    }
}
