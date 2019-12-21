using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MOVE.Client.Debug.Formular;
using MOVE.Server.Debug.Formular;

namespace Start
{
    public class SpeechControl
    {
        SpeechRecognitionEngine _recognizer = new SpeechRecognitionEngine();
        SpeechRecognitionEngine _recognizerinfo = new SpeechRecognitionEngine();
        SpeechRecognitionEngine startlistening = new SpeechRecognitionEngine();
        SpeechSynthesizer com = new SpeechSynthesizer();

        public void DefaultListener()
        {
            _recognizer.SetInputToDefaultAudioDevice();
            _recognizer.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines(@"DefaultSettings.txt")))));
            _recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Default_SpeechRecognized);
            _recognizer.SpeechDetected += new EventHandler<SpeechDetectedEventArgs>(_recognizer_SpeechRecognized);
            _recognizer.RecognizeAsync(RecognizeMode.Multiple);
        }


        private void _recognizer_SpeechRecognized(object sender, SpeechDetectedEventArgs e)
        {
        }
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        private string GetActiveWindowTitle()
        {
            const int nChars = 256;
            StringBuilder Buff = new StringBuilder(nChars);
            IntPtr handle = GetForegroundWindow();

            if (GetWindowText(handle, Buff, nChars) > 0)
            {
                return Buff.ToString();
            }
            return null;
        }
        public void Default_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string speech = e.Result.Text;
            if (speech == "Los")
            {
                OpenClientServer();
            }

            if (speech == "Spielinformation")
            {
                OpenInformation();
            }

            if (speech == "Settings")
            {
                OpenSettings();
            }

            if (speech == "Deaktiviere Sprachmodul")
            {
                _recognizer.RecognizeAsyncCancel();
                com.SpeakAsync("deactivated");
                startlistening.RecognizeAsync(RecognizeMode.Multiple);
            }

            if (speech == "Übungsmodus")
            {
                OpenÜbung();
            }

        }


        public void OpenClientServer()
        {
            ClientForms cf = new ClientForms();
            cf.Show();
            ServerForms sf = new ServerForms();
            sf.Show();
        }

        public void OpenInformation()
        {
            Info info = new Info();
            info.ShowDialog();
        }

        public void OpenSettings()
        {
            Settings s = new Settings();
            s.ShowDialog();
        }

        public void OpenÜbung()
        {
            SinglePlayerForms spf = new SinglePlayerForms();
            spf.ShowDialog();
        }

        public void CancelDefaultListener()
        {
            try
            {
                _recognizer.RecognizeAsyncStop();
            }
            catch (Exception ex)
            {

            }
        }

        public void ActivateDefaultListener()
        {
            try
            {
                _recognizer.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception ex)
            {

            }
        }
        public void CancelDefaultListenerInfo()
        {
            try
            {
                _recognizerinfo.RecognizeAsyncStop();
            }
            catch (Exception ex)
            {

            }
        }

        public void ActivateDefaultListenerInfo()
        {
            try
            {
                _recognizerinfo.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
