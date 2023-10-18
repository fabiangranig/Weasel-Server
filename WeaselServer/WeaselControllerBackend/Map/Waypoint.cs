using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaselServer.WeaselControllerBackend.Map
{
    internal class Waypoint
    {
        private int _PointID;
        private bool _Reserved;
        private Color _ReservedColor;
        private int _ReservedColorNumber;
        private List<Waypoint> _Next;

        public Waypoint(int number)
        {
            this._PointID = number;
            this._Reserved = false;
            this._ReservedColor = Color.LightGreen;
            this._ReservedColorNumber = 0;
        }
    }
}
