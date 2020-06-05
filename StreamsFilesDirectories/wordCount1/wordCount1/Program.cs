using System;
using System.IO;
using System.Collections.Generic;

namespace wordCount1
{
    class Program
    {
        static void Main(string[] args)
        {
            var wordsToKeepCount = new Dictionary<string, int>();
            using StreamReader readerWords = new StreamReader("words.txt");
            ReadWords(wordsToKeepCount, readerWords);

            using StreamReader textReader = new StreamReader("text.txt");

            while (!textReader.EndOfStream)
            {
                string[] line = textReader.ReadLine()
                    .ToLower()
                    .Split(" ");

                for (int i = 0; i < line.Length; i++)
                {
                    if (wordsToKeepCount.ContainsKey(line[i]))
                    {
                        wordsToKeepCount[line[i]]++;
                    }
                }
            }

            using StreamWriter writer = new StreamWriter("output.txt");

            writer.Write(string.Join(Environment.NewLine, wordsToKeepCount));

        }

        public static void ReadWords(Dictionary<string, int> words, StreamReader reader)
        {
            while (!reader.EndOfStream)
            {
                string word = reader.ReadLine();

                if (!words.ContainsKey(word))
                {
                    words.Add(word, 1);
                }
            }
        }
    }
}
