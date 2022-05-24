using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPG_Launcher.Models
{
    public class Game
    {
        #region Fields

        private string name;
        private string tagLine;
        private string description;
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

        public string TagLine
        {
            get { return tagLine; }
            set
            {
                if (tagLine != value)
                {
                    tagLine = value;
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

        public Game(string setName, string setTagLine, string setDescription, DateTime setRelease)
        {
            name = setName;
            tagLine = setTagLine;
            description = setDescription;
            release = setRelease;
        }

        #endregion
    }
}