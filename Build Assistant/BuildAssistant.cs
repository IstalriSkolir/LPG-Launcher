using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.IO.Compression;
using Build_Assistant.Models;

namespace Build_Assistant
{
    public class BuildAssistant
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\nBuild Assistant: Loading...");
            List<string> commands = new List<string> { "CheckInstallers", "MoveGameData", "MakeDirDebug", "MakeDirRelease", "MoveGames" };
            if (args == null || args.Length == 0)
            {
                Console.WriteLine("No arguements given, Build Assistant needs to be given one of the following arguements:");
                foreach (string command in commands)
                    Console.WriteLine("- " + command);
                Console.WriteLine("Build Assistant: Closing...\n");
                return;
            }
            switch (args[0])
            {
                case "CheckInstallers":
                    checkInstallers();
                    break;
                case "MoveGameData":
                    checkGameDataFiles();
                    break;
                case "MakeDirDebug":
                    makeDirectories("Debug");
                    break;
                case "MakeDirRelease":
                    makeDirectories("Release");
                    break;
                case "MoveGames":
                    moveGameFiles();
                    break;
                default:
                    Console.WriteLine("Build Assistant Error -> Invalid Arguement '" + args[0] + "'");
                    break;
            }
            Console.WriteLine("Build Assistant: Closing...\n");
        }

        #region Check Installers

        private static void checkInstallers()
        {
            try
            {
                string appDir = Directory.GetCurrentDirectory() + "\\Output";
                Console.WriteLine("Build Assistant: Checking Installer Count...");
                int fileCount = Directory.GetFiles(appDir, "*.exe").Length;
                if (fileCount == 1)
                    Console.WriteLine("Build Assistant: " + fileCount + " Installer Present, no Installers will be removed");
                else if (fileCount > 1 && fileCount <= 5)
                    Console.WriteLine("Build Assistant: " + fileCount + " Installers Present, no Installers will be removed");
                else if (fileCount == 6)
                {
                    Console.WriteLine("Build Assistant: " + fileCount + " Installers Present, 1 Installer will be removed");
                    removeInstallers(appDir);
                }
                else
                {
                    Console.WriteLine("Build Assistant: " + fileCount + " Installers Present, " + (fileCount - 5) + " Installers will be removed");
                    removeInstallers(appDir);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Build Assistant Error -> Couldn't check installer count: " + e);
            }
        }

        private static void removeInstallers(string appDir)
        {
            foreach (var fi in new DirectoryInfo(appDir).GetFiles().OrderByDescending(x => x.CreationTime).Skip(5))
            {
                Console.WriteLine("Build Assistant: Deleting " + fi.Name + "...");
                fi.Delete();
            }
            Console.WriteLine("Build Assistant: Older Installers Deleted, 5 Installers Remain");
        }

        #endregion

        #region Move/Generate GameData

        private static void checkGameDataFiles()
        {
            try
            {
                string gameConfigDir = Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().Length - 12) + "LPG Game Configurator\\bin\\Debug\\net5.0-windows\\GameData";
                Console.WriteLine("Build Assistant: Checking For New GameData...");
                int fileCount = Directory.GetFiles(gameConfigDir, "*.xml").Length;
                if (fileCount > 0)
                    moveGameData(gameConfigDir);
                else
                    Console.WriteLine("Build Assistant Error -> Couldn't find any GameData files!\nChecked Directory: " + gameConfigDir);
            }
            catch (Exception e)
            {
                Console.WriteLine("Build Assistant Error -> Couldn't check for GameData: " + e);
            }
        }

        private static void moveGameData(string gameConfigDir)
        {
            try
            {
                Console.WriteLine("Build Assistant: Checking For Old GameData...");
                DirectoryInfo dir = new DirectoryInfo(Directory.GetCurrentDirectory() + "\\bin\\Release\\net5.0-windows\\GameData");
                foreach (FileInfo file in dir.GetFiles())
                {
                    Console.WriteLine("Build Assistant: Deleting " + file.Name + "...");
                    file.Delete();
                }
                var configDir = new DirectoryInfo(gameConfigDir);
                var newestGameData = (from file in configDir.GetFiles() orderby file.CreationTime descending select file).First();
                string GameData = gameConfigDir + "\\" + newestGameData.Name;
                string launcherConfigDir = Directory.GetCurrentDirectory() + "\\bin\\Release\\net5.0-windows\\GameData\\" + newestGameData.Name;
                Console.WriteLine("Build Assistant: Moving Newest GameData File...");
                File.Copy(GameData, launcherConfigDir, true);
                Console.WriteLine("Build Assistant: " + newestGameData.Name + " Copied to " + launcherConfigDir);
            }
            catch (Exception e)
            {
                Console.WriteLine("Build Assistant Error -> Couldn't move GameData: " + e);
            }
        }


        #endregion

        #region Make Directories

        private static void makeDirectories(string buildMode)
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

        #endregion

        #region Move Games

        private static void moveGameFiles()
        {
            try
            {
                clearOldGames();
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

        private static void clearOldGames()
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
                Console.WriteLine("Build Assistant: Getting GameData...");
                DirectoryInfo gameDataDir = new DirectoryInfo(Directory.GetCurrentDirectory() + "\\bin\\Release\\net5.0-windows\\GameData");
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
                var gameDatafile = (from file in gameDataDir.GetFiles() orderby file.CreationTime descending select file).First();
                XmlSerializer serializer = new XmlSerializer(games.GetType());
                TextWriter writer = new StreamWriter(gameDataDir + "\\" + gameDatafile);
                serializer.Serialize(writer, games);
                writer.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Build Assistant Error -> Couldn't serialize GameData file: " + e);
            }
        }

        #endregion
    }
}
