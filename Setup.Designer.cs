namespace FileSystemsWatcherTest
{
    partial class SetupForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pathsGroup = new System.Windows.Forms.GroupBox();
            this.pathsWindow = new System.Windows.Forms.ListBox();
            this.pathDeleteButton = new System.Windows.Forms.Button();
            this.pathAddButton = new System.Windows.Forms.Button();
            this.nameGroup = new System.Windows.Forms.GroupBox();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.mainSplit = new System.Windows.Forms.SplitContainer();
            this.commandsGroup = new System.Windows.Forms.GroupBox();
            this.commandersWindow = new System.Windows.Forms.TextBox();
            this.pathBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.filtersGroup = new System.Windows.Forms.GroupBox();
            this.directoryGrop = new System.Windows.Forms.GroupBox();
            this.directoryBox = new System.Windows.Forms.TextBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.directoryBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.filtersBox = new System.Windows.Forms.ComboBox();
            this.pathsGroup.SuspendLayout();
            this.nameGroup.SuspendLayout();
            this.mainSplit.Panel1.SuspendLayout();
            this.mainSplit.Panel2.SuspendLayout();
            this.mainSplit.SuspendLayout();
            this.commandsGroup.SuspendLayout();
            this.filtersGroup.SuspendLayout();
            this.directoryGrop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pathsGroup
            // 
            this.pathsGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pathsGroup.Controls.Add(this.pathsWindow);
            this.pathsGroup.Controls.Add(this.pathDeleteButton);
            this.pathsGroup.Controls.Add(this.pathAddButton);
            this.pathsGroup.Location = new System.Drawing.Point(3, 3);
            this.pathsGroup.Name = "pathsGroup";
            this.pathsGroup.Size = new System.Drawing.Size(336, 172);
            this.pathsGroup.TabIndex = 0;
            this.pathsGroup.TabStop = false;
            this.pathsGroup.Text = "Paths";
            // 
            // pathsWindow
            // 
            this.pathsWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pathsWindow.FormattingEnabled = true;
            this.pathsWindow.Location = new System.Drawing.Point(6, 19);
            this.pathsWindow.Name = "pathsWindow";
            this.pathsWindow.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.pathsWindow.Size = new System.Drawing.Size(324, 108);
            this.pathsWindow.TabIndex = 0;
            // 
            // pathDeleteButton
            // 
            this.pathDeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pathDeleteButton.Location = new System.Drawing.Point(87, 143);
            this.pathDeleteButton.Name = "pathDeleteButton";
            this.pathDeleteButton.Size = new System.Drawing.Size(75, 23);
            this.pathDeleteButton.TabIndex = 2;
            this.pathDeleteButton.Text = "Delete";
            this.pathDeleteButton.UseVisualStyleBackColor = true;
            this.pathDeleteButton.Click += new System.EventHandler(this.pathDeleteButton_Click);
            // 
            // pathAddButton
            // 
            this.pathAddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pathAddButton.Location = new System.Drawing.Point(6, 143);
            this.pathAddButton.Name = "pathAddButton";
            this.pathAddButton.Size = new System.Drawing.Size(75, 23);
            this.pathAddButton.TabIndex = 1;
            this.pathAddButton.Text = "Add";
            this.pathAddButton.UseVisualStyleBackColor = true;
            this.pathAddButton.Click += new System.EventHandler(this.pathAddButton_Click);
            // 
            // nameGroup
            // 
            this.nameGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.nameGroup.Controls.Add(this.nameBox);
            this.nameGroup.Location = new System.Drawing.Point(12, 12);
            this.nameGroup.Name = "nameGroup";
            this.nameGroup.Size = new System.Drawing.Size(341, 52);
            this.nameGroup.TabIndex = 0;
            this.nameGroup.TabStop = false;
            this.nameGroup.Text = "Name";
            // 
            // nameBox
            // 
            this.nameBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.nameBox.Location = new System.Drawing.Point(6, 19);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(329, 20);
            this.nameBox.TabIndex = 0;
            // 
            // mainSplit
            // 
            this.mainSplit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mainSplit.Location = new System.Drawing.Point(12, 186);
            this.mainSplit.Name = "mainSplit";
            this.mainSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // mainSplit.Panel1
            // 
            this.mainSplit.Panel1.Controls.Add(this.commandsGroup);
            // 
            // mainSplit.Panel2
            // 
            this.mainSplit.Panel2.Controls.Add(this.pathsGroup);
            this.mainSplit.Size = new System.Drawing.Size(341, 325);
            this.mainSplit.SplitterDistance = 143;
            this.mainSplit.TabIndex = 3;
            // 
            // commandsGroup
            // 
            this.commandsGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.commandsGroup.Controls.Add(this.commandersWindow);
            this.commandsGroup.Location = new System.Drawing.Point(3, 3);
            this.commandsGroup.Name = "commandsGroup";
            this.commandsGroup.Size = new System.Drawing.Size(335, 137);
            this.commandsGroup.TabIndex = 0;
            this.commandsGroup.TabStop = false;
            this.commandsGroup.Text = "Commands";
            // 
            // commandersWindow
            // 
            this.commandersWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.commandersWindow.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.commandersWindow.Location = new System.Drawing.Point(6, 19);
            this.commandersWindow.Multiline = true;
            this.commandersWindow.Name = "commandersWindow";
            this.commandersWindow.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.commandersWindow.Size = new System.Drawing.Size(323, 112);
            this.commandersWindow.TabIndex = 0;
            this.commandersWindow.WordWrap = false;
            // 
            // pathBrowser
            // 
            this.pathBrowser.Description = "Folder to add to watched folders";
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(197, 517);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 4;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(278, 517);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // filtersGroup
            // 
            this.filtersGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.filtersGroup.Controls.Add(this.filtersBox);
            this.filtersGroup.Location = new System.Drawing.Point(12, 70);
            this.filtersGroup.Name = "filtersGroup";
            this.filtersGroup.Size = new System.Drawing.Size(341, 52);
            this.filtersGroup.TabIndex = 1;
            this.filtersGroup.TabStop = false;
            this.filtersGroup.Text = "Filters";
            // 
            // directoryGrop
            // 
            this.directoryGrop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.directoryGrop.Controls.Add(this.browseButton);
            this.directoryGrop.Controls.Add(this.directoryBox);
            this.directoryGrop.Location = new System.Drawing.Point(12, 128);
            this.directoryGrop.Name = "directoryGrop";
            this.directoryGrop.Size = new System.Drawing.Size(341, 52);
            this.directoryGrop.TabIndex = 2;
            this.directoryGrop.TabStop = false;
            this.directoryGrop.Text = "Working Directory";
            // 
            // directoryBox
            // 
            this.directoryBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.directoryBox.Location = new System.Drawing.Point(6, 19);
            this.directoryBox.Name = "directoryBox";
            this.directoryBox.Size = new System.Drawing.Size(248, 20);
            this.directoryBox.TabIndex = 0;
            // 
            // browseButton
            // 
            this.browseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.browseButton.Location = new System.Drawing.Point(260, 17);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 1;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // directoryBrowser
            // 
            this.directoryBrowser.Description = "Folder to add to watched folders";
            // 
            // filtersBox
            // 
            this.filtersBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.filtersBox.FormattingEnabled = true;
            this.filtersBox.Location = new System.Drawing.Point(6, 19);
            this.filtersBox.Name = "filtersBox";
            this.filtersBox.Size = new System.Drawing.Size(326, 21);
            this.filtersBox.TabIndex = 0;
            // 
            // SetupForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 552);
            this.Controls.Add(this.directoryGrop);
            this.Controls.Add(this.filtersGroup);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.mainSplit);
            this.Controls.Add(this.nameGroup);
            this.Name = "SetupForm";
            this.Text = "Setup Commander";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SetupForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SetupForm_FormClosed);
            this.Load += new System.EventHandler(this.SetupForm_Load);
            this.pathsGroup.ResumeLayout(false);
            this.nameGroup.ResumeLayout(false);
            this.nameGroup.PerformLayout();
            this.mainSplit.Panel1.ResumeLayout(false);
            this.mainSplit.Panel2.ResumeLayout(false);
            this.mainSplit.ResumeLayout(false);
            this.commandsGroup.ResumeLayout(false);
            this.commandsGroup.PerformLayout();
            this.filtersGroup.ResumeLayout(false);
            this.directoryGrop.ResumeLayout(false);
            this.directoryGrop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox pathsGroup;
        private System.Windows.Forms.Button pathDeleteButton;
        private System.Windows.Forms.Button pathAddButton;
        private System.Windows.Forms.GroupBox nameGroup;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.ListBox pathsWindow;
        private System.Windows.Forms.SplitContainer mainSplit;
        private System.Windows.Forms.GroupBox commandsGroup;
        private System.Windows.Forms.FolderBrowserDialog pathBrowser;
        private System.Windows.Forms.TextBox commandersWindow;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.GroupBox filtersGroup;
        private System.Windows.Forms.GroupBox directoryGrop;
        private System.Windows.Forms.ComboBox filtersBox;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.TextBox directoryBox;
        private System.Windows.Forms.FolderBrowserDialog directoryBrowser;
    }
}