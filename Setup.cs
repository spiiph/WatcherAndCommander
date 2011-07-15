using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FileSystemsWatcherTest
{
    public partial class SetupForm : Form
    {
        public string CommanderName;
        public string Filter;
        public string WorkingDirectory;
        public List<string> Commands;
        public List<string> Paths;

        private string[] mFilters = {
            "\\.(c|h|cpp|hpp)$"
        };

        public SetupForm()
        {
            CommanderName = "";
            Filter = "";
            WorkingDirectory = "";
            Commands = new List<string>();
            Paths = new List<string>();
            InitializeComponent();
        }

        public SetupForm(Commander c)
        {
            CommanderName = c.Name;
            Filter = c.Filter;
            WorkingDirectory = c.WorkingDirectory;
            Commands = c.Commands;
            Paths = c.Paths;
            InitializeComponent();
        }

        private void pathAddButton_Click(object sender, EventArgs e)
        {
            if (pathBrowser.ShowDialog() == DialogResult.OK)
            {
                pathsWindow.Items.Add(pathBrowser.SelectedPath);
            }
        }

        private void pathDeleteButton_Click(object sender, EventArgs e)
        {
            while (pathsWindow.SelectedItems.Count > 0)
            {
                pathsWindow.Items.Remove(pathsWindow.SelectedItem);
            }
        }

        private void SetupForm_Load(object sender, EventArgs e)
        {
            nameBox.Text = CommanderName;
            foreach (string s in mFilters)
            {
                filtersBox.Items.Add(s);
            }
            filtersBox.Text = Filter;
            directoryBox.Text = WorkingDirectory;
            commandersWindow.Text = string.Join(Environment.NewLine,
                                                Commands.ToArray());
            foreach (string s in Paths)
            {
                pathsWindow.Items.Add(s);
            }
        }

        private void SetupForm_FormClosed(object sender,
                                          FormClosedEventArgs e)
        {
            CommanderName = nameBox.Text.Trim();
            Filter = filtersBox.Text.Trim();
            WorkingDirectory = directoryBox.Text.Trim();
            Commands = new List<string>(commandersWindow.Text.Split(
                            new string[] {Environment.NewLine},
                            StringSplitOptions.RemoveEmptyEntries));
            Paths.Clear();
            foreach (string s in pathsWindow.Items)
            {
                Paths.Add(s);
            }
        }

        private void SetupForm_FormClosing(object sender,
                                           FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK && nameBox.Text.Trim() == "")
            {
                MessageBox.Show("You must enter a name for the commander.");
                e.Cancel = true;
            }
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            directoryBrowser.SelectedPath = directoryBox.Text;
            if (directoryBrowser.ShowDialog() == DialogResult.OK)
            {
                directoryBox.Text = directoryBrowser.SelectedPath;
            }
        }
    }
}
