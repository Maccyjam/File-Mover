using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace File_Mover
{
    public partial class MainForm : Form
    {
        const string XML_FILE_NAME = "fileLocationData.xml";
        string[] filesToMove;
        List<XmlGroup> fileGroups; // Used for storing Comment and ID of groups of file movements.

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
            if (!File.Exists(XML_FILE_NAME))
            {
                XDocument newDoc = new XDocument();
                newDoc.Add(new XElement("FileLocations"));
                newDoc.Save(XML_FILE_NAME);
            }
            
            XDocument loadedXml = XDocument.Load(XML_FILE_NAME);

            // Initialise the list of our structure which we populate with values from the XML file.
            fileGroups = new List<XmlGroup>();

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
            XDocument xmlDoc = XDocument.Load(XML_FILE_NAME);

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

            xmlDoc.Save(XML_FILE_NAME);
            loadXML();
        }

        private void revertButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to revert this file group?", "Revert?", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                if (revertListBox.SelectedValue != null)
                {
                    XDocument xmlDoc = XDocument.Load(XML_FILE_NAME);
                    // This mess of a line finds the group element that has the ID of the file movement that has been selected in the ListBox.
                    XElement selectedGroup = xmlDoc.Element("FileLocations").Elements("group").Where(group => group.Attribute("id").Value == revertListBox.SelectedValue.ToString()).First();
                    int count = 0;

                    foreach (XElement fileEl in selectedGroup.Elements("file"))
                    {
                        try
                        {
                            File.Move(fileEl.Element("to").Value, fileEl.Element("from").Value); // We're reverting a file movement so we go from 'to' to 'from'. :D
                        }
                        catch (FileNotFoundException ex)
                        {
                            MessageBox.Show("File " + ex.FileName + " does not exist!");
                            break;
                        }
                        count += 1;
                    }

                    DeleteGroup(); // Delete the group as we've just reverted it so it's not much use to us now.

                    MessageBox.Show(count + " files reverted.");
                }
                else
                {
                    MessageBox.Show("Please select a file group to revert from the box.");
                }
            }
        }

        private void revertDeleteButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this file group?", "Delete?", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                DeleteGroup();
            }
        }

        private void DeleteGroup()
        {
            XDocument xmlDoc = XDocument.Load(XML_FILE_NAME);
            // Borrowed from above!
            XElement selectedGroup = xmlDoc.Element("FileLocations").Elements("group").Where(group => group.Attribute("id").Value == revertListBox.SelectedValue.ToString()).First();

            MessageBox.Show(selectedGroup.ToString());

            selectedGroup.Remove();
            xmlDoc.Save(XML_FILE_NAME);

            loadXML(); // Refresh the ListBox.
        }

    }
}
