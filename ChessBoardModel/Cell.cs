using System;
using System.Collections.Generic;
using System.Text;

namespace ChessBoardModel
{
    class Cell
    {
        public int RowNumber { get; set; }
        public int ColumnNumber { get; set; }
        public bool CurrentlyOccupied { get; set; }
        public bool LegalNextMove { get; set; }
    }
}
