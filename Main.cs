using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Xml;

namespace FileSystemsWatcherTest
{
    public partial class MainForm : Form
    {
        private BindingList<Commander> mCommanders;
        private BindingSource mBinding;

        //////////////////////////////////////////////////
        // Constructor
        public MainForm()
        {
            mCommanders = new BindingList<Commander>();
            mBinding = new BindingSource();
            InitializeComponent();
        }

        //////////////////////////////////////////////////
        // Control event handlers
        private void addPathButton_Click(object sender, EventArgs e)
        {
            SetupForm dlg = new SetupForm();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Commander c = new Commander(dlg.CommanderName,
                                            dlg.Filter,
                                            dlg.WorkingDirectory,
                                            dlg.Commands,
                                            dlg.Paths);
                c.Log += CommanderLog; 
                mBinding.Add(c);
                c.Start();
                WriteXml(mCommanders);
            }
            dlg.Dispose();
        }

        private void deletePathButton_Click(object sender, EventArgs e)
        {
            ArrayList Commanders = new ArrayList(commandersWindow.SelectedItems);
            foreach (Commander c in Commanders)
            {
                c.Stop();
                mBinding.Remove(c);
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (commandersWindow.SelectedItems.Count == 1)
            {
                int index = commandersWindow.SelectedIndex;
                Commander c = mCommanders[index];
                SetupForm dlg = new SetupForm(c);
                c.Stop();
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    c.Shutdown();
                    mBinding.Remove(c);
                    c = new Commander(dlg.CommanderName,
                                      dlg.Filter,
                                      dlg.WorkingDirectory,
                                      dlg.Commands,
                                      dlg.Paths);
                    c.Log += CommanderLog; 
                    mBinding.Insert(index, c);
                    WriteXml(mCommanders);
                }
                c.Start();
                dlg.Dispose();
                commandersWindow.ClearSelected();
                commandersWindow.SelectedIndex = index;
            }
            else
            {
                MessageBox.Show("Select one item to edit.");
            }
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            if (commandersWindow.SelectedItems.Count == 1)
            {
                int index = commandersWindow.SelectedIndex;
                Commander c = new Commander(mCommanders[index]);
                SetupForm dlg = new SetupForm(c);
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    c = new Commander(dlg.CommanderName,
                                      dlg.Filter,
                                      dlg.WorkingDirectory,
                                      dlg.Commands,
                                      dlg.Paths);
                    c.Log += CommanderLog; 
                    mBinding.Add(c);
                    WriteXml(mCommanders);
                    c.Start();
                }
                dlg.Dispose();
                commandersWindow.ClearSelected();
                commandersWindow.SelectedIndex = index;
            }
            else
            {
                MessageBox.Show("Select one item.");
            }
        }

        //////////////////////////////////////////////////
        // Form event handlers
        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadXml(mCommanders);
            mBinding.DataSource = mCommanders;
            commandersWindow.DataSource = mBinding;
            StartCommanders();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopCommanders();
            WriteXml(mCommanders);
        }


        //////////////////////////////////////////////////
        // Commander event handlers
        private void CommanderLog(object source, CommanderLogEventArgs e)
        {
            if (InvokeRequired)
            {
                logWindow.Invoke(new MethodInvoker(delegate {
                               logWindow.Items.Insert(0, e.Message);
                        }));
            }
        }

        private void StartCommanders()
        {
            foreach (Commander c in mBinding)
            {
                c.Start();
            }
        }

        private void StopCommanders()
        {
            foreach (Commander c in mBinding)
            {
                c.Stop();
                c.Shutdown();
            }
        }

        private string GetSettingsFile()
        {
            string folderName = Path.Combine(
                    Environment.GetFolderPath(
                            Environment.SpecialFolder.LocalApplicationData),
                    "WatcherAndCommander");
            if (!Directory.Exists(folderName))
            {
                Directory.CreateDirectory(folderName);
            }
            return Path.Combine(folderName, "settings.xml");
        }

        private void LoadXml(BindingList<Commander> l)
        {
            string fileName = GetSettingsFile();
            XmlDocument xmlDoc = new XmlDocument();
            XmlElement xmlCommanders;

            if (!File.Exists(fileName))
            {
                return;
            }

            xmlDoc.Load(fileName);
            xmlCommanders = xmlDoc["Commanders"];

            foreach (XmlNode xmlCommander in xmlCommanders)
            {
                string name;
                string filter = "";
                string workingDirectory = "";
                List<string> commands = new List<string>();
                List<string> paths = new List<string>();
                Commander c;

                // Read the commander settings into temporary variables
                name = xmlCommander["Name"].InnerText;
                if (xmlCommander["Filter"] != null)
                {
                    filter = xmlCommander["Filter"].InnerText;
                }
                if (xmlCommander["WorkingDirectory"] != null)
                {
                    workingDirectory = xmlCommander["WorkingDirectory"].InnerText;
                }
                if (xmlCommander["Commands"] != null)
                {
                    commands = new List<string>(xmlCommander["Commands"].InnerText.Split(
                                    new string[] {Environment.NewLine},
                                    StringSplitOptions.None));
                }
                if (xmlCommander["Paths"] != null)
                {
                    foreach (XmlNode xmlPath in xmlCommander["Paths"])
                    {
                        paths.Add(xmlPath.InnerText);
                    }
                }

                // Create the new commander and add it to the list
                c = new Commander(name,
                                  filter,
                                  workingDirectory,
                                  commands,
                                  paths);
                c.Log += CommanderLog; 
                mCommanders.Add(c);
            }
        }

        private void WriteXml(BindingList<Commander> l)
        {
            string fileName = GetSettingsFile();
            XmlDocument xmlDoc = new XmlDocument();
            XmlNode xmlDocNode = xmlDoc.CreateXmlDeclaration("1.0",
                                                             "UTF-8",
                                                             null);
            XmlElement xmlCommanders = xmlDoc.CreateElement("Commanders");

            xmlDoc.AppendChild(xmlDocNode);

            foreach (Commander c in mCommanders)
            {
                XmlElement xmlCommander = xmlDoc.CreateElement("Commander");
                XmlElement xmlName = xmlDoc.CreateElement("Name");
                XmlElement xmlFilter = xmlDoc.CreateElement("Filter");
                XmlElement xmlWorkingDirectory = xmlDoc.CreateElement("WorkingDirectory");
                XmlElement xmlCommands = xmlDoc.CreateElement("Commands");
                XmlElement xmlPaths = xmlDoc.CreateElement("Paths");

                // Set the commander name
                xmlName.InnerText = c.Name;
                xmlCommander.AppendChild(xmlName);

                // Set the commander filter
                xmlFilter.InnerText = c.Filter;
                xmlCommander.AppendChild(xmlFilter);

                // Set the commander working directory
                xmlWorkingDirectory.InnerText = c.WorkingDirectory;
                xmlCommander.AppendChild(xmlWorkingDirectory);

                // Set the commander commands as a string separated by
                // linebreaks to preserve command order
                xmlCommands.InnerText = string.Join(Environment.NewLine,
                                                    c.Commands.ToArray());
                xmlCommander.AppendChild(xmlCommands);

                // Set the commander paths
                foreach (string s in c.Paths)
                {
                    XmlElement xmlPath = xmlDoc.CreateElement("Path");
                    xmlPath.InnerText = s;
                    xmlPaths.AppendChild(xmlPath);
                }
                xmlCommander.AppendChild(xmlPaths);

                // Finally append the commander to the list of commanders
                xmlCommanders.AppendChild(xmlCommander);
            }

            // Append the list of commanders to the document
            xmlDoc.AppendChild(xmlCommanders);

            // Save the XML file
            xmlDoc.Save(fileName);
        }

    }
}
