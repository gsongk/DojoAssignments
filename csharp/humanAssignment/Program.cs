using System;

namespace humanAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Human player1 = new Human("Dan", 20, 20, 20, 200);
            Human player2 = new Human("Joe");
            Console.WriteLine($"Player1 Name: {player1.name} Stats => strength {player1.strength} intelligence {player1.intelligence} dexterity {player1.dexterity} health {player1.health}");
            Console.WriteLine($"Player2 Name: {player2.name} Stats => strength {player2.strength} intelligence {player2.intelligence} dexterity {player2.dexterity} health {player2.health}");
            player1.Attack(player2);
            Console.WriteLine($"Player1 Name: {player1.name} Stats => strength {player1.strength} intelligence {player1.intelligence} dexterity {player1.dexterity} health {player1.health}");
            Console.WriteLine($"Player2 Name: {player2.name} Stats => strength {player2.strength} intelligence {player2.intelligence} dexterity {player2.dexterity} health {player2.health}");
        }
    }
}
