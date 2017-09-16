using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SouthTech_Test.Models
{
    public partial class Contact
    {
        
        public int fld_Contact_ID
        {
            get;
            set;
        }

        
        public string fld_Contact_Name
        {
            get;
            set;
        }

        
        public int? fld_Group_ID { get; set; }
        
        public string PhonesList { get; set; }
    }
}