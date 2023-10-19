using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeaselServer.Roboter.Kuka;

namespace WeaselServer.CommandHandler.Resolvers
{
    internal class KukaResolver
    {
        private static KukaRoboter _KR;

        static KukaResolver()
        {
            _KR = new KukaRoboter();
        }

        public static void MoveLikeFile(string filePath)
        {
            _KR.MoveKukaWithFile(filePath);
        }
    }
}
