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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainProgram));
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
            this.btnStop = new System.Windows.Forms.Button();
            this.lblPlayer = new System.Windows.Forms.Label();
            this.cmbPlayers = new System.Windows.Forms.ComboBox();
            this.btnManual = new System.Windows.Forms.Button();
            this.btnAutomatic = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblAngleRight = new System.Windows.Forms.Label();
            this.lblAngleLeft = new System.Windows.Forms.Label();
            this.lblBackUpper = new System.Windows.Forms.Label();
            this.lblLeftBack = new System.Windows.Forms.Label();
            this.lblRightBack = new System.Windows.Forms.Label();
            this.lblRightFront = new System.Windows.Forms.Label();
            this.lblFrontLower = new System.Windows.Forms.Label();
            this.lblLeftFront = new System.Windows.Forms.Label();
            this.lblBackLower = new System.Windows.Forms.Label();
            this.lblFrontUpper = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.cmbChart = new System.Windows.Forms.ComboBox();
            this._chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
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
            this.lblLeftDetect = new System.Windows.Forms.Label();
            this.lblRightDetect = new System.Windows.Forms.Label();
            this.lblSpeedMid = new System.Windows.Forms.Label();
            this.lblDistanceMid = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rbtnSpeed4 = new System.Windows.Forms.RadioButton();
            this.rbtnSpeed3 = new System.Windows.Forms.RadioButton();
            this.rbtnSpeed2 = new System.Windows.Forms.RadioButton();
            this.rbtnSpeed1 = new System.Windows.Forms.RadioButton();
            this.btnSend = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox5.SuspendLayout();
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
            this.groupBox1.Location = new System.Drawing.Point(954, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(438, 177);
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
            this.lblBaudRate.Size = new System.Drawing.Size(55, 23);
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
            this.txtOutput.Size = new System.Drawing.Size(426, 306);
            this.txtOutput.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtOutput);
            this.groupBox2.Location = new System.Drawing.Point(954, 378);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(438, 340);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Styrbeslut";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnStop);
            this.groupBox3.Controls.Add(this.lblPlayer);
            this.groupBox3.Controls.Add(this.cmbPlayers);
            this.groupBox3.Controls.Add(this.btnManual);
            this.groupBox3.Controls.Add(this.btnAutomatic);
            this.groupBox3.Location = new System.Drawing.Point(1093, 206);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(299, 110);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Styrning";
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.LightCoral;
            this.btnStop.Location = new System.Drawing.Point(22, 80);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(99, 24);
            this.btnStop.TabIndex = 10;
            this.btnStop.Text = "STOP";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // lblPlayer
            // 
            this.lblPlayer.AutoSize = true;
            this.lblPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayer.Location = new System.Drawing.Point(182, 68);
            this.lblPlayer.Name = "lblPlayer";
            this.lblPlayer.Size = new System.Drawing.Size(50, 16);
            this.lblPlayer.TabIndex = 9;
            this.lblPlayer.Text = "Player:";
            // 
            // cmbPlayers
            // 
            this.cmbPlayers.FormattingEnabled = true;
            this.cmbPlayers.Location = new System.Drawing.Point(238, 67);
            this.cmbPlayers.Name = "cmbPlayers";
            this.cmbPlayers.Size = new System.Drawing.Size(42, 21);
            this.cmbPlayers.TabIndex = 8;
            // 
            // btnManual
            // 
            this.btnManual.Location = new System.Drawing.Point(181, 28);
            this.btnManual.Name = "btnManual";
            this.btnManual.Size = new System.Drawing.Size(99, 31);
            this.btnManual.TabIndex = 1;
            this.btnManual.Text = "Manuellt";
            this.btnManual.UseVisualStyleBackColor = true;
            this.btnManual.Click += new System.EventHandler(this.btnManual_Click);
            // 
            // btnAutomatic
            // 
            this.btnAutomatic.Location = new System.Drawing.Point(22, 28);
            this.btnAutomatic.Name = "btnAutomatic";
            this.btnAutomatic.Size = new System.Drawing.Size(99, 31);
            this.btnAutomatic.TabIndex = 0;
            this.btnAutomatic.Text = "Autonomt";
            this.btnAutomatic.UseVisualStyleBackColor = true;
            this.btnAutomatic.Click += new System.EventHandler(this.btnAutomatic_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblAngleRight);
            this.groupBox4.Controls.Add(this.lblAngleLeft);
            this.groupBox4.Controls.Add(this.lblBackUpper);
            this.groupBox4.Controls.Add(this.lblLeftBack);
            this.groupBox4.Controls.Add(this.lblRightBack);
            this.groupBox4.Controls.Add(this.lblRightFront);
            this.groupBox4.Controls.Add(this.lblFrontLower);
            this.groupBox4.Controls.Add(this.lblLeftFront);
            this.groupBox4.Controls.Add(this.lblBackLower);
            this.groupBox4.Controls.Add(this.lblFrontUpper);
            this.groupBox4.Controls.Add(this.pictureBox2);
            this.groupBox4.Controls.Add(this.cmbChart);
            this.groupBox4.Controls.Add(this._chart);
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
            this.groupBox4.Controls.Add(this.lblLeftDetect);
            this.groupBox4.Controls.Add(this.lblRightDetect);
            this.groupBox4.Controls.Add(this.lblSpeedMid);
            this.groupBox4.Controls.Add(this.lblDistanceMid);
            this.groupBox4.Controls.Add(this.pictureBox1);
            this.groupBox4.Location = new System.Drawing.Point(18, 23);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(930, 775);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Diverse sensorinformation";
            // 
            // lblAngleRight
            // 
            this.lblAngleRight.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblAngleRight.Location = new System.Drawing.Point(850, 202);
            this.lblAngleRight.Name = "lblAngleRight";
            this.lblAngleRight.Size = new System.Drawing.Size(50, 15);
            this.lblAngleRight.TabIndex = 37;
            this.lblAngleRight.Text = "label4";
            // 
            // lblAngleLeft
            // 
            this.lblAngleLeft.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblAngleLeft.Location = new System.Drawing.Point(850, 175);
            this.lblAngleLeft.Name = "lblAngleLeft";
            this.lblAngleLeft.Size = new System.Drawing.Size(50, 15);
            this.lblAngleLeft.TabIndex = 36;
            this.lblAngleLeft.Text = "label4";
            // 
            // lblBackUpper
            // 
            this.lblBackUpper.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBackUpper.Location = new System.Drawing.Point(137, 365);
            this.lblBackUpper.Name = "lblBackUpper";
            this.lblBackUpper.Size = new System.Drawing.Size(50, 15);
            this.lblBackUpper.TabIndex = 31;
            this.lblBackUpper.Text = "label4";
            // 
            // lblLeftBack
            // 
            this.lblLeftBack.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLeftBack.Location = new System.Drawing.Point(29, 321);
            this.lblLeftBack.Name = "lblLeftBack";
            this.lblLeftBack.Size = new System.Drawing.Size(50, 15);
            this.lblLeftBack.TabIndex = 30;
            this.lblLeftBack.Text = "label4";
            // 
            // lblRightBack
            // 
            this.lblRightBack.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRightBack.Location = new System.Drawing.Point(237, 321);
            this.lblRightBack.Name = "lblRightBack";
            this.lblRightBack.Size = new System.Drawing.Size(50, 15);
            this.lblRightBack.TabIndex = 29;
            this.lblRightBack.Text = "label4";
            // 
            // lblRightFront
            // 
            this.lblRightFront.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRightFront.Location = new System.Drawing.Point(240, 142);
            this.lblRightFront.Name = "lblRightFront";
            this.lblRightFront.Size = new System.Drawing.Size(50, 15);
            this.lblRightFront.TabIndex = 27;
            this.lblRightFront.Text = "label4";
            // 
            // lblFrontLower
            // 
            this.lblFrontLower.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFrontLower.Location = new System.Drawing.Point(137, 37);
            this.lblFrontLower.Name = "lblFrontLower";
            this.lblFrontLower.Size = new System.Drawing.Size(50, 15);
            this.lblFrontLower.TabIndex = 26;
            this.lblFrontLower.Text = "label4";
            // 
            // lblLeftFront
            // 
            this.lblLeftFront.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLeftFront.Location = new System.Drawing.Point(29, 142);
            this.lblLeftFront.Name = "lblLeftFront";
            this.lblLeftFront.Size = new System.Drawing.Size(50, 15);
            this.lblLeftFront.TabIndex = 25;
            this.lblLeftFront.Text = "label4";
            // 
            // lblBackLower
            // 
            this.lblBackLower.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBackLower.Location = new System.Drawing.Point(137, 423);
            this.lblBackLower.Name = "lblBackLower";
            this.lblBackLower.Size = new System.Drawing.Size(50, 15);
            this.lblBackLower.TabIndex = 24;
            this.lblBackLower.Text = "label4";
            // 
            // lblFrontUpper
            // 
            this.lblFrontUpper.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFrontUpper.Location = new System.Drawing.Point(137, 92);
            this.lblFrontUpper.Name = "lblFrontUpper";
            this.lblFrontUpper.Size = new System.Drawing.Size(50, 15);
            this.lblFrontUpper.TabIndex = 23;
            this.lblFrontUpper.Text = "label4";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(6, 37);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(308, 401);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 28;
            this.pictureBox2.TabStop = false;
            // 
            // cmbChart
            // 
            this.cmbChart.FormattingEnabled = true;
            this.cmbChart.Location = new System.Drawing.Point(91, 483);
            this.cmbChart.Name = "cmbChart";
            this.cmbChart.Size = new System.Drawing.Size(121, 21);
            this.cmbChart.TabIndex = 21;
            this.cmbChart.SelectedIndexChanged += new System.EventHandler(this.cmbChart_SelectedIndexChanged);
            // 
            // _chart
            // 
            this._chart.Location = new System.Drawing.Point(218, 483);
            this._chart.Name = "_chart";
            this._chart.Size = new System.Drawing.Size(572, 280);
            this._chart.TabIndex = 20;
            this._chart.Text = "chart1";
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(714, 203);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(120, 15);
            this.label17.TabIndex = 17;
            this.label17.Text = "Vinkel vägg höger:";
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(714, 176);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(120, 15);
            this.label16.TabIndex = 16;
            this.label16.Text = "Vinkel vägg vänster:";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(714, 93);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(120, 15);
            this.label15.TabIndex = 15;
            this.label15.Text = "Hindertyp bak: ";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(714, 64);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(120, 15);
            this.label14.TabIndex = 14;
            this.label14.Text = "Hindertyp fram: ";
            // 
            // lblDistRight
            // 
            this.lblDistRight.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDistRight.Location = new System.Drawing.Point(632, 229);
            this.lblDistRight.Name = "lblDistRight";
            this.lblDistRight.Size = new System.Drawing.Size(50, 15);
            this.lblDistRight.TabIndex = 13;
            this.lblDistRight.Text = "label4";
            // 
            // lblDistFront
            // 
            this.lblDistFront.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDistFront.Location = new System.Drawing.Point(505, 37);
            this.lblDistFront.Name = "lblDistFront";
            this.lblDistFront.Size = new System.Drawing.Size(50, 15);
            this.lblDistFront.TabIndex = 12;
            this.lblDistFront.Text = "label4";
            // 
            // lblDistLeft
            // 
            this.lblDistLeft.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDistLeft.Location = new System.Drawing.Point(374, 229);
            this.lblDistLeft.Name = "lblDistLeft";
            this.lblDistLeft.Size = new System.Drawing.Size(50, 15);
            this.lblDistLeft.TabIndex = 11;
            this.lblDistLeft.Text = "label4";
            // 
            // lblRearDetect
            // 
            this.lblRearDetect.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRearDetect.Location = new System.Drawing.Point(850, 92);
            this.lblRearDetect.Name = "lblRearDetect";
            this.lblRearDetect.Size = new System.Drawing.Size(50, 15);
            this.lblRearDetect.TabIndex = 10;
            this.lblRearDetect.Text = "label4";
            // 
            // lblDistRear
            // 
            this.lblDistRear.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDistRear.Location = new System.Drawing.Point(505, 423);
            this.lblDistRear.Name = "lblDistRear";
            this.lblDistRear.Size = new System.Drawing.Size(50, 15);
            this.lblDistRear.TabIndex = 9;
            this.lblDistRear.Text = "label4";
            // 
            // lblFrontDetect
            // 
            this.lblFrontDetect.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFrontDetect.Location = new System.Drawing.Point(850, 63);
            this.lblFrontDetect.Name = "lblFrontDetect";
            this.lblFrontDetect.Size = new System.Drawing.Size(50, 15);
            this.lblFrontDetect.TabIndex = 8;
            this.lblFrontDetect.Text = "label4";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(714, 149);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Typ vänster: ";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(714, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Typ höger: ";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(714, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Derivatan av avvikelsen";
            // 
            // lblLeftDetect
            // 
            this.lblLeftDetect.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLeftDetect.Location = new System.Drawing.Point(850, 147);
            this.lblLeftDetect.Name = "lblLeftDetect";
            this.lblLeftDetect.Size = new System.Drawing.Size(50, 15);
            this.lblLeftDetect.TabIndex = 3;
            this.lblLeftDetect.Text = "label4";
            // 
            // lblRightDetect
            // 
            this.lblRightDetect.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRightDetect.Location = new System.Drawing.Point(850, 120);
            this.lblRightDetect.Name = "lblRightDetect";
            this.lblRightDetect.Size = new System.Drawing.Size(50, 15);
            this.lblRightDetect.TabIndex = 2;
            this.lblRightDetect.Text = "label4";
            // 
            // lblSpeedMid
            // 
            this.lblSpeedMid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSpeedMid.Location = new System.Drawing.Point(850, 36);
            this.lblSpeedMid.Name = "lblSpeedMid";
            this.lblSpeedMid.Size = new System.Drawing.Size(50, 15);
            this.lblSpeedMid.TabIndex = 1;
            this.lblSpeedMid.Text = "label4";
            // 
            // lblDistanceMid
            // 
            this.lblDistanceMid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDistanceMid.Location = new System.Drawing.Point(505, 229);
            this.lblDistanceMid.Name = "lblDistanceMid";
            this.lblDistanceMid.Size = new System.Drawing.Size(50, 15);
            this.lblDistanceMid.TabIndex = 0;
            this.lblDistanceMid.Text = "label4";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(374, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(308, 401);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnSend);
            this.groupBox5.Controls.Add(this.rbtnSpeed4);
            this.groupBox5.Controls.Add(this.rbtnSpeed3);
            this.groupBox5.Controls.Add(this.rbtnSpeed2);
            this.groupBox5.Controls.Add(this.rbtnSpeed1);
            this.groupBox5.Location = new System.Drawing.Point(976, 322);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(416, 50);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Hastighet";
            // 
            // rbtnSpeed4
            // 
            this.rbtnSpeed4.AutoSize = true;
            this.rbtnSpeed4.Location = new System.Drawing.Point(227, 22);
            this.rbtnSpeed4.Name = "rbtnSpeed4";
            this.rbtnSpeed4.Size = new System.Drawing.Size(31, 17);
            this.rbtnSpeed4.TabIndex = 5;
            this.rbtnSpeed4.TabStop = true;
            this.rbtnSpeed4.Text = "4";
            this.rbtnSpeed4.UseVisualStyleBackColor = true;
            // 
            // rbtnSpeed3
            // 
            this.rbtnSpeed3.AutoSize = true;
            this.rbtnSpeed3.Location = new System.Drawing.Point(158, 22);
            this.rbtnSpeed3.Name = "rbtnSpeed3";
            this.rbtnSpeed3.Size = new System.Drawing.Size(31, 17);
            this.rbtnSpeed3.TabIndex = 4;
            this.rbtnSpeed3.TabStop = true;
            this.rbtnSpeed3.Text = "3";
            this.rbtnSpeed3.UseVisualStyleBackColor = true;
            // 
            // rbtnSpeed2
            // 
            this.rbtnSpeed2.AutoSize = true;
            this.rbtnSpeed2.Location = new System.Drawing.Point(81, 22);
            this.rbtnSpeed2.Name = "rbtnSpeed2";
            this.rbtnSpeed2.Size = new System.Drawing.Size(31, 17);
            this.rbtnSpeed2.TabIndex = 3;
            this.rbtnSpeed2.TabStop = true;
            this.rbtnSpeed2.Text = "2";
            this.rbtnSpeed2.UseVisualStyleBackColor = true;
            // 
            // rbtnSpeed1
            // 
            this.rbtnSpeed1.AutoSize = true;
            this.rbtnSpeed1.Location = new System.Drawing.Point(13, 22);
            this.rbtnSpeed1.Name = "rbtnSpeed1";
            this.rbtnSpeed1.Size = new System.Drawing.Size(31, 17);
            this.rbtnSpeed1.TabIndex = 2;
            this.rbtnSpeed1.TabStop = true;
            this.rbtnSpeed1.Text = "1";
            this.rbtnSpeed1.UseVisualStyleBackColor = true;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(298, 18);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 6;
            this.btnSend.Text = "Skicka";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // MainProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1404, 805);
            this.Controls.Add(this.groupBox5);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
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
        private System.Windows.Forms.DataVisualization.Charting.Chart _chart;
        private System.Windows.Forms.ComboBox cmbChart;
        private System.Windows.Forms.Label lblPlayer;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblRightFront;
        private System.Windows.Forms.Label lblFrontLower;
        private System.Windows.Forms.Label lblLeftFront;
        private System.Windows.Forms.Label lblBackLower;
        private System.Windows.Forms.Label lblFrontUpper;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblRightBack;
        private System.Windows.Forms.Label lblLeftBack;
        private System.Windows.Forms.Label lblBackUpper;
        private System.Windows.Forms.Label lblAngleRight;
        private System.Windows.Forms.Label lblAngleLeft;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.RadioButton rbtnSpeed4;
        private System.Windows.Forms.RadioButton rbtnSpeed3;
        private System.Windows.Forms.RadioButton rbtnSpeed2;
        private System.Windows.Forms.RadioButton rbtnSpeed1;
        private System.Windows.Forms.Button btnSend;
    }
}

