namespace DKAS
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
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.Baudrate = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.kn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cBaud = new System.Windows.Forms.ComboBox();
            this.cCOM = new System.Windows.Forms.ComboBox();
            this.ex = new System.Windows.Forms.Button();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lbUtra = new System.Windows.Forms.Label();
            this.tb_Utra = new System.Windows.Forms.TextBox();
            this.situa = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.bt_run = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.receiveflow = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.luuluongdat = new System.Windows.Forms.TextBox();
            this.bt_mode = new System.Windows.Forms.Button();
            this.bt_send = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // Baudrate
            // 
            this.Baudrate.AutoSize = true;
            this.Baudrate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Baudrate.Location = new System.Drawing.Point(20, 55);
            this.Baudrate.Name = "Baudrate";
            this.Baudrate.Size = new System.Drawing.Size(74, 17);
            this.Baudrate.TabIndex = 5;
            this.Baudrate.Text = "Baudrate";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "COM";
            this.label2.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // kn
            // 
            this.kn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kn.ForeColor = System.Drawing.Color.Green;
            this.kn.Location = new System.Drawing.Point(25, 90);
            this.kn.Name = "kn";
            this.kn.Size = new System.Drawing.Size(88, 28);
            this.kn.TabIndex = 7;
            this.kn.Text = "Connect";
            this.kn.UseVisualStyleBackColor = true;
            this.kn.Click += new System.EventHandler(this.kn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cBaud);
            this.groupBox1.Controls.Add(this.cCOM);
            this.groupBox1.Controls.Add(this.ex);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Baudrate);
            this.groupBox1.Controls.Add(this.kn);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(16, 67);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(266, 125);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "COMMUNICATION";
            // 
            // cBaud
            // 
            this.cBaud.FormattingEnabled = true;
            this.cBaud.Location = new System.Drawing.Point(133, 55);
            this.cBaud.Name = "cBaud";
            this.cBaud.Size = new System.Drawing.Size(97, 24);
            this.cBaud.TabIndex = 13;
            // 
            // cCOM
            // 
            this.cCOM.FormattingEnabled = true;
            this.cCOM.Location = new System.Drawing.Point(134, 24);
            this.cCOM.Name = "cCOM";
            this.cCOM.Size = new System.Drawing.Size(96, 24);
            this.cCOM.TabIndex = 12;
            this.cCOM.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // ex
            // 
            this.ex.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ex.ForeColor = System.Drawing.Color.Red;
            this.ex.Location = new System.Drawing.Point(142, 90);
            this.ex.Name = "ex";
            this.ex.Size = new System.Drawing.Size(88, 28);
            this.ex.TabIndex = 9;
            this.ex.Text = "Exit";
            this.ex.UseVisualStyleBackColor = true;
            this.ex.Click += new System.EventHandler(this.button5_Click);
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(297, 146);
            this.zedGraphControl1.Margin = new System.Windows.Forms.Padding(6);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(599, 349);
            this.zedGraphControl1.TabIndex = 12;
            this.zedGraphControl1.UseExtendedPrintDialog = true;
            this.zedGraphControl1.Load += new System.EventHandler(this.zedGraphControl1_Load);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(356, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 17);
            this.label6.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(499, 501);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(135, 20);
            this.label8.TabIndex = 16;
            this.label8.Text = "Đồ thị lưu lượng";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.Image = global::DKAS.Properties.Resources.Ảnh_chụp_màn_hình_2024_05_18_102627;
            this.pictureBox1.InitialImage = global::DKAS.Properties.Resources.Ảnh_chụp_màn_hình_2024_05_18_102015;
            this.pictureBox1.Location = new System.Drawing.Point(783, 43);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(113, 94);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lbUtra);
            this.groupBox4.Controls.Add(this.tb_Utra);
            this.groupBox4.Controls.Add(this.situa);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.bt_run);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.receiveflow);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(16, 215);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(266, 140);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Situation";
            // 
            // lbUtra
            // 
            this.lbUtra.AutoSize = true;
            this.lbUtra.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUtra.Location = new System.Drawing.Point(9, 98);
            this.lbUtra.Name = "lbUtra";
            this.lbUtra.Size = new System.Drawing.Size(85, 17);
            this.lbUtra.TabIndex = 19;
            this.lbUtra.Text = "Duty Cycle";
            this.lbUtra.Click += new System.EventHandler(this.label7_Click);
            // 
            // tb_Utra
            // 
            this.tb_Utra.Location = new System.Drawing.Point(119, 95);
            this.tb_Utra.Name = "tb_Utra";
            this.tb_Utra.Size = new System.Drawing.Size(78, 22);
            this.tb_Utra.TabIndex = 18;
            this.tb_Utra.Text = "null";
            this.tb_Utra.TextChanged += new System.EventHandler(this.tb_Utra_TextChanged);
            // 
            // situa
            // 
            this.situa.AutoSize = true;
            this.situa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.situa.ForeColor = System.Drawing.Color.Crimson;
            this.situa.Location = new System.Drawing.Point(219, 28);
            this.situa.Name = "situa";
            this.situa.Size = new System.Drawing.Size(38, 17);
            this.situa.TabIndex = 17;
            this.situa.Text = "OFF";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(202, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 17);
            this.label9.TabIndex = 15;
            this.label9.Text = "[ml/min]";
            this.label9.Click += new System.EventHandler(this.label9_Click_1);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(9, 63);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(104, 17);
            this.label12.TabIndex = 13;
            this.label12.Text = "Current Flow ";
            // 
            // bt_run
            // 
            this.bt_run.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_run.Location = new System.Drawing.Point(122, 20);
            this.bt_run.Name = "bt_run";
            this.bt_run.Size = new System.Drawing.Size(75, 32);
            this.bt_run.TabIndex = 3;
            this.bt_run.Text = "ON/OFF\r\n";
            this.bt_run.UseVisualStyleBackColor = true;
            this.bt_run.Click += new System.EventHandler(this.bt_run_Click_1);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(20, 28);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 17);
            this.label13.TabIndex = 11;
            this.label13.Text = "Pump";
            // 
            // receiveflow
            // 
            this.receiveflow.Location = new System.Drawing.Point(119, 60);
            this.receiveflow.Name = "receiveflow";
            this.receiveflow.Size = new System.Drawing.Size(78, 22);
            this.receiveflow.TabIndex = 11;
            this.receiveflow.Text = "null";
            this.receiveflow.TextChanged += new System.EventHandler(this.receiveflow_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.luuluongdat);
            this.groupBox3.Controls.Add(this.bt_mode);
            this.groupBox3.Controls.Add(this.bt_send);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(16, 376);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(266, 119);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "FLOW SET UP ";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(197, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 17;
            this.label3.Text = "[ml/min]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Flow setting ";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // luuluongdat
            // 
            this.luuluongdat.Location = new System.Drawing.Point(119, 28);
            this.luuluongdat.Name = "luuluongdat";
            this.luuluongdat.Size = new System.Drawing.Size(78, 22);
            this.luuluongdat.TabIndex = 2;
            this.luuluongdat.Text = "null";
            // 
            // bt_mode
            // 
            this.bt_mode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_mode.Location = new System.Drawing.Point(154, 66);
            this.bt_mode.Name = "bt_mode";
            this.bt_mode.Size = new System.Drawing.Size(75, 32);
            this.bt_mode.TabIndex = 4;
            this.bt_mode.Text = "Auto";
            this.bt_mode.UseVisualStyleBackColor = true;
            this.bt_mode.Click += new System.EventHandler(this.bt_mode_Click);
            // 
            // bt_send
            // 
            this.bt_send.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_send.Location = new System.Drawing.Point(28, 66);
            this.bt_send.Name = "bt_send";
            this.bt_send.Size = new System.Drawing.Size(75, 32);
            this.bt_send.TabIndex = 0;
            this.bt_send.Text = "Send\r\n";
            this.bt_send.UseVisualStyleBackColor = true;
            this.bt_send.Click += new System.EventHandler(this.bt_send_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Brown;
            this.label1.Location = new System.Drawing.Point(176, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(601, 36);
            this.label1.TabIndex = 19;
            this.label1.Text = "WATER FLOW CONTROLLING SYSTEM";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 548);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.zedGraphControl1);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label Baudrate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button kn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button ex;
        private System.Windows.Forms.ComboBox cBaud;
        private System.Windows.Forms.ComboBox cCOM;
        private System.Windows.Forms.PictureBox pictureBox1;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bt_run;
        private System.Windows.Forms.TextBox luuluongdat;
        private System.Windows.Forms.Button bt_mode;
        private System.Windows.Forms.Button bt_send;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label situa;
        private System.Windows.Forms.TextBox receiveflow;
        private System.Windows.Forms.Label lbUtra;
        private System.Windows.Forms.TextBox tb_Utra;
    }
}

