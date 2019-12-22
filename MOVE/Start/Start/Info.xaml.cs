using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        SpeechRecognitionEngine _recognizerinfo = new SpeechRecognitionEngine();
        public Info()
        {
            InitializeComponent();
            DefaultListenerInfo();
            this.Focus();
        }

        public void DefaultListenerInfo()
        {
            _recognizerinfo.SetInputToDefaultAudioDevice();
            _recognizerinfo.LoadGrammarAsync(new Grammar(new GrammarBuilder(new Choices(File.ReadAllLines(@"DefaultSettings.txt")))));
            _recognizerinfo.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(DefaultInfo_SpeechRecognized);
            _recognizerinfo.SpeechDetected += new EventHandler<SpeechDetectedEventArgs>(_recognizerInfo_SpeechRecognized);
            _recognizerinfo.RecognizeAsync(RecognizeMode.Multiple);
        }


        private void _recognizerInfo_SpeechRecognized(object sender, SpeechDetectedEventArgs e)
        {
        }

        private void DefaultInfo_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {

            string speech = e.Result.Text;
            if (speech == "exit")
            {
                CloseWindow();
            }
        }

        public void CloseWindow()
        {
            this.Close();
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
        private void Window_Activated(object sender, EventArgs e)
        {
            ActivateDefaultListenerInfo();
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            CancelDefaultListenerInfo();
        }
    }
}
