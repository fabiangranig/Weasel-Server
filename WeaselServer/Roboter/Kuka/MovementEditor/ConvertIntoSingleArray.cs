using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using WeaselServer.Logger;

namespace WeaselServer.Roboter.Kuka.MovementEditor
{
    internal class ConvertIntoSingleArray
    {
        public static string[] GetArray(string path, int type)
        {
            switch(type)
            {
                case 1:
                    LoggerWorker.LogText("ConvertIntoSingleArray: Type 1 not assigned");
                    return null;
                case 2:
                    return CollectJoins(path);
                case 3:
                    LoggerWorker.LogText("ConvertIntoSingleArray: Type 3 not assigned");
                    return null;
                default:
                    LoggerWorker.LogText("ConvertIntoSingleArray: Type not correct");
                    return null;
            }
        }

        private static string[] CollectJoins(string path)
        {
            string[] FullList = File.ReadAllLines(path);

            //Loop through items and get the right part
            for(int i = 0; i < FullList.Length; i++)
            {
                string[] split = FullList[i].Split('#');
                FullList[i] = split[1];
            }

            //Return the new list
            return FullList;
        }
    }
}
