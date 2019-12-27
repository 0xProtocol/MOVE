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
        #region Klasseninstanzvariablen
        IServiceLogger _serviceLogger;
        ErrorLogWriter elw = new ErrorLogWriter();
        #endregion
        #region Variablen
        public string _request;
        #endregion
        #region Konstruktor
        public MOVERequestHandler(string request, IServiceLogger servicelogger)
        {
            _request = request;
            _serviceLogger = servicelogger;
        }
        #endregion
        #region Methoden
        public string PerformAction()
        {
            string commandLine = GetCommandLine(_request);
            string[] tmp = commandLine.Split('|');
            string command = tmp[0].ToLower();
            string[] param = null;

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
                }
                return "0";
            }
            catch (Exception ex)
            {
                elw.WriteErrorLog(ex.ToString());
                return "0";
            }
        }

        private static string GetCommandLine(string request)
        {
            string[] seperator = { "move:\\" };
            string[] tmp = request.Split(seperator, StringSplitOptions.RemoveEmptyEntries);
            return tmp[0];
        }
    }
}
#endregion
