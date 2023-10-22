using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaselServer.General
{
    internal class IntManipulation
    {
        public static int[] ArrayMinusOne(int[] arr)
        {
            int[] array = new int[arr.Length - 1];
            for(int i = 0; i < arr.Length - 1; i++)
            {
                array[i] = arr[i];
            }
            return array;
        }
    }
}
