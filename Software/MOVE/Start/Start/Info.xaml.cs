using MOVE.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Speech.Recognition;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Start
{
    /// <summary>
    /// Interaktionslogik für Info.xaml
    /// </summary>
    public partial class Info : Window
    {
        #region Klasseninstanzierungen
        SpeechRecognitionEngine _recognizergerman = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("de-DE"));
        SpeechRecognitionEngine _recognizerenglish = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-GB"));
        ErrorLogWriter elw = new ErrorLogWriter();
        #endregion
        int speechvalue;
        #region klassengenerierte Methoden
        public Info()
        {
            InitializeComponent();
            string speechmodule = ConfigurationManager.AppSettings["language"];
            speechvalue = Convert.ToInt32(speechmodule);
            if (speechvalue == 0)
            {
                DefaultListenerGerman();
            }
            if (speechvalue == 1)
            {
                DefaultListenerEnglish();
            }
            this.Focus();
        }
        private void Window_Activated(object sender, EventArgs e)
        {
            if (speechvalue == 0)
            {
                ActivateDefaultGermanListener();
            }
            else if (speechvalue == 1)
            {
                ActivateDefaultEnglishListener();
            }
        }
            private void Window_Deactivated(object sender, EventArgs e)
        {
                if (speechvalue == 0)
                {
                    CancelDefaultGermanListener();
                }
                else if (speechvalue == 1)
                {
                   CancelDefaultEnglishListener();
                }
            }
        #endregion
        #region Speech Recognition
        public void DefaultListenerGerman()
        {
            try
            {
                _recognizergerman.SetInputToDefaultAudioDevice();
                GrammarBuilder gb = new GrammarBuilder(new Choices(File.ReadAllLines(@"SpeechRecognitionEngineGerman\commandsinfo.txt")));
                gb.Culture = new CultureInfo("de-DE");
                Grammar g = new Grammar(gb);
                _recognizergerman.LoadGrammar(g);
                _recognizergerman.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(DefaultInfoGerman_SpeechRecognized);
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
                GrammarBuilder gb = new GrammarBuilder(new Choices(File.ReadAllLines(@"SpeechRecognitionEngineEnglish\commandsinfo.txt")));
                gb.Culture = new CultureInfo("en-GB");
                Grammar g = new Grammar(gb);
                _recognizerenglish.LoadGrammar(g);
                _recognizerenglish.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(DefaultInfoEnglish_SpeechRecognized);
                _recognizerenglish.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception ex)
            {
                elw.WriteErrorLog(ex.Message);
            }
        }

        private void DefaultInfoGerman_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {

            string speech = e.Result.Text;
            if (speech == "Schließe das Fenster")
            {
                CloseWindow();
            }
        }
        private void DefaultInfoEnglish_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {

            string speech = e.Result.Text;
            if (speech == "Exit")
            {
                CloseWindow();
            }
        }
        #endregion
        #region Methoden
        public void CloseWindow()
        {
            this.Close();
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
        #endregion

    }
}
