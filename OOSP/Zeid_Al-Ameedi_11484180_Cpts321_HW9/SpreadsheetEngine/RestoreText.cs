/****************
 * Zeid Al-Ameedi
 * 04/01/2019
 * CptS321 - Spreadsheet application
 * 
****************/

using CptS321;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpreadsheetEngine
{
    public class RestoreText : IUndoRedoCommand
    {
        private Cell cell;
        private string text;

        /// <summary>
        /// The restore portion but for text, so this resets the past text that the individual used.
        /// </summary>
        /// <param name="c"></param>
        /// <param name="t"></param>
        public RestoreText(Cell c, string t)
        {
            cell = c;
            text = t;
        }

        /// <summary>
        /// Undo/Redo command for the text. 
        /// </summary>
        /// <param name="spreadsheet"></param>
        /// <returns></returns>
        public IUndoRedoCommand Execute(Spreadsheet spreadsheet)
        {
            string cellName = this.cell.ColumnIndex.ToString() + this.cell.RowIndex.ToString();
            Cell cell = spreadsheet.GetCell(cellName);
            string currentText = cell.Text;
            cell.Text = this.text;
            return new RestoreText(cell, currentText);
        }
    }
}
