using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Data.OleDb;
using Microsoft.Office.Interop.Excel;

namespace BreakIn
{
    class Database
    {
        private OleDbConnection ole_con;
        private OleDbCommand ole_cmd;

        /*
         * Method to connect to the database,  Also opens db to check connection,
         * then closes db.
         */
        public void ConnectToDb()
        {
            string con_str = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=bs_breakin.mdb;Jet OLEDB:Database Password=r0adk1ll";
            try
            {
              ole_con = new OleDbConnection(con_str);
              ole_con.Open();
              ole_con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to connect to database: \r\n" + e.Message);
            }
        }
        /*
         * Method to validate a username against a password.
         * If the user is valid, the user details are returned as a instance
         * of class user.
         */
        public User GetUserDetails(string user_name)
        {
            User res = new User();
            string cmd_str = "SELECT tblUsers.UserID, tblUsers.UserName, tblUsers.Password, tblUsers.Level " +
                             "FROM tblUsers " +
                             "WHERE (((tblUsers.UserName)='" + user_name + "'));";
            ole_cmd = new OleDbCommand(cmd_str, ole_con);
            try
            {
              ole_con.Open();
              OleDbDataAdapter ole_adapter = new OleDbDataAdapter(cmd_str, ole_con);
              OleDbDataReader ole_reader = ole_cmd.ExecuteReader();
              if (ole_reader != null)
              {
                ole_reader.Read();
                if (ole_reader.HasRows)
                {
                  res.UserID = (int)ole_reader[0];
                  res.UserName = ole_reader[1].ToString();
                  res.Password = ole_reader[2].ToString();
                  res.Accesslevel = (int)ole_reader[3];
                }
              }
              ole_con.Close();
            }
            catch (Exception e)
            {
              MessageBox.Show("DATABASE ERROR:\n\r " + e.Message);
            }
            return res;
        }

        /*
         * Queries the database for a table. 
         * Use when data is expected from the query.
         * Requires a sql query string.
         * Returns a DataTable.
         */
        public System.Data.DataTable GetTable(string cmd_str)
        {
          System.Data.DataTable ole_table = new System.Data.DataTable();
            ole_cmd = new OleDbCommand(cmd_str, ole_con);
            try
            {
              ole_con.Open();
              OleDbDataAdapter ole_adapter = new OleDbDataAdapter(cmd_str, ole_con);
              OleDbDataReader ole_reader = ole_cmd.ExecuteReader();
              if (ole_reader != null)
                ole_adapter.Fill(ole_table);
              ole_con.Close();
            }
            catch (Exception e)
            {
              MessageBox.Show("DATABASE ERROR:\n\r " + e.Message);
            }
            return ole_table;
        }

        /*
         * Execute an sql query on the database. 
         * Use for updates, edits, deletes, etc.
         * REQUIRES: a sql query string.
         * RETURNS: Number of records affected.
         */
        public int ExecuteQry(string cmd_str)
        {
          int result = 0;
          ole_cmd = new OleDbCommand(cmd_str, ole_con);
          try
          {
            ole_con.Open();
            OleDbCommand cmd = new OleDbCommand(cmd_str, ole_con);
            result = cmd.ExecuteNonQuery();
            ole_con.Close();
          }
          catch (Exception e)
          {
            MessageBox.Show("DATABASE ERROR:\n\r " + e.Message);
          }
          return result;
        }

        /*
         * Get the number of records in a table.
         * REQUIRES: a sql query string which will return a table.
         * RETURNS: the number of records in the table.
         */
        public int GetRecordCount(string cmd_str)
        {
          int result = 99;  // must return user exists on failure
          System.Data.DataTable ole_table = new System.Data.DataTable();
          ole_cmd = new OleDbCommand(cmd_str, ole_con);
          try
          {
            ole_con.Open();
            OleDbDataAdapter ole_adapter = new OleDbDataAdapter(cmd_str, ole_con);
            OleDbDataReader ole_reader = ole_cmd.ExecuteReader();
            if (ole_reader != null)
            {
              ole_adapter.Fill(ole_table);
              result = ole_table.Rows.Count;
            }
            ole_con.Close();
          }
          catch (Exception e)
          {
            MessageBox.Show("DATABASE ERROR:\n\r " + e.Message);
          }
          return result;
        }

