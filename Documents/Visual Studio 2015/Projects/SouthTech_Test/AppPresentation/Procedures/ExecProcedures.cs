using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppPresentation.Attributes;
namespace AppPresentation.Procedures
{
    public partial class ExecProcedures
    {
        public enum Procedures
        {
            [Parameter("exec sp_contactTransactions @fld_Contact_Name,@fld_Group_ID,@fld_Contact_ID,@xmlPhone ")]
            sp_contactTransactions,
        }
    }
}