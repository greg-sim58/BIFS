using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace BreakIn
{
  class Settings
  {

    public static string RecordedMessageDir = "C:\\RecordedMessages";

    public static int SpeechDevice = 0;

    public static System.Drawing.Color Color1 = System.Drawing.Color.Red;
    public static System.Drawing.Color Color2 = System.Drawing.Color.Orange;
    public static System.Drawing.Color Color3 = System.Drawing.Color.Green;
    public static System.Drawing.Color Color4 = System.Drawing.Color.Black;

    public static AddEditSchedule.Schedule NextScheduledMsg;


    public static void DefaultSettings()
    {
    }

    public static void UpdateSettings(List<string> list)
    {
        RecordedMessageDir = list[0].ToString();
        RelayControl.SetPortName(list[1].ToString());
    }
  }
}
