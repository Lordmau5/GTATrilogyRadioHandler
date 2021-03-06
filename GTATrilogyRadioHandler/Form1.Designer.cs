namespace GTATrilogyRadioHandler
{
    partial class GTATrilogyRadioHandler
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
            this.buttonGTA3 = new System.Windows.Forms.Button();
            this.buttonGTAViceCity = new System.Windows.Forms.Button();
            this.buttonGTASanAndreas = new System.Windows.Forms.Button();
            this.buttonUnhook = new System.Windows.Forms.Button();
            this.buttonPauseResume = new System.Windows.Forms.Button();
            this.listBoxPrograms = new System.Windows.Forms.ListBox();
            this.buttonAddPrograms = new System.Windows.Forms.Button();
            this.labelInformation = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonGTA3
            // 
            this.buttonGTA3.Location = new System.Drawing.Point(12, 12);
            this.buttonGTA3.Name = "buttonGTA3";
            this.buttonGTA3.Size = new System.Drawing.Size(299, 23);
            this.buttonGTA3.TabIndex = 0;
            this.buttonGTA3.Text = "GTA 3";
            this.buttonGTA3.UseVisualStyleBackColor = true;
            this.buttonGTA3.Click += new System.EventHandler(this.ButtonGTA3_Click);
            // 
            // buttonGTAViceCity
            // 
            this.buttonGTAViceCity.Location = new System.Drawing.Point(12, 41);
            this.buttonGTAViceCity.Name = "buttonGTAViceCity";
            this.buttonGTAViceCity.Size = new System.Drawing.Size(299, 23);
            this.buttonGTAViceCity.TabIndex = 1;
            this.buttonGTAViceCity.Text = "GTA Vice City";
            this.buttonGTAViceCity.UseVisualStyleBackColor = true;
            this.buttonGTAViceCity.Click += new System.EventHandler(this.ButtonGTAViceCity_Click);
            // 
            // buttonGTASanAndreas
            // 
            this.buttonGTASanAndreas.Location = new System.Drawing.Point(12, 70);
            this.buttonGTASanAndreas.Name = "buttonGTASanAndreas";
            this.buttonGTASanAndreas.Size = new System.Drawing.Size(299, 23);
            this.buttonGTASanAndreas.TabIndex = 2;
            this.buttonGTASanAndreas.Text = "GTA San Andreas";
            this.buttonGTASanAndreas.UseVisualStyleBackColor = true;
            this.buttonGTASanAndreas.Click += new System.EventHandler(this.ButtonGTASanAndreas_Click);
            // 
            // buttonUnhook
            // 
            this.buttonUnhook.Enabled = false;
            this.buttonUnhook.Location = new System.Drawing.Point(355, 12);
            this.buttonUnhook.Name = "buttonUnhook";
            this.buttonUnhook.Size = new System.Drawing.Size(128, 23);
            this.buttonUnhook.TabIndex = 4;
            this.buttonUnhook.Text = "Unhook";
            this.buttonUnhook.UseVisualStyleBackColor = true;
            this.buttonUnhook.Click += new System.EventHandler(this.ButtonUnhook_Click);
            // 
            // buttonPauseResume
            // 
            this.buttonPauseResume.Enabled = false;
            this.buttonPauseResume.Location = new System.Drawing.Point(355, 41);
            this.buttonPauseResume.Name = "buttonPauseResume";
            this.buttonPauseResume.Size = new System.Drawing.Size(128, 23);
            this.buttonPauseResume.TabIndex = 5;
            this.buttonPauseResume.Text = "Pause";
            this.buttonPauseResume.UseVisualStyleBackColor = true;
            this.buttonPauseResume.Click += new System.EventHandler(this.ButtonPauseResume_Click);
            // 
            // listBoxPrograms
            // 
            this.listBoxPrograms.FormattingEnabled = true;
            this.listBoxPrograms.Location = new System.Drawing.Point(12, 99);
            this.listBoxPrograms.Name = "listBoxPrograms";
            this.listBoxPrograms.Size = new System.Drawing.Size(299, 160);
            this.listBoxPrograms.TabIndex = 7;
            this.listBoxPrograms.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListBoxPrograms_KeyDown);
            // 
            // buttonAddPrograms
            // 
            this.buttonAddPrograms.Location = new System.Drawing.Point(317, 236);
            this.buttonAddPrograms.Name = "buttonAddPrograms";
            this.buttonAddPrograms.Size = new System.Drawing.Size(166, 23);
            this.buttonAddPrograms.TabIndex = 8;
            this.buttonAddPrograms.Text = "Add Programs";
            this.buttonAddPrograms.UseVisualStyleBackColor = true;
            this.buttonAddPrograms.Click += new System.EventHandler(this.ButtonAddPrograms_Click);
            // 
            // labelInformation
            // 
            this.labelInformation.AutoSize = true;
            this.labelInformation.Location = new System.Drawing.Point(317, 99);
            this.labelInformation.Name = "labelInformation";
            this.labelInformation.Size = new System.Drawing.Size(157, 39);
            this.labelInformation.TabIndex = 9;
            this.labelInformation.Text = "Hold SHIFT and press DELETE\r\nto remove a program from\r\nthe list.";
            // 
            // GTATrilogyRadioHandler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 271);
            this.Controls.Add(this.labelInformation);
            this.Controls.Add(this.buttonAddPrograms);
            this.Controls.Add(this.listBoxPrograms);
            this.Controls.Add(this.buttonPauseResume);
            this.Controls.Add(this.buttonUnhook);
            this.Controls.Add(this.buttonGTASanAndreas);
            this.Controls.Add(this.buttonGTAViceCity);
            this.Controls.Add(this.buttonGTA3);
            this.MaximumSize = new System.Drawing.Size(511, 310);
            this.MinimumSize = new System.Drawing.Size(511, 310);
            this.Name = "GTATrilogyRadioHandler";
            this.Text = "GTA Radio Thingy";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonGTA3;
        private System.Windows.Forms.Button buttonGTAViceCity;
        private System.Windows.Forms.Button buttonGTASanAndreas;
        private System.Windows.Forms.Button buttonUnhook;
        private System.Windows.Forms.Button buttonPauseResume;
        private System.Windows.Forms.ListBox listBoxPrograms;
        private System.Windows.Forms.Button buttonAddPrograms;
        private System.Windows.Forms.Label labelInformation;
    }
}

