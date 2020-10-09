using Microsoft.Extensions.Configuration;
using System;

namespace Assignment.Common
{
    /// <summary>
    /// Helper class for db connection string.
    /// </summary>
    public static class ConnectionStringConnectionHelper
    {
        private static string _connectionString;
        /// <summary>
        /// Get db connection string.
        /// </summary>
        /// <param name="configuration">Configuration.</param>
        /// <returns>Returns connection string.</returns>
        public static string GetConnectionString(IConfiguration configuration)
        {
            if (string.IsNullOrWhiteSpace(_connectionString))
            {
                _connectionString = configuration.GetConnectionString(CommonConstants.SqlConnectionString);
            }
            return _connectionString;
        }
    }
}
