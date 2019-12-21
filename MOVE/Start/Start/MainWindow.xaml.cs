using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MOVE.Client.Debug.Formular;
using MOVE.Server.Debug.Formular;
using System.Speech;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Threading;
using System.Configuration;
using MOVE.AudioLayer;

namespace Start
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SpeechRecognitionEngine _recognizer = new SpeechRecognitionEngine();
        SpeechRecognitionEngine startlistening = new SpeechRecognitionEngine();
        SpeechSynthesizer com = new SpeechSynthesizer();
        Settings s = new Settings();
        SpeechControl si = new SpeechControl();
        public MainWindow()
        {
            InitializeComponent();
            si.DefaultListener();
        }

        
        //   string row;
        //  string[] splitted;
        //  string splittedrow;
        //   int wertx = 555;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Info wininfo = new Info();
            wininfo.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ClientForms cf = new ClientForms();
            cf.Show();
            ServerForms sf = new ServerForms();
            sf.Show();
        }

        private void Window_FocusableChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
        }

        private void ButtonÜbung_Click(object sender, RoutedEventArgs e)
        {
            SinglePlayerForms spf = new SinglePlayerForms();
            spf.Show();
            /*/ Load();
             if(splitted[0]=="Einfach")
             {
                 MessageBox.Show("Einfach");
             }
             if (splitted[0] == "Mittel")
             {
                 MessageBox.Show("Mittel");
             }
             if (splitted[0] == "Schwer")
             {
                 MessageBox.Show("Schwer");
             }
             if(splitted[0] == "none"|| splittedrow == "")
             {
                 MessageBox.Show("none");
             }
             /*/

        }
        

        private void ButtonSettings_Click(object sender, RoutedEventArgs e)
        {
            Settings winsettings = new Settings();
            winsettings.Show();
        }

        private void Img_background_Loaded(object sender, RoutedEventArgs e)
        {

        }


        private void _recognizer_SpeechRecognized(object sender, SpeechDetectedEventArgs e)
        {

        }

        private void Window_Activated(object sender, EventArgs e)
        {
            si.ActivateDefaultListener();
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            si.CancelDefaultListener();
        }
    }
}
