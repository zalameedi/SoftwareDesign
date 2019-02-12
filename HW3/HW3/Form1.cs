using System.Numerics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic;


//// Zeid Al-Ameedi
//// 11484180

namespace HW3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }


        /// <summary>
        /// Save function that uses the savedialog object to save all info into a file chosen or created into .txt format
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Open File";
            sfd.Filter = "Text Files (*.txt)|*.txt| All Files (*.*)|*.*";
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path = sfd.FileName;
                StreamWriter w = new StreamWriter(File.Create(path));
                w.Write(textBox1.Text);
                w.Dispose();
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Load function. Creates openfiledialog object and 
        /// checks to see if it's clicked. If so lets open up a file
        /// that the user chooses. Then send it to load text it can
        /// be portrayed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpF = new OpenFileDialog();
            if (OpF.ShowDialog() == DialogResult.OK)
            {
                TextReader TR = new StreamReader(File.OpenRead(OpF.FileName));
                LoadText(TR);
            }
        }
        /// <summary>
        /// LoadText function that reads the textwriter to end. 
        /// Put it all in the textbox and then dispose of it when we're done
        /// </summary>
        /// <param name="TR"></param>
        private void LoadText(TextReader TR)
        {
            textBox1.Text = TR.ReadToEnd();
            TR.Dispose();
        }

        /// <summary>
        /// button layout for the first 50 fib numbers. Generates and writes all of them to info
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            FibonacciTextReader FibReader = new FibonacciTextReader(50);
            LoadText(FibReader);
        }

        /// <summary>
        /// button layout for the first 100 fib numbers. Generates and writes all of them to info
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            FibonacciTextReader FibReader = new FibonacciTextReader(100);
            LoadText(FibReader);
        }

        /// <summary>
        /// Save function that uses the savedialog object to save all info into a file chosen or created into .txt format
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();

            saveFile.Title = "Save File";
            saveFile.Filter = "Text Files (*.txt)|*.txt";
            if (saveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamWriter writeToSavedFile = new StreamWriter(File.Create(saveFile.FileName));

                writeToSavedFile.Write(textBox1.Text);
                writeToSavedFile.Dispose();
            }
        }
    }
}
