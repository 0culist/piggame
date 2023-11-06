/*
Pig is a simple dice game first described in print by John Scarne in 1945. Players take turns to roll a single dice as many times as they wish, adding all roll results to a running total, but losing their gained score for the turn if they roll a 1.
Each turn, a player repeatedly rolls a die until either a 1 is rolled or the player decides to "hold":
•	If the player rolls a 1, they score nothing and it becomes the next player's turn.
•	If the player rolls any other number, it is added to their turn total and the player's turn continues.
•	If a player chooses to "hold", their turn total is added to their score, and it becomes the next player's turn.
The first player to score 100 or more points wins.
For example, the first player, Donald, begins a turn with a roll of 5. Donald could hold and score 5 points, but chooses to roll again. Donald rolls a 2, and could hold with a turn total of 7 points, but chooses to roll again. Donald rolls a 1, and must end his turn without scoring. The next player, Alexis, rolls the sequence 4-5-3-5-5, after which she chooses to hold, and adds her turn total of 22 points to her score.
*/

namespace ConsoleApp1
{
    class Program
    {
        public static void Main(string[] args)
        {
            // create 'players' array to store scores in corresponding indexes.
            Console.Write("how many players: ");
            int userInput = 0;
            string rawInput = Console.ReadLine(); int.TryParse(rawInput, out userInput);
            int numPlayers = userInput;
            int[] playerScores = new int[numPlayers];
            
            // create array to store player names
            string[] playerNames = new string[numPlayers];
            for (int i = 0; i < playerScores.Length; i++)
            {
                Console.Write($"player {i+1} name: ");
                playerNames[i] = Console.ReadLine();
            }
            
            // choose dice which will be used for the game
            Console.Write("select...\n[1] d4\n[2] d6\n[3] d8\n[4] d10\n[5] d12\n[6] d20\ninput: ");
            rawInput = Console.ReadLine();
            int.TryParse(rawInput, out userInput);
            int diceChoice = userInput - 1;
            
            // method for a player's turn
            static int rollMethod(int turnScore, int diceChoice)
            {
                while (true)
                {
                    // define stuff
                    int currentRoll = 0;
                    Random rand = new Random();
                    int[] dice = {4, 6, 8, 10, 12, 20};
                    int userInput = 0;
                    
                    // roll and output
                    try
                    {
                        Console.Write($"rolling [d{dice[diceChoice]}]... ");
                        currentRoll = rand.Next(1, dice[diceChoice]);
                        Console.WriteLine(currentRoll);
                        if (currentRoll == 1)
                        {
                            turnScore = 0;
                            Console.WriteLine("you rolled a 1!\nturn over, you score nothing this turn");
                            return turnScore;
                        }
                        turnScore += currentRoll;
                        Console.WriteLine($"turn total: {turnScore}");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                    
                    // break loop
                    Console.Write("end turn?\n [1] no, roll again\n [2] yes, end turn\ninput: ");
                    string rawInput = Console.ReadLine();
                    int.TryParse(rawInput, out userInput);
                    if (userInput == 2)
                    {
                        Console.WriteLine("ending turn...");
                        return turnScore;
                    }
                    Console.WriteLine(); // newline
                }
            }
            
            // do stuff
            bool flagOne = false;
            while (flagOne == false)
            {
                for (int i = 0; i < playerScores.Length; i++)
                {
                    Console.WriteLine($"\n-- {playerNames[i]}'s turn --");
                    playerScores[i] += rollMethod(playerScores[i], diceChoice);
                    Console.WriteLine($"total score: {playerScores[i]}");
                    if (playerScores[i] >= 100)
                    {
                        Console.WriteLine($"{playerNames[i]} has won the game!");
                        flagOne = true;
                        break;
                    }
                }
            }
            
        }
    }
}