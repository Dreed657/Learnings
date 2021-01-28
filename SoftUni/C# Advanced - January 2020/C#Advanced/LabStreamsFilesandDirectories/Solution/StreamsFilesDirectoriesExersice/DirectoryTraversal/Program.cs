using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\report.txt";

            DirectoryInfo dir = new DirectoryInfo(@".\..\..\..\Traversal");
            FileInfo[] files = dir.GetFiles();

            var dict = new Dictionary<string, Dictionary<string, double>>();

            for (int i = 0; i < files.Length; i++)
            {
                if (files[i].Exists)
                {
                    var name = files[i].Name;
                    double size = files[i].Length / 1024;
                    var extention = files[i].Extension;

                    if (!dict.ContainsKey(extention)) dict.Add(extention, new Dictionary<string, double>());
                    dict[extention].Add(name, size);
                }
            }

            var output = new List<string>();

            foreach (var (extention, value) in dict.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                output.Add(extention);

                foreach (var (file, size) in value.OrderBy(x => x.Value))
                    output.Add($"--{file} - {size:F2}kb");
            }

            File.WriteAllLines(desktopPath, output);
        }
    }
}
