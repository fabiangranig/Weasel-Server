using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace WeaselServer.Logger
{
    internal class LoggerWorker
    {

        static string _LogLocation;

        static LoggerWorker()
        {
            _LogLocation = "log.txt";
        }

        public static void LogText(string loggedText)
        {
            string DateAndTime = DateTime.Now.ToString();
            File.AppendAllText(_LogLocation, DateAndTime + ": " + loggedText + "\n");
        }
    }
}
