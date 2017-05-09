using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace BlackjackProject
{
    public partial class Form1 : Form
    {
        public Player player1 = new Player("Jack", 0, 500);
        public WindowsMediaPlayer music = new WindowsMediaPlayer();
        public Boolean musicIsPlaying;
       

        public Form1()
        {
            InitializeComponent();

            if (musicIsPlaying == true)
            {
                music.controls.stop();
            }

            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void onePlayerButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            onePlayerGame game = new onePlayerGame();
            bettingWindow betWindow = new bettingWindow();
            

            betWindow.StartPosition = FormStartPosition.CenterScreen;
            betWindow.Show();

            /*if(musicIsPlaying == true)
            {
                music.controls.stop();
            }*/

            if (musicIsPlaying == false)
            {
                music.URL = @"C:\Users\Herndel\Desktop\Blackjack Project\Blackjack Images\game_music.wav";
                music.controls.play();
                music.settings.setMode("Loop", true);
            }

        }

        private void twoPlayerButton_Click(object sender, EventArgs e)
        {
            /*this.Hide();
            playerTwoMenu twoPlayerWindow = new playerTwoMenu();
            twoPlayerWindow.Show();*/

            this.Hide();
            howToPlayMenu howToPlay = new howToPlayMenu();
            howToPlay.StartPosition = FormStartPosition.CenterScreen;
            howToPlay.Show();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
