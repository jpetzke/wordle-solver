using Wordle_Solver;

string[] file = System.IO.File.ReadAllLines(Constants.wordlist);

Game _game = new Game();
_game.GameEngine(file);