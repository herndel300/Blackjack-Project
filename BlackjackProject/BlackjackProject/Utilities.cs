using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackjackProject
{
    class Utilities
    {
        //displays card's image
        //Might have to adjust method or have multiple display methods
        public void displayCard(Card x, int coorX, int coorY, PictureBox pb, Control form)
        {

            /*x.cardImage.Image = new Bitmap(x.cardImageFile);
            x.cardImage.SizeMode = PictureBoxSizeMode.AutoSize;
            x.cardImage.Location = new Point(400, 375);
            x.cardImage.BringToFront();
            this.Controls.Add(x.cardImage);*/

            pb.Image = new Bitmap(x.cardImageFile);
            pb.SizeMode = PictureBoxSizeMode.AutoSize;
            pb.Location = new Point(coorX, coorY);
            pb.BringToFront();
            pb.BackColor = Color.Transparent;
            form.Controls.Add(pb);
        }

        //resets all controls
        public void reset(Control form)
        {
            foreach (Control control in form.Controls)
            {
                if (control is TextBox)
                {
                    TextBox textBox = (TextBox)control;
                    textBox.Text = null;
                }

                if (control is ComboBox)
                {
                    ComboBox comboBox = (ComboBox)control;
                    if (comboBox.Items.Count > 0)
                        comboBox.SelectedIndex = 0;
                }

                if (control is CheckBox)
                {
                    CheckBox checkBox = (CheckBox)control;
                    checkBox.Checked = false;
                }

                if (control is ListBox)
                {
                    ListBox listBox = (ListBox)control;
                    listBox.ClearSelected();
                }

                if (control is PictureBox)
                {
                    PictureBox picturebox = (PictureBox)control;
                    picturebox.Image = null;
                }

                if (control is Button)
                {
                    Button button = (Button)control;
                    button.Enabled = true;
                }
            }

        }

        //generates standard 52 card deck
        public void createDeck(onePlayerGame game)
        {
            Card[] cards = new Card[52];

            //generates deck with array of card objects
            int index = 0;
            for (int suit = 1; suit <= 4; suit++)
            {
                for (int value = 2; value <= 14; value++)
                {
                    cards[index] = new Card(value, suit, new PictureBox(), "C:\\Users\\Herndel\\Desktop\\Blackjack Project\\Blackjack Images\\Playing Cards\\" + suit + "\\" + suit + "_of_" + value + ".png");
                    index++;
                }
            }

            //catches the addition of the face cards and the aces. This then changes their value accordingly
            //this makes the order of values strange, (2-11, then 3 additional 10's)
            for (int x = 0; x < cards.Length; x++)
            {
                if (cards[x].cardValue >= 11 && cards[x].cardValue != 14)
                {
                    cards[x].cardValue = 10;
                }

                if (cards[x].cardValue == 14)
                {
                    cards[x].cardValue = 11;
                }

            }

            game.deck = new List<Card>(cards);
        }

        //resets hand totals for the player and dealer
        //eventually find a way to move into reset() method
        public void resetHandTotals(onePlayerGame game)
        {
            game.player1.handTotal = 0;
            game.dealer.handTotal = 0;
        }
    }
}
