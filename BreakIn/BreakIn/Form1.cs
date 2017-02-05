using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using NAudio.Wave;
using System.Reflection;
using System.Collections;

namespace BreakIn
{
    public partial class Form1 : Form
    {
        const int ADMIN    = 1;
        const int OPERATOR = 2;

        const int TBL_USERS     = 0;
        const int TBL_MESSAGES  = 1;
        const int MESS_FIRE     = 2;
        const int MESS_ACCIDENT = 3;
        const int MESS_MISC     = 4;

        enum AppSettings  : int { MessageFolder=0,  RelayComPort=1, Color1=2, Color2=3, Color3=4, Color4=5, SpeechDevice=6};


        string[] TableSqlStrings = {"SELECT tblUsers.UserID, tblUsers.UserName, tblUsers.Password, tblUsers.Level FROM tblUsers;",

                                    "SELECT tblMessages.MessageID, tblMessages.MessageName, tblMessages.MessageDescription, " +
                                    "tblMessages.MessageFilename, tblMsgGroups.GroupName " +
                                    "FROM tblMessages LEFT JOIN tblMsgGroups ON tblMessages.MessageGroup = tblMsgGroups.GroupID;",
                                    
                                    "SELECT tblMessages.MessageID, tblMessages.MessageName, tblMessages.MessageDescription, " +
                                    "tblMessages.MessageFilename, tblMessages.MessageGroup, tblMessages.MessageCategory " +
                                    "FROM tblMessages " +
                                    "WHERE tblMessages.MessageGroup=1;",
                                    
                                    "SELECT tblMessages.MessageID, tblMessages.MessageName, tblMessages.MessageDescription, " +
                                    "tblMessages.MessageFilename, tblMessages.MessageGroup, tblMessages.MessageCategory " +
                                    "FROM tblMessages " +
                                    "WHERE tblMessages.MessageGroup=2;",
                                    
                                    "SELECT tblMessages.MessageID, tblMessages.MessageName, tblMessages.MessageDescription, " +
                                    "tblMessages.MessageFilename, tblMessages.MessageGroup, tblMessages.MessageCategory " +
                                    "FROM tblMessages " +
                                    "WHERE tblMessages.MessageGroup=3;",
                                    ""};

        User CurrentUser = new User();
        private Audio audio;
        private string CurrentMessage = "";

        public int CurrentMsgID = 0;
        //public string MessageFolder = Directory.GetCurrentDirectory() + "\\RecordedMessages";


        private void SetFormDefaults()
        {
            // Load all found serial ports
            cmbPorts.Items.Clear();
            string[] ports = System.IO.Ports.SerialPort.GetPortNames();
            foreach (string port in ports)
                cmbPorts.Items.Add(port);
            // Load all recoding devices
            List<NAudio.Wave.WaveInCapabilities> sources = new List<NAudio.Wave.WaveInCapabilities>();

            for (int i = 0; i < NAudio.Wave.WaveIn.DeviceCount; i++)
            {
                sources.Add(NAudio.Wave.WaveIn.GetCapabilities(i));
            }

            cmbSpeechDevice.Items.Clear();

            foreach (var source in sources)
            {
                ListViewItem item = new ListViewItem(source.ProductName);
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, source.Channels.ToString()));
                cmbSpeechDevice.Items.Add(source.ProductName.ToString());
            }

