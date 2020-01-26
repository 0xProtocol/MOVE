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
        public double soundValueOne = 0;
        public  double soundValueTwo = 0;
        public  int audioCount = 10;
        public  int samplingRate = 44000;
        public int bufferSize = 2048;
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
            waveIn.WaveFormat = new NAudio.Wave.WaveFormat(samplingRate, 1);
            waveIn.DataAvailable += GetSoundValues;
            waveIn.BufferMilliseconds = (int)((double)bufferSize / (double)samplingRate * 1000.0);
            waveIn.StartRecording();
        }

        private void GetSoundValues(object sender, WaveInEventArgs args)
        {

            float tempSoundValue = 0;

            for (int index = 0; index < args.BytesRecorded; index += 3)
            {
                short sample = (short)((args.Buffer[index + 1] << 8) | args.Buffer[index + 0]);
                var audioSample = sample / 32668f; 
                if (audioSample < 0) audioSample = -audioSample;  
                if (audioSample > tempSoundValue) tempSoundValue = audioSample;
            }

            if (tempSoundValue > soundValueOne)
            {
                soundValueOne = (double)tempSoundValue;
            }
            soundValueTwo = tempSoundValue;
            audioCount += 1;
        }
    }
}
#endregion