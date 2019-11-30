namespace projekt_mechatronika
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
            this.buttonConnect = new System.Windows.Forms.Button();
            this.buttonDisconnect = new System.Windows.Forms.Button();
            this.comboBoxPorts = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.ActiveUsers = new System.Windows.Forms.GroupBox();
            this.textBoxUser3 = new System.Windows.Forms.TextBox();
            this.textBoxUser2 = new System.Windows.Forms.TextBox();
            this.textBoxUser1 = new System.Windows.Forms.TextBox();
            this.checkBoxUser3 = new System.Windows.Forms.CheckBox();
            this.checkBoxUser2 = new System.Windows.Forms.CheckBox();
            this.checkBoxUser1 = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.textBoxEvents = new System.Windows.Forms.TextBox();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.ActiveUsers.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(31, 43);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(155, 40);
            this.buttonConnect.TabIndex = 0;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // buttonDisconnect
            // 
            this.buttonDisconnect.Location = new System.Drawing.Point(224, 43);
            this.buttonDisconnect.Name = "buttonDisconnect";
            this.buttonDisconnect.Size = new System.Drawing.Size(148, 40);
            this.buttonDisconnect.TabIndex = 1;
            this.buttonDisconnect.Text = "Disconnect";
            this.buttonDisconnect.UseVisualStyleBackColor = true;
            this.buttonDisconnect.Click += new System.EventHandler(this.buttonDisconnect_Click);
            // 
            // comboBoxPorts
            // 
            this.comboBoxPorts.FormattingEnabled = true;
            this.comboBoxPorts.Location = new System.Drawing.Point(31, 145);
            this.comboBoxPorts.Name = "comboBoxPorts";
            this.comboBoxPorts.Size = new System.Drawing.Size(341, 24);
            this.comboBoxPorts.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Controls.Add(this.comboBoxPorts);
            this.groupBox1.Controls.Add(this.buttonDisconnect);
            this.groupBox1.Controls.Add(this.buttonConnect);
            this.groupBox1.Location = new System.Drawing.Point(22, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(396, 209);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection with Arduino";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(31, 98);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(341, 23);
            this.progressBar1.TabIndex = 3;
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // ActiveUsers
            // 
            this.ActiveUsers.Controls.Add(this.textBoxUser3);
            this.ActiveUsers.Controls.Add(this.textBoxUser2);
            this.ActiveUsers.Controls.Add(this.textBoxUser1);
            this.ActiveUsers.Controls.Add(this.checkBoxUser3);
            this.ActiveUsers.Controls.Add(this.checkBoxUser2);
            this.ActiveUsers.Controls.Add(this.checkBoxUser1);
            this.ActiveUsers.Location = new System.Drawing.Point(22, 240);
            this.ActiveUsers.Name = "ActiveUsers";
            this.ActiveUsers.Size = new System.Drawing.Size(396, 171);
            this.ActiveUsers.TabIndex = 14;
            this.ActiveUsers.TabStop = false;
            this.ActiveUsers.Text = "Active Users";
            // 
            // textBoxUser3
            // 
            this.textBoxUser3.Location = new System.Drawing.Point(228, 125);
            this.textBoxUser3.Name = "textBoxUser3";
            this.textBoxUser3.Size = new System.Drawing.Size(144, 22);
            this.textBoxUser3.TabIndex = 5;
            // 
            // textBoxUser2
            // 
            this.textBoxUser2.Location = new System.Drawing.Point(228, 79);
            this.textBoxUser2.Name = "textBoxUser2";
            this.textBoxUser2.Size = new System.Drawing.Size(144, 22);
            this.textBoxUser2.TabIndex = 4;
            // 
            // textBoxUser1
            // 
            this.textBoxUser1.Location = new System.Drawing.Point(224, 32);
            this.textBoxUser1.Name = "textBoxUser1";
            this.textBoxUser1.Size = new System.Drawing.Size(148, 22);
            this.textBoxUser1.TabIndex = 3;
            this.textBoxUser1.TextChanged += new System.EventHandler(this.textBoxUser1_TextChanged);
            // 
            // checkBoxUser3
            // 
            this.checkBoxUser3.AutoSize = true;
            this.checkBoxUser3.Location = new System.Drawing.Point(31, 125);
            this.checkBoxUser3.Name = "checkBoxUser3";
            this.checkBoxUser3.Size = new System.Drawing.Size(191, 21);
            this.checkBoxUser3.TabIndex = 2;
            this.checkBoxUser3.Text = "\"ba1be68b\" -  legitymacja";
            this.checkBoxUser3.UseVisualStyleBackColor = true;
            this.checkBoxUser3.CheckedChanged += new System.EventHandler(this.checkBoxUser3_CheckedChanged);
            // 
            // checkBoxUser2
            // 
            this.checkBoxUser2.AutoSize = true;
            this.checkBoxUser2.Location = new System.Drawing.Point(31, 81);
            this.checkBoxUser2.Name = "checkBoxUser2";
            this.checkBoxUser2.Size = new System.Drawing.Size(152, 21);
            this.checkBoxUser2.TabIndex = 1;
            this.checkBoxUser2.Text = "\"fb779a1b\" - brelok";
            this.checkBoxUser2.UseVisualStyleBackColor = true;
            this.checkBoxUser2.CheckedChanged += new System.EventHandler(this.checkBoxUser2_CheckedChanged);
            // 
            // checkBoxUser1
            // 
            this.checkBoxUser1.AutoSize = true;
            this.checkBoxUser1.Location = new System.Drawing.Point(31, 32);
            this.checkBoxUser1.Name = "checkBoxUser1";
            this.checkBoxUser1.Size = new System.Drawing.Size(183, 21);
            this.checkBoxUser1.TabIndex = 0;
            this.checkBoxUser1.Text = "\"3989a299\" - biała karta";
            this.checkBoxUser1.UseVisualStyleBackColor = false;
            this.checkBoxUser1.CheckedChanged += new System.EventHandler(this.checkBoxUser1_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonClear);
            this.groupBox2.Controls.Add(this.textBoxEvents);
            this.groupBox2.Location = new System.Drawing.Point(459, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(437, 495);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Events";
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(308, 446);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(104, 43);
            this.buttonClear.TabIndex = 13;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // textBoxEvents
            // 
            this.textBoxEvents.Location = new System.Drawing.Point(27, 21);
            this.textBoxEvents.Multiline = true;
            this.textBoxEvents.Name = "textBoxEvents";
            this.textBoxEvents.Size = new System.Drawing.Size(394, 405);
            this.textBoxEvents.TabIndex = 12;
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(22, 432);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(396, 75);
            this.buttonOpen.TabIndex = 15;
            this.buttonOpen.Text = "Open Door";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 531);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.ActiveUsers);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.ActiveUsers.ResumeLayout(false);
            this.ActiveUsers.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button buttonDisconnect;
        private System.Windows.Forms.ComboBox comboBoxPorts;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox ActiveUsers;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxEvents;
        private System.Windows.Forms.CheckBox checkBoxUser3;
        private System.Windows.Forms.CheckBox checkBoxUser2;
        private System.Windows.Forms.CheckBox checkBoxUser1;
        private System.Windows.Forms.TextBox textBoxUser1;
        private System.Windows.Forms.TextBox textBoxUser3;
        private System.Windows.Forms.TextBox textBoxUser2;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonOpen;
    }
}

