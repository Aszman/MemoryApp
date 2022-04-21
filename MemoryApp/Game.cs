using System;
using System.Drawing;
using System.Windows.Forms;

namespace MemoryApp
{
    public partial class Game : Form
    {

        private readonly MainMenu menu; // to get back to main menu form game's window
        private Settings settings; // to change settings during a game
        private Score score;

        private Card[] cards;

        private int hiddenCards; // number of still covered Cards
        private int rows, columns;

        // selected cards
        private Card firstCard = null;
        private Card secondCard = null;

        //states of game
        private bool isCardTurned = false;
        private bool isPaused = false;
        private bool isFinished = false;

        //constants for layout design
        private const int bottomSectionHeight = 120;

        public Game(MainMenu owner)
        {
            menu = owner;
            settings = Settings.getInstance();

            InitializeComponent();

            this.Width = settings.boardWidth;
            this.Height = settings.boardHeight + bottomSectionHeight;
            this.MaximumSize = new Size(Settings.boardWidthMax, Settings.boardHeightMax + bottomSectionHeight);
            this.MinimumSize = new Size(Settings.boardWidthMin, Settings.boardHeightMin + bottomSectionHeight);

            InitializeCards();
            ShuffleCards();
            SetObjectsLocation();
        }

        // sets number of cards depending of difficulty,
        // links picture with card  
        private void InitializeCards()
        {
            switch (menu.chosenDifficulty)
            {
                case MainMenu.Difficulties.EASY:
                    hiddenCards = 12;
                    rows = 3;
                    columns = 4;
                    score = new Score(menu.playerName, 2000);
                    break;

                case MainMenu.Difficulties.NORMAL:
                    hiddenCards = 36;
                    rows = columns = 6;
                    score = new Score(menu.playerName, 10000);
                    break;

                case MainMenu.Difficulties.HARD:
                    hiddenCards = 80;
                    rows = 8;
                    columns = 10;
                    score = new Score(menu.playerName, 50000);
                    break;
            }

            UpdateScore();

            this.cards = new Card[hiddenCards];

            for (int index = 0; index < hiddenCards; ++index)
            {
                Card newCard = new Card(index / 2);

                newCard.Front = Image.FromFile("..\\..\\Resources\\" + newCard.ID.ToString() + ".png");

                // if cards' front will be visible right after a start 
                if (settings.initShowTime != 0) 
                {
                    newCard.Image = newCard.Front;
                    newCard.Enabled = false;
                    isCardTurned = true;
                    btnSett.Enabled = false;

                }

                newCard.Click += new EventHandler(this.Card_Click);
                cards[index] = newCard;
                this.Controls.Add(cards[index]);
            }
        }

        // shuffles cards
        private void ShuffleCards()
        {
            Random rnd = new Random();

            for (int unShuffled = hiddenCards; unShuffled > 1; --unShuffled)
            {
                int rndTile = rnd.Next(0, unShuffled);

                Card temp = this.cards[rndTile];

                this.cards[rndTile] = this.cards[unShuffled - 1];
                this.cards[unShuffled - 1] = temp;
            }
        }

        //sets location of form's context and cards size
        private void SetObjectsLocation()
        {
            this.lblLine.Location = new Point(0, Height - bottomSectionHeight);
            this.btnSett.Location = new Point(10, Height - bottomSectionHeight + 25);
            this.lblScore.Location = new Point(Width - 200, Height - bottomSectionHeight + 20);

            this.boxPause.Location = new Point((Width - boxPause.Width) / 2, Height - bottomSectionHeight + 20);

            SetCardsLocationSize();
        }

