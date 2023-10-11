//Ben Hayden
//Module 10
//November 4

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToe.Models
{
    public class BoardStateModel
    {
        //constructor for new board states
        public BoardStateModel()
        {
            Boxes = new string[9]{
                " ",
                " ",
                " ",
                " ",
                " ",
                " ",
                " ",
                " ",
                " "
            };

            Winner = "none";
            WhoseTurn = "X";
        }
        //constructor for already-existing board states
        public BoardStateModel(string[] boxes,string whoseTurn)
        {
            Boxes = boxes;
            WhoseTurn = whoseTurn;
            Winner = "none";
        }

        //array of X's or O's 
        //array elements are arranged like this:
        //   0 | 1 | 2
        //   3 | 4 | 5
        //   6 | 7 | 8
        public string[] Boxes { get; set; }

        //either is "X" or "O" depending on whose turn it is
        public string WhoseTurn { get; set; }

        //who won
        public string Winner { get; set; }

        //this function returns "disabled" if the selected box number has been filled already
        //or if the game is over
        //used to disable the buttons after being pressed
        public string Disabled(int boxNum)
        {
            if (Boxes[boxNum] != " " || Winner != "none") return "disabled";
            return "";
        }

        //contains the logic for when the game is over
        public bool IsGameOver()
        {
            //first row
            if (Boxes[0] == Boxes[1] && Boxes[0] == Boxes[2] && Boxes[0] != " ")
            {
                Winner = Boxes[0];
                return true;
            }
            //second row
            else if (Boxes[3] == Boxes[4] && Boxes[3] == Boxes[5] && Boxes[3] != " ")
            {
                Winner = Boxes[3];
                return true;
            }
            //third row
            else if (Boxes[6] == Boxes[7] && Boxes[6] == Boxes[8] && Boxes[6] != " ")
            {
                Winner = Boxes[6];
                return true;
            }

            //first column
            else if (Boxes[0] == Boxes[3] && Boxes[0] == Boxes[6] && Boxes[0] != " ")
            {
                Winner = Boxes[0];
                return true;
            }
            //second column
            else if (Boxes[1] == Boxes[4] && Boxes[1] == Boxes[7] && Boxes[1] != " ")
            {
                Winner = Boxes[1];
                return true;
            }
            //third column
            else if (Boxes[2] == Boxes[5] && Boxes[2] == Boxes[8] && Boxes[2] != " ")
            {
                Winner = Boxes[2];
                return true;
            }

            //down-right diagonal
            else if (Boxes[0] == Boxes[4] && Boxes[0] == Boxes[8] && Boxes[0] != " ")
            {
                Winner = Boxes[0];
                return true;
            }
            //up-right diagonal
            else if (Boxes[6] == Boxes[4] && Boxes[6] == Boxes[2] && Boxes[6] != " ")
            {
                Winner = Boxes[6];
                return true;
            }


            //tie
            else if (Boxes[0] != " " && Boxes[1] != " " && Boxes[2] != " " && Boxes[3] != " " && Boxes[4] != " " && Boxes[5] != " " && Boxes[6] != " " && Boxes[7] != " " && Boxes[8] != " ")
            {
                Winner = "tie";
                return true;
            }
                
            //the game is not over yet
            return false;
        }
    }
}
