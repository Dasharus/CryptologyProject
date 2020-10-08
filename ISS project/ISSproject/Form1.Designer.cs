namespace ISSproject
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.pageOptions = new System.Windows.Forms.TabControl();
            this.Options = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.greatJobButton = new System.Windows.Forms.Button();
            this.labelAbout = new System.Windows.Forms.Label();
            this.pageOptions.SuspendLayout();
            this.Options.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MistyRose;
            this.button1.Font = new System.Drawing.Font("Microsoft YaHei", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(97, 61);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(169, 50);
            this.button1.TabIndex = 1;
            this.button1.Text = "Частотна таблиця";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // pageOptions
            // 
            this.pageOptions.Controls.Add(this.Options);
            this.pageOptions.Controls.Add(this.tabPage2);
            this.pageOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageOptions.Location = new System.Drawing.Point(0, 0);
            this.pageOptions.Name = "pageOptions";
            this.pageOptions.SelectedIndex = 0;
            this.pageOptions.Size = new System.Drawing.Size(377, 382);
            this.pageOptions.TabIndex = 2;
            // 
            // Options
            // 
            this.Options.Controls.Add(this.button2);
            this.Options.Controls.Add(this.button1);
            this.Options.ForeColor = System.Drawing.Color.Black;
            this.Options.Location = new System.Drawing.Point(4, 25);
            this.Options.Name = "Options";
            this.Options.Padding = new System.Windows.Forms.Padding(3);
            this.Options.Size = new System.Drawing.Size(369, 353);
            this.Options.TabIndex = 0;
            this.Options.Text = "Options";
            this.Options.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.MistyRose;
            this.button2.Location = new System.Drawing.Point(97, 142);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(169, 50);
            this.button2.TabIndex = 3;
            this.button2.Text = "Простий шифр";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Snow;
            this.tabPage2.Controls.Add(this.greatJobButton);
            this.tabPage2.Controls.Add(this.labelAbout);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(369, 353);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "About";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // greatJobButton
            // 
            this.greatJobButton.BackColor = System.Drawing.Color.SeaShell;
            this.greatJobButton.Location = new System.Drawing.Point(118, 256);
            this.greatJobButton.Name = "greatJobButton";
            this.greatJobButton.Size = new System.Drawing.Size(133, 32);
            this.greatJobButton.TabIndex = 1;
            this.greatJobButton.Text = "GREAT JOB!";
            this.greatJobButton.UseVisualStyleBackColor = false;
            this.greatJobButton.Click += new System.EventHandler(this.GreatJobButton_Click);
            // 
            // labelAbout
            // 
            this.labelAbout.AutoSize = true;
            this.labelAbout.BackColor = System.Drawing.Color.MistyRose;
            this.labelAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAbout.Location = new System.Drawing.Point(68, 82);
            this.labelAbout.Name = "labelAbout";
            this.labelAbout.Size = new System.Drawing.Size(232, 145);
            this.labelAbout.TabIndex = 0;
            this.labelAbout.Text = "MADE BY \r\nDARIA SLUPACHYK\r\nPMA-31\r\n\r\nLOL\r\n";
            this.labelAbout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(377, 382);
            this.Controls.Add(this.pageOptions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CRYPTOLOGY";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.pageOptions.ResumeLayout(false);
            this.Options.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabControl pageOptions;
        private System.Windows.Forms.TabPage Options;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button greatJobButton;
        private System.Windows.Forms.Label labelAbout;
        private System.Windows.Forms.Button button2;
    }
}

