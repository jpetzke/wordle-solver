using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Wordle_Solver
{
    public class CheckMatchWithRegex
    {

        public bool checkMatchRegex(string source, string pattern, string match)
        {
            int len = pattern.Length;

            if (match.Length != len | source.Length != len) { return false; }

            string[] regex_raw = new string[len];
            string[] regex_formatted = new string[len];
            char[] regex_flags = new char[len];

            string forbidden_chars = "";
            List<char> somewhere_chars = new List<char>();

            // get raw data
            for (int i = 0; i < len; i++)
            {
                char op = pattern[i];
                regex_flags[i] = op;

                switch (op)
                {
                    case '+':
                        regex_raw[i] = source[i].ToString();
                        continue;
                    case '-':
                        forbidden_chars += (source[i]);
                        continue;
                    case '*':
                        somewhere_chars.Add(source[i]);
                        regex_raw[i] += source[i].ToString();
                        continue;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            // remove multiple times the same character
            for (int i = 0; i < len; i++)
            {
                if (source.Count(c => c == source[i]) > 1 )
                {
                    forbidden_chars = forbidden_chars.Replace(source[i].ToString(), string.Empty);
                }
            }

            // format the regex expression
            for (int i = 0; i < len; i++)
            {
                char op = regex_flags[i];

                switch (op)
                {
                    case '+':
                        regex_formatted[i] = source[i].ToString();
                        continue;
                    case '*':
                        regex_formatted[i] = $"[^{regex_raw[i]}{forbidden_chars}]";
                        continue;
                    case '-':
                        regex_formatted[i] = $"[^{forbidden_chars}]";
                        continue;
                    default:
                        throw new ArgumentOutOfRangeException();

                }
            }

            string rgex_combined = string.Join("", regex_formatted);
            Regex rex = new Regex(rgex_combined, RegexOptions.IgnoreCase);
            Console.WriteLine($"{match} --{{ {rex} }}--> {rex.IsMatch(match)}");

            foreach (char c in somewhere_chars)
            {
                if (!match.Contains(c))
                {
                    return false;
                }
            }

            return rex.IsMatch(match);
        }
    }
}
