using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WeaselServer.CommandHandler.Resolvers;
using WeaselServer.WeaselControllerBackend.Map;

namespace WeaselServer.Roboter.Weasels
{
    internal class MovementHandler
    {
        private int _WeaselID;
        private List<Weasel> _Weasel;
        private Thread _Mover;

        public MovementHandler(ref List<Weasel> weasel, int ID)
        {
            this._WeaselID = ID;
            this._Weasel = weasel;

            _Mover = new Thread(TryMove);
            _Mover.Name = "_MoverID_" + _WeaselID;
            _Mover.Start();
        }

        private void TryMove()
        {
            //Check if there is an move option
            while(1 == 1)
            {
                //Check if an Movement is possible
                if(_Weasel[_WeaselID].GetDestination() != null)
                {
                    EvaluateActions(_Weasel[_WeaselID].GetDestination());
                    _Weasel[_WeaselID].RemoveDestination();
                }

                //Check again after 200ms
                Thread.Sleep(200);
            }
        }

        private void EvaluateActions(DestinationInformation destinationInformation)
        {
            //Give the before Action to the resolver
            ActionResolver.ResolveAction(destinationInformation.ActionBeforeMovement);

            //Move the weasel


            //Give the after action to the resolver
            ActionResolver.ResolveAction(destinationInformation.ActionAfterMovement);
        }
    }
}
