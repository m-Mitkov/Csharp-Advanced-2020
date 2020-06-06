using System;
using System.Collections.Generic;
using System.Linq;

namespace songsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputSongs = Console.ReadLine()
                .Split(", ");

            Queue<string> songs = new Queue<string>(inputSongs);

            while (songs.Any())
            {
                string[] comand = Console.ReadLine()
                    .Split(" ", 2);

                string toDo = comand[0];

                if (toDo == "Play")
                {
                    songs.Dequeue();
                }

                else if (toDo == "Add")
                {
                    string songToAdd = comand[1];

                    if (!songs.Contains(songToAdd))
                    {
                        songs.Enqueue(songToAdd);
                    }

                    else
                    {
                        Console.WriteLine($"{songToAdd} is already contained!"  );
                    }
                }

                else if(toDo == "Show")
                {
                    Console.WriteLine(string.Join(", ", songs));
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
