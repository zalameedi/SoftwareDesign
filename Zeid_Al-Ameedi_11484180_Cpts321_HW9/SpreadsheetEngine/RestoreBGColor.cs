/****************
 * Zeid Al-Ameedi
 * 04/01/2019
 * CptS321 - Spreadsheet application
 * 
****************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CptS321;

namespace SpreadsheetEngine
{
    public class RestoreBGColor :IUndoRedoCommand
    {
        private Cell cell;
        private uint color;

        /// <summary>
        /// Restores the background color, updating it to the assigned color
        /// </summary>
        /// <param name="updateCell"></param>
        /// <param name="updateColor"></param>
        public RestoreBGColor(Cell updateCell, uint updateColor)
        {
            cell = updateCell;
            color = updateColor;
        }

        /// <summary>
        /// Undo/Redo command that searches for the string depending on your location and button clicked.
        /// </summary>
        /// <param name="sheet"></param>
        /// <returns></returns>
        public IUndoRedoCommand Execute(Spreadsheet sheet)
        {
            string cellName = this.cell.ColumnIndex.ToString() + this.cell.RowIndex.ToString();
            uint currentColor = cell.BGColor;
            cell.BGColor = color;
            return new RestoreBGColor(cell, currentColor);

        }

    }
}
