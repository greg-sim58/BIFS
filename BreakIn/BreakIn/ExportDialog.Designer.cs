namespace BreakIn
{
  partial class ExportDialog
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
      this.btnOk = new System.Windows.Forms.Button();
      this.btnCancel = new System.Windows.Forms.Button();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.radCSV = new System.Windows.Forms.RadioButton();
      this.radExcel = new System.Windows.Forms.RadioButton();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.radArchive = new System.Windows.Forms.RadioButton();
      this.radCurrent = new System.Windows.Forms.RadioButton();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.SuspendLayout();
      // 
      // btnOk
      // 
      this.btnOk.BackColor = System.Drawing.Color.SteelBlue;
      this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnOk.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnOk.ForeColor = System.Drawing.Color.White;
      this.btnOk.Location = new System.Drawing.Point(103, 193);
      this.btnOk.Name = "btnOk";
      this.btnOk.Size = new System.Drawing.Size(106, 31);
      this.btnOk.TabIndex = 0;
      this.btnOk.Text = "OK";
      this.btnOk.UseVisualStyleBackColor = false;
      this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
      // 
      // btnCancel
      // 
      this.btnCancel.BackColor = System.Drawing.Color.SteelBlue;
      this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnCancel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnCancel.ForeColor = System.Drawing.Color.White;
      this.btnCancel.Location = new System.Drawing.Point(245, 193);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.Size = new System.Drawing.Size(106, 31);
      this.btnCancel.TabIndex = 1;
      this.btnCancel.Text = "Cancel";
      this.btnCancel.UseVisualStyleBackColor = false;
      this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.radCSV);
      this.groupBox1.Controls.Add(this.radExcel);
      this.groupBox1.ForeColor = System.Drawing.Color.SteelBlue;
      this.groupBox1.Location = new System.Drawing.Point(46, 13);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(369, 60);
      this.groupBox1.TabIndex = 2;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Export To:";
      // 
      // radCSV
      // 
      this.radCSV.AutoSize = true;
      this.radCSV.ForeColor = System.Drawing.Color.Black;
      this.radCSV.Location = new System.Drawing.Point(229, 22);
      this.radCSV.Name = "radCSV";
      this.radCSV.Size = new System.Drawing.Size(53, 20);
      this.radCSV.TabIndex = 1;
      this.radCSV.TabStop = true;
      this.radCSV.Text = "CSV";
      this.radCSV.UseVisualStyleBackColor = true;
      // 
      // radExcel
      // 
      this.radExcel.AutoSize = true;
      this.radExcel.Checked = true;
      this.radExcel.ForeColor = System.Drawing.Color.Black;
      this.radExcel.Location = new System.Drawing.Point(41, 22);
      this.radExcel.Name = "radExcel";
      this.radExcel.Size = new System.Drawing.Size(59, 20);
      this.radExcel.TabIndex = 0;
      this.radExcel.TabStop = true;
      this.radExcel.Text = "Excel";
      this.radExcel.UseVisualStyleBackColor = true;
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.radArchive);
      this.groupBox2.Controls.Add(this.radCurrent);
      this.groupBox2.ForeColor = System.Drawing.Color.SteelBlue;
      this.groupBox2.Location = new System.Drawing.Point(46, 108);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(369, 60);
      this.groupBox2.TabIndex = 3;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Export From:";
      // 
      // radArchive
      // 
      this.radArchive.AutoSize = true;
      this.radArchive.ForeColor = System.Drawing.Color.Black;
      this.radArchive.Location = new System.Drawing.Point(229, 24);
      this.radArchive.Name = "radArchive";
      this.radArchive.Size = new System.Drawing.Size(68, 20);
      this.radArchive.TabIndex = 1;
      this.radArchive.TabStop = true;
      this.radArchive.Text = "Archive";
      this.radArchive.UseVisualStyleBackColor = true;
      // 
      // radCurrent
      // 
      this.radCurrent.AutoSize = true;
      this.radCurrent.Checked = true;
      this.radCurrent.ForeColor = System.Drawing.Color.Black;
      this.radCurrent.Location = new System.Drawing.Point(41, 24);
      this.radCurrent.Name = "radCurrent";
      this.radCurrent.Size = new System.Drawing.Size(68, 20);
      this.radCurrent.TabIndex = 0;
      this.radCurrent.TabStop = true;
      this.radCurrent.Text = "Current";
      this.radCurrent.UseVisualStyleBackColor = true;
      // 
      // ExportDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(455, 238);
      this.ControlBox = false;
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.btnCancel);
      this.Controls.Add(this.btnOk);
      this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.Name = "ExportDialog";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Export Options";
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button btnOk;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.RadioButton radCSV;
    private System.Windows.Forms.RadioButton radExcel;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.RadioButton radArchive;
    private System.Windows.Forms.RadioButton radCurrent;
  }
}