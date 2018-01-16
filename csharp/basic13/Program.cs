using System;

namespace basic13
{
    class Program
    {
        //Prints values 1 to 255
        public static void Print1to255(){
            for (int x = 1; x<=255; x++){
                Console.WriteLine(x);
            }
        }
        //Print Odd Values
        public static void PrintOdds(){
            for (int x=1; x<=255; x++){
                if (x%2==1){
                    Console.WriteLine(x);
                }
            }
        }
        //Print the sum
        public static void PrintSum(){
            int sum = 0;
            for(int x=1; x<=255; x++){
                sum += x;
                Console.WriteLine($"New Number: {x} Sum: {sum}");
            }
        }
        //The Array
        public static void Array(int[] arr){
            string printout = "[";
            for (int idx=0; idx<arr.Length; idx++){
                printout += arr[idx] + ",";
            }
            printout += "]";
            Console.WriteLine(printout);
        }
        //The Max
        public static void Max(int[] arr){
            int max = arr[0];
            foreach (int val in arr){
                if(val > max){
                    max = val;
                }
            }
            Console.WriteLine("Max Value: {0}", max);
        }
        //Average
        public static void Average(int[] arr){
            int max = 0;
            foreach (int val in arr){
                max += val;
            }
            max = max/arr.Length;
            Console.WriteLine("Avg Value: {0}", max);
        }
        //Array with Odd Numbers
        // public static int[] OddNumbers(){
        //     List <int> oddList = new List <int>();
        //     for (int val = 1; val < 256; val++){
        //         if (val % 2 == 1){
        //             oddList.Add(val);
        //         }
        //     }
        //     return oddList.ToArray();
        // }
        //Greater than Y
        public static void GreaterThanY(int[] arr, int y){
            int count = 0;
            foreach (int x in arr){
                if(x > y){
                    count++;
                }
            }
            Console.WriteLine($"There are {count} values greater than {y}");
        }
        //Square the Values
        public static void squared(int[] arr){
            string list = "[";
            for (int idx = 0; idx < arr.Length; idx++)
            {
                arr[idx] *= arr[idx];
                list += arr[idx] + ",";
            }
            list += "]";
            Console.WriteLine($"squared: {list}");
        }
        //Eliminate Negative Numbers
        public static void negative(int[] arr){
            for(int idx = 0; idx<arr.Length; idx++){
                if (arr[idx]<0){
                    arr[idx] = 0;
                }
            }
        }
        //Min, Max, and Average
        public static void MinMaxAvg(int[] arr){
            int sum = 0;
            int min = arr[0];
            int max = arr[0];
            foreach (int val in arr){
                sum += val;
                if (val < min){
                    min = val;
                }
                if (val > max){
                    max = val;
                }
            }
            Console.WriteLine("The max of the array is {0}, the min is {1}, and the average is {2}", max, min, (double)sum / (double)arr.Length);
        }
        //Shifting the Values in an Array
        public static void ShiftLeft(int[] arr){
            for (int idx = 0; idx < arr.Length - 1; idx++){
                arr[idx] = arr[idx + 1];
            }
            arr[arr.Length - 1] = 0;
        }
        //Number to String
        public static object[] ReplaceNumberWithString(object[] arr){
            for (int idx = 0; idx < arr.Length; idx++){
                if ((int)arr[idx] < 0){
                    arr[idx] = "Dojo";
                }
            }
            return arr;
        }
        static void Main(string[] args)
        {
            // Print1to255();
            // PrintOdds();
            // PrintSum();
            int[] myArr = new int[] {-3, 8, 10, 20};
            // Array(myArr);
            // Max(myArr);
            // Average(myArr);
            // OddNumbers();
            // GreaterThanY(myArr, 4);
            // squared(myArr);
            // negative(myArr);
            // MinMaxAvg(myArr);
            // ShiftLeft(myArr);
            // object[] boxedArray = new object[] { -1, 3, 2 - 16 };
            // ReplaceNumberWithString(boxedArray);
        }
    }
}
