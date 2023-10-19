using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaselServer.WeaselControllerBackend.Map
{
    internal class MapBackend
    {
        public static void AddNodeToNumberBackend(Waypoint temp_map, Waypoint waypoint1, int id1)
        {
            if (temp_map._Next != null && temp_map.PointID == id1)
            {
                temp_map._Next.Add(waypoint1);
                return;
            }

            if (temp_map._Next == null && temp_map.PointID == id1)
            {
                temp_map._Next = new List<Waypoint>();
                temp_map._Next.Add(waypoint1);
            }

            if (temp_map._Next == null)
            {
                return;
            }

            for (int i = 0; i < temp_map._Next.Count; i++)
            {
                AddNodeToNumberBackend(temp_map._Next[i], waypoint1, id1);
            }
        }

        public static Waypoint FindWayPointBackend(Waypoint header, int id1)
        {
            if (header != null && header.PointID == id1)
            {
                return header;
            }

            if (header == null)
            {
                return null;
            }

            if (header._Next != null)
            {
                Waypoint[] waypoints = new Waypoint[header._Next.Count];
                for (int i = 0; i < waypoints.Length; i++)
                {
                    waypoints[i] = FindWayPointBackend(header._Next[i], id1);
                    if (waypoints[i] != null)
                    {
                        return waypoints[i];
                    }
                }
            }

            return null;
        }

        public static Waypoint FindWayPointBackendBeforeNumberBackend(Waypoint header, int id1)
        {
            if (header._Next == null)
            {
                return null;
            }

            for (int i = 0; i < header._Next.Count; i++)
            {
                if (header == null || header._Next[i] == null)
                {
                    return null;
                }
            }

            for (int i = 0; i < header._Next.Count; i++)
            {
                if (header != null && header._Next[i].PointID == id1)
                {
                    return header;
                }
            }

            if (header._Next != null)
            {
                Waypoint[] waypoints = new Waypoint[header._Next.Count];
                for (int i = 0; i < waypoints.Length; i++)
                {
                    waypoints[i] = FindWayPointBackendBeforeNumberBackend(header._Next[i], id1);
                    if (waypoints[i] != null)
                    {
                        return waypoints[i];
                    }
                }
            }

            return null;
        }
    }
}
