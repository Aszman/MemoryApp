using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryApp
{
    public partial class Game : Form
    {
        readonly MainMenu menu;
       
        Card[] cards;
        int hiddenTiles;
        int rows, columns;

        Card firstCard = null;
        Card secondCard = null;

        bool isCardTurned = false;
        bool isPaused = false;

        const int bottomSectionHeight = 120;

        FormWindowState? lastWindowState;

        public Game(MainMenu owner)
        {
            menu = owner;

            InitializeComponent();

            InitializeTiles();
            ShuffleTiles();
            setObjectsLocation();
            
        }

        private void setObjectsLocation()
        {
            this.Width = menu.settings.boardWidth;
            this.Height = menu.settings.boardHeight + bottomSectionHeight;
            this.MaximumSize = new Size(menu.settings.boardWidthMax, menu.settings.boardHeightMax + bottomSectionHeight);
            this.MinimumSize = new Size(menu.settings.boardWidthMin, menu.settings.boardHeightMin + bottomSectionHeight);

            this.lblLine.Location = new Point(0, Height - bottomSectionHeight);
            this.btnSett.Location = new Point(10, Height - bottomSectionHeight + 25);

            this.boxPause.Location = new Point((Width - boxPause.Width) / 2, Height - bottomSectionHeight + 20) ;

            SetTilesLocationSize();
        }

        private void InitializeTiles()
        {
            switch (menu.chosenDifficulty)
            {
                case MainMenu.Difficulties.EASY:
                    hiddenTiles = 12;
                    rows = 3;
                    columns = 4;
                    break;

                case MainMenu.Difficulties.NORMAL:
                    hiddenTiles = 36;
                    rows = columns = 6;
                    break;

                case MainMenu.Difficulties.HARD:
                    hiddenTiles = 80;
                    rows = 8;
                    columns = 10;
                    break;
            }
            this.cards = new Card[hiddenTiles];

            for(int i = 0; i < rows; ++i)
            {
                for(int j = 0; j < columns; ++j)
                {

                    int index = i * columns + j;
                    Card newCard = new Card();

                    newCard.ImageID = index / 2;
                    if (menu.settings.initShowTime != 0)
                    {
                        newCard.Text = (index / 2).ToString();
                        newCard.Enabled = false;
                        isCardTurned = true;
                    }

                    //newCard.Font = new Font(newCard.Font.Name, 12F);
                    //newCard.TabStop = false;
                    newCard.Click += new System.EventHandler(this.Card_Click);
                    cards[index] = newCard;


                    this.Controls.Add(cards[index]);
                }

            }
        }

        private void ShuffleTiles()
        {
            Random rnd = new Random();

            for(int unShuffled = hiddenTiles; unShuffled > 1; --unShuffled)
            {
                for (int i = 0; i <= 1; ++i)
                { 
                    int rndTile = rnd.Next(0, unShuffled);

                    Card temp = this.cards[rndTile];

                    this.cards[rndTile] = this.cards[unShuffled - 1];
                    this.cards[unShuffled - 1] = temp;

                }
            }
        }

        private void SetTilesLocationSize()
        {
            int fixedBoardWith = this.Width - 10;
            int fixedBoardHeight = this.Height - bottomSectionHeight;

            int optimalTileSize = Math.Min(fixedBoardWith / (columns + 1), fixedBoardHeight / (rows + 1)); ;
            int widthPadding = (fixedBoardWith - columns * optimalTileSize) / (columns + 1);
            int heightPadding = (fixedBoardHeight - rows * optimalTileSize) / (rows + 1);

            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < columns; ++j)
                {
        
                    Card card = this.cards[i * columns + j];
   
                    // size        
                    card.Width = optimalTileSize;                    
                    card.Height = optimalTileSize;
                    
                    // location
                    card.Location = new Point(widthPadding * (j + 1) + optimalTileSize * j, heightPadding * (i + 1) + optimalTileSize * i);
                        
                    cards[i * columns + j] = card;
                }
            }
        }

        private void Game_ResizeEnd(object sender, EventArgs e)
        {
            setObjectsLocation();

        }

        private void Game_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                setObjectsLocation();
            }
            else if (WindowState == FormWindowState.Normal && lastWindowState == FormWindowState.Maximized)
            {
                setObjectsLocation();
            }
            lastWindowState = WindowState;
        }

        private void timInit_Tick(object sender, EventArgs e)
        {
            foreach( Card c in cards)
            {
                c.Text = "";
                c.Enabled = true;
            }


            timInit.Enabled = false;
            isCardTurned = false;
        }

        private void Game_FormClosing(object sender, FormClosingEventArgs e)
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

        private void timShow_Tick(object sender, EventArgs e)
        {
            if(secondCard != null)
            {
                if(equalIDs(firstCard, secondCard))
                {
                    firstCard.Visible = false;
                    secondCard.Visible = false;
                    hiddenTiles -= 2;
                }

                secondCard.Enabled = true;
                secondCard.Text = "";

                secondCard = null;

            }

            if(firstCard != null)
            {
                firstCard.Enabled = true;
                firstCard.Text = "";

                firstCard = null;
            }

            timShow.Enabled = false;
            isCardTurned = false;
            if(hiddenTiles == 0)
            {
                GameFinish();
            }
        }

        private void GameFinish()
        {
            MessageBox.Show("Congratulation, you did it! :D");
        }

        private void Card_Click(object sender, EventArgs e)
        {
            if (!isPaused)
            {
                if (firstCard == null)
                {
                    firstCard = (Card)sender;

                    firstCard.Text = firstCard.ImageID.ToString();
                    firstCard.Enabled = false;

                    isCardTurned = true;
                    timShow.Enabled = true;
                }
                else if (firstCard != null && secondCard == null)
                {
                    timShow.Stop();

                    secondCard = (Card)sender;

                    secondCard.Text = secondCard.ImageID.ToString();
                    secondCard.Enabled = false;

                    timShow.Start();
                }
            }

        }

        private void Game_Shown(object sender, EventArgs e)
        {
            if (menu.settings.initShowTime != 0)
            {
                this.timInit.Interval = menu.settings.initShowTime * 1000;
                this.timInit.Enabled = true;
            }

            this.timShow.Interval = Convert.ToInt32(menu.settings.cardsShowTime * 1000);
        }

        private void boxPause_Click(object sender, EventArgs e)
        {
            if (!isCardTurned && !isPaused)
            {
                boxPause.Image = global::MemoryApp.Properties.Resources.startIcon;
                isPaused = true;
            }
            else if(isPaused)
            {
                boxPause.Image = global::MemoryApp.Properties.Resources.pauseIcon;
                isPaused = false;
            }
        }

        private void btnSett_Click(object sender, EventArgs e)
        {
            menu.settings.ShowDialog();

            setObjectsLocation();

        }

        private bool equalIDs(Card first, Card second)
        {
            if (first.ImageID == second.ImageID)
            {
                return true;
            }

            return false;
        }
    }
}
