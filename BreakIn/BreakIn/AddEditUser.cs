using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BreakIn
{
    public partial class AddEditUser : Form
    {
        const int ADDING  = 1;
        const int EDITING = 2;

        private int AddEditAction;
        private int EditID;

        private void LoadUser(int id)
        {
          Database db = new Database();
          db.ConnectToDb();
          DataTable tbl = db.GetTable("SELECT * FROM tblUsers WHERE UserID=" + id);
          if (tbl != null)
          {
            DataRow row = tbl.Rows[0];

            txtUserName.Text = row["UserName"].ToString();
            txtPassword.Text = row["Password"].ToString();
            cmbAccessLevel.SelectedIndex = (int)(row["Level"]) - 1;
          }
        }

        public AddEditUser()
        {
            InitializeComponent();
            AddEditAction = ADDING;
            lblAddEditUserHeading.Text = "Add User";
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtUserName.Enabled = true;
            btnSave.Enabled = false;
            cmbAccessLevel.SelectedIndex = 0;
        }

        public AddEditUser(int id)
        {
            EditID = id;
            InitializeComponent();
            AddEditAction = EDITING;
            lblAddEditUserHeading.Text = "Edit User";
            LoadUser(id);
            txtUserName.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
          /*if (btnCancel.Text == "Close")
            Close();
          else
          {
            txtUserName.Text = "";
            txtPassword.Text = "";
            cmbAccessLevel.SelectedIndex = 0;
          }*/
          Close();
            
        }

        private bool CheckForExistingUsername(string str)
        {
          bool result = true;
          string sql_str = "SELECT UserID FROM tblUsers WHERE UserName='" + str + "';";
          Database db = new Database();
          db.ConnectToDb();
          result = (db.GetRecordCount(sql_str) != 0);
          db = null;
          return result;
        }

        private int SaveUserData(string str)
        {
          int result = 0;
          Database db = new Database();
          db.ConnectToDb();
          result = db.ExecuteQry(str);
          db = null;
          return result;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
          string sql_str;
          if (AddEditAction == ADDING)
            sql_str = "INSERT INTO tblUsers ( UserName, [Password], [Level] ) " +
               "VALUES ('" + txtUserName.Text + "','" + txtPassword.Text + "'," + (int)(cmbAccessLevel.SelectedIndex + 1) + ")";
          else
            sql_str = "UPDATE tblUsers SET UserName = '" + txtUserName.Text + "', [Password] = '" + txtPassword.Text + "', [Level] = " + (int)(cmbAccessLevel.SelectedIndex + 1) + " WHERE UserID=" + EditID;

              if ((AddEditAction == EDITING) | (CheckForExistingUsername(txtUserName.Text) == false) )
              {
                if (SaveUserData(sql_str) == 0)
                  MessageBox.Show("ERROR: Record not saved");
                else
                  Close();
              }
              else
                MessageBox.Show("Username already exists.\n\rPlease choose another name.");
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
          if ((txtUserName.Text == "") & (txtPassword.Text == ""))
            btnCancel.Text = "Close";
          else
            btnCancel.Text = "Cancel";
          btnSave.Enabled = (txtUserName.Text != "") & (txtPassword.Text != "");
        }
    }
}
