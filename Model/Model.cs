using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTC.Model
{
    class Model
    {
        public static string[] FindDisks()
        {
            return Directory.GetLogicalDrives();
        }

        public static string[] FindFiles(string path)
        {
            List<string> files = new List<string>();
            try
            {
                files.Add("..");

                // add directories
                string[] directories = Directory.GetDirectories(path);

                for (int i = 0; i < directories.Length; i++)
                    files.Add("<D>" + Path.GetFileName(directories[i]));

                // add files
                string[] f = Directory.GetFiles(path);

                for (int i = 0; i < f.Length; i++)
                    files.Add(Path.GetFileName(f[i]));

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return files.ToArray();
        }

        public static string ChangePath(string path, string file)
        {
            if (file != null && file != ".." && file.Substring(0, 3) == "<D>")
            {
                file = file.Replace("<D>", "");

                return Path.Combine(path, file);
            }

            // cofanie do porzedniego katalogu
            else if (path != null && file == ".." && path.Length > 3)
            {
                int l = 0;
                for (int i = path.Length - 1; i > 1; i--)
                {
                    if (String.Equals(path[i].ToString(), @"\"))
                    {
                        path = path.Substring(0, path.Length - l - 1);
                        break;
                    }
                    l++;
                }

                if (path.Length == 2)
                    path += @"\";
            }

            return path;
        }

        // kopiowanie
        public static void CopyFile(string sourceFile, string destinationFile)
        {
            try
            {
                File.Copy(sourceFile, destinationFile, true);
            }

            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("sourceFile: " + sourceFile + " dest: " + destinationFile);
        }
    }
}
