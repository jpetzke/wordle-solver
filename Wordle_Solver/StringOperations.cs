using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hangman_Solver;

namespace Wordle_Solver
{
    public class StringOperations : IStringOperations
    {

        public bool StringDoesMatch(string source, string condition, string check)
        {
            char[] condition_chars = condition.ToCharArray();
            char[] check_chars = check.ToCharArray();
            char[] source_chars = source.ToCharArray();

            List<int> ignore_star_chars_indexes = new List<int>();

            for (int i = 0; i < condition_chars.Length; i++)
            {

                if (condition_chars[i] == '+')
                {
                    if (source_chars[i] != check_chars[i]) 
                    {
                        Console.WriteLine($"Guess = {source} | Condition = {condition} | Check = {check} => + does not match at index {i} => false"); 
                        return false; 
                    }

                    ignore_star_chars_indexes.Add(i);

                }
                else if (condition_chars[i] == '*')
                {
                    if (source_chars[i] == check_chars[i]) 
                    {
                        Console.WriteLine($"Guess = {source} | Condition = {condition} | Check = {check} => * does match at index {i} => false");
                        return false; 
                    }
                    if (!check_chars.Contains(source_chars[i])) 
                    { 
                        Console.WriteLine($"Guess = {source} | Condition = {condition} | Check = {check} => * check does not contain at index {i} => false"); 
                        return false; 
                    }
                }
                else if (condition_chars[i] == '-')
                {
                    if (check_chars.Contains(source_chars[i])) 
                    { 
                        Console.WriteLine($"Guess = {source} | Condition = {condition} | Check = {check} => - does contain char at index {i} => false");
                        return false; 
                    }
                }
            }
            Console.WriteLine($"Guess = {source} | Condition = {condition} | Check = {check} => matches all => true");
            return true;
        }


        public int GetIndex(string[] array, string query)
        {
            if (array == null || query == null) { throw new ArgumentNullException(); }
            return array.Select((elem, index) => new { elem, index }).First(p => p.elem == query).index;
        }

        public int CountCharsInString(string s, char f)
        {
            if (s == null || f == default(char)) { throw new ArgumentNullException(); }
            return s.Count(c => c == f);
        }

        public string[] GetStringsWithLenghFromArray(string[] array, int length)
        {
            return array.Where(x => x.Length == length).ToArray();
        }

        public string[] GetStringsWithCharAtIndex(string[] array, int index, char c)
        {
            return array.Where(x => x[index] == c).ToArray();
        }
        public string[] GetStringsWithNotCharAtIndex(string[] array, int index, char c)
        {
            return array.Where(x => x[index] != c).ToArray();
        }

        public string[] GetStringsContainingChar(string[] array, char c)
        {
            return array.Where(x => x.Contains(c)).ToArray();
        }

        public string[] GetStringsNotContainingChar(string[] array, char c)
        {
            return array.Where(x => !x.Contains(c)).ToArray();
        }

    }
}


namespace Hangman_Solver
{
    public interface IStringOperations
    {
        int GetIndex(string[] array, string query);
        public int CountCharsInString(string s, char c);
        public string[] GetStringsWithLenghFromArray(string[] array, int length);
        public string[] GetStringsWithCharAtIndex(string[] array, int index, char c);
        public string[] GetStringsContainingChar(string[] array, char c);
        public string[] GetStringsNotContainingChar(string[] array, char c);
        public string[] GetStringsWithNotCharAtIndex(string[] array, int index, char c);
    }
}