        /*
         * Gets the ID of a specific record in a specific table.
         * The sql string must contain the tabe name, the ID field name.
         * REQUIRES: an sql query that returns a table.
         * RETURNS: an integer denoting the requested ID.  Returns 0 if record does not exist.
         */
        public int GetIdFromString(string sql_str, string fld)
        {
          int result = 0;

          System.Data.DataTable tbl = GetTable(sql_str);
          if (tbl != null)
          {
            if (tbl.Rows.Count > 0)
            {
              DataRow row = tbl.Rows[0];
              result = (int)(row[fld]);
            }
          }

          return result;
        }

        /*
         * Gets the CateoryID from the database for a specific CategoryName
         * Accepts a string CategoryName
         * Returns an int : CategoryID od 0 if CategoryName does not exist.
         */
        public int GetCategoryID(string s)
        {
            int result = 0;
            string sql_str = "SELECT CategoryID FROM tblCategories WHERE CategoryName='" + s + "'";
            result = GetIdFromString(sql_str, "CategoryID");
            return result;
        }

        /*
         * Takes a log and saves the data therein to the database.
         * Accepts Logs l 
         * Return int result of database operation.
         */
        public int AppendLog(Logs l)
        {
          int result = 0;
          string s = "INSERT INTO tblLogs (LogDate, MessageID, Duration, MsgStart, MsgStop, Loop, UserID, Tunnel1, Tunnel2, MsgType ) " +
            "VALUES ('" + l.LogDate + "'," + l.MsgID + ",'" + l.Duration + "','" +
            l.StartDateTime + "','" + l.StopDateTime + "'," + l.Looped + "," + l.UserID + "," + l.Tunnel1 + "," + l.Tunnel2 + ",'"
            + l.MsgType + "');";
          result = ExecuteQry(s);

          return result;
        }

        /*
         * Takes a log and saves it to the archive table, essentially making a copy of the log.
         * Accepts Logs l 
         * Return int result of database operation.
         */
        public int ArchiveLog(Logs l)
        {
          int result = 0;
          string s = "INSERT INTO tblLogsArchive (LogDate, MessageID, Duration, MsgStart, MsgStop, Loop, UserID, Tunnel1, Tunnel2, MsgType ) " +
            "VALUES ('" + l.LogDate + "'," + l.MsgID + ",'" + l.Duration + "','" +
            l.StartDateTime + "','" + l.StopDateTime + "'," + l.Looped + "," + l.UserID + "," + l.Tunnel1 + "," + l.Tunnel2 + ",'"
            + l.MsgType + "');";
          result = ExecuteQry(s);

          return result;
        }

        /*
         * Exports a datatable to MS Excel.
         * Note that Excel must be installed on the host computer for this feature to work.
         * REQUIRES: an sql query that returns a table.
         * RETURNS: nothing.
         */
        public void ExportTableToExcel(string sql)
        {
          System.Data.DataTable dt = GetTable(sql);

          if ((dt != null) && (dt.Rows.Count != 0))
          {
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            if (xlApp == null)
            {
              MessageBox.Show("ERROR: Cannot create an Excel application");
              return;
            }

            System.Globalization.CultureInfo CurrentCI = System.Threading.Thread.CurrentThread.CurrentCulture;
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
            Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];
            Microsoft.Office.Interop.Excel.Range range;

            long totalCount = dt.Rows.Count;
            long rowRead = 0;
            float percent = 0;
            for (int i = 0; i < dt.Columns.Count; i++)
            {
              worksheet.Cells[1, i + 1] = dt.Columns[i].ColumnName;
              range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[1, i + 1];
              range.Interior.ColorIndex = 15;
              range.Font.Bold = true;
            }
            for (int r = 0; r < dt.Rows.Count; r++)
            {
              for (int i = 0; i < dt.Columns.Count; i++)
              {
                worksheet.Cells[r + 2, i + 1] = dt.Rows[r][i].ToString();
              }
              rowRead++;
              percent = ((float)(100 * rowRead)) / totalCount;
            }
            xlApp.Visible = true;
          }
        }

