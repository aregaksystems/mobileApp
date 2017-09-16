using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using AppPresentation.Procedures;
namespace IntegrationService.ServiceModels
{
    [DataContract]
    public class ProcedureParam
    {
        [DataMember]
        public _Sp_contactTransactions.Sp_contactTransactions  param { get; set; }
    }

}