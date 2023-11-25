using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using WeaselServer.WeaselControllerBackend.Map;
using WeaselServer.CommandHandler.Handlers;
using System.Runtime.CompilerServices;
using WeaselServer.Logger;

namespace WeaselServer.Roboter.Weasels
{
    internal class Weasel : Roboter
    {
        protected int _ID;
        protected bool _HasBox;
        protected int _BatteryProcentage;
        protected int _LastPosition;
        protected int _HomePosition;
        protected Color _Color;
        protected List<DestinationInformation> _Destinations;

        public Weasel(int ID1, bool HasBox1, int BatteryPercentage1, int LastPosition1, 
            int HomePosition1, Color Color1, string Name1,
            bool _Online1) : base (Name1, _Online1) 
        {
            this._ID = ID1;
            this._HasBox = HasBox1;
            this._BatteryProcentage = BatteryPercentage1;
            this._LastPosition = LastPosition1;
            this._HomePosition = HomePosition1;
            this._Color = Color1;
            this._Destinations = new List<DestinationInformation>();
        }

        public int ID { get { return _ID; } }
        public bool HasBox { get { return _HasBox; } }
        public int BatteryPercentage { get { return _BatteryProcentage; } }
        public int LastPosition { get { return _LastPosition; } }
        public int HomePosition { get { return _HomePosition;} }
        public Color Coloring {  get { return _Color; } }
        public List<DestinationInformation> Destinations { get {  return _Destinations; } }

        public DestinationInformation GetDestination()
        {
            if(_Destinations.Count > 0)
            {
                return _Destinations[0];
            }
            return null;
        }

        public void RemoveDestination()
        {
            _Destinations.RemoveAt(0);
        }

        public void AddDestination(DestinationInformation Destination)
        {
            _Destinations.Add(Destination);
        }

        public virtual void WeaselMove(int position)
        {
            LoggerWorker.LogText("Calling non implemented Weasel! : Position " + position);
        }

        public virtual void RenewSetLastPosition()
        {
            this._LastPosition = _HomePosition;
        }
    }
}
