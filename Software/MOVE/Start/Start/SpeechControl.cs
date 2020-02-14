using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
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
        SpeechRecognitionEngine _recognizerenglish = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-GB"));
        SpeechRecognitionEngine _recognizergerman = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("de-DE"));
        ErrorLogWriter elw = new ErrorLogWriter();
        #endregion
        #region Speech Recognition
        public void DefaultListenerGerman()
        {
            try
            {
                _recognizergerman.SetInputToDefaultAudioDevice();
                GrammarBuilder gb = new GrammarBuilder(new Choices(File.ReadAllLines(@"SpeechRecognitionEngineGerman\commandsmainwindow.txt")));
                gb.Culture = new CultureInfo("de-DE");
                Grammar g = new Grammar(gb);
                _recognizergerman.LoadGrammar(g);
                _recognizergerman.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(DefaultGerman_SpeechRecognized);
                _recognizergerman.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception ex)
            {
                elw.WriteErrorLog(ex.Message);
            }
        }
        public void DefaultListenerEnglish()
        {
            try
            {
                _recognizerenglish.SetInputToDefaultAudioDevice();
                GrammarBuilder gb = new GrammarBuilder(new Choices(File.ReadAllLines(@"SpeechRecognitionEngineEnglish\commandsmainwindow.txt")));
                gb.Culture = new CultureInfo("en-GB"); 
                Grammar g = new Grammar(gb);
                _recognizerenglish.LoadGrammar(g);
                _recognizerenglish.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(DefaultEnglish_SpeechRecognized);
                _recognizerenglish.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception ex)
            {
                elw.WriteErrorLog(ex.Message);
            }
        }
      
        public void DefaultGerman_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
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

            if (speech == "Informationen")
            {
                OpenInformation();
            }

            if (speech == "Spieleinstellungen")
            {
                OpenSettings();
            }

            if (speech == "Übungsmodus")
            {
                OpenÜbung();
            }
            
            if(speech== "Schließe das Spiel")
            {
                ExitGame();
            }
            if (speech == "Zeige allgemeine Hilfe")
            {
                GeneralHelp gh = new GeneralHelp();
                gh.ShowDialog();
            }
            if (speech=="Welche Befehle gibt es?")
            {
                MOVE.Shared.Help h = new MOVE.Shared.Help();
                h.FillHelpResults("SpeechRecognitionEngineGerman\\commandsmainwindow.txt");
                h.ShowDialog();
            }
        }
        public void DefaultEnglish_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string speech = e.Result.Text;
            if (speech == "Start Server")
            {
                OpenServer();
            }
            if (speech == "Start Client")
            {
                OpenClient();
            }

            if (speech == "Information")
            {
                OpenInformation();
            }

            if (speech == "Settings")
            {
                OpenSettings();
            }

            if (speech == "Practice Mode")
            {
                OpenÜbung();
            }
            if (speech == "show general help")
            {
                GeneralHelp gh = new GeneralHelp();
                gh.ShowDialog();
            }
            if (speech == "Exit the game")
            {
                ExitGame();
            }
            if(speech=="Which commands are avaiable?")
            {
                MOVE.Shared.Help h = new MOVE.Shared.Help();
                h.FillHelpResults("SpeechRecognitionEngineEnglish\\commandsmainwindow.txt");
                h.ShowDialog();
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
        public void CancelDefaultGermanListener()
        {
            try
            {
                _recognizergerman.RecognizeAsyncStop();
            }
            catch (Exception ex)
            {
                elw.WriteErrorLog(ex.ToString());
            }
        }

        public void ActivateDefaultGermanListener()
        {
            try
            {
                _recognizergerman.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception ex)
            {
                elw.WriteErrorLog(ex.ToString());
            }
        }
        public void CancelDefaultEnglishListener()
        {
            try
            {
                _recognizerenglish.RecognizeAsyncStop();
            }
            catch (Exception ex)
            {
                elw.WriteErrorLog(ex.ToString());
            }
        }

        public void ActivateDefaultEnglishListener()
        {
            try
            {
                _recognizerenglish.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception ex)
            {
                elw.WriteErrorLog(ex.ToString());
            }
        }
    }
}
#endregion