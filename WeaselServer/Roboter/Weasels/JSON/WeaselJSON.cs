using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeaselServer.WeaselControllerBackend.Map;

namespace WeaselServer.Roboter.Weasels.JSON
{
    internal class WeaselJSON
    {
        public string _Name;
        public bool _Online;
        public int _ID;
        public bool _HasBox;
        public int _BatteryProcentage;
        public int _LastPosition;
        public int _HomePosition;
        public string _Color;
        public int _ColorNumber;
        public string _Destinations;

        public WeaselJSON(string Name1, bool Online1, int ID1, bool HasBox1, int BatteryProcentage1, int LastPosition1, int HomePosition1, Color Color1, int ColorNumber1, List<DestinationInformation> Destinations1)
        {
            this._Name = Name1;
            this._Online = Online1;
            this._ID = ID1;
            this._HasBox = HasBox1;
            this._BatteryProcentage = BatteryProcentage1;
            this._LastPosition = LastPosition1;
            this._HomePosition = HomePosition1;
            this._Color = Color1.Name;
            this._ColorNumber = ColorNumber1;
            this._Destinations = BuildDestinationsToString(Destinations1);
        }

        private string BuildDestinationsToString(List<DestinationInformation> destinations)
        {
            string result = "";
            for(int i = 0; i < destinations.Count; i++)
            {
                result += destinations[i].ActionBeforeMovement + "-" + destinations[i].Destination + destinations[i].ActionAfterMovement;

                if(i < destinations.Count - 1)
                {
                    result += ":";
                }
            }
            return result;
        }
    }
}
