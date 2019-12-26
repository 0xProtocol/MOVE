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
    public class FrequenzInput
    {
        private int rate = 44100;
        private int bufferSamples = 2048;
        public BufferedWaveProvider bwp;
        int xValue = 0;
        double maxValue = 0.0;
        int maxIndex = 0;
        
        public void Start()
        {
            StartMicrofoneRecording();
        }

        void AudioDataAvailable(object sender, WaveInEventArgs e)
        {
            bwp.AddSamples(e.Buffer, 0, e.BytesRecorded);
        }

        public void StartMicrofoneRecording()
        {
            WaveIn waveIn = new WaveIn();
            waveIn.DeviceNumber = 0;
            waveIn.WaveFormat = new NAudio.Wave.WaveFormat(rate, 1);
            waveIn.BufferMilliseconds = (int)((double)bufferSamples / (double)rate * 1000.0);
            waveIn.DataAvailable += new EventHandler<WaveInEventArgs>(AudioDataAvailable);
            bwp = new BufferedWaveProvider(waveIn.WaveFormat);
            bwp.BufferLength = bufferSamples * 2;
            bwp.DiscardOnBufferOverflow = true;

            try
            {
                waveIn.StartRecording();
            }
            catch
            {
                MessageBox.Show("Aufnahme fehlgeschlagen");
            }
        }

        public void CalculateData()
        {
            var audioBytes = new byte[bufferSamples];
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
            maxIndex = fftReal.ToList().IndexOf(maxValue);
        }

        public int CalculatePaddleLocationX(int setting)
        {
            if (maxValue > 0.01)
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
                    xValue = maxIndex * 60 - 25 * 60;
                }

                return xValue;
            }
            else
            {
                xValue = 0;
                return xValue;
            }
        }

        public void SetPaddleLocation(PictureBox pbPaddle)
        {

        }

        public double[] FFT(double[] data)
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

