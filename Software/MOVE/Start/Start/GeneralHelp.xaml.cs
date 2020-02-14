using MOVE.Shared;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Speech.Recognition;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Start
{
    /// <summary>
    /// Interaktionslogik für GeneralHelp.xaml
    /// </summary>
    public partial class GeneralHelp : Window
    {


        int speechmodulevalue = 1;
        int speechvalue;
        SpeechRecognitionEngine _recognizerservergerman = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("de-DE"));
        SpeechRecognitionEngine _recognizerserverenglish = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-GB"));
        ErrorLogWriter elw = new ErrorLogWriter();

       

        public GeneralHelp()
        {
            InitializeComponent();
            string language = ConfigurationManager.AppSettings["language"];
            speechvalue = Convert.ToInt32(language);
            string speechmodule = ConfigurationManager.AppSettings["speechmodule"];
            speechmodulevalue = Convert.ToInt32(speechmodule);
            if (speechmodulevalue == 1)
            {
                if (speechvalue == 0)
                {
                    DefaultListenerGerman();
                }
                if (speechvalue == 1)
                {
                    DefaultListenerEnglish();
                }
            }
            else
            {

            }

        }

        public void DefaultListenerGerman()
        {
            try
            {
                _recognizerservergerman.SetInputToDefaultAudioDevice();
                GrammarBuilder gb = new GrammarBuilder(new Choices(File.ReadAllLines(@"SpeechRecognitionEngineGerman\commandshelp.txt")));
                gb.Culture = new CultureInfo("de-DE");
                Grammar g = new Grammar(gb);
                _recognizerservergerman.LoadGrammar(g);
                _recognizerservergerman.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(DefaultServerGerman_SpeechRecognized);
                _recognizerservergerman.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception ex)
            {
                elw.WriteErrorLog(ex.Message);
            }
        }

        private void DefaultServerGerman_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string speech = e.Result.Text;

            if (speech == "Danke für die Hilfe")
            {
                CloseWindow();
            }

        }

        public void DefaultListenerEnglish()
        {
            try
            {
                _recognizerserverenglish.SetInputToDefaultAudioDevice();
                GrammarBuilder gb = new GrammarBuilder(new Choices(File.ReadAllLines(@"SpeechRecognitionEngineEnglish\commandshelp.txt")));
                gb.Culture = new CultureInfo("en-GB");
                Grammar g = new Grammar(gb);
                _recognizerserverenglish.LoadGrammar(g);
                _recognizerserverenglish.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(DefaultServerEnglish_SpeechRecognized);
                _recognizerserverenglish.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception ex)
            {
                elw.WriteErrorLog(ex.Message);
            }
        }

        private void DefaultServerEnglish_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string speech = e.Result.Text;

            if (speech == "thanks for the help")
            {
                CloseWindow();
            }
        }

        private void CloseWindow()
        {
            this.Close();
        }
        private void Helpbox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


       

      
      

    }
}