        /*
         * Exports a datatable to MS Excel.
         * Note that Excel must be installed on the host computer for this feature to work.
         * REQUIRES: an sql query that returns a table.
         * RETURNS: nothing.
         */
        public void ExportTableToCsv(string sql)
        {
          string FName = Directory.GetCurrentDirectory() + "\\TmpCsv.txt";
          string StrToWrite = "";
          System.Data.DataTable dt = GetTable(sql);
          StreamWriter sw = new StreamWriter(FName);

          if ((dt != null) && (dt.Rows.Count != 0))
          {
            for (int i = 0; i < dt.Columns.Count-1; i++)
            {
              StrToWrite += dt.Columns[i].ColumnName + ",";
            }
            StrToWrite += dt.Columns[dt.Columns.Count - 1].ColumnName;
            sw.WriteLine(StrToWrite);
            for (int r = 0; r < dt.Rows.Count; r++)
            {
              StrToWrite = "";
              for (int i = 0; i < dt.Columns.Count-1; i++)
              {
                StrToWrite += dt.Rows[r][i].ToString() + ",";
              }
              StrToWrite += dt.Rows[r][dt.Columns.Count - 1].ToString();
              sw.WriteLine(StrToWrite);
            }
          }
          sw.Close();
          System.Diagnostics.Process.Start(@"notepad.exe",FName);
        }

        /*
         * Exports the logs in tblLOgs to MS Excel.
         * Note that Excel must be installed on the host computer for this feature to work.
         * REQUIRES: nothing.
         * RETURNS: nothing.
         */
        public void ExportLogsToExcel()
        {
          Cursor.Current = Cursors.WaitCursor;
          string s = "SELECT tblLogs.LogID, tblLogs.LogDate, tblMessages.MessageName, tblMessages.MessageDescription, " +
            "tblMessages.MessageFilename, tblLogs.MsgStart, tblLogs.MsgStop, tblLogs.Duration, tblLogs.Loop, " +
            "tblUsers.UserName, tblUserGroups.UserGroupName, tblLogs.Tunnel1, tblLogs.Tunnel2, MsgType " +
            "FROM ((tblLogs LEFT JOIN tblMessages ON tblLogs.MessageID = tblMessages.MessageID) LEFT JOIN tblUsers " +
            "ON tblLogs.UserID = tblUsers.UserID) LEFT JOIN tblUserGroups ON tblUsers.Level = tblUserGroups.UserGroupID;";
          ExportTableToExcel(s);
          Cursor.Current = Cursors.Default;
        }

        /*
         * Exports the logs in tblLogsArchive to MS Excel.
         * Note that Excel must be installed on the host computer for this feature to work.
         * REQUIRES: nothing.
         * RETURNS: nothing.
         */
        public void ExportArchiveToExcel()
        {
          Cursor.Current = Cursors.WaitCursor;
          string s = "SELECT tblLogsArchive.LogID, tblLogsArchive.LogDate, tblMessages.MessageName, tblMessages.MessageDescription, " +
            "tblMessages.MessageFilename, tblLogsArchive.MsgStart, tblLogsArchive.MsgStop, tblLogsArchive.Duration, tblLogsArchive.Loop, " +
            "tblUsers.UserName, tblUserGroups.UserGroupName, tblLogsArchive.Tunnel1, tblLogsArchive.Tunnel2, MsgType " +
            "FROM ((tblLogsArchive LEFT JOIN tblMessages ON tblLogsArchive.MessageID = tblMessages.MessageID) LEFT JOIN tblUsers " +
            "ON tblLogsArchive.UserID = tblUsers.UserID) LEFT JOIN tblUserGroups ON tblUsers.Level = tblUserGroups.UserGroupID;";
          ExportTableToExcel(s);
          Cursor.Current = Cursors.Default;
        }

