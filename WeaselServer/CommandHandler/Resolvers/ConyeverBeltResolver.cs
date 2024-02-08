using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaselServer.CommandHandler.Resolvers
{
    class ConyeverBeltResolver
    {
        public static void ManualSensorTouchSwitch()
        {
            ConyeverBelt.K_ConyeverBelt.ManualSensorTouchSwitch();
        }
    }
}
