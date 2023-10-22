using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WeaselServer.CommandHandler.Resolvers;
using WeaselServer.Roboter;

namespace WeaselServer.Roboter.Weasels.WeaselTypes
{
    internal class VirtualWeasel : Weasel
    {
        private Thread _MoveByTick;
        private List<int> _Moves;

        public VirtualWeasel(string Name1, bool _Online1, int ID1, bool HasBox1, int BatteryPercentage1, int LastPosition1,
            int HomePosition1, Color Color1, int ColorNumber1) : base(ID1, HasBox1, BatteryPercentage1, LastPosition1,
            HomePosition1, Color1, ColorNumber1, Name1,
            _Online1)
        {
            _Moves = new List<int>();
            _MoveByTick = new Thread(MoveByTickExecute);
            _MoveByTick.Name = "OfflineMover";
            _MoveByTick.Start();
        }

        private void MoveByTickExecute()
        {
            while(1 == 1)
            {
                //Move to next position
                if(_Moves.Count > 0)
                {
                    _LastPosition = _Moves[0];
                    _Moves.RemoveAt(0);
                }

                //Wait for next action
                Thread.Sleep(1000);
            }
        }

        public override void WeaselMove(int position)
        {
            int[] route = MapResolver.FreePath(_LastPosition, position, _Color);

            _Moves.Clear();

            for (int i = 0; i < route.Length; i++)
            {
                _Moves.Add(route[i]);
            }
        }
    }
}
