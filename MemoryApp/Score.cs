using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryApp
{
    class Score
    {
        const int mistakeValue = 100;
        const int pairValue = 20;

        private int score;
        private String name;

        public Score(String _name, int initScore)
        {
            this.name = _name;
            this.score = initScore;
        }

        public int getScore()
        {
            return this.score;
        }

        public void madeMistake()
        {
            this.score -= mistakeValue; 
        }

        public void madePair()
        {
            this.score += pairValue;
        }

        public void substractValue(int value)
        {
            this.score -= value;
        }


    }
}
