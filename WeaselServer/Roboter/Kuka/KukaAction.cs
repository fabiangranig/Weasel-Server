using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaselServer.Roboter.Kuka
{
    internal class KukaAction
    {
        private int _ID;
        private string _Movement;

        public int ID { get { return _ID; } }
        public string Movement { get { return _Movement;} }

        public KukaAction(int id, string movement)
        {
            this._ID = id;
            this._Movement = movement;
        }
    }
}
