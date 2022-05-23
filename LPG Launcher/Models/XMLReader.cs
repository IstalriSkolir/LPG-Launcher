using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPG_Launcher.Models
{
    class XMLReader
    {
        #region Fields

        private string gameDataDir;

        #endregion

        #region Constructor/Destructor

        public XMLReader()
        {
            gameDataDir = Environment.CurrentDirectory + "\\GameData";
        }

        #endregion

        #region Public Functions

        public List<Game> GetGameData()
        {
            List<Game> games = new List<Game>();
            return games;
        }

        #endregion
    }
}
