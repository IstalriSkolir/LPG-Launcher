using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LPG_Launcher.Models
{
    public class GameLogic : Game
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

        public GameLogic(Game game)
        {
            Name = game.Name;
            Description = game.Description;
            Controls = game.Controls;
            ExePath = game.ExePath;
            Release = game.Release;
            ImageData = game.ImageData;
            URL = game.URL;
        }

        #region Private Functionality

        private void runGame()
        {
            ProcessStartInfo game = new ProcessStartInfo(ExePath);
            using (Process process = Process.Start(game))
            {
                process.WaitForExit();
            }
        }

        #endregion region
    }
}
