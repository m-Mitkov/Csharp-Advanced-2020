using System;
using System.IO;

namespace copyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using var fileToCopy = new FileStream("Botev.jpg", FileMode.Open);
            using var copiedFile = new FileStream("copyOfBotev.jpg", FileMode.Create);

            fileToCopy.CopyTo(copiedFile);
        }
    }
}
