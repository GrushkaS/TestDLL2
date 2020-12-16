namespace TestDLL2
{
    partial class MainUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TextBoxMain = new System.Windows.Forms.TextBox();
            this.LabelMain = new System.Windows.Forms.Label();
            this.ButtonMain = new System.Windows.Forms.Button();
            this.LabelDescription = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TextBoxMain
            // 
            this.TextBoxMain.Location = new System.Drawing.Point(3, 27);
            this.TextBoxMain.Name = "TextBoxMain";
            this.TextBoxMain.Size = new System.Drawing.Size(268, 20);
            this.TextBoxMain.TabIndex = 0;
            // 
            // LabelMain
            // 
            this.LabelMain.AutoSize = true;
            this.LabelMain.Location = new System.Drawing.Point(3, 10);
            this.LabelMain.Name = "LabelMain";
            this.LabelMain.Size = new System.Drawing.Size(45, 13);
            this.LabelMain.TabIndex = 1;
            this.LabelMain.Text = "WGS84";
            // 
            // ButtonMain
            // 
            this.ButtonMain.Location = new System.Drawing.Point(325, 27);
            this.ButtonMain.Name = "ButtonMain";
            this.ButtonMain.Size = new System.Drawing.Size(75, 23);
            this.ButtonMain.TabIndex = 2;
            this.ButtonMain.Text = "Accept";
            this.ButtonMain.UseVisualStyleBackColor = true;
            this.ButtonMain.Click += new System.EventHandler(this.ButtonMain_Click);
            // 
            // LabelDescription
            // 
            this.LabelDescription.AutoSize = true;
            this.LabelDescription.Location = new System.Drawing.Point(3, 59);
            this.LabelDescription.Name = "LabelDescription";
            this.LabelDescription.Size = new System.Drawing.Size(247, 13);
            this.LabelDescription.TabIndex = 3;
            this.LabelDescription.Text = "Input format: Xcoord1 Ycoord1 Xcoord2 Ycoord2...";
            // 
            // MainUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LabelDescription);
            this.Controls.Add(this.ButtonMain);
            this.Controls.Add(this.LabelMain);
            this.Controls.Add(this.TextBoxMain);
            this.Name = "MainUserControl";
            this.Size = new System.Drawing.Size(440, 210);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBoxMain;
        private System.Windows.Forms.Label LabelMain;
        private System.Windows.Forms.Button ButtonMain;
        private System.Windows.Forms.Label LabelDescription;
    }
}
