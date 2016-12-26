using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BreakIn
{
  class Logs
  {
    public int UserID;
    public int MsgID;
    public DateTime LogDate;
    public DateTime StartDateTime;
    public DateTime StopDateTime;
    public TimeSpan StartTime;
    public TimeSpan StopTime;
    public int Duration;
    public bool Looped;
    public bool Tunnel1;
    public bool Tunnel2;
    public string MsgType;

    /*
     * Set the stop time and calculate the duration og the playing time in seconds.
     */
    public void SetStopTime()
    {
      StopDateTime = DateTime.Now;
      StopTime = StopDateTime.TimeOfDay;
      Duration = (StopDateTime.Subtract(StartDateTime)).Seconds;
    }

    /*
     * Contructor
     */
    public Logs()
    {

    }

    /*
     * Constructor with start settings.
     * UserID, MessageID, Looped
     */
    public Logs(int uid, int mid, bool lpd, bool tun1, bool tun2, string msg_type)
    {
      UserID = uid;
      MsgID = mid;
      Looped = lpd;
      Tunnel1 = tun1;
      Tunnel2 = tun2;
      LogDate = DateTime.Today;
      StartDateTime = DateTime.Now;
      StartTime = StartDateTime.TimeOfDay;
      MsgType = msg_type;
    }

    /*
     * Achives all the records in tblLogs by copying them to tblLogsArchive.
     * tblLogs is then cleared.
     * REQUIRES: nothing.
     * RETURNS: number of records archived.
     */
    public int ArchiveAll()
    {
        int result = 0;
        int i;

        Database db = new Database();
        db.ConnectToDb();
        System.Data.DataTable tbl = db.GetTable("SELECT * FROM tblLogs");
        if ((tbl != null) && (tbl.Rows.Count > 0))
        {
            foreach (System.Data.DataRow row in tbl.Rows)
            {
            }
        }
        db = null;

        return result;
    }
  }
}
