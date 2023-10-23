using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Threading;

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

            //Try to write to that file
            bool switcher = false;
            while(switcher == false)
            {
                try
                {
                    File.AppendAllText(_LogLocation, DateAndTime + ": " + loggedText + "\n");
                    switcher = true;
                }
                catch (Exception e)
                {
                    string error = e.ToString();
                }

                //Wait before next try
                Thread.Sleep(200);
            }
            
        }
    }
}
