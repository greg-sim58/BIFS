namespace BreakIn
{
    partial class DataTbl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
          System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
          System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
          this.panel3 = new System.Windows.Forms.Panel();
          this.GridView = new System.Windows.Forms.DataGridView();
          this.panel2 = new System.Windows.Forms.Panel();
          this.btnClose = new System.Windows.Forms.Button();
          this.btnDelete = new System.Windows.Forms.Button();
          this.btnEdit = new System.Windows.Forms.Button();
          this.btnAdd = new System.Windows.Forms.Button();
          this.panel1 = new System.Windows.Forms.Panel();
          this.lblPageTitle = new System.Windows.Forms.Label();
          this.panel3.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this.GridView)).BeginInit();
          this.panel2.SuspendLayout();
          this.panel1.SuspendLayout();
          this.SuspendLayout();
          // 
          // panel3
          // 
          this.panel3.Controls.Add(this.GridView);
          this.panel3.Controls.Add(this.panel2);
          this.panel3.Controls.Add(this.panel1);
          this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
          this.panel3.Location = new System.Drawing.Point(0, 0);
          this.panel3.Name = "panel3";
          this.panel3.Size = new System.Drawing.Size(891, 484);
          this.panel3.TabIndex = 2;
          // 
          // GridView
          // 
          this.GridView.AllowUserToAddRows = false;
          this.GridView.AllowUserToDeleteRows = false;
          this.GridView.AllowUserToOrderColumns = true;
          this.GridView.AllowUserToResizeRows = false;
          dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
          dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Teal;
          this.GridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
          this.GridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
          this.GridView.BackgroundColor = System.Drawing.Color.White;
          this.GridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
          this.GridView.Cursor = System.Windows.Forms.Cursors.Default;
          this.GridView.Dock = System.Windows.Forms.DockStyle.Fill;
          this.GridView.Location = new System.Drawing.Point(0, 32);
          this.GridView.Name = "GridView";
          this.GridView.ReadOnly = true;
          dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.MediumSeaGreen;
          this.GridView.RowsDefaultCellStyle = dataGridViewCellStyle2;
          this.GridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
          this.GridView.Size = new System.Drawing.Size(891, 398);
          this.GridView.TabIndex = 5;
          // 
          // panel2
          // 
          this.panel2.BackColor = System.Drawing.Color.White;
          this.panel2.Controls.Add(this.btnClose);
          this.panel2.Controls.Add(this.btnDelete);
          this.panel2.Controls.Add(this.btnEdit);
          this.panel2.Controls.Add(this.btnAdd);
          this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
          this.panel2.Location = new System.Drawing.Point(0, 430);
          this.panel2.Name = "panel2";
          this.panel2.Size = new System.Drawing.Size(891, 54);
          this.panel2.TabIndex = 7;
          // 
          // btnClose
          // 
          this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Top;
          this.btnClose.BackColor = System.Drawing.Color.SteelBlue;
          this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
          this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
          this.btnClose.ForeColor = System.Drawing.Color.White;
          this.btnClose.Location = new System.Drawing.Point(623, 9);
          this.btnClose.Name = "btnClose";
          this.btnClose.Size = new System.Drawing.Size(138, 36);
          this.btnClose.TabIndex = 3;
          this.btnClose.Text = "Close";
          this.btnClose.UseVisualStyleBackColor = false;
          this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
          // 
          // btnDelete
          // 
          this.btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Top;
          this.btnDelete.BackColor = System.Drawing.Color.SteelBlue;
          this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
          this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
          this.btnDelete.ForeColor = System.Drawing.Color.White;
          this.btnDelete.Location = new System.Drawing.Point(456, 9);
          this.btnDelete.Name = "btnDelete";
          this.btnDelete.Size = new System.Drawing.Size(138, 36);
          this.btnDelete.TabIndex = 2;
          this.btnDelete.Text = "Delete";
          this.btnDelete.UseVisualStyleBackColor = false;
          this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
          // 
          // btnEdit
          // 
          this.btnEdit.Anchor = System.Windows.Forms.AnchorStyles.Top;
          this.btnEdit.BackColor = System.Drawing.Color.SteelBlue;
          this.btnEdit.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
          this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
          this.btnEdit.ForeColor = System.Drawing.Color.White;
          this.btnEdit.Location = new System.Drawing.Point(289, 9);
          this.btnEdit.Name = "btnEdit";
          this.btnEdit.Size = new System.Drawing.Size(138, 36);
          this.btnEdit.TabIndex = 1;
          this.btnEdit.Text = "Edit";
          this.btnEdit.UseVisualStyleBackColor = false;
          this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
          // 
          // btnAdd
          // 
          this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Top;
          this.btnAdd.BackColor = System.Drawing.Color.SteelBlue;
          this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
          this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
          this.btnAdd.ForeColor = System.Drawing.Color.White;
          this.btnAdd.Location = new System.Drawing.Point(122, 9);
          this.btnAdd.Name = "btnAdd";
          this.btnAdd.Size = new System.Drawing.Size(138, 36);
          this.btnAdd.TabIndex = 0;
          this.btnAdd.Text = "Add";
          this.btnAdd.UseVisualStyleBackColor = false;
          this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
          // 
          // panel1
          // 
          this.panel1.BackColor = System.Drawing.Color.White;
          this.panel1.Controls.Add(this.lblPageTitle);
          this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
          this.panel1.Location = new System.Drawing.Point(0, 0);
          this.panel1.Name = "panel1";
          this.panel1.Size = new System.Drawing.Size(891, 32);
          this.panel1.TabIndex = 6;
          // 
          // lblPageTitle
          // 
          this.lblPageTitle.AutoSize = true;
          this.lblPageTitle.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.lblPageTitle.ForeColor = System.Drawing.Color.SteelBlue;
          this.lblPageTitle.Location = new System.Drawing.Point(26, 4);
          this.lblPageTitle.Name = "lblPageTitle";
          this.lblPageTitle.Size = new System.Drawing.Size(65, 24);
          this.lblPageTitle.TabIndex = 0;
          this.lblPageTitle.Text = "label1";
          // 
          // DataTbl
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.Controls.Add(this.panel3);
          this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
          this.Margin = new System.Windows.Forms.Padding(4);
          this.Name = "DataTbl";
          this.Size = new System.Drawing.Size(891, 484);
          this.panel3.ResumeLayout(false);
          ((System.ComponentModel.ISupportInitialize)(this.GridView)).EndInit();
          this.panel2.ResumeLayout(false);
          this.panel1.ResumeLayout(false);
          this.panel1.PerformLayout();
          this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView GridView;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblPageTitle;
    }
}
