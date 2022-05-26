using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

	public class BuildAssistant
	{	
		public static void Main(string[]args)
		{
			Console.WriteLine("\nBuild Assistant: Loading...");
			List<string> commands = new List<string> { "CheckInstallers", "MoveGameData" };
			if(args == null || args.Length == 0)
			{
				Console.WriteLine("No arguements given, Build Assistant needs to be given one of the following arguements:");
				foreach(string command in commands)
					Console.WriteLine("- " + command);
				Console.WriteLine("Build Assistant: Closing...\n");
				return;
			}
			switch(args[0])
			{
				case "CheckInstallers":
					checkInstallers();
					break;
				case "MoveGameData":
					checkGameDataFiles();
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
				else if(fileCount > 1 && fileCount <= 5)
					Console.WriteLine("Build Assistant: " + fileCount + " Installers Present, no Installers will be removed");
				else if(fileCount == 6)
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
				Console.WriteLine("Build Assistant: Checking For GameData...");	
				int fileCount = Directory.GetFiles(gameConfigDir, "*.xml").Length;
				if(fileCount > 0)
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
				Console.WriteLine("Build Assistant: Moving Newest GameData File...");
				var configDir = new DirectoryInfo(gameConfigDir);
				var newestGameData = (from file in configDir.GetFiles() orderby file.CreationTime descending select file).First();
				string GameData = gameConfigDir + "\\" + newestGameData.Name;
				string launcherConfigDir = Directory.GetCurrentDirectory()+ "\\bin\\Release\\net5.0-windows\\GameData\\" + newestGameData.Name;
				if(!File.Exists(launcherConfigDir))
					File.Copy(GameData, launcherConfigDir, true);
				Console.WriteLine("Build Assistant: " + newestGameData.Name + " Copied to " + launcherConfigDir);
			}
			catch (Exception e)
			{
				Console.WriteLine("Build Assistant Error -> Couldn't move GameData: " + e);
			}
		}
		
		
		#endregion
	} 