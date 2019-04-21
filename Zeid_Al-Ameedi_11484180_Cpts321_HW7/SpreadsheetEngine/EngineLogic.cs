/***************
 * Zeid Al-Ameedi
 * 03/04/2019
 * CptS321 HW - Spreadsheet application
 * 
****************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace CptS321
{
    /// <summary>
    /// Abstract class cell that will be accompanied in every spreadsheet's cell
    /// </summary>
    public abstract class Cell : INotifyPropertyChanged
    {
        /// <summary>
        /// Constructor for the cell object sets row/cols
        /// </summary>
        public Cell(int row, char col)
        {
            rowIndex = row;
            columnIndex = col;
        }

        private readonly int rowIndex;

        /// <summary>
        /// Property for the row field.
        /// </summary>
        public int RowIndex
        {
            get { return rowIndex; }
        }

        private readonly char columnIndex;

        /// <summary>
        /// Property for the column field.
        /// </summary>
        public char ColumnIndex
        {
            get { return columnIndex; }
        }

        protected string text = string.Empty;

        /// <summary>
        /// Sets the text field. While notifying of any property changed.
        /// </summary>
        public string Text
        {
            get { return text; }
            set
            {
                if (text == value)
                { return; }
                
                text = value;
                OnPropertyChanged("Text");
                
            }
        }

        protected string value;

        /// <summary>
        /// Property for the value data field.
        /// </summary>
        public string Value
        {
            get { return value; }
        }

        private uint bgcolor = 4294967295; 

        /// <summary>
        /// Background color method that sets a new color for BG
        /// while at the same time notifying the change.
        /// </summary>
        public uint BGColor
        {
            get { return bgcolor; }
            set
            {
                if (value != bgcolor)
                {
                    bgcolor = value;

                    OnPropertyChanged("BGColor");
                }
            }
        }

        /// <summary>
        /// Quick clear method that resets a BG to white's code
        /// </summary>
        public void Clear()
        {
            Text = string.Empty;
            BGColor = 4294967295;
        }

        /// <summary>
        /// Property for each cell found within the spreadsheet
        /// </summary>
        /// <param name="r">row</param>
        /// <param name="c">column</param>
        /// <returns></returns>
        public string GetCellName()
        {
            string cellname = ColumnIndex.ToString() + RowIndex.ToString();

            return cellname;
        }


        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Here is where each cell that's changed essentially has a delegate that notifies its respective event has changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        
        #endregion
    }

   
}
