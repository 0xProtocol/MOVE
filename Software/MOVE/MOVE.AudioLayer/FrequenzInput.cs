using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MOVE.Shared;
using NAudio;
using NAudio.Wave;

namespace MOVE.AudioLayer
{
    public class FrequenzInput
    {
        #region Klasseninstanzvariablen
        ErrorLogWriter ewl = new ErrorLogWriter();
        #endregion
        #region Variablen
        int rate = 44100;
        int bufferSamples = 2048;
        public BufferedWaveProvider bwp;
        int xValue = 0;
        double maxValue = 0.0;
        int maxIndex = 0;
        List<int> maxIndexList = new List<int>();
        int calValue = 0;
        #endregion
        #region Methoden

        public void Start()
        {
            StartMicrofoneRecording();
        }

        void AudioDataAvailable(object sender, WaveInEventArgs e)
        {
            bwp.AddSamples(e.Buffer, 0, e.BytesRecorded);
        }

        void StartMicrofoneRecording()
        {
            try
            {
                WaveIn waveIn = new WaveIn();
                waveIn.DeviceNumber = 0;
                waveIn.WaveFormat = new NAudio.Wave.WaveFormat(rate, 1);
                waveIn.BufferMilliseconds = (int)((double)bufferSamples / (double)rate * 1000.0);
                waveIn.DataAvailable += new EventHandler<WaveInEventArgs>(AudioDataAvailable);
                bwp = new BufferedWaveProvider(waveIn.WaveFormat);
                bwp.BufferLength = bufferSamples * 2;
                bwp.DiscardOnBufferOverflow = true;
                waveIn.StartRecording();
            }
            catch(Exception ex)
            {
                ewl.WriteErrorLog(ex.ToString());
            }
        }

        public void CalculateData(int cal)
        {
            byte[] audioBytes = new byte[bufferSamples];
            bwp.Read(audioBytes, 0, bufferSamples);

            if (audioBytes.Length == 0)
            {
                return;
            }
            if (audioBytes[bufferSamples - 2] == 0)
            {
                return;
            }

            int lenght = bufferSamples / 2;

            double[] pcm = new double[lenght];
            double[] fft = new double[lenght];
            double[] fftReal = new double[lenght / 2];

            for (int i = 0; i < lenght; i++)
            {
                Int16 val = BitConverter.ToInt16(audioBytes, i * 2);
                pcm[i] = (double)(val) / Math.Pow(2, 16) * 200.0;
            }

            fft = FFT(pcm);
            Array.Copy(fft, fftReal, fftReal.Length);

            maxValue = fftReal.Max();
            maxIndex = Array.IndexOf(fftReal, maxValue);
            //maxIndex = fftReal.ToList().IndexOf(maxValue);

            if (cal == 1)
            {
                maxIndexList.Add(maxIndex);
            }
            if (cal == 2)
            {
                if (maxIndexList.Count != 0)
                {
                    calValue = Convert.ToInt32(maxIndexList.Average());
                    maxIndexList.Clear();
                }
            }
        }

        public int CalculatePaddleLocationX(int setting, double threshold)
        {
            if (maxValue > threshold)
            {
                if (setting == 1)
                {
                    xValue = maxIndex * 225 - 2 * 225;
                }
                if (setting == 2)
                {
                    xValue = maxIndex * 193 - 2 * 193;
                }
                if (setting == 3)
                {
                    xValue = maxIndex * 193 - 3 * 193;
                }
                if (setting == 4)
                {
                    xValue = maxIndex * 123 - 4 * 123;
                }
                if (setting == 5)
                {
                    xValue = maxIndex * 123 - 5 * 123;
                }
                if (setting == 6)
                {
                    xValue = maxIndex * 97 - 6 * 97;
                }
                if (setting == 7)
                {
                    xValue = maxIndex * 25 - 15 * 25;
                }
                if (setting == 8)
                {
                    xValue = maxIndex * 80 - calValue * 80;
                }
                return xValue;
            }
            else
            {
                xValue = 0;
                return xValue;
            }
        }

        double[] FFT(double[] data)
        {
            double[] fft = new double[data.Length];
            System.Numerics.Complex[] fftComplex = new System.Numerics.Complex[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                fftComplex[i] = new System.Numerics.Complex(data[i], 0.0);
            }
            Accord.Math.FourierTransform.FFT(fftComplex, Accord.Math.FourierTransform.Direction.Forward);
            for (int i = 0; i < data.Length; i++)
            {
                fft[i] = fftComplex[i].Magnitude;
            }
            return fft;
        }
    }
}
#endregion
