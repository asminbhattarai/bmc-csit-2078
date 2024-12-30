using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace notepad
{
    // Main Form for the Notepad application
    public partial class NotePad : Form
    {
        // Constructor to initialize components
        public NotePad()
        {
            InitializeComponent();
        }

        // Variable to hold the current file name (if any)
        private string FileName = string.Empty;

        // Event handler for creating a new document
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Clear the filename and the text in the richTextBox to start fresh
            this.FileName = string.Empty;
            richTextBox.Clear();
        }

        // Event handler for opening an existing file
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create an OpenFileDialog for selecting a file
            OpenFileDialog ofd = new OpenFileDialog();

            // Set file filter for .txt files and all files
            ofd.Filter = "Text Files (*.txt) | *.txt| All Files (*.*) | *.*";
            ofd.Title = "Open File";
            ofd.FileName = "";  // Initially, no file is selected

            // Show the open file dialog and proceed if a file is selected
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // Store the selected file's name
                this.FileName = ofd.FileName;

                // Update the form's title with the file's name (without extension)
                this.Text = string.Format("{0}", Path.GetFileNameWithoutExtension(ofd.FileName));

                // Read the content of the file and display it in the richTextBox
                StreamReader sr = new StreamReader(ofd.FileName);
                richTextBox.Text = sr.ReadToEnd();
                sr.Close();

                // Move the cursor to the end of the text in the richTextBox
                richTextBox.SelectionStart = richTextBox.Text.Length;
                richTextBox.SelectionLength = 0;
                richTextBox.ScrollToCaret();
                richTextBox.Focus(); // Focus back on the richTextBox
            }
        }

        // Event handler for saving the current document
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // If the current document doesn't have a file name, prompt for a 'Save As' dialog
            if (string.IsNullOrEmpty(this.FileName))
            {
                saveAsToolStripMenuItem_Click(sender, e);
            }
            else
            {
                // Write the content of the richTextBox to the existing file
                StreamWriter sw = new StreamWriter(this.FileName);
                sw.Write(richTextBox.Text);
                sw.Close();
            }
        }

        // Event handler for saving the document with a new file name (Save As)
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create a SaveFileDialog for saving the file
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); // Default directory is My Documents
            sfd.Filter = "Text Files (*.txt) | *.txt| All Files (*.*) | *.*"; // Filter to select text files or all files
            sfd.Title = "Save As"; // Set the dialog title
            sfd.FileName = "Untitled"; // Default file name when saving

            // Show the save file dialog and proceed if a file name is chosen
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                // Store the new file's name
                this.FileName = sfd.FileName;

                // Write the content of the richTextBox to the new file
                StreamWriter sw = new StreamWriter(sfd.FileName);
                sw.Write(richTextBox.Text);
                sw.Close();
            }
        }
    }
}