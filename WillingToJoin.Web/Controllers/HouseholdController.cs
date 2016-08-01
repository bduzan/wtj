using System.Collections.Generic;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.Linq;
using System.Web.Mvc;
using WillingToJoin.Shared.Data;
using WillingToJoin.Web.Models;
using WillingToJoin.Shared.Services.Contacts;

namespace WillingToJoin.Web.Areas.CRM.Controllers
{
    public class HouseholdController : Umbraco.Web.Mvc.SurfaceController
    {
        private readonly IHouseholdService _service;
        private readonly IContactService _contactService;
        public HouseholdController(IHouseholdService service, IContactService contactService)
        {
            _service = service;
            _contactService = contactService;
        }
        // GET: CRM/Household
        public ActionResult Index()
        {
	        PopulateHouseholdStatus();
            return View();
        }

		public ActionResult Household()
		{
			PopulateHouseholdStatus();
			return View();
		}

		public void PopulateHouseholdStatus()
	    {
		    WTJContext context = new WTJContext();
		    var statuses = context.HouseholdStatuses.ToList();
		    List<SelectListItem> householdStatuses = statuses.Select(status => new SelectListItem
		    {
			    Value = status.HouseholdStatusID.ToString(), Text = status.Name
		    }).ToList();

		    ViewData["householdStatuses"] = householdStatuses;
		}

