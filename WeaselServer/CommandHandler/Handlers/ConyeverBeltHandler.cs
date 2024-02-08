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
using WeaselServer.Logger;

namespace WeaselServer.ConyeverBelt
{
    public class K_ConyeverBelt
    {
        private static Thread threader;
        private static Thread threader_virtual;
        private static bool ManualSensorTouch;

        static K_ConyeverBelt()
        {
            //Set static variables
            ManualSensorTouch = false;

            threader = new Thread(SendCommandIfSensorTouch);
            threader.Start();
            threader_virtual = new Thread(SendCommandIfSensorTouchVirtual);
            threader_virtual.Start();
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
                if(GetSensor("I510.1") == false)
                {
                    int FreeWeasel = SearchForWeaselNoBox();
                    if(FreeWeasel != -1)
                    {
                        WeaselResolver.AddDestination(FreeWeasel, new DestinationInformation("Console", "none", 41, "none"));
                        WeaselResolver.AddDestination(FreeWeasel, new DestinationInformation("Console", "none", 41, "Pickup"));
                        WeaselResolver.AddDestination(FreeWeasel, new DestinationInformation("Console", "none", WeaselResolver.GetHomePositionOfWeasel(FreeWeasel), "none"));
                        Thread.Sleep(5000);
                    }
                }
            }
        }

        private static void SendCommandIfSensorTouchVirtual()
        {
            while (1 == 1)
            {
                Thread.Sleep(10);
                if (ManualSensorTouch == true)
                {
                    int FreeWeasel = SearchForWeaselNoBox();
                    if (FreeWeasel != -1)
                    {
                        WeaselResolver.AddDestination(FreeWeasel, new DestinationInformation("Console", "none", 41, "none"));
                        WeaselResolver.AddDestination(FreeWeasel, new DestinationInformation("Console", "none", 41, "Pickup"));
                        WeaselResolver.AddDestination(FreeWeasel, new DestinationInformation("Console", "none", WeaselResolver.GetHomePositionOfWeasel(FreeWeasel), "none"));
                        Thread.Sleep(5000);
                    }
                }
            }
        }

        public static int SearchForWeaselNoBox()
        {
            for(int i = 0; i < WeaselResolver.GetWeaselCount(); i++)
            {
                if(WeaselResolver.GetWeaselBoxStatus(i) == false)
                {
                    //Give the weasel the task
                    return i;
                }
            }

            //When there was no free weasel found
            return -1;
        }

        public static bool GetSensor(string sensor)
        {
            try
            {
                using (Plc plc = new Plc(CpuType.S7300, "10.0.9.100", 0, 2))
                {
                    plc.Open();
                    while (1 == 1)
                    {
                        return (bool)plc.Read(sensor);
                    }
                }
            }
            catch(Exception e)
            {
                LoggerWorker.LogText("Getting conyever belt failed: " + e.ToString());
                return true;
            }
        }

        public static void ManualSensorTouchSwitch()
        {
            ManualSensorTouch = true;
            Thread.Sleep(1000);
            ManualSensorTouch = false;
        }
    }
}
