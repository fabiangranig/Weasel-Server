using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using WeaselServer.Roboter.Weasels;
using WeaselServer.Roboter.Weasels.WeaselTypes;
using WeaselServer.WeaselControllerBackend.Map;

namespace WeaselServer.CommandHandler.Handlers
{
    internal class WeaselHandler
    {
        private List<Weasel> _Weasels;
        private WeaselMovementHandler _WeaselsMovement;
        public WeaselHandler()
        {
            _Weasels = new List<Weasel>();
        }

        public void AddWeaselVirtual(string WeaselCreate)
        {
            string[] split = WeaselCreate.Split('-');
            _Weasels.Add(new VirtualWeasel(split[0], Convert.ToBoolean(split[1]), _Weasels.Count, Convert.ToBoolean(split[2]), Int32.Parse(split[3]), Int32.Parse(split[4]), 
                Int32.Parse(split[5]), Color.FromName(split[6]), Int32.Parse(split[7])));

            //Add an movement handler to the weasel
            

            //Reserve the point of the weasel
            //Reserve the current position
            MapHandler.Reserve(_Weasels[_Weasels.Count - 1].LastPosition, _Weasels[_Weasels.Count -1].Color);
        }

        public string ListWeasels()
        {
            string result = "";
            for(int i = 0; i < _Weasels.Count; i++)
            {
                result += _Weasels[i].ID + " -> " + _Weasels[i].Name;

                if(i < _Weasels.Count - 1)
                {
                    result += "\n";
                }
            }
            return result;
        }

        public void AddDestination(int WeaselID, DestinationInformation Destination)
        {
            _Weasels[WeaselID].AddDestination(Destination);
        }
    }
}
