using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LPG_Game_Configurator.Models;

namespace LPG_Game_Configurator
{
    public partial class Form1 : Form
    {
        #region Fields

        private GamesStorage gameData;

        #endregion
        public Form1()
        {
            InitializeComponent();
            gameData = new GamesStorage();
        }

        #region Add/Remove Games

        private void AddGameButton_Click(object sender, EventArgs e)
        {
            gameData.AddNewGame();
            updateGamesBoxList();
        }

        private void RemoveGameButton_Click(object sender, EventArgs e)
        {
            if(GamesBox.SelectedItem != null)
            {
                if(MessageBox.Show("Are you show you want to delete the game '" + GamesBox.SelectedItem + "'?", "Confirm Deletion", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    gameData.RemoveGame(GamesBox.SelectedItem.ToString());
                    updateGamesBoxList();
                }
            }
            else
            {
                MessageBox.Show("No Game Selected!", "Error Removing Game", MessageBoxButtons.OK);
            }
        }

        private void updateGamesBoxList()
        {
            GamesBox.Items.Clear();
            foreach (Game game in gameData.Games)
                GamesBox.Items.Add(game.Name);
        }

        #endregion

        #region Load/Save

        private void LoadFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = Environment.CurrentDirectory;
            fileDialog.Title = "Load GameData File";
            fileDialog.DefaultExt = "xml";
            fileDialog.Multiselect = false;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                GamesBox.Items.Clear();
                gameData.LoadFile(fileDialog.FileName);
                foreach (Game game in gameData.Games)
                    GamesBox.Items.Add(game.Name);
            }
        }

        private void SaveFileButton_Click(object sender, EventArgs e)
        {
            gameData.SaveFile();
            MessageBox.Show("File Saved", "Save Complete", MessageBoxButtons.OK);
        }

        #endregion

    }
}
