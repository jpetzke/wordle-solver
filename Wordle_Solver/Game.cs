using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordle_Solver;

namespace Wordle_Solver
{
    public class Game : IGame
    {

        private StringOperations _operations = new StringOperations();
        private CheckMatchWithRegex _checker = new CheckMatchWithRegex();

        public int GameEngine(string[] wordlist)
        {
            Console.Write("length of word to guess > ");
            int length = int.Parse(Console.ReadLine());

            
            wordlist = _operations.GetStringsWithLenghFromArray(wordlist, length);
            Console.WriteLine($"Size of wordlist => {wordlist.Length}");
            char[] word = new char[length];
            
            bool finished = false;
            while (!finished)
            {
                Random random = new Random();
                int rint = random.Next(wordlist.Length);
                string guess = wordlist[rint];
                wordlist = wordlist.Where(x => x != wordlist[rint]).ToArray(); // take the first element
                char[] xword = (char[])word.Clone();
                xword.ReplaceAll(default(char), '_');
                Console.Write($"Guess => {guess} \nNew game state > ");
                string? input = Console.ReadLine();

                if (input.Length == length) 
                { 
                    wordlist = wordlist.Where(x => _checker.checkMatchRegex(guess, input, x)).ToArray(); 
                }

                Console.WriteLine($"Size of wordlist => {wordlist.Length}");
                

            }
            return 0; // not actually
        }
    }
}

namespace Wordle_Solver
{
    public interface IGame
    {
        public int GameEngine(string[] wordlist);
    }
}
