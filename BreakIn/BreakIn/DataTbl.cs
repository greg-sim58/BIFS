using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace BreakIn
{

  public partial class DataTbl : UserControl
  {

    enum DataTableTypes
    {
      User,
      Message,
      Log,
      Schedule
    };
    private Form1 f1;
    private string sql_str;
    private DataTableTypes DataTableType;

    #region constructor

    public DataTbl(Form1 f)
    {
        InitializeComponent();
        this.Dock = DockStyle.Fill;
        f1 = f;
    }
    #endregion

    #region private

    /*
     * Show table denoted by table type.
     * Get the relevant data from the database and display it in a table.
     */
    private void ShowTable(DataTableTypes t)
    {
      switch (t)
      {
        case DataTableTypes.User   : lblPageTitle.Text = "User Table"; break;
        case DataTableTypes.Message: lblPageTitle.Text = "Message Table"; break;
        case DataTableTypes.Log:
          {
            btnAdd.Text = "Export";
            btnEdit.Text = "Clear Logs";
            lblPageTitle.Text = "Logs Table";
            break;
          }
        default: break;
      }
      btnEdit.Visible = (t == DataTableTypes.Log);
      btnDelete.Visible = (t != DataTableTypes.Log);

      GridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.Navy;
      GridView.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 8, FontStyle.Bold); ;
      
      GridView.DataSource = null;
      Database db = new Database();
      db.ConnectToDb();
      try
      {
          DataTable tbl = new DataTable();
          tbl = db.GetTable(sql_str);
          if (tbl != null)
          {
              GridView.DataSource = tbl;
          }
      }
      catch (Exception ee)
      {
          MessageBox.Show(ee.Message);
      }
    }

    /*
     * Deletes a record from a table in the database.
     * REQUIRES: a sql query string that contains the delete statement.
     * RETURNS: the number of rows affected.  If rows affected = 0, then no record was deleted.
     */
    private int DeleteRecord(string str)
    {
      Database db = new Database();
        
      db.ConnectToDb();
      return db.ExecuteQry(str);
    }

    /*
     * Closes the form.
     */
    private void btnClose_Click(object sender, EventArgs e)
    {
        f1.SetMainTab(1);
    }

    #endregion

    #region public

    /* Displys the users table.
     * REQUIRES: nothing.
     * RETURNS: nothing.
     */
    public void ShowUsers()
    {
      DataTableType = DataTableTypes.User;
        sql_str = "SELECT tblUsers.UserID, tblUsers.UserName, tblUsers.Password, tblUserGroups.UserGroupName " +
          "FROM tblUsers LEFT JOIN tblUserGroups ON tblUsers.Level = tblUserGroups.UserGroupID;";
        ShowTable(DataTableTypes.User);
    }

    /* Displys the messages table.
     * REQUIRES: nothing.
     * RETURNS: nothing.
     */
    public void ShowMessages()
    {
      DataTableType = DataTableTypes.Message;
      sql_str = "SELECT tblMessages.MessageID, tblMessages.MessageName, tblMessages.MessageDescription, " +
                "tblMessages.MessageFilename, tblMsgGroups.GroupName, tblCategories.CategoryName " +
                "FROM (tblMessages LEFT JOIN tblMsgGroups ON tblMessages.MessageGroup = tblMsgGroups.GroupID) " +
                "LEFT JOIN tblCategories ON tblMessages.MessageCategory = tblCategories.CategoryID;";
      ShowTable(DataTableTypes.Message);
    }

    /* Displys the schedule table.
     * REQUIRES: nothing.
     * RETURNS: nothing.
     */
    public void ShowSchedules()
    {
      DataTableType = DataTableTypes.Schedule;
      sql_str = "SELECT * " +
                "FROM tblSchedule;";
      ShowTable(DataTableTypes.Schedule);
    }

    /* Displys the logs table.
     * REQUIRES: nothing.
     * RETURNS: nothing.
     */
    public void ShowLogs()
    {
      DataTableType = DataTableTypes.Log;
      sql_str = "SELECT tblLogs.LogID, tblLogs.LogDate, tblMessages.MessageName, tblMessages.MessageDescription, " +
            "tblMessages.MessageFilename, tblLogs.MsgStart, tblLogs.MsgStop, tblLogs.Duration, tblLogs.Loop, " +
            "tblUsers.UserName, tblUserGroups.UserGroupName, tblLogs.Tunnel1, tblLogs.Tunnel2, MsgType " +
            "FROM ((tblLogs LEFT JOIN tblMessages ON tblLogs.MessageID = tblMessages.MessageID) LEFT JOIN tblUsers " +
            "ON tblLogs.UserID = tblUsers.UserID) LEFT JOIN tblUserGroups ON tblUsers.Level = tblUserGroups.UserGroupID;";
      ShowTable(DataTableTypes.Log);
    }

    #endregion

    /*
     * Adds a new record to the current table in the database.
     * REQUIRES: nothing.
     * RETURNS: nothing.
     */
    private void btnAdd_Click(object sender, EventArgs e)
    {
      if (btnAdd.Text == "Add")
      {
        Form ae = new Form();

        if (DataTableType == DataTableTypes.User)
          ae = new AddEditUser();
        else if (DataTableType == DataTableTypes.Message)
          ae = new AddEditMessage();
        else if (DataTableType == DataTableTypes.Schedule)
          ae = new AddEditSchedule();
        ae.ShowDialog();
        ShowTable(DataTableType);
        ae.Dispose();
      }
      else if (btnAdd.Text == "Export")
      {
        ExportDialog ed = new ExportDialog();
        ed.ShowDialog();

        //Database db = new Database();
        //db.ConnectToDb();
        //db.ExportLogsToExcel();
        //db = null;
      }
    }

    /*
     * Edits an existing record in the current table in the database.
     * REQUIRES: nothing.
     * RETURNS: nothing.
     */
    private void btnEdit_Click(object sender, EventArgs e)
    {
        if (btnEdit.Text == "Edit")
        {
            int id = (int)GridView.Rows[GridView.CurrentCell.RowIndex].Cells[0].Value;
            Form ae = new Form();
            if (DataTableType == DataTableTypes.User)
                ae = new AddEditUser(id);
            else if (DataTableType == DataTableTypes.Message)
                ae = new AddEditMessage(id);
            else if (DataTableType == DataTableTypes.Schedule)
                ae = new AddEditSchedule(id);
            ae.ShowDialog();
            ShowTable(DataTableType);
            ae.Dispose();
        }
        else
        {
            if (MessageBox.Show("Are you sure you want to clear the logs?\n\r (Logs are archived)","",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
              Database db = new Database();
              db.ConnectToDb();
              db.ExecuteQry("DELETE tblLogs.* FROM tblLogs;");
              db = null;
              ShowTable(DataTableType);
            }
        }
    }

    /*
     * Deletes the selected from the tale in the database.
     * REQUIRES: nothing.
     * RETURNS: nothing.
     */
    private void btnDelete_Click(object sender, EventArgs e)
    {
      string TableName = "";
      if (DataTableType == DataTableTypes.User)
        TableName = "tblUsers";
      else if (DataTableType == DataTableTypes.Message)
        TableName = "tblMessages";
      else if (DataTableType == DataTableTypes.Schedule)
        TableName = "tblSchedule";
      string FieldName = GridView.Columns[0].Name;
      
      int id = (int)GridView.Rows[GridView.CurrentCell.RowIndex].Cells[0].Value;
      MessageBoxButtons buttons = MessageBoxButtons.YesNo;
      int row = GridView.SelectedRows[0].Index;
      if (MessageBox.Show("Are you sure you want to delete '" + GridView.Rows[row].Cells[1].Value.ToString()  + "'?", "", buttons) == DialogResult.Yes)
      {
        string qry_str = "DELETE FROM " + TableName + " WHERE " + FieldName + "=" + id.ToString();
        if (DeleteRecord(qry_str) == 0)
          MessageBox.Show("ERROR: Could not delete selected record!");
      }
      ShowTable(DataTableType);
    }
  }
}
