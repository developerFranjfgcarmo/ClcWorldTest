using System.IO;
using System.Reflection;
using log4net;

namespace ClcWorld.WebApi
{
    /// <summary>
    ///     Application configuration
    /// </summary>
    public static class AppConfig
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        ///     Configure
        /// </summary>
        public static void Configure()
        {
            Log.Info("Configure Application setting");
            Directory.CreateDirectory(Config.Config.AppBasePath);
            Directory.CreateDirectory(Config.Config.LogsPath);
        }
    }
}