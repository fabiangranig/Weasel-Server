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
        private List<KukaAction> _KukaActions;
        private List<int> _ResolvedAction;

        public List<int> ResolvedActions { get { return _ResolvedAction; } }

        public KukaHandler()
        {
            _KR = new KukaRoboter();
            _ResolvedAction = new List<int>();

            _KukaActions = new List<KukaAction>();
            _Thread = new Thread(KukaThread);
            _Thread.Name = "KukaThread";
            _Thread.Start();
        }

        private void KukaThread()
        {
            while(1 == 1)
            {
                //Send Command if possible
                if(_KukaActions.Count > 0)
                {
                    _KR.MoveKukaWithFile(_KukaActions[0].Movement);
                    _ResolvedAction.Add(_KukaActions[0].ID);
                    _KukaActions.RemoveAt(0);
                }

                //Wait for next iteration
                Thread.Sleep(1000);
            }
        }

        public void AddItem(KukaAction K_Action)
        {
            _KukaActions.Add(K_Action);
        }

        public void RealMode()
        {
            _KR.SwitchRealMode();
            SPSClaw.SetOnlineMode(true);
        }
    }
}
