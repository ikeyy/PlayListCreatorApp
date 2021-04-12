
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace LoggerLibrary
{
    public class Logger
    {
        public static void Info(string content)
        {
            WriteLog("INFO", content);
        }

        public static void Error(string content)
        {
            WriteLog("ERROR", content);
        }

        protected static void WriteLog(string logtype, string content)
        {

            string filepathname = "Paymaya";
            string foldername = @"Logs\Paymaya";

            string filepath = Path.Combine(AppContext.BaseDirectory, foldername);
            filepath = Path.Combine(filepath, foldername);

            if (!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath);
            }

            string logtime = DateTime.UtcNow.AddHours(8).ToString("yyyy-MM-dd HH:mm:ss.fff");
            string filename = filepath + "/" + filepathname + "_" + DateTime.UtcNow.AddHours(8).ToString("yyyyMMdd") + ".txt";

            StreamWriter mySw = File.AppendText(filename);

            string write_content = logtime + " " + logtype + " " + content;
            mySw.WriteLine(write_content);
            mySw.Close();
        }
    }
}
