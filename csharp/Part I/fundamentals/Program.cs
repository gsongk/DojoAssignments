using System;

namespace fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            // Part I of the assignment: 
            // for (int i=1; i<=255; i++)
            // {
            //     Console.WriteLine(i);
            // }

            //Part II of the assignment:
            // for (int i=1; i<=100; i++)
            // {
            //     if (i%3==0 || i%5 ==0)
            //     {
            //         if (i % 3 == 0 && i % 5 == 0)
            //         {
            //             Console.WriteLine("Both divisible by 3 and 5");
            //         }
            //         else
            //         {
            //             Console.WriteLine(i);
            //         }
            //     }
            // }

            //Part III of the Assignment:
            // for (int i=1; i<=100; i++){
            //     if (i%3 == 0 || i % 5 == 0){
            //         if (i % 3 == 0 && i % 5 == 0){
            //                 Console.WriteLine("FizzBuzz");
            //             }
            //         if (i % 3 == 0){
            //             Console.WriteLine("Fizz");
            //         }
            //         if (i % 5 == 0){
            //             Console.WriteLine("Buzz");
            //         }
            //     }
            // }

            //Part IV of the Assignment:
            // for (int i = 1; i<=100; i++){
            //     if (i/3 == i/3.0 || i/5 == i/5.0){
            //         if (i / 3 == i / 3.0 && i / 5 == i / 5.0){
            //             Console.WriteLine("FizzBuzz");
            //         }
            //         if (i / 3 == i / 3.0){
            //             Console.WriteLine("Fizz");
            //         }
            //         if (i / 5 == i / 5.0){
            //             Console.WriteLine("Buzz");
            //         }
            //     }
            // }

            //Part V of the Assignment:
            Random rand = new Random();
            for (int k=1; k<=10; k++){
                int i = rand.Next(1,11);
                Console.WriteLine("Random Number: " + i);

                if (i % 3 == 0 || i % 5 == 0){
                    if (i % 3 == 0 && i % 5 == 0){
                        Console.WriteLine("Both divisible by 3 and 5");
                    }
                    else{
                        Console.WriteLine("Divisible by 3 or 5: " + i);
                    }
                }
            }

        }
    }
}
