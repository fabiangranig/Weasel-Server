using S7.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaselServer.Roboter.Kuka
{
    internal class SPS_Claw
    {
        public void GreiferZu()
        {
            using (Plc plc = new Plc(CpuType.S71200, "10.0.9.106", 0, 1))
            {
                plc.Open();
                System.Threading.Thread.Sleep(1000);
                plc.Write("M12.0", 0);
                plc.Write("M12.1", 1);
                System.Threading.Thread.Sleep(1000);
            }
        }

        public void GreiferAuf()
        {
            using (Plc plc = new Plc(CpuType.S71200, "10.0.9.106", 0, 1))
            {
                plc.Open();
                System.Threading.Thread.Sleep(1000);
                plc.Write("M12.0", 1);
                plc.Write("M12.1", 0);
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}
