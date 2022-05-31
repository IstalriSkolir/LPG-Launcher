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

        GamesStorage gameData = new GamesStorage();

        #endregion
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Game> games = new List<Game>();
            games.Add(new Game("Name 1", "Desc 1", DateTime.Now));
            games.Add(new Game("Name 2", "Desc 2", DateTime.Now));
            games.Add(new Game("Name 3", "Desc 3", DateTime.Now));
            XMLIO test = new XMLIO();
            test.SaveXMLFile(games);
        }
    }
}
