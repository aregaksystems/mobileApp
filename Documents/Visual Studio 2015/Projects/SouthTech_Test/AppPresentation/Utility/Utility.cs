using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using AppLogger;
using System.Web.Script.Serialization;
using System.Xml;
using Newtonsoft.Json;
using System.IO;

namespace AppPresentation.Utility
{
    public class Utility : IUtility
    {
        #region func
        public string JsonToXML(string JSON)
        {
            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                XmlDocument doc = (XmlDocument)JsonConvert.DeserializeXmlNode("{\"Phone\":" + JSON + "}", "root");
                
                using (var stringWriter = new StringWriter())
                using (var xmlTextWriter = XmlWriter.Create(stringWriter))
                {
                    doc.WriteTo(xmlTextWriter);
                    xmlTextWriter.Flush();
                    return stringWriter.GetStringBuilder().ToString();
                }
            }
            catch (Exception ex)
            {

                AppLogerClient appLog = new AppLogerClient(new AppLogger<Utility>());
                appLog.AppLoggining(LogingOptions.Options.Error, ex.Message, ex);
                return null;
            }
        } 
        #endregion
    }
}
