using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryApp
{
    class SettingsManager
    {
        static SettingsManager instance = null;
 
        public int initCardsShowTime = 15;  // in seconds, normally 15 now for dev is set 5;
        public double cardsFaceUpShowTime = 1.5;  // in seconds

        public int boardWidth = 1080;
        public const int boardWidthMax = 1600;
        public const int boardWidthMin = 800;

        public int boardHeight = 720;
        public const int boardHeightMax = 900;
        public const int boardHeightMin = 600;


        private SettingsManager()
        {

        }

        public static SettingsManager getInstance()
        {
            if (instance == null)
            {
                instance = new SettingsManager();
            }

            return instance;
        }
    }
}
