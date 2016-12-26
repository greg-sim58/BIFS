using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using NAudio.Wave;

namespace BreakIn
{
  class Audio
  {
    public event EventHandler TestEvent;

    public enum PlayStates
    {
      Idle,
      ReadyToPlay,
      Stopped,
      Playing,
      Paused,
      ReadyToBroadcast
    };

    private NAudio.Wave.WaveFileReader wave = null;
    private NAudio.Wave.DirectSoundOut output = null;
    private NAudio.Wave.BlockAlignReductionStream stream = null;
    private WaveOut waveOut;
    WaveFileReader reader;// = new WaveFileReader(msg);
    LoopStream loop;// = new LoopStream(reader);

    public string SelectedMessage = "";
    public int SelectedTunnel = 0;
    public bool LoopSelected = false;

    public PlayStates PlayState;

    //public string RecordedMessageDir = "C:\\bs_elec\\BreakIn\\BreakIn\\bin\\Debug\\RecordedMessages";
    public string RecordedMessageDir = Directory.GetCurrentDirectory() + "\\RecordedMessages";

    private void output_PlaybackStopped(object sender, EventArgs e)
    {
      MessageBox.Show("playback stopped");
    }

    public bool PlayMessage(bool brdcast)
    {
      bool result = true;
      if (brdcast == false)
      {
          if (LoopSelected)
              result = LoopMessage(SelectedMessage);
          else
              result = StartMessage(SelectedMessage);
      }
      else
      {
          result = BroadcastMessage();
      }
      return result;
    }

    NAudio.Wave.WaveIn sourceStream = null;
    NAudio.Wave.DirectSoundOut BroadcastWaveOut = null;
    NAudio.Wave.WaveFileWriter waveWriter = null;

    private bool BroadcastMessage()
    {
        int deviceNumber = Settings.SpeechDevice;

        if (PlayState == PlayStates.Playing)
        {
            if (BroadcastWaveOut != null)
            {
                BroadcastWaveOut.Stop();
                BroadcastWaveOut.Dispose();
                BroadcastWaveOut = null;
            }
            if (sourceStream != null)
            {
                sourceStream.StopRecording();
                sourceStream.Dispose();
                sourceStream = null;
            }

            PlayState = PlayStates.Idle;
        }
        else
        {
            PlayState = PlayStates.Playing;

            try
            {
                sourceStream = new NAudio.Wave.WaveIn();
                sourceStream.DeviceNumber = deviceNumber;
                sourceStream.WaveFormat = new NAudio.Wave.WaveFormat(44100, NAudio.Wave.WaveIn.GetCapabilities(deviceNumber).Channels);

                NAudio.Wave.WaveInProvider waveIn = new NAudio.Wave.WaveInProvider(sourceStream);
                BroadcastWaveOut = new NAudio.Wave.DirectSoundOut();
                BroadcastWaveOut.Init(waveIn);

                sourceStream.StartRecording();
                BroadcastWaveOut.Play();
            }
            catch (Exception ex)
            {
                sourceStream = null;
                MessageBox.Show("AUDIO INPUT ERROR:\n\r " + ex.Message + "\n\r Please check Speech Device settings");
            }

        }

        return true;
    }

    public void PlayMessage(string msg)
    {
      if ((SelectedTunnel > 0) & (SelectedMessage != "") & (PlayState == PlayStates.Playing))
      {
        if (LoopSelected)
          LoopMessage(msg);
        else
          StartMessage(SelectedMessage);
      }

    }

    public bool StartMessage(string msg)
    {
      DisposeWave();
      msg =  RecordedMessageDir + "\\" + msg;
      if ((msg != null) && (File.Exists(msg) == false))
      {
          MessageBox.Show("File does exist.\n\r " + msg + "\n\r Check message folder.");
          return false;
      }

      if (waveOut == null)
      {
        reader = new WaveFileReader(msg);
        loop = new LoopStream(reader);
        loop.EnableLooping = false;
        waveOut = new WaveOut();
        waveOut.Init(loop);
        waveOut.Play();
        waveOut.PlaybackStopped += TestEvent;

        PlayState = PlayStates.Playing;
      }
      else
      {
        waveOut.Stop();
        waveOut.Dispose();
        waveOut = null;
      }
      return true;
    }

    void waveOut_PlaybackStopped(object sender, EventArgs e)
    {
      throw new NotImplementedException();
    }


    public bool LoopMessage(string msg)
    {
      DisposeWave();
      //msg = Directory.GetCurrentDirectory() + "\\recordedmessages\\" + msg;
      msg = RecordedMessageDir + "\\" + msg;
      if (File.Exists(msg) == false)
      {
          MessageBox.Show("File does exist.\n\r " + msg + "\n\r Check message folder.");
          return false;
      }
      if (waveOut == null)
      {
        WaveFileReader reader = new WaveFileReader(msg);
        LoopStream loop = new LoopStream(reader);
        waveOut = new WaveOut();
        waveOut.Init(loop);
        waveOut.Play();
        PlayState = PlayStates.Playing;
      }
      else
      {
        waveOut.Stop();
        waveOut.Dispose();
        waveOut = null;
      }
      return true;
    }

    public void loop_StartEvent()
    {
      
    }
    public void StopMessage()
    {
      if (output != null)
      {
        output.Stop();
        PlayState = PlayStates.Stopped;
        DisposeWave();
      }
      if (waveOut != null)
      {
          waveOut.Stop();
          waveOut.Dispose();
          waveOut = null;
          PlayState = PlayStates.Stopped;
      }
      if (BroadcastWaveOut != null)
      {
        BroadcastWaveOut.Stop();
        BroadcastWaveOut.Dispose();
        BroadcastWaveOut = null;
      }
      if (sourceStream != null)
      {
        sourceStream.StopRecording();
        sourceStream.Dispose();
        sourceStream = null;
      }
      PlayState = PlayStates.Stopped;
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
      if (loop != null)
      {
          loop.Dispose();
          loop = null;
      }
      if (reader != null)
      {
          reader.Dispose();
          reader = null;
      }
    }
  }
}
