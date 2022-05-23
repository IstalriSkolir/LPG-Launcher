using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LPG_Launcher.Models;

namespace LPG_Launcher.ViewModels
{
    class MainWindowViewModel : MainWindow
    {
        #region Fields

        private GameStorage gameData;

        #endregion

        #region Contructors/Destructors

        public MainWindowViewModel()
        {
            gameData = new GameStorage();
        }

        #endregion

        #region Private Functions

        public void onLoad(object sender, RoutedEventArgs e)
        {
            int test = 0;
        }

        #endregion
    }
}
