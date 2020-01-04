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

        public void CalculateData()
        {
            byte[] audioBytes = new byte[bufferSamples];
            bwp.Read(audioBytes, 0, bufferSamples);

            if (audioBytes.Length == 0)
                return;
            if (audioBytes[bufferSamples - 2] == 0)
                return;

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
        }

        public int CalculatePaddleLocationX(int setting, double threshold)
        {
            if (maxValue > threshold)
            {
                if (setting == 1)
                {
                    xValue = maxIndex * 192 - 2 * 192;
                }
                if (setting == 2)
                {
                    xValue = maxIndex * 165 - 2 * 165;
                }
                if (setting == 3)
                {
                    xValue = maxIndex * 165 - 3 * 165;
                }
                if (setting == 4)
                {
                    xValue = maxIndex * 105 - 4 * 105;
                }
                if (setting == 5)
                {
                    xValue = maxIndex * 105 - 5 * 105;
                }
                if (setting == 6)
                {
                    xValue = maxIndex * 83 - 6 * 83;
                }
                if (setting == 7)
                {
                    xValue = maxIndex * 25 - 10 * 25;
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
