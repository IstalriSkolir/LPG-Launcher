using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.IO.Compression;
using Build_Assistant.Models;
using Build_Assistant.Singletons;

namespace Build_Assistant
{
    public class BuildAssistant
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\nBuild Assistant: Loading...");
            List<string> commands = new List<string> { "CheckInstallers", "MakeDirDebug", "MakeDirRelease", "MoveGames" };
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
                    CheckInstallers.Instance.Run();
                    break;
                case "MakeDirDebug":
                    MakeDirectories.Instance.Run("Debug");
                    break;
                case "MakeDirRelease":
                    MakeDirectories.Instance.Run("Release");
                    break;
                case "MoveGames":
                    MoveGames.Instance.Run();
                    break;
                default:
                    Console.WriteLine("Build Assistant Error -> Invalid Arguement '" + args[0] + "'");
                    break;
            }
            Console.WriteLine("Build Assistant: Closing...\n");
        }
    }
}
