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
        private string description;
        private string controls;
        private string exePath;
        private string fileZip;
        private DateTime release;
        private byte[] imageData;
        private string imageName;
        private string url;

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

        public string FileZip
        {
            get { return fileZip; }
            set
            {
                if (fileZip != value)
                {
                    fileZip = value;
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

        public byte[] ImageData
        {
            get { return imageData; }
            set
            {
                if (imageData != value)
                {
                    imageData = value;
                }
            }
        }

        public string ImageName
        {
            get { return imageName; }
            set
            {
                if (imageName != value)
                {
                    imageName = value;
                }
            }
        }

        public string URL
        {
            get { return url; }
            set
            {
                if (url != value)
                {
                    url = value;
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