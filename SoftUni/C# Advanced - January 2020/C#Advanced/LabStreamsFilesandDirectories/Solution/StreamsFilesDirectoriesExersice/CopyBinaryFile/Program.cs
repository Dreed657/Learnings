using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using FileStream reader = new FileStream("copyMe.png", FileMode.Open);
            using FileStream writer = new FileStream("newImageCopy.png", FileMode.Create);

            var buffer = new byte[256];

            while (reader.CanRead)
            {
                var bytesReaded = reader.Read(buffer, 0, buffer.Length);

                if (bytesReaded == 0) break;

                writer.Write(buffer, 0, buffer.Length);
            }
        }
    }
}
