using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppPresentation.Attributes;
namespace AppPresentation.Procedures
{
    public partial class _Sp_contactTransactions
    {
        public enum Sp_contactTransactions
        {
            [Parameter("@fld_Contact_Name")]
            [SqlDataType(System.Data.SqlDbType.NVarChar)]
            fld_Contact_Name,
            [Parameter("@fld_Group_ID")]
            [SqlDataType(System.Data.SqlDbType.Int)]
            fld_Group_ID,
            [Parameter("@fld_Contact_ID")]
            [SqlDataType(System.Data.SqlDbType.Int)]
            fld_Contact_ID,
            [Parameter("@xmlPhone")]
            [SqlDataType(System.Data.SqlDbType.VarChar)]
            xmlPhone
        }
    }
}