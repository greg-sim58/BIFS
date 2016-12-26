using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BreakIn
{
  public partial class MessageControl : UserControl
  {
    public enum MessageTypes
    { 
      Emergency,
      Warning,
      Information,
      Broadcast
    }
    private Form1 f1;
    private string FileName;
    private int MsgID;
    private string MsgColor;


    private void SetMsgColor(Color c)
    {
      MsgColor = c.ToString();
      this.btnMessage.BackColor = c;
      this.btnMessage.FlatAppearance.BorderColor = c;


    }

    public string GetFileName()
    {
      return FileName;
    }

    public void SetFileName(string s)
    {
      FileName = s;
    }

    public int GetMsgID()
    {
      return MsgID;
    }

    public void SetMsgID(int id)
    {
      MsgID = id;
    }

    public MessageControl(MessageTypes mt)
    {
      InitializeComponent();
      switch (mt)
      {
        case MessageTypes.Emergency: SetMsgColor(Settings.Color1); break;
        case MessageTypes.Warning: SetMsgColor(Settings.Color2); break;
        case MessageTypes.Information: SetMsgColor(Settings.Color3); break;
        case MessageTypes.Broadcast: SetMsgColor(Settings.Color4); break;
        default: break;
      }
    }

    public MessageControl(Form1 f, MessageTypes mt)
    {
      InitializeComponent();
      f1 = f;
      switch (mt)
      {
        case MessageTypes.Emergency: SetMsgColor(Settings.Color1); break;
        case MessageTypes.Warning: SetMsgColor(Settings.Color2); break;
        case MessageTypes.Information: SetMsgColor(Settings.Color3); break;
        case MessageTypes.Broadcast: SetMsgColor(Settings.Color4); break;
        default: break;
      }
    }

    private void btnMessage_Click(object sender, EventArgs e)
    {
      if (btnMessage.Text != "Live Message")
      {
        f1.lblPlaying.ForeColor = btnMessage.BackColor;
        f1.SetMessage(GetFileName());
        f1.CurrentMsgID = GetMsgID();
      }
      else
      {
        f1.CurrentMsgID = 0;
      }
        f1.lblPlaying.Text = btnMessage.Text;
    }
  }
}
