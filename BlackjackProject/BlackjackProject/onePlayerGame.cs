using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using WMPLib;

namespace BlackjackProject
{
    public partial class onePlayerGame : Form
    {
        //Bet window fix: form.player1 is always created with 500 chips when oneplayergame window is open. need to store somewhere else!
        //Need to hide form when game ends for all conditions

        //Need to fix: 
        //fix bet window so onePlayerGame can properly use the bet
        //fix window priority
        //fix music looping
        //add how to play menu
        //add graphical touches
        //finish design document

        WindowsMediaPlayer music = new WindowsMediaPlayer();
        Random random = new Random();
        Utilities utilities = new Utilities();
        public Dealer dealer = new Dealer();
        public List<Card> deck;
        Form1 form = new Form1();

        public int savedValue;
        public string savedFile;
        public string savedPlayerCard1;
        public string savedPlayerCard2;

        public Card playerFirstCard;
        public Card playerSecondCard;
        public Card dealerFirstCard;
        public Card dealerSecondCard;

        public int firstHandTotal = 0;
        public int secondHandTotal = 0;

        public int pixelChange = 0;
        public Boolean doubledown = false;
        public Boolean first = true;

        public int bet;

        public onePlayerGame()

        {
            InitializeComponent();

            //music.controls.stop();
            //music.URL = @"C:\Users\Herndel\Desktop\Blackjack Project\Blackjack Images\game_music.wav";
            //music.controls.play();

            playerHandTotalTextBox.Enabled = false;
            dealerHandTotalTextBox.Enabled = false;

            stayButton.Hide();
            hitButton.Hide();
            doubledownButton.Hide();
            splitButton.Hide();
            splitHitButton.Hide();
            splitStayButton.Hide();

            utilities.createDeck(this);
        }

        //Starts game after the player's bets have been placed
        //Deals initial cards, then adds their value to the player's hand total
        //Need to make aces' value dynamic (1 or 11)
        //-------------------------------------------->Chip total is not being updated, need to fix <----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void dealButton_Click(object sender, EventArgs e)
        {
            bettingWindow betWindow = new bettingWindow();

            Boolean gameOver = false;

            playerFirstCard = deck[random.Next(deck.Count - 1)];
            //playerFirstCard.cardValue = 5;
            int firstCardValue = playerFirstCard.cardValue;
            savedPlayerCard1 = playerFirstCard.cardImageFile;
            utilities.displayCard(playerFirstCard, 405, 375, playerFirstCard.cardImage, this);
            deck.Remove(playerFirstCard);

            playerSecondCard = deck[random.Next(deck.Count - 1)];
            //playerSecondCard.cardValue = 5;
            int secondCardValue = playerSecondCard.cardValue;
            savedPlayerCard2 = playerSecondCard.cardImageFile;
            utilities.displayCard(playerSecondCard, 455, 375, playerSecondCard.cardImage, this);
            deck.Remove(playerSecondCard);

            form.player1.handTotal = form.player1.handTotal + playerFirstCard.cardValue + playerSecondCard.cardValue;
            playerHandTotalTextBox.Text = "Player Hand Total: " + form.player1.handTotal;

            dealerFirstCard = deck[random.Next(deck.Count - 1)];
            utilities.displayCard(dealerFirstCard, 405, 5, dealerFirstCard.cardImage, this);
            deck.Remove(dealerFirstCard);

            dealerSecondCard = deck[random.Next(deck.Count - 1)];
            savedFile = dealerSecondCard.cardImageFile; //saves image so that the card can be flipped over
            savedValue = dealerSecondCard.cardValue;
            dealerSecondCard.cardImageFile = @"C:\Users\Herndel\Desktop\Blackjack Project\Blackjack Images\card back.jpg"; //changes card image to card back
            utilities.displayCard(dealerSecondCard, 455, 5, dealerSecondCard.cardImage, this);
            deck.Remove(dealerSecondCard);

            dealer.handTotal = dealer.handTotal + dealerFirstCard.cardValue;
            dealerHandTotalTextBox.Text = "Dealer Hand Total: " + dealer.handTotal;

            dealButton.Hide();

            //Condition if player is dealt 21 and the dealer is not
            if (form.player1.handTotal == 21 && dealer.handTotal != 21)
            {
                gameOver = true;

                MessageBox.Show("Blackjack, you win!");

                form.player1.chipTotal = form.player1.chipTotal + (bet * 2);

                utilities.reset(this, this);
                utilities.resetHandTotals(this);
                deck.Clear();
                utilities.createDeck(this);

                betWindow.StartPosition = FormStartPosition.CenterScreen;
                betWindow.Show();
            }

            if (firstCardValue == secondCardValue)
            {
                splitButton.Show();

            }

            if (gameOver == false)
            {
                stayButton.Show();
                hitButton.Show();
                doubledownButton.Show();
            }
        }

