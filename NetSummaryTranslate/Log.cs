using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
namespace NetCore.zh_hans
{
    public class Log
    {
        TextBox UILog { get; set; }
        public Log()
        {

        }

        public Log(TextBox UILog)
        {
            this.UILog = UILog;
        }

        public void Logging(string logstring)
        {
            string loginfo = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:") + logstring + System.Environment.NewLine;
            lock (typeof(Log))
            {
                File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + DateTime.Now.ToString("yyyy-MM-dd") + " Log.txt", loginfo);
            }
            if (UILog != null)
            {
                UILog.Parent.Invoke((MethodInvoker)(() =>
                {
                    UILog.Text += loginfo;
                    UILog.Focus();
                    UILog.Select(UILog.Text.Length, 0);
                    UILog.ScrollToCaret();                    
                }));
            }
        }
    }
}
