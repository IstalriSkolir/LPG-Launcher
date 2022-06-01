using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LPG_Game_Configurator.Models
{
    [XmlRoot("GameData")]
    class GamesStorage
    {
        #region Fields

        [XmlArray("GameList")]

        [XmlArrayItem("Game")]
        private List<Game> games;
        private XMLIO xmlParser;
        private int selectedGame;

        #endregion

        #region Get/Set Functions

        public List<Game> Games
        {
            get { return games; }
        }

        public int SelectedGame
        {
            get { return selectedGame; }
            set
            {
                if(selectedGame != value)
                {
                    selectedGame = value;
                }
            }
        }

        #endregion

        #region Constructors/Destructors

        public GamesStorage()
        {
            games = new List<Game>();
            xmlParser = new XMLIO();
        }

        #endregion

        #region Public Functions

        public void LoadFile(string path)
        {
            games = xmlParser.LoadXMLFile(path);
        }

        public void SaveFile()
        {
            xmlParser.SaveXMLFile(games);
        }

        public void AddNewGame()
        {
            games.Add(new Game("Name " + (games.Count + 1), "Desc " + (games.Count + 1), DateTime.Now));
        }

        public void RemoveGame(string name)
        {
            for(int i = 0; i < games.Count; i++)
            {
                if (name.Equals(games[i].Name))
                {
                    games.RemoveAt(i);
                    break;
                }
            }
        }

        public Game GetGame(string name)
        {
            for(int i = 0; i < games.Count; i++)
            {
                if (name.Equals(games[i].Name))
                {
                    selectedGame = i;
                    return games[i];
                }
            }
            return null;
        }

        public bool UpdateSelectedGame(string prop, string val = "", DateTime date = new DateTime(), byte[] imageData = null)
        {
            switch (prop)
            {
                case "Name":
                    foreach (Game game in games)
                        if (val.Equals(game.Name))
                            return true;
                    games[selectedGame].Name = val;
                    return false;
                case "Date":
                    games[selectedGame].Release = date;
                    break;
                case "Controls":
                    games[selectedGame].Controls = val;
                    break;
                case "Path":
                    games[selectedGame].ExePath = val;
                    break;
                case "Image":
                    games[selectedGame].ImageData = imageData;
                    games[selectedGame].ImageName = val;
                    break;
                case "URL":
                    games[selectedGame].URL = val;
                    break;
                case "Desc":
                    games[selectedGame].Description = val;
                    break;
                default:
                    break;
            }
            return false;
        }

        #endregion
    }
}