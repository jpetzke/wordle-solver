using Wordle_Solver;

Options options = new Options();

// get wordlist from the argument 
options.wordlist = args[0];

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