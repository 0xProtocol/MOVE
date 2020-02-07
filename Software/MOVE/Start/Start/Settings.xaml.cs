using MOVE.Shared;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Speech.Recognition;
using System.Speech.Synthesis;
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
    /// Interaktionslogik für Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        #region Klasseninstanzierungen
        SpeechRecognitionEngine _recognizergerman = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("de-DE"));
        SpeechRecognitionEngine _recognizerenglish = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-GB"));
        SpeechSynthesizer com = new SpeechSynthesizer();
        SpeechControl si = new SpeechControl();
        ErrorLogWriter elw = new ErrorLogWriter();
        int counter = 0;
        int speechvalue;
        #endregion
        #region klassengenerierte Methoden
        public Settings()
        {
            InitializeComponent();
            string speechmodule = ConfigurationManager.AppSettings["language"];
            speechvalue = Convert.ToInt32(speechmodule);
            this.Focus();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RadioButtonIsChecked();
            RadioButtonIsChecked2();
            RadioButtonIsChecked3();
            RadioButtonIsChecked4();
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {

        }
        private void Window_Activated(object sender, EventArgs e)
        {
            if (speechvalue == 0)
            {
                ActivateDefaultListenerSettingsGerman();
            }
            else if (speechvalue == 1)
            {
                ActivateDefaultListenerSettingsEnglish();
            }
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            if (speechvalue == 0)
            {
                CancelDefaultListenerSettingsGerman();
            }
            else if (speechvalue == 1)
            {
                CancelDefaultListenerSettingsEnglish();
            }
        }
        #endregion
        #region Speech Recognition

        private void DefaultSettingsGerman_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string speech = e.Result.Text;

            if (speech == "Empfindlichkeit leicht")
            {
                SetEmpfindlichkeitleicht();
            }

            if (speech == "Empfindlichkeit mittel")
            {
                SetEmpfindlichkeitmittel();
            }

            if (speech == "Empfindlichkeit stark")
            {
                SetEmpfindlichkeitschwer();
            }

            if (speech == "Glättung leicht")
            {
                SetGlättungleicht();
            }

            if (speech == "Glättung mittel")
            {
                SetGlättungmittel();
            }

            if (speech == "Glättung stark")
            {
                SetGlättungschwer();
            }
            if (speech == "speichern")
            {
               Save();
               
               com.SpeakAsync("Die Einstellungen wurden gespeichert");
            }
            if (speech == "Sprachmodul aktivieren")
            {
                Setspeechmoduleactive();
            }
            if (speech == "Deaktiviere Sprachmodul")
            {
                Setspeechmoduledeactive();
            }
            if (speech == "Stelle Sprache auf Deutsch")
            {
                SetLanguageGerman();
            }
            if (speech == "Stelle Sprache auf Englisch")
            {
                SetLanguageEnglish();
            }
            if (speech == "Abbrechen")
            {
                CloseWindow();
                CancelDefaultListenerSettingsGerman();
            }
        }

        private void DefaultSettingsEnglish_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string speech = e.Result.Text;

            if (speech == "sensitivity one")
            {
                SetEmpfindlichkeitleicht();
            }

            if (speech == "sensitivity two")
            {
                SetEmpfindlichkeitmittel();
            }

            if (speech == "sensitivity three")
            {
                SetEmpfindlichkeitschwer();
            }

            if (speech == "smoothing one")
            {
                SetGlättungleicht();
            }

            if (speech == "Gsmoothing two")
            {
                SetGlättungmittel();
            }

            if (speech == "smoothing three")
            {
                SetGlättungschwer();
            }
            if (speech == "save")
            {
                Save();

                com.SpeakAsync("The settings were saved");
            }
            if (speech == "speechmodule active")
            {
                Setspeechmoduleactive();
            }
            if (speech == "deactivate speechmodule")
            {
                Setspeechmoduledeactive();
            }
            if (speech == "set language to german")
            {
                SetLanguageGerman();
            }
            if (speech == "set language to english")
            {
                SetLanguageEnglish();
            }
            if (speech == "exit")
            {
                CloseWindow();
                CancelDefaultListenerSettingsGerman();
            }
        }
        #endregion
        #region Methoden
        private void CloseWindow()
        {
            this.Close();
        }
        private void Save()
        {
            RadioButtonIsChecked();
            RadioButtonIsChecked2();
            RadioButtonIsChecked3();
            RadioButtonIsChecked4();
        }
        private void SetEmpfindlichkeitleicht()
        {
            rb_einfach.IsChecked = true;
        }
        private void SetEmpfindlichkeitmittel()
        {
            rb_mittel.IsChecked = true;
        }
        private void SetEmpfindlichkeitschwer()
        {
            rb_schwer.IsChecked = true;
        }
        private void SetGlättungleicht()
        {
            rb_modell1.IsChecked = true;
        }

        private void SetGlättungmittel()
        {
            rb_modell2.IsChecked = true;
        }

        private void SetGlättungschwer()
        {
            rb_modell3.IsChecked = true;
        }
        private void Setspeechmoduleactive()
        {
            rb_speechmoduleactivated.IsChecked= true;
        }
        private void Setspeechmoduledeactive()
        {
            rb_speechmoduledeactivated.IsChecked = true;
        }
        private void SetLanguageEnglish()
        {
            rb_speechmoduleenglish.IsChecked = true;
        }
        private void SetLanguageGerman()
        {
            rb_speechmodulegerman.IsChecked = true;
        }

        public void RadioButtonIsChecked()
        {
            if (rb_einfach.IsChecked == true)
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["sensitivity"].Value = "1";
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            if (rb_mittel.IsChecked == true)
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["sensitivity"].Value = "2";
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            if (rb_schwer.IsChecked == true)
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["sensitivity"].Value = "3";
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
        }
        public void RadioButtonIsChecked2()
        {
            if (rb_modell1.IsChecked == true)
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["smoothing"].Value = "1";
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            if (rb_modell2.IsChecked == true)
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["smoothing"].Value = "2";
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            if (rb_modell3.IsChecked == true)
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["smoothing"].Value = "3";
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
        }
        public void RadioButtonIsChecked3()
        {
            if (rb_speechmoduleactivated.IsChecked == true)
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["speechmodule"].Value = "1";
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            if (rb_speechmoduledeactivated.IsChecked == true)
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["speechmodule"].Value = "0";
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
        }
        public void RadioButtonIsChecked4()
        {
            if (rb_speechmoduleenglish.IsChecked == true && speechvalue==0)
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["language"].Value = "1";
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
                Application.Current.Shutdown();
                System.Windows.Forms.Application.Restart();
            }
            if (rb_speechmodulegerman.IsChecked == true && speechvalue == 1)
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["language"].Value = "0";
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
                Application.Current.Shutdown();
                System.Windows.Forms.Application.Restart();
            }
        }
        public void CancelDefaultListenerSettingsGerman()
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

        public void ActivateDefaultListenerSettingsGerman()
        {
            if (counter < 1)
            {
                counter++;
                try
                {
                    _recognizergerman.SetInputToDefaultAudioDevice();
                    GrammarBuilder gb = new GrammarBuilder(new Choices(File.ReadAllLines(@"commandssettings.txt")));
                    gb.Culture = new CultureInfo("de-DE");
                    Grammar g = new Grammar(gb);
                    _recognizergerman.LoadGrammar(g);
                    _recognizergerman.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(DefaultSettingsGerman_SpeechRecognized);
                    _recognizergerman.RecognizeAsync(RecognizeMode.Multiple);
                }
                catch (Exception ex)
                {
                    elw.WriteErrorLog(ex.ToString());
                }
            }
            else
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
        }
        public void CancelDefaultListenerSettingsEnglish()
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

       public void ActivateDefaultListenerSettingsEnglish()
        {
            if (counter < 1)
            {
                counter++;
                try
                {
                    _recognizerenglish.SetInputToDefaultAudioDevice();
                    GrammarBuilder gb = new GrammarBuilder(new Choices(File.ReadAllLines(@"commandssettings.txt")));
                    gb.Culture = new CultureInfo("en-GB");
                    Grammar g = new Grammar(gb);
                    _recognizerenglish.LoadGrammar(g);
                    _recognizerenglish.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(DefaultSettingsEnglish_SpeechRecognized);
                    _recognizerenglish.RecognizeAsync(RecognizeMode.Multiple);
                }
                catch (Exception ex)
                {
                    elw.WriteErrorLog(ex.ToString());
                }
            }
            else
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
        #endregion


    }
}
