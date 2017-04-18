using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BlackjackProject
{
    public partial class onePlayerGame : Form
    {
        Random random = new Random();
        Utilities utilities = new Utilities();
        public Player player1 = new Player("Jack", 0, 500);
        public Dealer dealer = new Dealer();
        public List<Card> deck;
        PictureBox playerCard1 = new PictureBox();
        PictureBox playerCard2 = new PictureBox();
        PictureBox dealerCard1 = new PictureBox();
        PictureBox dealerCard2 = new PictureBox();

        public onePlayerGame()
        {
            InitializeComponent();
            utilities.createDeck(this);
        }

        //Starts game after the player's bets have been placed
        //Deals initial cards, then adds their value to the player's hand total
        //-------------------------------------------->Chip total is not being updated, need to fix <---------------------------------------------------
        private void dealButton_Click(object sender, EventArgs e)
        {
            bettingWindow betWindow = new bettingWindow();

            var playerFirstCard = deck[12];
            utilities.displayCard(playerFirstCard, 405, 375, playerCard1, this);
            deck.Remove(playerFirstCard);

            var playerSecondCard = deck[11];
            utilities.displayCard(playerSecondCard, 455, 375, playerCard2, this);
            deck.Remove(playerSecondCard);

            player1.handTotal = player1.handTotal + playerFirstCard.cardValue + playerSecondCard.cardValue;
            playerHandTotalTextBox.Text = "Hand Total: " + player1.handTotal;

            var dealerFirstCard = deck[random.Next(deck.Count - 1)];
            utilities.displayCard(dealerFirstCard, 405, 5, dealerCard1, this);
            deck.Remove(dealerFirstCard);

            var dealerSecondCard = deck[random.Next(deck.Count - 1)];
            utilities.displayCard(dealerSecondCard, 455, 5, dealerCard2, this);
            deck.Remove(dealerSecondCard);

            dealer.handTotal = dealer.handTotal + dealerFirstCard.cardValue + dealerSecondCard.cardValue;
            dealerHandTotalTextBox.Text = "Hand Total: " + dealer.handTotal;

            dealButton.Enabled = false;
            playerHandTotalTextBox.Enabled = false;
            dealerHandTotalTextBox.Enabled = false;

            //Condition if both the player and dealer are dealt 21
            if (player1.handTotal == 21 && dealer.handTotal == 21)
            {
                MessageBox.Show("Push! Waged chips have been returned");

                player1.chipTotal = player1.chipTotal + betWindow.bet;

                utilities.reset(this);
                utilities.resetHandTotals(this);
                deck.Clear();
                utilities.createDeck(this);

                betWindow.StartPosition = FormStartPosition.CenterScreen;
                betWindow.Show();
            }

            //Condition if player is dealt 21 and the dealer is not
            if (player1.handTotal == 21 && dealer.handTotal != 21)
            {
                MessageBox.Show("Blackjack, you win!");

                player1.chipTotal = player1.chipTotal + (betWindow.bet * 2);

                utilities.reset(this);
                utilities.resetHandTotals(this);
                deck.Clear();
                utilities.createDeck(this);

                betWindow.StartPosition = FormStartPosition.CenterScreen;
                betWindow.Show();
            }

            //Condition if dealer is dealt 21 and player is not
            if (dealer.handTotal == 21 && player1.handTotal != 21)
            {
                MessageBox.Show("Dealer has blackjack, you lose!");

                utilities.reset(this);
                utilities.resetHandTotals(this);
                deck.Clear();
                utilities.createDeck(this);

                betWindow.StartPosition = FormStartPosition.CenterScreen;
                betWindow.Show();
            }            
        }

        private void hitButton_Click(object sender, EventArgs e)
        {
            //displays card image in player one position
            //eventually move to method
            /*deck[51].cardImage.Image = new Bitmap(deck[51].cardImageFile);
            deck[51].cardImage.SizeMode = PictureBoxSizeMode.AutoSize;
            deck[51].cardImage.Location = new Point(400, 375);
            Controls.Add(deck[51].cardImage);
            deck[51].cardImage.BringToFront();
            displayCard(deck[1]);
            Console.WriteLine(deck[1].cardValue);
            Console.WriteLine(deck[1].cardImageFile);*/
        }

        
    }
}