        // sets cards location and size at start everytime when size of board was changed
        private void SetCardsLocationSize()
        {
            int fixedBoardWith = this.Width - 10;
            int fixedBoardHeight = this.Height - bottomSectionHeight;

            int optimalCardSize = Math.Min(fixedBoardWith / (columns + 1), fixedBoardHeight / (rows + 1)); ;
            int widthPadding = (fixedBoardWith - columns * optimalCardSize) / (columns + 1);
            int heightPadding = (fixedBoardHeight - rows * optimalCardSize) / (rows + 1);

            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < columns; ++j)
                {

                    Card card = this.cards[i * columns + j];

                    // size        
                    card.Width = optimalCardSize;
                    card.Height = optimalCardSize;

                    // location
                    card.Location = new Point(widthPadding * (j + 1) + optimalCardSize * j, heightPadding * (i + 1) + optimalCardSize * i);
                }
            }
        }

        private bool equalIDs(Card first, Card second)
        {
            if (first.ID == second.ID)
            {
                return true;
            }

            return false;
        }

        private void Pause()
        {
            this.timScore.Enabled = false;
            boxPause.Image = global::MemoryApp.Properties.Resources.play_button;
            isPaused = true;

        }

        private void Unpause()
        {
            this.timScore.Enabled = true;
            boxPause.Image = global::MemoryApp.Properties.Resources.pauseIcon;
            isPaused = false;
        }

        private void UpdateScore()
        {
            lblScore.Text = "Score: " + score.getScore().ToString();
        }

        private void GameFinish()
        {
            isFinished = true;
            timScore.Stop();

            HighScore.getInstance().AddScore(score);
            HighScore.getInstance().ShowDialog();

        }

        // runs when form is first time displayed
        private void Game_Shown(object sender, EventArgs e)
        {
            if (settings.initShowTime != 0) // starts timer if value is positive
            {
                this.timInit.Interval = settings.initShowTime * 1000;
                this.timInit.Enabled = true;
            }

            this.timBad.Interval = Convert.ToInt32(settings.cardsShowTime * 1000);
            this.timScore.Enabled = true;
        }

        private void Game_ResizeEnd(object sender, EventArgs e)
        {
            SetObjectsLocation();

            settings.boardWidth = this.Width;
            settings.boardHeight = this.Height - bottomSectionHeight;
        }

        private void Game_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isFinished)
            {
                DialogResult response = MessageBox.Show("Do you really want to exit? Progress won't be saved.", "Exit", MessageBoxButtons.YesNo);

                switch (response)
                {
                    case DialogResult.Yes:
                        menu.Show();
                        break;
                    case DialogResult.No:
                        e.Cancel = true;
                        break;
                }
            }
            else
            {
                menu.Show();
            }
        }

        private void Card_Click(object sender, EventArgs e)
        {
            if (!isPaused) //can't turn card when game is paused
            {
                if (firstCard == null) // if it was first card
                {
                    firstCard = (Card)sender;

                    firstCard.Image = firstCard.Front;
                    firstCard.Enabled = false;

                    isCardTurned = true;
                    btnSett.Enabled = false;
                }
                else if (secondCard == null) // if it was second card
                {
                    secondCard = (Card)sender;

                    secondCard.Image = secondCard.Front;
                    secondCard.Enabled = false;

                    if (equalIDs(firstCard, secondCard))
                    {
                        timGood.Start();

                    }
                    else
                    {
                        timBad.Start();
                    }
                }
            }
        }

        private void timInit_Tick(object sender, EventArgs e)
        {
            foreach (Card c in cards)
            {
                c.Image = null;
                c.Enabled = true;
            }

            timInit.Enabled = false;
            isCardTurned = false;
            btnSett.Enabled = true;
        }

        // pair was wrong
        private void timGood_Tick(object sender, EventArgs e)
        {
            timGood.Stop();

            firstCard.Visible = false;
            firstCard.Front.Dispose();
            firstCard.Image.Dispose();
            firstCard = null;

            secondCard.Visible = false;
            secondCard.Front.Dispose();
            secondCard.Image.Dispose();
            secondCard = null;

            hiddenCards -= 2;
            score.madePair();
            UpdateScore();

            isCardTurned = false;
            btnSett.Enabled = true;

            if (hiddenCards == 0)
            {
                GameFinish();
            }
        }

        // pair was correct
        private void timBad_Tick(object sender, EventArgs e)
        {
            timBad.Stop();

            firstCard.Enabled = true;
            firstCard.Image = null;
            firstCard = null;

            secondCard.Enabled = true;
            secondCard.Image = null;
            secondCard = null;

            score.madeMistake();
            UpdateScore();

            isCardTurned = false;
            btnSett.Enabled = true;
        }



        private void boxPause_Click(object sender, EventArgs e)
        {
            if (!isCardTurned && !isPaused) //cant pause when game is paused or card is turned
            {
                Pause();

            }
            else if (isPaused) //unpause when game is paused
            {
                Unpause();
            }
        }

        private void timScore_Tick(object sender, EventArgs e)
        {
            score.substractValue(1);
            UpdateScore();
        }

        private void btnSett_Click(object sender, EventArgs e)
        {
            if (!isPaused)
            {
                Pause();
            }

            settings.ShowDialog();

            this.Width = settings.boardWidth;
            this.Height = settings.boardHeight + bottomSectionHeight;

            timInit.Interval = settings.initShowTime * 1000;
            timBad.Interval = Convert.ToInt32(settings.cardsShowTime * 1000);

            SetObjectsLocation();
        }
    }
}
