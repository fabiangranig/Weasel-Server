using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaselServer.General
{
    internal class IntManipulation
    {
        public static int[] ArrayMinusOneSearchedItem(int[] arr, int number)
        {
            int location = 0;
            for(int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == number)
                {
                    location = i;
                    break;
                }
            }

            int[] array = new int[location];
            for(int i = 0; i < array.Length; i++)
            {
                array[i] = arr[i];
            }
            return array;
        }
    }
}
