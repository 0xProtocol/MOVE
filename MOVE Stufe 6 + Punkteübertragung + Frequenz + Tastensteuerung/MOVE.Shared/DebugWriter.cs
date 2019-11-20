using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOVE.Shared
{
   public class DebugWriter
    {

        public void SendDebug(string text)
        { 
            StreamWriter writer = new StreamWriter("DebugLogSend.txt",true);

            writer.WriteLine(text);
            writer.Close();
        }

        public void ReceiveDebug(string text)
        {
            StreamWriter writer = new StreamWriter("DebugLogReceive.txt",true);

            writer.WriteLine(text);
            writer.Close();
        }

        public void PaddleThread(string text)
        {
            StreamWriter writer = new StreamWriter("DebugLogPaddleThread.txt", true);

            writer.WriteLine(text);
            writer.Close();
        }
        public void BallThread(string text)
        {
            StreamWriter writer = new StreamWriter("DebugLogBallThread.txt", true);

            writer.WriteLine(text);
            writer.Close();
        }
        public void PaintMethod (string text)
        {
            StreamWriter writer = new StreamWriter("DebugLogPaint.txt", true);

            writer.WriteLine(text);
            writer.Close();
        }
    }
}
