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
  public partial class AddEditSchedule : Form
  {
    const int ADDING = 1;
    const int EDITING = 2;
    public struct Schedule
      {
        public int ID;
        public string MsgName;
        public string Filename;
        public TimeSpan TimeOfDay;
        public DateTime StartDate;
        public DateTime EndDate;
        public bool Mon;
        public bool Tue;
        public bool Wed;
        public bool Thu;
        public bool Fri;
        public bool Sat;
        public bool Sun;
        public bool Tunnel1;
        public bool Tunnel2;
        public bool Enabled;
      }

      private int AddEditAction;
      private int EditID;

      /*
       * Get the message ID from the database given the message filename.
       * REQUIRES: Message filename.
       * RETURNS: MESSAGE id
       */
      private int GetMessageIndex(string s)
      {
        int result = -1;

        for (int i = 0; i < cmbScheduleFilename.Items.Count; i++)
        {
          if (cmbScheduleFilename.Items[i].ToString() == s)
            result = i;
        }
        return result;

      }

      private void LoadMessages()
    {
      string[] files;
      string MsgPath = Settings.RecordedMessageDir;
      if (Directory.Exists(MsgPath))
      {
        files = Directory.GetFiles(MsgPath, @"*.wav", SearchOption.TopDirectoryOnly);
        foreach (string file in files)
        {
          string fn = System.IO.Path.GetFileName(file);
          cmbScheduleFilename.Items.Add(fn);
        }
      }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      Close();
    }

    public AddEditSchedule()
    {
      AddEditAction = ADDING;
      InitializeComponent();
      LoadMessages();
    }

    public AddEditSchedule(int id)
    {
      AddEditAction = EDITING;
      EditID = id;
      InitializeComponent();
      LoadMessages();
      Database db = new Database();
      db.ConnectToDb();
      string sql_str = "SELECT * FROM tblSchedule WHERE ScheduleID=" + id;
      DataTable dt = db.GetTable(sql_str);
      if ((dt != null) && (dt.Rows.Count > 0))
      {
          DataRow dr = dt.Rows[0];
          txtScheduleMessageName.Text = dr["MessageName"].ToString();
          dtpTimeOfDay.Value =  Convert.ToDateTime(dr["TimeOfDay"]);
          dtpStartDate.Value = Convert.ToDateTime(dr["StartDate"]);
          dtpEndDate.Value = Convert.ToDateTime(dr["EndDate"]);
          chkScheduleMon.Checked = Convert.ToBoolean(dr["Mon"]);
          chkScheduleTue.Checked = Convert.ToBoolean(dr["Tue"]);
          chkScheduleWed.Checked = Convert.ToBoolean(dr["Wed"]);
          chkScheduleThu.Checked = Convert.ToBoolean(dr["Thu"]);
          chkScheduleFri.Checked = Convert.ToBoolean(dr["Fri"]);
          chkScheduleSat.Checked = Convert.ToBoolean(dr["Sat"]);
          chkScheduleSun.Checked = Convert.ToBoolean(dr["Sun"]);
          chkTunnel1.Checked = Convert.ToBoolean(dr["Tunnel1"]);
          chkTunnel2.Checked = Convert.ToBoolean(dr["Tunnel2"]);
          chkScheduleEnabled.Checked = Convert.ToBoolean(dr["Enabled"]);
          cmbScheduleFilename.SelectedIndex = GetMessageIndex(dr["FileName"].ToString());
      }
      
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        Schedule Sch = new Schedule();
        Sch.MsgName = txtScheduleMessageName.Text;
        Sch.Filename = cmbScheduleFilename.SelectedItem.ToString();
        Sch.TimeOfDay = dtpTimeOfDay.Value.TimeOfDay;
        Sch.EndDate = dtpEndDate.Value.Date;
        Sch.StartDate = dtpStartDate.Value.Date;
        Sch.Mon = chkScheduleMon.Checked;
        Sch.Tue = chkScheduleTue.Checked;
        Sch.Wed = chkScheduleWed.Checked;
        Sch.Thu = chkScheduleThu.Checked;
        Sch.Fri = chkScheduleFri.Checked;
        Sch.Sat = chkScheduleSat.Checked;
        Sch.Sun = chkScheduleSun.Checked;
        Sch.Tunnel1 = chkTunnel1.Checked;
        Sch.Tunnel2 = chkTunnel2.Checked;
        Sch.Enabled = chkScheduleEnabled.Checked;

        Database db = new Database();
        db.ConnectToDb();

        if (AddEditAction == ADDING)
        {
          if (db.SaveSchedule(Sch) == 0)
            MessageBox.Show("ERROR: Could not save the schedule");
        }
        else
        {
          Sch.ID = EditID;
          if (db.UpdateSchedule(Sch) == 0)
            MessageBox.Show("ERROR: Could not update the schedule table");
        }
        db = null;
        Close();
    }
  }
}
