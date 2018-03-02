using System;
using System.Collections.Generic;
using System.Linq;

namespace puzzles
{
    class Program
    {
        //Random Array
        public int [] RandomArray(){
            Random rand = new Random();
            int [] randArr = new int[10];
            int sum = 0;
            for(int idx = 0; idx<randArr.Length; idx++){
                int val = rand.Next(5,26);
                randArr[idx] = val;
                sum += val;
            }
            Console.WriteLine("The max value of the random array is {0}", randArr.Max());
            Console.WriteLine("The min value of the random array is {0}", randArr.Min());
            return randArr;
        }
        //Coin Flip
        public string TossCoin(Random rand){
            Console.WriteLine("Tossing a Coin!");
            string result = "Tails";
            if (rand.Next() == 0){
                result = "Heads";
            }
            Console.WriteLine(result);
            return result;
        }

        public Double TossMultipleCoins(int num){
            int numHeads = 0;
            for (int reps = 0; reps < num; reps++){
                if (TossCoin(new Random()) == "Heads"){
                    numHeads++;
                }
            }
            return (double)numHeads / (double)num;
        }
        //Names
        public string[] Names(){
            string[] names = new string[5] { "Todd", "Tiffany", "Charlie", "Geneva", "Sydney" };
            //Fisher-Yates Shuffle
            Random rand = new Random();
            for (var idx = 0; idx < names.Length - 1; idx++){
                int randIdx = rand.Next(idx + 1, names.Length - 1);
                string temp = names[idx];
                names[idx] = names[randIdx];
                names[randIdx] = temp;
                //Print each name in it's new position
                Console.WriteLine(names[idx]);
            }
            //Don't forget the last value!
            Console.WriteLine(names[names.Length - 1]);

            //Return an array the only includes names longer than 5
            List<string> nameList = new List<string>();
            foreach (var name in names){
                nameList.Add(name);
            }
            return nameList.ToArray();
        }

        static void Main(string[] args)
        {
        }
    }
}
