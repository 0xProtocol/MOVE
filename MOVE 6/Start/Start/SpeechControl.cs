using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using MOVE.Client.Debug.Formular;
using MOVE.Server.Debug.Formular;

namespace Start
{
  public  class SpeechControl
    {
        SpeechRecognitionEngine _recognizer = new SpeechRecognitionEngine();
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

        public void Default_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string speech = e.Result.Text;

            if (speech == "Los")
            {
                OpenClientServer();
            }

            if(speech== "Spielinformation")
            {
                OpenInformation();
            }

            if(speech=="Settings")
            {
                OpenSettings();
            }

            if(speech=="Deaktiviere Sprachmodul")
            {
                _recognizer.RecognizeAsyncCancel();
                com.SpeakAsync("deactivated");
                startlistening.RecognizeAsync(RecognizeMode.Multiple);
            }

            if(speech=="Übungsmodus")
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
                _recognizer.RecognizeAsyncCancel();
                //  com.SpeakAsync("deactivated");
                startlistening.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception ex)
            {

            }
        }

        public void BackgroundListener()
        {
            startlistening.SetInputToDefaultAudioDevice();
            startlistening.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines(@"DefaultSettings.txt")))));
            startlistening.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(startlistening_SpeechRecognized);
        }

        private void startlistening_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string speech = e.Result.Text;

            if (speech == "Sprachmodul aktiviere")
            {
                startlistening.RecognizeAsyncCancel();
                com.SpeakAsync("EI em hier");
                _recognizer.RecognizeAsync(RecognizeMode.Multiple);
            }
        }
    }
}
