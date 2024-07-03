using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemTrayApp.src
{
    public class LogWriter : TextWriter
    {
        private readonly string _logFilePath;

        public LogWriter(string logFilePath)
        {
            _logFilePath = logFilePath;
        }

        public override void Write(string message)
        {
            using (StreamWriter writer = File.AppendText(_logFilePath))
            {
                writer.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}");
            }
        }

        public override Encoding Encoding => Encoding.UTF8; 
    }
}
