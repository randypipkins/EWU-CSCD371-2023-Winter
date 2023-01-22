using System;
using System.IO;

namespace Logger
{
    public class FileLogger:BaseLogger
    {
        public string Path { get; }

        public FileLogger(string path)
        {
            Path = path;
            if(!File.Exists(path))
            {
                File.Create(path);
            }
        }

        public override void Log(LogLevel logLevel, string message)
        {
            if(!File.Exists(Path))
            {
                return;
            }
            using (StreamWriter sw = File.CreateText(Path))
            {
                sw.WriteLine($"{DateTime.Now} {ClassName} {logLevel + ":"} {message}");
            }
        }
    }
}