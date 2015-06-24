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
using System.Xml;
using System.Xml.Linq;

namespace File_Mover
{
    public partial class MainForm : Form
    {
        string[] filesToMove;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            loadXML();   
        }

        private void loadXML()
        {
            // If the XML file does not yet exist, create it and initalise it with the root element.
            if (!File.Exists("fileLocationData.xml"))
            {
                XDocument newDoc = new XDocument();
                newDoc.Add(new XElement("FileLocations"));
                newDoc.Save("fileLocationData.xml");
            }
            
            XDocument loadedXml = XDocument.Load("fileLocationData.xml");

            // Create a list of our structure which we populate with values from the XML file.
            List<XmlGroup> fileGroups = new List<XmlGroup>();

            foreach (XElement groupEl in loadedXml.Element("FileLocations").Elements("group"))
            {
                fileGroups.Add(new XmlGroup(groupEl.Attribute("comment").Value, groupEl.Attribute("id").Value));
            }

            // Set the ListBox to use our List as a data source and set the 'comment' attribute to be displayed
            // but the 'id' attribute to be used as the value.
            revertListBox.DataSource = fileGroups;
            revertListBox.DisplayMember = "comment";
            revertListBox.ValueMember = "id";
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
            XDocument xmlDoc = XDocument.Load("fileLocationData.xml");

            XElement rootEl = xmlDoc.Element("FileLocations");

            rootEl.Add(new XElement("group"));
            XElement groupEl = rootEl.Elements("group").Last(); // The one we just added will be last, so we want that.
            groupEl.Add(new XAttribute("comment", commentTextBox.Text)); // Add a comment for differentiating between groups.
            groupEl.Add(new XAttribute("id", Guid.NewGuid().ToString())); // Add a unique identifier for use when reverting.

            foreach (string file in filesToMove)
            {
                string fileName = file.Split('\\').Last();
                try
                {
                    File.Move(file, dirSelector.SelectedPath + "\\" + fileName);

                    groupEl.Add(new XElement("file", 
                        new XElement("from", file), 
                        new XElement("to", dirSelector.SelectedPath + "\\" + fileName)));
                }
                catch (FileNotFoundException ex)
                {
                    MessageBox.Show("File " + ex.FileName + " does not exist! Please reselect files.");
                    break;
                }

            }

            xmlDoc.Save("fileLocationData.xml");
        }

        private void revertButton_Click(object sender, EventArgs e)
        {

        }

    }
}
