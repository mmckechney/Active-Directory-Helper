namespace ActiveDirectoryHelper
{
    partial class FindMultipleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FindMultipleForm));
            this.txtMultiple = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statLines = new System.Windows.Forms.ToolStripStatusLabel();
            this.ddRecent = new System.Windows.Forms.ToolStripDropDownButton();
            this.clearRecentSearchesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtMultiple
            // 
            this.txtMultiple.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMultiple.Location = new System.Drawing.Point(12, 98);
            this.txtMultiple.Multiline = true;
            this.txtMultiple.Name = "txtMultiple";
            this.txtMultiple.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMultiple.Size = new System.Drawing.Size(318, 297);
            this.txtMultiple.TabIndex = 0;
            this.txtMultiple.TextChanged += new System.EventHandler(this.txtMultiple_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter one User ID or Name per line:";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(93, 401);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(174, 401);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 65);
            this.label2.TabIndex = 4;
            this.label2.Text = "Accepted Formats:\r\n  User ID\r\n  Last , First \r\n  First (Middle)  Last\r\n  E-Mail A" +
                "ddress";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statLines,
            this.ddRecent});
            this.statusStrip1.Location = new System.Drawing.Point(0, 430);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(342, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statLines
            // 
            this.statLines.Name = "statLines";
            this.statLines.Size = new System.Drawing.Size(183, 17);
            this.statLines.Spring = true;
            this.statLines.Text = "Items Added : 0";
            this.statLines.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ddRecent
            // 
            this.ddRecent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ddRecent.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearRecentSearchesToolStripMenuItem,
            this.toolStripSeparator1});
            this.ddRecent.ForeColor = System.Drawing.Color.Blue;
            this.ddRecent.Image = ((System.Drawing.Image)(resources.GetObject("ddRecent.Image")));
            this.ddRecent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ddRecent.Name = "ddRecent";
            this.ddRecent.Size = new System.Drawing.Size(113, 20);
            this.ddRecent.Text = "Recent Searches...";
            // 
            // clearRecentSearchesToolStripMenuItem
            // 
            this.clearRecentSearchesToolStripMenuItem.Name = "clearRecentSearchesToolStripMenuItem";
            this.clearRecentSearchesToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.clearRecentSearchesToolStripMenuItem.Text = "Clear Recent Searches";
            this.clearRecentSearchesToolStripMenuItem.Click += new System.EventHandler(this.clearRecentSearchesToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(191, 6);
            // 
            // FindMultipleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 452);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMultiple);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FindMultipleForm";
            this.Text = "Multiple User Search";
            this.Load += new System.EventHandler(this.FindMultipleForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMultiple;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statLines;
        private System.Windows.Forms.ToolStripDropDownButton ddRecent;
        private System.Windows.Forms.ToolStripMenuItem clearRecentSearchesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}