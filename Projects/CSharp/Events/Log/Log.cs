using System;
using System.IO;

namespace Log
{
    public class Log
    {
        private string path = @" D:\";
        private System.IO.StreamWriter sw_error;
        private System.IO.StreamWriter sw_succes;
        private static Log log = null;
       
        public static Log GetTheLog()
        {
           return MyInternalClass._log;
        }
        private class MyInternalClass
        {
            internal readonly  static Log _log = new Log();//se indeplineste o singura data pentru membrii statici
            static MyInternalClass() { }

        }
        private Log()
        {
            System.IO.FileStream fs__error = new System.IO.FileStream(System.IO.Path.Combine(path, "log_Error.txt"), FileMode.Append);

            sw_error = new System.IO.StreamWriter(fs__error);

            System.IO.FileStream fs__succes = new System.IO.FileStream(System.IO.Path.Combine(path, "log_Succes.txt"), FileMode.Append);

            sw_succes = new System.IO.StreamWriter(fs__succes);

        }
        public string Path
        {
            get { return path; }
        }
        public void WriteError(string text)
        {
            sw_error.WriteLine(DateTime.Now.ToString("yyyy.MM.dd hh:mm:ss:fff ") + " " + text);
            sw_error.Flush();

        }
        public void WriteSucces(string text)
        {
            sw_succes.WriteLine(DateTime.Now.ToString("yyyy.MM.dd hh:mm:ss:fff ") + " " + text);
            sw_succes.Flush();

        }
    }
}
