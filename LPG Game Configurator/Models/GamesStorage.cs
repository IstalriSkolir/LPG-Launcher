using System;
using System.Collections.Generic;
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

        #endregion

        #region Get/Set Functions

        public List<Game> Games
        {
            get { return games; }
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
            //foreach (Game game in games)
            //    if (name.Equals(game.Name))
            //        games.Remove(game);
        }

        #endregion
    }
}