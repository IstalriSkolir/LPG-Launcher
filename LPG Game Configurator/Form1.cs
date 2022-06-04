using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        private bool firstGameSelected;

        #endregion
        public Form1()
        {
            InitializeComponent();
            gameData = new GamesStorage();
            firstGameSelected = false;
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
            fileDialog.InitialDirectory = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString()).ToString() + "\\GameData";
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

        #region Change Game Data

        private void GamesBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(GamesBox.SelectedItem != null)
            {
                Game game = gameData.GetGame(GamesBox.SelectedItem.ToString());
                if (game != null)
                    updateGameInfoBoxes(game);
                else
                    MessageBox.Show("Error finding the selected game!", "Internal Error", MessageBoxButtons.OK);
                updateGamesBoxList();
                if(!firstGameSelected)
                    EnableControls();
            }
        }

        private void GameNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                bool check = gameData.UpdateSelectedGame("Name", GameNameTextBox.Text);
                if (!check)
                {
                    GameLabel.Text = GameNameTextBox.Text;
                }
                else
                {
                    MessageBox.Show("A game with the name '" + GameNameTextBox.Text + "' already exists!", "Error Changing Game Name", MessageBoxButtons.OK);
                    GameNameTextBox.Text = "";
                }
            }
        }

        private void GameDatePicker_ValueChanged(object sender, EventArgs e)
        {
            gameData.UpdateSelectedGame("Date", date: GameDatePicker.Value);
        }

        private void GameControlsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            gameData.UpdateSelectedGame("Controls", GameControlsComboBox.Text);
        }

        private void GameURLTextBox_TextChanged(object sender, EventArgs e)
        {
            gameData.UpdateSelectedGame("URL", GameURLTextBox.Text);
        }

        private void GamePathButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = Environment.CurrentDirectory;
            fileDialog.Title = "Select Game .zip";
            fileDialog.DefaultExt = "zip";
            fileDialog.Multiselect = false;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                gameData.UpdateSelectedGame("Path",fileDialog.FileName ,fileDialog.SafeFileName);
                GamePathTextBox.Text = fileDialog.SafeFileName;
            }
        }

        private void GameImageButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = Environment.CurrentDirectory;
            fileDialog.Title = "Select Game Image";
            fileDialog.Multiselect = false;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string ext = Path.GetExtension(fileDialog.FileName).ToLower();
                if(".jpg".Equals(ext) || ".png".Equals(ext))
                {
                    byte[] imageData = File.ReadAllBytes(fileDialog.FileName);
                    gameData.UpdateSelectedGame("Image", fileDialog.SafeFileName, imageData: imageData);
                    GameImageTextBox.Text = fileDialog.SafeFileName;
                }
            }
        }

        private void GameDescTextBox_TextChanged(object sender, EventArgs e)
        {
            gameData.UpdateSelectedGame("Desc", GameDescTextBox.Text);
        }

        private void updateGameInfoBoxes(Game game)
        {
            GameLabel.Text = game.Name;
            GameNameTextBox.Text = game.Name;
            GameDatePicker.Value = game.Release;
            GameControlsComboBox.Text = game.Controls;
            GamePathTextBox.Text = game.FileZip;
            GameImageTextBox.Text = game.ImageName;
            GameURLTextBox.Text = game.URL;
            GameDescTextBox.Text = game.Description;
        }

        private void EnableControls()
        {
            firstGameSelected = true;
            GameNameTextBox.Enabled = true;
            GameDatePicker.Enabled = true;
            GameControlsComboBox.Enabled = true;
            GamePathTextBox.Enabled = true;
            GamePathButton.Enabled = true;
            GameImageTextBox.Enabled = true;
            GameImageButton.Enabled = true;
            GameURLTextBox.Enabled = true;
            GameDescTextBox.Enabled = true;
        }

        #endregion
    }
}
