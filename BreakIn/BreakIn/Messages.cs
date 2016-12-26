using System.Windows.Forms;
using System.Data;
using System;

namespace BreakIn
{
  public partial class Form1 : Form
  {
    private void FormatTableLayoutRows()
    {
      //TableLayoutRowStyleCollection styles = tableLayoutPanelFire.RowStyles;

      //int i = tableLayoutPanelFire.RowCount;
      //int rsc = styles.Count;

      //foreach (RowStyle style in styles)
      //{
      //  style.SizeType = SizeType.Absolute;
      //  style.Height = 60;
      //}
    }

    private void LoadMessagesFire()
    {
        tableLayoutPanelFire.Controls.Clear();
        
        MessageControl.MessageTypes bmsgtype = MessageControl.MessageTypes.Broadcast;
        
        MessageControl bmc = new MessageControl(this, bmsgtype);
        bmc.btnMessage.Text = "Live Message";
        //mc.SetFileName(tbl.Rows[i][3].ToString());
        //mc.Dock = DockStyle.Fill;
        //mc.Controls[0].Dock = DockStyle.Fill;
        //mc.SetMsgID((int)(tbl.Rows[i][0]));
        tableLayoutPanelFire.Controls.Add(bmc);
      
      string sql_str = TableSqlStrings[MESS_FIRE];
      Database db = new Database();
      db.ConnectToDb();
      try
      {
        DataTable tbl = db.GetTable(sql_str);
        if (tbl != null)
        {
          for (int i = 0; i < tbl.Rows.Count; i++)
          {
            int cat = (int)(tbl.Rows[i][5]);
            MessageControl.MessageTypes msgtype = (MessageControl.MessageTypes)(cat-1);
            MessageControl mc = new MessageControl(this, msgtype);
            mc.btnMessage.Text = tbl.Rows[i][1].ToString();
            mc.SetFileName(tbl.Rows[i][3].ToString());
            //mc.Dock = DockStyle.Fill;
            //mc.Controls[0].Dock = DockStyle.Fill;
            mc.SetMsgID((int)(tbl.Rows[i][0]));
            tableLayoutPanelFire.Controls.Add(mc);
          }
        }
        FormatTableLayoutRows();
      }
      catch (Exception e)
      {
      }
    }
    private void LoadMessagesAccident()
    {
      tableLayoutPanelAccident.Controls.Clear();
      string sql_str = TableSqlStrings[MESS_ACCIDENT];
      Database db = new Database();
      db.ConnectToDb();
      try
      {
        DataTable tbl = db.GetTable(sql_str);
        if (tbl != null)
        {
          for (int i = 0; i < tbl.Rows.Count; i++)
          {
            int cat = (int)(tbl.Rows[i][5]);
            MessageControl.MessageTypes msgtype = (MessageControl.MessageTypes)(cat - 1);
            MessageControl mc = new MessageControl(this, msgtype);
            mc.btnMessage.Text = tbl.Rows[i][1].ToString();
            mc.SetFileName(tbl.Rows[i][3].ToString());
            mc.SetMsgID((int)(tbl.Rows[i][0]));
            tableLayoutPanelAccident.Controls.Add(mc);
          }
        }
      }
      catch (Exception e)
      {
      }
    }
    private void LoadMessagesMisc()
    {
      tableLayoutPanelMisc.Controls.Clear();
      string sql_str = TableSqlStrings[MESS_MISC];
      Database db = new Database();
      db.ConnectToDb();
      try
      {
        DataTable tbl = db.GetTable(sql_str);
        if (tbl != null)
        {
          for (int i = 0; i < tbl.Rows.Count; i++)
          {
            int cat = (int)(tbl.Rows[i][5]);
            MessageControl.MessageTypes msgtype = (MessageControl.MessageTypes)(cat - 1);
            MessageControl mc = new MessageControl(this, msgtype);
            mc.btnMessage.Text = tbl.Rows[i][1].ToString();
            mc.SetFileName(tbl.Rows[i][3].ToString());
            mc.SetMsgID((int)(tbl.Rows[i][0]));
            tableLayoutPanelMisc.Controls.Add(mc);
          }
        }
      }
      catch (Exception e)
      {
      }
    }
  }
}