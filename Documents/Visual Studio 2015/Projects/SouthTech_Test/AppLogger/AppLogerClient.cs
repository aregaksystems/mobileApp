using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogger
{
   public partial class AppLogerClient
    {
        #region vars
       private readonly IAppLogger ILog;
        #endregion
       
        #region ctor
        public AppLogerClient(IAppLogger _ILog)
        {
            this.ILog = _ILog;
        }
        #endregion
        #region Func
        #region AppLogging
        public void AppLoggining(LogingOptions.Options options,string message,Exception ex)
        {
            ILog.AppLoging(options, message, ex);
        }
        #endregion
        #endregion
    }
}
