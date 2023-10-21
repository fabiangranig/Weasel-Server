using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using WeaselServer.Roboter.Weasels;
using WeaselServer.Roboter.Weasels.WeaselTypes;

namespace WeaselServer.CommandHandler.Handlers
{
    internal class WeaselHandler
    {
        private List<Weasel> _Weasels;

        public WeaselHandler()
        {
            _Weasels = new List<Weasel>();
        }

        public void AddWeaselVirtual(string WeaselCreate)
        {
            string[] split = WeaselCreate.Split('-');
            _Weasels.Add(new VirtualWeasel(split[0], Convert.ToBoolean(split[1]), Int32.Parse(split[2]), Convert.ToBoolean(split[3]), Int32.Parse(split[4]), Int32.Parse(split[5]), 
                Int32.Parse(split[6]), Color.FromName(split[7]), Int32.Parse(split[8])));
        }
    }
}
