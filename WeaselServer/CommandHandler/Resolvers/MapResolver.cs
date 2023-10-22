using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeaselServer.CommandHandler.Handlers;
using WeaselServer.WeaselControllerBackend.Map;

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

        public static void Reserve(int id, Color color)
        {
            MapHandler.Reserve(id, color);
        }

        public static void UnReserve(int id)
        {
            MapHandler.UnReserve(id);
        }

        public static void ReserveArr(int[] positions, Color WeaselColor)
        {
            MapHandler.ReserveArr(positions, WeaselColor);
        }

        public static void UnreserveArr(int[] positions)
        {
            MapHandler.UnreserveArr(positions);
        }

        public static int[] FreePath(int start, int end, Color weasel_color)
        {
            return MapHandler.FreePath(start, end, weasel_color);
        }

        public static int[] possibleRoute(int[] route, Color weasel_color)
        {
            return MapHandler.possibleRoute(route, weasel_color);
        }

        public static int[] RadiusRoute(int[] arr)
        {
            return MapHandler.RadiusRoute(arr);
        }
    }
}
