using System;

namespace human
{
    public class Program
    {
        public static void Main(string [] args){
            Human player1 = new Human("SPAM", 10, 10, 10, 500);
            Human player2 = new Human("JOE");
            System.Console.WriteLine(player1.strength);
            System.Console.WriteLine(player1.strength);
            player1.attack(player2);
        }
    }
}
