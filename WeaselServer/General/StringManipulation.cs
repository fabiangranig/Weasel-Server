using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaselServer.General
{
    internal class StringManipulation
    {
        public static string[] GetSpaceSplitString(string command)
        {
            string[] split_string;
            if (command.Contains(" "))
            {
                return command.Split(' ');
            }
            else
            {
                split_string = new string[1];
                split_string[0] = command;
                return split_string;
            }
        }
    }
}
