using System;
using System.Collections.Generic;
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

        public List<Game> GetGameData()
        {
            List<Game> games = new List<Game>();
            try
            {
                var gameDir = new DirectoryInfo(gameDataDir);
                var newestGameData = (from file in gameDir.GetFiles() orderby file.CreationTime descending select file).First();
                string path = gameDataDir + "\\" + newestGameData.Name;
                XmlSerializer serializer = new XmlSerializer(games.GetType());
                TextReader reader = new StreamReader(path);
                games = (List<Game>)serializer.Deserialize(reader);
                reader.Close();
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
