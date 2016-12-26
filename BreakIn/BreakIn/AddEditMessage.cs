using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace BreakIn
{
    public partial class AddEditMessage : Form
    {
      const int ADDING = 1;
      const int EDITING = 2;

      private Form1 f1;
      private int AddEditAction;
      private int EditID;

      /*-------------------------------------------------------------------------------------------------------------------------------*/
      /* PRIVATE                                                                                                                       */
      /*-------------------------------------------------------------------------------------------------------------------------------*/
      private int GetCategoryId(string s)
      {
        int result = 0;

        Database db = new Database();
        db.ConnectToDb();
        result = db.GetCategoryID(s);
        db = null;

        return result;
      }

      private int GetCategoryIndex(string s)
      {
        int result = -1;

        for (int i = 0; i < cmbCategory.Items.Count; i++)
        {
          if (cmbCategory.Items[i].ToString() == s)
            result = i;
        }
        return result;

      }

      private int GetMessageIndex(string s)
      {
        int result = -1;

        for (int i = 0; i < cmbMessages.Items.Count; i++)
        {
          if (cmbMessages.Items[i].ToString() == s)
            result = i;
        }
        return result;

      }

      private void LoadUser(int id)
      {
        Database db = new Database();
        db.ConnectToDb();
        DataTable tbl = db.GetTable("SELECT tblMessages.MessageID, tblMessages.MessageName, tblMessages.MessageDescription, " +
             "tblMessages.MessageFilename, tblMessages.MessageGroup, tblMessages.MessageCategory, tblMsgGroups.GroupName, " +
             "tblCategories.CategoryName " +
             "FROM (tblMessages LEFT JOIN tblMsgGroups ON tblMessages.MessageGroup = tblMsgGroups.GroupID) LEFT JOIN " +
             "tblCategories ON tblMessages.MessageCategory = tblCategories.CategoryID " +
             "WHERE tblMessages.MessageID=" + id);
        if (tbl != null)
        {
          DataRow row = tbl.Rows[0];

          txtMsgName.Text = row["MessageName"].ToString();
          cmbMessages.SelectedIndex = GetMessageIndex(row["MessageFileName"].ToString());
          cmbMsgGroup.SelectedIndex = (int)(row["MessageGroup"]) - 1;
          cmbCategory.SelectedIndex = GetCategoryIndex(row["CategoryName"].ToString());
          txtDescription.Text = row["MessageDescription"].ToString();
        }
      }

      private void LoadMessages()
      {
        string[] files;
        //string MsgPath = Directory.GetCurrentDirectory() + "\\recordedmessages";
        string MsgPath = Settings.RecordedMessageDir;
        if (Directory.Exists(MsgPath))
        {
          files = Directory.GetFiles(MsgPath, @"*.wav", SearchOption.TopDirectoryOnly);
          foreach (string file in files)
          {
            string fn = System.IO.Path.GetFileName(file);
            cmbMessages.Items.Add(fn);
          }
        }
      }

      private void LoadCategories()
      {
        Database db = new Database();
        db.ConnectToDb();
        DataTable tbl = db.GetTable("SELECT CategoryID, CategoryName FROM tblCategories ORDER BY CategoryName;");
        if (tbl != null)
        {
          //DataRow row = tbl.Rows[0];
          foreach (DataRow row in tbl.Rows) 
            cmbCategory.Items.Add((string)(row["CategoryName"]));
        }
      }

      /*-------------------------------------------------------------------------------------------------------------------------------*/
      /* PUBLIC                                                                                                                        */
      /*-------------------------------------------------------------------------------------------------------------------------------*/

      public AddEditMessage()
      {
        InitializeComponent();
        LoadMessages();
        LoadCategories();
        AddEditAction = ADDING;
        lblAddEditUserHeading.Text = "Add Message";
        txtMsgName.Text = "";
        //cmbMsgGroup.SelectedIndex = 0;
        //cmbMessages.SelectedIndex = 0;
        btnSave.Enabled = false;
      }

      public AddEditMessage(int id)
      {
        InitializeComponent();
        EditID = id;
        AddEditAction = EDITING;
        lblAddEditUserHeading.Text = "Edit Message";
        LoadMessages();
        LoadCategories();
        LoadUser(id);
      }

      /*-------------------------------------------------------------------------------------------------------------------------------*/
      /* USER EVENTS                                                                                                                   */
      /*-------------------------------------------------------------------------------------------------------------------------------*/

      private void CheckSave(object sender, EventArgs e)
      {
        btnSave.Enabled = true;
        if ((txtMsgName == null ) || (txtMsgName.Text == ""))
          btnSave.Enabled = false;
        //if ((cmbMsgGroup == null) || (cmbMsgGroup.SelectedItem.ToString() == ""))
        //  btnSave.Enabled = false;
        //if ((cmbMessages == null) || (cmbMessages.SelectedItem.ToString() == ""))
        //  btnSave.Enabled = false;
      }
      /*-------------------------------------------------------------------------------------------------------------------------------*/
      /* FORM EVENTS                                                                                                                   */
      /*-------------------------------------------------------------------------------------------------------------------------------*/

      private void btnCancel_Click(object sender, EventArgs e)
      {
        Close();
      }

      private void btnSave_Click(object sender, EventArgs e)
      {
        string sql_str;
        int id = GetCategoryId(cmbCategory.SelectedItem.ToString());

        if (AddEditAction == ADDING)
          sql_str = "INSERT INTO tblMessages ( MessageName, MessageFilename, MessageGroup, MessageDescription,  MessageCategory) " +
             "VALUES ('" + txtMsgName.Text + "','" + cmbMessages.SelectedItem.ToString() + "'," + (int)(cmbMsgGroup.SelectedIndex + 1) + ",'" + 
             txtDescription.Text + "'," + GetCategoryId(cmbCategory.SelectedItem.ToString()) + ")";
        else
          sql_str = "UPDATE tblMessages SET MessageName = '" + txtMsgName.Text + "', [MessageFilename] = '" + 
              cmbMessages.SelectedItem.ToString() + "', [MessageGroup] = " + (int)(cmbMsgGroup.SelectedIndex + 1) + 
              ", MessageDescription = '" + txtDescription.Text + "', MessageCategory = " + id.ToString() +
            " WHERE MessageID=" + EditID;
        try
        {
          Database db = new Database();
          db.ConnectToDb();
          if (db.ExecuteQry(sql_str) == 0)
            MessageBox.Show("ERROR: Record not saved");
        }
        catch (Exception ex)
        {
          MessageBox.Show("Error - Could not access the database " + Environment.NewLine + ex.Message);
        }
        Close();
      }

      private void txtMsgName_MouseHover(object sender, EventArgs e)
      {
        label5.Visible = true;
      }

      private void txtMsgName_MouseLeave(object sender, EventArgs e)
      {
        label5.Visible = false;
      }

      private void btnRecord_Click(object sender, EventArgs e)
      {
        Recorder r = new Recorder();
        r.ShowDialog();
        string newmsg = r.GetRecordedMessage();
        cmbMessages.Items.Add(newmsg);
        cmbMessages.SelectedIndex = cmbMessages.Items.Count - 1;
        r.Dispose();
      }
    }
}
