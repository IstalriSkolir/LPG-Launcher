using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace LPG_Launcher.Models
{
    class XMLReader
    {
        #region Fields

        private string gameDataDir;

        #endregion

        #region Constructor/Destructor

        public XMLReader()
        {
            gameDataDir = Environment.CurrentDirectory + "\\GameData";
        }

        #endregion

        #region Public Functions

        public ObservableCollection<GameLogic> GetGameData()
        {
            ObservableCollection<GameLogic> games = new ObservableCollection<GameLogic>();
            try
            {
                var gameDir = new DirectoryInfo(gameDataDir);
                var newestGameData = (from file in gameDir.GetFiles() orderby file.CreationTime descending select file).First();
                string path = gameDataDir + "\\" + newestGameData.Name;
                List<Game> tempGames = new List<Game>();
                XmlSerializer serializer = new XmlSerializer(tempGames.GetType());
                TextReader reader = new StreamReader(path);
                tempGames = (List<Game>)serializer.Deserialize(reader);
                reader.Close();
                foreach (Game game in tempGames)
                    games.Add(new GameLogic(game)); ;               
            }
            catch
            {
                MessageBox.Show("Error loading file!", "Read Error", MessageBoxButton.OK);
                return null;
            }
            return games;
        }

        #endregion
    }
}
