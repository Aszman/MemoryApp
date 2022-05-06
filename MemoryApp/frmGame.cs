using System;
using System.Drawing;
using System.Windows.Forms;

namespace MemoryApp
{
    public partial class frmGame : Form
    {

        private readonly frmMainMenu menu; // to get back to main menu form game's window

        private ManGame game;

        public frmGame(frmMainMenu owner)
        {
            menu = owner;

            InitializeComponent();

            game = new ManGame(this, menu.chosenDifficulty, menu.playerName);
        }


        //sets location of form's context and cards size
        public void SetObjectsLocation(int bottomSectionHeight)
        {
            this.lblLine.Location = new Point(0, Height - bottomSectionHeight);
            this.btnSett.Location = new Point(10, Height - bottomSectionHeight + 25);
            this.lblScore.Location = new Point(Width - 200, Height - bottomSectionHeight + 20);
            this.boxPause.Location = new Point((Width - boxPause.Width) / 2, Height - bottomSectionHeight + 20);
        }

        public void Pause()
        {
            this.timScore.Enabled = false;
            boxPause.Image = Properties.Resources.play_button;
        }

        public void Unpause()
        {
            this.timScore.Enabled = true;
            boxPause.Image = Properties.Resources.pauseIcon;
        }

        public void UpdateScore(Score score)
        {
            lblScore.Text = "Score: " + score.getScore().ToString();
        }



        // runs when form is first time displayed
        private void Game_Shown(object sender, EventArgs e)
        {
            int initTime = game.getInitShowTime();
            if (initTime != 0) // starts timer if value is positive
            {
                this.timInit.Interval = initTime * 1000;
                this.timInit.Enabled = true;
            }

            this.timBad.Interval = Convert.ToInt32(game.getFaceUpShowTime() * 1000);
            this.timScore.Enabled = true;
        }

        private void Game_ResizeEnd(object sender, EventArgs e)
        {
            game.windowResize();
        }

        private void Game_FormClosing(object sender, FormClosingEventArgs e)
        {
            game.windowClose(menu, e);
        }

        private void Card_Click(object sender, EventArgs e)
        {
            game.cardClick((Card)sender);
        }

        private void timInit_Tick(object sender, EventArgs e)
        {
            game.disableCards();

            timInit.Enabled = false;
            btnSett.Enabled = true;
        }

        // pair was wrong
        private void timGood_Tick(object sender, EventArgs e)
        {
            game.GoodTimerTick();
        }

        // pair was correct
        private void timBad_Tick(object sender, EventArgs e)
        {
            game.BadTimerTick();

        }

        private void boxPause_Click(object sender, EventArgs e)
        {
            game.PauseClicked();
        }

        private void timScore_Tick(object sender, EventArgs e)
        {
            game.ScoreTimerTick();
        }

        private void btnSett_Click(object sender, EventArgs e)
        {
            game.SettingsClicked();

            timInit.Interval = game.getInitShowTime() * 1000;
            timBad.Interval = Convert.ToInt32(game.getFaceUpShowTime() * 1000);

        }

        public void btnSettEnable(bool enable)
        {
            btnSett.Enabled = enable;
        }

        public void addCard(Card newCard)
        {
            newCard.Click += new EventHandler(this.Card_Click);
            this.Controls.Add(newCard);
        }

        public void StopScoreTimer()
        {
            timScore.Stop();
        }

        public void StopGoodTimer()
        {
            timGood.Stop();
        }

        public void StopBadTimer()
        {
            timBad.Stop();
        }

        public void StartScoreTimer()
        {
            timScore.Start();
        }

        public void StartGoodTimer()
        {
            timGood.Start();
        }

        public void StartBadTimer()
        {
            timBad.Start();
        }
    }
}
