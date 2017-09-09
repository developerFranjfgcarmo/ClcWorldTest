using System.Configuration;
using System.IO;

namespace ClcWorld.Config
{
    /// <summary>
    /// Application setting
    /// </summary>
    public static class Config
    {
        private static readonly string _defaultAppBasePath = @"C:\ClcWorld\";

        public static string AppBasePath
        {
            get
            {
                var path = ConfigurationManager.AppSettings["ClcWorld:AppBasePath"];
                return path ?? _defaultAppBasePath;
            }
        }
        private static readonly string _defaultLogsPath = @"logs\";

        public static string LogsPath
        {
            get
            {
                var logsFolder = ConfigurationManager.AppSettings["ClcWorld:Logs"];
                return Path.Combine(AppBasePath,logsFolder??_defaultLogsPath);
            }
        }
    }
}