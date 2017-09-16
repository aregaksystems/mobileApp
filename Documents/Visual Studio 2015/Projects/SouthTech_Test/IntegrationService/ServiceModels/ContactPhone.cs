using System.Runtime.Serialization;

namespace IntegrationService.ServiceModels
{
    [DataContract]
    public class ContactPhone
    {
        [DataMember]
        public int fld_Phone_ID { get; set; }
        [DataMember]
        public string fld_Phone_Number { get; set; }
        [DataMember]
        public int? fld_Contact_ID { get; set; }
    }
}