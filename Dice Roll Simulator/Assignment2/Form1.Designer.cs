namespace Assignment2
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
            this.rTxtBox1 = new System.Windows.Forms.RichTextBox();
            this.lbl1 = new System.Windows.Forms.Label();
            this.pBox1 = new System.Windows.Forms.PictureBox();
            this.cmd1 = new System.Windows.Forms.Button();
            this.cmd2 = new System.Windows.Forms.Button();
            this.txtbox1 = new System.Windows.Forms.TextBox();
            this.grpBox1 = new System.Windows.Forms.GroupBox();
            this.lbl7 = new System.Windows.Forms.Label();
            this.lbl6 = new System.Windows.Forms.Label();
            this.lbl5 = new System.Windows.Forms.Label();
            this.lbl4 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pBox1)).BeginInit();
            this.grpBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rTxtBox1
            // 
            this.rTxtBox1.Font = new System.Drawing.Font("SimSun-ExtB", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rTxtBox1.Location = new System.Drawing.Point(43, 258);
            this.rTxtBox1.Name = "rTxtBox1";
            this.rTxtBox1.Size = new System.Drawing.Size(440, 180);
            this.rTxtBox1.TabIndex = 0;
            this.rTxtBox1.Text = "";
            this.rTxtBox1.WordWrap = false;
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(40, 101);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(138, 13);
            this.lbl1.TabIndex = 1;
            this.lbl1.Text = "Enter your Guess (1-6):";
            // 
            // pBox1
            // 
            this.pBox1.Location = new System.Drawing.Point(43, 126);
            this.pBox1.Name = "pBox1";
            this.pBox1.Size = new System.Drawing.Size(139, 111);
            this.pBox1.TabIndex = 2;
            this.pBox1.TabStop = false;
            // 
            // cmd1
            // 
            this.cmd1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.cmd1.Location = new System.Drawing.Point(188, 126);
            this.cmd1.Name = "cmd1";
            this.cmd1.Size = new System.Drawing.Size(75, 23);
            this.cmd1.TabIndex = 3;
            this.cmd1.Text = "Roll";
            this.cmd1.UseVisualStyleBackColor = true;
            this.cmd1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmd2
            // 
            this.cmd2.Location = new System.Drawing.Point(188, 155);
            this.cmd2.Name = "cmd2";
            this.cmd2.Size = new System.Drawing.Size(75, 23);
            this.cmd2.TabIndex = 4;
            this.cmd2.Text = "Reset";
            this.cmd2.UseVisualStyleBackColor = true;
            this.cmd2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtbox1
            // 
            this.txtbox1.Location = new System.Drawing.Point(188, 98);
            this.txtbox1.MaxLength = 1;
            this.txtbox1.Name = "txtbox1";
            this.txtbox1.Size = new System.Drawing.Size(75, 20);
            this.txtbox1.TabIndex = 5;
            this.txtbox1.Click += new System.EventHandler(this.txtBox1_TextChanged);
            this.txtbox1.TextChanged += new System.EventHandler(this.txtBox1_TextChanged);
            // 
            // grpBox1
            // 
            this.grpBox1.Controls.Add(this.lbl7);
            this.grpBox1.Controls.Add(this.lbl6);
            this.grpBox1.Controls.Add(this.lbl5);
            this.grpBox1.Controls.Add(this.lbl4);
            this.grpBox1.Controls.Add(this.lbl3);
            this.grpBox1.Controls.Add(this.lbl2);
            this.grpBox1.Location = new System.Drawing.Point(43, 25);
            this.grpBox1.Name = "grpBox1";
            this.grpBox1.Size = new System.Drawing.Size(259, 70);
            this.grpBox1.TabIndex = 6;
            this.grpBox1.TabStop = false;
            this.grpBox1.Text = "Game Info";
            // 
            // lbl7
            // 
            this.lbl7.AutoSize = true;
            this.lbl7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl7.Location = new System.Drawing.Point(162, 51);
            this.lbl7.Name = "lbl7";
            this.lbl7.Size = new System.Drawing.Size(14, 13);
            this.lbl7.TabIndex = 5;
            this.lbl7.Text = "0";
            // 
            // lbl6
            // 
            this.lbl6.AutoSize = true;
            this.lbl6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl6.Location = new System.Drawing.Point(162, 33);
            this.lbl6.Name = "lbl6";
            this.lbl6.Size = new System.Drawing.Size(14, 13);
            this.lbl6.TabIndex = 4;
            this.lbl6.Text = "0";
            // 
            // lbl5
            // 
            this.lbl5.AutoSize = true;
            this.lbl5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl5.Location = new System.Drawing.Point(162, 16);
            this.lbl5.Name = "lbl5";
            this.lbl5.Size = new System.Drawing.Size(14, 13);
            this.lbl5.TabIndex = 3;
            this.lbl5.Text = "0";
            // 
            // lbl4
            // 
            this.lbl4.AutoSize = true;
            this.lbl4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl4.Location = new System.Drawing.Point(7, 51);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(134, 13);
            this.lbl4.TabIndex = 2;
            this.lbl4.Text = "Number of Times Lost:";
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl3.Location = new System.Drawing.Point(7, 33);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(136, 13);
            this.lbl3.TabIndex = 1;
            this.lbl3.Text = "Number of Times Won:";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl2.Location = new System.Drawing.Point(7, 16);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(148, 13);
            this.lbl2.TabIndex = 0;
            this.lbl2.Text = "Number of Times Played:";
            // 
            // lbl8
            // 
            this.lbl8.AutoSize = true;
            this.lbl8.Location = new System.Drawing.Point(270, 102);
            this.lbl8.Name = "lbl8";
            this.lbl8.Size = new System.Drawing.Size(214, 13);
            this.lbl8.TabIndex = 7;
            this.lbl8.Text = "<- Please enter a number between 1 and 6 !";
            this.lbl8.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(528, 450);
            this.Controls.Add(this.lbl8);
            this.Controls.Add(this.grpBox1);
            this.Controls.Add(this.txtbox1);
            this.Controls.Add(this.cmd2);
            this.Controls.Add(this.cmd1);
            this.Controls.Add(this.pBox1);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.rTxtBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pBox1)).EndInit();
            this.grpBox1.ResumeLayout(false);
            this.grpBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rTxtBox1;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.PictureBox pBox1;
        private System.Windows.Forms.Button cmd1;
        private System.Windows.Forms.Button cmd2;
        private System.Windows.Forms.TextBox txtbox1;
        private System.Windows.Forms.GroupBox grpBox1;
        private System.Windows.Forms.Label lbl5;
        private System.Windows.Forms.Label lbl4;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl6;
        private System.Windows.Forms.Label lbl7;
        private System.Windows.Forms.Label lbl8;
    }
}

