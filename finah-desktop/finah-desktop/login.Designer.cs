namespace finah_desktop
{
    partial class login
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gebruiker = new System.Windows.Forms.TextBox();
            this.wachtwoord = new System.Windows.Forms.TextBox();
            this.logbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "gebruikersnaam";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(80, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "wachtwoord";
            // 
            // gebruiker
            // 
            this.gebruiker.Location = new System.Drawing.Point(165, 103);
            this.gebruiker.Name = "gebruiker";
            this.gebruiker.Size = new System.Drawing.Size(150, 20);
            this.gebruiker.TabIndex = 2;
            // 
            // wachtwoord
            // 
            this.wachtwoord.Location = new System.Drawing.Point(165, 145);
            this.wachtwoord.Name = "wachtwoord";
            this.wachtwoord.Size = new System.Drawing.Size(150, 20);
            this.wachtwoord.TabIndex = 3;
            this.wachtwoord.UseSystemPasswordChar = true;
            // 
            // logbutton
            // 
            this.logbutton.Location = new System.Drawing.Point(203, 185);
            this.logbutton.Name = "logbutton";
            this.logbutton.Size = new System.Drawing.Size(75, 25);
            this.logbutton.TabIndex = 4;
            this.logbutton.Text = "login";
            this.logbutton.UseVisualStyleBackColor = true;
            this.logbutton.Click += new System.EventHandler(this.logbutton_Click);
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.ControlBox = false;
            this.Controls.Add(this.logbutton);
            this.Controls.Add(this.wachtwoord);
            this.Controls.Add(this.gebruiker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox gebruiker;
        private System.Windows.Forms.TextBox wachtwoord;
        private System.Windows.Forms.Button logbutton;
    }
}