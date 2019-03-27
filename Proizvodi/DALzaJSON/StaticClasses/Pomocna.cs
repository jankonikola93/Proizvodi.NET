using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALzaJSON.StaticClasses
{
    public static class Pomocna
    {
        public static void LogError(string error)
        {
            var LogApiDestination = ConfigurationManager.AppSettings["LogApiDestination"].ToString();
            StreamWriter SW;
            if (Directory.Exists(LogApiDestination))
            {
                var destination = System.IO.Path.Combine(LogApiDestination, "LogApiError_" + DateTime.Now.ToString("yyyyMMdd") + ".txt");
                if (!File.Exists(destination))
                {
                    SW = File.CreateText(destination);
                    SW.Close();
                }

                using (SW = File.AppendText(destination))
                {
                    SW.Write("\r\n\n");
                    SW.WriteLine(DateTime.Now.ToString("dd-MM-yyyy H:mm:ss") + " " + error);
                    SW.Close();
                }
            }
        }
    }
}
