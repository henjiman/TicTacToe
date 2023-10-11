//Ben Hayden
//Module 10
//November 4

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TicTacToe.Models;

namespace TicTacToe.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            BoardStateModel boardState;
            //If a board hasn't been created yet.
            if (!TempData.ContainsKey("BoardBoxes") || !TempData.ContainsKey("WhoseTurn"))
            {
                //Create new, empty board state
                boardState = new BoardStateModel();
                TempData["BoardBoxes"] = boardState.Boxes;
                TempData["WhoseTurn"] = boardState.WhoseTurn;
            }
            //If a board has already been created
            else
            {
                //create boardstate from tempdata information
                boardState = new BoardStateModel((string[])TempData.Peek("BoardBoxes"),(string)TempData.Peek("WhoseTurn"));
            }
            return View(boardState);
        }

        //post action when a button is clicked
        //button number is sent using model binding
        [HttpPost]
        public IActionResult Index(int buttonNumber)
        {
            //gets current box states from temp data
            var currentBoxes = (string[])TempData.Peek("BoardBoxes");

            //sets whichever button got clicked to represent the player who made that move
            currentBoxes[buttonNumber] = (string)TempData.Peek("WhoseTurn");

            //flips whoseTurn variable
            TempData["WhoseTurn"] = ((string)TempData["WhoseTurn"] == "X") ? "O" : "X";

            //sets back tempData to equal updated box states
            TempData["BoardBoxes"] = currentBoxes;

            //return to index action
            return RedirectToAction("Index");
        }

        //new game action
        public IActionResult NewGame()
        {
            //clears tempData so next time in index, will create new board state
            TempData.Clear();
            return RedirectToAction("Index");
        }
    }
}
