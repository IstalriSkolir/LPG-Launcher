using Build_Assistant.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Build_Assistant.Singletons
{
    public sealed class MoveGames
    {
        private static MoveGames instance = null;

        private MoveGames() { }

        public static MoveGames Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new MoveGames();
                }
                return instance;
            }
        }

        public void Run()
        {
            try
            {
                clearOldFiles();
                List<Game> games = getGameData();
                if (games != null && games.Count > 0)
                {
                    moveGames(games);
                    games = setGameExePath(games);
                    serializeGameData(games);
                }
                else
                {
                    Console.WriteLine("Build Assistant Error -> Latest GameData file doesn't contain any games to move!");
                    return;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Build Assistant Error -> Couldn't move Games: " + e);
            }
        }

        private static void clearOldFiles()
        {
            try
            {
                Console.WriteLine("Build Assistant: Checking For Old Games...");
                DirectoryInfo dirs = new DirectoryInfo(Directory.GetCurrentDirectory() + "\\bin\\Release\\net5.0-windows\\Games");
                foreach (DirectoryInfo dir in dirs.GetDirectories())
                {
                    Console.WriteLine("Build Assistant: Deleting " + dir.Name + "...");
                    Directory.Delete(Directory.GetCurrentDirectory() + "\\bin\\Release\\net5.0-windows\\Games\\" + dir.Name, true);
                }
                Console.WriteLine("Build Assistant: Checking For Old GameData Files...");
                dirs = new DirectoryInfo(Directory.GetCurrentDirectory() + "\\bin\\Release\\net5.0-windows\\GameData");
                foreach(FileInfo file in dirs.GetFiles())
                {
                    Console.WriteLine("Build Assistant: Deleting " + file.Name + "...");
                    File.Delete(Directory.GetCurrentDirectory() + "\\bin\\Release\\net5.0-windows\\GameData\\" + file.Name);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Build Assistant Error -> Couldn't delete old games: " + e);
            }
        }

        private static List<Game> getGameData()
        {
            try
            {
                Console.WriteLine("Build Assistant: Getting New GameData...");
                DirectoryInfo gameDataDir = new DirectoryInfo(Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().Length - 12) + "LPG Game Configurator\\bin\\Debug\\net5.0-windows\\GameData");
                var gameDatafile = (from file in gameDataDir.GetFiles() orderby file.CreationTime descending select file).First();
                List<Game> games = new List<Game>();
                XmlSerializer serializer = new XmlSerializer(games.GetType());
                TextReader reader = new StreamReader(gameDataDir + "\\" + gameDatafile);
                games = (List<Game>)serializer.Deserialize(reader);
                reader.Close();
                return games;
            }
            catch (Exception e)
            {
                Console.WriteLine("Build Assistant Error -> Couldn't get Game Data: " + e);
                return null;
            }
        }

        private static void moveGames(List<Game> games)
        {
            try
            {
                Console.WriteLine("Build Assistant: Extracting Games...");
                foreach (Game game in games)
                {
                    Console.WriteLine("Build Assistant: Extracting " + game.FileZip + "...");
                    ZipFile.ExtractToDirectory(game.ExePath, Directory.GetCurrentDirectory() + "\\bin\\Release\\net5.0-windows\\Games\\" + game.FileZip);
                    Directory.Move(Directory.GetCurrentDirectory() + "\\bin\\Release\\net5.0-windows\\Games\\" + game.FileZip + "\\" + game.FileZip.Substring(0, game.FileZip.Length - 4) + "\\", Directory.GetCurrentDirectory() + "\\bin\\Release\\net5.0-windows\\Games\\" + game.FileZip.Substring(0, game.FileZip.Length - 4) + "\\");
                    Directory.Delete(Directory.GetCurrentDirectory() + "\\bin\\Release\\net5.0-windows\\Games\\" + game.FileZip);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Build Assistant Error -> Couldn't move game files: " + e);
            }
        }

        private static List<Game> setGameExePath(List<Game> games)
        {
            try
            {
                Console.WriteLine("Build Assistant: Setting Game Exe Paths...");
                foreach (Game game in games)
                {
                    Console.WriteLine("Build Assistant: Setting " + game.Name + ".exe path...");
                    string gameFolder = Directory.GetCurrentDirectory() + "\\bin\\Release\\net5.0-windows\\Games\\" + game.FileZip.Substring(0, game.FileZip.Length - 4) + "\\";
                    string[] files = Directory.GetFiles(gameFolder, "*.exe");
                    game.ExePath = game.FileZip.Substring(0, game.FileZip.Length - 4) + "\\" + files[0].Split(Path.DirectorySeparatorChar).Last();
                    game.FileZip = null;
                    game.ImageName = null;
                }
                return games;
            }
            catch (Exception e)
            {
                Console.WriteLine("Build Assistant Error -> Couldn't set game exe paths: " + e);
                return null;
            }
        }

        private static void serializeGameData(List<Game> games)
        {
            try
            {
                Console.WriteLine("Build Assistant: Serializing GameData...");
                DirectoryInfo gameDataDir = new DirectoryInfo(Directory.GetCurrentDirectory() + "\\bin\\Release\\net5.0-windows\\GameData");
                XmlSerializer serializer = new XmlSerializer(games.GetType());
                TextWriter writer = new StreamWriter(gameDataDir + "\\GameData.xml");
                serializer.Serialize(writer, games);
                writer.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Build Assistant Error -> Couldn't serialize GameData file: " + e);
            }
        }
    }
}
