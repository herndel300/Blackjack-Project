using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace BlackjackProject
{
    public partial class onePlayerGame : Form
    {
        //Need to fix: 
        //fix music looping
        //finish design document

        Random random = new Random();
        Utilities utilities = new Utilities();
        public Dealer dealer = new Dealer();
        public Form1 form = new Form1();
        public List<Card> deck;

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
        public Card secondHandCard;

        public int pixelChange = 0;
        public Boolean doubledown = false;
        public Boolean first = true;
        public Boolean gameOver = false;

        public int bet;
        public int savedChips;
        public Boolean musicIsPlaying;

        public onePlayerGame()
        {
            InitializeComponent();
            form.musicIsPlaying = true;
            this.MaximizeBox = false;

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
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void dealButton_Click(object sender, EventArgs e)
        {
            bettingWindow betWindow = new bettingWindow();
            betWindow.form.player1.chipTotal = savedChips;

            playerFirstCard = deck[random.Next(deck.Count - 1)];
            form.player1.hand.Add(playerFirstCard);
            //playerFirstCard.cardValue = 8;
            int firstCardValue = playerFirstCard.cardValue;
            savedPlayerCard1 = playerFirstCard.cardImageFile;
            utilities.displayCard(playerFirstCard, 405, 375, playerFirstCard.cardImage, this);
            deck.Remove(playerFirstCard);

            playerSecondCard = deck[random.Next(deck.Count - 1)];
            form.player1.hand.Add(playerSecondCard);
            //playerSecondCard.cardValue = 8;
            int secondCardValue = playerSecondCard.cardValue;
            savedPlayerCard2 = playerSecondCard.cardImageFile;
            utilities.displayCard(playerSecondCard, 455, 375, playerSecondCard.cardImage, this);
            deck.Remove(playerSecondCard);

            form.player1.handTotal = form.player1.handTotal + playerFirstCard.cardValue + playerSecondCard.cardValue;
            utilities.checkAcesPlayer(form);
            playerHandTotalTextBox.Text = "Player Hand Total: " + form.player1.handTotal;

            dealerFirstCard = deck[random.Next(deck.Count - 1)];
            //dealerFirstCard.cardValue = 11;
            dealer.hand.Add(dealerFirstCard);
            utilities.displayCard(dealerFirstCard, 405, 5, dealerFirstCard.cardImage, this);
            deck.Remove(dealerFirstCard);

            dealerSecondCard = deck[random.Next(deck.Count - 1)];
            //dealerSecondCard.cardValue = 11;
            dealer.hand.Add(dealerSecondCard);
            savedFile = dealerSecondCard.cardImageFile; //saves image so that the card can be flipped over
            savedValue = dealerSecondCard.cardValue;
            dealerSecondCard.cardImageFile = @"C:\Users\Herndel\Desktop\Blackjack Project\Blackjack Images\card back.jpg"; //changes card image to card back
            utilities.displayCard(dealerSecondCard, 455, 5, dealerSecondCard.cardImage, this);
            deck.Remove(dealerSecondCard);

            dealer.handTotal = dealer.handTotal + dealerFirstCard.cardValue + dealerSecondCard.cardValue;
            utilities.checkAcesDealer(dealer);

            if (dealerFirstCard.cardValue == 1)
            {
                dealerHandTotalTextBox.Text = "Dealer Hand Total: " + (dealerFirstCard.cardValue + 10);
            }

            else
            {
                dealerHandTotalTextBox.Text = "Dealer Hand Total: " + dealerFirstCard.cardValue;
            }

            dealButton.Hide();

            //Condition if player is dealt 21 and the dealer is not
            if (form.player1.handTotal == 21 && dealer.handTotal != 21)
            {
                gameOver = true;

                MessageBox.Show("Blackjack, you win!");

                betWindow.form.player1.chipTotal = betWindow.form.player1.chipTotal + (bet * 2);

                utilities.reset(this, this);
                utilities.resetHandTotals(this);
                deck.Clear();
                utilities.createDeck(this);

                this.Hide();
                betWindow.StartPosition = FormStartPosition.CenterScreen;
                betWindow.Show();
                betWindow.currentChipsTextBox.Text = betWindow.form.player1.chipTotal + "";
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
            betWindow.form.player1.chipTotal = savedChips;

            int xCoord = 505;
            var card = deck[random.Next(deck.Count - 1)];
            //card.cardValue = 11;
            form.player1.hand.Add(card);
        
            form.player1.handTotal = form.player1.handTotal + card.cardValue;
            utilities.checkAcesPlayer(form);
            utilities.displayCard(card, xCoord + pixelChange, 375, card.cardImage, this);
            playerHandTotalTextBox.Text = "Player Hand Total: " + form.player1.handTotal;
            deck.Remove(card);

            pixelChange = pixelChange + 50;

            //Condition if player's hand total exceeds 21
            if (form.player1.handTotal > 21)
            {
                gameOver = true;

                MessageBox.Show("Hand total exceeded 21 You Lose");

                utilities.reset(this, this);
                utilities.resetHandTotals(this);
                deck.Clear();
                utilities.createDeck(this);

                if (betWindow.form.player1.chipTotal <= 0)
                {
                    MessageBox.Show("You ran out of chips. GAME OVER!");
                    this.Hide();
                    form.StartPosition = FormStartPosition.CenterScreen;
                    form.Show();
                }

                else
                {
                    this.Hide();
                    betWindow.StartPosition = FormStartPosition.CenterScreen;
                    betWindow.Show();
                    betWindow.currentChipsTextBox.Text = betWindow.form.player1.chipTotal + "";
                }
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
            betWindow.form.player1.chipTotal = savedChips;

            int pixelChange = 0;

            utilities.displayImage(455, 5, new PictureBox(), this, savedFile);
            //dealer.handTotal = dealer.handTotal + savedValue;
            dealerHandTotalTextBox.Text = "Dealer Hand Total: " + dealer.handTotal;


            //loop for dealing cards for the dealer
            while (dealer.handTotal < 17)
            {
                int xCoord = 505 + pixelChange;
                var card = deck[random.Next(deck.Count - 1)];
                //card.cardValue = 11;
                dealer.hand.Add(card);

                dealer.handTotal = dealer.handTotal + card.cardValue;
                utilities.checkAcesDealer(dealer);
                utilities.displayCard(card, xCoord, 5, card.cardImage, this);
                dealerHandTotalTextBox.Text = "Dealer Hand Total: " + dealer.handTotal;
                deck.Remove(card);

                pixelChange = pixelChange + 50;
            }

            //condition if player and dealer tie
            if (dealer.handTotal == form.player1.handTotal && dealer.handTotal <= 21 && gameOver == false)
            {
                gameOver = true;
                MessageBox.Show("Push! Waged chips have been returned");

                betWindow.form.player1.chipTotal = betWindow.form.player1.chipTotal + bet;

                utilities.reset(this,this);
                utilities.resetHandTotals(this);
                deck.Clear();
                utilities.createDeck(this);

                this.Hide();
                betWindow.StartPosition = FormStartPosition.CenterScreen;
                betWindow.Show();
                betWindow.currentChipsTextBox.Text = betWindow.form.player1.chipTotal + "";
            }

            //condition if dealer goes over 21
            if (dealer.handTotal > 21 && form.player1.handTotal <= 21 && gameOver == false)
            {
                gameOver = true;

                MessageBox.Show("Dealer busted. You win!");

                betWindow.form.player1.chipTotal = betWindow.form.player1.chipTotal + (bet * 2);

                utilities.reset(this,this);
                utilities.resetHandTotals(this);
                deck.Clear();
                utilities.createDeck(this);

                this.Hide();
                betWindow.StartPosition = FormStartPosition.CenterScreen;
                betWindow.Show();
                betWindow.currentChipsTextBox.Text = betWindow.form.player1.chipTotal + "";
            }

            //condition if dealer wins
            if (dealer.handTotal > form.player1.handTotal && dealer.handTotal <= 21 && gameOver == false)
            {
                gameOver = true;

                MessageBox.Show("Dealer wins!");

                utilities.reset(this,this);
                utilities.resetHandTotals(this);
                deck.Clear();
                utilities.createDeck(this);

                if (betWindow.form.player1.chipTotal <= 0)
                {
                    MessageBox.Show("You ran out of chips. GAME OVER!");
                    this.Hide();
                    form.StartPosition = FormStartPosition.CenterScreen;
                    form.Show();
                }

                else
                {
                    this.Hide();
                    betWindow.StartPosition = FormStartPosition.CenterScreen;
                    betWindow.Show();
                    betWindow.currentChipsTextBox.Text = betWindow.form.player1.chipTotal + "";
                }
            }

            //condition if player wins
            if (dealer.handTotal < form.player1.handTotal && form.player1.handTotal <= 21 && gameOver == false)
            {
                gameOver = true;

                MessageBox.Show("You win!");

                betWindow.form.player1.chipTotal = betWindow.form.player1.chipTotal + (bet * 2);

                utilities.reset(this,this);
                utilities.resetHandTotals(this);
                deck.Clear();
                utilities.createDeck(this);

                this.Hide();
                betWindow.StartPosition = FormStartPosition.CenterScreen;
                betWindow.Show();
                betWindow.currentChipsTextBox.Text = betWindow.form.player1.chipTotal + "";
            }

        }
        //double down button-------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void doubledownButton_Click(object sender, EventArgs e)
        {
            if(bet * 2 < savedChips)
            {
                splitButton.Hide();

                bettingWindow betWindow = new bettingWindow();
                savedChips = savedChips - bet;

                bet = bet * 2;

                doubledown = true;

                doubledownButton.Hide();
            }

            else
            {
                MessageBox.Show("Insufficient amount of chips!");
            }
           
        }

        //split button-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void splitButton_Click(object sender, EventArgs e)
        {
            bettingWindow betWindow = new bettingWindow();
            form.player1.handTotal = 0;

            splitHitButton.Text = "Hit1";
            splitStayButton.Text = "Stay1";
            
            foreach(Card card in form.player1.hand)
            {
                if(card.cardValue == 1)
                {
                    card.cardValue = 11;
                }
            }

            form.player1.hand.Clear();

            hitButton.Hide();
            splitButton.Hide();
            doubledownButton.Hide();
            splitHitButton.Show();
            splitStayButton.Show();

            savedChips = savedChips - bet;

            //removes image from intial hand to be relocated 
            this.Controls.Remove(playerFirstCard.cardImage);
            this.Controls.Remove(playerSecondCard.cardImage);

            utilities.displayCard(playerFirstCard, 200, 200, new PictureBox(), this);
            utilities.displayCard(playerSecondCard, 675, 200, new PictureBox(), this);

            var firstHandCard = deck[random.Next(deck.Count - 1)];
            //firstHandCard.cardValue = 11;
            form.player1.hand.Add(firstHandCard);
            form.player1.hand.Add(playerFirstCard);
            utilities.displayCard(firstHandCard, 200, 230, firstHandCard.cardImage, this);
            deck.Remove(firstHandCard);

            firstHandTotal = playerFirstCard.cardValue + firstHandCard.cardValue;
            playerHandTotalTextBox.Text = "First Hand Total: " + firstHandTotal;

            secondHandCard = deck[random.Next(deck.Count - 1)];
            //secondHandCard.cardValue = 11;
            utilities.displayCard(secondHandCard, 675, 230, secondHandCard.cardImage, this);
            deck.Remove(secondHandCard);

            secondHandTotal = playerFirstCard.cardValue + secondHandCard.cardValue;

            pixelChange = 0;

        }

        //changed hit button if user decides to split-------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void splitHitButton_Click(object sender, EventArgs e)
        {
            bettingWindow betWindow = new bettingWindow();
            betWindow.form.player1.chipTotal = savedChips;

            int yCoord;

            //condition for second hand (this is placed before the first hand for hitting bug)
            if (first == false)
            {
                yCoord = 260;
                form.player1.hand.Clear();
                form.player1.hand.Add(playerSecondCard);
                form.player1.hand.Add(secondHandCard);

                //form.player1.handTotal = 0;

                var card = deck[random.Next(deck.Count - 1)];
                //card.cardValue = 11;
                form.player1.hand.Add(card);

                secondHandTotal = secondHandTotal + card.cardValue;
                form.player1.handTotal = secondHandTotal;
                utilities.checkAcesPlayer(form);
                secondHandTotal = form.player1.handTotal;

                utilities.displayCard(card, 675, 260 + pixelChange, card.cardImage, this);
                playerHandTotalTextBox.Text = "Second Hand Total: " + secondHandTotal;
                deck.Remove(card);

                pixelChange = pixelChange + 30;

                //Condition if player's hand total exceeds 21
                if (secondHandTotal > 21)
                {
                    MessageBox.Show("Your second hand total exceeded 21. You Lose");
                    gameOver = true;
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

                    if (betWindow.form.player1.chipTotal <= 0)
                    {
                        MessageBox.Show("You ran out of chips. GAME OVER!");
                        this.Hide();
                        form.StartPosition = FormStartPosition.CenterScreen;
                        form.Show();
                    }

                    else
                    {
                        this.Hide();
                        betWindow.StartPosition = FormStartPosition.CenterScreen;
                        betWindow.Show();
                        betWindow.currentChipsTextBox.Text = betWindow.form.player1.chipTotal + "";
                    }
                }
            }

            //condition for first hand
            if (first == true)
            {
                yCoord = 260;
                var card = deck[random.Next(deck.Count - 1)];
                //card.cardValue = 10;
                form.player1.hand.Add(card);

                firstHandTotal = firstHandTotal + card.cardValue;
                form.player1.handTotal = firstHandTotal;
                utilities.checkAcesPlayer(form);
                firstHandTotal = form.player1.handTotal;

                utilities.displayCard(card, 200, 260 + pixelChange, card.cardImage, this);
                playerHandTotalTextBox.Text = "First Hand Total: " + firstHandTotal;
                deck.Remove(card);

                pixelChange = pixelChange + 30;

                //Condition if player's hand total exceeds 21
                if (form.player1.handTotal > 21)
                {
                    form.player1.hand.Clear();
                    form.player1.hand.Add(playerSecondCard);
                    form.player1.hand.Add(secondHandCard);

                    MessageBox.Show("Your first hand total exceeded 21. You Lose");

                    splitHitButton.Text = "Hit2";
                    splitStayButton.Text = "Stay2";
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
                betWindow.form.player1.chipTotal = savedChips;

                int pixelChange = 0;

                utilities.displayImage(455, 5, new PictureBox(), this, savedFile);
                //dealer.handTotal = dealer.handTotal;
                dealerHandTotalTextBox.Text = "Dealer Hand Total: " + dealer.handTotal;


                //loop for dealing cards for the dealer
                while (dealer.handTotal < 17)
                {
                    int xCoord = 505 + pixelChange;
                    var card = deck[random.Next(deck.Count - 1)];
                    dealer.hand.Add(card);

                    dealer.handTotal = dealer.handTotal + card.cardValue;
                    utilities.checkAcesDealer(dealer);
                    utilities.displayCard(card, xCoord, 5, card.cardImage, this);
                    dealerHandTotalTextBox.Text = "Dealer Hand Total: " + dealer.handTotal;
                    deck.Remove(card);

                    pixelChange = pixelChange + 50;
                }

                //condition if player's FIRST hand and dealer tie
                if (dealer.handTotal == firstHandTotal && dealer.handTotal <= 21)
                {
                    MessageBox.Show("First Hand: Push! Waged chips have been returned");

                    betWindow.form.player1.chipTotal = betWindow.form.player1.chipTotal + bet;

                    if(secondHandTotal > 21)
                    {
                        utilities.reset(this, this);
                        utilities.resetHandTotals(this);
                        deck.Clear();
                        utilities.createDeck(this);

                        this.Hide();
                        betWindow.StartPosition = FormStartPosition.CenterScreen;
                        betWindow.Show();
                        betWindow.currentChipsTextBox.Text = betWindow.form.player1.chipTotal + "";
                    }
                }

                //condition if dealer goes over 21 for the player's FIRST hand
                if (dealer.handTotal > 21 && firstHandTotal <= 21)
                {
                    MessageBox.Show("First Hand: Dealer busted. You win!");

                    betWindow.form.player1.chipTotal = betWindow.form.player1.chipTotal + (bet * 2);

                    if (secondHandTotal > 21)
                    {
                        utilities.reset(this, this);
                        utilities.resetHandTotals(this);
                        deck.Clear();
                        utilities.createDeck(this);

                        this.Hide();
                        betWindow.StartPosition = FormStartPosition.CenterScreen;
                        betWindow.Show();
                        betWindow.currentChipsTextBox.Text = betWindow.form.player1.chipTotal + "";
                    }

                }

                //condition if dealer wins against player's FIRST hand
                if (dealer.handTotal > firstHandTotal && dealer.handTotal <= 21)
                {
                    MessageBox.Show("First Hand: Dealer wins!");

                    if (secondHandTotal > 21)
                    {
                        utilities.reset(this, this);
                        utilities.resetHandTotals(this);
                        deck.Clear();
                        utilities.createDeck(this);

                        this.Hide();
                        betWindow.StartPosition = FormStartPosition.CenterScreen;
                        betWindow.Show();
                        betWindow.currentChipsTextBox.Text = betWindow.form.player1.chipTotal + "";
                    }

                }

                //condition if player wins with FIRST hand
                if ((dealer.handTotal < firstHandTotal && firstHandTotal <= 21) && dealer.handTotal != 0)
                {
                    MessageBox.Show("First Hand: You win!");

                    betWindow.form.player1.chipTotal = betWindow.form.player1.chipTotal + (bet * 2);

                    if (gameOver == true)
                    {
                        utilities.reset(this, this);
                        utilities.resetHandTotals(this);
                        deck.Clear();
                        utilities.createDeck(this);

                        this.Hide();
                        betWindow.StartPosition = FormStartPosition.CenterScreen;
                        betWindow.Show();
                        betWindow.currentChipsTextBox.Text = betWindow.form.player1.chipTotal + "";
                    }
                }

                //condition if player wins with SECOND hand
                if (secondHandTotal > dealer.handTotal && secondHandTotal <= 21)
                {
                    MessageBox.Show("Second Hand: You win!");

                    betWindow.form.player1.chipTotal = betWindow.form.player1.chipTotal + (bet * 2);

                    utilities.reset(this, this);
                    utilities.resetHandTotals(this);
                    deck.Clear();
                    utilities.createDeck(this);

                    this.Hide();
                    betWindow.StartPosition = FormStartPosition.CenterScreen;
                    betWindow.Show();
                    betWindow.currentChipsTextBox.Text = betWindow.form.player1.chipTotal + "";
                }

                //condition if player's SECOND hand and dealer tie
                if (dealer.handTotal == secondHandTotal && dealer.handTotal <= 21)
                {
                    betWindow.form.player1.chipTotal = betWindow.form.player1.chipTotal + bet;
                    MessageBox.Show("Second Hand: Push! Waged chips have been returned");

                    utilities.reset(this, this);
                    utilities.resetHandTotals(this);
                    deck.Clear();
                    utilities.createDeck(this);

                    this.Hide();
                    betWindow.StartPosition = FormStartPosition.CenterScreen;
                    betWindow.Show();
                    betWindow.currentChipsTextBox.Text = betWindow.form.player1.chipTotal + "";

                }

                //condition if dealer goes over 21 for the player's SECOND hand
                if (dealer.handTotal > 21 && secondHandTotal <= 21)
                {
                    MessageBox.Show("Second Hand: Dealer busted. You win!");

                    betWindow.form.player1.chipTotal = betWindow.form.player1.chipTotal + (bet * 2);

                    utilities.reset(this, this);
                    utilities.resetHandTotals(this);
                    deck.Clear();
                    utilities.createDeck(this);

                    if (betWindow.form.player1.chipTotal <= 0)
                    {
                        MessageBox.Show("You ran out of chips. GAME OVER!");
                        this.Hide();
                        form.StartPosition = FormStartPosition.CenterScreen;
                        form.Show();
                    }

                    else
                    {
                        this.Hide();
                        betWindow.StartPosition = FormStartPosition.CenterScreen;
                        betWindow.Show();
                        betWindow.currentChipsTextBox.Text = betWindow.form.player1.chipTotal + "";
                    }

                }

                //condition if dealer wins against player's SECOND hand
                if (dealer.handTotal > secondHandTotal && dealer.handTotal <= 21)
                {
                    MessageBox.Show("Second Hand: Dealer wins!");

                    utilities.reset(this, this);
                    utilities.resetHandTotals(this);
                    deck.Clear();
                    utilities.createDeck(this);

                    if (betWindow.form.player1.chipTotal <= 0)
                    {
                        MessageBox.Show("You ran out of chips. GAME OVER!");
                        this.Hide();
                        form.StartPosition = FormStartPosition.CenterScreen;
                        form.Show();
                    }

                    else
                    {
                        this.Hide();
                        betWindow.StartPosition = FormStartPosition.CenterScreen;
                        betWindow.Show();
                        betWindow.currentChipsTextBox.Text = betWindow.form.player1.chipTotal + "";
                    }

                }
            }

            if(first == true)
            {
                first = false;
                pixelChange = 0;
                playerHandTotalTextBox.Text = "Second Hand Total: " + secondHandTotal;

                splitHitButton.Text = "Hit2";
                splitStayButton.Text = "Stay2";
            }
            
        }

        private void exitGameButton_Click(object sender, EventArgs e)
        {
            form.musicIsPlaying = true;
            this.Hide();
            form.Show();
        }
    }
}
