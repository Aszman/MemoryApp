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
    public partial class Card : PictureBox
    {
        private int cardID;
        private Image frontImage;

        public int ID
        {
            get
            {
                return cardID;
            }

            set
            {
                cardID = value;
            }
        }

        public Image Front
        {
            get
            {
                return frontImage;
            }

            set
            {
                frontImage = value;
            }
        }

        public Card(int id)
        {
            this.ID = id;
            
            InitializeComponent();
        }

        public Card()
        {
            this.ID = 0;
            InitializeComponent();
        }
    }
}