        /*
         * Exports the logs in tblLOgs to MS Excel.
         * Note that Excel must be installed on the host computer for this feature to work.
         * REQUIRES: nothing.
         * RETURNS: nothing.
         */
        public void ExportLogsToCsv()
        {
          Cursor.Current = Cursors.WaitCursor;
          string s = "SELECT tblLogs.LogID, tblLogs.LogDate, tblMessages.MessageName, tblMessages.MessageDescription, " +
            "tblMessages.MessageFilename, tblLogs.MsgStart, tblLogs.MsgStop, tblLogs.Duration, tblLogs.Loop, " +
            "tblUsers.UserName, tblUserGroups.UserGroupName, tblLogs.Tunnel1, tblLogs.Tunnel2, MsgType " +
            "FROM ((tblLogs LEFT JOIN tblMessages ON tblLogs.MessageID = tblMessages.MessageID) LEFT JOIN tblUsers " +
            "ON tblLogs.UserID = tblUsers.UserID) LEFT JOIN tblUserGroups ON tblUsers.Level = tblUserGroups.UserGroupID;";
          ExportTableToCsv(s);
          Cursor.Current = Cursors.Default;
        }

        /*
         * Exports the logs in tblLogsArchive to MS Excel.
         * Note that Excel must be installed on the host computer for this feature to work.
         * REQUIRES: nothing.
         * RETURNS: nothing.
         */
        public void ExportArchiveToCsv()
        {
          Cursor.Current = Cursors.WaitCursor;
          string s = "SELECT tblLogsArchive.LogID, tblLogsArchive.LogDate, tblMessages.MessageName, tblMessages.MessageDescription, " +
            "tblMessages.MessageFilename, tblLogsArchive.MsgStart, tblLogsArchive.MsgStop, tblLogsArchive.Duration, tblLogsArchive.Loop, " +
            "tblUsers.UserName, tblUserGroups.UserGroupName, tblLogsArchive.Tunnel1, tblLogsArchive.Tunnel2, MsgType " +
            "FROM ((tblLogsArchive LEFT JOIN tblMessages ON tblLogsArchive.MessageID = tblMessages.MessageID) LEFT JOIN tblUsers " +
            "ON tblLogsArchive.UserID = tblUsers.UserID) LEFT JOIN tblUserGroups ON tblUsers.Level = tblUserGroups.UserGroupID;";
          ExportTableToCsv(s);
          Cursor.Current = Cursors.Default;
        }

        /*
         * Saves the appliction setting to a table in the database.
         * REQUIRES: a KeyValue list of all the settings.
         * RETURNS: zero.
         */
        public int SaveSettings(List<KeyValuePair<string, string>> l)
        {
          // first clear settings from tblSettings
          ExecuteQry("DELETE FROM tblSettings");
            foreach (var element in l)
            {
                string fld = element.Key.ToString();
                string val = element.Value.ToString();
                string sql_str = "INSERT INTO tblSettings (SettingName, SettingValue) VALUES ('" + fld + "','" + val + "');";
                ExecuteQry(sql_str);
            }
            return 0;
        }

