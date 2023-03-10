using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Threading;

namespace TicTacToe
{
    public class UserInterface
    {


        // Set starting values, variables
        int positionX = 0;
        int positionY = 0;
        int choice;
        int player = 1;
        int turnCounter = 1;
        string xOrO = "X"; // UpdatePlayer method changes both player and xOrO
        bool isGameOver = false;
        bool isDraw = false;
        Board board = new Board();
        List<int> taken = new List<int>(); // collects positions 1-9 so it cannot be reused


        public void TicTacGo()
        {
            while (!isGameOver)
            {
                ChoiceScreen();
                SetPosition(choice);
                board.gameBoard[positionX, positionY] = xOrO;
                turnCounter++;
                UpdatePlayer();
                CheckIfGameIsOver();
            }

            Console.Clear();
            board.PrintActiveBoard();
            turnCounter++;
            UpdatePlayer();

            if (isDraw)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Game is over, there is no winner.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Game is Over! Player {player} has won.");
            }
        }


        // Methods
        void UpdatePlayer()
        {
            if (turnCounter % 2 == 0)
            {
                xOrO = "O";
                player = 2;
            }
            else
            {
                xOrO = "X";
                player = 1;
            }
        }

        void SetPosition(int pos)  // translates choice input from user to gameBoard coordinates, adds choice to taken
        {

            switch (pos)
            {
                case 1:
                    positionX = 0;
                    positionY = 0;
                    taken.Add(1);
                    break;
                case 2:
                    positionX = 0;
                    positionY = 1;
                    taken.Add(2);
                    break;
                case 3:
                    positionX = 0;
                    positionY = 2;
                    taken.Add(3);
                    break;
                case 4:
                    positionX = 1;
                    positionY = 0;
                    taken.Add(4);
                    break;
                case 5:
                    positionX = 1;
                    positionY = 1;
                    taken.Add(5);
                    break;
                case 6:
                    positionX = 1;
                    positionY = 2;
                    taken.Add(6);
                    break;
                case 7:
                    positionX = 2;
                    positionY = 0;
                    taken.Add(7);
                    break;
                case 8:
                    positionX = 2;
                    positionY = 1;
                    taken.Add(8);
                    break;
                case 9:
                    positionX = 2;
                    positionY = 2;
                    taken.Add(9);
                    break;
            }
        }

        void ChoiceScreen()
        {
            Console.Clear();
            Console.WriteLine($"Player {player} is {xOrO}. Please choose your position");
            Console.WriteLine();
            Thread.Sleep(200);  // helps visually distinguish new gameBoard
            board.PrintActiveBoard();
            choice = int.Parse(Console.ReadLine());

            // need a way to protect against string input, just use switch/case?

            while (choice < 1 || choice > 10 || taken.Contains(choice))
            {
                Console.WriteLine("Not a valid choice. Please select available square using displayed number.");
                choice = int.Parse(Console.ReadLine());
            }
        }


        // win conditions

        
        void CheckIfGameIsOver()  // loops through gameBoard string in chunks of 3, looking for XXX or OOO
        {
            char[] check = BoardToString(board.gameBoard).ToCharArray();
            bool threeInARow = false;
            for (int i = 0; i < check.Length; i += 3)
            {
                string three = "";
                three += check[i].ToString() + check[i + 1].ToString() + check[i + 2].ToString();
                if (three == "XXX" || three == "OOO")
                {
                    threeInARow = true;
                }
            }
            if (threeInARow == true)
            {
                isGameOver = true;
            }
            else if (turnCounter == 10)
            {
                isGameOver = true;
                isDraw = true;
            }

        }

        // turns active board into a string that can be looped through and searched for patterns
        string BoardToString(string[,] arr)
        {
            string holder = "";
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    holder += arr[i, j];
                }
            }
            for (int i = 0; i < arr.GetLength(1); i++)
            {
                for (int j = 0; j < arr.GetLength(0); j++)
                {
                    holder += arr[j, i];
                }
            }
            int k = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                holder += arr[i, k];
                k++;
            }
            int l = 0;
            for (int i = arr.GetLength(0) - 1; i >= 0; i--)
            {
                holder += arr[i, l];
                l++;
            }
            return holder;
        }

        // first try on logic for check conditions
        /*
        void CheckIfGameOver()
        {
            if (board.gameBoard[0, 0] == board.gameBoard[0, 1] && board.gameBoard[0, 1] == board.gameBoard[0, 2])
            {
                gameOver = true;
            }
            else if (board.gameBoard[1, 0] == board.gameBoard[1, 1] && board.gameBoard[1, 1] == board.gameBoard[1, 2])
            {
                gameOver = true;
            }
            else if (board.gameBoard[2, 0] == board.gameBoard[2, 1] && board.gameBoard[2, 1] == board.gameBoard[2, 2])
            {
                gameOver = true;
            }
            else if (board.gameBoard[0, 0] == board.gameBoard[1, 0] && board.gameBoard[1, 0] == board.gameBoard[2, 0])
            {
                gameOver = true;
            }
            else if (board.gameBoard[0, 1] == board.gameBoard[1, 1] && board.gameBoard[1, 1] == board.gameBoard[2, 1])
            {
                gameOver = true;
            }
            else if (board.gameBoard[0, 2] == board.gameBoard[1, 2] && board.gameBoard[1, 2] == board.gameBoard[2, 2])
            {
                gameOver = true;
            }
            else if (board.gameBoard[0, 0] == board.gameBoard[1, 1] && board.gameBoard[1, 1] == board.gameBoard[2, 2])
            {
                gameOver = true;
            }
            else if (board.gameBoard[2, 0] == board.gameBoard[1, 1] && board.gameBoard[1, 1] == board.gameBoard[0, 2])
            {
                gameOver = true;
            }
            else if (turnCounter == 10)
            {
                gameOver = true;
                isDraw = true;
            }
        }
        */

    }
}
