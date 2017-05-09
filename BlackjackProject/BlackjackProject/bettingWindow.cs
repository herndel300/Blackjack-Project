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
        //public SystemMenuManager manager;
        //public int bet;

        public Form1 form = new Form1();
        public onePlayerGame game = new onePlayerGame();
        
        //Utilities utilities = new Utilities();

        public bettingWindow()
        {
            InitializeComponent();
            this.MaximizeBox = false;

            //Console.WriteLine(form.player1.chipTotal);

            //this.menuManager = new SystemMenuManager(this, SystemMenuManager.MenuItemState.Removed);
            //onePlayerGame game = new onePlayerGame();

            
            currentChipsTextBox.Text = form.player1.chipTotal + "";
            String currentChips = currentChipsTextBox.ToString();
            currentChipsTextBox.Enabled = false;

        }

        //Makes it so user cannot exit out of the bet window since the bet must be placed
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
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
                game.StartPosition = FormStartPosition.CenterScreen;
                game.Show();

                game.savedChips = form.player1.chipTotal - game.bet;
                //game.form.musicIsPlaying = false;
            }

        }
    }
}
