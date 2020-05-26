using System;
using System.Collections.Generic;
using System.Linq;

namespace BalancedParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputParentheses = Console.ReadLine();

            if (inputParentheses.Length % 2 != 0)
            {
                Console.WriteLine("NO");
                return;
            }

            Queue<char> openingParentheses = new Queue<char>(inputParentheses);
            Stack<char> closingParentheses = new Stack<char>(inputParentheses);

            Dictionary<char, char> pairParentheses = new Dictionary<char, char>();
            pairParentheses.Add('(', ')');
            pairParentheses.Add('{', '}');
            pairParentheses.Add('[', ']');

            int counterItteratios = 0;
            while (openingParentheses.Any())
            {
                counterItteratios++;
                char currentOpeningBracket = openingParentheses.Dequeue();
                char currentClosingBracket = closingParentheses.Pop();

                if (counterItteratios == inputParentheses.Length / 2)
                {
                    break;
                }

                if (pairParentheses.ContainsKey(currentOpeningBracket))
                {
                    if (pairParentheses[currentOpeningBracket] == currentClosingBracket)
                    {
                        continue;
                    }

                    else
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }

                else
                {
                    Console.WriteLine("NO");
                    return;
                }
            }

            Console.WriteLine("YES");
        }
    }
}
