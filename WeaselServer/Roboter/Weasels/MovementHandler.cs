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
                if(_Weasel[_WeaselID].Destinations.Count > 0)
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
            //If there was an issue set the weasel to the real last position
            _Weasel[_WeaselID].RenewSetLastPosition();

            while (_Weasel[_WeaselID].LastPosition != destination)
            {
                //Add an sleep timer to prevent performence issues when waiting
                Thread.Sleep((_WeaselID + 1) * 50);

                //Get the next possible movement
                int[] next_route = GetNextPossibleRadiusRoute(destination);

                //Move to last possible route option
                MapHandler.ReserveArr(next_route, _Weasel[_WeaselID].Coloring);
                _Weasel[_WeaselID].WeaselMove(next_route[next_route.Length - 1]);

                //Wait for Position Change
                while(1 == 1)
                {
                    if(next_route.Length == 0 || next_route.Length == 1)
                    {
                        Thread.Sleep(5000);
                        break;
                    }

                    if(next_route[next_route.Length/2] == _Weasel[_WeaselID].LastPosition)
                    {
                        break;
                    }

                    Thread.Sleep(10);
                }

                //Unreserve when that move is finished
                int[] next_route_unreserve = IntManipulation.ArrayMinusOneSearchedItem(next_route, _Weasel[_WeaselID].LastPosition);
                MapHandler.UnreserveArr(next_route_unreserve);
                MapHandler.Reserve(_Weasel[_WeaselID].LastPosition, _Weasel[_WeaselID].Coloring);
            }
        }

        private int[] GetNextPossibleRadiusRoute(int destination)
        {
            int[] waypoint = MapResolver.FreePath(_Weasel[_WeaselID].LastPosition, destination, _Weasel[_WeaselID].Coloring);
            int[] waypoint_possible = MapResolver.possibleRoute(waypoint, _Weasel[_WeaselID].Coloring);
            return MapResolver.RadiusRoute(waypoint_possible);
        }

        private int CheckPositionInArrayIndex(int[] array, int number)
        {
            //Get where this number is located
            int location = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == number)
                {
                    location = i;
                    break;
                }
            }

            //Return the index
            return location;
        }
    }
}
