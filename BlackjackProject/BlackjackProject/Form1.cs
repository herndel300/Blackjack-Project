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
    public partial class Form1 : Form
    {
        public Player player1 = new Player("Jack", 0, 500);

        public Form1()
        {
            InitializeComponent();
            
        }

        private void onePlayerButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            /*onePlayerGame game1 = new onePlayerGame();
            game1.StartPosition = FormStartPosition.CenterScreen;
            game1.Show();*/

            bettingWindow betWindow = new bettingWindow();
            betWindow.StartPosition = FormStartPosition.CenterScreen;
            betWindow.Show(); 

        }

        private void twoPlayerButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            playerTwoMenu twoPlayerWindow = new playerTwoMenu();
            twoPlayerWindow.Show();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {

        }
    }
}
