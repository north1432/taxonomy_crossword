namespace WindowsFormsApplication1
{
    partial class Form2
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
            this.PlayButton = new System.Windows.Forms.Button();
            this.Helpbutton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.CreditButton = new System.Windows.Forms.Button();
            this.OptionButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PlayButton
            // 
            this.PlayButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.PlayButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.PlayButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.PlayButton.Location = new System.Drawing.Point(300, 200);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(200, 40);
            this.PlayButton.TabIndex = 1;
            this.PlayButton.Text = "Play";
            this.PlayButton.UseVisualStyleBackColor = false;
            this.PlayButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // Helpbutton
            // 
            this.Helpbutton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Helpbutton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Helpbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Helpbutton.Location = new System.Drawing.Point(300, 300);
            this.Helpbutton.Name = "Helpbutton";
            this.Helpbutton.Size = new System.Drawing.Size(200, 40);
            this.Helpbutton.TabIndex = 3;
            this.Helpbutton.Text = "Help";
            this.Helpbutton.UseVisualStyleBackColor = false;
            this.Helpbutton.Click += new System.EventHandler(this.button3_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ExitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.ExitButton.Location = new System.Drawing.Point(300, 400);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(200, 40);
            this.ExitButton.TabIndex = 5;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = false;
            this.ExitButton.Click += new System.EventHandler(this.button5_Click);
            // 
            // CreditButton
            // 
            this.CreditButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.CreditButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CreditButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.CreditButton.Location = new System.Drawing.Point(300, 350);
            this.CreditButton.Name = "CreditButton";
            this.CreditButton.Size = new System.Drawing.Size(200, 40);
            this.CreditButton.TabIndex = 6;
            this.CreditButton.Text = "Credit";
            this.CreditButton.UseVisualStyleBackColor = false;
            this.CreditButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // OptionButton
            // 
            this.OptionButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.OptionButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.OptionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.OptionButton.Location = new System.Drawing.Point(300, 250);
            this.OptionButton.Name = "OptionButton";
            this.OptionButton.Size = new System.Drawing.Size(200, 40);
            this.OptionButton.TabIndex = 7;
            this.OptionButton.Text = "Option";
            this.OptionButton.UseVisualStyleBackColor = false;
            this.OptionButton.Click += new System.EventHandler(this.OptionButton_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.mainbg2;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.OptionButton);
            this.Controls.Add(this.CreditButton);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.Helpbutton);
            this.Controls.Add(this.PlayButton);
            this.Name = "Form2";
            this.Text = "Taxonomy Crossword";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button PlayButton;
        private System.Windows.Forms.Button Helpbutton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button CreditButton;
        private System.Windows.Forms.Button OptionButton;
    }
}