namespace FinancasSobControle
{
    partial class Changes
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
            this.txtChanges = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtChanges
            // 
            this.txtChanges.Location = new System.Drawing.Point(12, 12);
            this.txtChanges.Multiline = true;
            this.txtChanges.Name = "txtChanges";
            this.txtChanges.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtChanges.Size = new System.Drawing.Size(729, 408);
            this.txtChanges.TabIndex = 0;
            // 
            // Changes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtChanges);
            this.Name = "Changes";
            this.Text = "Changes";
            this.Load += new System.EventHandler(this.Changes_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtChanges;
    }
}