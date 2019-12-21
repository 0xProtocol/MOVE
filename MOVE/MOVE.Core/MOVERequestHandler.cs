using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MOVE.Shared;

namespace MOVE.Core
{
   public class MOVERequestHandler
    {
        public string _request;
        IServiceLogger _serviceLogger;

        public MOVERequestHandler(string request, IServiceLogger servicelogger)
        {
            _request = request;
            _serviceLogger = servicelogger;
        }

        public string PerformAction()
        {
            string commandLine = GetCommandLine(_request);
            string[] tmp = commandLine.Split('|');
            string command = tmp[0].ToLower();
            string[] param = null;
            string ret;

            if (tmp.Length > 1)
            {
                param = tmp[1].Split(',');
            }

            try
            {
                switch (command)
                {
                    case "lb":
                        return tmp[1] + "|" + tmp[2] + "|" + tmp[3] + "|" + tmp[4] + "|" + tmp[5];
                    case "l":
                        return "l"+ "|" + tmp[1];
                    case "b":
                        return tmp[1] + "|" + tmp[2] + "|" + tmp[3] + "|" + tmp[4] + "|" + tmp[5];
                }
                return "0";
            }
            catch (Exception ex)
            {
                FileStream fs = new FileStream("ErrorLog.txt", FileMode.Open);
                StreamWriter writer = new StreamWriter(fs);

                writer.WriteLine("Message :" + ex.Message + "<br/>" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
                    "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
                writer.Close();
                return "0";
            }
        }

        private static string GetCommandLine(string request)
        {
            string[] seperator = { ":\\" };
            string[] tmp = request.Split(seperator, StringSplitOptions.RemoveEmptyEntries);
            return tmp[0];
        }
    }
}
