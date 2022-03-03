
namespace ConnorJenkins_ZumoGUI_ProgrmamingTHings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.GBPortControls = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.CBoxBaudRate = new System.Windows.Forms.ComboBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.CBoxComPort = new System.Windows.Forms.ComboBox();
            this.lblStatus1 = new System.Windows.Forms.Label();
            this.LblBaudRate = new System.Windows.Forms.Label();
            this.LblComPort = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.btnForward = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnSTOP = new System.Windows.Forms.Button();
            this.GBManualControls = new System.Windows.Forms.GroupBox();
            this.btnAutomatic = new System.Windows.Forms.Button();
            this.lblCurrentAction = new System.Windows.Forms.Label();
            this.lblAction = new System.Windows.Forms.Label();
            this.lblConnorJenkins = new System.Windows.Forms.Label();
            this.txtUsage = new System.Windows.Forms.TextBox();
            this.btnStopForRoom = new System.Windows.Forms.Button();
            this.btnSearchRoom = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.lblCa = new System.Windows.Forms.Label();
            this.RTBoxReceive = new System.Windows.Forms.RichTextBox();
            this.RTBRoomLog = new System.Windows.Forms.RichTextBox();
            this.LBLRoomLog = new System.Windows.Forms.Label();
            this.GBOutputs = new System.Windows.Forms.GroupBox();
            this.GBPortControls.SuspendLayout();
            this.GBManualControls.SuspendLayout();
            this.GBOutputs.SuspendLayout();
            this.SuspendLayout();
            // 
            // GBPortControls
            // 
            this.GBPortControls.Controls.Add(this.lblStatus);
            this.GBPortControls.Controls.Add(this.btnClose);
            this.GBPortControls.Controls.Add(this.CBoxBaudRate);
            this.GBPortControls.Controls.Add(this.btnOpen);
            this.GBPortControls.Controls.Add(this.CBoxComPort);
            this.GBPortControls.Controls.Add(this.lblStatus1);
            this.GBPortControls.Controls.Add(this.LblBaudRate);
            this.GBPortControls.Controls.Add(this.LblComPort);
            this.GBPortControls.Location = new System.Drawing.Point(12, 12);
            this.GBPortControls.Name = "GBPortControls";
            this.GBPortControls.Size = new System.Drawing.Size(268, 177);
            this.GBPortControls.TabIndex = 0;
            this.GBPortControls.TabStop = false;
            this.GBPortControls.Text = "Port Control";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(123, 84);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(73, 13);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "Disconnected";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(145, 131);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // CBoxBaudRate
            // 
            this.CBoxBaudRate.FormattingEnabled = true;
            this.CBoxBaudRate.Items.AddRange(new object[] {
            "9600",
            "38400",
            "115200"});
            this.CBoxBaudRate.Location = new System.Drawing.Point(99, 54);
            this.CBoxBaudRate.Name = "CBoxBaudRate";
            this.CBoxBaudRate.Size = new System.Drawing.Size(121, 21);
            this.CBoxBaudRate.TabIndex = 6;
            this.CBoxBaudRate.Text = "9600";
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(20, 131);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // CBoxComPort
            // 
            this.CBoxComPort.FormattingEnabled = true;
            this.CBoxComPort.Location = new System.Drawing.Point(99, 27);
            this.CBoxComPort.Name = "CBoxComPort";
            this.CBoxComPort.Size = new System.Drawing.Size(121, 21);
            this.CBoxComPort.TabIndex = 5;
            // 
            // lblStatus1
            // 
            this.lblStatus1.AutoSize = true;
            this.lblStatus1.Location = new System.Drawing.Point(17, 84);
            this.lblStatus1.Name = "lblStatus1";
            this.lblStatus1.Size = new System.Drawing.Size(37, 13);
            this.lblStatus1.TabIndex = 2;
            this.lblStatus1.Text = "Status";
            // 
            // LblBaudRate
            // 
            this.LblBaudRate.AutoSize = true;
            this.LblBaudRate.Location = new System.Drawing.Point(17, 57);
            this.LblBaudRate.Name = "LblBaudRate";
            this.LblBaudRate.Size = new System.Drawing.Size(69, 13);
            this.LblBaudRate.TabIndex = 1;
            this.LblBaudRate.Text = "BAUD RATE";
            // 
            // LblComPort
            // 
            this.LblComPort.AutoSize = true;
            this.LblComPort.Location = new System.Drawing.Point(17, 30);
            this.LblComPort.Name = "LblComPort";
            this.LblComPort.Size = new System.Drawing.Size(61, 13);
            this.LblComPort.TabIndex = 0;
            this.LblComPort.Text = "Com PORT";
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // btnForward
            // 
            this.btnForward.Location = new System.Drawing.Point(85, 19);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(101, 62);
            this.btnForward.TabIndex = 8;
            this.btnForward.Text = "Forward";
            this.btnForward.UseVisualStyleBackColor = true;
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(6, 87);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(101, 62);
            this.btnLeft.TabIndex = 9;
            this.btnLeft.Text = "Left";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(161, 87);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(101, 62);
            this.btnRight.TabIndex = 10;
            this.btnRight.Text = "Right";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(85, 155);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(101, 65);
            this.btnBack.TabIndex = 11;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnSTOP
            // 
            this.btnSTOP.Location = new System.Drawing.Point(766, 270);
            this.btnSTOP.Name = "btnSTOP";
            this.btnSTOP.Size = new System.Drawing.Size(223, 181);
            this.btnSTOP.TabIndex = 12;
            this.btnSTOP.Text = "STOP";
            this.btnSTOP.UseVisualStyleBackColor = true;
            this.btnSTOP.Click += new System.EventHandler(this.btnSTOP_Click);
            // 
            // GBManualControls
            // 
            this.GBManualControls.Controls.Add(this.btnForward);
            this.GBManualControls.Controls.Add(this.btnBack);
            this.GBManualControls.Controls.Add(this.btnLeft);
            this.GBManualControls.Controls.Add(this.btnRight);
            this.GBManualControls.Location = new System.Drawing.Point(12, 209);
            this.GBManualControls.Name = "GBManualControls";
            this.GBManualControls.Size = new System.Drawing.Size(268, 226);
            this.GBManualControls.TabIndex = 13;
            this.GBManualControls.TabStop = false;
            this.GBManualControls.Text = "Manual Control";
            // 
            // btnAutomatic
            // 
            this.btnAutomatic.Location = new System.Drawing.Point(546, 96);
            this.btnAutomatic.Name = "btnAutomatic";
            this.btnAutomatic.Size = new System.Drawing.Size(214, 62);
            this.btnAutomatic.TabIndex = 12;
            this.btnAutomatic.Text = "Automatic";
            this.btnAutomatic.UseVisualStyleBackColor = true;
            this.btnAutomatic.Click += new System.EventHandler(this.btnAutomatic_Click);
            // 
            // lblCurrentAction
            // 
            this.lblCurrentAction.AutoSize = true;
            this.lblCurrentAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentAction.Location = new System.Drawing.Point(597, 29);
            this.lblCurrentAction.Name = "lblCurrentAction";
            this.lblCurrentAction.Size = new System.Drawing.Size(133, 20);
            this.lblCurrentAction.TabIndex = 15;
            this.lblCurrentAction.Text = "Button Pressed";
            // 
            // lblAction
            // 
            this.lblAction.AutoSize = true;
            this.lblAction.BackColor = System.Drawing.SystemColors.Control;
            this.lblAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAction.ForeColor = System.Drawing.Color.Red;
            this.lblAction.Location = new System.Drawing.Point(622, 64);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(77, 20);
            this.lblAction.TabIndex = 16;
            this.lblAction.Text = "Awaiting";
            // 
            // lblConnorJenkins
            // 
            this.lblConnorJenkins.AutoSize = true;
            this.lblConnorJenkins.Location = new System.Drawing.Point(12, 438);
            this.lblConnorJenkins.Name = "lblConnorJenkins";
            this.lblConnorJenkins.Size = new System.Drawing.Size(243, 13);
            this.lblConnorJenkins.TabIndex = 17;
            this.lblConnorJenkins.Text = "Connor Jenkins - Programming Things - Zumo GUI";
            // 
            // txtUsage
            // 
            this.txtUsage.BackColor = System.Drawing.SystemColors.Control;
            this.txtUsage.Location = new System.Drawing.Point(766, 17);
            this.txtUsage.Multiline = true;
            this.txtUsage.Name = "txtUsage";
            this.txtUsage.Size = new System.Drawing.Size(223, 247);
            this.txtUsage.TabIndex = 18;
            this.txtUsage.Text = resources.GetString("txtUsage.Text");
            // 
            // btnStopForRoom
            // 
            this.btnStopForRoom.Location = new System.Drawing.Point(546, 164);
            this.btnStopForRoom.Name = "btnStopForRoom";
            this.btnStopForRoom.Size = new System.Drawing.Size(214, 62);
            this.btnStopForRoom.TabIndex = 20;
            this.btnStopForRoom.Text = "Stop For Room.";
            this.btnStopForRoom.UseVisualStyleBackColor = true;
            this.btnStopForRoom.Click += new System.EventHandler(this.btnStopForRoom_Click);
            // 
            // btnSearchRoom
            // 
            this.btnSearchRoom.Location = new System.Drawing.Point(546, 232);
            this.btnSearchRoom.Name = "btnSearchRoom";
            this.btnSearchRoom.Size = new System.Drawing.Size(214, 62);
            this.btnSearchRoom.TabIndex = 21;
            this.btnSearchRoom.Text = "SearchRoom";
            this.btnSearchRoom.UseVisualStyleBackColor = true;
            this.btnSearchRoom.Click += new System.EventHandler(this.btnSearchRoom_Click_1);
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(546, 300);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(214, 62);
            this.btnReturn.TabIndex = 22;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // lblCa
            // 
            this.lblCa.AutoSize = true;
            this.lblCa.Location = new System.Drawing.Point(6, 24);
            this.lblCa.Name = "lblCa";
            this.lblCa.Size = new System.Drawing.Size(71, 13);
            this.lblCa.TabIndex = 14;
            this.lblCa.Text = "CurrentAction";
            // 
            // RTBoxReceive
            // 
            this.RTBoxReceive.Location = new System.Drawing.Point(6, 39);
            this.RTBoxReceive.Name = "RTBoxReceive";
            this.RTBoxReceive.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RTBoxReceive.Size = new System.Drawing.Size(239, 138);
            this.RTBoxReceive.TabIndex = 1;
            this.RTBoxReceive.Text = "Awaiting";
            this.RTBoxReceive.TextChanged += new System.EventHandler(this.RTBoxReceive_TextChanged);
            // 
            // RTBRoomLog
            // 
            this.RTBRoomLog.Location = new System.Drawing.Point(7, 197);
            this.RTBRoomLog.Name = "RTBRoomLog";
            this.RTBRoomLog.Size = new System.Drawing.Size(238, 220);
            this.RTBRoomLog.TabIndex = 22;
            this.RTBRoomLog.Text = "RoomID: NULL  | Location: NULL  | Empty : NULL";
            this.RTBRoomLog.TextChanged += new System.EventHandler(this.RTBRoomLog_TextChanged);
            // 
            // LBLRoomLog
            // 
            this.LBLRoomLog.AutoSize = true;
            this.LBLRoomLog.Location = new System.Drawing.Point(3, 180);
            this.LBLRoomLog.Name = "LBLRoomLog";
            this.LBLRoomLog.Size = new System.Drawing.Size(53, 13);
            this.LBLRoomLog.TabIndex = 23;
            this.LBLRoomLog.Text = "RoomLog";
            // 
            // GBOutputs
            // 
            this.GBOutputs.Controls.Add(this.LBLRoomLog);
            this.GBOutputs.Controls.Add(this.RTBRoomLog);
            this.GBOutputs.Controls.Add(this.RTBoxReceive);
            this.GBOutputs.Controls.Add(this.lblCa);
            this.GBOutputs.Location = new System.Drawing.Point(289, 12);
            this.GBOutputs.Name = "GBOutputs";
            this.GBOutputs.Size = new System.Drawing.Size(251, 423);
            this.GBOutputs.TabIndex = 19;
            this.GBOutputs.TabStop = false;
            this.GBOutputs.Text = "Outputs";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 458);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnSearchRoom);
            this.Controls.Add(this.btnStopForRoom);
            this.Controls.Add(this.GBOutputs);
            this.Controls.Add(this.txtUsage);
            this.Controls.Add(this.lblConnorJenkins);
            this.Controls.Add(this.lblAction);
            this.Controls.Add(this.lblCurrentAction);
            this.Controls.Add(this.btnAutomatic);
            this.Controls.Add(this.btnSTOP);
            this.Controls.Add(this.GBManualControls);
            this.Controls.Add(this.GBPortControls);
            this.Name = "Form1";
            this.Text = "ZUMO GUI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.GBPortControls.ResumeLayout(false);
            this.GBPortControls.PerformLayout();
            this.GBManualControls.ResumeLayout(false);
            this.GBOutputs.ResumeLayout(false);
            this.GBOutputs.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox GBPortControls;
        private System.Windows.Forms.ComboBox CBoxBaudRate;
        private System.Windows.Forms.ComboBox CBoxComPort;
        private System.Windows.Forms.Label lblStatus1;
        private System.Windows.Forms.Label LblBaudRate;
        private System.Windows.Forms.Label LblComPort;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnForward;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnSTOP;
        private System.Windows.Forms.GroupBox GBManualControls;
        private System.Windows.Forms.Button btnAutomatic;
        private System.Windows.Forms.Label lblCurrentAction;
        private System.Windows.Forms.Label lblAction;
        private System.Windows.Forms.Label lblConnorJenkins;
        private System.Windows.Forms.TextBox txtUsage;
        private System.Windows.Forms.Button btnStopForRoom;
        private System.Windows.Forms.Button btnSearchRoom;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Label lblCa;
        private System.Windows.Forms.RichTextBox RTBoxReceive;
        private System.Windows.Forms.RichTextBox RTBRoomLog;
        private System.Windows.Forms.Label LBLRoomLog;
        private System.Windows.Forms.GroupBox GBOutputs;
    }
}

