using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogger
{
  public interface IAppLogger
    {
        void AppLoging(LogingOptions.Options options, string message, Exception ex = null);
        
    }
}
