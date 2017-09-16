using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace AppPresentation.Attributes
{
   public partial class SqlDataTypeAttribute:Attribute
    {
        #region Var
        private SqlDbType _SqlDbType;
        #endregion
        #region Ctor
        public SqlDataTypeAttribute(SqlDbType _SqlDbType)
        {
            this._SqlDbType = _SqlDbType;
        }
        #endregion
        #region Prop
        public SqlDbType SqlDbType
        {
            get { return _SqlDbType; }
        }
        #endregion
        #region Func
        
        #endregion
    }
}