        //Hit Button-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void hitButton_Click(object sender, EventArgs e)
        {
            bettingWindow betWindow = new bettingWindow();
            int xCoord = 505;
            var card = deck[random.Next(deck.Count - 1)];

            form.player1.handTotal = form.player1.handTotal + card.cardValue;
            utilities.displayCard(card, xCoord + pixelChange, 375, card.cardImage, this);
            playerHandTotalTextBox.Text = "Player Hand Total: " + form.player1.handTotal;
            deck.Remove(card);

            pixelChange = pixelChange + 50;

            //Condition if player's hand total exceeds 21
            if (form.player1.handTotal > 21)
            {
                MessageBox.Show("Hand total exceeded 21 You Lose");

                form.player1.chipTotal = form.player1.chipTotal - bet;
                Console.WriteLine(bet);
                Console.WriteLine(form.player1.chipTotal);

                utilities.reset(this, this);
                utilities.resetHandTotals(this);
                deck.Clear();
                utilities.createDeck(this);

                //form.player1.chipTotal = form.player1.chipTotal - bet;

                Console.WriteLine(form.player1.chipTotal);
                betWindow.currentChipsTextBox.Text = form.player1.chipTotal + "";

                this.Hide();
                betWindow.StartPosition = FormStartPosition.CenterScreen;
                betWindow.Show();
            }

            splitButton.Hide();
            doubledownButton.Hide();

            //makes it so user can only hit once if they decide to double down
            if (doubledown == true)
            {
                hitButton.Hide();
            }
        }


        //stay button-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void stayButton_Click(object sender, EventArgs e)
        {
            bettingWindow betWindow = new bettingWindow();
            
            int pixelChange = 0;

            utilities.displayImage(455, 5, new PictureBox(), this, savedFile);
            dealer.handTotal = dealer.handTotal + savedValue;
            dealerHandTotalTextBox.Text = "Dealer Hand Total: " + dealer.handTotal;


            //loop for dealing cards for the dealer
            while (dealer.handTotal < 17)
            {
                int xCoord = 505 + pixelChange;
                var card = deck[random.Next(deck.Count - 1)];

                dealer.handTotal = dealer.handTotal + card.cardValue;
                utilities.displayCard(card, xCoord, 5, card.cardImage, this);
                dealerHandTotalTextBox.Text = "Hand Total: " + dealer.handTotal;
                deck.Remove(card);

                pixelChange = pixelChange + 50;
            }

            //condition if player and dealer tie
            if (dealer.handTotal == form.player1.handTotal && dealer.handTotal <= 21)
            {
                MessageBox.Show("Push! Waged chips have been returned");

                form.player1.chipTotal = form.player1.chipTotal + bet;

                utilities.reset(this,this);
                utilities.resetHandTotals(this);
                deck.Clear();
                utilities.createDeck(this);

                betWindow.StartPosition = FormStartPosition.CenterScreen;
                betWindow.Show();
            }

            //condition if dealer goes over 21
            if (dealer.handTotal > 21 && form.player1.handTotal <= 21)
            {
                MessageBox.Show("Dealer busted. You win!");

                form.player1.chipTotal = form.player1.chipTotal + (bet * 2);

                utilities.reset(this,this);
                utilities.resetHandTotals(this);
                deck.Clear();
                utilities.createDeck(this);

                betWindow.StartPosition = FormStartPosition.CenterScreen;
                betWindow.Show();
            }

            //condition if dealer wins
            if (dealer.handTotal > form.player1.handTotal && dealer.handTotal <= 21)
            {
                MessageBox.Show("Dealer wins!");

                utilities.reset(this,this);
                utilities.resetHandTotals(this);
                deck.Clear();
                utilities.createDeck(this);

                betWindow.StartPosition = FormStartPosition.CenterScreen;
                betWindow.Show();
            }

            //condition if player wins
            if (dealer.handTotal < form.player1.handTotal && form.player1.handTotal <= 21)
            {
                MessageBox.Show("You win!");

                form.player1.chipTotal = form.player1.chipTotal + (bet * 2);

                utilities.reset(this,this);
                utilities.resetHandTotals(this);
                deck.Clear();
                utilities.createDeck(this);

                betWindow.StartPosition = FormStartPosition.CenterScreen;
                betWindow.Show();
            }

        }
        //double down button-------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void doubledownButton_Click(object sender, EventArgs e)
        {
            splitButton.Hide(); 

            bettingWindow betWindow = new bettingWindow();

            bet = bet * 2;

            doubledown = true;

            doubledownButton.Hide();
        }

