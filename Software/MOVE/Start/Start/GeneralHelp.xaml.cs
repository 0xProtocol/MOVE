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
<<<<<<< HEAD
            tbContent.Text = "General help for MOVE (MOdern Voice Experience):\r\n\r\n• What is MOVE?\r\n• Client/Server Mode\r\n• Practise Mode\r\n• The Sound Mode\r\n• The Frequency Mode\r\n• The Keyboard Mode\r\n• The Speech Module\r\n\r\nWhat is MOVE?:\r\n\r\nMOVE stands for MOdern Voice Experience and is a pong game that can be controlled by revolutionary input methods. This, and the fact that you can control all settings and functions with your voice, makes the main differences in comparison to conventional pong games. The network mode is an extra feature that makes our software even more extraordinary. While these functions are new, the goal of the game is still the same as with other pong games. You play a paddle that kicks a ball to the other player, which has the same task. If one player is not able to catch the ball, it is reset to the original state and the opponent earns a point. The person who has got the most points wins the game.\r\n\r\nClient/Server Mode:\r\n\r\nThis is the main main game where the player has the chance to play against an opponent throw a network connection.\r\nSettings: This Button opens the settings window that lets you tune the input options as well as the network settings. It is also possible to find new network partners.\r\nStart: This button starts a connection which leads to the waiting state, where the client should connect to the server\r\nConnect: This button connects the player to the other player, at the end a connection should be established, if all steps are correct.\r\nMove it: With this function the game starts and the paddles begin to move, the ball is going to be transmitted to the client.\r\nSound/Frequency/Keyboard: These are radio buttons that are responsible to the correct input devices. You can only choose one input devices at the time.\r\n\r\nPractise Mode:\r\nThis is a singleplayer game that gives the player the option to practice his skills without a colleague. Instead he plays the ball against some obstacles. If the ball touches an object, it disappears and the player gets a point. If all objects have disappered, they are reset to their home position.\r\n\r\nThe Sound Mode:\r\nThis option gives the player the chance to control the pong game with sounds and noise over the microphone. If he makes louder noise, the paddle will move further to the right.\r\n\r\nThe Frequency Mode:\r\nThis option is similar to the Sound Mode, but instead of singing louder, you have to sing different music notes to move the paddle.\r\n\r\nThe Keyboard Mode:\r\nThis is the classical way to control a pong game. The process is simple, because you have to tab the left arrow to move the paddle in the left position and the other way around.\r\n\r\nThe Speech Module:\r\nThis option can be (de)activated in the settings window in the MOVE Controlcenter. It gives physically limited people the chance to control the menu of our software. Throw english or german words they can literally open every function and start a game.";
            tbContent.IsReadOnly = true;
=======
>>>>>>> parent of 51d6d11... General Help implemented + design revolution
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
