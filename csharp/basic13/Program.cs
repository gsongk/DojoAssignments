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
        public static void PrintSum(){
            int sum = 0;
            for(int x=1; x<=255; x++){
                sum += x;
                Console.WriteLine($"New Number: {x} Sum: {sum}");
            }
        }
        public static void Array(){
            
        }
        static void Main(string[] args)
        {
            Print1to255();
            PrintOdds();
            PrintSum();
            Array();
        }
    }
}
