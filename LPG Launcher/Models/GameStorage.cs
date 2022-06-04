using LPG_Launcher.ViewModels;
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
    public class GameStorage
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

        public GameStorage(MainWindowViewModel mainWindow)
        {
            games = new XMLReader().GetGameData(mainWindow);
            initialiseGameData();
        }

        #endregion

        #region Public functions

        public void ChangeGameButtonEnabled(bool enabled)
        {
            foreach (GameLogic game in games)
                game.ButtonEnabled = enabled;
        }

        #endregion

        #region Private Functions

        private void initialiseGameData()
        {
            foreach(Game game in games)
            {
                game.ExePath = Directory.GetCurrentDirectory() + "\\Games\\" + game.ExePath;
                game.Controls = "Controls: " + game.Controls;
                game.URL = "URL: " + game.URL;
            }
        }

        #endregion

    }
}
