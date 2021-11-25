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
            this.SuspendLayout();
            // 
            // buttonGTA3
            // 
            this.buttonGTA3.Location = new System.Drawing.Point(12, 12);
            this.buttonGTA3.Name = "buttonGTA3";
            this.buttonGTA3.Size = new System.Drawing.Size(216, 23);
            this.buttonGTA3.TabIndex = 0;
            this.buttonGTA3.Text = "GTA 3";
            this.buttonGTA3.UseVisualStyleBackColor = true;
            this.buttonGTA3.Click += new System.EventHandler(this.buttonGTA3_Click);
            // 
            // buttonGTAViceCity
            // 
            this.buttonGTAViceCity.Location = new System.Drawing.Point(12, 41);
            this.buttonGTAViceCity.Name = "buttonGTAViceCity";
            this.buttonGTAViceCity.Size = new System.Drawing.Size(216, 23);
            this.buttonGTAViceCity.TabIndex = 1;
            this.buttonGTAViceCity.Text = "GTA Vice City";
            this.buttonGTAViceCity.UseVisualStyleBackColor = true;
            this.buttonGTAViceCity.Click += new System.EventHandler(this.buttonGTAViceCity_Click);
            // 
            // buttonGTASanAndreas
            // 
            this.buttonGTASanAndreas.Location = new System.Drawing.Point(12, 70);
            this.buttonGTASanAndreas.Name = "buttonGTASanAndreas";
            this.buttonGTASanAndreas.Size = new System.Drawing.Size(216, 23);
            this.buttonGTASanAndreas.TabIndex = 2;
            this.buttonGTASanAndreas.Text = "GTA San Andreas";
            this.buttonGTASanAndreas.UseVisualStyleBackColor = true;
            this.buttonGTASanAndreas.Click += new System.EventHandler(this.buttonGTASanAndreas_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 107);
            this.Controls.Add(this.buttonGTASanAndreas);
            this.Controls.Add(this.buttonGTAViceCity);
            this.Controls.Add(this.buttonGTA3);
            this.MaximumSize = new System.Drawing.Size(256, 146);
            this.MinimumSize = new System.Drawing.Size(256, 146);
            this.Name = "Form1";
            this.Text = "GTA Radio Thingy";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonGTA3;
        private System.Windows.Forms.Button buttonGTAViceCity;
        private System.Windows.Forms.Button buttonGTASanAndreas;
    }
}

