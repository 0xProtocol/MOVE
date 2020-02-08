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

        int currentlist;
        string listname = "item";
        List<string> items1 = new List<string>();

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

            timer.Interval = 100000;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
