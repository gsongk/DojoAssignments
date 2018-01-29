using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    public class Deck
    {
        private List<Card> cards;

        public Deck()
        {
            Reset();
        }

        public Card Deal()
        {
            if (cards.Count > 0)
            {
                Card temp = cards[0];
                cards.RemoveAt(0);
                return temp;
            }
            return null;
        }

        public Deck Shuffle()
        {
            Random rand = new Random();
            for (int idx = cards.Count - 1; idx > 0; idx--)
            {
                int randIdx = rand.Next(idx);
                Card temp = cards[randIdx];
                cards[randIdx] = cards[idx];
                cards[idx] = temp;
            }
            return this;
        }

        public Deck Reset()
        {
            cards = new List<Card>();
            string[] suits = new string[4] { "Hearts", "Clubs", "Spades", "Diamonds" };
            foreach (string suit in suits)
            {
                for (int val = 1; val <= 13; val++)
                {
                    cards.Add(new Card(suit, val));
                }
            }
            return this;
        }

        public override string ToString()
        {
            string info = "";
            foreach (Card card in cards)
            {
                info += card + "\n";
            }
            return info;
        }
    }
}