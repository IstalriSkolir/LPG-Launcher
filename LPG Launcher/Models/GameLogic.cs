using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using LPG_Launcher.ViewModels;

namespace LPG_Launcher.Models
{
    public class GameLogic : Game
    {
        #region Fields

        private MainWindowViewModel mainWindow;
        private ICommand runGameCommand;
        private bool buttonEnabled;

        #endregion

        #region Get/Sets

        public ICommand RunGameCommand
        {
            get { return runGameCommand ?? (runGameCommand = new CommandHandler(() => runGame(), () => buttonEnabled)); }
        }

        public bool ButtonEnabled
        {
            get { return buttonEnabled; }
            set
            {
                if(buttonEnabled != value)
                {
                    buttonEnabled = value;
                }
            }
        }

        #endregion

        public GameLogic(Game game, MainWindowViewModel window)
        {
            Name = game.Name;
            Description = game.Description;
            Controls = game.Controls;
            ExePath = game.ExePath;
            Release = game.Release;
            ImageData = game.ImageData;
            URL = game.URL;
            mainWindow = window;
            buttonEnabled = true;
        }

        #region Private Functionality

        private void runGame()
        {
            mainWindow.GameData.ChangeGameButtonEnabled(false);
            var process = new Process();
            process.StartInfo.FileName = ExePath;
            process.EnableRaisingEvents = true;
            process.Exited += new EventHandler(gameExited);
            process.Start();
        }

        private void gameExited(object sender, EventArgs e)
        {
            mainWindow.GameData.ChangeGameButtonEnabled(true);
        }

        #endregion region
    }
}
