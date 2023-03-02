using System;

namespace TicTacToe
{
    public class Program
    {
        public static void Main()
        {
            TicTacToe Program = new TicTacToe();


            string[,] gameBoard = { { "1", "2", "3" }, { "4", "5", "6" }, { "7", "8", "9" } };

            foreach(string num in gameBoard)
            {
            Console.Write(num); 

            }


            Program.TicTacGo();

        }
    }
}
