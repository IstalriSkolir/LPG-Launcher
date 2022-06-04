using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Build_Assistant.Singletons
{
    public sealed class CleanDirectories
    {
        private static CleanDirectories instance = null;

        private CleanDirectories() { }

        public static CleanDirectories Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new CleanDirectories();
                }
                return instance;
            }
        }
        public void Run(string buildMode)
        {
            try
            {
                string path;
                Console.WriteLine("Build Assistant: Cleaning " + buildMode + " Directory...");
                if ("Debug".Equals(buildMode))
                    path = Directory.GetCurrentDirectory() + "\\bin\\Debug";
                else
                    path = Directory.GetCurrentDirectory() + "\\bin\\Release";
                DirectoryInfo dirs = new DirectoryInfo(path);
                foreach (DirectoryInfo dir in dirs.GetDirectories())
                {
                    Console.WriteLine("Build Assistant: Deleting " + dir.Name + "...");
                    Directory.Delete(dir.FullName, true);
                }
                foreach (FileInfo file in dirs.GetFiles())
                {
                    Console.WriteLine("Build Assistant: Deleting " + file.Name + "...");
                    file.Delete();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Build Assistant Error -> Couldn't clean directories: " + e);
            }
        }
    }
}
