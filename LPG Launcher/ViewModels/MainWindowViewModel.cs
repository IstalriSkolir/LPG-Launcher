using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using LPG_Launcher.Models;

namespace LPG_Launcher.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region Fields

        public event PropertyChangedEventHandler PropertyChanged;
        private GameStorage gameData;
        private ICommand showLibraryCommand;
        private ICommand showAboutCommand;
        private bool showLibrary;
        private bool showAbout;

        #endregion

        #region Get/Sets

        public GameStorage GameData
        {
            get { return gameData; }
        }

        public ICommand ShowLibraryCommand
        {
            get { return showLibraryCommand ?? (showLibraryCommand = new CommandHandler(() => showPanel("Library"), () => true)); }
        }

        public ICommand ShowAboutCommand
        {
            get { return showAboutCommand ?? (showAboutCommand = new CommandHandler(() => showPanel("About"), () => true)); }
        }

        public bool ShowLibrary
        {
            get { return showLibrary; }
            set
            {
                if(showLibrary != value)
                {
                    showLibrary = value;
                    onPropertyChange("showLibrary");
                }
            }
        }

        public bool ShowAbout
        {
            get { return showAbout; }
            set
            {
                if (showAbout != value)
                {
                    showAbout = value;
                    onPropertyChange("showAbout");
                }
            }
        }

        #endregion

        #region Contructors/Destructors

        public MainWindowViewModel()
        {
            gameData = new GameStorage(this);
            ToolTipService.ShowDurationProperty.OverrideMetadata(typeof(DependencyObject), new FrameworkPropertyMetadata(Int32.MaxValue));
            showPanel("Library");
        }

        #endregion

        #region Private Functionality

        private void onPropertyChange(string pPropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(pPropertyName));
            }
        }

        private void showPanel(string panel)
        {
            hideAllPanels();
            switch (panel)
            {
                case "Library":
                    ShowLibrary = true;
                    break;
                case "About":
                    ShowAbout = true;
                    break;
                default:
                    MessageBox.Show("Error Showing " + panel, "Panel Error", MessageBoxButton.OK);
                    break;
            }
        }

        private void hideAllPanels()
        {
            ShowLibrary = false;
            ShowAbout = false;
        }

        #endregion
    }
}
