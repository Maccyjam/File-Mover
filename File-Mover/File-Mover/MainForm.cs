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

namespace File_Mover
{
    public partial class MainForm : Form
    {
        string[] filesToMove;

        public MainForm()
        {
            InitializeComponent();
        }

        private void fileSelectButton_Click(object sender, EventArgs e)
        {
            fileSelector.ShowDialog();
        }

        private void fileSelector_FileOk(object sender, CancelEventArgs e)
        {
            filesToMove = fileSelector.FileNames;
            fileSelectTextBox.Text = "";

            foreach (string file in fileSelector.FileNames)
            {
                fileSelectTextBox.Text += file + ";";
            }
        }

        private void dirSelectButton_Click(object sender, EventArgs e)
        {
            if (dirSelector.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                dirSelectTextBox.Text = dirSelector.SelectedPath;
            }
        }

        private void moveButton_Click(object sender, EventArgs e)
        {
            foreach (string file in filesToMove)
            {
                string fileName = file.Split('\\').Last();
                try
                {
                    File.Move(file, dirSelector.SelectedPath + "\\" + fileName);
                }
                catch (FileNotFoundException ex)
                {
                    MessageBox.Show("File " + ex.FileName + " does not exist! Please reselect files.");
                    break;
                }

            }
        }
    }
}
