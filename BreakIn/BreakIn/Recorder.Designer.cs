namespace BreakIn
{
  partial class Recorder
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Recorder));
        this.panel3 = new System.Windows.Forms.Panel();
        this.btnSaveRecording = new System.Windows.Forms.Button();
        this.btnPlayBack = new System.Windows.Forms.Button();
        this.btnStopRecording = new System.Windows.Forms.Button();
        this.btnStartRecording = new System.Windows.Forms.Button();
        this.SourceList = new System.Windows.Forms.ListView();
        this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
        this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
        this.linkLabel1 = new System.Windows.Forms.LinkLabel();
        this.panel1 = new System.Windows.Forms.Panel();
        this.lblAddEditUserHeading = new System.Windows.Forms.Label();
        this.panel2 = new System.Windows.Forms.Panel();
        this.btnCancel = new System.Windows.Forms.Button();
        this.btnSave = new System.Windows.Forms.Button();
        this.panel3.SuspendLayout();
        this.panel1.SuspendLayout();
        this.panel2.SuspendLayout();
        this.SuspendLayout();
        // 
        // panel3
        // 
        this.panel3.BackColor = System.Drawing.SystemColors.Control;
        this.panel3.Controls.Add(this.btnSaveRecording);
        this.panel3.Controls.Add(this.btnPlayBack);
        this.panel3.Controls.Add(this.btnStopRecording);
        this.panel3.Controls.Add(this.btnStartRecording);
        this.panel3.Controls.Add(this.SourceList);
        this.panel3.Controls.Add(this.linkLabel1);
        this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
        this.panel3.Location = new System.Drawing.Point(0, 42);
        this.panel3.Name = "panel3";
        this.panel3.Size = new System.Drawing.Size(667, 270);
        this.panel3.TabIndex = 8;
        // 
        // btnSaveRecording
        // 
        this.btnSaveRecording.Enabled = false;
        this.btnSaveRecording.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveRecording.Image")));
        this.btnSaveRecording.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.btnSaveRecording.Location = new System.Drawing.Point(370, 183);
        this.btnSaveRecording.Name = "btnSaveRecording";
        this.btnSaveRecording.Size = new System.Drawing.Size(163, 39);
        this.btnSaveRecording.TabIndex = 7;
        this.btnSaveRecording.Text = "Save Recording";
        this.btnSaveRecording.UseVisualStyleBackColor = true;
        this.btnSaveRecording.Click += new System.EventHandler(this.btnSaveRecording_Click);
        // 
        // btnPlayBack
        // 
        this.btnPlayBack.Enabled = false;
        this.btnPlayBack.Image = global::BreakIn.Properties.Resources.Player_play;
        this.btnPlayBack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.btnPlayBack.Location = new System.Drawing.Point(370, 129);
        this.btnPlayBack.Name = "btnPlayBack";
        this.btnPlayBack.Size = new System.Drawing.Size(163, 39);
        this.btnPlayBack.TabIndex = 6;
        this.btnPlayBack.Text = "Play Recording";
        this.btnPlayBack.UseVisualStyleBackColor = true;
        this.btnPlayBack.Click += new System.EventHandler(this.btnPlayBack_Click);
        // 
        // btnStopRecording
        // 
        this.btnStopRecording.Enabled = false;
        this.btnStopRecording.Image = global::BreakIn.Properties.Resources.Player_stop;
        this.btnStopRecording.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.btnStopRecording.Location = new System.Drawing.Point(370, 75);
        this.btnStopRecording.Name = "btnStopRecording";
        this.btnStopRecording.Size = new System.Drawing.Size(163, 39);
        this.btnStopRecording.TabIndex = 5;
        this.btnStopRecording.Text = "Stop Recording";
        this.btnStopRecording.UseVisualStyleBackColor = true;
        this.btnStopRecording.Click += new System.EventHandler(this.btnStopRecording_Click);
        // 
        // btnStartRecording
        // 
        this.btnStartRecording.Enabled = false;
        this.btnStartRecording.Image = ((System.Drawing.Image)(resources.GetObject("btnStartRecording.Image")));
        this.btnStartRecording.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.btnStartRecording.Location = new System.Drawing.Point(370, 21);
        this.btnStartRecording.Name = "btnStartRecording";
        this.btnStartRecording.Size = new System.Drawing.Size(163, 39);
        this.btnStartRecording.TabIndex = 4;
        this.btnStartRecording.Text = "Start Recording";
        this.btnStartRecording.UseVisualStyleBackColor = true;
        this.btnStartRecording.Click += new System.EventHandler(this.btnStartRecording_Click);
        // 
        // SourceList
        // 
        this.SourceList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
        this.SourceList.Dock = System.Windows.Forms.DockStyle.Left;
        this.SourceList.Location = new System.Drawing.Point(0, 0);
        this.SourceList.MultiSelect = false;
        this.SourceList.Name = "SourceList";
        this.SourceList.Size = new System.Drawing.Size(235, 270);
        this.SourceList.TabIndex = 3;
        this.SourceList.UseCompatibleStateImageBehavior = false;
        this.SourceList.View = System.Windows.Forms.View.Details;
        this.SourceList.SelectedIndexChanged += new System.EventHandler(this.SourceList_SelectedIndexChanged);
        // 
        // columnHeader3
        // 
        this.columnHeader3.Text = "Device";
        this.columnHeader3.Width = 150;
        // 
        // columnHeader4
        // 
        this.columnHeader4.Text = "Channels";
        // 
        // linkLabel1
        // 
        this.linkLabel1.AutoSize = true;
        this.linkLabel1.Location = new System.Drawing.Point(12, 240);
        this.linkLabel1.Name = "linkLabel1";
        this.linkLabel1.Size = new System.Drawing.Size(55, 13);
        this.linkLabel1.TabIndex = 1;
        this.linkLabel1.TabStop = true;
        this.linkLabel1.Text = "linkLabel1";
        // 
        // panel1
        // 
        this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(136)))), ((int)(((byte)(207)))));
        this.panel1.Controls.Add(this.lblAddEditUserHeading);
        this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
        this.panel1.Location = new System.Drawing.Point(0, 0);
        this.panel1.Margin = new System.Windows.Forms.Padding(4);
        this.panel1.Name = "panel1";
        this.panel1.Size = new System.Drawing.Size(667, 42);
        this.panel1.TabIndex = 6;
        // 
        // lblAddEditUserHeading
        // 
        this.lblAddEditUserHeading.AutoSize = true;
        this.lblAddEditUserHeading.Location = new System.Drawing.Point(31, 9);
        this.lblAddEditUserHeading.Name = "lblAddEditUserHeading";
        this.lblAddEditUserHeading.Size = new System.Drawing.Size(35, 13);
        this.lblAddEditUserHeading.TabIndex = 0;
        this.lblAddEditUserHeading.Text = "label4";
        // 
        // panel2
        // 
        this.panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
        this.panel2.Controls.Add(this.btnCancel);
        this.panel2.Controls.Add(this.btnSave);
        this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.panel2.Location = new System.Drawing.Point(0, 312);
        this.panel2.Margin = new System.Windows.Forms.Padding(4);
        this.panel2.Name = "panel2";
        this.panel2.Size = new System.Drawing.Size(667, 69);
        this.panel2.TabIndex = 7;
        // 
        // btnCancel
        // 
        this.btnCancel.Location = new System.Drawing.Point(528, 18);
        this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
        this.btnCancel.Name = "btnCancel";
        this.btnCancel.Size = new System.Drawing.Size(112, 32);
        this.btnCancel.TabIndex = 1;
        this.btnCancel.Text = "Close";
        this.btnCancel.UseVisualStyleBackColor = true;
        this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
        // 
        // btnSave
        // 
        this.btnSave.Location = new System.Drawing.Point(153, 18);
        this.btnSave.Margin = new System.Windows.Forms.Padding(4);
        this.btnSave.Name = "btnSave";
        this.btnSave.Size = new System.Drawing.Size(112, 32);
        this.btnSave.TabIndex = 0;
        this.btnSave.Text = "Save";
        this.btnSave.UseVisualStyleBackColor = true;
        // 
        // Recorder
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(667, 381);
        this.Controls.Add(this.panel3);
        this.Controls.Add(this.panel1);
        this.Controls.Add(this.panel2);
        this.Name = "Recorder";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Recorder";
        this.Load += new System.EventHandler(this.Recorder_Load);
        this.panel3.ResumeLayout(false);
        this.panel3.PerformLayout();
        this.panel1.ResumeLayout(false);
        this.panel1.PerformLayout();
        this.panel2.ResumeLayout(false);
        this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Label lblAddEditUserHeading;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.LinkLabel linkLabel1;
    private System.Windows.Forms.ListView SourceList;
    private System.Windows.Forms.ColumnHeader columnHeader3;
    private System.Windows.Forms.ColumnHeader columnHeader4;
    private System.Windows.Forms.Button btnStartRecording;
    private System.Windows.Forms.Button btnSaveRecording;
    private System.Windows.Forms.Button btnPlayBack;
    private System.Windows.Forms.Button btnStopRecording;
  }
}