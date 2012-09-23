using Views;
using System;

namespace _5._1
{
    class DriveRPSGameGUI
    {
        /// <summary>
        /// RSPGame with GUI      Bishop and Horspool      May 2002 
        /// ================
        /// Plays the Rock-Paper-Scissors game with the user.
        /// Illustrates GUI interaction, and switch on string.
        /// Uses the class RSPSGame from Chapter 4.
        /// </summary>
        string fspec =
          @"<form Text='Rock-Paper-Scissors'>
      <vertical>
        <Label Text='Rock-Paper-Scissors' ForeColor=Red Font=Bold18/>
        <horizontal>
          <vertical>
            <space Height=1cm/>
            <Label Text=Wins/>
            <TextBox Name=winBox Width=2cm/>
            <space Height=0.5cm/>
            <Label Text=Losses/>
            <TextBox Name=lossBox Width=2cm/>
            <space Height=0.5cm/>
            <Label Text=Draws/>
            <TextBox Name=drawBox Width=2cm/>
          </vertical>
          <vertical>
            <Label Text=History/>
            <ListBox Name=history Width=7cm/>
          </vertical>
        </horizontal>
        <space Width=10cm Height=0.1cm BackColor=Black
                 halign=center/>
        <Label Text='Choose your selection ...' ForeColor=Red/>
        <horizontal>
          <Button Name=Rock Image='Rock.gif' Width=3cm/>
          <Button Name=Paper Image='Paper.gif' Width=3cm/>
          <Button Name=Scissors Image='Scissors.gif' Width=3cm/>
        </horizontal>
      </vertical>
    </Form>";

        string playersChoice;

        void Go()
        {
            /// <summary>
            /// Drives the Rock-Paper-Scissors game.
            /// </summary>

            RPSGame game = new RPSGame();
            int noOfWins, noOfDraws, noOfLosses, round;

            Views.Form form = new Views.Form(fspec);
            noOfWins = noOfDraws = noOfLosses = 0;
            round = 0;
            form.PutText("drawBox", "0");
            form.PutText("winBox", "0");
            form.PutText("lossBox", "0");

            string computersChoice, c, result;

            for (; ; )
            {
                computersChoice = game.ComputersChoice;
                c = form.GetControl();
                if (c == null) break;
                ActionPerformed(c);  // sets playersChoice
                result = game.ComparePlays(playersChoice);

                round++;
                form.PutText("history", "Round " + round);
                form.PutText("history",
                       "The computer's choice = " + computersChoice);
                form.PutText("history",
                       "The player's choice = " + playersChoice);

                switch (result)
                {
                    case "draw":
                        form.PutText("history", "  This round is drawn");
                        noOfDraws++;
                        form.PutText("drawBox", noOfDraws.ToString());
                        break;
                    case "lose":
                        form.PutText("history", "  Sorry, you lose this round");
                        noOfLosses++;
                        form.PutText("lossBox", noOfLosses.ToString());
                        break;
                    case "win":
                        form.PutText("history", "  Well done, you win this round");
                        noOfWins++;
                        form.PutText("winBox", noOfWins.ToString());
                        break;
                }
                form.PutText("history", "");
            }
            form.CloseGUI();
        }

        void ActionPerformed(string c)
        {
            switch (c)
            {
                case "Rock":
                case "Paper":
                case "Scissors": playersChoice = c;
                    break;
                default:
                    throw new Exception("Unhandled control " + c);
            }
        }
        static void Main()
        {
            new DriveRPSGameGUI().Go();
        }
    }
}
