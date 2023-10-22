using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WeaselServer.CommandHandler.Handlers;
using WeaselServer.CommandHandler.Resolvers;
using WeaselServer.General;
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
            MoveWeasel(destinationInformation.Destination);

            //Give the after action to the resolver
            ActionResolver.ResolveAction(destinationInformation.ActionAfterMovement);
        }

        private void MoveWeasel(int destination)
        {
            while (_Weasel[_WeaselID].LastPosition != destination)
            {
                //Get the next possible movement
                int[] next_route = GetNextPossibleRadiusRoute(destination);

                //Move to last possible route option
                MapHandler.ReserveArr(next_route, _Weasel[_WeaselID].Coloring);
                _Weasel[_WeaselID].WeaselMove(next_route[next_route.Length - 1]);

                //Wait for Position Change
                while(CheckPositionInArray(next_route, _Weasel[_WeaselID].LastPosition) == -1)
                {
                    Thread.Sleep(200);
                }

                //Unreserve when that move is finished
                //Remove the last element before moving
                int[] next_route_unreserve = IntManipulation.ArrayMinusOne(next_route);
                MapHandler.UnreserveArr(next_route_unreserve);
            }
        }

        private int[] GetNextPossibleRadiusRoute(int destination)
        {
            int[] waypoint = MapResolver.FreePath(_Weasel[_WeaselID].LastPosition, destination, _Weasel[_WeaselID].Coloring);
            int[] waypoint_possible = MapResolver.possibleRoute(waypoint, _Weasel[_WeaselID].Coloring);
            return MapResolver.RadiusRoute(waypoint_possible);
        }

        private int CheckPositionInArray(int[] array, int number)
        {
            //Get where this number is located
            int location = 0;
            for(int i = 0; i < array.Length; i++)
            {
                if (array[i] == number)
                {
                    location = i;
                    break;
                }
            }

            //Return if it is in the upper or lower bound
            if(array.Length / 2 > location)
            {
                return -1;
            }
            if (array.Length / 2 < location)
            {
                return 1;
            }
            if (array.Length / 2 == location)
            {
                return 0;
            }

            //If there is an problem
            return 99;
        }
    }
}
