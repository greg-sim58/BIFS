namespace BreakIn
{
    partial class AddEditMessage
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
          this.btnCancel = new System.Windows.Forms.Button();
          this.label2 = new System.Windows.Forms.Label();
          this.label1 = new System.Windows.Forms.Label();
          this.panel3 = new System.Windows.Forms.Panel();
          this.cmbCategory = new System.Windows.Forms.ComboBox();
          this.label6 = new System.Windows.Forms.Label();
          this.btnRecord = new System.Windows.Forms.Button();
          this.label5 = new System.Windows.Forms.Label();
          this.cmbMessages = new System.Windows.Forms.ComboBox();
          this.label4 = new System.Windows.Forms.Label();
          this.txtDescription = new System.Windows.Forms.TextBox();
          this.label3 = new System.Windows.Forms.Label();
          this.cmbMsgGroup = new System.Windows.Forms.ComboBox();
          this.txtMsgName = new System.Windows.Forms.TextBox();
          this.panel1 = new System.Windows.Forms.Panel();
          this.lblAddEditUserHeading = new System.Windows.Forms.Label();
          this.btnSave = new System.Windows.Forms.Button();
          this.panel2 = new System.Windows.Forms.Panel();
          this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
          this.panel3.SuspendLayout();
          this.panel1.SuspendLayout();
          this.panel2.SuspendLayout();
          this.SuspendLayout();
          // 
          // btnCancel
          // 
          this.btnCancel.BackColor = System.Drawing.Color.SteelBlue;
          this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
          this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
          this.btnCancel.ForeColor = System.Drawing.Color.White;
          this.btnCancel.Location = new System.Drawing.Point(528, 18);
          this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
          this.btnCancel.Name = "btnCancel";
          this.btnCancel.Size = new System.Drawing.Size(112, 32);
          this.btnCancel.TabIndex = 1;
          this.btnCancel.Text = "Close";
          this.btnCancel.UseVisualStyleBackColor = false;
          this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
          // 
          // label2
          // 
          this.label2.AutoSize = true;
          this.label2.Location = new System.Drawing.Point(181, 77);
          this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
          this.label2.Name = "label2";
          this.label2.Size = new System.Drawing.Size(77, 18);
          this.label2.TabIndex = 12;
          this.label2.Text = "Filename:";
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
          // panel3
          // 
          this.panel3.BackColor = System.Drawing.SystemColors.Control;
          this.panel3.Controls.Add(this.cmbCategory);
          this.panel3.Controls.Add(this.label6);
          this.panel3.Controls.Add(this.btnRecord);
          this.panel3.Controls.Add(this.label5);
          this.panel3.Controls.Add(this.cmbMessages);
          this.panel3.Controls.Add(this.label4);
          this.panel3.Controls.Add(this.txtDescription);
          this.panel3.Controls.Add(this.label3);
          this.panel3.Controls.Add(this.label2);
          this.panel3.Controls.Add(this.label1);
          this.panel3.Controls.Add(this.cmbMsgGroup);
          this.panel3.Controls.Add(this.txtMsgName);
          this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
          this.panel3.Location = new System.Drawing.Point(0, 68);
          this.panel3.Name = "panel3";
          this.panel3.Size = new System.Drawing.Size(811, 310);
          this.panel3.TabIndex = 5;
          // 
          // cmbCategory
          // 
          this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this.cmbCategory.FormattingEnabled = true;
          this.cmbCategory.Location = new System.Drawing.Point(266, 158);
          this.cmbCategory.Name = "cmbCategory";
          this.cmbCategory.Size = new System.Drawing.Size(262, 26);
          this.cmbCategory.TabIndex = 22;
          // 
          // label6
          // 
          this.label6.AutoSize = true;
          this.label6.Location = new System.Drawing.Point(182, 161);
          this.label6.Name = "label6";
          this.label6.Size = new System.Drawing.Size(76, 18);
          this.label6.TabIndex = 21;
          this.label6.Text = "Category:";
          // 
          // btnRecord
          // 
          this.btnRecord.BackColor = System.Drawing.Color.SteelBlue;
          this.btnRecord.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
          this.btnRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
          this.btnRecord.ForeColor = System.Drawing.Color.White;
          this.btnRecord.Location = new System.Drawing.Point(547, 74);
          this.btnRecord.Name = "btnRecord";
          this.btnRecord.Size = new System.Drawing.Size(75, 26);
          this.btnRecord.TabIndex = 20;
          this.btnRecord.Text = "New";
          this.btnRecord.UseVisualStyleBackColor = false;
          this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
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
          // cmbMessages
          // 
          this.cmbMessages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this.cmbMessages.FormattingEnabled = true;
          this.cmbMessages.Location = new System.Drawing.Point(266, 74);
          this.cmbMessages.Name = "cmbMessages";
          this.cmbMessages.Size = new System.Drawing.Size(262, 26);
          this.cmbMessages.TabIndex = 18;
          this.cmbMessages.TextChanged += new System.EventHandler(this.CheckSave);
          // 
          // label4
          // 
          this.label4.AutoSize = true;
          this.label4.Location = new System.Drawing.Point(166, 219);
          this.label4.Name = "label4";
          this.label4.Size = new System.Drawing.Size(92, 18);
          this.label4.TabIndex = 15;
          this.label4.Text = "Description:";
          // 
          // txtDescription
          // 
          this.txtDescription.Location = new System.Drawing.Point(266, 216);
          this.txtDescription.Multiline = true;
          this.txtDescription.Name = "txtDescription";
          this.txtDescription.Size = new System.Drawing.Size(432, 66);
          this.txtDescription.TabIndex = 14;
          // 
          // label3
          // 
          this.label3.AutoSize = true;
          this.label3.Location = new System.Drawing.Point(203, 120);
          this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
          this.label3.Name = "label3";
          this.label3.Size = new System.Drawing.Size(55, 18);
          this.label3.TabIndex = 13;
          this.label3.Text = "Group:";
          // 
          // cmbMsgGroup
          // 
          this.cmbMsgGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this.cmbMsgGroup.FormattingEnabled = true;
          this.cmbMsgGroup.Items.AddRange(new object[] {
            "Fire",
            "Accident",
            "Miscellaneous"});
          this.cmbMsgGroup.Location = new System.Drawing.Point(266, 117);
          this.cmbMsgGroup.Margin = new System.Windows.Forms.Padding(4);
          this.cmbMsgGroup.Name = "cmbMsgGroup";
          this.cmbMsgGroup.Size = new System.Drawing.Size(262, 26);
          this.cmbMsgGroup.TabIndex = 10;
          this.cmbMsgGroup.TextChanged += new System.EventHandler(this.CheckSave);
          // 
          // txtMsgName
          // 
          this.txtMsgName.Location = new System.Drawing.Point(266, 33);
          this.txtMsgName.Margin = new System.Windows.Forms.Padding(4);
          this.txtMsgName.Name = "txtMsgName";
          this.txtMsgName.Size = new System.Drawing.Size(262, 26);
          this.txtMsgName.TabIndex = 8;
          this.txtMsgName.TextChanged += new System.EventHandler(this.CheckSave);
          this.txtMsgName.MouseLeave += new System.EventHandler(this.txtMsgName_MouseLeave);
          this.txtMsgName.MouseHover += new System.EventHandler(this.txtMsgName_MouseHover);
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
          this.panel1.Size = new System.Drawing.Size(811, 68);
          this.panel1.TabIndex = 3;
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
          // btnSave
          // 
          this.btnSave.BackColor = System.Drawing.Color.SteelBlue;
          this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
          this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
          this.btnSave.ForeColor = System.Drawing.Color.White;
          this.btnSave.Location = new System.Drawing.Point(153, 18);
          this.btnSave.Margin = new System.Windows.Forms.Padding(4);
          this.btnSave.Name = "btnSave";
          this.btnSave.Size = new System.Drawing.Size(112, 32);
          this.btnSave.TabIndex = 0;
          this.btnSave.Text = "Save";
          this.btnSave.UseVisualStyleBackColor = false;
          this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
          // 
          // panel2
          // 
          this.panel2.BackColor = System.Drawing.Color.White;
          this.panel2.Controls.Add(this.btnCancel);
          this.panel2.Controls.Add(this.btnSave);
          this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
          this.panel2.Location = new System.Drawing.Point(0, 378);
          this.panel2.Margin = new System.Windows.Forms.Padding(4);
          this.panel2.Name = "panel2";
          this.panel2.Size = new System.Drawing.Size(811, 69);
          this.panel2.TabIndex = 4;
          // 
          // openFileDialog1
          // 
          this.openFileDialog1.FileName = "openFileDialog1";
          // 
          // AddEditMessage
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size(811, 447);
          this.ControlBox = false;
          this.Controls.Add(this.panel3);
          this.Controls.Add(this.panel1);
          this.Controls.Add(this.panel2);
          this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
          this.Margin = new System.Windows.Forms.Padding(4);
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "AddEditMessage";
          this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
          this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
          this.Text = "AddEditMessage";
          this.panel3.ResumeLayout(false);
          this.panel3.PerformLayout();
          this.panel1.ResumeLayout(false);
          this.panel1.PerformLayout();
          this.panel2.ResumeLayout(false);
          this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbMsgGroup;
        private System.Windows.Forms.TextBox txtMsgName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblAddEditUserHeading;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox cmbMessages;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label label6;

    }
}