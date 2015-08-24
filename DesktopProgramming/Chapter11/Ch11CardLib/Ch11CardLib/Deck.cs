using System;

namespace Ch11CardLib
{
    public class Deck : ICloneable
    {
        private Cards cards = new Cards();

        public Deck()
        {
            for (int suitVal = 0; suitVal < 4; suitVal++)
            {
                for (int rankVal = 1; rankVal < 14; rankVal++)
                {
                    cards.Add(new Card((Suit) suitVal, (Rank) rankVal));
                }
            }
        }
        private Deck(Cards newCards)
        {
            cards = newCards;
        }
        // Конструктор не по умолчанию, позволяющий делать тузы старшими, 
        public Deck(bool isAceHigh) : this()
        {
            Card.isAceHigh = isAceHigh;
        }
        // Конструктор не по умолчанию, позволяющий использовать козырную масть. 
        public Deck(bool useTrumps, Suit trump) : this()
        {
            Card.useTrumps = useTrumps;
            Card.trump = trump;
        }
        // Конструктор не no умолчанию, позволяющий делать тузы старшими 
        //и использовать козырную масть. 
        public Deck(bool isAceHigh, bool useTrumps, Suit trump) : this()
        {
            Card.isAceHigh = isAceHigh;
            Card.useTrumps = useTrumps;
            Card.trump = trump;
        } 

        public Card GetCard(int cardNumb)
        {
            if (cardNumb >= 0 && cardNumb <= 51)
                return cards[cardNumb];
            else
                throw (new System.ArgumentOutOfRangeException("cardNumb", cardNumb, "Value must be between 0 and 51."));
        }

        public void Shuffle()
        {
            Cards newDeck = new Cards();
            bool[] assigned = new bool[52];
            Random sourceGen = new Random();
            for (int i = 0; i < 52; i++)
            {
                int sourceCard = 0;
                bool foundCard = false;
                while (foundCard == false)
                {
                    sourceCard = sourceGen.Next(52);
                    if (assigned[sourceCard] == false)
                        foundCard = true;
                }
                assigned[sourceCard] = true;
                newDeck.Add(cards[sourceCard]);
            }
            newDeck.CopyTo(cards);
        }
        public object Clone()
        {
            Deck newDeck = new Deck(cards.Clone() as Cards);
            return newDeck;
        }
    }
}
