using System;
using System.Linq;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;
using System.Text;

namespace ZipandExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Archive.zip";
            string rootPath = "./../../../";

            ZipFile.CreateFromDirectory(rootPath + "temp", desktopPath);

            ZipFile.ExtractToDirectory(desktopPath, rootPath);
        }
    }
}
