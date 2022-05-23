using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPG_Launcher.Models
{
    class GameStorage
    {
        #region Fields

        private List<Game> games;

        #endregion

        #region Constructor/Destructor

        public GameStorage()
        {
            games = new XMLReader().GetGameData();
        }

        #endregion
    }
}
