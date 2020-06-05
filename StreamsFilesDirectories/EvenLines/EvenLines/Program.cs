using System;
using System.IO;
using System.Linq;

namespace EvenLines
{
    class Program
    {
        static void Main()
        {
            var separators = new char[] { '-', ',', '.', '!', '?' };

           using var reader = new StreamReader("text.txt");
           using var writer = new StreamWriter("output.txt");

            int counter = 0;

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine()
                    .Split(" ")
                    .Reverse()
                    .ToArray();

                if (counter % 2 == 0)
                {
                    for (int i = 0; i < line.Length; i++)
                    {
                        foreach (var symbol in separators)
                        {
                            line[i] = line[i].Replace(symbol, '@');
                        }
                    }

                    string text = String.Join(" ", line);
                    writer.WriteLine(text);
                }

                counter++;
            }
        }
    }
}
