using System;

namespace Assignment.Common
{
    /// <summary>
    /// Helper class.
    /// </summary>
    public static class CommonHelper
    {
        /// <summary>
        /// Get log file path.
        /// </summary>
        /// <returns>Returns log file path.</returns>
        public static string GetLogFilePath()
        {
            return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, CommonConstants.LogFile);
        }
    }
}
