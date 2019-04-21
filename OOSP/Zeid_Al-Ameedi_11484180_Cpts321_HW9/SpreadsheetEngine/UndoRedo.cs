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

namespace SpreadsheetEngine
{
    /// <summary>
    /// Interface to be used for our undo/redo commands (Text, bg)
    /// </summary>
    public interface IUndoRedoCommand
    {
        IUndoRedoCommand Execute(Spreadsheet spreadsheet);
    }

    /// <summary>
    /// Class for undo/redo commands.
    /// uses stacks to keep track of changes that way we can pop to go back and simply go via to get redo
    /// </summary>
    public class UndoRedo
    {
        private Stack<UndoRedoCollection> undoStack = new Stack<UndoRedoCollection>();
        private Stack<UndoRedoCollection> redoStack = new Stack<UndoRedoCollection>();

        /// <summary>
        /// Undo as long as stack isn't empty
        /// </summary>
        public bool CanUndo
        {
            get { return undoStack.Count != 0; }
        }

        /// <summary>
        /// Redo as long as stack isn't empty
        /// </summary>
        public bool CanRedo
        {
            get { return redoStack.Count != 0; }
        }

        /// <summary>
        /// The undo stack is inserted in with the new undo to operate on
        /// </summary>
        /// <param name="undos"></param>
        public void AddUndo(UndoRedoCollection undos)
        {
            undoStack.Push(undos);
            redoStack.Clear();
        }

        /// <summary>
        /// Execute the undo right here, 
        /// </summary>
        /// <param name="sheet"></param>
        public void Undo(Spreadsheet sheet)
        {
            UndoRedoCollection commands = undoStack.Pop();
            redoStack.Push(commands.Restore(sheet));
        }

        /// <summary>
        /// Execute the redo right here, 
        /// </summary>
        /// <param name="sheet"></param>
        public void Redo(Spreadsheet sheet)
        {
            UndoRedoCollection commands = redoStack.Pop();
            undoStack.Push(commands.Restore(sheet));
        }

        /// <summary>
        /// Safety property to determine if an undo is compatible with the op.
        /// </summary>
        public string CheckUndo
        {
            get
            {
                if (CanUndo)
                {
                    return undoStack.Peek().title;
                }
                return string.Empty;
            }
        }

        /// <summary>
        /// Safety property to determine if an redo is compatible with the op.
        /// </summary>
        public string CheckRedo
        {
            get
            {
                if (CanRedo)
                {
                    return redoStack.Peek().title;
                }
                return string.Empty;
            }
        }

        /// <summary>
        /// Clears stacks
        /// </summary>
        public void ClearStacks()
        {
            redoStack.Clear();
            undoStack.Clear();
        }     
    }

    /// <summary>
    /// Undo/redo collection that contains the logic for object [commands]
    /// </summary>
    public class UndoRedoCollection
    {
        private IUndoRedoCommand[] commandObjects;
        public string title;

        /// <summary>
        /// Constructor for the command objects
        /// </summary>
        public UndoRedoCollection()
        { }

        /// <summary>
        /// UndoRedo collection that contains the name of the titles and assigns them respectively to commandobj
        /// </summary>
        /// <param name="commands"></param>
        /// <param name="title"></param>
        public UndoRedoCollection(IUndoRedoCommand[] commands, string title)
        {
            commandObjects = commands;
            this.title = title;
        }

        /// <summary>
        /// UndoRedo collection that contains the name of the titles and assigns them respectively to LISTS
        /// </summary>
        /// <param name="commands"></param>
        /// <param name="title"></param>
        public UndoRedoCollection(List<IUndoRedoCommand> commands, string title)
        {
            commandObjects = commands.ToArray();
            this.title = title;
        }

        /// <summary>
        /// Restore function to give back the restored command
        /// </summary>
        /// <param name="spreadsheet"></param>
        /// <returns></returns>
        public UndoRedoCollection Restore(Spreadsheet spreadsheet)
        {
            List<IUndoRedoCommand> commandList = new List<IUndoRedoCommand>();
            foreach (IUndoRedoCommand command in commandObjects)
            {
                commandList.Add(command.Execute(spreadsheet));
            }
            return new UndoRedoCollection(commandList.ToArray(), this.title);
        }

    }
}
