using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPG_Launcher.Models
{
    class GameStorage
    {
        #region Fields

        private ObservableCollection<Game> games;

        #endregion

        #region Get/Sets

        public ObservableCollection<Game> Games
        {
            get { return games; }
            set
            {
                if (games != value)
                {
                    games = value;
                }
            }
        }

        #endregion

        #region Constructor/Destructor

        public GameStorage()
        {
            games = new XMLReader().GetGameData();
        }

        #endregion
    }
}
