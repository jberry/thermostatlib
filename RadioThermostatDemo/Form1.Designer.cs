namespace RadioThermostatDemo
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
            this.InfoButton = new System.Windows.Forms.Button();
            this.ipText = new System.Windows.Forms.TextBox();
            this.SetLedButton = new System.Windows.Forms.Button();
            this.PriceButton = new System.Windows.Forms.Button();
            this.SystemNameButton = new System.Windows.Forms.Button();
            this.RebootButton = new System.Windows.Forms.Button();
            this.CoolButton = new System.Windows.Forms.Button();
            this.HeatButton = new System.Windows.Forms.Button();
            this.AutoButton = new System.Windows.Forms.Button();
            this.LoadProgramButton = new System.Windows.Forms.Button();
            this.SetProgramButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // InfoButton
            // 
            this.InfoButton.Location = new System.Drawing.Point(118, 9);
            this.InfoButton.Name = "InfoButton";
            this.InfoButton.Size = new System.Drawing.Size(100, 23);
            this.InfoButton.TabIndex = 0;
            this.InfoButton.Text = "Show Info";
            this.InfoButton.UseVisualStyleBackColor = true;
            this.InfoButton.Click += new System.EventHandler(this.InfoButton_Click);
            // 
            // ipText
            // 
            this.ipText.Location = new System.Drawing.Point(12, 12);
            this.ipText.Name = "ipText";
            this.ipText.Size = new System.Drawing.Size(100, 20);
            this.ipText.TabIndex = 1;
            this.ipText.Text = "192.168.1.106";
            // 
            // SetLedButton
            // 
            this.SetLedButton.Location = new System.Drawing.Point(13, 39);
            this.SetLedButton.Name = "SetLedButton";
            this.SetLedButton.Size = new System.Drawing.Size(99, 23);
            this.SetLedButton.TabIndex = 2;
            this.SetLedButton.Text = "Make LED Green";
            this.SetLedButton.UseVisualStyleBackColor = true;
            this.SetLedButton.Click += new System.EventHandler(this.SetLedButton_Click);
            // 
            // PriceButton
            // 
            this.PriceButton.Location = new System.Drawing.Point(12, 68);
            this.PriceButton.Name = "PriceButton";
            this.PriceButton.Size = new System.Drawing.Size(100, 23);
            this.PriceButton.TabIndex = 3;
            this.PriceButton.Text = "Set Price";
            this.PriceButton.UseVisualStyleBackColor = true;
            this.PriceButton.Click += new System.EventHandler(this.PriceButton_Click);
            // 
            // SystemNameButton
            // 
            this.SystemNameButton.Location = new System.Drawing.Point(13, 97);
            this.SystemNameButton.Name = "SystemNameButton";
            this.SystemNameButton.Size = new System.Drawing.Size(99, 23);
            this.SystemNameButton.TabIndex = 4;
            this.SystemNameButton.Text = "Set System Name";
            this.SystemNameButton.UseVisualStyleBackColor = true;
            this.SystemNameButton.Click += new System.EventHandler(this.SystemNameButton_Click);
            // 
            // RebootButton
            // 
            this.RebootButton.Location = new System.Drawing.Point(13, 126);
            this.RebootButton.Name = "RebootButton";
            this.RebootButton.Size = new System.Drawing.Size(99, 23);
            this.RebootButton.TabIndex = 5;
            this.RebootButton.Text = "Reboot";
            this.RebootButton.UseVisualStyleBackColor = true;
            this.RebootButton.Click += new System.EventHandler(this.RebootButton_Click);
            // 
            // CoolButton
            // 
            this.CoolButton.Location = new System.Drawing.Point(118, 39);
            this.CoolButton.Name = "CoolButton";
            this.CoolButton.Size = new System.Drawing.Size(100, 23);
            this.CoolButton.TabIndex = 6;
            this.CoolButton.Text = "Cool to 70";
            this.CoolButton.UseVisualStyleBackColor = true;
            this.CoolButton.Click += new System.EventHandler(this.CoolButton_Click);
            // 
            // HeatButton
            // 
            this.HeatButton.Location = new System.Drawing.Point(118, 68);
            this.HeatButton.Name = "HeatButton";
            this.HeatButton.Size = new System.Drawing.Size(100, 23);
            this.HeatButton.TabIndex = 7;
            this.HeatButton.Text = "Heat to 80";
            this.HeatButton.UseVisualStyleBackColor = true;
            this.HeatButton.Click += new System.EventHandler(this.HeatButton_Click);
            // 
            // AutoButton
            // 
            this.AutoButton.Location = new System.Drawing.Point(118, 97);
            this.AutoButton.Name = "AutoButton";
            this.AutoButton.Size = new System.Drawing.Size(100, 23);
            this.AutoButton.TabIndex = 8;
            this.AutoButton.Text = "Maintain 75-85";
            this.AutoButton.UseVisualStyleBackColor = true;
            this.AutoButton.Click += new System.EventHandler(this.AutoButton_Click);
            // 
            // LoadProgramButton
            // 
            this.LoadProgramButton.Location = new System.Drawing.Point(224, 39);
            this.LoadProgramButton.Name = "LoadProgramButton";
            this.LoadProgramButton.Size = new System.Drawing.Size(100, 23);
            this.LoadProgramButton.TabIndex = 9;
            this.LoadProgramButton.Text = "Load Program";
            this.LoadProgramButton.UseVisualStyleBackColor = true;
            this.LoadProgramButton.Click += new System.EventHandler(this.LoadProgramButton_Click);
            // 
            // SetProgramButton
            // 
            this.SetProgramButton.Location = new System.Drawing.Point(225, 69);
            this.SetProgramButton.Name = "SetProgramButton";
            this.SetProgramButton.Size = new System.Drawing.Size(99, 23);
            this.SetProgramButton.TabIndex = 10;
            this.SetProgramButton.Text = "Set Program";
            this.SetProgramButton.UseVisualStyleBackColor = true;
            this.SetProgramButton.Click += new System.EventHandler(this.SetProgramButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 155);
            this.Controls.Add(this.SetProgramButton);
            this.Controls.Add(this.LoadProgramButton);
            this.Controls.Add(this.AutoButton);
            this.Controls.Add(this.HeatButton);
            this.Controls.Add(this.CoolButton);
            this.Controls.Add(this.RebootButton);
            this.Controls.Add(this.SystemNameButton);
            this.Controls.Add(this.PriceButton);
            this.Controls.Add(this.SetLedButton);
            this.Controls.Add(this.ipText);
            this.Controls.Add(this.InfoButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button InfoButton;
        private System.Windows.Forms.TextBox ipText;
        private System.Windows.Forms.Button SetLedButton;
        private System.Windows.Forms.Button PriceButton;
        private System.Windows.Forms.Button SystemNameButton;
        private System.Windows.Forms.Button RebootButton;
        private System.Windows.Forms.Button CoolButton;
        private System.Windows.Forms.Button HeatButton;
        private System.Windows.Forms.Button AutoButton;
        private System.Windows.Forms.Button LoadProgramButton;
        private System.Windows.Forms.Button SetProgramButton;
    }
}

