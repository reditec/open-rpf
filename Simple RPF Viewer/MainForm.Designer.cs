namespace Simple_RPF_Viewer
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Folder", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("XML File", System.Windows.Forms.HorizontalAlignment.Left);
            listView = new System.Windows.Forms.ListView();
            columnHeader1 = new System.Windows.Forms.ColumnHeader();
            columnHeader2 = new System.Windows.Forms.ColumnHeader();
            columnHeader3 = new System.Windows.Forms.ColumnHeader();
            columnHeader4 = new System.Windows.Forms.ColumnHeader();
            columnHeader5 = new System.Windows.Forms.ColumnHeader();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            backButton = new System.Windows.Forms.ToolStripButton();
            contextMenu = new System.Windows.Forms.ContextMenuStrip(components);
            openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            openWithToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            extractToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStrip1.SuspendLayout();
            contextMenu.SuspendLayout();
            SuspendLayout();
            // 
            // listView
            // 
            listView.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5 });
            listView.FullRowSelect = true;
            listView.GridLines = true;
            listViewGroup1.Header = "Folder";
            listViewGroup1.Name = "dir";
            listViewGroup1.Tag = "Folder";
            listViewGroup2.Header = "XML File";
            listViewGroup2.Name = "xml";
            listViewGroup2.Tag = "XML FIle";
            listView.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] { listViewGroup1, listViewGroup2 });
            listView.LabelEdit = true;
            listView.Location = new System.Drawing.Point(0, 28);
            listView.Name = "listView";
            listView.Size = new System.Drawing.Size(941, 474);
            listView.TabIndex = 1;
            listView.UseCompatibleStateImageBehavior = false;
            listView.View = System.Windows.Forms.View.Details;
            listView.DoubleClick += listView1_DoubleClick;
            listView.MouseClick += listView_MouseClick;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Name";
            columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Type";
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Size";
            columnHeader3.Width = 80;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Attributes";
            columnHeader4.Width = 80;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Tags";
            columnHeader5.Width = 120;
            // 
            // toolStrip1
            // 
            toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { backButton });
            toolStrip1.Location = new System.Drawing.Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new System.Drawing.Size(941, 25);
            toolStrip1.TabIndex = 2;
            toolStrip1.Text = "toolStrip1";
            // 
            // backButton
            // 
            backButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            backButton.Enabled = false;
            backButton.Image = Properties.Resources.undo_icon;
            backButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            backButton.Name = "backButton";
            backButton.Size = new System.Drawing.Size(23, 22);
            backButton.Text = "Back";
            backButton.Click += backButton_Click;
            // 
            // contextMenu
            // 
            contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { openToolStripMenuItem, openWithToolStripMenuItem, extractToolStripMenuItem });
            contextMenu.Name = "contextMenu";
            contextMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            contextMenu.Size = new System.Drawing.Size(139, 70);
            contextMenu.Text = "Context menu";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // openWithToolStripMenuItem
            // 
            openWithToolStripMenuItem.Name = "openWithToolStripMenuItem";
            openWithToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            openWithToolStripMenuItem.Text = "Open with...";
            openWithToolStripMenuItem.Click += openWithToolStripMenuItem_Click;
            // 
            // extractToolStripMenuItem
            // 
            extractToolStripMenuItem.Name = "extractToolStripMenuItem";
            extractToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            extractToolStripMenuItem.Text = "Extract";
            extractToolStripMenuItem.Click += extractToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(941, 502);
            Controls.Add(toolStrip1);
            Controls.Add(listView);
            Name = "MainForm";
            Text = "Simple RPF Viewer";
            Shown += MainForm_Shown;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            contextMenu.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton backButton;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem extractToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openWithToolStripMenuItem;
    }
}

