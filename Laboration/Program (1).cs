using Laboration;
using Laboration.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MooGame
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
            .AddSingleton<IGameLogic, GameLogic>()
            .AddSingleton<IPlayer, Player>()
            .BuildServiceProvider();

            var gameLogic = serviceProvider.GetService<IGameLogic>();
            var player = serviceProvider.GetService<IPlayer>();

            GameBoard gameBoard = new(gameLogic, player);
            //gameBoard.RunTheGame();
            //bool playOn = true;

            while (gameBoard.RunTheGame())
            {
                gameBoard.RunTheGame();
            }




            //var container = new Container();

            //container.Add<IUserInterface,UserInterface>();
            //container.Add<IPlayer, Player>();
            //container.Add<IGameLogic,GameLogic>();



            //        bool playOn = true;
            //        Console.WriteLine("Enter your user name:\n");
            //        string userName = Console.ReadLine();

            //        while (playOn)
            //        {
            //            // change "goal" name everyname that has goal in it 
            //            string goal = GenerateGoalNumber();


            //            Console.WriteLine("New game:\n");
            //            //comment out or remove next line to play real games!
            //            Console.WriteLine("For practice, number is: " + goal + "\n");
            //            string userGuess = Console.ReadLine();

            //            int numberOfGuesses = 1;
            //            string bbcc = CheckBC(goal, userGuess);
            //            Console.WriteLine(bbcc + "\n");
            //            while (bbcc != "BBBB,")
            //            {
            //                numberOfGuesses++;
            //                userGuess = Console.ReadLine();
            //                Console.WriteLine(userGuess + "\n");
            //                bbcc = CheckBC(goal, userGuess);
            //                Console.WriteLine(bbcc + "\n");
            //            }
            //            StreamWriter output = new StreamWriter("result.txt", append: true);
            //            output.WriteLine(userName + "#&#" + numberOfGuesses);
            //            output.Close();
            //            ShowTopList();
            //            Console.WriteLine("Correct, it took " + numberOfGuesses + " guesses\nContinue?");
            //            string answer = Console.ReadLine();
            //            if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
            //            {
            //                playOn = false;
            //            }
            //        }
            //    }
            //    static string GenerateGoalNumber()
            //    {
            //        Random randomGenerator = new Random();
            //        string goal = "";
            //        for (int i = 0; i < 4; i++)
            //        {
            //            int random = randomGenerator.Next(10);
            //            string randomDigit = "" + random;
            //            while (goal.Contains(randomDigit))
            //            {
            //                random = randomGenerator.Next(10);
            //                randomDigit = "" + random;
            //            }
            //            goal = goal + randomDigit;
            //        }
            //        return goal;
            //    }

            //    static string CheckBC(string goal, string guess)
            //    {
            //        int cows = 0, bulls = 0;
            //        guess += "    ";     // if player entered less than 4 chars
            //        for (int i = 0; i < 4; i++)
            //        {
            //            for (int j = 0; j < 4; j++)
            //            {
            //                if (goal[i] == guess[j])
            //                {
            //                    if (i == j)
            //                    {
            //                        bulls++;
            //                    }
            //                    else
            //                    {
            //                        cows++;
            //                    }
            //                }
            //            }
            //        }
            //        return "BBBB".Substring(0, bulls) + "," + "CCCC".Substring(0, cows);
            //    }


            //    static void ShowTopList()
            //    {
            //        StreamReader input = new StreamReader("result.txt");
            //        List<Player> results = new List<Player>();
            //        string line;
            //        while ((line = input.ReadLine()) != null)
            //        {
            //            string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
            //            string name = nameAndScore[0];
            //            int guesses = Convert.ToInt32(nameAndScore[1]);
            //            Player pd = new Player(name, guesses);
            //            int pos = results.IndexOf(pd);
            //            if (pos < 0)
            //            {
            //                results.Add(pd);
            //            }
            //            else
            //            {
            //                results[pos].Update(guesses);
            //            }


            //        }
            //        results.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));
            //        Console.WriteLine("Player   games average");
            //        foreach (Player p in results)
            //        {
            //            Console.WriteLine(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.Name, p.NumberOfGames, p.Average()));
            //        }
            //        input.Close();
            //    }
            //}

            //class PlayerData
            //{
            //    public string Name { get; private set; }
            //    public int NumberOfGames { get; private set; }
            //    int totalGuess;


            //    public PlayerData(string name, int guesses)
            //    {
            //        this.Name = name;
            //        NumberOfGames = 1;
            //        totalGuess = guesses;
            //    }

            //    public void Update(int guesses)
            //    {
            //        totalGuess += guesses;
            //        NumberOfGames++;
            //    }

            //    public double Average()
            //    {
            //        return (double)totalGuess / NumberOfGames;
            //    }


            //    public override bool Equals(Object p)
            //    {
            //        return Name.Equals(((PlayerData)p).Name);
            //    }


            //    public override int GetHashCode()
            //    {
            //        return Name.GetHashCode();
            //    }
        }
    }
}
    //public class GameBoard
    //{
    //    // Private fields for the game board state
    //    private List<Row> rows;
    //    private int[] scores;

    //    // Public constructor for initializing the game board
    //    public GameBoard(int numRows, int numPlayers)
    //    {
    //        // Initialize the rows and scores arrays
    //        rows = new List<Row>(numRows);
    //        scores = new int[numPlayers];

    //        // Add empty rows to the game board
    //        for (int i = 0; i < numRows; i++)
    //        {
    //            rows.Add(new Row());
    //        }
    //    }

        //// Public method for making a guess
        //public void MakeGuess(int player, List<Peg> guess)
        //{
        //    // Check if the guess is valid
        //    if (IsValidGuess(guess))
        //    {
        //        // Add the guess to the game board
        //        rows[player].AddGuess(guess);

        //        // Check if the guess is correct
        //        if (IsCorrectGuess(guess))
        //        {
        //            // Update the player's score
        //            scores[player]++;
        //        }
        //    }
        //    else
        //    {
        //        // Print an error message if the guess is not valid
        //        Console.WriteLine("Invalid guess. Please try again.");
        //    }
        //}

        //// Other methods and fields for the game board...

