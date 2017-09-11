using System;
using System.Reflection;
using System.Web.Http;
using log4net;
using log4net.Config;

namespace ClcWorld.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        protected void Application_Start()
        {
            Log.Error("Application_Start.");
            //Configure Log4net.
            XmlConfigurator.Configure();
        }
        /// <summary>
        /// Fired when an application unhandled error occurs.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_Error(object sender, EventArgs e)
        {
            var ex = Server.GetLastError();

            if (ex == null)
            {
                Log.Error("Application_Error: null last error.");
            }
            else
            {
                try
                {
                    var innerException = ex.InnerException ?? ex;
                    Log.Error($"Application_Error: {innerException}");
                }
                catch
                {
                    // ignored
                }
            }
        }

        /// <summary>
        /// Fired when the application end s.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_End(object sender, EventArgs e)
        {
            Log.Info("Application ended.");
        }
    }
}
