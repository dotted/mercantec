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
            // create object reference game for class RPSGame
            RPSGame game = new RPSGame();
            // create some int vars
            int noOfWins, noOfDraws, noOfLosses, round;
            // set, set, vars to 0
            noOfWins = noOfDraws = noOfLosses = round = 0;
            // some string vars
            string computersChoice;
            string result;
            //WHY MICROSOFT WHYYYYYYYYYYYYYYYYYY???
            //Infinite loop, damnit white (true) should be used here.
            for (; ; )
            {
                // Store the return value of the ComutersChoice method from the game object reference
                computersChoice = game.ComputersChoice;
                // store playersChoice string with null
                string playersChoice = null;
                // Run code atleast once and repeat until while conditions are met
                do
                {
                    //Write things to the console
                    Console.Write(
                      "Enter R (Rock), P (Paper), " +
                      "S (Scissors), or Q (Quit): ");
                    // Store lowercased console input as a string in b var
                    string b = Console.ReadLine().ToLower();
                    //Switch on the first caracter in b var
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
                //if value of playersChoice wasn't changed repeat until a coice has been made
                } while (playersChoice == null);
                //Break out of infinite loop if choice is quit
                if (playersChoice == "Quit") break;
                //store the return of RPSGame method ComparePlays in result var
                result = game.ComparePlays(playersChoice);
                //same as round = round + 1
                round++;
                //write things
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
        // Main method, starting point of our program
        static void Main()
        {
            // instantiate DriveRPSGameConsole and call Go method
            new DriveRPSGameConsole().Go();
        }
    }
}
