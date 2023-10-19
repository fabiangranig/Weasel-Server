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
        public bool _Reserved;
        public Color _ReservedColor;
        private int _ReservedColorNumber;
        public List<Waypoint> _Next;

        public int PointID { get { return this._PointID; } }

        public Waypoint(int number)
        {
            this._PointID = number;
            this._Reserved = false;
            this._ReservedColor = Color.LightGreen;
            this._ReservedColorNumber = 0;
        }
    }
}
