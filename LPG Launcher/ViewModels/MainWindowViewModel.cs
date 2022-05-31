using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LPG_Launcher.Models;

namespace LPG_Launcher.ViewModels
{
    class MainWindowViewModel
    {
        #region Fields

        private GameStorage gameData;

        #endregion

        #region Get/Sets

        public GameStorage GameData
        {
            get { return gameData; }
        }

        #endregion

        #region Contructors/Destructors

        public MainWindowViewModel()
        {
            gameData = new GameStorage();
        }

        #endregion

    }
}
