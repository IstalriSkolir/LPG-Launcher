using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Build_Assistant.Singletons
{
    public sealed class MakeDirectories
    {
        private static MakeDirectories instance = null;

        private MakeDirectories() { }

        public static MakeDirectories Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new MakeDirectories();
                }
                return instance;
            }
        }

        public void Run(string buildMode)
        {
            try
            {
                string gameDataPath;
                string gamesPath;
                Console.WriteLine("Build Assistant: Checking Directories...");
                if ("Debug".Equals(buildMode))
                {
                    gameDataPath = Directory.GetCurrentDirectory() + "\\bin\\Debug\\net5.0-windows\\GameData";
                    gamesPath = Directory.GetCurrentDirectory() + "\\bin\\Debug\\net5.0-windows\\Games";
                }
                else
                {
                    gameDataPath = Directory.GetCurrentDirectory() + "\\bin\\Release\\net5.0-windows\\GameData";
                    gamesPath = Directory.GetCurrentDirectory() + "\\bin\\Release\\net5.0-windows\\Games";
                }
                if (!Directory.Exists(gameDataPath))
                {
                    Console.WriteLine("Build Assistant: Creating GameData Folder...");
                    Directory.CreateDirectory(gameDataPath);
                }
                if (!Directory.Exists(gamesPath))
                {
                    Console.WriteLine("Build Assistant: Creating Games Folder...");
                    Directory.CreateDirectory(gamesPath);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Build Assistant Error -> Couldn't check directories: " + e);
            }
        }
    }
}
