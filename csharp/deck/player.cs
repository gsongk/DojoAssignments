using System.Collections.Generic;

namespace DeckOfCards
{
    public class Player
    {
        public string name;
        private List<Card> hand;

        public Player(string n)
        {
            hand = new List<Card>();
            name = n;
        }

        public void DrawFrom(Deck currentDeck)
        {
            hand.Add(currentDeck.Deal());
        }

        public Card Discard(int idx)
        {
            Card temp = hand[idx];
            hand.RemoveAt(idx);
            return temp;
        }
    }
}