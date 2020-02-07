using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MOVE.Shared
{
    public partial class Help : Form
    {
        int counter = 0;
        string line;

        public Help()
        {
            InitializeComponent();
        }

        private void Helpbox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected override bool ShowWithoutActivation
        {
            get
            {
                return true;
            }
        }
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
        Timer timer = new Timer();

        private void Help_Load(object sender, EventArgs e)
        {

            timer.Interval = 10000;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
