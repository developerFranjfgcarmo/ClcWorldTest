using System;
using System.Reflection;
using System.Threading.Tasks;
using ClcWorld.Entities.Context;
using log4net;

namespace ClcWorld.Service
{
    public class ServiceBase:IDisposable
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public IClcWorldContext ClcWorldContext { get; set; }

        protected ServiceBase(IClcWorldContext clcWorldContext)
        {
            ClcWorldContext = clcWorldContext;
            clcWorldContext.Database.Log = s => Log.Debug(s);
        }

        protected internal bool Save()
        {
            return (ClcWorldContext as ClcWorldContext).SaveChanges() > 0;
        }

        protected internal async Task<bool> SaveAsync()
        {
            return await (ClcWorldContext as ClcWorldContext).SaveChangesAsync() > 0;
        }

        #region [Dispose]
        ~ServiceBase()
        {
            // Finalizer calls Dispose(false)
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(false);
        }

        public virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                ClcWorldContext.Dispose();
            }
        }
        #endregion
    }
}
