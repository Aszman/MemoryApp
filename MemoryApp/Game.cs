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
        MainMenu menu;

        Button[] tiles;
        int hiddenTiles;
        int rows, columns;

        public Game(MainMenu owner)
        {
            menu = owner;
            InitializeComponent();
            this.Width = menu.settings.boardWidth;
            this.Height = menu.settings.boardHeight;

            InitializeTiles();
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
                    hiddenTiles = 108;
                    rows = 9;
                    columns = 12;
                    break;
            }
            this.tiles = new Button[hiddenTiles];

            
            int optimalTileSize = Math.Min(this.Width / columns, this.Height / rows); ;
            int widthPadding = (this.Width - columns * optimalTileSize) / (columns + 1); 
            int heightPadding = (this.Height - rows * optimalTileSize) / (rows + 1); 

            for(int i = 0; i < rows; ++i)
            {
                for(int j = 0; j < columns; ++j)
                { 
                    // text
                    Button newButton = new Button();
                    newButton.Text = (i * columns + j).ToString();

                    // size
                    newButton.Width = optimalTileSize;
                    newButton.Height = optimalTileSize;

                    //location
                    newButton.Location = new Point(widthPadding*(j+1) + optimalTileSize * j, heightPadding * (i + 1) + optimalTileSize * i);

                    tiles[i * columns + j] = newButton;
                    this.Controls.Add(tiles[i * columns + j]);
                }

            }
        }

        private void Game_FormClosing(object sender, FormClosingEventArgs e)
        {
            menu.Show();
        }
    }
}
