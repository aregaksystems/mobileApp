using SouthTech_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SouthTech_Test.SouthTechService;
using AppLogger;
using AppPresentation.Procedures;
using AppPresentation.Utility;
namespace SouthTech_Test.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index(int Added = 0)
        {
            switch (Added)
            {
                case 1:
                    ViewBag.SuccessOpt = 1;
                    break;
                case -1:
                    ViewBag.SuccessOpt = -1;
                    break;
             
                default:
                    ViewBag.SuccessOpt = 0;
                    break;
            }
            ViewBag.ContactModel = null;
            return View(getAllContact());
        }

        [HttpGet]
        public ActionResult getContact(int id)
        {
            try
            {
                ViewBag.ContactModel = getContactById(id);
                return View("Index", getAllContact());
            }
            catch (Exception ex)
            {

                AppLogerClient appLog = new AppLogerClient(new AppLogger<ContactController>());
                appLog.AppLoggining(LogingOptions.Options.Error, ex.Message, ex);
                return RedirectToAction("Index", new { Added = -1 });
            }
        }



        [HttpPost]
        public ActionResult AddContact(Models.Contact model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var contact = QueryTransaction(model);
                    if (contact != null)
                    {
                        return RedirectToAction("Index", new { Added = 1 });
                    }
                    else
                    {
                        throw new Exception();
                    }
                    
                }
                return RedirectToAction("Index","Contact", new { Added = -1 });

            }
            catch (Exception ex)
            {
                AppLogerClient appLog = new AppLogerClient(new AppLogger<ContactController>());
                appLog.AppLoggining(LogingOptions.Options.Error, ex.Message, ex);
                return RedirectToAction("Index", new { Added = -1 });
            }
        }
        [NonAction]
        protected List<SouthTechService.Contact> getAllContact()
        {
            try
            {
                SouthTechClient client = new SouthTechClient();
                List<SouthTechService.Contact> lcontact = client.GetAllContact().ToList();
                return lcontact;
            }
            catch (Exception ex)
            {
                AppLogerClient appLog = new AppLogerClient(new AppLogger<ContactController>());
                appLog.AppLoggining(LogingOptions.Options.Error, ex.Message, ex);
                return null;
            }
        }
        [NonAction]
        protected SouthTechService.Contact getContactById(int Id)
        {
            try
            {
                SouthTechClient client = new SouthTechClient();
                SouthTechService.Contact lcontact = client.GetContactByID(Id);
                return lcontact;
            }
            catch (Exception ex)
            {
                AppLogerClient appLog = new AppLogerClient(new AppLogger<ContactController>());
                appLog.AppLoggining(LogingOptions.Options.Error, ex.Message, ex);
                return null;
            }
        }
        [NonAction]
        protected SouthTechService.Contact QueryTransaction(Models.Contact model)
        {
            Dictionary<object, object> dicSqlParam = new Dictionary<object, object>();
            UtilityClient utilityClient = new UtilityClient(new Utility());
            try
            {

                dicSqlParam.Add(Enum.GetName(typeof(_Sp_contactTransactions.Sp_contactTransactions), _Sp_contactTransactions.Sp_contactTransactions.fld_Contact_ID), model.fld_Contact_ID==0?(int?)null: model.fld_Contact_ID);
                dicSqlParam.Add(Enum.GetName(typeof(_Sp_contactTransactions.Sp_contactTransactions), _Sp_contactTransactions.Sp_contactTransactions.fld_Contact_Name), model.fld_Contact_Name);
                dicSqlParam.Add(Enum.GetName(typeof(_Sp_contactTransactions.Sp_contactTransactions), _Sp_contactTransactions.Sp_contactTransactions.fld_Group_ID), model.fld_Group_ID);
                dicSqlParam.Add(Enum.GetName(typeof(_Sp_contactTransactions.Sp_contactTransactions), _Sp_contactTransactions.Sp_contactTransactions.xmlPhone), utilityClient.JsonToXml(model.PhonesList));
                SouthTechClient client = new SouthTechClient();
                SouthTechService.Contact contact = client.ContactTransaction(dicSqlParam);
                return contact;
            }
            catch (Exception ex)
            {
                AppLogerClient appLog = new AppLogerClient(new AppLogger<object>());
                appLog.AppLoggining(LogingOptions.Options.Error, ex.Message, ex);
                return null;
            }
        }
    }
}