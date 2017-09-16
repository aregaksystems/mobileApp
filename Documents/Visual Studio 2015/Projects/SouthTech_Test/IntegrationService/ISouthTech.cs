using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using IntegrationService.ServiceModels;
using AppPresentation.Procedures;
namespace IntegrationService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ISouthTech
    {

        [OperationContract]
        Contact ContactTransaction(Dictionary<object, object> Param);

        [OperationContract]
        IEnumerable<Contact> GetAllContact();

        [OperationContract]
        Contact GetContactByID(int Id);
        [OperationContract]
        IEnumerable<Group> GetAllGroup();


        
    }


   
}
