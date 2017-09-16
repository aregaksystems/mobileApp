using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPresentation.Attributes
{
   public partial class ParameterAttribute:Attribute
    {
        #region Var
        private string ParameterName;
        #endregion
        #region Ctor
        public ParameterAttribute(string ParameterName)
        {
            this.ParameterName = ParameterName;
        }
        #endregion
        #region Prop
        public string value
        {
            get { return this.ParameterName; }
        }
        #endregion
        #region Func
        
        #endregion
    }
}
