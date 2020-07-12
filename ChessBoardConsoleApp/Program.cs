using ChessBoardModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChessBoardConsoleApp
{
    class Program
    {
        static Board myBoard = new Board(8);

        static void Main(string[] args)
        {
            //show the empty chess board
            printBoard(myBoard);

            //ask x and y coordinates

            //calculate all legal moves 

            //print the chess board. x for occupied piece. + for legal move. . for empty

            //wait for another key press to exit
            Console.ReadLine();
        }

        private static void printBoard(Board myBoard)
        {
            //print the chess board to console.X for piecce location,. +  for legal moves
            for (int i = 0; i < myBoard.Size; i++)
            {
                for (int j = 0; j < myBoard.Size; j++)
                {
                    Cell c = myBoard.theGrid[i, j];

                    if (c.CurrentlyOccupied == true)
                    {
                        Console.Write("X");
                    }
                    else if(c.LegalNextMove == true)
                    {
                        Console.Write("+");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine("========");
        }
    }
}
