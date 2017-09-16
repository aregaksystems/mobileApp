using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using AppPresentation.Attributes;
using AppLogger;

namespace AppPresentation.Extensions
{
  public static  class SqlDBTypeExtension
    {
      public static SqlDbType getSqlDbType(this Enum Extension,Enum SqlDbTypeValue)
      {
          try
          {
              SqlDbType? ReturnedValue=null;
              Type type = SqlDbTypeValue.GetType();
              FieldInfo fieledinfo = type.GetField(SqlDbTypeValue.ToString());
              SqlDataTypeAttribute[] SqlDBTypeArr = fieledinfo.GetCustomAttributes(typeof(SqlDataTypeAttribute), false) as SqlDataTypeAttribute[];
              if (SqlDBTypeArr.Length>0)
              {
                  ReturnedValue = SqlDBTypeArr[0].SqlDbType;
              }
              return ReturnedValue??0;

          }
          catch (Exception ex)
          {
                AppLogerClient appLog = new AppLogerClient(new AppLogger<object>());
                appLog.AppLoggining(LogingOptions.Options.Error, ex.Message, ex);
                return 0;
            }
      }
    }
}
