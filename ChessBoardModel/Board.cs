using System;
using System.Collections.Generic;
using System.Text;

namespace ChessBoardModel
{
    public class Board
    {
        //size of board, usually 8x8
        public int Size { get; set; }

        public Cell[,] theGrid { get; set; }

        //constructor
        public Board(int s)
        {
            //initial board size s
            Size = s;

            //cretae a new 2D array of Cells
            theGrid = new Cell[Size, Size];

            //fill 2D array with new Cells with unique x and y coordinates
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    theGrid[i, j] = new Cell(i, j);
                }
            }
        }

        public void MarkNextLegalMoves(Cell currentCell, string chessPiece)
        {
            //step 1 - clear all previous legal movies
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    theGrid[i, j].LegalNextMove = false;
                    theGrid[i, j].CurrentlyOccupied = false;
                }
            }

            //step 2 - find all legal moves and mark the cells as 'legal'
            switch(chessPiece)
            {
                case "Knight":
                    if(isSafe(currentCell.RowNumber + 2, currentCell.ColumnNumber + 1))
                        theGrid[currentCell.RowNumber + 2, currentCell.ColumnNumber + 1].LegalNextMove = true;
                    if(isSafe(currentCell.RowNumber + 2, currentCell.ColumnNumber - 1))
                        theGrid[currentCell.RowNumber + 2, currentCell.ColumnNumber - 1].LegalNextMove = true;
                    if(isSafe(currentCell.RowNumber - 2, currentCell.ColumnNumber + 1))
                        theGrid[currentCell.RowNumber - 2, currentCell.ColumnNumber + 1].LegalNextMove = true;
                    if(isSafe(currentCell.RowNumber - 2, currentCell.ColumnNumber - 1))
                        theGrid[currentCell.RowNumber - 2, currentCell.ColumnNumber - 1].LegalNextMove = true;
                    if(isSafe(currentCell.RowNumber + 1, currentCell.ColumnNumber + 2))
                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber + 2].LegalNextMove = true;
                    if(isSafe(currentCell.RowNumber + 1, currentCell.ColumnNumber - 2))
                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber - 2].LegalNextMove = true;
                    if(isSafe(currentCell.RowNumber - 1, currentCell.ColumnNumber + 2))
                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber + 2].LegalNextMove = true;
                    if(isSafe(currentCell.RowNumber - 1, currentCell.ColumnNumber - 2))
                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber - 2].LegalNextMove = true;
                    break;

                case "King":
                    if (isSafe(currentCell.RowNumber + 1, currentCell.ColumnNumber + 1))
                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber + 1].LegalNextMove = true;
                    if (isSafe(currentCell.RowNumber + 1, currentCell.ColumnNumber + 0))
                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber + 0].LegalNextMove = true;
                    if (isSafe(currentCell.RowNumber + 1, currentCell.ColumnNumber - 1))
                        theGrid[currentCell.RowNumber + 1, currentCell.ColumnNumber - 1].LegalNextMove = true;
                    if (isSafe(currentCell.RowNumber + 0, currentCell.ColumnNumber - 1))
                        theGrid[currentCell.RowNumber + 0, currentCell.ColumnNumber - 1].LegalNextMove = true;
                    if (isSafe(currentCell.RowNumber + 0, currentCell.ColumnNumber + 1))
                        theGrid[currentCell.RowNumber + 0, currentCell.ColumnNumber + 1].LegalNextMove = true;
                    if (isSafe(currentCell.RowNumber - 1, currentCell.ColumnNumber + 1))
                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber + 1].LegalNextMove = true;
                    if (isSafe(currentCell.RowNumber - 1, currentCell.ColumnNumber + 0))
                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber + 0].LegalNextMove = true;
                    if (isSafe(currentCell.RowNumber - 1, currentCell.ColumnNumber - 1))
                        theGrid[currentCell.RowNumber - 1, currentCell.ColumnNumber - 1].LegalNextMove = true;
                    break;

                case "Rook":
                    for (int i = 1; i <= Size; i++)
                    {
                        if (isSafe(currentCell.RowNumber - i, currentCell.ColumnNumber))
                            theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber].LegalNextMove = true;
                    }
                    for (int i = 0; i < Size; i++)
                    {
                        if (isSafe(currentCell.RowNumber + i, currentCell.ColumnNumber))
                            theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber].LegalNextMove = true;
                    }
                    for (int i = 0; i < Size; i++)
                    {
                        if (isSafe(currentCell.RowNumber, currentCell.ColumnNumber - i))
                            theGrid[currentCell.RowNumber, currentCell.ColumnNumber - i].LegalNextMove = true;
                    }
                    for (int i = 0; i < Size; i++)
                    {
                        if (isSafe(currentCell.RowNumber, currentCell.ColumnNumber + i))
                            theGrid[currentCell.RowNumber, currentCell.ColumnNumber + i].LegalNextMove = true;
                    }

                    break;

                case "Bishop":
                    for (int i = 1; i <= Size; i++)
                    {
                        if (isSafe(currentCell.RowNumber - i, currentCell.ColumnNumber - i))
                            theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber - i].LegalNextMove = true;
                    }
                    for (int i = 0; i < Size; i++)
                    {
                        if (isSafe(currentCell.RowNumber + i, currentCell.ColumnNumber + i))
                            theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber + i].LegalNextMove = true;
                    }
                    for (int i = 0; i < Size; i++)
                    {
                        if (isSafe(currentCell.RowNumber + i, currentCell.ColumnNumber - i))
                            theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber - i].LegalNextMove = true;
                    }
                    for (int i = 0; i < Size; i++)
                    {
                        if (isSafe(currentCell.RowNumber - i, currentCell.ColumnNumber + i))
                            theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber + i].LegalNextMove = true;
                    }
                    break;

                case "Queen":
                    for (int i = 1; i <= Size; i++)
                    {
                        if (isSafe(currentCell.RowNumber - i, currentCell.ColumnNumber))
                            theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber].LegalNextMove = true;
                    }
                    for (int i = 0; i < Size; i++)
                    {
                        if (isSafe(currentCell.RowNumber + i, currentCell.ColumnNumber))
                            theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber].LegalNextMove = true;
                    }
                    for (int i = 0; i < Size; i++)
                    {
                        if (isSafe(currentCell.RowNumber, currentCell.ColumnNumber - i))
                            theGrid[currentCell.RowNumber, currentCell.ColumnNumber - i].LegalNextMove = true;
                    }
                    for (int i = 0; i < Size; i++)
                    {
                        if (isSafe(currentCell.RowNumber, currentCell.ColumnNumber + i))
                            theGrid[currentCell.RowNumber, currentCell.ColumnNumber + i].LegalNextMove = true;
                    }
                    for (int i = 1; i <= Size; i++)
                    {
                        if (isSafe(currentCell.RowNumber - i, currentCell.ColumnNumber - i))
                            theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber - i].LegalNextMove = true;
                    }
                    for (int i = 0; i < Size; i++)
                    {
                        if (isSafe(currentCell.RowNumber + i, currentCell.ColumnNumber + i))
                            theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber + i].LegalNextMove = true;
                    }
                    for (int i = 0; i < Size; i++)
                    {
                        if (isSafe(currentCell.RowNumber + i, currentCell.ColumnNumber - i))
                            theGrid[currentCell.RowNumber + i, currentCell.ColumnNumber - i].LegalNextMove = true;
                    }
                    for (int i = 0; i < Size; i++)
                    {
                        if (isSafe(currentCell.RowNumber - i, currentCell.ColumnNumber + i))
                            theGrid[currentCell.RowNumber - i, currentCell.ColumnNumber + i].LegalNextMove = true;
                    }
                    break;

                default:
                    break;



            }
            theGrid[currentCell.RowNumber, currentCell.ColumnNumber].CurrentlyOccupied = true;
        }

        private bool isSafe(int rownum, int colnum)
        {
            if(0 <= rownum && rownum < Size)
            {
                if(0 <= colnum && colnum < Size)
                {
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }
        }
    }    
}
