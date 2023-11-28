using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using WeaselServer.Roboter.Weasels;
using WeaselServer.Roboter.Weasels.WeaselTypes;
using WeaselServer.WeaselControllerBackend.Map;
using System.Drawing.Text;
using WeaselServer.CommandHandler.Resolvers;
using Newtonsoft.Json;
using WeaselServer.WeaselControllerBackend.JSON;
using WeaselServer.Roboter.Weasels.JSON;
using System.Threading;

namespace WeaselServer.CommandHandler.Handlers
{
    internal class WeaselHandler
    {
        private List<Weasel> _Weasels;
        private List<MovementHandler> _MovementHandler;

        public WeaselHandler()
        {
            _Weasels = new List<Weasel>();
            _MovementHandler = new List<MovementHandler>();
        }

        public void AddWeaselVirtual(string WeaselCreate)
        {
            string[] split = WeaselCreate.Split('-');

            //Check if name exists don't create the weasel
            bool name_exists = false;
            for(int i = 0; i < _Weasels.Count; i++)
            {
                if(split[0] == _Weasels[i].Name)
                {
                    name_exists = true;
                }
            }

            if(name_exists == false)
            {
                _Weasels.Add(new VirtualWeasel(split[0], Convert.ToBoolean(split[1]), _Weasels.Count, Convert.ToBoolean(split[2]), Int32.Parse(split[3]), Int32.Parse(split[4]),
                Int32.Parse(split[5]), Color.FromName(split[6])));

                //Add an movement handler to the weasel
                _MovementHandler.Add(new MovementHandler(ref _Weasels, _Weasels.Count - 1));

                //Reserve the point of the weasel
                //Reserve the current position
                MapHandler.Reserve(_Weasels[_Weasels.Count - 1].LastPosition, _Weasels[_Weasels.Count - 1].Coloring);
            }
            else if (name_exists == true)
            {
                WriteLineResolver.WriteLine("Weasel name is already existing.");
            }
        }

        public void AddWeaselReal(string WeaselCreate)
        {
            string[] split = WeaselCreate.Split('-');

            //Check if name exists don't create the weasel
            bool name_exists = false;
            for (int i = 0; i < _Weasels.Count; i++)
            {
                if (split[0] == _Weasels[i].Name)
                {
                    name_exists = true;
                }
            }

            if (name_exists == false)
            {
                _Weasels.Add(new RealWeasel(split[0], _Weasels.Count, Convert.ToBoolean(split[1]),
                Int32.Parse(split[2]), Color.FromName(split[3])));

                //Add an movement handler to the weasel
                _MovementHandler.Add(new MovementHandler(ref _Weasels, _Weasels.Count - 1));

                //Reserve the point of the weasel
                //Reserve the current position
                //Wait before issuing command
                Thread.Sleep(5000);
                MapHandler.Reserve(_Weasels[_Weasels.Count - 1].LastPosition, _Weasels[_Weasels.Count - 1].Coloring);
            }
            else if (name_exists == true)
            {
                WriteLineResolver.WriteLine("Weasel name is already existing.");
            }  
        }

        public string ListWeasels()
        {
            string result = "";
            for(int i = 0; i < _Weasels.Count; i++)
            {
                result += _Weasels[i].ID + " -> " + _Weasels[i].Name + " on " + _Weasels[i].LastPosition;

                if(i < _Weasels.Count - 1)
                {
                    result += "\n";
                }
            }
            return result;
        }

        public void AddDestination(int WeaselID, DestinationInformation Destination)
        {
            if(WeaselID < _Weasels.Count)
            {
                //Check before command
                if (_Weasels[WeaselID].HasBox == true)
                {
                    if(Destination.ActionBeforeMovement != "Pickup" && Destination.ActionAfterMovement != "Pickup")
                    {
                        _Weasels[WeaselID].AddDestination(Destination);
                    }
                    else
                    {
                        WriteLineResolver.WriteLine("Weasel has box.");
                    }
                }
                else
                {
                    _Weasels[WeaselID].AddDestination(Destination);
                }
            }
            else
            {
                WriteLineResolver.WriteLine("WeaselID doesn't exist.");
            }
        }

        public string WeaselsToJSON()
        {
            List<WeaselJSON> WeaselJSONs = new List<WeaselJSON>();
            for(int i = 0; i < _Weasels.Count; i++)
            {
                Weasel weasel = _Weasels[i];
                WeaselJSONs.Add(new WeaselJSON(weasel.Name, weasel.Online, weasel.ID, weasel.HasBox,
                    weasel.BatteryPercentage, weasel.LastPosition, weasel.HomePosition, weasel.Coloring,
                    weasel.Destinations));
            }
            return JsonConvert.SerializeObject(WeaselJSONs, Formatting.Indented);
        }
    }
}
