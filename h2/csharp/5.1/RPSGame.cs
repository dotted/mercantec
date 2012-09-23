using System;

namespace _5._1
{
    class RPSGame
    {
        /// <summary>
        /// Keeps track of state of the Rock-Paper-Scissors game.
        /// </summary>
        string[] MoveNames = { "Rock", "Paper", "Scissors" };
        string computersChoice;
        Random r;
        /// <summary>
        /// Constructor
        /// Upon instantiation of the class, create instance of Random as r.
        /// </summary>
        public RPSGame()
        {
            r = new Random();
        }
        /// <summary>
        /// Property
        /// </summary>
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
        /// <summary>
        /// Method
        /// </summary>
        /// <param name="playersChoice">The choice made by the player</param>
        /// <returns></returns>
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
                //if playersChoice is Rock then return Result with defined params
                case "Rock":
                    //             Player P win     P lose
                    return Result("Rock", "Scissors", "Paper");
                case "Paper":
                    //             Player   P win   P lose
                    return Result("Paper", "Rock", "Scissors");
                case "Scissors":
                    //             Player      P win    P lose
                    return Result("Scissors", "Paper", "Rock");
                // If playerChoice is none of the 3 above return null
                default:
                    return null;
            }
        }
        /// <summary>
        /// Method
        /// Compare the parameters with computersChoice property
        /// Returns string: win, lose or draw.
        /// </summary>
        /// <param name="player">Choice of the player</param>
        /// <param name="Pwin">Losing computer choice</param>
        /// <param name="Plose">Winning computer choice</param>
        /// <returns></returns>
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
