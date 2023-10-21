using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeaselServer.WeaselControllerBackend.JSON;

namespace WeaselServer.WeaselControllerBackend.Map
{
    internal class Map
    {
        private Waypoint _Head;
        private List<int[]> _CombinedNodes;

        public Map()
        {
            _Head = null;
            _CombinedNodes = new List<int[]>();
        }

        public void AddNodeToNumber(Waypoint waypoint1, int id1)
        {
            if (_Head == null)
            {
                _Head = waypoint1;
                return;
            }

            MapBackend.AddNodeToNumberBackend(_Head, waypoint1, id1);
        }

        public Waypoint FindWayPoint(int id1)
        {
            return MapBackend.FindWayPointBackend(_Head, id1);
        }

        public Waypoint FindWayPointBeforeNumber(int id1)
        {
            return MapBackend.FindWayPointBackendBeforeNumberBackend(_Head, id1);
        }

        public void Reserve(int id, Color color1)
        {
            Waypoint temp = FindWayPoint(id);
            temp._Reserved = true;
            temp._ReservedColor = color1;
        }

        public void UnReserve(int id)
        {
            Waypoint temp = FindWayPoint(id);
            temp._Reserved = false;
            temp._ReservedColor = Color.LightGreen;
        }

        public void ReserveArr(int[] arr, Color color1)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Reserve(arr[i], color1);
            }
        }

        public void UnReserveArr(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                UnReserve(arr[i]);
            }
        }

        public List<string> ShowMap()
        {
            Waypoint temp = _Head;
            List<string> points = new List<string>();
            ShowMapBackend(temp, ref points);
            points.Sort();
            return points;
        }

        private void ShowMapBackend(Waypoint way, ref List<string> points)
        {
            string toAdd = way.PointID + " " + way._Reserved + " " + way._ReservedColor.Name;
            if (way._Next == null)
            {
                if (!points.Contains(toAdd))
                {
                    points.Add(toAdd);
                }
                return;
            }

            if (!points.Contains(toAdd))
            {
                points.Add(toAdd);
            }

            for (int i = 0; i < way._Next.Count; i++)
            {
                ShowMapBackend(way._Next[i], ref points);
            }
        }

        //Returns all information seperated by \n
        public override string ToString()
        {
            List<string> MapInList = ShowMap();
            string MapInString = "";
            for (int i = 0; i < MapInList.Count; i++)
            {
                MapInString += MapInList[i];

                if(i < MapInList.Count - 1)
                {
                    MapInString += "\n";
                }
            }
            return MapInString;
        }

        public string ToJSON()
        {
            List<string> MapInList = ShowMap();
            List<WaypointJSON> waypointJSONs = new List<WaypointJSON>();
            for (int i = 0; i < MapInList.Count; i++)
            {
                string[] split = MapInList[i].Split(' ');
                waypointJSONs.Add(new WaypointJSON(Int32.Parse(split[0]), Convert.ToBoolean(split[1]), split[2]));
            }
            return JsonConvert.SerializeObject(waypointJSONs, Formatting.Indented);
        }

        //Pathfindig related
        //Pathfindig related
        //Pathfindig related
        public int[] FreePath(int start, int end, Color weasel_color)
        {
            Waypoint start_position = FindWayPoint(start);

            List<string> routes = new List<string>();
            FreePathBackend(start_position, end, "", ref routes, weasel_color);

            if (routes.Count == 0)
            {
                FreePathBackendWithoutCheckBackend(start_position, end, "", ref routes);
            }

            //Get the shortest route
            string shortest_route = routes[0];
            for (int i = 1; i < routes.Count; i++)
            {
                if (routes[i].Length < shortest_route.Length)
                {
                    shortest_route = routes[i];
                }
            }

            string[] split = shortest_route.Split(' ');
            int[] arr = new int[split.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = Int32.Parse(split[i]);
            }

            //Check if the route is actually possible
            if (weasel_color != Color.Empty)
            {
                arr = possibleRoute(arr, weasel_color);
            }

            return arr;
        }

        private void FreePathBackend(Waypoint way, int id, string path, ref List<string> routes, Color weasel_color)
        {
            if (way.PointID == id && (way._Reserved == false || weasel_color == way._ReservedColor || weasel_color == Color.Empty))
            {
                routes.Add(path + way.PointID);
                return;
            }

            if (way._Next == null && way.PointID != id && (_Head._Reserved == false || weasel_color == _Head._ReservedColor || weasel_color == Color.Empty))
            {
                FreePathBackend(_Head, id, path + way.PointID + " ", ref routes, weasel_color);
            }

            if (way._Next == null || path.Contains(" " + Convert.ToString(way.PointID) + " "))
            {
                return;
            }

            for (int i = 0; i < way._Next.Count; i++)
            {
                if (way._Next[i]._Reserved == false || weasel_color == way._Next[i]._ReservedColor || weasel_color == Color.Empty)
                {
                    Waypoint RandomWay = way._Next[i];
                    FreePathBackend(RandomWay, id, path + way.PointID + " ", ref routes, weasel_color);
                }
            }
        }

        private void FreePathBackendWithoutCheckBackend(Waypoint way, int id, string path, ref List<string> routes)
        {
            if (way.PointID == id)
            {
                routes.Add(path + way.PointID);
            }

            if (way._Next == null && way.PointID != id)
            {
                FreePathBackendWithoutCheckBackend(_Head, id, path + way.PointID + " ", ref routes);
            }

            if (way._Next == null || path.Contains(" " + Convert.ToString(way.PointID) + " "))
            {
                return;
            }

            for (int i = 0; i < way._Next.Count; i++)
            {
                Waypoint RandomWay = way._Next[i];
                FreePathBackendWithoutCheckBackend(RandomWay, id, path + way.PointID + " ", ref routes);
            }
        }

        //Shrink the route to the possible route
        public int[] possibleRoute(int[] route, Color weasel_color)
        {
            List<int> liste = new List<int>();
            liste.Add(route[0]);
            for (int i = 1; i < route.Length; i++)
            {
                Waypoint temp = FindWayPoint(route[i]);

                if (temp._Reserved == true && weasel_color != temp._ReservedColor)
                {
                    break;
                }

                liste.Add(route[i]);
            }

            int[] newroute = new int[liste.Count];
            for (int i = 0; i < newroute.Length; i++)
            {
                newroute[i] = liste[i];
            }
            return newroute;
        }

        //Shrink the route to radius route
        public int[] RadiusRoute(int[] arr)
        {
            if (arr.Length < 6)
            {
                return arr;
            }

            int[] arr2 = new int[5];
            for (int i = 0; i < arr2.Length; i++)
            {
                arr2[i] = arr[i];
            }
            return arr2;
        }

        //Connect Points
        public void ConnectTwoPoints(int start_point, int end_point)
        {
            Waypoint waypoint = MapBackend.FindWayPointBackend(_Head, start_point);

            if (waypoint._Next == null)
            {
                waypoint._Next = new List<Waypoint>();
            }

            waypoint._Next.Add(MapBackend.FindWayPointBackend(_Head, end_point));
        }

        public void CombineTwoReservedNodes(int number1, int number2)
        {
            int[] arr = new int[2];
            arr[0] = number1;
            arr[1] = number2;
            _CombinedNodes.Add(arr);
        }
    }
}
