namespace WISH_client
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
            this.btnAutomatic = new System.Windows.Forms.Button();
            this.btnManual = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSpeed = new System.Windows.Forms.TextBox();
            this.btnUpdateSpeed = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            this.txtOutput.Location = new System.Drawing.Point(25, 372);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.Size = new System.Drawing.Size(631, 199);
            this.txtOutput.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(18, 348);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(646, 227);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Info (Tänkte att man skulle kunna slänga ut alla styrbeslut som en sträng i rutan" +
    " nedan)";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnUpdateSpeed);
            this.groupBox3.Controls.Add(this.txtSpeed);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.btnManual);
            this.groupBox3.Controls.Add(this.btnAutomatic);
            this.groupBox3.Location = new System.Drawing.Point(720, 262);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(493, 254);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Styrning";
            // 
            // btnAutomatic
            // 
            this.btnAutomatic.Location = new System.Drawing.Point(64, 200);
            this.btnAutomatic.Name = "btnAutomatic";
            this.btnAutomatic.Size = new System.Drawing.Size(155, 40);
            this.btnAutomatic.TabIndex = 0;
            this.btnAutomatic.Text = "Autonomt";
            this.btnAutomatic.UseVisualStyleBackColor = true;
            // 
            // btnManual
            // 
            this.btnManual.Location = new System.Drawing.Point(285, 200);
            this.btnManual.Name = "btnManual";
            this.btnManual.Size = new System.Drawing.Size(155, 40);
            this.btnManual.TabIndex = 1;
            this.btnManual.Text = "Manuellt";
            this.btnManual.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Kanske lite info här om vilka knappar som används till vad";
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(18, 23);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(646, 303);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Diverse sensorinformation";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Hastighet (1-4): ";
            // 
            // txtSpeed
            // 
            this.txtSpeed.Location = new System.Drawing.Point(100, 163);
            this.txtSpeed.Name = "txtSpeed";
            this.txtSpeed.Size = new System.Drawing.Size(58, 20);
            this.txtSpeed.TabIndex = 4;
            // 
            // btnUpdateSpeed
            // 
            this.btnUpdateSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateSpeed.Location = new System.Drawing.Point(164, 163);
            this.btnUpdateSpeed.Name = "btnUpdateSpeed";
            this.btnUpdateSpeed.Size = new System.Drawing.Size(71, 20);
            this.btnUpdateSpeed.TabIndex = 5;
            this.btnUpdateSpeed.Text = "Uppdatera";
            this.btnUpdateSpeed.UseVisualStyleBackColor = true;
            // 
            // MainProgram
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1225, 593);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainProgram";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnManual;
        private System.Windows.Forms.Button btnAutomatic;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtSpeed;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnUpdateSpeed;
    }
}

