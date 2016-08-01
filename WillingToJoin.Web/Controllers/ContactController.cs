using System.Collections.Generic;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.Web.Mvc;
using System.Linq;
using WillingToJoin.Shared.Data;
using WillingToJoin.Shared.Services.Contacts;
using WillingToJoin.Shared.Services.Accounts;
using WillingToJoin.Web.Models;


namespace WillingToJoin.Web.Areas.CRM.Controllers
{
    public class ContactController : Umbraco.Web.Mvc.SurfaceController
    {
        private readonly IContactService _service;
        private readonly IHouseholdService _householdService;
        public ContactController(IContactService service, IHouseholdService householdService)
        {
            _service = service;
            _householdService = householdService;
        }
        // GET: CRM/Contact
        public ActionResult Index()
        {
            PopulateHouseholds();
            return View();
        }




        public void PopulateHouseholds()
        {
            WTJContext context = new WTJContext();
            var households = context.Contacts.ToList();
            List<SelectListItem> householdList = households.Select(hh => new SelectListItem
            {
                Value = hh.ID.ToString(),
                Text = hh.Name
            }).ToList();

            ViewBag["householdList"] = householdList;
        }
        #region Grid Actions
        public ActionResult Contact_Read([DataSourceRequest]DataSourceRequest request)
        {
            PopulateHouseholds();
            var entities = _service.GetAll();
            var contactRead = entities.ToDataSourceResult(request, s => new ContactViewModel
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

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Contact_Create([DataSourceRequest] DataSourceRequest request, ContactViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var firstEntity = new Contact
                {
                    AccountID = model.AccountID,
                    AccountImportedID = model.AccountImportedID,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    HomeEmail = model.Npe01HomeEmail,
                    HomePhone = model.Phone,
                    HouseholdID = model.HouseholdID,
                    HouseholdFamilyRoleID = model.HouseholdFamilyRoleID,
                    HouseholdImportedID = model.HouseholdImportedID,
                    ID = model.ID,
                    ImportedID = model.ImportedID,
                    LastName = model.LastName,
                    MailingCity = model.MailingCity,
                    MailingPostalCode = model.MailingPostalCode,
                    MailingState = model.MailingState,
                    MailingStreet = model.MailingStreet,
                    MobilePhone = model.MobilePhone,
                    Name = model.Name,
                    OwnerID = model.OwnerID,
                    Phone = model.Phone,
                    Salutation = model.Salutation,
                    WorkEmail = model.Npe01WorkEmail,
                    WorkPhone = model.Npe01WorkPhone
                };

                firstEntity.HouseholdFamilyRoleID = 1;
                try
                {
                    Contact existingEntity = _service.Get(model.ID);
                    if (existingEntity != null)
                        firstEntity = _service.Update(firstEntity);
                    else
                        firstEntity = _service.Add(firstEntity);
                    model.ID = firstEntity.ID;
                    model.HouseholdFamilyRoleID = 1;
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
            }
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Contact_Update([DataSourceRequest] DataSourceRequest request, ContactViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var firstEntity = new Contact
                {
                    AccountID = model.AccountID,
                    AccountImportedID = model.AccountImportedID,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    HomeEmail = model.Npe01HomeEmail,
                    HomePhone = model.Phone,
                    HouseholdID = model.HouseholdID,
                    HouseholdFamilyRoleID = model.HouseholdFamilyRoleID,
                    HouseholdImportedID = model.HouseholdImportedID,
                    ID = model.ID,
                    ImportedID = model.ImportedID,
                    LastName = model.LastName,
                    MailingCity = model.MailingCity,
                    MailingPostalCode = model.MailingPostalCode,
                    MailingState = model.MailingState,
                    MailingStreet = model.MailingStreet,
                    MobilePhone = model.MobilePhone,
                    Name = model.Name,
                    OwnerID = model.OwnerID,
                    Phone = model.Phone,
                    Salutation = model.Salutation,
                    WorkEmail = model.Npe01WorkEmail,
                    WorkPhone = model.Npe01WorkPhone
                };
                Contact existingEntity = _service.Get(model.ID);
                if (existingEntity != null)
                    firstEntity = _service.Update(firstEntity);
                else
                    firstEntity = _service.Add(firstEntity);
                model.ID = firstEntity.ID;
            }
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Contact_Destroy([DataSourceRequest] DataSourceRequest request, ContactViewModel model)
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