            //Load colors in comboBox
            Type colorType = typeof(System.Drawing.Color);
            PropertyInfo[] propInfoList = colorType.GetProperties(BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.Public);
            foreach (PropertyInfo c in propInfoList)
            {
                this.cmbColor1.Items.Add(c.Name);
                this.cmbColor2.Items.Add(c.Name);
                this.cmbColor3.Items.Add(c.Name);
                this.cmbColor4.Items.Add(c.Name);
            }
            // Get settings from database
            Database db = new Database();
            db.ConnectToDb();
            List<string> list = db.ReadSettings();
            if ((list != null) && (list.Count > 0))
            {
                try
                {
                    string PortName = list[(int)AppSettings.RelayComPort].ToString();
                    if (PortName == "" || PortName == null || !PortName.Contains("COM"))
                        PortName = "";// "COM99";
                    txtMessageFolder.Text = list[0].ToString();
                    Settings.RecordedMessageDir = txtMessageFolder.Text;
                    RelayControl.SetPortName(PortName);
                    cmbColor1.SelectedIndex = Convert.ToInt32(list[(int)AppSettings.Color1]);
                    cmbColor2.SelectedIndex = Convert.ToInt32(list[(int)AppSettings.Color2]);
                    cmbColor3.SelectedIndex = Convert.ToInt32(list[(int)AppSettings.Color3]);
                    cmbColor4.SelectedIndex = Convert.ToInt32(list[(int)AppSettings.Color4]);
                    cmbSpeechDevice.SelectedIndex = Convert.ToInt32(list[(int)AppSettings.SpeechDevice]);
                    Settings.SpeechDevice = Convert.ToInt32(list[6]);
                }
                catch (Exception)
                {
                }
            }
            // Set port name
            if (cmbPorts.Items.Count > 0)
            {
                cmbPorts.SelectedIndex = 0;
                for (int i = 0; i < cmbPorts.Items.Count; i++)
                {
                    if ((RelayControl.GetPortName() != null) & (cmbPorts.Items[i].ToString() == RelayControl.GetPortName()))
                        cmbPorts.SelectedIndex = i;
                }
            }

