namespace FileSystemsWatcherTest
{
    partial class MainForm
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
            this.logWindow = new System.Windows.Forms.ListBox();
            this.commandersWindow = new System.Windows.Forms.ListBox();
            this.mainSplit = new System.Windows.Forms.SplitContainer();
            this.pathsGroup = new System.Windows.Forms.GroupBox();
            this.copyButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.deletePathButton = new System.Windows.Forms.Button();
            this.addPathButton = new System.Windows.Forms.Button();
            this.pathBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.mainSplit.Panel1.SuspendLayout();
            this.mainSplit.Panel2.SuspendLayout();
            this.mainSplit.SuspendLayout();
            this.pathsGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // logWindow
            // 
            this.logWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.logWindow.FormattingEnabled = true;
            this.logWindow.HorizontalScrollbar = true;
            this.logWindow.IntegralHeight = false;
            this.logWindow.Location = new System.Drawing.Point(3, 12);
            this.logWindow.Name = "logWindow";
            this.logWindow.Size = new System.Drawing.Size(607, 437);
            this.logWindow.TabIndex = 0;
            // 
            // commandersWindow
            // 
            this.commandersWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.commandersWindow.FormattingEnabled = true;
            this.commandersWindow.IntegralHeight = false;
            this.commandersWindow.Location = new System.Drawing.Point(12, 145);
            this.commandersWindow.Name = "commandersWindow";
            this.commandersWindow.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.commandersWindow.Size = new System.Drawing.Size(143, 304);
            this.commandersWindow.TabIndex = 0;
            // 
            // mainSplit
            // 
            this.mainSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplit.Location = new System.Drawing.Point(0, 0);
            this.mainSplit.Name = "mainSplit";
            // 
            // mainSplit.Panel1
            // 
            this.mainSplit.Panel1.Controls.Add(this.pathsGroup);
            this.mainSplit.Panel1.Controls.Add(this.commandersWindow);
            // 
            // mainSplit.Panel2
            // 
            this.mainSplit.Panel2.Controls.Add(this.logWindow);
            this.mainSplit.Size = new System.Drawing.Size(784, 461);
            this.mainSplit.SplitterDistance = 158;
            this.mainSplit.TabIndex = 2;
            // 
            // pathsGroup
            // 
            this.pathsGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pathsGroup.Controls.Add(this.copyButton);
            this.pathsGroup.Controls.Add(this.editButton);
            this.pathsGroup.Controls.Add(this.deletePathButton);
            this.pathsGroup.Controls.Add(this.addPathButton);
            this.pathsGroup.Location = new System.Drawing.Point(12, 3);
            this.pathsGroup.Name = "pathsGroup";
            this.pathsGroup.Size = new System.Drawing.Size(143, 136);
            this.pathsGroup.TabIndex = 1;
            this.pathsGroup.TabStop = false;
            // 
            // copyButton
            // 
            this.copyButton.Location = new System.Drawing.Point(6, 77);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(75, 23);
            this.copyButton.TabIndex = 3;
            this.copyButton.Text = "Copy...";
            this.copyButton.UseVisualStyleBackColor = true;
            this.copyButton.Click += new System.EventHandler(this.copyButton_Click);
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(6, 48);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(75, 23);
            this.editButton.TabIndex = 2;
            this.editButton.Text = "Edit...";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // deletePathButton
            // 
            this.deletePathButton.Location = new System.Drawing.Point(6, 106);
            this.deletePathButton.Name = "deletePathButton";
            this.deletePathButton.Size = new System.Drawing.Size(75, 23);
            this.deletePathButton.TabIndex = 1;
            this.deletePathButton.Text = "Delete";
            this.deletePathButton.UseVisualStyleBackColor = true;
            this.deletePathButton.Click += new System.EventHandler(this.deletePathButton_Click);
            // 
            // addPathButton
            // 
            this.addPathButton.Location = new System.Drawing.Point(6, 19);
            this.addPathButton.Name = "addPathButton";
            this.addPathButton.Size = new System.Drawing.Size(75, 23);
            this.addPathButton.TabIndex = 0;
            this.addPathButton.Text = "New...";
            this.addPathButton.UseVisualStyleBackColor = true;
            this.addPathButton.Click += new System.EventHandler(this.addPathButton_Click);
            // 
            // pathBrowser
            // 
            this.pathBrowser.Description = "Folder to add to watched folders";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.mainSplit);
            this.Name = "MainForm";
            this.Text = "File System Watcher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mainSplit.Panel1.ResumeLayout(false);
            this.mainSplit.Panel2.ResumeLayout(false);
            this.mainSplit.ResumeLayout(false);
            this.pathsGroup.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox logWindow;
        private System.Windows.Forms.ListBox commandersWindow;
        private System.Windows.Forms.SplitContainer mainSplit;
        private System.Windows.Forms.GroupBox pathsGroup;
        private System.Windows.Forms.Button deletePathButton;
        private System.Windows.Forms.Button addPathButton;
        private System.Windows.Forms.FolderBrowserDialog pathBrowser;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button copyButton;
    }
}

