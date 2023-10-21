using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaselServer.WeaselControllerBackend.Map
{
    internal class DestinationInformation
    {
        private string _SendBy;
        private string _ActionBeforeMovement;
        private int _Destination;
        private string _ActionAfterMovement;

        public string SendBy { get { return _SendBy; } }
        public string ActionBeforeMovement {  get { return _ActionBeforeMovement; } }
        public int Destination { get { return _Destination; } }
        public string ActionAfterMovement { get { return _ActionAfterMovement; } }

        public DestinationInformation(string SendBy, string ActionBeforeMovement, int Destination, string ActionAftermovement)
        {
            this._SendBy = SendBy;
            this._ActionBeforeMovement = ActionBeforeMovement;
            this._Destination = Destination;
            this._ActionAfterMovement = ActionAftermovement;
        }
    }
}
