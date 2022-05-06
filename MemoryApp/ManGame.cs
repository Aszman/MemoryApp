using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryApp
{
    class ManGame
    {
        private frmGame gameForm;

        private string player;
        private frmMainMenu.Difficulties difficulty;
        frmSettings settingsForm;
        frmHighScore highScoreForm;

        private ManHighScore highScore;
        private ManSettings settings; // to change settings during a game
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


        public ManGame(frmGame frmGame, frmMainMenu.Difficulties difficulty, string playerName)
        {
            this.gameForm = frmGame;
            this.difficulty = difficulty;
            this.player = playerName;

            settingsForm = new frmSettings();
            highScoreForm = new frmHighScore();

            settings = ManSettings.getInstance();
            highScore = ManHighScore.getInstance();

            gameForm.Width = settings.boardWidth;
            gameForm.Height = settings.boardHeight + bottomSectionHeight;
            gameForm.MaximumSize = new Size(ManSettings.boardWidthMax, ManSettings.boardHeightMax + bottomSectionHeight);
            gameForm.MinimumSize = new Size(ManSettings.boardWidthMin, ManSettings.boardHeightMin + bottomSectionHeight);

            InitializeCards();
            ShuffleCards();
            gameForm.SetObjectsLocation(bottomSectionHeight);
            SetCardsLocationSize();
        }

        // sets number of cards depending of difficulty,
        // links picture with card  
        private void InitializeCards()
        {
            switch (this.difficulty)
            {
                case frmMainMenu.Difficulties.EASY:
                    hiddenCards = 12;
                    rows = 3;
                    columns = 4;
                    score = new Score(this.player, 2000);
                    break;

                case frmMainMenu.Difficulties.NORMAL:
                    hiddenCards = 36;
                    rows = columns = 6;
                    score = new Score(this.player, 10000);
                    break;

                case frmMainMenu.Difficulties.HARD:
                    hiddenCards = 80;
                    rows = 8;
                    columns = 10;
                    score = new Score(this.player, 50000);
                    break;
            }

            gameForm.UpdateScore(score);

            this.cards = new Card[hiddenCards];

            for (int index = 0; index < hiddenCards; ++index)
            {
                Card newCard = new Card(index / 2);

                newCard.Front = Image.FromFile("..\\..\\Resources\\" + newCard.ID.ToString() + ".png");

                // if cards' front will be visible right after a start 
                if (settings.initCardsShowTime != 0)
                {
                    newCard.Image = newCard.Front;
                    newCard.Enabled = false;
                    isCardTurned = true;
                    gameForm.btnSettEnable(false);

                }

                cards[index] = newCard;
                gameForm.addCard(cards[index]);
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

        // sets cards location and size at start everytime when size of board was changed
        private void SetCardsLocationSize()
        {
            int fixedBoardWith = gameForm.Width - 10;
            int fixedBoardHeight = gameForm.Height - bottomSectionHeight;

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
            gameForm.Pause();
            isPaused = true;
        }

        private void Unpause()
        {
            gameForm.Unpause();
            isPaused = false;
        }

        private void GameFinish()
        {
            isFinished = true;
            gameForm.StopScoreTimer();

            highScore.AddScore(score);
            highScoreForm.ShowDialog();
        }

        public int getInitShowTime()
        {
            return settings.initCardsShowTime;
        }

        public double getFaceUpShowTime()
        {
            return settings.cardsFaceUpShowTime;
        }

        public void windowResize()
        {
            gameForm.SetObjectsLocation(bottomSectionHeight);
            SetCardsLocationSize();

            settings.boardWidth = gameForm.Width;
            settings.boardHeight = gameForm.Height - bottomSectionHeight;
        }

        public void windowClose(frmMainMenu menu, FormClosingEventArgs e)
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

        public void cardClick(Card card)
        {
            if (!isPaused) //can't turn card when game is paused
            {
                if (firstCard == null) // if it was first card
                {
                    firstCard = card;

                    firstCard.Image = firstCard.Front;
                    firstCard.Enabled = false;

                    isCardTurned = true;
                    gameForm.btnSettEnable(false);

                }
                else if (secondCard == null) // if it was second card
                {
                    secondCard = card;

                    secondCard.Image = secondCard.Front;
                    secondCard.Enabled = false;

                    if (equalIDs(firstCard, secondCard))
                    {
                        gameForm.StartGoodTimer();

                    }
                    else
                    {
                        gameForm.StartBadTimer();
                    }
                }
            }
        }
  
        public void disableCards()
        {
            foreach (Card c in cards)
            {
                c.Image = null;
                c.Enabled = true;
            }

            isCardTurned = false;
        }

        public void GoodTimerTick()
        {
            gameForm.StopGoodTimer();

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
            gameForm.UpdateScore(score);

            isCardTurned = false;
            gameForm.btnSettEnable(true);


            if (hiddenCards == 0)
            {
                GameFinish();
            }
        }

        public void BadTimerTick()
        {
            gameForm.StopBadTimer();

            firstCard.Enabled = true;
            firstCard.Image = null;
            firstCard = null;

            secondCard.Enabled = true;
            secondCard.Image = null;
            secondCard = null;

            score.madeMistake();
            gameForm.UpdateScore(score);

            isCardTurned = false;
            gameForm.btnSettEnable(true);
        }

        public void ScoreTimerTick()
        {
            score.substractValue(1);
            gameForm.UpdateScore(score);
        }

        public void PauseClicked()
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

        public void SettingsClicked()
        {
            if (!isPaused)
            {
                Pause();
            }

            settingsForm.ShowDialog();

            gameForm.Width = settings.boardWidth;
            gameForm.Height = settings.boardHeight + bottomSectionHeight;

            gameForm.SetObjectsLocation(bottomSectionHeight);
            SetCardsLocationSize();
        }
    }

}
