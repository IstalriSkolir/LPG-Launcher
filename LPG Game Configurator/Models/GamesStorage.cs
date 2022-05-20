using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPG_Game_Configurator.Models
{
    class GamesStorage
    {
        #region Fields

        private List<Game> games;

        #endregion

        #region Constructors/Destructors

        public GamesStorage()
        {
            games = new List<Game>();
        }

        #endregion
    }
}