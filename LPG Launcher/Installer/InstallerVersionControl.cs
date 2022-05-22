using System;
using System.IO;
using System.Linq;

	public class InstallerCountChecker
	{

		public static void Main(string[]args)
		{
			try{				
				string appDir;
				if(args == null || args.Length == 0)
					appDir = Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().Length - 9) + "Output";
				else
					if(args[0] == "BuildTime")
						appDir = Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().Length - 12) + "LPG Launcher\\Output";
					else
					{
						Console.WriteLine("'" + args[0] + "' not recognised as valid arguement\nInstallerVersionControl.exe Failure!");
						return;
					}
				Console.WriteLine("Checking Installer Count...");	
				int fileCount = Directory.GetFiles(appDir, "*.exe").Length;
				if (fileCount == 1)
					Console.WriteLine(fileCount + " Installer Present, no Installers will be removed");
				else if(fileCount > 1 && fileCount <= 5)
					Console.WriteLine(fileCount + " Installers Present, no Installers will be removed");
				else if(fileCount == 6)
				{
					int removeCount = fileCount - 5;
					Console.WriteLine(fileCount + " Installers Present, " + removeCount + " Installer will be removed");
					removeInstallers(removeCount, appDir);
				}				
				else
				{
					int removeCount = fileCount - 5;
					Console.WriteLine(fileCount + " Installers Present, " + removeCount + " Installers will be removed");
					removeInstallers(removeCount, appDir);
				}
			} catch {
				Console.WriteLine("Error Checking Output folder\nInstallerVersionControl.exe Failure!");
			}
		}
		
		private static void removeInstallers(int removeCount, string appDir){	
			foreach (var fi in new DirectoryInfo(appDir).GetFiles().OrderByDescending(x => x.CreationTime).Skip(5))
			{
				Console.WriteLine("Deleting " + fi.Name + "...");
				fi.Delete();
			}
			Console.WriteLine("Older Installers Deleted, 5 Installers Remain");
		}
	} 