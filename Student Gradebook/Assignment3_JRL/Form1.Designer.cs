namespace Assignment3_JRL
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.submitCountBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tBoxNAssignments = new System.Windows.Forms.TextBox();
            this.tBoxNStudents = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelHint = new System.Windows.Forms.Label();
            this.lastStudentBtn = new System.Windows.Forms.Button();
            this.nextStudentBtn = new System.Windows.Forms.Button();
            this.prevStudentBtn = new System.Windows.Forms.Button();
            this.firstStudentBtn = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.saveNameBtn = new System.Windows.Forms.Button();
            this.tBoxStudentInfo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.errLabel4 = new System.Windows.Forms.Label();
            this.errLabel3 = new System.Windows.Forms.Label();
            this.saveScoreBtn = new System.Windows.Forms.Button();
            this.tBoxAssignmentScore = new System.Windows.Forms.TextBox();
            this.tBoxAssignmentNum = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.displayScoreBtn = new System.Windows.Forms.Button();
            this.resetScoreBtn = new System.Windows.Forms.Button();
            this.errLabel1 = new System.Windows.Forms.Label();
            this.errLabel2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(13, 372);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(719, 135);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.WordWrap = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.submitCountBtn);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tBoxNAssignments);
            this.groupBox1.Controls.Add(this.tBoxNStudents);
            this.groupBox1.Location = new System.Drawing.Point(12, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(501, 78);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Counts";
            // 
            // submitCountBtn
            // 
            this.submitCountBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitCountBtn.Location = new System.Drawing.Point(331, 19);
            this.submitCountBtn.Name = "submitCountBtn";
            this.submitCountBtn.Size = new System.Drawing.Size(161, 46);
            this.submitCountBtn.TabIndex = 4;
            this.submitCountBtn.Text = "Submit Counts";
            this.submitCountBtn.UseVisualStyleBackColor = true;
            this.submitCountBtn.Click += new System.EventHandler(this.submitCountBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Number of assignments:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(51, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Number of students:";
            // 
            // tBoxNAssignments
            // 
            this.tBoxNAssignments.Location = new System.Drawing.Point(187, 47);
            this.tBoxNAssignments.Name = "tBoxNAssignments";
            this.tBoxNAssignments.Size = new System.Drawing.Size(100, 20);
            this.tBoxNAssignments.TabIndex = 1;
            this.tBoxNAssignments.TextChanged += new System.EventHandler(this.tBoxNAssignments_TextChanged);
            // 
            // tBoxNStudents
            // 
            this.tBoxNStudents.Location = new System.Drawing.Point(187, 20);
            this.tBoxNStudents.Name = "tBoxNStudents";
            this.tBoxNStudents.Size = new System.Drawing.Size(100, 20);
            this.tBoxNStudents.TabIndex = 0;
            this.tBoxNStudents.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tBoxNStudents_MouseClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelHint);
            this.groupBox2.Controls.Add(this.lastStudentBtn);
            this.groupBox2.Controls.Add(this.nextStudentBtn);
            this.groupBox2.Controls.Add(this.prevStudentBtn);
            this.groupBox2.Controls.Add(this.firstStudentBtn);
            this.groupBox2.Location = new System.Drawing.Point(13, 110);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(590, 74);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Navigate";
            // 
            // labelHint
            // 
            this.labelHint.AutoSize = true;
            this.labelHint.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHint.Location = new System.Drawing.Point(103, 25);
            this.labelHint.Name = "labelHint";
            this.labelHint.Size = new System.Drawing.Size(388, 24);
            this.labelHint.TabIndex = 4;
            this.labelHint.Text = "Please Submit Counts to reveal the form.";
            this.labelHint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lastStudentBtn
            // 
            this.lastStudentBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastStudentBtn.Location = new System.Drawing.Point(405, 19);
            this.lastStudentBtn.Name = "lastStudentBtn";
            this.lastStudentBtn.Size = new System.Drawing.Size(86, 41);
            this.lastStudentBtn.TabIndex = 3;
            this.lastStudentBtn.Text = ">> Last Student";
            this.lastStudentBtn.UseVisualStyleBackColor = true;
            this.lastStudentBtn.Click += new System.EventHandler(this.lastStudentBtn_Click);
            // 
            // nextStudentBtn
            // 
            this.nextStudentBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextStudentBtn.Location = new System.Drawing.Point(285, 19);
            this.nextStudentBtn.Name = "nextStudentBtn";
            this.nextStudentBtn.Size = new System.Drawing.Size(86, 41);
            this.nextStudentBtn.TabIndex = 2;
            this.nextStudentBtn.Text = "> Next Student";
            this.nextStudentBtn.UseVisualStyleBackColor = true;
            this.nextStudentBtn.Click += new System.EventHandler(this.nextStudentBtn_Click);
            // 
            // prevStudentBtn
            // 
            this.prevStudentBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prevStudentBtn.Location = new System.Drawing.Point(167, 19);
            this.prevStudentBtn.Name = "prevStudentBtn";
            this.prevStudentBtn.Size = new System.Drawing.Size(86, 41);
            this.prevStudentBtn.TabIndex = 1;
            this.prevStudentBtn.Text = "< Prev Student";
            this.prevStudentBtn.UseVisualStyleBackColor = true;
            this.prevStudentBtn.Click += new System.EventHandler(this.prevStudentBtn_Click);
            // 
            // firstStudentBtn
            // 
            this.firstStudentBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.firstStudentBtn.Location = new System.Drawing.Point(54, 19);
            this.firstStudentBtn.Name = "firstStudentBtn";
            this.firstStudentBtn.Size = new System.Drawing.Size(86, 41);
            this.firstStudentBtn.TabIndex = 0;
            this.firstStudentBtn.Text = "<< First Student";
            this.firstStudentBtn.UseVisualStyleBackColor = true;
            this.firstStudentBtn.Click += new System.EventHandler(this.firstStudentBtn_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.saveNameBtn);
            this.groupBox3.Controls.Add(this.tBoxStudentInfo);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(13, 190);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(590, 55);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Student Info";
            // 
            // saveNameBtn
            // 
            this.saveNameBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveNameBtn.Location = new System.Drawing.Point(500, 17);
            this.saveNameBtn.Name = "saveNameBtn";
            this.saveNameBtn.Size = new System.Drawing.Size(82, 22);
            this.saveNameBtn.TabIndex = 2;
            this.saveNameBtn.Text = "Save Name";
            this.saveNameBtn.UseVisualStyleBackColor = true;
            this.saveNameBtn.Click += new System.EventHandler(this.saveNameBtn_Click);
            // 
            // tBoxStudentInfo
            // 
            this.tBoxStudentInfo.Location = new System.Drawing.Point(207, 19);
            this.tBoxStudentInfo.Name = "tBoxStudentInfo";
            this.tBoxStudentInfo.Size = new System.Drawing.Size(284, 20);
            this.tBoxStudentInfo.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(129, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Student #:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.errLabel4);
            this.groupBox4.Controls.Add(this.errLabel3);
            this.groupBox4.Controls.Add(this.saveScoreBtn);
            this.groupBox4.Controls.Add(this.tBoxAssignmentScore);
            this.groupBox4.Controls.Add(this.tBoxAssignmentNum);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Location = new System.Drawing.Point(13, 251);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(590, 80);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Student Info";
            // 
            // errLabel4
            // 
            this.errLabel4.AutoSize = true;
            this.errLabel4.Location = new System.Drawing.Point(302, 49);
            this.errLabel4.Name = "errLabel4";
            this.errLabel4.Size = new System.Drawing.Size(152, 13);
            this.errLabel4.TabIndex = 6;
            this.errLabel4.Text = "Enter Number between (1-100)";
            this.errLabel4.Visible = false;
            // 
            // errLabel3
            // 
            this.errLabel3.AutoSize = true;
            this.errLabel3.Location = new System.Drawing.Point(302, 23);
            this.errLabel3.Name = "errLabel3";
            this.errLabel3.Size = new System.Drawing.Size(87, 13);
            this.errLabel3.TabIndex = 5;
            this.errLabel3.Text = "Enter Number (1-";
            this.errLabel3.Visible = false;
            this.errLabel3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tBoxNStudents_MouseClick);
            // 
            // saveScoreBtn
            // 
            this.saveScoreBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveScoreBtn.Location = new System.Drawing.Point(500, 23);
            this.saveScoreBtn.Name = "saveScoreBtn";
            this.saveScoreBtn.Size = new System.Drawing.Size(82, 22);
            this.saveScoreBtn.TabIndex = 4;
            this.saveScoreBtn.Text = "Save Score";
            this.saveScoreBtn.UseVisualStyleBackColor = true;
            this.saveScoreBtn.Click += new System.EventHandler(this.saveScoreBtn_Click);
            // 
            // tBoxAssignmentScore
            // 
            this.tBoxAssignmentScore.Location = new System.Drawing.Point(245, 45);
            this.tBoxAssignmentScore.Name = "tBoxAssignmentScore";
            this.tBoxAssignmentScore.Size = new System.Drawing.Size(51, 20);
            this.tBoxAssignmentScore.TabIndex = 3;
            this.tBoxAssignmentScore.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tBoxNStudents_MouseClick);
            this.tBoxAssignmentScore.TextChanged += new System.EventHandler(this.tBoxAssignmentScore_TextChanged);
            // 
            // tBoxAssignmentNum
            // 
            this.tBoxAssignmentNum.Location = new System.Drawing.Point(245, 19);
            this.tBoxAssignmentNum.Name = "tBoxAssignmentNum";
            this.tBoxAssignmentNum.Size = new System.Drawing.Size(51, 20);
            this.tBoxAssignmentNum.TabIndex = 2;
            this.tBoxAssignmentNum.TextChanged += new System.EventHandler(this.tBoxAssignmentNum_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(93, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "Assignment Score:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(221, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Enter Assignment Number (1-99):";
            // 
            // displayScoreBtn
            // 
            this.displayScoreBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayScoreBtn.Location = new System.Drawing.Point(297, 337);
            this.displayScoreBtn.Name = "displayScoreBtn";
            this.displayScoreBtn.Size = new System.Drawing.Size(116, 29);
            this.displayScoreBtn.TabIndex = 5;
            this.displayScoreBtn.Text = "Display Scores";
            this.displayScoreBtn.UseVisualStyleBackColor = true;
            this.displayScoreBtn.Click += new System.EventHandler(this.displayScoreBtn_Click);
            // 
            // resetScoreBtn
            // 
            this.resetScoreBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetScoreBtn.Location = new System.Drawing.Point(519, 23);
            this.resetScoreBtn.Name = "resetScoreBtn";
            this.resetScoreBtn.Size = new System.Drawing.Size(84, 82);
            this.resetScoreBtn.TabIndex = 6;
            this.resetScoreBtn.Text = "Reset Scores";
            this.resetScoreBtn.UseVisualStyleBackColor = true;
            this.resetScoreBtn.Click += new System.EventHandler(this.resetScoreBtn_Click);
            // 
            // errLabel1
            // 
            this.errLabel1.AutoSize = true;
            this.errLabel1.Location = new System.Drawing.Point(63, 6);
            this.errLabel1.Name = "errLabel1";
            this.errLabel1.Size = new System.Drawing.Size(270, 13);
            this.errLabel1.TabIndex = 7;
            this.errLabel1.Text = "Please enter a valid number of students between (1-10).";
            this.errLabel1.Visible = false;
            // 
            // errLabel2
            // 
            this.errLabel2.AutoSize = true;
            this.errLabel2.Location = new System.Drawing.Point(340, 6);
            this.errLabel2.Name = "errLabel2";
            this.errLabel2.Size = new System.Drawing.Size(241, 13);
            this.errLabel2.TabIndex = 8;
            this.errLabel2.Text = "Please enter a valid number of assignments (0-99)";
            this.errLabel2.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 519);
            this.Controls.Add(this.errLabel2);
            this.Controls.Add(this.errLabel1);
            this.Controls.Add(this.resetScoreBtn);
            this.Controls.Add(this.displayScoreBtn);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button submitCountBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tBoxNAssignments;
        private System.Windows.Forms.TextBox tBoxNStudents;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button lastStudentBtn;
        private System.Windows.Forms.Button nextStudentBtn;
        private System.Windows.Forms.Button prevStudentBtn;
        private System.Windows.Forms.Button firstStudentBtn;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button saveNameBtn;
        private System.Windows.Forms.TextBox tBoxStudentInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button saveScoreBtn;
        private System.Windows.Forms.TextBox tBoxAssignmentScore;
        private System.Windows.Forms.TextBox tBoxAssignmentNum;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button displayScoreBtn;
        private System.Windows.Forms.Button resetScoreBtn;
        private System.Windows.Forms.Label errLabel1;
        private System.Windows.Forms.Label errLabel2;
        private System.Windows.Forms.Label errLabel4;
        private System.Windows.Forms.Label errLabel3;
        private System.Windows.Forms.Label labelHint;
    }
}

