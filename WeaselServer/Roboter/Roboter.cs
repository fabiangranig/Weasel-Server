using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaselServer.Roboter
{
    internal class Roboter
    {
        protected string _Name;
        protected bool _Online;

        public Roboter(string Name1, bool _Online1)
        {
            this._Name = Name1;
            this._Online = _Online1;
        }
    }
}
