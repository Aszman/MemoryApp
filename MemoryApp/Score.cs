namespace MemoryApp
{
    public class Score
    {
        const int mistakeValue = 100;
        const int pairValue = 20;

        private string name;
        private int score;

        public Score(string _name, int initScore)
        {
            this.name = _name;
            this.score = initScore;
        }

        public int getScore()
        {
            return this.score;
        }

        public string getName()
        {
            return this.name;
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
