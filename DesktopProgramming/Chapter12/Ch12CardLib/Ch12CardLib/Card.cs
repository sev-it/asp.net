using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch12CardLib
{
    public class Card : ICloneable
    {
        public static bool useTrumps = false;
        public static Suit trump = Suit.Club;
        public static bool isAceHigh = true; 

        public readonly Rank rank;
        public readonly Suit suit;

        private Card()
        {
        }

        public Card(Suit newSuit, Rank newRank)
        {
            suit = newSuit;
            rank = newRank;
        }
        public static bool operator ==(Card card1, Card card2)
        {
            return (card1.suit == card2.suit) && (card1.rank == card2.rank);
        }

        public static bool operator !=(Card cardl, Card card2)
        {
            return !(cardl == card2);
        }

        public override bool Equals(object card)
        {
            return this == (Card) card;
        }

        public override int GetHashCode()
        {
            return 13*(int) rank + (int) suit;
        }
        public static bool operator > (Card cardl, Card card2) 
        {
            if (cardl.suit == card2.suit)
            {
                if (isAceHigh)
                {
                    if (cardl.rank == Rank.Ace)
                    {
                        if (card2.rank == Rank.Ace)
                            return false;
                        else
                            return true;
                    }
                    else
                    {
                        if (card2.rank == Rank.Ace)
                            return false;
                        else
                            return (cardl.rank > card2.rank);
                    }
                }
                else
                {
                    return (cardl.rank > card2.rank);
                }
            }
            else
            {
                if (useTrumps && (card2.suit == Card.trump))
                    return false;
                else
                    return true;
            }
        } 

        public static bool operator < (Card card1, Card card2) 
        { 
            return !(card1 >= card2); 
        } 
        public static bool operator >=(Card card1, Card card2) 
        { 
            if (card1.suit == card2.suit) 
            { 
                if (isAceHigh) 
                { 
                    if (card1.rank == Rank.Ace) 
                    { 
                        return true; 
                    } 
                    else 
                    { 
                        if (card2.rank == Rank.Ace) 
                            return false; 
                        else 
                            return (card1.rank >= card2.rank); 
                    } 
                }  
                else 
                { 
                    return (card1.rank >= card2.rank); 
                } 
            } 
            else 
            { 
                if (useTrumps && (card2.suit == Card.trump)) 
                    return false; 
                else 
                    return true; 
            } 
        } 

        public static bool operator <=(Card card1, Card card2)
        {
            return !(card1 > card2);
        }

        public override string ToString()
        {
            return "The " + rank + " of " + suit + "s";
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