        /*
         * Reads the appliction setting from a table in the database.
         * REQUIRES: nothing.
         * RETURNS: a KeyValue list of all the settings.
         */
        public List<string> ReadSettings()
        {
          DataRow dr;
          List<string> list = new List<string>();
          string sql_str = "SELECT SettingName, SettingValue FROM tblSettings ORDER BY ID";

          System.Data.DataTable dt =GetTable(sql_str);
          if ((dt != null) && (dt.Rows.Count > 0))
          {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dr = dt.Rows[i];
                if (dr.ItemArray[0].ToString() == "RelayComPort" && dr.ItemArray[1].ToString() == "")
                    list.Add("COM99");
                else
                    list.Add(dr["SettingValue"].ToString());
            }
            dr = null;
          }
          return list;
        }

        public int SaveSchedule(AddEditSchedule.Schedule s)
        {
            int result = 0;

            //int ms = s.TimeOfDay.Milliseconds;
            //double tms = s.TimeOfDay.TotalMilliseconds;
            //tms = tms - ms;
            //s.TimeOfDay.TotalMilliseconds  = Convert.to tms;

            s.TimeOfDay = new TimeSpan(s.TimeOfDay.Hours, s.TimeOfDay.Minutes,0);

            string sql_str = "INSERT INTO tblSchedule (MessageName, Filename, TimeOfDay, StartDate, EndDate, Mon, Tue, Wed, Thu, " +
              "Fri, Sat, Sun, Tunnel1, Tunnel2, Enabled) " +
                "VALUES ('" + s.MsgName  + "','" + s.Filename + "','" + s.TimeOfDay + "','" + s.StartDate + "','" + s.EndDate + "'," + s.Mon + "," + s.Tue + "," +
                s.Wed + "," + s.Thu + "," + s.Fri + "," + s.Sat + "," + s.Sun + "," + s.Tunnel1 + "," + s.Tunnel2 + "," + s.Enabled + ")";
            result = ExecuteQry(sql_str);
            return result;
        }

        public int UpdateSchedule(AddEditSchedule.Schedule s)
        {
          int result = 0;
          s.TimeOfDay = new TimeSpan(s.TimeOfDay.Hours, s.TimeOfDay.Minutes, 0);
          string sql_str = "UPDATE tblSchedule SET MessageName = '" + s.MsgName + "', [Filename] = '" + s.Filename +
            "', TimeOfDay = '" + s.TimeOfDay + "', StartDate = '" + s.StartDate + "', EndDate = '" + s.EndDate +
            "', Mon = " + s.Mon + ", Tue = " + s.Tue + ", Wed = " + s.Wed +
            ", Thu = " + s.Thu + ", Fri = " + s.Fri + ", Sat = " + s.Sat + ", Sun = " + s.Sun +
            ", Tunnel1 = " + s.Tunnel1 + ", Tunnel2 = " + s.Tunnel2 + ", Enabled = " + s.Enabled +
            " WHERE ScheduleID=" + s.ID;
          result = ExecuteQry(sql_str);
          
          return result;
        }

        public AddEditSchedule.Schedule GetNextScheduledMsg()
        {
          System.Data.DataRow dr;
          AddEditSchedule.Schedule sch = new AddEditSchedule.Schedule();
          string FldName="";

          System.DayOfWeek _day = DateTime.Now.DayOfWeek;

          switch (_day)
          {
              case DayOfWeek.Monday: FldName    = "Mon"; break;
              case DayOfWeek.Tuesday: FldName   = "Tue"; break;
              case DayOfWeek.Wednesday: FldName = "Wed"; break;
              case DayOfWeek.Thursday: FldName  = "Thu"; break;
              case DayOfWeek.Friday: FldName    = "Fri"; break;
              case DayOfWeek.Saturday: FldName  = "Sat"; break;
              case DayOfWeek.Sunday: FldName    = "Sun"; break;
              default: break;
          }

          if (DateTime.Today.DayOfWeek == DayOfWeek.Monday)
              FldName = "mon";
          string sql_str = "SELECT TimeOfDay, Tunnel1, Tunnel2, MessageName, Filename " +
              "FROM tblSchedule " +
              "WHERE (StartDate<=Date()) AND (EndDate>=Date()) AND (TimeOfDay>Time()) AND (" + FldName + "=True) " +
              "ORDER BY tblSchedule.TimeOfDay;";
          System.Data.DataTable dt = GetTable(sql_str);
          if ((dt != null) && (dt.Rows.Count > 0))
          {
            dr = dt.Rows[0];
            string s = dr["TimeOfDay"].ToString();
            sch.TimeOfDay = TimeSpan.Parse(s);
            sch.MsgName = dr["Messagename"].ToString();
            sch.Filename = dr["Filename"].ToString();
            sch.Tunnel1 = (bool)(dr["Tunnel1"]);
            sch.Tunnel2 = (bool)(dr["Tunnel2"]);
          }
          return sch;
        }
    }
}
