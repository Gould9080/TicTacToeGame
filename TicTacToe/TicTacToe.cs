using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Threading;

namespace TicTacToe
{
    public class TicTacToe
    {
        /*

    -----------------
    | 0,0  0,1  0,2 |
    |               |
    | 1,0  1,1  1,2 |
    |               |
    | 2,0  2,1  2,2 |
    -----------------

     */
        public void TicTacGo()
        {
            // Set starting values, variables
            string[,] gameBoard = { { "1", "2", "3" }, { "4", "5", "6" }, { "7", "8", "9" } };
            int positionX = 0;
            int positionY = 0;
            int choice;
            int player = 1;
            int turnCounter = 1;
            string xOrO = "X";
            bool gameOver = false;
            bool isDraw = false;

            // Methods

            void updatePlayer()
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

            void setPosition(int pos)
            {
                switch (pos)
                {
                    case 1:
                        positionX = 0;
                        positionY = 0;
                        break;
                    case 2:
                        positionX = 0;
                        positionY = 1;
                        break;
                    case 3:
                        positionX = 0;
                        positionY = 2;
                        break;
                    case 4:
                        positionX = 1;
                        positionY = 0;
                        break;
                    case 5:
                        positionX = 1;
                        positionY = 1;
                        break;
                    case 6:
                        positionX = 1;
                        positionY = 2;
                        break;
                    case 7:
                        positionX = 2;
                        positionY = 0;
                        break;
                    case 8:
                        positionX = 2;
                        positionY = 1;
                        break;
                    case 9:
                        positionX = 2;
                        positionY = 2;
                        break;
                }
            }

            void choiceScreen()
            {
                Console.Clear();
                Console.WriteLine($"Player {player} is {xOrO}. Please choose your position");
                Console.WriteLine();
                //Console.WriteLine($"turn counter: {turnCounter}");
                Thread.Sleep(200);
                printBoard();
                choice = int.Parse(Console.ReadLine());
            }

            void printBoard()
            {
                Console.WriteLine();
                Console.WriteLine(" -----------------------------");
                Console.WriteLine("|         |         |         |");
                Console.WriteLine($"|    {gameBoard[0, 0]}    |    {gameBoard[0, 1]}    |    {gameBoard[0, 2]}    |");
                Console.WriteLine("|         |         |         |");
                Console.WriteLine(" -----------------------------");
                Console.WriteLine("|         |         |         |");
                Console.WriteLine($"|    {gameBoard[1, 0]}    |    {gameBoard[1, 1]}    |    {gameBoard[1, 2]}    |");
                Console.WriteLine("|         |         |         |");
                Console.WriteLine(" ------------------------------");
                Console.WriteLine("|         |         |         |");
                Console.WriteLine($"|    {gameBoard[2, 0]}    |    {gameBoard[2, 1]}    |    {gameBoard[2, 2]}    |");
                Console.WriteLine("|         |         |         |");
                Console.WriteLine(" -----------------------------");
                Console.WriteLine();
            }


            // Order of methods

            /*
            choiceScreen();
            choice = Int32.Parse(Console.ReadLine());
            setPosition(choice);
            gameBoard[positionX, positionY] = xOrO;

            choiceScreen();
            */


            // win conditions

            void checkIfGameOver()
            {
                if (gameBoard[0, 0] == gameBoard[0, 1] && gameBoard[0, 1] == gameBoard[0, 2])
                {
                    gameOver = true;
                }
                else if (gameBoard[1, 0] == gameBoard[1, 1] && gameBoard[1, 1] == gameBoard[1, 2])
                {
                    gameOver = true;
                }
                else if (gameBoard[2, 0] == gameBoard[2, 1] && gameBoard[2, 1] == gameBoard[2, 2])
                {
                    gameOver = true;
                }
                else if (gameBoard[0, 0] == gameBoard[1, 0] && gameBoard[1, 0] == gameBoard[2, 0])
                {
                    gameOver = true;
                }
                else if (gameBoard[0, 1] == gameBoard[1, 1] && gameBoard[1, 1] == gameBoard[2, 1])
                {
                    gameOver = true;
                }
                else if (gameBoard[0, 2] == gameBoard[1, 2] && gameBoard[1, 2] == gameBoard[2, 2])
                {
                    gameOver = true;
                }
                else if (gameBoard[0, 0] == gameBoard[1, 1] && gameBoard[1, 1] == gameBoard[2, 2])
                {
                    gameOver = true;
                }
                else if (gameBoard[2, 0] == gameBoard[1, 1] && gameBoard[1, 1] == gameBoard[0, 2])
                {
                    gameOver = true;
                }
                else if (turnCounter == 10)
                {
                    gameOver = true;
                    isDraw = true;
                }
            }


            // while loop and end game

            while (!gameOver)
            {
                choiceScreen();
                //choice = int.Parse(Console.ReadLine());
                setPosition(choice);
                gameBoard[positionX, positionY] = xOrO;
                turnCounter++;
                updatePlayer();
                checkIfGameOver();
            }

            Console.Clear();
            printBoard();
            turnCounter++;
            updatePlayer();
            //Console.WriteLine($"turn counter: {turnCounter}");

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
    }
}
