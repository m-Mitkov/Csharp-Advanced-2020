using System;
using System.IO;

namespace LineNumbers1
{
    class Program
    {
        static void Main(string[] args)
        {
           var reader =  File.ReadAllLines("text.txt");

            for (int i = 0; i < reader.Length; i++)
            {
                var currenLine = reader[i];
                var countLetters = 0;
                var countPunctuation = 0;

                foreach (var item in currenLine)
                {
                    if (char.IsLetter(item))
                    {
                        countLetters++;
                    }

                    else if (char.IsPunctuation(item))
                    {
                        countPunctuation++;
                    }
                }

                reader[i] =  $"Line{i + 1}: {currenLine} ({countLetters})({countPunctuation})";
            }

            File.WriteAllLines("output.txt", reader);
        }
    }
}
