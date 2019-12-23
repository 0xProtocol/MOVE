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
        SpeechSynthesizer com = new SpeechSynthesizer();

        public void DefaultListener()
        {
            _recognizer.SetInputToDefaultAudioDevice();
            _recognizer.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines(@"commandsmainwindow.txt")))));
            _recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Default_SpeechRecognized);
            _recognizer.RecognizeAsync(RecognizeMode.Multiple);
        }
      
        public void Default_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string speech = e.Result.Text;
            if (speech == "Starte Server")
            {
                OpenServer();
            }
            if(speech=="Starte Client")
            {
                OpenClient();
            }

            if (speech == "Spielinformation")
            {
                OpenInformation();
            }

            if (speech == "Settings")
            {
                OpenSettings();
            }

            if (speech == "Übungsmodus")
            {
                OpenÜbung();
            }
        }

        public void OpenServer()
        {
            ServerForms sf = new ServerForms();
            sf.Show();
        }
        public void OpenClient()
        {
            ClientForms cf = new ClientForms();
            cf.Show();
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
    }
}
