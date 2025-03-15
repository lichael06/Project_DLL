using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_DLL
{
    public class Report
    {
        //Create a log file
        public static void Logit(string logfilepath, string logs)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(logfilepath, true))
                {
                    string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - INFO - {logs}";
                    writer.WriteLine(logEntry);
                }
            }
            catch (Exception ex)
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(logfilepath, true))
                    {
                        string errorEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - ERROR - Failed to write log: {ex.Message}";
                        writer.WriteLine(errorEntry);
                    }

                }
                catch
                {

                }
            }
        }
    }
}
