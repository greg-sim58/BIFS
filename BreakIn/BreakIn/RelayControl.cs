using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace BreakIn
{
  class RelayControl
  {
    private static string ComPortName = "COM12";

    private static SerialPort RelayPort = new SerialPort();

    public static void SetPortName(string port)
    {
      if (RelayPort.IsOpen)
        RelayPort.Close();
      ComPortName = port;
    }

    public static string GetPortName()
    {
      return ComPortName;
    }
    public static void OpenPort()
    {
        if (ComPortName != null && ComPortName != "")
        {
            try
            {
                RelayControl.SetPortName(ComPortName);// 
                RelayPort.PortName = ComPortName;
                RelayPort.DataBits = 8;
                RelayPort.Parity = Parity.None;
                RelayPort.StopBits = StopBits.One;
                RelayPort.Open();
            }
            catch (Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show("SERIAL PORT ERROR\n\r" + e.Message);
                throw ex;// new Exception(e);
            }
        }
    }
 
    private static void ClosePort()
    {
      if (RelayPort != null)
      {
        if (RelayPort.IsOpen)
          RelayPort.Close();
      }
    }

    public static int RelayOn(int rel)
    {
      int result = 0;
      try
      {
        OpenPort();
        if (rel == 1)
          RelayPort.Write(new byte[] {0xFF, 0X01, 0X01}, 0, 3);
        else if (rel == 2)
          RelayPort.Write(new byte[] {0xFF, 0X02, 0X01}, 0, 3);
      }
      catch (Exception e)
      {
        result = -1;
        //System.Windows.Forms.MessageBox.Show("SERIAL PORT ERROR\n\r" + e.Message);
      }
      ClosePort();
      return result;
    }

    public static int RelayOff(int rel)
    {
      int result = 0;
      try
      {
        OpenPort();
        if (rel == 1)
          RelayPort.Write(new byte[] { 0xFF, 0X01, 0X00 }, 0, 3);
        else if (rel == 2)
          RelayPort.Write(new byte[] { 0xFF, 0X02, 0X00 }, 0, 3);
      }
      catch (Exception e)
      {
        result = -1;
        //System.Windows.Forms.MessageBox.Show("SERIAL PORT ERROR\n\r" + e.Message);
      }
      ClosePort();
      return result;
    }
  }
}
