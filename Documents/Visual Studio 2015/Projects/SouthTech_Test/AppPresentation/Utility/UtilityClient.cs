using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLogger;
namespace AppPresentation.Utility
{
  public partial class UtilityClient
    {
        #region var
        IUtility IUtility;
        #endregion
        #region Ctor
        public UtilityClient(IUtility IUtility)
        {
            this.IUtility = IUtility;
        }
        #endregion
        #region Func
        public string JsonToXml(string JSON)
        {
            try
            {
                return IUtility.JsonToXML(JSON);
            }
            catch (Exception ex)
            {

                AppLogerClient appLog = new AppLogerClient(new AppLogger<UtilityClient>());
                appLog.AppLoggining(LogingOptions.Options.Error, ex.Message, ex);
                return null;
            }
        }
        #endregion
    }
}
