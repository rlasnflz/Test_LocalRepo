namespace EncoderCalibration
{
    partial class Config
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Config));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rBtnRight = new System.Windows.Forms.RadioButton();
            this.rBtnLeft = new System.Windows.Forms.RadioButton();
            this.btnSave = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tBoxGCMax = new System.Windows.Forms.TextBox();
            this.tBoxGCMin = new System.Windows.Forms.TextBox();
            this.tBoxGFMax = new System.Windows.Forms.TextBox();
            this.tBoxGFMin = new System.Windows.Forms.TextBox();
            this.tBoxGXMax = new System.Windows.Forms.TextBox();
            this.tBoxGXMin = new System.Windows.Forms.TextBox();
            this.tBoxVOSSMax = new System.Windows.Forms.TextBox();
            this.tBoxVOSSMin = new System.Windows.Forms.TextBox();
            this.tBoxVOSCMax = new System.Windows.Forms.TextBox();
            this.tBoxVOSCMin = new System.Windows.Forms.TextBox();
            this.tBoxPHMax = new System.Windows.Forms.TextBox();
            this.tBoxPHMin = new System.Windows.Forms.TextBox();
            this.tBoxGXErrMax = new System.Windows.Forms.TextBox();
            this.tBoxGXErrMin = new System.Windows.Forms.TextBox();
            this.tBoxVOSSErrMax = new System.Windows.Forms.TextBox();
            this.tBoxVOSSErrMin = new System.Windows.Forms.TextBox();
            this.tBoxVOSCErrMax = new System.Windows.Forms.TextBox();
            this.tBoxVOSCErrMin = new System.Windows.Forms.TextBox();
            this.tBoxPHErrMax = new System.Windows.Forms.TextBox();
            this.tBoxPHErrMin = new System.Windows.Forms.TextBox();
            this.tBoxNoniusMax = new System.Windows.Forms.TextBox();
            this.tBoxNoniusMin = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox1, 3);
            this.groupBox1.Controls.Add(this.rBtnRight);
            this.groupBox1.Controls.Add(this.rBtnLeft);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(278, 52);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Start Position";
            // 
            // rBtnRight
            // 
            this.rBtnRight.AutoSize = true;
            this.rBtnRight.Location = new System.Drawing.Point(60, 23);
            this.rBtnRight.Name = "rBtnRight";
            this.rBtnRight.Size = new System.Drawing.Size(53, 19);
            this.rBtnRight.TabIndex = 0;
            this.rBtnRight.TabStop = true;
            this.rBtnRight.Text = "Right";
            this.rBtnRight.UseVisualStyleBackColor = true;
            // 
            // rBtnLeft
            // 
            this.rBtnLeft.AutoSize = true;
            this.rBtnLeft.Location = new System.Drawing.Point(9, 23);
            this.rBtnLeft.Name = "rBtnLeft";
            this.rBtnLeft.Size = new System.Drawing.Size(45, 19);
            this.rBtnLeft.TabIndex = 0;
            this.rBtnLeft.TabStop = true;
            this.rBtnLeft.Text = "Left";
            this.rBtnLeft.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.Location = new System.Drawing.Point(127, 429);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(74, 29);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSave, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnClose, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(284, 461);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClose.Location = new System.Drawing.Point(207, 429);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(74, 29);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox2, 3);
            this.groupBox2.Controls.Add(this.tBoxNoniusMin);
            this.groupBox2.Controls.Add(this.tBoxPHErrMin);
            this.groupBox2.Controls.Add(this.tBoxVOSCErrMin);
            this.groupBox2.Controls.Add(this.tBoxVOSSErrMin);
            this.groupBox2.Controls.Add(this.tBoxGXErrMin);
            this.groupBox2.Controls.Add(this.tBoxPHMin);
            this.groupBox2.Controls.Add(this.tBoxVOSCMin);
            this.groupBox2.Controls.Add(this.tBoxVOSSMin);
            this.groupBox2.Controls.Add(this.tBoxGXMin);
            this.groupBox2.Controls.Add(this.tBoxGFMin);
            this.groupBox2.Controls.Add(this.tBoxGCMin);
            this.groupBox2.Controls.Add(this.tBoxNoniusMax);
            this.groupBox2.Controls.Add(this.tBoxPHErrMax);
            this.groupBox2.Controls.Add(this.tBoxVOSCErrMax);
            this.groupBox2.Controls.Add(this.tBoxVOSSErrMax);
            this.groupBox2.Controls.Add(this.tBoxGXErrMax);
            this.groupBox2.Controls.Add(this.tBoxPHMax);
            this.groupBox2.Controls.Add(this.tBoxVOSCMax);
            this.groupBox2.Controls.Add(this.tBoxVOSSMax);
            this.groupBox2.Controls.Add(this.tBoxGXMax);
            this.groupBox2.Controls.Add(this.tBoxGFMax);
            this.groupBox2.Controls.Add(this.tBoxGCMax);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 63);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(278, 360);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Spec";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gain Range";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(144, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Min";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(219, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Max";
            // 
            // tBoxGCMax
            // 
            this.tBoxGCMax.Location = new System.Drawing.Point(199, 39);
            this.tBoxGCMax.Name = "tBoxGCMax";
            this.tBoxGCMax.Size = new System.Drawing.Size(70, 23);
            this.tBoxGCMax.TabIndex = 1;
            // 
            // tBoxGCMin
            // 
            this.tBoxGCMin.Location = new System.Drawing.Point(123, 39);
            this.tBoxGCMin.Name = "tBoxGCMin";
            this.tBoxGCMin.Size = new System.Drawing.Size(70, 23);
            this.tBoxGCMin.TabIndex = 1;
            // 
            // tBoxGFMax
            // 
            this.tBoxGFMax.Location = new System.Drawing.Point(199, 68);
            this.tBoxGFMax.Name = "tBoxGFMax";
            this.tBoxGFMax.Size = new System.Drawing.Size(70, 23);
            this.tBoxGFMax.TabIndex = 1;
            // 
            // tBoxGFMin
            // 
            this.tBoxGFMin.Location = new System.Drawing.Point(123, 68);
            this.tBoxGFMin.Name = "tBoxGFMin";
            this.tBoxGFMin.Size = new System.Drawing.Size(70, 23);
            this.tBoxGFMin.TabIndex = 1;
            // 
            // tBoxGXMax
            // 
            this.tBoxGXMax.Location = new System.Drawing.Point(199, 97);
            this.tBoxGXMax.Name = "tBoxGXMax";
            this.tBoxGXMax.Size = new System.Drawing.Size(70, 23);
            this.tBoxGXMax.TabIndex = 1;
            // 
            // tBoxGXMin
            // 
            this.tBoxGXMin.Location = new System.Drawing.Point(123, 97);
            this.tBoxGXMin.Name = "tBoxGXMin";
            this.tBoxGXMin.Size = new System.Drawing.Size(70, 23);
            this.tBoxGXMin.TabIndex = 1;
            // 
            // tBoxVOSSMax
            // 
            this.tBoxVOSSMax.Location = new System.Drawing.Point(199, 126);
            this.tBoxVOSSMax.Name = "tBoxVOSSMax";
            this.tBoxVOSSMax.Size = new System.Drawing.Size(70, 23);
            this.tBoxVOSSMax.TabIndex = 1;
            // 
            // tBoxVOSSMin
            // 
            this.tBoxVOSSMin.Location = new System.Drawing.Point(123, 126);
            this.tBoxVOSSMin.Name = "tBoxVOSSMin";
            this.tBoxVOSSMin.Size = new System.Drawing.Size(70, 23);
            this.tBoxVOSSMin.TabIndex = 1;
            // 
            // tBoxVOSCMax
            // 
            this.tBoxVOSCMax.Location = new System.Drawing.Point(199, 155);
            this.tBoxVOSCMax.Name = "tBoxVOSCMax";
            this.tBoxVOSCMax.Size = new System.Drawing.Size(70, 23);
            this.tBoxVOSCMax.TabIndex = 1;
            // 
            // tBoxVOSCMin
            // 
            this.tBoxVOSCMin.Location = new System.Drawing.Point(123, 155);
            this.tBoxVOSCMin.Name = "tBoxVOSCMin";
            this.tBoxVOSCMin.Size = new System.Drawing.Size(70, 23);
            this.tBoxVOSCMin.TabIndex = 1;
            // 
            // tBoxPHMax
            // 
            this.tBoxPHMax.Location = new System.Drawing.Point(199, 184);
            this.tBoxPHMax.Name = "tBoxPHMax";
            this.tBoxPHMax.Size = new System.Drawing.Size(70, 23);
            this.tBoxPHMax.TabIndex = 1;
            // 
            // tBoxPHMin
            // 
            this.tBoxPHMin.Location = new System.Drawing.Point(123, 184);
            this.tBoxPHMin.Name = "tBoxPHMin";
            this.tBoxPHMin.Size = new System.Drawing.Size(70, 23);
            this.tBoxPHMin.TabIndex = 1;
            // 
            // tBoxGXErrMax
            // 
            this.tBoxGXErrMax.Location = new System.Drawing.Point(199, 213);
            this.tBoxGXErrMax.Name = "tBoxGXErrMax";
            this.tBoxGXErrMax.Size = new System.Drawing.Size(70, 23);
            this.tBoxGXErrMax.TabIndex = 1;
            // 
            // tBoxGXErrMin
            // 
            this.tBoxGXErrMin.Location = new System.Drawing.Point(123, 213);
            this.tBoxGXErrMin.Name = "tBoxGXErrMin";
            this.tBoxGXErrMin.Size = new System.Drawing.Size(70, 23);
            this.tBoxGXErrMin.TabIndex = 1;
            // 
            // tBoxVOSSErrMax
            // 
            this.tBoxVOSSErrMax.Location = new System.Drawing.Point(199, 242);
            this.tBoxVOSSErrMax.Name = "tBoxVOSSErrMax";
            this.tBoxVOSSErrMax.Size = new System.Drawing.Size(70, 23);
            this.tBoxVOSSErrMax.TabIndex = 1;
            // 
            // tBoxVOSSErrMin
            // 
            this.tBoxVOSSErrMin.Location = new System.Drawing.Point(123, 242);
            this.tBoxVOSSErrMin.Name = "tBoxVOSSErrMin";
            this.tBoxVOSSErrMin.Size = new System.Drawing.Size(70, 23);
            this.tBoxVOSSErrMin.TabIndex = 1;
            // 
            // tBoxVOSCErrMax
            // 
            this.tBoxVOSCErrMax.Location = new System.Drawing.Point(199, 271);
            this.tBoxVOSCErrMax.Name = "tBoxVOSCErrMax";
            this.tBoxVOSCErrMax.Size = new System.Drawing.Size(70, 23);
            this.tBoxVOSCErrMax.TabIndex = 1;
            // 
            // tBoxVOSCErrMin
            // 
            this.tBoxVOSCErrMin.Location = new System.Drawing.Point(123, 271);
            this.tBoxVOSCErrMin.Name = "tBoxVOSCErrMin";
            this.tBoxVOSCErrMin.Size = new System.Drawing.Size(70, 23);
            this.tBoxVOSCErrMin.TabIndex = 1;
            // 
            // tBoxPHErrMax
            // 
            this.tBoxPHErrMax.Location = new System.Drawing.Point(199, 300);
            this.tBoxPHErrMax.Name = "tBoxPHErrMax";
            this.tBoxPHErrMax.Size = new System.Drawing.Size(70, 23);
            this.tBoxPHErrMax.TabIndex = 1;
            // 
            // tBoxPHErrMin
            // 
            this.tBoxPHErrMin.Location = new System.Drawing.Point(123, 300);
            this.tBoxPHErrMin.Name = "tBoxPHErrMin";
            this.tBoxPHErrMin.Size = new System.Drawing.Size(70, 23);
            this.tBoxPHErrMin.TabIndex = 1;
            // 
            // tBoxNoniusMax
            // 
            this.tBoxNoniusMax.Location = new System.Drawing.Point(199, 329);
            this.tBoxNoniusMax.Name = "tBoxNoniusMax";
            this.tBoxNoniusMax.Size = new System.Drawing.Size(70, 23);
            this.tBoxNoniusMax.TabIndex = 1;
            // 
            // tBoxNoniusMin
            // 
            this.tBoxNoniusMin.Location = new System.Drawing.Point(123, 329);
            this.tBoxNoniusMin.Name = "tBoxNoniusMin";
            this.tBoxNoniusMin.Size = new System.Drawing.Size(70, 23);
            this.tBoxNoniusMin.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(60, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Gain Fine";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(46, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Cosine Gain";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(51, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Sine Offset";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(38, 158);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "Cosine Offset";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(41, 187);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "Phase Adjust";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 216);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 15);
            this.label9.TabIndex = 0;
            this.label9.Text = "Cosine Gain (Err)";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(25, 245);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 15);
            this.label10.TabIndex = 0;
            this.label10.Text = "Sine Offset (Err)";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 274);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(105, 15);
            this.label11.TabIndex = 0;
            this.label11.Text = "Cosine Offset (Err)";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 303);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(102, 15);
            this.label12.TabIndex = 0;
            this.label12.Text = "Phase Adjust (Err)";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(21, 332);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(96, 15);
            this.label13.TabIndex = 0;
            this.label13.Text = "Nonius In Range";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 461);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Config";
            this.Text = "Config";
            this.Load += new System.EventHandler(this.Config_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rBtnRight;
        private System.Windows.Forms.RadioButton rBtnLeft;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tBoxNoniusMin;
        private System.Windows.Forms.TextBox tBoxPHErrMin;
        private System.Windows.Forms.TextBox tBoxVOSCErrMin;
        private System.Windows.Forms.TextBox tBoxVOSSErrMin;
        private System.Windows.Forms.TextBox tBoxGXErrMin;
        private System.Windows.Forms.TextBox tBoxPHMin;
        private System.Windows.Forms.TextBox tBoxVOSCMin;
        private System.Windows.Forms.TextBox tBoxVOSSMin;
        private System.Windows.Forms.TextBox tBoxGXMin;
        private System.Windows.Forms.TextBox tBoxGFMin;
        private System.Windows.Forms.TextBox tBoxGCMin;
        private System.Windows.Forms.TextBox tBoxNoniusMax;
        private System.Windows.Forms.TextBox tBoxPHErrMax;
        private System.Windows.Forms.TextBox tBoxVOSCErrMax;
        private System.Windows.Forms.TextBox tBoxVOSSErrMax;
        private System.Windows.Forms.TextBox tBoxGXErrMax;
        private System.Windows.Forms.TextBox tBoxPHMax;
        private System.Windows.Forms.TextBox tBoxVOSCMax;
        private System.Windows.Forms.TextBox tBoxVOSSMax;
        private System.Windows.Forms.TextBox tBoxGXMax;
        private System.Windows.Forms.TextBox tBoxGFMax;
        private System.Windows.Forms.TextBox tBoxGCMax;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}