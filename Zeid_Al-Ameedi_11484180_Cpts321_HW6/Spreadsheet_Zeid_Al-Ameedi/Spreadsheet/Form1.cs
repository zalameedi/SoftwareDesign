using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CptS321;

namespace Spreadsheet
{
    /// <summary>
    /// Form object that holds the template of the spreadsheet in GUI form.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// 50 * 26 rows and columns that create the base of the template.
        /// </summary>
        private spreadsheet basesheet = new spreadsheet(50, 26);

        /// <summary>
        /// Constructor that calls the initialize of the object.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Edits the cells and columns, enters edit mode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            int row = e.RowIndex;
            int column = e.ColumnIndex;
            dataGridView1.Rows[row].Cells[column].Value = (basesheet.GetCell(row, column)).setText;
        }

        /// <summary>
        /// Indicator when the edit mode is over.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            int column = e.ColumnIndex;
            string text = "";
            Cell cell = basesheet.GetCell(row, column);

            try
            {
                text = dataGridView1.Rows[row].Cells[column].Value.ToString();
            }
            catch (NullReferenceException)
            {
                text = "";
            }
            cell.setText = text;

        }

        /// <summary>
        /// Indicates when the property change for every cell is valid.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SCellPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Cell cell = (Cell)sender;
            if (cell != null && e.PropertyName == "Value")
            {
                dataGridView1.Rows[cell.getRow].Cells[cell.getCol].Value = cell.Value;

            }
        }

        /// <summary>
        /// Helper function to load the template of the base. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            basesheet.CellPropertyChanged += SCellPropertyChanged;
            dataGridView1.CellBeginEdit += CellBeginEdit;
            dataGridView1.CellEndEdit += CellEndEdit;
            dataGridView1.Columns.Clear();
            for(char i = 'A'; i <= 'Z'; i++)
            {
                DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                column.Name = i.ToString();
                dataGridView1.Columns.Add(column);
            }
            dataGridView1.Rows.Clear();
            dataGridView1.Rows.Add(50);
            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                row.HeaderCell.Value = (row.Index + 1).ToString();
            }
        }

        /// <summary>
        /// Calls the sample demo method that produces 50 random strings and B-location cells
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            basesheet.Demo();
        }

        /// <summary>
        /// Data grid view for each cell's info.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

