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
            Cell currentCell = setCurrentCell();
            currentCell.CurrentlyOccupied = true;


            //calculate all legal moves 
            myBoard.MarkNextLegalMoves(currentCell, "Queen");

            //print the chess board. x for occupied piece. + for legal move. . for empty
            printBoard(myBoard);

            //wait for another key press to exit
            Console.ReadLine();
        }

        private static Cell setCurrentCell()
        {
            int currentRow, currentColumn;
            //get x and y coordinates from user then return cell location
            while(true)
            {
                try
                {
                    Console.WriteLine("Enter the current row number (0-7): ");
                    try
                    {
                        currentRow = int.Parse(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        continue;                        
                    }
                    
                    if (0 <= currentRow && currentRow < 8)
                        break;
                    else
                        continue;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid input: " + e.Message);
                    continue;
                }
            }
            
            while(true)
            {
                try
                {
                    Console.WriteLine("Enter the current column number (0-7): ");
                    try
                    {
                        currentColumn = int.Parse(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                    if (0 <= currentColumn && currentColumn < 8)
                        break;
                    else
                        continue;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid input: " + e.Message);
                    continue;
                }
            }

            

            return myBoard.theGrid[currentRow, currentColumn];
        }

        private static void printBoard(Board myBoard)
        {
            //print the chess board to console.X for piecce location,. +  for legal moves
            for (int i = 0; i < myBoard.Size; i++)
            {
                Console.WriteLine("+---+---+---+---+---+---+---+---+");
                for (int j = 0; j < myBoard.Size; j++)
                {
                    Cell c = myBoard.theGrid[i, j];
                    Console.Write("| ");

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
                    Console.Write(" ");
                }
                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("+---+---+---+---+---+---+---+---+");
        }
    }
}
