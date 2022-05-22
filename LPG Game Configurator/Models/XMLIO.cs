﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace LPG_Game_Configurator.Models
{
    class XMLIO
    {
        #region Fields

        string gameDataDir;

        #endregion

        #region Constructor/Destructor

        public XMLIO()
        {
            gameDataDir = Environment.CurrentDirectory + "\\GameData";
        }

        #endregion

        #region Public Functions

        public void SaveXMLFile(List<Game> games)
        {
            try
            {
                if (games.Count > 0)
                {
                    checkGameDataDirectoryExists();
                    string fileName = "//GameData-" + DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss").Replace("/", "").Replace(":", "").Replace(" ", "") + ".xml";
                    string path = gameDataDir + fileName;
                    XmlSerializer serializer = new XmlSerializer(games.GetType());
                    TextWriter writer = new StreamWriter(path);
                    serializer.Serialize(writer, games);
                    writer.Close();
                }
            }
            catch
            {
                MessageBox.Show("Error saving file!", "Write Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public List<Game> LoadXMLFile(string fileName)
        {
            List<Game> games = new List<Game>();
            try
            {
                string path = gameDataDir + "\\" + fileName;
                XmlSerializer serializer = new XmlSerializer(games.GetType());
                TextReader reader = new StreamReader(path);
                games = (List<Game>)serializer.Deserialize(reader);
                reader.Close();
            }
            catch
            {
                MessageBox.Show("Error loading file!", "Read Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            return games;
        }

        #endregion

        #region Private Functions

        private void checkGameDataDirectoryExists()
        {
            if (!Directory.Exists(gameDataDir))
            {
                Directory.CreateDirectory(gameDataDir);
            }
        }

        #endregion
    }
}