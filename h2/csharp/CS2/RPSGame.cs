using System;

namespace CS2
{
    class RPSGame
    {
        /// <summary>
        /// Keeps track of state of the Rock-Paper-Scissors game.
        /// </summary>
        string[] MoveNames = { "Rock", "Paper", "Scissors" };
        string computersChoice;
        Random r;
        public RPSGame()
        {
            r = new Random();
        }
        public string ComputersChoice
        {
            get
            {
                // generate a random 0, 1 or 2 and convert it to a string
                // and save it for the compare phase
                computersChoice = MoveNames[r.Next(3)];
                return computersChoice;
            }
        }

        public string ComparePlays(string playersChoice)
        {
            /// <summary>
            /// Determines whether the player beats the computer.
            /// Calls constructMessage where the parameters are
            /// - the player's choice
            /// - the choice the player could beat
            /// - the choice that could beat the player.
            /// </summary>
            switch (playersChoice)
            {
                case "Rock":
                    //             Player P win     P lose
                    return Result("Rock", "Scissors", "Paper");
                case "Paper":
                    //             Player   P win   P lose
                    return Result("Paper", "Rock", "Scissors");
                case "Scissors":
                    //             Player      P win    P lose
                    return Result("Scissors", "Paper", "Rock");
                default:
                    return null;
            }
        }

        string Result(string player, string Pwin, string Plose)
        {
            if (computersChoice == Pwin)
                return "win";
            else if (computersChoice == Plose)
                return "lose";
            else
                return "draw";
        }
    }
}
