using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace IntegrationService.ServiceModels
{
    [DataContract]
    public class Group
    {
        [DataMember]
        public int fld_Group_ID { get; set; }
        [DataMember]
        public string fld_Group_Title { get; set; }
    }
}