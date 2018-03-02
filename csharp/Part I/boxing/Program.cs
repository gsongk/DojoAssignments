using System;
using System.Collections;
using System.Collections.Generic;

namespace boxing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<object> mixedList = new List<object>();
            mixedList.Add(7);
            mixedList.Add(28);
            mixedList.Add(-1);
            mixedList.Add(true);
            mixedList.Add("chair");

            int sum = 0;
            foreach (var item in mixedList){
                Console.WriteLine(item);
                if (item is int)
                {
                    sum += (int)item;
                }
            }
            Console.WriteLine("The sum of all the integers in the list is {0}", sum);

        }
    }
}
