using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
namespace AppLogger
{
    public partial class AppLogger<T>   : IAppLogger where T:class
    {
        #region vars
        private readonly ILog loger = LogManager.GetLogger(typeof(T));
        #endregion
        #region func
        #region AppLoging
      /// <summary>
      /// log incedant accore through the runtime
      /// </summary>
      /// <param name="options">debug,fatal,error</param>
      /// <param name="message">incedant message</param>
      /// <param name="ex">exception paramters</param>

     public void AppLoging(LogingOptions.Options options, string message, Exception ex)
        {
            switch (options)
            {
                case LogingOptions.Options.Debuge:
                    loger.Debug(message, ex);
                    break;
                case LogingOptions.Options.Error:
                    loger.Error(message, ex);
                    break;
                case LogingOptions.Options.Fatal:
                    loger.Fatal(message, ex);
                    break;
                case LogingOptions.Options.Info:
                    loger.Info(message, ex);
                    break;
                case LogingOptions.Options.Warn:
                    loger.Warn(message, ex);
                    break;
                default:
                    break;
            }
        } 
        #endregion
        #endregion
    }
}
