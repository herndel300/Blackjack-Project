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
        //SystemMenuManager manager;
        //public int bet;

        Form1 form = new Form1();
        onePlayerGame game = new onePlayerGame();

        public bettingWindow()
        {
            InitializeComponent();

            //this.menuManager = new SystemMenuManager(this, SystemMenuManager.MenuItemState.Removed);
            //onePlayerGame game = new onePlayerGame();

            currentChipsTextBox.Text = form.player1.chipTotal + "";
            currentChipsTextBox.Enabled = false;

        }

        private void acceptButton_Click(object sender, EventArgs e)
        { 

            if (Convert.ToInt32(desiredWagerUpDown.Value) > form.player1.chipTotal)
            {
                MessageBox.Show("Insufficient amount of chips!");
            }

            else if(Convert.ToInt32(desiredWagerUpDown.Value) <= 0)
            {
                MessageBox.Show("You must bet over $0!");
            }

            else
            {
                
                this.Hide();
                game.bet = Convert.ToInt32(desiredWagerUpDown.Value);
                form.player1.chipTotal = form.player1.chipTotal - game.bet;
                game.StartPosition = FormStartPosition.CenterScreen;
                game.Show();

            }

            

        }
    }
}
