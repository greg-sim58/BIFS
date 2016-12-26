namespace BreakIn
{
  partial class AddEditSchedule
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
      this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
      this.btnSave = new System.Windows.Forms.Button();
      this.lblAddEditUserHeading = new System.Windows.Forms.Label();
      this.panel1 = new System.Windows.Forms.Panel();
      this.label5 = new System.Windows.Forms.Label();
      this.txtMsgName = new System.Windows.Forms.TextBox();
      this.panel3 = new System.Windows.Forms.Panel();
      this.txtScheduleMessageName = new System.Windows.Forms.TextBox();
      this.lblScheduleFilename = new System.Windows.Forms.Label();
      this.dtpTimeOfDay = new System.Windows.Forms.DateTimePicker();
      this.lblDaysOfWeek = new System.Windows.Forms.Label();
      this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
      this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
      this.cmbScheduleFilename = new System.Windows.Forms.ComboBox();
      this.chkScheduleEnabled = new System.Windows.Forms.CheckBox();
      this.chkScheduleSun = new System.Windows.Forms.CheckBox();
      this.chkScheduleSat = new System.Windows.Forms.CheckBox();
      this.chkScheduleFri = new System.Windows.Forms.CheckBox();
      this.chkScheduleThu = new System.Windows.Forms.CheckBox();
      this.chkScheduleWed = new System.Windows.Forms.CheckBox();
      this.chkScheduleTue = new System.Windows.Forms.CheckBox();
      this.chkScheduleMon = new System.Windows.Forms.CheckBox();
      this.lblScheduleEndDate = new System.Windows.Forms.Label();
      this.lblScheduleStartDate = new System.Windows.Forms.Label();
      this.lblTimeOfDay = new System.Windows.Forms.Label();
      this.lblScheduleMessageName = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.panel2 = new System.Windows.Forms.Panel();
      this.btnCancel = new System.Windows.Forms.Button();
      this.chkTunnel1 = new System.Windows.Forms.CheckBox();
      this.chkTunnel2 = new System.Windows.Forms.CheckBox();
      this.panel1.SuspendLayout();
      this.panel3.SuspendLayout();
      this.panel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // openFileDialog1
      // 
      this.openFileDialog1.FileName = "openFileDialog1";
      // 
      // btnSave
      // 
      this.btnSave.BackColor = System.Drawing.Color.SteelBlue;
      this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
      this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnSave.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnSave.ForeColor = System.Drawing.Color.White;
      this.btnSave.Location = new System.Drawing.Point(138, 18);
      this.btnSave.Margin = new System.Windows.Forms.Padding(4);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new System.Drawing.Size(112, 32);
      this.btnSave.TabIndex = 0;
      this.btnSave.Text = "Save";
      this.btnSave.UseVisualStyleBackColor = false;
      this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
      // 
      // lblAddEditUserHeading
      // 
      this.lblAddEditUserHeading.AutoSize = true;
      this.lblAddEditUserHeading.Location = new System.Drawing.Point(45, 22);
      this.lblAddEditUserHeading.Name = "lblAddEditUserHeading";
      this.lblAddEditUserHeading.Size = new System.Drawing.Size(65, 24);
      this.lblAddEditUserHeading.TabIndex = 0;
      this.lblAddEditUserHeading.Text = "label4";
      // 
      // panel1
      // 
      this.panel1.BackColor = System.Drawing.Color.SteelBlue;
      this.panel1.Controls.Add(this.lblAddEditUserHeading);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.panel1.ForeColor = System.Drawing.Color.White;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Margin = new System.Windows.Forms.Padding(4);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(762, 68);
      this.panel1.TabIndex = 6;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label5.ForeColor = System.Drawing.SystemColors.ControlDark;
      this.label5.Location = new System.Drawing.Point(547, 36);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(226, 16);
      this.label5.TabIndex = 19;
      this.label5.Text = "Enter a unique name for the message";
      this.label5.Visible = false;
      // 
      // txtMsgName
      // 
      this.txtMsgName.Location = new System.Drawing.Point(266, 33);
      this.txtMsgName.Margin = new System.Windows.Forms.Padding(4);
      this.txtMsgName.Name = "txtMsgName";
      this.txtMsgName.Size = new System.Drawing.Size(262, 26);
      this.txtMsgName.TabIndex = 8;
      // 
      // panel3
      // 
      this.panel3.BackColor = System.Drawing.SystemColors.Control;
      this.panel3.Controls.Add(this.chkTunnel2);
      this.panel3.Controls.Add(this.chkTunnel1);
      this.panel3.Controls.Add(this.txtScheduleMessageName);
      this.panel3.Controls.Add(this.lblScheduleFilename);
      this.panel3.Controls.Add(this.dtpTimeOfDay);
      this.panel3.Controls.Add(this.lblDaysOfWeek);
      this.panel3.Controls.Add(this.dtpEndDate);
      this.panel3.Controls.Add(this.dtpStartDate);
      this.panel3.Controls.Add(this.cmbScheduleFilename);
      this.panel3.Controls.Add(this.chkScheduleEnabled);
      this.panel3.Controls.Add(this.chkScheduleSun);
      this.panel3.Controls.Add(this.chkScheduleSat);
      this.panel3.Controls.Add(this.chkScheduleFri);
      this.panel3.Controls.Add(this.chkScheduleThu);
      this.panel3.Controls.Add(this.chkScheduleWed);
      this.panel3.Controls.Add(this.chkScheduleTue);
      this.panel3.Controls.Add(this.chkScheduleMon);
      this.panel3.Controls.Add(this.lblScheduleEndDate);
      this.panel3.Controls.Add(this.lblScheduleStartDate);
      this.panel3.Controls.Add(this.lblTimeOfDay);
      this.panel3.Controls.Add(this.lblScheduleMessageName);
      this.panel3.Controls.Add(this.label5);
      this.panel3.Controls.Add(this.label1);
      this.panel3.Controls.Add(this.txtMsgName);
      this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.panel3.Location = new System.Drawing.Point(0, 0);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(762, 402);
      this.panel3.TabIndex = 8;
      // 
      // txtScheduleMessageName
      // 
      this.txtScheduleMessageName.Location = new System.Drawing.Point(241, 96);
      this.txtScheduleMessageName.Name = "txtScheduleMessageName";
      this.txtScheduleMessageName.Size = new System.Drawing.Size(287, 26);
      this.txtScheduleMessageName.TabIndex = 38;
      // 
      // lblScheduleFilename
      // 
      this.lblScheduleFilename.AutoSize = true;
      this.lblScheduleFilename.Location = new System.Drawing.Point(155, 135);
      this.lblScheduleFilename.Name = "lblScheduleFilename";
      this.lblScheduleFilename.Size = new System.Drawing.Size(77, 18);
      this.lblScheduleFilename.TabIndex = 37;
      this.lblScheduleFilename.Text = "Filename:";
      // 
      // dtpTimeOfDay
      // 
      this.dtpTimeOfDay.CustomFormat = "HH:mm";
      this.dtpTimeOfDay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
      this.dtpTimeOfDay.Location = new System.Drawing.Point(241, 168);
      this.dtpTimeOfDay.Name = "dtpTimeOfDay";
      this.dtpTimeOfDay.ShowUpDown = true;
      this.dtpTimeOfDay.Size = new System.Drawing.Size(124, 26);
      this.dtpTimeOfDay.TabIndex = 36;
      this.dtpTimeOfDay.Value = new System.DateTime(2012, 11, 17, 13, 32, 44, 0);
      // 
      // lblDaysOfWeek
      // 
      this.lblDaysOfWeek.AutoSize = true;
      this.lblDaysOfWeek.Location = new System.Drawing.Point(112, 285);
      this.lblDaysOfWeek.Name = "lblDaysOfWeek";
      this.lblDaysOfWeek.Size = new System.Drawing.Size(120, 18);
      this.lblDaysOfWeek.TabIndex = 35;
      this.lblDaysOfWeek.Text = "Day(s) of Week:";
      // 
      // dtpEndDate
      // 
      this.dtpEndDate.Location = new System.Drawing.Point(241, 240);
      this.dtpEndDate.Name = "dtpEndDate";
      this.dtpEndDate.Size = new System.Drawing.Size(287, 26);
      this.dtpEndDate.TabIndex = 34;
      // 
      // dtpStartDate
      // 
      this.dtpStartDate.Location = new System.Drawing.Point(241, 204);
      this.dtpStartDate.Name = "dtpStartDate";
      this.dtpStartDate.Size = new System.Drawing.Size(287, 26);
      this.dtpStartDate.TabIndex = 33;
      // 
      // cmbScheduleFilename
      // 
      this.cmbScheduleFilename.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbScheduleFilename.FormattingEnabled = true;
      this.cmbScheduleFilename.Location = new System.Drawing.Point(241, 132);
      this.cmbScheduleFilename.Name = "cmbScheduleFilename";
      this.cmbScheduleFilename.Size = new System.Drawing.Size(287, 26);
      this.cmbScheduleFilename.TabIndex = 32;
      // 
      // chkScheduleEnabled
      // 
      this.chkScheduleEnabled.AutoSize = true;
      this.chkScheduleEnabled.Location = new System.Drawing.Point(241, 364);
      this.chkScheduleEnabled.Name = "chkScheduleEnabled";
      this.chkScheduleEnabled.Size = new System.Drawing.Size(76, 22);
      this.chkScheduleEnabled.TabIndex = 31;
      this.chkScheduleEnabled.Text = "Enable";
      this.chkScheduleEnabled.UseVisualStyleBackColor = true;
      // 
      // chkScheduleSun
      // 
      this.chkScheduleSun.AutoSize = true;
      this.chkScheduleSun.Location = new System.Drawing.Point(649, 284);
      this.chkScheduleSun.Name = "chkScheduleSun";
      this.chkScheduleSun.Size = new System.Drawing.Size(54, 22);
      this.chkScheduleSun.TabIndex = 30;
      this.chkScheduleSun.Text = "Sun";
      this.chkScheduleSun.UseVisualStyleBackColor = true;
      // 
      // chkScheduleSat
      // 
      this.chkScheduleSat.AutoSize = true;
      this.chkScheduleSat.Location = new System.Drawing.Point(583, 284);
      this.chkScheduleSat.Name = "chkScheduleSat";
      this.chkScheduleSat.Size = new System.Drawing.Size(51, 22);
      this.chkScheduleSat.TabIndex = 29;
      this.chkScheduleSat.Text = "Sat";
      this.chkScheduleSat.UseVisualStyleBackColor = true;
      // 
      // chkScheduleFri
      // 
      this.chkScheduleFri.AutoSize = true;
      this.chkScheduleFri.Location = new System.Drawing.Point(522, 284);
      this.chkScheduleFri.Name = "chkScheduleFri";
      this.chkScheduleFri.Size = new System.Drawing.Size(46, 22);
      this.chkScheduleFri.TabIndex = 28;
      this.chkScheduleFri.Text = "Fri";
      this.chkScheduleFri.UseVisualStyleBackColor = true;
      // 
      // chkScheduleThu
      // 
      this.chkScheduleThu.AutoSize = true;
      this.chkScheduleThu.Location = new System.Drawing.Point(455, 284);
      this.chkScheduleThu.Name = "chkScheduleThu";
      this.chkScheduleThu.Size = new System.Drawing.Size(52, 22);
      this.chkScheduleThu.TabIndex = 27;
      this.chkScheduleThu.Text = "Thu";
      this.chkScheduleThu.UseVisualStyleBackColor = true;
      // 
      // chkScheduleWed
      // 
      this.chkScheduleWed.AutoSize = true;
      this.chkScheduleWed.Location = new System.Drawing.Point(380, 284);
      this.chkScheduleWed.Name = "chkScheduleWed";
      this.chkScheduleWed.Size = new System.Drawing.Size(60, 22);
      this.chkScheduleWed.TabIndex = 26;
      this.chkScheduleWed.Text = "Wed";
      this.chkScheduleWed.UseVisualStyleBackColor = true;
      // 
      // chkScheduleTue
      // 
      this.chkScheduleTue.AutoSize = true;
      this.chkScheduleTue.Location = new System.Drawing.Point(313, 284);
      this.chkScheduleTue.Name = "chkScheduleTue";
      this.chkScheduleTue.Size = new System.Drawing.Size(52, 22);
      this.chkScheduleTue.TabIndex = 25;
      this.chkScheduleTue.Text = "Tue";
      this.chkScheduleTue.UseVisualStyleBackColor = true;
      // 
      // chkScheduleMon
      // 
      this.chkScheduleMon.AutoSize = true;
      this.chkScheduleMon.Location = new System.Drawing.Point(241, 284);
      this.chkScheduleMon.Name = "chkScheduleMon";
      this.chkScheduleMon.Size = new System.Drawing.Size(57, 22);
      this.chkScheduleMon.TabIndex = 24;
      this.chkScheduleMon.Text = "Mon";
      this.chkScheduleMon.UseVisualStyleBackColor = true;
      // 
      // lblScheduleEndDate
      // 
      this.lblScheduleEndDate.AutoSize = true;
      this.lblScheduleEndDate.Location = new System.Drawing.Point(154, 246);
      this.lblScheduleEndDate.Name = "lblScheduleEndDate";
      this.lblScheduleEndDate.Size = new System.Drawing.Size(78, 18);
      this.lblScheduleEndDate.TabIndex = 23;
      this.lblScheduleEndDate.Text = "End Date:";
      // 
      // lblScheduleStartDate
      // 
      this.lblScheduleStartDate.AutoSize = true;
      this.lblScheduleStartDate.Location = new System.Drawing.Point(149, 210);
      this.lblScheduleStartDate.Name = "lblScheduleStartDate";
      this.lblScheduleStartDate.Size = new System.Drawing.Size(83, 18);
      this.lblScheduleStartDate.TabIndex = 22;
      this.lblScheduleStartDate.Text = "Start Date:";
      // 
      // lblTimeOfDay
      // 
      this.lblTimeOfDay.AutoSize = true;
      this.lblTimeOfDay.Location = new System.Drawing.Point(134, 174);
      this.lblTimeOfDay.Name = "lblTimeOfDay";
      this.lblTimeOfDay.Size = new System.Drawing.Size(98, 18);
      this.lblTimeOfDay.TabIndex = 21;
      this.lblTimeOfDay.Text = "Time Of Day:";
      // 
      // lblScheduleMessageName
      // 
      this.lblScheduleMessageName.AutoSize = true;
      this.lblScheduleMessageName.Location = new System.Drawing.Point(109, 99);
      this.lblScheduleMessageName.Name = "lblScheduleMessageName";
      this.lblScheduleMessageName.Size = new System.Drawing.Size(123, 18);
      this.lblScheduleMessageName.TabIndex = 20;
      this.lblScheduleMessageName.Text = "Message Name:";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(135, 36);
      this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(123, 18);
      this.label1.TabIndex = 11;
      this.label1.Text = "Message Name:";
      // 
      // panel2
      // 
      this.panel2.BackColor = System.Drawing.Color.White;
      this.panel2.Controls.Add(this.btnCancel);
      this.panel2.Controls.Add(this.btnSave);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel2.Location = new System.Drawing.Point(0, 402);
      this.panel2.Margin = new System.Windows.Forms.Padding(4);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(762, 69);
      this.panel2.TabIndex = 7;
      // 
      // btnCancel
      // 
      this.btnCancel.BackColor = System.Drawing.Color.SteelBlue;
      this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
      this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnCancel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnCancel.ForeColor = System.Drawing.Color.White;
      this.btnCancel.Location = new System.Drawing.Point(513, 18);
      this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(112, 32);
      this.btnCancel.TabIndex = 1;
      this.btnCancel.Text = "Close";
      this.btnCancel.UseVisualStyleBackColor = false;
      this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // chkTunnel1
      // 
      this.chkTunnel1.AutoSize = true;
      this.chkTunnel1.Location = new System.Drawing.Point(241, 324);
      this.chkTunnel1.Name = "chkTunnel1";
      this.chkTunnel1.Size = new System.Drawing.Size(84, 22);
      this.chkTunnel1.TabIndex = 39;
      this.chkTunnel1.Text = "Tunnel 1";
      this.chkTunnel1.UseVisualStyleBackColor = true;
      // 
      // chkTunnel2
      // 
      this.chkTunnel2.AutoSize = true;
      this.chkTunnel2.Location = new System.Drawing.Point(439, 324);
      this.chkTunnel2.Name = "chkTunnel2";
      this.chkTunnel2.Size = new System.Drawing.Size(84, 22);
      this.chkTunnel2.TabIndex = 40;
      this.chkTunnel2.Text = "Tunnel 2\r\n";
      this.chkTunnel2.UseVisualStyleBackColor = true;
      // 
      // AddEditSchedule
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(762, 471);
      this.ControlBox = false;
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.panel3);
      this.Controls.Add(this.panel2);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "AddEditSchedule";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "AddEditSchedule";
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.panel3.ResumeLayout(false);
      this.panel3.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.OpenFileDialog openFileDialog1;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Label lblAddEditUserHeading;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox txtMsgName;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Label lblScheduleMessageName;
    private System.Windows.Forms.Label lblTimeOfDay;
    private System.Windows.Forms.CheckBox chkScheduleEnabled;
    private System.Windows.Forms.CheckBox chkScheduleSun;
    private System.Windows.Forms.CheckBox chkScheduleSat;
    private System.Windows.Forms.CheckBox chkScheduleFri;
    private System.Windows.Forms.CheckBox chkScheduleThu;
    private System.Windows.Forms.CheckBox chkScheduleWed;
    private System.Windows.Forms.CheckBox chkScheduleTue;
    private System.Windows.Forms.CheckBox chkScheduleMon;
    private System.Windows.Forms.Label lblScheduleEndDate;
    private System.Windows.Forms.Label lblScheduleStartDate;
    private System.Windows.Forms.DateTimePicker dtpEndDate;
    private System.Windows.Forms.DateTimePicker dtpStartDate;
    private System.Windows.Forms.ComboBox cmbScheduleFilename;
    private System.Windows.Forms.DateTimePicker dtpTimeOfDay;
    private System.Windows.Forms.Label lblDaysOfWeek;
    private System.Windows.Forms.TextBox txtScheduleMessageName;
    private System.Windows.Forms.Label lblScheduleFilename;
    private System.Windows.Forms.CheckBox chkTunnel2;
    private System.Windows.Forms.CheckBox chkTunnel1;
  }
}