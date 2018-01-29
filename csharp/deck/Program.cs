using System;

namespace DeckOfCards
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Deck myDeck = new Deck();
            Player tester = new Player("Sam");
            Console.WriteLine(myDeck);
        }
    }
}
