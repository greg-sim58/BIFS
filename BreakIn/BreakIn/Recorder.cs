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
  public partial class Recorder : Form
  {
    private string Msgdir;
    private string tmpFile = Directory.GetCurrentDirectory() + "\\tmp.wav";
    private NAudio.Wave.WaveFileReader wave = null;
    private NAudio.Wave.DirectSoundOut output = null;

    public Recorder()
    {
      InitializeComponent();
      Msgdir = Settings.RecordedMessageDir;
    }

    private void DisposeWave()
    {
      if (output != null)
      {
        if (output.PlaybackState == NAudio.Wave.PlaybackState.Playing) output.Stop();
        output.Dispose();
        output = null;
      }
      if (wave != null)
      {
        wave.Dispose();
        wave = null;
      }
    }

    private void LoadSources()
    {
      List<NAudio.Wave.WaveInCapabilities> sources = new List<NAudio.Wave.WaveInCapabilities>();

      for (int i = 0; i < NAudio.Wave.WaveIn.DeviceCount; i++)
      {
        sources.Add(NAudio.Wave.WaveIn.GetCapabilities(i));
      }

      SourceList.Items.Clear();

      foreach (var source in sources)
      {
        ListViewItem item = new ListViewItem(source.ProductName);
        item.SubItems.Add(new ListViewItem.ListViewSubItem(item, source.Channels.ToString()));
        SourceList.Items.Add(item);
      }
    }

    private void Recorder_Load(object sender, EventArgs e)
    {
        //Msgdir = Directory.GetCurrentDirectory() + "\\RecordedMessages\\";
        Msgdir = Settings.RecordedMessageDir;
        LoadSources();

    }
    public string GetRecordedMessage()
    {
      string Result = "new message";
      return Result;
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      Close();
    }

    NAudio.Wave.WaveIn sourceStream = null;
    NAudio.Wave.DirectSoundOut waveOut = null;
    NAudio.Wave.WaveFileWriter waveWriter = null;

    private void sourceStream_DataAvailable(object sender, NAudio.Wave.WaveInEventArgs e)
    {
      if (waveWriter == null) return;

      waveWriter.WriteData(e.Buffer, 0, e.BytesRecorded);
      waveWriter.Flush();
    }



    private void btnStartRecording_Click(object sender, EventArgs e)
    {
      if (File.Exists(tmpFile))
        File.Delete(tmpFile);
      if (SourceList.SelectedItems.Count == 0) return;

      int deviceNumber = SourceList.SelectedItems[0].Index;

      sourceStream = new NAudio.Wave.WaveIn();
      sourceStream.DeviceNumber = deviceNumber;
      sourceStream.WaveFormat = new NAudio.Wave.WaveFormat(44100, NAudio.Wave.WaveIn.GetCapabilities(deviceNumber).Channels);

      sourceStream.DataAvailable += new EventHandler<NAudio.Wave.WaveInEventArgs>(sourceStream_DataAvailable);
      waveWriter = new NAudio.Wave.WaveFileWriter(tmpFile, sourceStream.WaveFormat);

      sourceStream.StartRecording();
      btnStopRecording.Enabled = true;
      btnStartRecording.Enabled = false;
    }

    private void btnStopRecording_Click(object sender, EventArgs e)
    {
      if (waveOut != null)
      {
        waveOut.Stop();
        waveOut.Dispose();
        waveOut = null;
      }
      if (sourceStream != null)
      {
        sourceStream.StopRecording();
        sourceStream.Dispose();
        sourceStream = null;
      }
      if (waveWriter != null)
      {
        waveWriter.Dispose();
        waveWriter = null;
      }

      btnStopRecording.Enabled = false;
      btnStartRecording.Enabled = true;
      btnPlayBack.Enabled = true;
      btnSaveRecording.Enabled = true;
    }

    private void btnPlayBack_Click(object sender, EventArgs e)
    {
      if (btnPlayBack.Text == "Play Recording")
      {
        btnPlayBack.Text = "Stop Playback";
        btnStartRecording.Enabled = false;
        btnStopRecording.Enabled = false;
        btnSaveRecording.Enabled = false;

        DisposeWave();

        wave = new NAudio.Wave.WaveFileReader(tmpFile);
        output = new NAudio.Wave.DirectSoundOut();
        output.Init(new NAudio.Wave.WaveChannel32(wave));
        output.Play();
      }
      else
      {
        output.Stop();
        DisposeWave();
        btnPlayBack.Text = "Play Recording";
        btnStartRecording.Enabled = true;
        btnStopRecording.Enabled = false;
        btnSaveRecording.Enabled = true;
      }
    }


    private void SourceList_SelectedIndexChanged(object sender, EventArgs e)
    {
      btnStartRecording.Enabled = (SourceList.SelectedItems.Count > 0);
    }

    private void btnSaveRecording_Click(object sender, EventArgs e)
    {
      string dest;
      if (File.Exists(tmpFile))
      {
        SaveFileDialog save = new SaveFileDialog();
        save.InitialDirectory = Msgdir;
        
        save.Filter = "Wave File (*.wav)|*.wav;";
        if (save.ShowDialog() == DialogResult.OK)
        {
          dest = save.FileName;
          System.IO.File.Copy(tmpFile, dest, true);
        }
      }
      else
        MessageBox.Show("Cannot save file");
    }
  }
}
