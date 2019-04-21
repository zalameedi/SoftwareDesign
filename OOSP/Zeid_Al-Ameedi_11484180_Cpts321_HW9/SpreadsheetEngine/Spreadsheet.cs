/****************
 * Zeid Al-Ameedi
 * 04/01/2019
 * CptS321 - Spreadsheet application
 * 
****************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using CptS321;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace SpreadsheetEngine
{
    /// <summary>
    /// Spreadsheet class essentially controls the creation of our excel sheet.
    /// </summary>
    public class Spreadsheet
    {
        public Cell[,] cells;
        private Dictionary<string, HashSet<string>> dependencyDict;
        public UndoRedo undoRedo = new UndoRedo();

       /// <summary>
       /// Sets the spreadsheet 50*26 cells
       /// </summary>
       /// <param name="numRows"></param>
       /// <param name="numColumns"></param>
        public Spreadsheet(int numRows, int numColumns) 
        {
            cells = new Cell[numRows, numColumns];
            dependencyDict = new Dictionary<string, HashSet<string>>();
            for (int i = 0; i < numRows; i++)
            {
                for (int c = 0; c < numColumns; c++)
                {
                    char letter =(char)(c + 64);
                    cells[i, c] = new BasicCell(i+1, letter);
                    cells[i, c].PropertyChanged += OnPropertyChanged;
                }
            }

            rowCount = numRows;
            columnCount = numColumns;

        }

        /// <summary>
        /// Used to initialize all cells
        /// </summary>
        private class BasicCell : Cell
        {
            public BasicCell(int row, char col) : base(row, col)
            {

            }
           public void setValue(string newValue)
            {
                value = newValue;
                OnPropertyChanged("Value");
            }
        }

        private int columnCount;
        /// <summary>
        /// Property for the count of columns.
        /// </summary>
        public int ColumnCount
        {
            get { return columnCount; }
            set { columnCount = value; }
        }

        private int rowCount;
        /// <summary>
        /// Property for the count of rows.
        /// </summary>
        public int RowCount
        {
            get { return rowCount; }
            set { rowCount = value; }
        }


        //CellPropertyChanged EventHandler
        public event PropertyChangedEventHandler CellPropertyChanged;

        /// <summary>
        /// Here is where each cell that's changed essentially has a delegate that notifies its respective event has changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Text")
            {
                BasicCell temporary = sender as BasicCell;
                string cellname = temporary.GetCellName();
                DeleteDependency(cellname);
                if (temporary.Text != "" && temporary.Text[0] == '=' && temporary.Text.Length > 1)
                {
                    ExpressionTree tree = new ExpressionTree(temporary.Text.Substring(1));
                    SetDependency(cellname, tree.GetVariables());
                }

                EvaluateCell(sender as Cell);

            }
            else if (e.PropertyName == "BGColor")
            {
                CellPropertyChanged(sender, new PropertyChangedEventArgs("BGColor"));
            }

        }

        /// <summary>
        /// GetCell returns a unique cell based on indices that will work thorugh cells
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <param name="colIndex"></param>
        /// <returns></returns>
        public Cell GetCell(int rowIndex, int colIndex)
        {

            if (cells[rowIndex, colIndex] != null)
            {
                return cells[rowIndex, colIndex];
            }
            else
            {
                return null;
            }
        }

       /// <summary>
       /// Logical function to determine which cell needs to be touched on.
       /// </summary>
       /// <param name="location"></param>
       /// <returns></returns>
       public Cell GetCell(string location)
        {
            char column = location[0];
            int row;
            Cell cell;
            if (!Char.IsLetter(column))
            {
                return null;
            }

           if (!int.TryParse(location.Substring(1), out row))
            {
                return null;
            }

            try
            {

                cell = GetCell(row - 1, column - 64);
            }
            catch (System.Exception ex)
            {
                System.ArgumentException argEx = new System.ArgumentException("Exception has occured. . .", ex);
                throw argEx;
            }
            return cell;
        }

        /// <summary>
        /// Function used to evaluate all the cells.
        /// LOGIC LIVES HERE COULDN'T ENCAPSULATE FURTHER
        /// </summary>
        /// <param name="cell"></param>
        private void EvaluateCell(Cell cell)
        {
            BasicCell evalCell = cell as BasicCell;
            bool error = false;

            if (string.IsNullOrWhiteSpace(evalCell.Text))
            {
                evalCell.setValue("");
                CellPropertyChanged(cell, new PropertyChangedEventArgs("Value"));
            }

            else if (evalCell.Text.Length > 1 && evalCell.Text[0] == '=')
            {
                string text = evalCell.Text.Substring(1);

                ExpressionTree evalTree = new ExpressionTree(text);
                string[] variables = evalTree.GetVariables();

                foreach (string variableName in variables)
                {
                    if (GetCell(variableName) == null)
                    {
                        CellPropertyChanged(cell, new PropertyChangedEventArgs("Value"));
                        error = true;
                        break;
                    }

                    Cell variableCell = GetCell(variableName);
                    double variableValue;

                    if (string.IsNullOrEmpty(variableCell.Value))
                    {
                        evalTree.SetVariable(variableName, 0);
                    }
                    else if (!double.TryParse(variableCell.Value, out variableValue))
                    {
                        evalTree.SetVariable(variableName, 0);
                    }
                    else
                    {
                        evalTree.SetVariable(variableName, variableValue);
                    }

                    string cellToEval = evalCell.ColumnIndex.ToString() + evalCell.RowIndex.ToString();
                    if (variableName == cellToEval)
                    {
                        evalCell.setValue("!(Self Reference)");
                        CellPropertyChanged(cell, new PropertyChangedEventArgs("Value"));

                        error = true;
                        break;
                    }

                }

                if (error)
                {
                    return;
                }

                foreach (string variableName in variables)
                {
                    if (IsCircularReference(variableName, evalCell.GetCellName()))
                    {
                        evalCell.setValue("!(Circular Reference!)");
                        CellPropertyChanged(cell, new PropertyChangedEventArgs("Value"));

                        error = true;
                        break;
                    }
                }

                if (error)
                {
                    return;
                }
                evalCell.setValue(evalTree.Evaluate().ToString());
                CellPropertyChanged(cell, new PropertyChangedEventArgs("Value"));
                
            }

            else
            {
                evalCell.setValue(evalCell.Text);
                CellPropertyChanged(cell, new PropertyChangedEventArgs("Value"));
            }

            string cellName = evalCell.GetCellName();
            if (dependencyDict.ContainsKey(cellName))
            {
                foreach (string dependentCell in dependencyDict[cellName])
                {
                    EvaluateCell(GetCell(dependentCell));
                }
            }

        }


        /// <summary>
        /// Used to set the dependency without our d.dict
        /// This is where we'll check each cell to make sure no reliance occurs
        /// </summary>
        /// <param name="cellName"></param>
        /// <param name="variables"></param>
        private void SetDependency(string cellName, string[] variables)
        {
            foreach (string variableName in variables)
            {
                if (!dependencyDict.ContainsKey(variableName))
                {
                    dependencyDict[variableName] = new HashSet<string>();
                }
                dependencyDict[variableName].Add(cellName);
                
            }
        }

        /// <summary>
        /// Delete dependency simply removes a dependency from the cell that we're currently observing
        /// </summary>
        /// <param name="cellName"></param>
        private void DeleteDependency(string cellName)
        {
            List<string> dependencyList = new List<string>();

            foreach (string key in dependencyDict.Keys)
            {
                if (dependencyDict[key].Contains(cellName))
                {
                    dependencyList.Add(key);
                }
            }
            foreach (string item in dependencyList)
            {
                HashSet<string> removeSet = dependencyDict[item];
                if (removeSet.Contains(cellName))
                {
                    removeSet.Remove(cellName);
                }
            }
        }

        /// <summary>
        /// Save function via XML format
        /// </summary>
        /// <param name="saveFile"></param>
        public void Save(Stream saveFile)
        {
            XmlWriter saveXML = XmlWriter.Create(saveFile);
            saveXML.WriteStartDocument();
            saveXML.WriteStartElement("Spreadsheet");

            foreach  (Cell indCell in cells)
            {
                if (indCell.Text != string.Empty | indCell.BGColor != 4294967295)
                {
                    saveXML.WriteStartElement("cell");
                    string cellname = indCell.GetCellName();
                    saveXML.WriteAttributeString("name", cellname);
                    saveXML.WriteElementString("text", indCell.Text);
                    saveXML.WriteElementString("bgcolor", indCell.BGColor.ToString());
                    saveXML.WriteWhitespace("\n");
                    saveXML.WriteEndElement();
                }
            }

            saveXML.WriteEndElement();
            saveXML.Close();
        }

        /// <summary>
        /// Load function via XML style
        /// </summary>
        /// <param name="loadFile"></param>
        public void Load(Stream loadFile)
        {
            XmlDocument loadedFile = new XmlDocument();
            loadedFile.Load(loadFile);
            XmlNode sheet = loadedFile.SelectSingleNode("Spreadsheet");
            XmlNodeList cellList = sheet.SelectNodes("cell");

            foreach (XmlNode cell in cellList)
            {
                string cellname = cell.Attributes.GetNamedItem("name").Value;
                Cell editCell = GetCell(cellname);
                if (cell.SelectSingleNode("text").InnerText.ToString() != string.Empty)
                {
                    editCell.Text = cell.SelectSingleNode("text").InnerText.ToString();
                }

                if (cell.SelectSingleNode("bgcolor").InnerText.ToString() != "4294967295")
                {
                    uint Color;

                    if (uint.TryParse(cell.SelectSingleNode("bgcolor").InnerText, out Color))
                    {
                        editCell.BGColor = Color;
                    }
                }
            }
        }
        
        /// <summary>
        /// Will Check the Circular reference.
        /// This is when cells are assigned either self or concurrently to each other making a bug
        /// </summary>
        /// <param name="variableName"></param>
        /// <param name="currentCell"></param>
        /// <returns></returns>
        public bool IsCircularReference(string variableName, string currentCell)
        {
            if (variableName == currentCell)
            {
                return true;
            }
            if (!dependencyDict.ContainsKey(currentCell))
            {
                return false;
            }
            foreach (string dependentCell in dependencyDict[currentCell])
            {
                if (IsCircularReference(variableName, dependentCell))
                {
                    return true;
                }
            }
            return false;
        }

    }

    
}
