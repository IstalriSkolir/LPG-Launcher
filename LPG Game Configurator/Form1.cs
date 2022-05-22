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

        }
    }
}
