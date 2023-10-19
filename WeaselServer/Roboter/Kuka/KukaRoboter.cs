using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S7.Net;
using WeaselServer.Roboter.Kuka.MovementEditor;

namespace WeaselServer.Roboter.Kuka
{
    internal class KukaRoboter : RDK_Setup
    {
        public void MoveKukaWithFile(string path)
        {
            string[] JointsPositions = ConvertIntoSingleArray.GetArray(path, 2);

            //Go through all positions and move to them
            for(int i = 0; i < JointsPositions.Length; i++)
            {
                Move(JointsPositions[i]);
            }
        }

        private void Move(string postions)
        {
            if (!Check_ROBOT()) { Console.WriteLine("Keine Verbindung zum Roboter"); return; }

            double[] jointsNEU;
            jointsNEU = new double[6];
            jointsNEU = String_2_Values_NEU(postions);

            // make sure RDK is running and we have a valid input
            if (!Check_ROBOT() || jointsNEU == null) { return; }

            try
            {
                ROBOT.MoveJ(jointsNEU, MOVE_BLOCKING);
                ROBOT.WaitMove();
            }
            catch (RoboDK.RDKException rdkex)
            {
                Console.WriteLine("Problems moving the robot: " + rdkex.Message);
            }
        }

        public double[] String_2_Values_NEU(string strvalues)
        {
            double[] dvalues = null;
            try
            {
                dvalues = Array.ConvertAll(strvalues.Split(';'), Double.Parse);
            }
            catch (System.FormatException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Invalid input: " + strvalues);
            }
            return dvalues;
        }
    }
}