            btnTestRelay.Enabled = cmbPorts.Items.Count > 0;
            db = null;
        }
      public Form1()
        {
            InitializeComponent();
            tabcontrolMain.ItemSize = new Size(0, 1);
            tabControlOperatorMessages.ItemSize = new Size(0, 1);
            tableLayoutPanelFire.AutoScroll = true;
            tableLayoutPanelAccident.AutoScroll = true;
            tableLayoutPanelMisc.AutoScroll = true;
            tableLayoutPanelFire.Padding = new Padding(0, 0, SystemInformation.VerticalScrollBarWidth, 0);
            tableLayoutPanelAccident.Padding = new Padding(0, 0, SystemInformation.VerticalScrollBarWidth, 0);
            tableLayoutPanelMisc.Padding = new Padding(0, 0, SystemInformation.VerticalScrollBarWidth, 0);
        }

      private void EnableTunnelLoop(bool en)
      {
        chkLoop.Enabled = en;
        chkTunnel1.Enabled = en;
        chkTunnel2.Enabled = en;
      }

        private void showHint(object sender, System.Windows.Forms.MouseEventArgs e)
        {
          if (sender is Button)
            staHints.Text = (sender as Button).Tag.ToString();
          if (sender is TextBox)
            staHints.Text = (sender as TextBox).Tag.ToString();
        }

        private void hideHint(object sender, EventArgs e)
        {
            if (sender is Button)
                staHints.Text = "";
            if (sender is TextBox)
                staHints.Text = "";
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
          if (sender is TextBox)
            (sender as TextBox).BackColor = Color.Beige;
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
          if (sender is TextBox)
            (sender as TextBox).BackColor = System.Windows.Forms.Control.DefaultBackColor;
        }

        public void ShowTable(int table_name, string TableName)
        {
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        /*
         * Get user details
         * Confirm password
         * if password correct allow entry
         * if user level is admin then show admin menu
         * else show operator menu
         */
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            db.ConnectToDb();
            // get user details
            CurrentUser = db.GetUserDetails(txtUserName.Text);
            // Check password
            if (CurrentUser.Password != txtPassword.Text)
                ShowError("Invalid UserName/Password");
            else
            {
                // set appropriate menu
                ShowMenu(CurrentUser.Accesslevel);
            }
        }

        private void btnMenuExit_Click(object sender, EventArgs e)
        {
            //log user out
            tabcontrolMain.SelectedTab = tabLogin;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            btnLogin.Enabled = (txtUserName.Text != "") & (txtPassword.Text != "");
            ShowError("");
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            btnLogin.Enabled = (txtUserName.Text != "") & (txtPassword.Text != "");
            ShowError("");
        }

        private void ShowError(string s)
        {
            lblErrMsg.Text = s;
            panErrMsg.Visible = (s != "");
        }

        private void ShowMenu(int level)
        {
          btnLogout.Text = "Logout";
          if (level == ADMIN)
            tabcontrolMain.SelectedTab = tabAdminMenu;
          else if (level == OPERATOR)
            tabcontrolMain.SelectedTab = tabPage1;// tabOperatorMenu;
        }

        private void tabLogin_Enter(object sender, EventArgs e)
        {
            panErrMsg.Visible = false;
            txtPassword.Text = "";
            txtUserName.Text = "";
        }

        private void btnTableClose_Click(object sender, EventArgs e)
        {
            tabcontrolMain.SelectedTab = tabAdminMenu;
        }

        //private void btnAddTable_Click(object sender, EventArgs e)
        //{

        //}

        private void ShowAddEditUser()
        {
            AddEditUser _add = new AddEditUser();
            _add.ShowDialog();
            ShowTable(TBL_USERS,"Users");
        }

        //private void btnEditTable_Click(object sender, EventArgs e)
        //{
        //}

        private void Form1_Load(object sender, EventArgs e)
        {
            
            SetFormDefaults();
            Database db = new Database();
            db.ConnectToDb();
            Settings.UpdateSettings(db.ReadSettings());
            try
            {
                lblErrorMsg.Text = "";
                RelayControl.OpenPort();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("The control box may not be connected or connected to the incorrect port.\n\r" +
                //       "Please check and set the correct port under 'Settings'");
                lblErrorMsg.Text = ex.Message + " Please check and set the correct port under 'Settings'";
            }

            tabcontrolMain.SelectedTab = tabLogin;
            txtUserName.Focus();
            if ((sender as Form1).HasChildren)
            {
              foreach (Control c in (sender as Form1).Controls)
              {
                if (c is Button)
                  (c as Button).BackColor = Color.BurlyWood;
              }
            }
        }

        public void SetMainTab(int t)
        {
            tabcontrolMain.SelectedIndex = t;
        }

        private void btnBrowseUsers_Click(object sender, EventArgs e)
        {
            tableLayoutPanelTables.Controls.Clear();
            DataTbl dt = new DataTbl(this);
            dt.ShowUsers();
            tableLayoutPanelTables.Controls.Add(dt);
            tabcontrolMain.SelectedTab = tabTable;
        }

        private void btnBrowseMessages_Click(object sender, EventArgs e)
        {
          tableLayoutPanelTables.Controls.Clear();
          DataTbl dt = new DataTbl(this);
          dt.ShowMessages();
          tableLayoutPanelTables.Controls.Add(dt);
          tabcontrolMain.SelectedTab = tabTable;
        }

        private void btnSchedules_Click(object sender, EventArgs e)
        {
          tableLayoutPanelTables.Controls.Clear();
          DataTbl dt = new DataTbl(this);
          dt.ShowSchedules();
          tableLayoutPanelTables.Controls.Add(dt);
          tabcontrolMain.SelectedTab = tabTable;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
          tabcontrolMain.SelectedTab = tabSettings;
        }

        private void btnSettingsClose_Click(object sender, EventArgs e)
        {
            lblErrorMsg.Text = "";
            Cursor.Current = Cursors.WaitCursor;
            if ((cmbPorts.Items.Count > 0) && (cmbPorts.SelectedItem != null))
              RelayControl.SetPortName(cmbPorts.SelectedItem.ToString());
            if ((cmbSpeechDevice.Items.Count > 0) && (cmbSpeechDevice.SelectedItem != null))
                Settings.SpeechDevice = cmbSpeechDevice.SelectedIndex;
            if (txtMessageFolder.Text != "")
            {
                Settings.RecordedMessageDir = txtMessageFolder.Text;
            }

            var list = new List<KeyValuePair<string, string>>();
            var comPortName = (cmbPorts.SelectedItem != null) ? cmbPorts.SelectedItem.ToString() : "";

            try
            {
                RelayControl.OpenPort();
            }
            catch (Exception ex)
            {
                lblErrorMsg.Text = ex.Message + " Please check and set the correct port under 'Settings'";
            }
            finally
            {
                list.Add(new KeyValuePair<string, string>("MessageFolder", txtMessageFolder.Text));
                list.Add(new KeyValuePair<string, string>("RelayComPort", comPortName));
                list.Add(new KeyValuePair<string, string>("Color1", cmbColor1.SelectedIndex.ToString()));
                list.Add(new KeyValuePair<string, string>("Color2", cmbColor2.SelectedIndex.ToString()));
                list.Add(new KeyValuePair<string, string>("Color3", cmbColor3.SelectedIndex.ToString()));
                list.Add(new KeyValuePair<string, string>("Color4", cmbColor4.SelectedIndex.ToString()));
                list.Add(new KeyValuePair<string, string>("SpeechDevice", cmbSpeechDevice.SelectedIndex.ToString()));

                Database db = new Database();
                db.ConnectToDb();
                db.SaveSettings(list);
                Cursor.Current = Cursors.Default;
                tabcontrolMain.SelectedTab = tabAdminMenu;
            }
        }

        private void btnOperate_Click(object sender, EventArgs e)
        {
          ShowMenu(OPERATOR);
          chkTunnel1.Enabled = true;
          chkTunnel2.Enabled = true;
          btnPlay.Image = global::BreakIn.Properties.Resources.Player_play;
          btnLogout.Text = "Back";
          lblFire.Font = new Font(lblFire.Font, FontStyle.Underline);
          lblMisc.Font = new Font(lblFire.Font, FontStyle.Regular);
          lblAccident.Font = new Font(lblFire.Font, FontStyle.Regular);
          tabControlOperatorMessages.SelectedTab = tabOperatorMessagesFire;
          Timer1.Interval = (int)GetInterval();
          Timer1.Start();
        }


        private void button1_Click(object sender, EventArgs e)
        {
          if (audio.PlayState == Audio.PlayStates.Playing)
            audio.StopMessage();
          if (btnLogout.Text == "Logout")
            tabcontrolMain.SelectedTab = tabLogin;
          else
            tabcontrolMain.SelectedTab = tabAdminMenu;
          Timer1.Enabled = false;
        }

        private void btnBrowseUsers_MouseLeave(object sender, EventArgs e)
        {
            (sender as Button).BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About a = new About();
            a.ShowDialog();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
          txtUserName.Focus();
        }

        private void lblPlaying_TextChanged(object sender, EventArgs e)
        {
            chkLoop.Enabled = (lblPlaying.Text != "Live Message");
            if (chkLoop.Enabled == false)
              chkLoop.Checked = false;
        }

        private void SetForeColor(object obj, Color col, Cursor cur)
        {
          if (obj != null)
          {
              if (obj is Label)
              {
                  (obj as Label).ForeColor = col;
              }
            Cursor = cur;
          }
        }

        private void SetSelected(object obj)
        {
          SetForeColor(obj, Color.Maroon, Cursors.Hand);
        }

        private void SetSelectedBold(object sender)
        {
            lblAccident.Font = new Font(lblAccident.Font, FontStyle.Regular);
            lblFire.Font = new Font(lblFire.Font, FontStyle.Regular);
            lblMisc.Font = new Font(lblMisc.Font, FontStyle.Regular);
            if (sender is Label)
                (sender as Label).Font = new Font((sender as Label).Font, FontStyle.Underline);
        }

        private void SetUnselected(object obj)
        {
          SetForeColor(obj, Color.RoyalBlue, Cursors.Default);
        }

      private void lblFire_MouseMove(object sender, MouseEventArgs e)
        {
          SetSelected(sender);
        }

        private void lblFire_MouseLeave(object sender, EventArgs e)
        {
          SetUnselected(sender);
        }

        private void lblFire_Click(object sender, EventArgs e)
        {
          tabControlOperatorMessages.SelectedTab = tabOperatorMessagesFire;
          SetSelectedBold(sender);
        }

        private void lblAccident_Click(object sender, EventArgs e)
        {
          tabControlOperatorMessages.SelectedTab = tabOperatorMessagesAccident;
          SetSelectedBold(sender);
        }

        private void lblMisc_Click(object sender, EventArgs e)
        {
          tabControlOperatorMessages.SelectedTab = tabOperatorMessagesMisc;
          SetSelectedBold(sender);
        }

        private void button2_Click(object sender, EventArgs e)
        {
          RelayControl.RelayOn(1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
          RelayControl.RelayOff(1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
          RelayControl.RelayOn(2);
        }
        private WaveOut waveOut;
        private void button5_Click(object sender, EventArgs e)
        {
          if (waveOut == null)
          {
              WaveFileReader reader = new WaveFileReader(Settings.RecordedMessageDir + "\\speech_nav_1.wav");
              LoopStream loop = new LoopStream(reader);
            waveOut = new WaveOut();
            waveOut.Init(loop);
            waveOut.Play();
          }
          else
          {
            waveOut.Stop();
            waveOut.Dispose();
            waveOut = null;
          }
        }

        private void tabPage1_Leave(object sender, EventArgs e)
        {
          lblPlaying.Text = "";
          RelayControl.RelayOff(1);
          RelayControl.RelayOff(2);
          chkTunnel1.Checked = false;
          chkTunnel2.Checked = false;
          chkLoop.Checked = false;
          audio = null;
          statustextHint.Items[4].Text = "";
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
          audio = new Audio();
          lblPlaying.Text = "";
          RelayControl.RelayOff(1);
          RelayControl.RelayOff(2);
          chkTunnel1.Checked = false;
          chkTunnel2.Checked = false;
          chkLoop.Checked = false;
          audio.LoopSelected = false;
          btnPlay.Enabled = false;
          LoadMessagesAccident();
          LoadMessagesFire();
          LoadMessagesMisc();
          Database db = new Database();
          db.ConnectToDb();
          DateTime dt = DateTime.Now;
          System.DayOfWeek Today = DateTime.Now.DayOfWeek;
          Settings.NextScheduledMsg = db.GetNextScheduledMsg();
            if (Settings.NextScheduledMsg.Filename != null)
                statustextHint.Items[4].Text = "Next Scheduled Message for today: " + Settings.NextScheduledMsg.TimeOfDay.ToString();
            else
              statustextHint.Items[4].Text = "Next Scheduled Message for today: None";
            db = null;
          Timer1.Stop();
          Timer1.Interval = GetInterval();
          Timer1.Start();
        }

        private static void PlaybackStopped(object sender, EventArgs e)
        {
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
          if ((audio != null) && (audio.PlayState == Audio.PlayStates.Playing))
            audio.StopMessage();
          RelayControl.RelayOff(1);
          RelayControl.RelayOff(2);
        }

        public void SetMessage(string msg)
        {
          audio.SelectedMessage = msg;
        }

        private void chkTunnel1_CheckedChanged(object sender, EventArgs e)
        {
            btnPlay.Enabled = ((lblPlaying.Text != "") & ((chkTunnel1.Checked) | (chkTunnel2.Checked)));
        }

        private Logs log;

        private void PlaySelectedMsg(string MsgType)
        {
          if (audio.PlayState == Audio.PlayStates.Playing)
          {
            EnableTunnelLoop(true);
            audio.TestEvent -= audio_TestEvent;
            audio.StopMessage();
            RelayControl.RelayOff(1);
            RelayControl.RelayOff(2);
            log.SetStopTime();
            btnPlay.Image = global::BreakIn.Properties.Resources.Player_play;
            Database db = new Database();
            db.ConnectToDb();
            if (db.AppendLog(log) == 0)
              MessageBox.Show("DATABASE ERROR : \n\r Unable to save to logs");
            else
              db.ArchiveLog(log);
          }
          else
          {
            EnableTunnelLoop(false);
            log = new Logs(CurrentUser.UserID, CurrentMsgID, chkLoop.Checked, chkTunnel1.Checked, chkTunnel2.Checked,MsgType);
            if (chkTunnel1.Checked)
              RelayControl.RelayOn(1);
            if (chkTunnel2.Checked)
              RelayControl.RelayOn(2);

            audio.RecordedMessageDir = Settings.RecordedMessageDir;

            audio.TestEvent += new EventHandler(audio_TestEvent);
            if (audio.PlayMessage(lblPlaying.Text == "Live Message"))
              btnPlay.Image = global::BreakIn.Properties.Resources.Player_stop;
          }

        }

        private void EndPlayBack(string MsgType)
        {
          EnableTunnelLoop(true);
          audio.TestEvent -= audio_TestEvent;
          audio.StopMessage();
          RelayControl.RelayOff(1);
          RelayControl.RelayOff(2);
          log.SetStopTime();
          btnPlay.Image = global::BreakIn.Properties.Resources.Player_play;
          Database db = new Database();
          db.ConnectToDb();
          if (db.AppendLog(log) == 0)
            MessageBox.Show("DATABASE ERROR : \n\r Unable to save to logs");
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
          PlaySelectedMsg("Normal");
          //if (audio.PlayState == Audio.PlayStates.Playing)
          //  EndPlayBack("Normal");
          //else
          //  PlaySelectedMsg("Normal");
          //if (audio.PlayState == Audio.PlayStates.Playing)
          //{
          //  EnableTunnelLoop(true);
          //  audio.TestEvent -= audio_TestEvent;
          //  audio.StopMessage();
          //  RelayControl.RelayOff(1);
          //  RelayControl.RelayOff(2);
          //  log.SetStopTime();
          //  btnPlay.Image = global::BreakIn.Properties.Resources.Player_play;
          //  Database db = new Database();
          //  db.ConnectToDb();
          //  if (db.AppendLog(log) == 0)
          //    MessageBox.Show("DATABASE ERROR : \n\r Unable to save to logs");
          //}
          //else
          //{
          //  EnableTunnelLoop(false);
          //  log = new Logs(CurrentUser.UserID, CurrentMsgID, chkLoop.Checked, chkTunnel1.Checked, chkTunnel2.Checked);
          //  if (chkTunnel1.Checked)
          //    RelayControl.RelayOn(1);
          //  if (chkTunnel2.Checked)
          //    RelayControl.RelayOn(2);

          //  audio.RecordedMessageDir = Settings.RecordedMessageDir;

          //  audio.TestEvent += new EventHandler(audio_TestEvent);
          //  if (audio.PlayMessage(lblPlaying.Text == "Live Message"))
          //      btnPlay.Image = global::BreakIn.Properties.Resources.Player_stop;
          //}
        }

        void audio_TestEvent(object sender, EventArgs e)
        {
          btnPlay_Click(this,e);
        }


        private void chkLoop_Click(object sender, EventArgs e)
        {
          audio.LoopSelected = chkLoop.Checked;
        }

        private void tabControlOperatorMessages_Enter(object sender, EventArgs e)
        {
        }

        private void button7_Click(object sender, EventArgs e)
        {
          Color c = panErrMsg.BackColor;
          string s = c.ToString();
          MessageBox.Show(s);
          panBanner.BackColor = Color.FromName("LightSeaGreen");

        }

        private void btnBrowseLogs_Click(object sender, EventArgs e)
        {
          tableLayoutPanelTables.Controls.Clear();
          DataTbl dt = new DataTbl(this);
          dt.ShowLogs();
          tableLayoutPanelTables.Controls.Add(dt);
          tabcontrolMain.SelectedTab = tabTable;
        }
        private void DisplayKnownColors()
        {
          this.Size = new Size(650, 550);

          // Get all the values from the KnownColor enumeration.
          System.Array colorsArray = Enum.GetValues(typeof(KnownColor));
          KnownColor[] allColors = new KnownColor[colorsArray.Length];

          Array.Copy(colorsArray, allColors, colorsArray.Length);

          // Loop through printing out the values' names in the colors  
          // they represent. 
          float y = 0;
          float x = 10.0F;

          for (int i = 0; i < allColors.Length; i++)
          {

            // If x is a multiple of 30, start a new column. 
            if (i > 0 && i % 30 == 0)
            {
              x += 105.0F;
              y = 15.0F;
            }
            else
            {
              // Otherwise, increment y by 15.
              y += 15.0F;
            }

            // Create a custom brush from the color and use it to draw 
            // the brush's name.
            SolidBrush aBrush =
                new SolidBrush(Color.FromName(allColors[i].ToString()));


            // Dispose of the custom brush.
            aBrush.Dispose();
          }

        }

        private void tabSettings_Enter(object sender, EventArgs e)
        {
            /*
          // Load all found serial ports
          cmbPorts.Items.Clear();
          string[] ports = System.IO.Ports.SerialPort.GetPortNames();
          foreach (string port in ports)
            cmbPorts.Items.Add(port);
          //Load colors in comboBox
          Type colorType = typeof(System.Drawing.Color);
          PropertyInfo[] propInfoList = colorType.GetProperties(BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.Public);
          foreach (PropertyInfo c in propInfoList)
          {
            this.cmbColor1.Items.Add(c.Name);
            this.cmbColor2.Items.Add(c.Name);
            this.cmbColor3.Items.Add(c.Name);
            this.cmbColor4.Items.Add(c.Name);
          }
          // Get settings from database
          Database db = new Database();
          db.ConnectToDb();
          List<string> list = db.ReadSettings();
          if ((list != null) && (list.Count > 0))
          {
            try
            {
              txtMessageFolder.Text = list[0].ToString();
              Settings.RecordedMessageDir = txtMessageFolder.Text;
              RelayControl.SetPortName(list[1].ToString());
              cmbColor1.SelectedIndex = Convert.ToInt32(list[2]);
              cmbColor2.SelectedIndex = Convert.ToInt32(list[3]);
              cmbColor3.SelectedIndex = Convert.ToInt32(list[4]);
              cmbColor4.SelectedIndex = Convert.ToInt32(list[5]);
            }
            catch (Exception)
            {
            }
          }
          // Set port name
          if (cmbPorts.Items.Count > 0)
          {
            cmbPorts.SelectedIndex = 0;
            for (int i = 0; i < cmbPorts.Items.Count; i++)
            {
              if ((RelayControl.GetPortName() != null) & (cmbPorts.Items[i].ToString() == RelayControl.GetPortName()))
                cmbPorts.SelectedIndex = i;
            }
          }
          db = null;
             */
        }

        private void cmbColors_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = e.Bounds;
            if (e.Index >= 0)
            {
                string n = ((ComboBox)sender).Items[e.Index].ToString();
                Font f = new Font("Arial", 9, FontStyle.Regular);
                Color c = Color.FromName(n);
                Brush b = new SolidBrush(c);
                g.DrawString(n, f, Brushes.Black, rect.X, rect.Top);
                g.FillRectangle(b, rect.X + 110, rect.Y + 5, rect.Width - 10, rect.Height - 10);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                txtMessageFolder.Text = folderBrowserDialog1.SelectedPath; 
        }

        private void btnTestRelay_Click(object sender, EventArgs e)
        {
          Cursor.Current = Cursors.WaitCursor;
          RelayControl.SetPortName(cmbPorts.SelectedItem.ToString());
          RelayControl.RelayOn(1);
          RelayControl.RelayOn(2);
          System.Threading.Thread.Sleep(2000);
          RelayControl.RelayOff(1);
          RelayControl.RelayOff(2);
          Cursor.Current = Cursors.Default;
        }

        private void lblPlaying_ForeColorChanged(object sender, EventArgs e)
        {
          label4.ForeColor = lblPlaying.ForeColor;
        }

        private void cmbColors_SelectedIndexChanged(object sender, EventArgs e)
        {
            string color = this.cmbColor1.SelectedItem.ToString();
            Settings.Color1 = Color.FromName(color);
        }

        private void cmbColor2_SelectedIndexChanged(object sender, EventArgs e)
        {
          string color = cmbColor2.SelectedItem.ToString();
          Settings.Color2 = Color.FromName(color);
        }

        private void cmbColor3_SelectedIndexChanged(object sender, EventArgs e)
        {
          string color = this.cmbColor3.SelectedItem.ToString();
          Settings.Color3 = Color.FromName(color);
        }

        private void cmbColor4_SelectedIndexChanged(object sender, EventArgs e)
        {
          string color = this.cmbColor4.SelectedItem.ToString();
          Settings.Color4 = Color.FromName(color);
        }

        private void tabOperatorMessagesFire_Enter(object sender, EventArgs e)
        {
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private int GetInterval()
        {
          DateTime now = DateTime.Now;
          return ((60 - now.Second) * 1000 - now.Millisecond);
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
          TimeSpan TimeNow = DateTime.Now.TimeOfDay;
          System.DayOfWeek Today = DateTime.Now.DayOfWeek;

          Timer1.Stop();

          if ((Settings.NextScheduledMsg.TimeOfDay.Hours == TimeNow.Hours) && (Settings.NextScheduledMsg.TimeOfDay.Minutes == TimeNow.Minutes))
          {
            if (MessageBox.Show("Play Scheduled Message " + Settings.NextScheduledMsg.MsgName + "?","", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
              audio.SelectedMessage = Settings.NextScheduledMsg.Filename;
              lblPlaying.Text = Settings.NextScheduledMsg.Filename;
              chkTunnel1.Checked = Settings.NextScheduledMsg.Tunnel1;
              chkTunnel2.Checked = Settings.NextScheduledMsg.Tunnel2;
              PlaySelectedMsg("Scheduled");
            }
          }

          Database db = new Database();
          db.ConnectToDb();
          Settings.NextScheduledMsg = db.GetNextScheduledMsg();
          if (Settings.NextScheduledMsg.Filename != null)
            statustextHint.Items[4].Text = "Next Scheduled Message for today:" + Settings.NextScheduledMsg.TimeOfDay.ToString();
          else
            statustextHint.Items[4].Text = "Next Scheduled Message for today: None";
          db = null;

          Timer1.Interval = (int)GetInterval();
          Timer1.Start();
        }

        private void StartScheduledMsg()
        {
          chkTunnel1.Checked = Settings.NextScheduledMsg.Tunnel1;
          chkTunnel2.Checked = Settings.NextScheduledMsg.Tunnel2;
          lblPlaying.Text = Settings.NextScheduledMsg.Filename;
          audio.SelectedMessage = Settings.NextScheduledMsg.Filename;
          btnPlay_Click(this, null); 

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
          StartScheduledMsg(); 
        }
    }
}