        //split button-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void splitButton_Click(object sender, EventArgs e)
        {
            bettingWindow betWindow = new bettingWindow();
            

            hitButton.Hide();
            splitButton.Hide();
            doubledownButton.Hide();
            splitHitButton.Show();
            splitStayButton.Show();

            form.player1.chipTotal = form.player1.chipTotal - bet;
            first = true;

            //removes image from intial hand to be relocated 
            this.Controls.Remove(playerFirstCard.cardImage);
            this.Controls.Remove(playerSecondCard.cardImage);

            utilities.displayCard(playerFirstCard, 200, 200, new PictureBox(), this);
            utilities.displayCard(playerSecondCard, 675, 200, new PictureBox(), this);

            var firstHandCard = deck[random.Next(deck.Count - 1)];
            utilities.displayCard(firstHandCard, 200, 230, firstHandCard.cardImage, this);
            deck.Remove(firstHandCard);

            firstHandTotal = playerFirstCard.cardValue + firstHandCard.cardValue;
            playerHandTotalTextBox.Text = "First Hand Total: " + firstHandTotal;

            var secondHandCard = deck[random.Next(deck.Count - 1)];
            utilities.displayCard(secondHandCard, 675, 230, secondHandCard.cardImage, this);
            deck.Remove(secondHandCard);

            secondHandTotal = playerFirstCard.cardValue + secondHandCard.cardValue;

            pixelChange = 0;

        }

        //changed hit button if user decides to split-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void splitHitButton_Click(object sender, EventArgs e)
        {
            bettingWindow betWindow = new bettingWindow();
            int yCoord;

            //condition for second hand (this is placed before the first hand for hitting bug)
            if (first == false)
            {
                yCoord = 260;

                var card = deck[random.Next(deck.Count - 1)];

                secondHandTotal = secondHandTotal + card.cardValue;
                utilities.displayCard(card, 675, 260 + pixelChange, card.cardImage, this);
                playerHandTotalTextBox.Text = "Second Hand Total: " + secondHandTotal;
                deck.Remove(card);

                pixelChange = pixelChange + 30;

                //Condition if player's hand total exceeds 21
                if (secondHandTotal > 21)
                {
                    MessageBox.Show("Your second hand total exceeded 21. You Lose");
                    splitHitButton.Hide();
                }

                //Condition if both of the player's hand totals exceeds 21
                if (firstHandTotal > 21 && secondHandTotal > 21 )
                {
                    MessageBox.Show("Both hand totals exceeded 21. Game Over");

                    utilities.reset(this, this);
                    utilities.resetHandTotals(this);
                    deck.Clear();
                    utilities.createDeck(this);

                    betWindow.StartPosition = FormStartPosition.CenterScreen;
                    betWindow.Show();
                }
            }

            //condition for first hand
            if (first == true)
            {
                yCoord = 260;
                var card = deck[random.Next(deck.Count - 1)];

                firstHandTotal = firstHandTotal + card.cardValue;
                utilities.displayCard(card, 200, 260 + pixelChange, card.cardImage, this);
                playerHandTotalTextBox.Text = "First Hand Total: " + firstHandTotal;
                deck.Remove(card);

                pixelChange = pixelChange + 30;

                //Condition if player's hand total exceeds 21
                if (firstHandTotal > 21)
                {
                    MessageBox.Show("Your first hand total exceeded 21. You Lose");
                    playerHandTotalTextBox.Text = "Second Hand Total: " + secondHandTotal;

                    pixelChange = 0;
                    first = false;
                }
            }
        }

