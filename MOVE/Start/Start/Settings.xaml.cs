using System;
using System.Collections.Generic;
using System.Configuration;
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
        SpeechRecognitionEngine _recognizersettings = new SpeechRecognitionEngine();
        SpeechSynthesizer com = new SpeechSynthesizer();
        public Settings()
        {
            InitializeComponent();
            DefaultListenerSettings();
            this.Focus();
        }


        public void DefaultListenerSettings()
        {
            _recognizersettings.SetInputToDefaultAudioDevice();
            _recognizersettings.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines(@"commandssettings.txt")))));
            _recognizersettings.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(DefaultInfo_SpeechRecognized);
            _recognizersettings.RecognizeAsync(RecognizeMode.Multiple);
        }

        private void DefaultInfo_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
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
            if (speech == "exit")
            {
                CloseWindow();
            }
        }

        private void CloseWindow()
        {
            this.Close();
        }
        private void Save()
        {
            RadioButtonIsChecked();
            RadioButtonIsChecked2();
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

        public void RadioButtonIsChecked()
        {
            if (rb_einfach.IsChecked == true)
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["empfindlichkeit"].Value = "1";
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            if (rb_mittel.IsChecked == true)
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["empfindlichkeit"].Value = "2";
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            if (rb_schwer.IsChecked == true)
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["empfindlichkeit"].Value = "3";
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
        }
        public void RadioButtonIsChecked2()
        {
            if (rb_modell1.IsChecked == true)
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["glättung"].Value = "1";
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            if (rb_modell2.IsChecked == true)
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["glättung"].Value = "2";
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
            if (rb_modell3.IsChecked == true)
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["glättung"].Value = "3";
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RadioButtonIsChecked();
            RadioButtonIsChecked2();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {

        }
        public void CancelDefaultListenerSettings()
        {
            try
            {
                _recognizersettings.RecognizeAsyncStop();
            }
            catch (Exception ex)
            {

            }
        }

        public void ActivateDefaultListenerSettings()
        {
            try
            {
                _recognizersettings.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception ex)
            {

            }
        }
        private void Window_Activated(object sender, EventArgs e)
        {
            ActivateDefaultListenerSettings();
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            CancelDefaultListenerSettings();
        }
    }
}
