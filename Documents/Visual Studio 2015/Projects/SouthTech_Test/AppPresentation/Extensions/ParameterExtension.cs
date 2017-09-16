using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using AppPresentation.Attributes;
using AppLogger;

namespace AppPresentation.Extensions
{
   public static class ParameterExtension
    {
       public static string getParameterValue(this string Param, Enum ParameterValue)
       {
           try
           {
               string ReturnedValue = string.Empty;
               Type InfoType = ParameterValue.GetType();
               FieldInfo fieldInfo = InfoType.GetField(ParameterValue.ToString());
               ParameterAttribute[] parmArray = fieldInfo.GetCustomAttributes(typeof(ParameterAttribute), false) as ParameterAttribute[];
               if (parmArray.Length>0)
               {
                   ReturnedValue = parmArray[0].value;
               }
               return ReturnedValue;
           }
           catch (Exception ex)
           {
                AppLogerClient appLog = new AppLogerClient(new AppLogger<object>());
                appLog.AppLoggining(LogingOptions.Options.Error, ex.Message, ex);
                return null;
            }
       }
    }
}