        //changed stay button if user decides to split-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void splitStayButton_Click(object sender, EventArgs e)
        {
            if (first == false)
            {

                bettingWindow betWindow = new bettingWindow();
                
                int pixelChange = 0;

                utilities.displayImage(455, 5, new PictureBox(), this, savedFile);
                dealer.handTotal = dealer.handTotal + savedValue;
                dealerHandTotalTextBox.Text = "Dealer Hand Total: " + dealer.handTotal;


                //loop for dealing cards for the dealer
                while (dealer.handTotal < 17)
                {
                    int xCoord = 505 + pixelChange;
                    var card = deck[random.Next(deck.Count - 1)];

                    dealer.handTotal = dealer.handTotal + card.cardValue;
                    utilities.displayCard(card, xCoord, 5, card.cardImage, this);
                    dealerHandTotalTextBox.Text = "Dealer Hand Total: " + dealer.handTotal;
                    deck.Remove(card);

                    pixelChange = pixelChange + 50;
                }

                //condition if player's FIRST hand and dealer tie
                if (dealer.handTotal == firstHandTotal && dealer.handTotal <= 21)
                {
                    MessageBox.Show("First Hand: Push! Waged chips have been returned");

                    form.player1.chipTotal = form.player1.chipTotal + bet;

                    if(secondHandTotal > 21)
                    {
                        utilities.reset(this, this);
                        utilities.resetHandTotals(this);
                        deck.Clear();
                        utilities.createDeck(this);

                        betWindow.StartPosition = FormStartPosition.CenterScreen;
                        betWindow.Show();
                    }
                }

                //condition if dealer goes over 21 for the player's FIRST hand
                if (dealer.handTotal > 21 && firstHandTotal <= 21)
                {
                    MessageBox.Show("First Hand: Dealer busted. You win!");

                    form.player1.chipTotal = form.player1.chipTotal + (bet * 2);

                    if (secondHandTotal > 21)
                    {
                        utilities.reset(this, this);
                        utilities.resetHandTotals(this);
                        deck.Clear();
                        utilities.createDeck(this);

                        betWindow.StartPosition = FormStartPosition.CenterScreen;
                        betWindow.Show();
                    }

                }

                //condition if dealer wins against player's FIRST hand
                if (dealer.handTotal > form.player1.handTotal && dealer.handTotal <= 21)
                {
                    MessageBox.Show("First Hand: Dealer wins!");

                    if (secondHandTotal > 21)
                    {
                        utilities.reset(this, this);
                        utilities.resetHandTotals(this);
                        deck.Clear();
                        utilities.createDeck(this);

                        betWindow.StartPosition = FormStartPosition.CenterScreen;
                        betWindow.Show();
                    }

                }

                //condition if player wins with FIRST hand
                if (dealer.handTotal < firstHandTotal && firstHandTotal <= 21)
                {
                    MessageBox.Show("First Hand: You win!");

                    form.player1.chipTotal = form.player1.chipTotal + (bet * 2);

                    if (secondHandTotal > 21)
                    {
                        utilities.reset(this, this);
                        utilities.resetHandTotals(this);
                        deck.Clear();
                        utilities.createDeck(this);

                        betWindow.StartPosition = FormStartPosition.CenterScreen;
                        betWindow.Show();
                    }
                }

                //condition if player wins with SECOND hand
                if (secondHandTotal > dealer.handTotal && secondHandTotal <= 21)
                {
                    MessageBox.Show("Second Hand: You win!");

                    form.player1.chipTotal = form.player1.chipTotal + (bet * 2);

                    utilities.reset(this, this);
                    utilities.resetHandTotals(this);
                    deck.Clear();
                    utilities.createDeck(this);

                    betWindow.StartPosition = FormStartPosition.CenterScreen;
                    betWindow.Show();
                }

                //condition if player's SECOND hand and dealer tie
                if (dealer.handTotal == secondHandTotal && dealer.handTotal <= 21)
                {
                    MessageBox.Show("Second Hand: Push! Waged chips have been returned");

                    form.player1.chipTotal = form.player1.chipTotal + bet;
                }

                //condition if dealer goes over 21 for the player's SECOND hand
                if (dealer.handTotal > 21 && secondHandTotal <= 21)
                {
                    MessageBox.Show("Second Hand: Dealer busted. You win!");

                    form.player1.chipTotal = form.player1.chipTotal + (bet * 2);

                    utilities.reset(this, this);
                    utilities.resetHandTotals(this);
                    deck.Clear();
                    utilities.createDeck(this);

                    betWindow.StartPosition = FormStartPosition.CenterScreen;
                    betWindow.Show();

                }

                //condition if dealer wins against player's SECOND hand
                if (dealer.handTotal > secondHandTotal && dealer.handTotal <= 21)
                {
                    MessageBox.Show("Second Hand: Dealer wins!");

                    utilities.reset(this, this);
                    utilities.resetHandTotals(this);
                    deck.Clear();
                    utilities.createDeck(this);

                    betWindow.StartPosition = FormStartPosition.CenterScreen;
                    betWindow.Show();

                }
            }

            if(first == true)
            {
                first = false;
                pixelChange = 0;
                playerHandTotalTextBox.Text = "Second Hand Total: " + secondHandTotal;
            }
            
        }
    }
}
