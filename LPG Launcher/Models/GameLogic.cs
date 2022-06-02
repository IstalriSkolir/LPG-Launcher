using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LPG_Launcher.Models
{
    public class GameLogic
    {
        #region Fields

        private ICommand runGameCommand;

        #endregion

        #region Get/Sets

        public ICommand RunGameCommand
        {
            get { return runGameCommand ?? (runGameCommand = new CommandHandler(() => runGame(), () => true)); }
        }

        #endregion

        #region Private Functionality

        private void runGame()
        {
            //string test = exePath;

        }

        #endregion region
    }
}
