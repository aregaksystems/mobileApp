using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using AppPresentation.Procedures;
using IntegrationService.ServiceModels;
using AppPresentation.RepositoryHandler;
using AppLogger;
using SouthTech_DAL;
using AppRepository;
namespace IntegrationService
{
   
    public class SouthTech : ISouthTech
    {
        #region Func
        public Contact ContactTransaction( Dictionary<object, object> Param)
        {
            Contact cont = new Contact();
            List<ContactPhone> phone = new List<ContactPhone>();
            Dictionary<Enum, object> dicParam = new Dictionary<Enum, object>();
            try
            {
                foreach (var item in Param)
                {
                    dicParam.Add((_Sp_contactTransactions.Sp_contactTransactions)Enum.Parse(typeof(_Sp_contactTransactions.Sp_contactTransactions),item.Key.ToString()), item.Value);
                }
                using (SouthTechEntities context=new SouthTechEntities())
                {
                    RepositoryController<Tbl_Contact> handler = new RepositoryController<Tbl_Contact>(new Repository<Tbl_Contact>(context));
                  List <Tbl_Contact> contact=   handler.ExecuteQuery(ExecProcedures.Procedures.sp_contactTransactions, dicParam);
                    cont.fld_Contact_ID = contact[0].fld_Contact_ID;
                    cont.fld_Contact_Name = contact[0].fld_Contact_Name;
                    cont.fld_Group_ID = contact[0].fld_Group_ID;
                    foreach (var item in contact[0].Tbl_PhoneContact.ToList())
                    {
                        phone.Add(new ContactPhone() { fld_Phone_ID = item.fld_Phone_ID, fld_Contact_ID = item.fld_Contact_ID, fld_Phone_Number = item.fld_Phone_Number });
                    }
                    cont.PhonesList = phone;
                    return cont;
                }
            }
            catch (Exception ex)
            {

                AppLogerClient appLog = new AppLogerClient(new AppLogger<SouthTech>());
                appLog.AppLoggining(LogingOptions.Options.Error, ex.Message, ex);
                return null;
            }
        }

        public IEnumerable<Contact> GetAllContact()
        {
            List<Contact> lcontact = new List<Contact>();
            try
            {
                using (SouthTechEntities context=new SouthTechEntities())
                {
                    RepositoryController<Tbl_Contact> handler = new RepositoryController<Tbl_Contact>(new Repository<Tbl_Contact>(context));
                    List<Tbl_Contact> contact = handler.GetAll().ToList();
                    foreach (var item in contact)
                    {
                        lcontact.Add(new Contact() { fld_Contact_ID = item.fld_Contact_ID, fld_Contact_Name = item.fld_Contact_Name, fld_Group_ID = item.fld_Group_ID });
                    }

                }
                return lcontact.AsEnumerable();
            }
            catch (Exception ex)
            {

                AppLogerClient appLog = new AppLogerClient(new AppLogger<SouthTech>());
                appLog.AppLoggining(LogingOptions.Options.Error, ex.Message, ex);
                return null;
            }
        }

        public IEnumerable<Group> GetAllGroup()
        {
            List<Group> lgroup = new List<Group>();
            try
            {
                using (SouthTechEntities context = new SouthTechEntities())
                {
                    RepositoryController<Tbl_Group> handler = new RepositoryController<Tbl_Group>(new Repository<Tbl_Group>(context));
                    List<Tbl_Group> group = handler.GetAll().ToList();
                    foreach (var item in group)
                    {
                        lgroup.Add(new Group() { fld_Group_ID=item.fld_Group_ID,fld_Group_Title=item.fld_Group_Title });
                    }

                }
                return lgroup.AsEnumerable();
            }
            catch (Exception ex)
            {

                AppLogerClient appLog = new AppLogerClient(new AppLogger<SouthTech>());
                appLog.AppLoggining(LogingOptions.Options.Error, ex.Message, ex);
                return null;
            }
        }

        public Contact GetContactByID(int Id)
        {
            Contact cont = new Contact();
            List<ContactPhone> phone = new List<ContactPhone>();
            try
            {
                    using (SouthTechEntities context = new SouthTechEntities())
                    {
                        RepositoryController<Tbl_Contact> handler = new RepositoryController<Tbl_Contact>(new Repository<Tbl_Contact>(context));
                        Tbl_Contact contact = handler.GetByID(Id);
                        cont.fld_Contact_ID = contact.fld_Contact_ID;
                        cont.fld_Contact_Name = contact.fld_Contact_Name;
                        cont.fld_Group_ID = contact.fld_Group_ID;
                        foreach (var item in contact.Tbl_PhoneContact.ToList())
                        {
                            phone.Add(new ContactPhone() { fld_Phone_ID = item.fld_Phone_ID, fld_Contact_ID = item.fld_Contact_ID, fld_Phone_Number = item.fld_Phone_Number });
                        }
                        cont.PhonesList = phone;
                        return cont;
                    }   
            }
            catch (Exception ex)
            {
                AppLogerClient appLog = new AppLogerClient(new AppLogger<SouthTech>());
                appLog.AppLoggining(LogingOptions.Options.Error, ex.Message, ex);
                return null;
            }
        } 
        #endregion
    }
}
