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

        #region Constructors/Destructors

        public GamesStorage()
        {
            games = new List<Game>();
            xmlParser = new XMLIO();
        }

        #endregion
    }
}