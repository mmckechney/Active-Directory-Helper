namespace ActiveDirectoryHelper
{
    partial class CustomDirectReportQueryForm
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
            this.SuspendLayout();
          
            // 
            // lblMain
            // 
            this.lblMain.Size = new System.Drawing.Size(516, 13);
            this.lblMain.Text = "LDAP Query format to use for retrieving direct report list (default is by disting" +
                "uishedname):";
           
            // 
            // CustomDirectReportQueryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(811, 291);
            this.Name = "CustomDirectReportQueryForm";
            this.Text = "Custom LDAP Search for finding Direct Report List";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
