using System;

namespace CS2
{
    class DriveRPSGameConsole
    {
        /// <summary>
        /// RSPGame      Bishop and Horspool    August 2002
        /// =======
        /// Plays the Rock-Paper-Scissors game with the user,
        /// using the Console for input-output
        /// </summary>
        void Go()
        {
            /// <summary>
            /// Drives the Rock-Paper-Scissors game.
            /// </summary>
            RPSGame game = new RPSGame();
            int noOfWins, noOfDraws, noOfLosses, round;
            noOfWins = noOfDraws = noOfLosses = round = 0;
            string computersChoice;
            string result;
            for (; ; )
            {
                computersChoice = game.ComputersChoice;
                string playersChoice = null;
                do
                {
                    Console.Write(
                      "Enter R (Rock), P (Paper), " +
                      "S (Scissors), or Q (Quit): ");
                    string b = Console.ReadLine().ToLower();
                    switch (b[0])
                    {
                        case 'r':
                            playersChoice = "Rock"; break;
                        case 'p':
                            playersChoice = "Paper"; break;
                        case 's':
                            playersChoice = "Scissors"; break;
                        case 'q':
                            playersChoice = "Quit"; break;
                    }
                } while (playersChoice == null);
                if (playersChoice == "Quit") break;
                result = game.ComparePlays(playersChoice);
                round++;
                Console.WriteLine("Round " + round);
                Console.WriteLine("The computer's choice = " + computersChoice);
                Console.WriteLine("The player's choice = " + playersChoice);
                switch (result)
                {
                    case "draw":
                        Console.WriteLine("  This round is drawn");
                        noOfDraws++;
                        break;
                    case "lose":
                        Console.WriteLine("  Sorry, you lose this round");
                        noOfLosses++;
                        break;
                    case "win":
                        Console.WriteLine("  Well done, you win this round");
                        noOfWins++;
                        break;
                }
                Console.WriteLine("Status: {0} wins, {1} draws," +
                          "{2} losses", noOfWins,
                  noOfDraws, noOfLosses);
            }
        }
        static void Main()
        {
            new DriveRPSGameConsole().Go();
        }
    }
}
