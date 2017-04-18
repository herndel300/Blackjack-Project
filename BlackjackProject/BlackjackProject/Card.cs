using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackjackProject
{
    public class Card
    {
        public int cardValue;
        public int cardSuit;
        public PictureBox cardImage;
        public string cardImageFile;

    public Card()
    {
        cardValue = 0;
        cardSuit = -1;
        cardImage = null;
    }

    public Card(int cardValue, int cardSuit, PictureBox cardImage, String cardImageFile)
    {
        this.cardValue = cardValue;
        this.cardSuit = cardSuit;
        this.cardImage = cardImage;
        this.cardImageFile = cardImageFile;
    }

    }
}
