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
using MOVE.Shared;
using System.Windows.Threading;

namespace Start
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Klasseninstanzierungen
        SpeechSynthesizer com = new SpeechSynthesizer();
        SpeechControl si = new SpeechControl();
        Settings s = new Settings();
        ErrorLogWriter elw = new ErrorLogWriter();
        #endregion
        #region Variablen
        int speechvalue;
        int speechmodulevalue;
        int valueTimer = 0;
        DispatcherTimer _timer;
        TimeSpan _time;
        #endregion 
        #region klassengenerierte Methoden
        public MainWindow()
        {
            InitializeComponent();

            _time = TimeSpan.FromSeconds(1);
            _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                lblTest.Content = _time.ToString("c");
                //if (_time == TimeSpan.Zero) _timer.Stop();
                _time = _time.Add(TimeSpan.FromSeconds(+1));
                if (_time.ToString("c") == "00:00:03")
                {
                    lblMenu1.Visibility = Visibility.Visible;
                    lblMenu2.Visibility = Visibility.Hidden;
                    lblMenu3.Visibility = Visibility.Hidden;
                    lblMenu4.Visibility = Visibility.Hidden;
                    lblName1.Visibility = Visibility.Visible;
                    lblName2.Visibility = Visibility.Hidden;
                    lblName3.Visibility = Visibility.Hidden;
                    lblName4.Visibility = Visibility.Hidden;

                }
                if (_time.ToString("c") == "00:00:04")
                {
                    lblMenu1.Visibility = Visibility.Hidden;
                    lblMenu2.Visibility = Visibility.Visible;
                    lblMenu3.Visibility = Visibility.Hidden;
                    lblMenu4.Visibility = Visibility.Hidden;
                    lblName1.Visibility = Visibility.Hidden;
                    lblName2.Visibility = Visibility.Visible;
                    lblName3.Visibility = Visibility.Hidden;
                    lblName4.Visibility = Visibility.Hidden;
                }
                if (_time.ToString("c") == "00:00:05")
                {
                    lblMenu1.Visibility = Visibility.Hidden;
                    lblMenu2.Visibility = Visibility.Hidden;
                    lblMenu3.Visibility = Visibility.Visible;
                    lblMenu4.Visibility = Visibility.Hidden;
                    lblName1.Visibility = Visibility.Hidden;
                    lblName2.Visibility = Visibility.Hidden;
                    lblName3.Visibility = Visibility.Visible;
                    lblName4.Visibility = Visibility.Hidden;
                }
                if (_time.ToString("c") == "00:00:06")
                {
                    lblMenu1.Visibility = Visibility.Hidden;
                    lblMenu2.Visibility = Visibility.Hidden;
                    lblMenu3.Visibility = Visibility.Hidden;
                    lblMenu4.Visibility = Visibility.Visible;
                    lblName1.Visibility = Visibility.Hidden;
                    lblName2.Visibility = Visibility.Hidden;
                    lblName3.Visibility = Visibility.Hidden;
                    lblName4.Visibility = Visibility.Visible;
                }
                if (_time.ToString("c") == "00:00:07")
                {
                    lblMenu1.Visibility = Visibility.Visible;
                    lblMenu2.Visibility = Visibility.Visible;
                    lblMenu3.Visibility = Visibility.Visible;
                    lblMenu4.Visibility = Visibility.Visible;
                    lblName1.Visibility = Visibility.Visible;
                    lblName2.Visibility = Visibility.Visible;
                    lblName3.Visibility = Visibility.Visible;
                    lblName4.Visibility = Visibility.Visible;
                    lblName5.Visibility = Visibility.Visible;
                    lblName6.Visibility = Visibility.Visible;

                }
                if (_time.ToString("c") == "00:00:08")
                {
                    lblMenu1.Visibility = Visibility.Visible;
                    lblMenu2.Visibility = Visibility.Visible;
                    lblMenu3.Visibility = Visibility.Visible;
                    lblMenu4.Visibility = Visibility.Visible;
                    lblName1.Visibility = Visibility.Visible;
                    lblName2.Visibility = Visibility.Visible;
                    lblName3.Visibility = Visibility.Visible;
                    lblName4.Visibility = Visibility.Visible;
                    lblName5.Visibility = Visibility.Visible;
                    lblName6.Visibility = Visibility.Visible;
                    lblName1.Foreground = Brushes.Turquoise;
                }
                if (_time.ToString("c") == "00:00:09")
                {
                    lblMenu1.Visibility = Visibility.Visible;
                    lblMenu2.Visibility = Visibility.Visible;
                    lblMenu3.Visibility = Visibility.Visible;
                    lblMenu4.Visibility = Visibility.Visible;
                    lblName1.Visibility = Visibility.Visible;
                    lblName2.Visibility = Visibility.Visible;
                    lblName3.Visibility = Visibility.Visible;
                    lblName4.Visibility = Visibility.Visible;
                    lblName5.Visibility = Visibility.Visible;
                    lblName6.Visibility = Visibility.Visible;
                    lblName1.Foreground = Brushes.Turquoise;
                    lblName2.Foreground = Brushes.LightGreen;
                }
                if (_time.ToString("c") == "00:00:10")
                {
                    lblMenu1.Visibility = Visibility.Visible;
                    lblMenu2.Visibility = Visibility.Visible;
                    lblMenu3.Visibility = Visibility.Visible;
                    lblMenu4.Visibility = Visibility.Visible;
                    lblName1.Visibility = Visibility.Visible;
                    lblName2.Visibility = Visibility.Visible;
                    lblName3.Visibility = Visibility.Visible;
                    lblName4.Visibility = Visibility.Visible;
                    lblName5.Visibility = Visibility.Visible;
                    lblName6.Visibility = Visibility.Visible;
                    lblName1.Foreground = Brushes.Turquoise;
                    lblName2.Foreground = Brushes.LightGreen;
                    lblName3.Foreground = Brushes.Yellow;
                }
                if (_time.ToString("c") == "00:00:11")
                {
                    lblMenu1.Visibility = Visibility.Visible;
                    lblMenu2.Visibility = Visibility.Visible;
                    lblMenu3.Visibility = Visibility.Visible;
                    lblMenu4.Visibility = Visibility.Visible;
                    lblName1.Visibility = Visibility.Visible;
                    lblName2.Visibility = Visibility.Visible;
                    lblName3.Visibility = Visibility.Visible;
                    lblName4.Visibility = Visibility.Visible;
                    lblName5.Visibility = Visibility.Visible;
                    lblName6.Visibility = Visibility.Visible;
                    lblName1.Foreground = Brushes.Turquoise;
                    lblName2.Foreground = Brushes.LightGreen;
                    lblName3.Foreground = Brushes.Yellow;
                    lblName4.Foreground = Brushes.Pink;

                }
                if (_time.ToString("c") == "00:00:12")
                {
                    lblMenu1.Visibility = Visibility.Hidden;
                    lblMenu2.Visibility = Visibility.Hidden;
                    lblMenu3.Visibility = Visibility.Hidden;
                    lblMenu4.Visibility = Visibility.Hidden;
                    lblName1.Visibility = Visibility.Hidden;
                    lblName2.Visibility = Visibility.Hidden;
                    lblName3.Visibility = Visibility.Hidden;
                    lblName4.Visibility = Visibility.Hidden;
                    lblName5.Visibility = Visibility.Hidden;
                    lblName6.Visibility = Visibility.Hidden;
                    lblName1.Foreground = Brushes.White;
                    lblName2.Foreground = Brushes.White;
                    lblName3.Foreground = Brushes.White;
                    lblName4.Foreground = Brushes.White;
                    _time = TimeSpan.FromSeconds(1);
                }

            }, Application.Current.Dispatcher);

            _timer.Start();

            try
            {
                this.MouseDown += delegate { DragMove(); };
            }
            catch (Exception ex)
            {
                elw.WriteErrorLog(ex.Message);
            }
            string language = ConfigurationManager.AppSettings["language"];
            speechvalue = Convert.ToInt32(language);
            string speechmodule = ConfigurationManager.AppSettings["speechmodule"];
            speechmodulevalue = Convert.ToInt32(speechmodule);

            if (speechmodulevalue == 1)
            {

                if (speechvalue == 0)
                {
                    si.DefaultListenerGerman();
                    DesignChangesGerman();
                }
                if (speechvalue == 1)
                {
                    si.DefaultListenerEnglish();
                    DesignChangesEnglish();
                }
            }
            else
            {
                if (speechvalue == 0)
                {
                    DesignChangesGerman();
                }
                if (speechvalue == 1)
                {
                    DesignChangesEnglish();
                }
                logolabel2.Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#515251"));
            }
            this.Focus();
        }
        #endregion
        #region Methoden

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Info wininfo = new Info();
            wininfo.Show();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ServerForms sf = new ServerForms();
            sf.Show();
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ClientForms cf = new ClientForms();
            cf.Show();
        }

        private void ButtonÜbung_Click(object sender, RoutedEventArgs e)
        {
            SinglePlayerForms spf = new SinglePlayerForms();
            spf.Show();
        }

        private void ButtonSettings_Click(object sender, RoutedEventArgs e)
        {
            Settings winsettings = new Settings();
            winsettings.Show();
        }

        private void DesignChangesGerman()
        {
            logolabel2.Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#660066"));
        }
        private void DesignChangesEnglish()
        {
            logolabel2.Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#db00cd"));
            btn_Uebung.Content = "Practice";
            btn_info.Content = "Information";
            btn_Settings.Content = "Settings";
        }
        private void Window_Activated(object sender, EventArgs e)
        {
            if (speechvalue == 0)
            {
                si.ActivateDefaultGermanListener();
            }
            else if (speechvalue == 1)
            {
                si.ActivateDefaultEnglishListener();
            }
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            if (speechvalue == 0)
            {
                si.CancelDefaultGermanListener();
            }
            else if (speechvalue == 1)
            {
                si.CancelDefaultEnglishListener();
            }
        }
        #endregion
        #region funktionslose Methoden
        private void Img_background_Loaded(object sender, RoutedEventArgs e)
        {

        }
        private void Window_FocusableChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void button_Click_3(object sender, RoutedEventArgs e)
        {

        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
<<<<<<< HEAD

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F1)
            {
                GeneralHelp gh = new GeneralHelp();
                gh.ShowDialog();
            }
        }
=======
>>>>>>> parent of 79d22c3... F1 hinzugefügt
    }
}
#endregion