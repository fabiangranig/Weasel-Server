using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace WeaselServer.Roboter
{
    internal class Weasel : Roboter
    {
        private int _ID;
        private bool _Online;
        private bool _HasBox;
        private int _BatteryProcentage;
        private int _BeforeLastPosition;
        private int _LastPosition;
        private int _LastDestinationReached;
        private int _HomePosition;
        private Color _Color;
        private int _ColorNumber;
    }
}
