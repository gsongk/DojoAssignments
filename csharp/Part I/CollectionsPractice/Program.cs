using System;
using System.Collections.Generic;


namespace CollectionsPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            // Three Basic Arrays: 

            //Part I:
            // int[] numArray;
            // numArray = new int[] {1,2,3,4,5,6,7,8,9};
            // for (int i=0; i<numArray.Length; i++){
            //     Console.WriteLine(numArray[i]);
            // }
            //Part II:
            // string[] names = new string[4] {"Tim", "Martin", "Nikki", "Sara" };
            // foreach (string name in names){
            //     Console.WriteLine("Names: {0}", name);
            // }
            //Part III:
            // string[] boolean = new string[10];
            // for (int i=0; i<10; i+=2)
            // {
            //     boolean[i] = true;
            // }
            //for (int i=0; i<10; i+=1){
            //  boolean[i] = false;
            //}

            //Multiplication Table:
            // int[,] mult = new int[10, 10];
            // for (int x = 0; x < 10; x++){
            //     for (int y = 0; y < 10; y++){
            //         mult[x, y] = (x + 1) * (y + 1);
            //     }
            // }
            // for (int x = 0; x < 10; x++){
            //     string display = "[ ";
            //     for (int y = 0; y < 10; y++)
            //     {
            //         display += mult[x, y] + ", ";
            //         if (mult[x, y] < 10){
            //             display += " ";
            //         }
            //     }
            //     display += "]";
            //     Console.WriteLine(display);
            // }

            //List of Flavors:
            List<string> flavors = new List<string>();

            flavors.Add("Mango");
            flavors.Add("Vanilla");
            flavors.Add("Chocolate");
            flavors.Add("Strawberry");
            flavors.Add("Swirl");
            flavors.Add("Blueberry");
            flavors.Add("Coconut");

            // Console.WriteLine("Numbers of Flavors: {0}", flavors.Count);
            
            // foreach (string name in flavors)
            // {
            //     Console.WriteLine("Flavors: {0}", name);
            // }
            // //Output the third flavor in the list, then remove this value.
            // Console.WriteLine("Third in list: {0}", flavors[3]);
            // flavors.RemoveAt(3);

            // foreach (string name in flavors)
            // {
            //     Console.WriteLine("Flavors: {0}", name);
            // }
            // //Output the new length of the list (Note it should just be one less~)
            // Console.WriteLine("Numbers of Flavors: {0}", flavors.Count);

            //User Info Dictionary:
            Dictionary<string, string> userInfo = new Dictionary<string, string>();
            Random rand = new Random();
            string[] nameArray = new string[] { "Tim", "Martin", "Nikki", "Sara" };
            foreach (string name in nameArray)
            {
                userInfo[name] = flavors[rand.Next(flavors.Count)];
            }

            //Looping through info Dictionary
            Console.WriteLine("Users and their favor ice cream flavors:");
            foreach (KeyValuePair<string, string> info in userInfo)
            {
                Console.WriteLine(info.Key + " - " + info.Value);
            }



        }
    }
}
