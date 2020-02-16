using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Speech.Recognition;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MOVE.Shared
{
    public partial class Help : Form
    {
        int counter = 0;
        string line;
        int speechmodulevalue = 1;
        int speechvalue;
        SpeechRecognitionEngine _recognizerservergerman = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("de-DE"));
        SpeechRecognitionEngine _recognizerserverenglish = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-GB"));
        ErrorLogWriter elw = new ErrorLogWriter();

        int currentlist;
        string listname = "item";
        List<string> items1 = new List<string>();

        public Help()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
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
        /*/
        protected override bool ShowWithoutActivation
        {
            get
            {
                return true;
            }
        }
        /*/
        public void FillHelpResults(string commands)
        {
            helpbox.Items.Clear();
            System.IO.StreamReader file =  new System.IO.StreamReader(@""+commands);
            while ((line = file.ReadLine()) != null)
            {
                if (line != "Which commands are avaiable?" && line != "Welche Befehle gibt es?")
                {
                    helpbox.Items.Add(line);
                    counter++;
                }
                else
                {
                    counter++;
                }
            }
            file.Close();
  
        }

        public void FillHelpResults(string commands, int value)
        {
            int countstripe=0;

            helpbox.Items.Clear();
            System.IO.StreamReader file = new System.IO.StreamReader(@"" + commands);
            while ((line = file.ReadLine()) != null)
            {
                if (line != "Which commands are avaiable?" && line != "Welche Befehle gibt es?")
                {
                    if (line == "---")
                    {
                        countstripe++;
                    }
                    else
                    {
                        if (value == 0)
                        {
                            if (countstripe <= 0)
                            {
                                SelectList();
                            }
                            else
                            {

                            }
                        }
                        if (value == 1)
                        {
                            if (countstripe <= 1)
                            {
                                SelectList();
                            }
                            else
                            {

                            }
                        }
                        if (value == 2)
                        {
                            if (countstripe <= 0 || countstripe==2)
                            {
                                SelectList();
                            }
                            else
                            {

                            }
                        }
                        if (value == 3)
                        {
                            if (countstripe <= 0 || countstripe == 3)
                            {
                                SelectList();
                            }
                            else
                            {

                            }
                        }
                    }
                }
                else
                {
                    counter++;
                }
            }
            foreach (string item in items1)
            {
                helpbox.Items.Add(item.ToString());
            }
            file.Close();

        }

        private void SelectList()
        {
                items1.Add(line.ToString());
                counter++;
        }

        Timer timer = new Timer();

        private void Help_Load(object sender, EventArgs e)
        {

            
        }

        

       
    }
}
