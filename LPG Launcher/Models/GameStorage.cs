using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPG_Launcher.Models
{
    class GameStorage
    {
        #region Fields

        private ObservableCollection<GameLogic> games;

        #endregion

        #region Get/Sets

        public ObservableCollection<GameLogic> Games
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
            initialiseGameData();
        }

        #endregion

        #region Private Functions

        private void initialiseGameData()
        {
            foreach(Game game in games)
            {
                game.ExePath = Directory.GetCurrentDirectory() + "\\Games\\" + game.ExePath;
            }
        }

        #endregion

    }
}
