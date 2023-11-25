using S7.Net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using WeaselServer.CommandHandler.Resolvers;
using WeaselServer.WeaselControllerBackend.Map;
using WeaselServer.CommandHandler;

namespace WeaselServer.ConyeverBelt
{
    public class K_ConyeverBelt
    {
        private static Thread threader;

        static K_ConyeverBelt()
        {
            threader = new Thread(SendCommandIfSensorTouch);
            threader.Start();
        }

        public static void StartConveyerBelt()
        {
            WriteLineResolver.WriteLine("Started conveyer belt...");
        }

        private static void SendCommandIfSensorTouch()
        {
            while(1 == 1)
            {
                Thread.Sleep(10);
                if(GetSensor() == false)
                {
                    WeaselResolver.AddDestination(0, new DestinationInformation("Console", "none", 41, "Pickup"));
                    WeaselResolver.AddDestination(0, new DestinationInformation("Console", "none", 39, "none"));
                    Thread.Sleep(10000);
                }
            }
        }

        private static bool GetSensor()
        {
            using (Plc plc = new Plc(CpuType.S7300, "10.0.9.100", 0, 2))
            {
                plc.Open();
                while (1 == 1)
                {
                    return (bool)plc.Read("I510.1");
                }
            }
        }
    }
}
