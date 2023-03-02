using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public class Board
    {
        public string[,] gameBoard = { { "1", "2", "3" }, { "4", "5", "6" }, { "7", "8", "9" } };

        public void PrintActiveBoard()
        {
            Console.WriteLine();
            Console.WriteLine(" -----------------------------");
            Console.WriteLine("|         |         |         |");
            WriteGridValues(0);
            WriteGridLines();
            WriteGridValues(1);
            WriteGridLines();
            WriteGridValues(2);
            Console.WriteLine("|         |         |         |");
            Console.WriteLine(" -----------------------------");
            Console.WriteLine();
        }

        public void WriteGridValues(int row)
        {
            Console.Write("|    ");

            if (gameBoard[row, 0] == "X")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            else if (gameBoard[row, 0] == "O")
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            }
            Console.Write($"{gameBoard[row, 0]}");
            Console.ResetColor();
            Console.Write("    |    ");

            if (gameBoard[row, 1] == "X")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            else if (gameBoard[row, 1] == "O")
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            }
            Console.Write($"{gameBoard[row, 1]}");
            Console.ResetColor();
            Console.Write("    |    ");

            if (gameBoard[row, 2] == "X")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            else if (gameBoard[row, 2] == "O")
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            }
            Console.Write($"{gameBoard[row, 2]}");
            Console.ResetColor();
            Console.WriteLine("    | ");

        }

        public void WriteGridLines()
        {
            Console.WriteLine("|         |         |         |");
            Console.WriteLine(" -----------------------------");
            Console.WriteLine("|         |         |         |");
        }



        /*
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
}*/

    }
}
