/***************
 * Zeid Al-Ameedi
 * 02/22/2019
 * CptS321 HW4 - Spreadsheet application
 * 
****************/

using System;
using System.ComponentModel;

namespace CptS321
{
    public abstract class Cell : INotifyPropertyChanged
    {
        protected int rowIndex, columnIndex;
        protected string text;
        protected string value;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        /// <summary>
        /// Constructor for the cell object, no implementation required.
        /// </summary>
        public Cell() 
        {
            
        }
        /// <summary>
        /// Property for the row field.
        /// </summary>
        public int getRow 
        {
            get
            {
                return this.rowIndex;
            }
            protected set
            {
                this.rowIndex = value;
            }
        }
        /// <summary>
        /// Property for the column field.
        /// </summary>
        public int getCol 
        {
            get
            {
                return this.columnIndex;
            }
            protected set
            {
                this.columnIndex = value;
            }
        }
        /// <summary>
        /// Sets the text field. While notifying of any property changed.
        /// </summary>
        public string setText 
        {
            get
            {
                return text;
            }
            set
            {
                if (value == text)
                {
                    return; 
                }
                else
                {
                    text = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Text"));
                }
            }
        }
        /// <summary>
        /// Property for the value data field.
        /// </summary>
        public string Value 
        {
            get
            {
                return this.value;
            }
            protected internal set
            {
                if (value == this.value)
                {
                    return;
                }
                else
                {
                    this.value = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Value"));
                }
            }
        }
    }
    /// <summary>
    /// Inhereits from the cell, to indicate cells that are used. Imagine a setter once edit mode is complete.
    /// </summary>
    public class UsedCell : Cell
    {
        public UsedCell(int row, int col, string txt)
        {
            rowIndex = row;
            columnIndex = col;
            this.text = txt;
            value = txt;
        }
    }
    /// <summary>
    /// Spreadsheet class essentially controls the creation of our excel sheet.
    /// </summary>
    public class spreadsheet
    {
        private int rows, columns;
        private Cell[,] ss;
        public event PropertyChangedEventHandler CellPropertyChanged;

        public spreadsheet(int row, int col)
        {
            this.rows = row;
            this.columns = col;
            ss = new Cell[row, col];
            for (int r = 0; r < row; r++)
            {
                for (int c = 0; c < col; c++)
                {
                    ss[r, c] = new UsedCell(r, c, "");
                    ss[r, c].PropertyChanged += SPropertyChanged;
                }
            }
        }
        /// <summary>
        /// Property for each cell found within the spreadsheet
        /// </summary>
        /// <param name="r">row</param>
        /// <param name="c">column</param>
        /// <returns></returns>
        public Cell GetCell(int r, int c)
        {
            if (r > ss.GetLength(0) || c > ss.GetLength(1))
            {
                return null;
            }
            else
            {
                return ss[r, c];
            }
        }
        /// <summary>
        /// Property for the count of columns.
        /// </summary>
        public int ColumnCount
        {
            get
            {
                return rows;
            }
        }
        /// <summary>
        /// Property for the count of rows.
        /// </summary>
        public int RowCount
        {
            get
            {
                return columns;
            }
        }
        /// <summary>
        /// Here is where each cell that's changed essentially has a delegate that notifies its respective event has changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "Text")
            {
                if(!((Cell)sender).setText.StartsWith("="))
                {
                    ((Cell)sender).Value = ((Cell)sender).setText;
                }
                else
                {
                    string equation = ((Cell)sender).setText.Substring(1);
                    int column = Convert.ToInt16(equation[0]) - 'A';
                    int row = Convert.ToInt16(equation.Substring(1)) - 1;
                    ((Cell)sender).Value = (GetCell(row, column)).Value;
                }
            }
            CellPropertyChanged?.Invoke(sender, new PropertyChangedEventArgs("Value"));
        }

        /// <summary>
        /// The random section where each demo run produces 50 slots with random literal string, and respective B cell locations
        /// </summary>
        public void Demo()
        {
            int i = 0;
            Random rand = new Random();

            while (i < 50)
            {
                int rc = rand.Next(0, 25);
                int rr = rand.Next(0, 49);

                Cell x = GetCell(rr, rc);
                x.setText = "CptS 321 is cool!";
                this.ss[rr, rc] = x;
                i++;
            }
            for (i = 0; i < 50; i++)
            {
                this.ss[i, 1].setText = "This is cell B" + (i + 1);
            }
            for (i = 0; i < 50; i++)
            {
                this.ss[i, 0].setText = "=B" + (i + 1);
            }

        }
    }
}
