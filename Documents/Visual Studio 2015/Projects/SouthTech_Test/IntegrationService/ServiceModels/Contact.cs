using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace IntegrationService.ServiceModels
{
    [DataContract]
    public class Contact
    {

        [DataMember]
        public int fld_Contact_ID
        {
            get;
            set;
        }

        [DataMember]
        public string fld_Contact_Name
        {
            get;
            set;
        }

        [DataMember]
        public int? fld_Group_ID { get; set; }
        [DataMember]
        public List<ContactPhone> PhonesList { get; set; }
    }
}