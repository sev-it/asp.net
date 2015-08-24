using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch13CardLib
{
    public class CardOutOfRangeException : ApplicationException
    {
        private Cards deckContents;
        public Cards DeckCotents
        {
            get { return deckContents; }
        }
        public CardOutOfRangeException(Cards sourceDeckContents) :
            base("There are only 52 cards in deck.")
        {
            deckContents = sourceDeckContents;
        }
    }
}
