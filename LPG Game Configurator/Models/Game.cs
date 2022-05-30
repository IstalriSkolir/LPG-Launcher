using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPG_Game_Configurator.Models
{
    public class Game
    {
        #region Fields

        private string name;
        private string description;
        private string controls;
        private string exePath;
        private DateTime release;

        #endregion

        #region Get/Set Functions

        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                }
            }
        }

        public string Description
        {
            get { return description; }
            set
            {
                if (description != value)
                {
                    description = value;
                }
            }
        }

        public string Controls
        {
            get { return controls; }
            set
            {
                if (controls != value)
                {
                    controls = value;
                }
            }
        }

        public string ExePath
        {
            get { return exePath; }
            set
            {
                if (exePath != value)
                {
                    exePath = value;
                }
            }
        }

        public DateTime Release
        {
            get { return release; }
            set
            {
                if (release != value)
                {
                    release = value;
                }
            }
        }

        #endregion

        #region Constructors/Destructors

        public Game()
        {

        }

        public Game(string setName, string setDescription, DateTime setRelease)
        {
            name = setName;
            description = setDescription;
            release = setRelease;
        }

        #endregion
    }
}