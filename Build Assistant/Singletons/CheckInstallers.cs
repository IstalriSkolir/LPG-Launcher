using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Build_Assistant.Singletons
{
    public sealed class CheckInstallers
    {
        private static CheckInstallers instance = null;

        private CheckInstallers() { }

        public static CheckInstallers Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new CheckInstallers();
                }
                return instance;
            }
        }

        public void Run()
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

    }
}
