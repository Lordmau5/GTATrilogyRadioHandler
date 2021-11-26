namespace GTATrilogyRadioHandler
{
    partial class FormAddProgram
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
            this.checkedListBoxPrograms = new System.Windows.Forms.CheckedListBox();
            this.buttonAddSelectedPrograms = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkedListBoxPrograms
            // 
            this.checkedListBoxPrograms.FormattingEnabled = true;
            this.checkedListBoxPrograms.Location = new System.Drawing.Point(12, 12);
            this.checkedListBoxPrograms.Name = "checkedListBoxPrograms";
            this.checkedListBoxPrograms.Size = new System.Drawing.Size(549, 244);
            this.checkedListBoxPrograms.TabIndex = 0;
            // 
            // buttonAddSelectedPrograms
            // 
            this.buttonAddSelectedPrograms.Location = new System.Drawing.Point(12, 262);
            this.buttonAddSelectedPrograms.Name = "buttonAddSelectedPrograms";
            this.buttonAddSelectedPrograms.Size = new System.Drawing.Size(146, 23);
            this.buttonAddSelectedPrograms.TabIndex = 1;
            this.buttonAddSelectedPrograms.Text = "Add Selected Programs";
            this.buttonAddSelectedPrograms.UseVisualStyleBackColor = true;
            this.buttonAddSelectedPrograms.Click += new System.EventHandler(this.buttonAddSelectedPrograms_Click);
            // 
            // FormAddProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 296);
            this.Controls.Add(this.buttonAddSelectedPrograms);
            this.Controls.Add(this.checkedListBoxPrograms);
            this.MaximumSize = new System.Drawing.Size(589, 335);
            this.MinimumSize = new System.Drawing.Size(589, 335);
            this.Name = "FormAddProgram";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Programs";
            this.Load += new System.EventHandler(this.OnLoad);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBoxPrograms;
        private System.Windows.Forms.Button buttonAddSelectedPrograms;
    }
}