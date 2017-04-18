using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackjackProject
{
    public partial class bettingWindow : Form
    {
        public int bet;

        public bettingWindow()
        {
            InitializeComponent();
            onePlayerGame game = new onePlayerGame();

            currentChipsTextBox.Text = game.player1.chipTotal + "";
            currentChipsTextBox.Enabled = false;
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            onePlayerGame game = new onePlayerGame();

            //if(desiredWagerUpDown.)

            if (Convert.ToInt32(Math.Round(desiredWagerUpDown.Value, 0)) > game.player1.chipTotal)
            {
                MessageBox.Show("Insufficient amount of chips!");
            }

            else if(Convert.ToInt32(Math.Round(desiredWagerUpDown.Value, 0)) <= 0)
            {
                MessageBox.Show("You must bet over $0!");
            }

            else
            {
                game.player1.chipTotal = game.player1.chipTotal - Convert.ToInt32(Math.Round(desiredWagerUpDown.Value, 0));
                bet = Convert.ToInt32(Math.Round(desiredWagerUpDown.Value, 0));
                this.Hide();
                Console.WriteLine(game.player1.chipTotal);
            } 
        }
    }
}
