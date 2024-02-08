using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WeaselServer.CommandHandler.Handlers;
using WeaselServer.Roboter.Weasels;
using WeaselServer.WeaselControllerBackend.Map;

namespace WeaselServer.CommandHandler.Resolvers
{
    internal class WeaselResolver
    {
        private static WeaselHandler _WeaselHandler;

        static WeaselResolver()
        {
            _WeaselHandler = new WeaselHandler();
        }

        public static void AddWeaselVirtual(string WeaselCreate)
        {
            _WeaselHandler.AddWeaselVirtual(WeaselCreate);
        }

        public static void AddWeaselReal(string WeaselCreate)
        {
            _WeaselHandler.AddWeaselReal(WeaselCreate);
        }

        public static void GetPositionOfWeasel(int WeaselID)
        {
            _WeaselHandler.GetPositionOfWeasel(WeaselID);
        }

        public static bool GetWeaselBoxStatus(int WeaselID)
        {
            return _WeaselHandler.GetBoxStatusOfWeasel(WeaselID);
        }

        public static void DisplayWeasels()
        {
            WriteLineResolver.WriteLine(_WeaselHandler.ListWeasels());
        }

        public static void AddDestination(int WeaselID, DestinationInformation Destination)
        {
            Destination.WeaselID = WeaselID;
            _WeaselHandler.AddDestination(WeaselID, Destination);
        }

        public static string WeaselsToJSON()
        {
            return _WeaselHandler.WeaselsToJSON();
        }

        public static int GetWeaselCount()
        {
            return _WeaselHandler.GetWeaselCount();
        }

        public static int GetHomePositionOfWeasel(int WeaselID)
        {
            return _WeaselHandler.GetHomePositionOfWeasel(WeaselID);
        }
    }
}
