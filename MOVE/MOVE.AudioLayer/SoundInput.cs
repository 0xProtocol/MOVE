using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio;
using NAudio.Wave;

namespace MOVE.AudioLayer
{
    public class SoundInput
    {
        #region Variablen
        public double audioValueMax = 0;
        public  double audioValueLast = 0;
        public  int audioCount = 0;
        public  int RATE = 44100;
        public int BUFFER_SAMPLES = 2800;
         int yValue = 663;
        List<int> savedValues = new List<int>();
        public int positionValue = 0;
        public int wertGlaettung = 3;
        int averagealt;
        public int average;
        public int mod;
        int summe = 0;
        string ip;
        public int speed_left = 4;
        public int speed_top = 4;
        #endregion
        #region Methoden
        public void Loading()
        {
            var waveIn = new WaveInEvent();
            waveIn.DeviceNumber = 0;
            waveIn.WaveFormat = new NAudio.Wave.WaveFormat(RATE, 1);
            waveIn.DataAvailable += OnDataAvailable;
            waveIn.BufferMilliseconds = (int)((double)BUFFER_SAMPLES / (double)RATE * 1000.0);
            waveIn.StartRecording();
        }

        private void OnDataAvailable(object sender, WaveInEventArgs args)
        {

            float max = 0;

            // interpret as 16 bit audio
            for (int index = 0; index < args.BytesRecorded; index += 2)
            {
                short sample = (short)((args.Buffer[index + 1] << 8) |
                                        args.Buffer[index + 0]);
                var sample32 = sample / 32768f; // to floating point
                if (sample32 < 0) sample32 = -sample32; // absolute value 
                if (sample32 > max) max = sample32; // is this the max value?
            }

            // calculate what fraction this peak is of previous peaks
            if (max > audioValueMax)
            {
                audioValueMax = (double)max;
            }
            audioValueLast = max;
            audioCount += 1;
        }
    }
}
#endregion