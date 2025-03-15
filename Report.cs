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

        //Clear the logfile if 7 days
        public static void ClearOldLogs(string logfilepath, int daysThreshold)
        {
            try
            {
                if (File.Exists(logfilepath))
                {
                    DateTime lastModified = File.GetLastWriteTime(logfilepath);
                    if ((DateTime.Now - lastModified).TotalDays >= daysThreshold)
                    {
                        File.WriteAllText(logfilepath, ""); // Clear the log file
                    }
                }
            }
            catch (Exception ex)
            {
                // If there's an issue clearing the file, log it in the same file
                using (StreamWriter writer = new StreamWriter(logfilepath, true))
                {
                    string errorEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - ERROR - Failed to clear log file: {ex.Message}";
                    writer.WriteLine(errorEntry);
                }
            }
        }

    }
}