		#region Grid Actions
		public ActionResult HierarchyBinding_Contacts(int householdID, [DataSourceRequest] DataSourceRequest request)
        {
            var entities = _contactService.GetAll();
            var contactRead = entities.Where<Contact>(w => w.HouseholdID == householdID).ToDataSourceResult(request, s => new ContactViewModel
            {
                ID = s.ID,
                HouseholdID = s.HouseholdID,
                AccountID = s.AccountID,
                ImportedID = s.ImportedID,
                HouseholdImportedID = s.HouseholdImportedID,
                AccountImportedID = s.AccountImportedID,
                LastName = s.LastName,
                FirstName = s.FirstName,
                Salutation = s.Salutation,
                Name = s.Name,
                MailingStreet = s.MailingStreet,
                MailingCity = s.MailingCity,
                MailingState = s.MailingState,
                MailingPostalCode = s.MailingPostalCode,
                Phone = s.Phone,
                MobilePhone = s.MobilePhone,
                HomePhone = s.HomePhone,
                Email = s.Email,
                OwnerID = s.OwnerID,
                Npe01HomeEmail = s.HomeEmail,
                Npe01WorkEmail = s.WorkEmail,
                Npe01WorkPhone = s.WorkPhone,
                HouseholdFamilyRoleID = s.HouseholdFamilyRoleID
            });
            return Json(contactRead, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Household_Read([DataSourceRequest]DataSourceRequest request)
        {
			PopulateHouseholdStatus();
			var entities = _service.GetAll();
            var houseHoldRead = entities.ToDataSourceResult(request, s => new HouseholdViewModel
            {
                CvmFormalGreeting = s.CvmFormalGreeting,
                CvmInformalGreeting = s.CvmInformalGreeting,
                CvmReID = s.CvmReID,
                ExportedToCvm = s.ExportedToCvm,
                GroupSource = s.GroupSource,
                ID = s.ID,
                ImportedID = s.ImportedID,
                Name = s.Name,
                Note = s.Note,
                Npo02FormalGreeting = s.Npo02FormalGreeting,
                Npo02FormulaMailingAddress = s.Npo02FormulaMailingAddress,
                Npo02HouseholdEmail = s.Npo02HouseholdEmail,
                Npo02HouseholdPhone = s.Npo02HouseholdPhone,
                Npo02InformalGreeting = s.Npo02InformalGreeting,
                Npo02MailingCity = s.Npo02MailingCity,
                Npo02MailingPostalCode = s.Npo02MailingPostalCode,
                Npo02MailingState = s.Npo02MailingState,
                Npo02MailingStreet = s.Npo02MailingStreet,
                OwnerID = s.OwnerID,
				HouseholdStatusID = s.HouseholdStatusID
			});
            return Json(houseHoldRead, JsonRequestBehavior.AllowGet);
        }

        public ActionResult HouseholdNote_Read([DataSourceRequest]DataSourceRequest request)
        {
            //PopulateHouseholdStatus();
            //var entities = _service.GetAll();
            //var houseHoldRead = entities.ToDataSourceResult(request, s => new HouseholdViewModel
            //{
            //    CvmFormalGreeting = s.CvmFormalGreeting,
            //    CvmInformalGreeting = s.CvmInformalGreeting,
            //    CvmReID = s.CvmReID,
            //    ExportedToCvm = s.ExportedToCvm,
            //    GroupSource = s.GroupSource,
            //    ID = s.ID,
            //    ImportedID = s.ImportedID,
            //    Name = s.Name,
            //    Note = s.Note,
            //    Npo02FormalGreeting = s.Npo02FormalGreeting,
            //    Npo02FormulaMailingAddress = s.Npo02FormulaMailingAddress,
            //    Npo02HouseholdEmail = s.Npo02HouseholdEmail,
            //    Npo02HouseholdPhone = s.Npo02HouseholdPhone,
            //    Npo02InformalGreeting = s.Npo02InformalGreeting,
            //    Npo02MailingCity = s.Npo02MailingCity,
            //    Npo02MailingPostalCode = s.Npo02MailingPostalCode,
            //    Npo02MailingState = s.Npo02MailingState,
            //    Npo02MailingStreet = s.Npo02MailingStreet,
            //    OwnerID = s.OwnerID,
            //    HouseholdStatusID = s.HouseholdStatusID
            //});
            //return Json(houseHoldRead, JsonRequestBehavior.AllowGet);
            return null;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Household_Create([DataSourceRequest] DataSourceRequest request, HouseholdViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var firstEntites = new Household
                {

                    CvmFormalGreeting = model.CvmFormalGreeting,
                    CvmInformalGreeting = model.CvmInformalGreeting,
                    CvmReID = model.CvmReID,
                    ExportedToCvm = model.ExportedToCvm,
                    GroupSource = model.GroupSource,
                    ID = model.ID,
                    ImportedID = model.ImportedID,
                    Name = model.Name,
                    Note = model.Note,
                    Npo02FormalGreeting = model.Npo02FormalGreeting,
                    Npo02FormulaMailingAddress = model.Npo02FormulaMailingAddress,
                    Npo02HouseholdEmail = model.Npo02HouseholdEmail,
                    Npo02HouseholdPhone = model.Npo02HouseholdPhone,
                    Npo02InformalGreeting = model.Npo02InformalGreeting,
                    Npo02MailingCity = model.Npo02MailingCity,
                    Npo02MailingPostalCode = model.Npo02MailingPostalCode,
                    Npo02MailingState = model.Npo02MailingState,
                    Npo02MailingStreet = model.Npo02MailingStreet,
                    OwnerID = model.OwnerID,
					HouseholdStatusID = model.HouseholdStatusID
				};
                firstEntites.HouseholdStatusID = 1;
                try
                {
                    Household existingEntity = _service.Get(model.ID);
                    if (existingEntity != null)
                        firstEntites = _service.Update(firstEntites);
                    else
                        firstEntites = _service.Add(firstEntites);
                    model.ID = firstEntites.ID;
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
            }
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Household_Update([DataSourceRequest] DataSourceRequest request, HouseholdViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var firstEntites = new Household
                {
                    CvmFormalGreeting = model.CvmFormalGreeting,
                    CvmInformalGreeting = model.CvmInformalGreeting,
                    CvmReID = model.CvmReID,
                    ExportedToCvm = model.ExportedToCvm,
                    GroupSource = model.GroupSource,
                    ID = model.ID,
                    ImportedID = model.ImportedID,
                    Name = model.Name,
                    Note = model.Note,
                    Npo02FormalGreeting = model.Npo02FormalGreeting,
                    Npo02FormulaMailingAddress = model.Npo02FormulaMailingAddress,
                    Npo02HouseholdEmail = model.Npo02HouseholdEmail,
                    Npo02HouseholdPhone = model.Npo02HouseholdPhone,
                    Npo02InformalGreeting = model.Npo02InformalGreeting,
                    Npo02MailingCity = model.Npo02MailingCity,
                    Npo02MailingPostalCode = model.Npo02MailingPostalCode,
                    Npo02MailingState = model.Npo02MailingState,
                    Npo02MailingStreet = model.Npo02MailingStreet,
                    OwnerID = model.OwnerID,
					HouseholdStatusID = model.HouseholdStatusID
                };
                try
                {
                    //Household existingEntity = _service.Get(model.ID);
                    //if (existingEntity != null)
                        firstEntites = _service.Update(firstEntites);
                    //else
                    //    firstEntites = _service.Add(firstEntites);
                    model.ID = firstEntites.ID;
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
            }
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Household_Destroy([DataSourceRequest] DataSourceRequest request, HouseholdViewModel model)
        {
            if (model != null)
            {
                var entity = _service.Get(model.ID);
                if (entity != null)
                    _service.Delete(entity);
            }
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
        #endregion
    }
}