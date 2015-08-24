using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ch13CardLib;

namespace Ch13CardClient
{
    public class Player
    {
        private Cards hand;
        private string name;

        public Cards PlayHand
        {
            get { return hand; }
        }
        public string Name
        {
            get { return name; }
        }
        private Player()
        {
        }
        public Player(string newName)
        {
            name = newName;
            hand = new Cards();
        }
        public bool HasWon()
        {
            bool won = true;
            Suit match = hand[0].suit;
            for (int i = 1; i < hand.Count; i++)
            {
                won &= hand[i].suit == match;
            }
            return won;
        }
    }
}
