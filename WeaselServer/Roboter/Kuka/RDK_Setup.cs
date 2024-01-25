using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaselServer.Roboter.Kuka
{
    internal class RDK_Setup
    {
        private RoboDK RDK = null;
        protected const bool MOVE_BLOCKING = false;
        protected RoboDK.Item ROBOT = null;

        //Constructor
        public RDK_Setup()
        {
            //Gets the Robot
            if (!Check_RDK())
            {
                RDK = new RoboDK();

                //Check if RDK is started
                if (Check_RDK())
                {
                    SelectRobot();
                }

                //Simulation Mode should be the default value
                SwitchSimulationMode();
            }
        }

        private bool Check_RDK()
        {
            // check if the RDK object has been initialised:
            if (RDK == null)
            {
                return false;
            }

            // Check if the RDK API is connected
            if (!RDK.Connected())
            {
                // Attempt to connect to the RDK API
                if (!RDK.Connect())
                {
                    return false;
                }
            }
            return true;
        }

        protected bool Check_ROBOT(bool ignore_busy_status = false)
        {
            if (!Check_RDK())
            {
                return false;
            }
            if (ROBOT == null || !ROBOT.Valid())
            {
                return false;
            }
            try
            {
            }
            catch (RoboDK.RDKException rdkex)
            {
                Console.WriteLine(rdkex.ToString());
                return false;
            }

            //Safe check: If we are doing non blocking movements, we can check if the robot is doing other movements with the Busy command
            if (!MOVE_BLOCKING && (!ignore_busy_status && ROBOT.Busy()))
            {
                return false;
            }
            return true;
        }

        private void SelectRobot()
        {
            if (!Check_RDK())
            {
                ROBOT = null;
                return;
            }
            ROBOT = RDK.ItemUserPick("Select a robot", RoboDK.ITEM_TYPE_ROBOT);
            if (ROBOT.Valid())
            {
                ROBOT.NewLink();
            }
        }

        public void SwitchSimulationMode()
        {
            // Check that there is a link with RoboDK
            if (!Check_ROBOT()) { return; }

            // Important: stop any previous program generation (if we selected offline programming mode)
            RDK.Finish();

            // Set to simulation mode
            RDK.setRunMode(RoboDK.RUNMODE_SIMULATE);
        }

        public void SwitchRealMode()
        {
            if (!Check_ROBOT()) { return; }

            // Important: stop any previous program generation (if we selected offline programming mode)
            RDK.Finish();

            // Connect to real robot
            if (ROBOT.Connect())
            {
                // Set to Run on Robot robot mode:
                RDK.setRunMode(RoboDK.RUNMODE_RUN_ROBOT);
            }
            else
            {
                Console.WriteLine("Can't connect to the robot. Check connection and parameters.");
                SwitchSimulationMode();
            }
        }
    }
}
