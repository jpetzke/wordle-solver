using Wordle_Solver;

Options options = new Options();

// get wordlist from the argument 
try
{
    options.wordlist = args[0];
}
catch (System.IndexOutOfRangeException)
{
    Console.WriteLine("Usage: Wordle_Solver.exe \"C:\\path\\to\\wordlist.txt\"");
}

string[] file = new string[0];

try
{
    file = System.IO.File.ReadAllLines(options.wordlist);
    Console.WriteLine("Loaded wordlist from " + options.wordlist);
    Console.WriteLine("Wordlist contains " + file.Length + " words");
}
catch (System.IO.FileNotFoundException)
{
    Console.WriteLine("File not found: ", args[0]);
    Environment.Exit(1);
}

Game _game = new Game();
_game.GameEngine(file);