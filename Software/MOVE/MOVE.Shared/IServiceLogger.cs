using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOVE.Shared
{
   public interface IServiceLogger
    {
        #region Interfaces
        void LogServiceinformation(string message);
        void LogRequestInformation(string message);
    }
}
#endregion