﻿namespace WISH_client
{
    partial class MainProgram
    {        
        private System.ComponentModel.IContainer components = null;

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
            this.cmbComPorts = new System.Windows.Forms.ComboBox();
            this.btnComStart = new System.Windows.Forms.Button();
            this.lblCOM = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnComUpdate = new System.Windows.Forms.Button();
            this.btnComStop = new System.Windows.Forms.Button();
            this.lblBaudRate = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnManual = new System.Windows.Forms.Button();
            this.btnAutomatic = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cmbChart = new System.Windows.Forms.ComboBox();
            this._chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblDistRight = new System.Windows.Forms.Label();
            this.lblDistFront = new System.Windows.Forms.Label();
            this.lblDistLeft = new System.Windows.Forms.Label();
            this.lblRearDetect = new System.Windows.Forms.Label();
            this.lblDistRear = new System.Windows.Forms.Label();
            this.lblFrontDetect = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblLeftDetect = new System.Windows.Forms.Label();
            this.lblRightDetect = new System.Windows.Forms.Label();
            this.lblSpeedMid = new System.Windows.Forms.Label();
            this.lblDistanceMid = new System.Windows.Forms.Label();
            this.cmbPlayers = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._chart)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbComPorts
            // 
            this.cmbComPorts.FormattingEnabled = true;
            this.cmbComPorts.Location = new System.Drawing.Point(68, 33);
            this.cmbComPorts.Name = "cmbComPorts";
            this.cmbComPorts.Size = new System.Drawing.Size(104, 21);
            this.cmbComPorts.TabIndex = 0;
            // 
            // btnComStart
            // 
            this.btnComStart.Location = new System.Drawing.Point(36, 109);
            this.btnComStart.Name = "btnComStart";
            this.btnComStart.Size = new System.Drawing.Size(182, 41);
            this.btnComStart.TabIndex = 1;
            this.btnComStart.Text = "Starta";
            this.btnComStart.UseVisualStyleBackColor = true;
            this.btnComStart.Click += new System.EventHandler(this.btnComStart_Click);
            // 
            // lblCOM
            // 
            this.lblCOM.AutoSize = true;
            this.lblCOM.Location = new System.Drawing.Point(6, 37);
            this.lblCOM.Name = "lblCOM";
            this.lblCOM.Size = new System.Drawing.Size(56, 13);
            this.lblCOM.TabIndex = 2;
            this.lblCOM.Text = "COM Port:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnComUpdate);
            this.groupBox1.Controls.Add(this.btnComStop);
            this.groupBox1.Controls.Add(this.lblBaudRate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnComStart);
            this.groupBox1.Controls.Add(this.cmbComPorts);
            this.groupBox1.Controls.Add(this.lblCOM);
            this.groupBox1.Location = new System.Drawing.Point(766, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(447, 177);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bluetooth";
            // 
            // btnComUpdate
            // 
            this.btnComUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComUpdate.Location = new System.Drawing.Point(191, 33);
            this.btnComUpdate.Name = "btnComUpdate";
            this.btnComUpdate.Size = new System.Drawing.Size(95, 21);
            this.btnComUpdate.TabIndex = 5;
            this.btnComUpdate.Text = "Uppdatera";
            this.btnComUpdate.UseVisualStyleBackColor = true;
            this.btnComUpdate.Click += new System.EventHandler(this.btnCOMUpdate_Click);
            // 
            // btnComStop
            // 
            this.btnComStop.Location = new System.Drawing.Point(238, 109);
            this.btnComStop.Name = "btnComStop";
            this.btnComStop.Size = new System.Drawing.Size(167, 41);
            this.btnComStop.TabIndex = 4;
            this.btnComStop.Text = "Stop";
            this.btnComStop.UseVisualStyleBackColor = true;
            this.btnComStop.Click += new System.EventHandler(this.btnCOMStop_Click);
            // 
            // lblBaudRate
            // 
            this.lblBaudRate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBaudRate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBaudRate.Location = new System.Drawing.Point(69, 68);
            this.lblBaudRate.Name = "lblBaudRate";
            this.lblBaudRate.Size = new System.Drawing.Size(64, 23);
            this.lblBaudRate.TabIndex = 4;
            this.lblBaudRate.Text = "label1";
            this.lblBaudRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Baud rate:";
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(6, 22);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.Size = new System.Drawing.Size(631, 199);
            this.txtOutput.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtOutput);
            this.groupBox2.Location = new System.Drawing.Point(25, 516);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(646, 227);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Info (Tänkte att man skulle kunna slänga ut alla styrbeslut som en sträng i rutan" +
    " nedan)";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.cmbPlayers);
            this.groupBox3.Controls.Add(this.btnManual);
            this.groupBox3.Controls.Add(this.btnAutomatic);
            this.groupBox3.Location = new System.Drawing.Point(720, 262);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(493, 152);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Styrning";
            // 
            // btnManual
            // 
            this.btnManual.Location = new System.Drawing.Point(284, 34);
            this.btnManual.Name = "btnManual";
            this.btnManual.Size = new System.Drawing.Size(155, 40);
            this.btnManual.TabIndex = 1;
            this.btnManual.Text = "Manuellt";
            this.btnManual.UseVisualStyleBackColor = true;
            this.btnManual.Click += new System.EventHandler(this.btnManual_Click);
            // 
            // btnAutomatic
            // 
            this.btnAutomatic.Location = new System.Drawing.Point(63, 34);
            this.btnAutomatic.Name = "btnAutomatic";
            this.btnAutomatic.Size = new System.Drawing.Size(155, 40);
            this.btnAutomatic.TabIndex = 0;
            this.btnAutomatic.Text = "Autonomt";
            this.btnAutomatic.UseVisualStyleBackColor = true;
            this.btnAutomatic.Click += new System.EventHandler(this.btnAutomatic_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cmbChart);
            this.groupBox4.Controls.Add(this._chart);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.lblDistRight);
            this.groupBox4.Controls.Add(this.lblDistFront);
            this.groupBox4.Controls.Add(this.lblDistLeft);
            this.groupBox4.Controls.Add(this.lblRearDetect);
            this.groupBox4.Controls.Add(this.lblDistRear);
            this.groupBox4.Controls.Add(this.lblFrontDetect);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.lblLeftDetect);
            this.groupBox4.Controls.Add(this.lblRightDetect);
            this.groupBox4.Controls.Add(this.lblSpeedMid);
            this.groupBox4.Controls.Add(this.lblDistanceMid);
            this.groupBox4.Location = new System.Drawing.Point(18, 23);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(646, 479);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Diverse sensorinformation";
            // 
            // cmbChart
            // 
            this.cmbChart.FormattingEnabled = true;
            this.cmbChart.Location = new System.Drawing.Point(519, 120);
            this.cmbChart.Name = "cmbChart";
            this.cmbChart.Size = new System.Drawing.Size(121, 21);
            this.cmbChart.TabIndex = 21;
            this.cmbChart.SelectedIndexChanged += new System.EventHandler(this.cmbChart_SelectedIndexChanged);
            // 
            // _chart
            // 
            this._chart.Location = new System.Drawing.Point(27, 161);
            this._chart.Name = "_chart";
            this._chart.Size = new System.Drawing.Size(572, 301);
            this._chart.TabIndex = 20;
            this._chart.Text = "chart1";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(39, 132);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(120, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Avstånd fram: ";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(296, 133);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(120, 15);
            this.label8.TabIndex = 18;
            this.label8.Text = "Avstånd vänster: ";
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(296, 29);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(120, 15);
            this.label17.TabIndex = 17;
            this.label17.Text = "Avstånd bak: ";
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(296, 107);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(120, 15);
            this.label16.TabIndex = 16;
            this.label16.Text = "Avstånd höger: ";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(296, 81);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(120, 15);
            this.label15.TabIndex = 15;
            this.label15.Text = "Typ bak: ";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(296, 55);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(120, 15);
            this.label14.TabIndex = 14;
            this.label14.Text = "Typ fram: ";
            // 
            // lblDistRight
            // 
            this.lblDistRight.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDistRight.Location = new System.Drawing.Point(431, 106);
            this.lblDistRight.Name = "lblDistRight";
            this.lblDistRight.Size = new System.Drawing.Size(50, 15);
            this.lblDistRight.TabIndex = 13;
            this.lblDistRight.Text = "label4";
            // 
            // lblDistFront
            // 
            this.lblDistFront.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDistFront.Location = new System.Drawing.Point(186, 131);
            this.lblDistFront.Name = "lblDistFront";
            this.lblDistFront.Size = new System.Drawing.Size(50, 15);
            this.lblDistFront.TabIndex = 12;
            this.lblDistFront.Text = "label4";
            // 
            // lblDistLeft
            // 
            this.lblDistLeft.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDistLeft.Location = new System.Drawing.Point(431, 131);
            this.lblDistLeft.Name = "lblDistLeft";
            this.lblDistLeft.Size = new System.Drawing.Size(50, 15);
            this.lblDistLeft.TabIndex = 11;
            this.lblDistLeft.Text = "label4";
            // 
            // lblRearDetect
            // 
            this.lblRearDetect.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRearDetect.Location = new System.Drawing.Point(431, 81);
            this.lblRearDetect.Name = "lblRearDetect";
            this.lblRearDetect.Size = new System.Drawing.Size(50, 15);
            this.lblRearDetect.TabIndex = 10;
            this.lblRearDetect.Text = "label4";
            // 
            // lblDistRear
            // 
            this.lblDistRear.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDistRear.Location = new System.Drawing.Point(431, 31);
            this.lblDistRear.Name = "lblDistRear";
            this.lblDistRear.Size = new System.Drawing.Size(50, 15);
            this.lblDistRear.TabIndex = 9;
            this.lblDistRear.Text = "label4";
            // 
            // lblFrontDetect
            // 
            this.lblFrontDetect.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFrontDetect.Location = new System.Drawing.Point(431, 56);
            this.lblFrontDetect.Name = "lblFrontDetect";
            this.lblFrontDetect.Size = new System.Drawing.Size(50, 15);
            this.lblFrontDetect.TabIndex = 8;
            this.lblFrontDetect.Text = "label4";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(41, 107);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Typ vänster: ";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(41, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Typ höger: ";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(39, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Derivatan av avvikelsen";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(39, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Avvikelse från mittlinjen:";
            // 
            // lblLeftDetect
            // 
            this.lblLeftDetect.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLeftDetect.Location = new System.Drawing.Point(186, 106);
            this.lblLeftDetect.Name = "lblLeftDetect";
            this.lblLeftDetect.Size = new System.Drawing.Size(50, 15);
            this.lblLeftDetect.TabIndex = 3;
            this.lblLeftDetect.Text = "label4";
            // 
            // lblRightDetect
            // 
            this.lblRightDetect.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRightDetect.Location = new System.Drawing.Point(186, 81);
            this.lblRightDetect.Name = "lblRightDetect";
            this.lblRightDetect.Size = new System.Drawing.Size(50, 15);
            this.lblRightDetect.TabIndex = 2;
            this.lblRightDetect.Text = "label4";
            // 
            // lblSpeedMid
            // 
            this.lblSpeedMid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSpeedMid.Location = new System.Drawing.Point(186, 56);
            this.lblSpeedMid.Name = "lblSpeedMid";
            this.lblSpeedMid.Size = new System.Drawing.Size(50, 15);
            this.lblSpeedMid.TabIndex = 1;
            this.lblSpeedMid.Text = "label4";
            // 
            // lblDistanceMid
            // 
            this.lblDistanceMid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDistanceMid.Location = new System.Drawing.Point(186, 31);
            this.lblDistanceMid.Name = "lblDistanceMid";
            this.lblDistanceMid.Size = new System.Drawing.Size(50, 15);
            this.lblDistanceMid.TabIndex = 0;
            this.lblDistanceMid.Text = "label4";
            // 
            // cmbPlayers
            // 
            this.cmbPlayers.FormattingEnabled = true;
            this.cmbPlayers.Location = new System.Drawing.Point(322, 90);
            this.cmbPlayers.Name = "cmbPlayers";
            this.cmbPlayers.Size = new System.Drawing.Size(117, 21);
            this.cmbPlayers.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(266, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Player:";
            // 
            // MainProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1225, 767);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainProgram";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._chart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbComPorts;
        private System.Windows.Forms.Button btnComStart;
        private System.Windows.Forms.Label lblCOM;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblBaudRate;
        private System.Windows.Forms.Button btnComUpdate;
        private System.Windows.Forms.Button btnComStop;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnManual;
        private System.Windows.Forms.Button btnAutomatic;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cmbPlayers;
        private System.Windows.Forms.Label lblLeftDetect;
        private System.Windows.Forms.Label lblRightDetect;
        private System.Windows.Forms.Label lblSpeedMid;
        private System.Windows.Forms.Label lblDistanceMid;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblDistRight;
        private System.Windows.Forms.Label lblDistFront;
        private System.Windows.Forms.Label lblDistLeft;
        private System.Windows.Forms.Label lblRearDetect;
        private System.Windows.Forms.Label lblDistRear;
        private System.Windows.Forms.Label lblFrontDetect;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataVisualization.Charting.Chart _chart;
        private System.Windows.Forms.ComboBox cmbChart;
        private System.Windows.Forms.Label label1;
    }
}

