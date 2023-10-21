using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WeaselServer.Roboter.Kuka;

namespace WeaselServer.CommandHandler.Handlers
{
    internal class KukaHandler
    {
        private KukaRoboter _KR;
        private Thread _Thread;
        private List<string> _MovementsLocations;

        public KukaHandler()
        {
            _KR = new KukaRoboter();
            _MovementsLocations = new List<string>();
            _Thread = new Thread(KukaThread);
            _Thread.Name = "KukaThread";
            _Thread.Start();
        }

        private void KukaThread()
        {
            while(1 == 1)
            {
                //Send Command if possible
                if(_MovementsLocations.Count > 0)
                {
                    _KR.MoveKukaWithFile(_MovementsLocations[0]);
                    _MovementsLocations.RemoveAt(0);
                }

                //Wait for next iteration
                Thread.Sleep(1000);
            }
        }

        public void AddItem(string item)
        {
            _MovementsLocations.Add(item);
        }
    }
}
