﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryApp
{
    class Card : Button
    {
        public int ImageID;
        public Card()
        {
            this.Font = new Font(this.Font.Name, 12F);
            this.TabStop = false;
        }
    }


}
