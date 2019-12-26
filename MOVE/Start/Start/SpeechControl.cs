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
using MOVE.Shared;

namespace Start
{
    public class SpeechControl
    {
        #region Klasseninstanzierungen
        SpeechRecognitionEngine _recognizer = new SpeechRecognitionEngine();
        SpeechSynthesizer com = new SpeechSynthesizer();
        ErrorLogWriter elw = new ErrorLogWriter();
        #endregion
        #region Speech Recognition
        public void DefaultListener()
        {
            try
            {

            _recognizer.SetInputToDefaultAudioDevice();
            _recognizer.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines(@"commandsmainwindow.txt")))));
            _recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Default_SpeechRecognized);
            _recognizer.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception ex)
            {
                elw.WriteErrorLog(ex.Message);
            }
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
            
            if(speech=="exit")
            {
                ExitGame();
            }
        }
        #endregion
        #region Methoden
        private void OpenServer()
        {
            ServerForms sf = new ServerForms();
            sf.Show();
        }
        private void OpenClient()
        {
            ClientForms cf = new ClientForms();
            cf.Show();
        }

        private void OpenInformation()
        {
            Info info = new Info();
            info.ShowDialog();
        }

        private void OpenSettings()
        {
            Settings s = new Settings();
            s.ShowDialog();
        }

        private void OpenÜbung()
        {
            SinglePlayerForms spf = new SinglePlayerForms();
            spf.ShowDialog();
        }

        private void ExitGame()
        {
            Environment.Exit(1);
        }
        public void CancelDefaultListener()
        {
            try
            {
                _recognizer.RecognizeAsyncStop();
            }
            catch (Exception ex)
            {
                elw.WriteErrorLog(ex.Message);
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
                elw.WriteErrorLog(ex.Message);
            }
        }
    }
}
#endregion