namespace MemoryApp
{
    class ManSettings
    {
        static ManSettings instance = null;
 
        public int initCardsShowTime = 15;  // in seconds, normally 15 now for dev is set 5;
        public double cardsFaceUpShowTime = 1.5;  // in seconds

        public int boardWidth = 1080;
        public const int boardWidthMax = 1600;
        public const int boardWidthMin = 800;

        public int boardHeight = 720;
        public const int boardHeightMax = 900;
        public const int boardHeightMin = 600;


        private ManSettings()
        {

        }

        public static ManSettings getInstance()
        {
            if (instance == null)
            {
                instance = new ManSettings();
            }

            return instance;
        }
    }
}
