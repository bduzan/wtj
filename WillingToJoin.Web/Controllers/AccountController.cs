using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.Web.Mvc;
using WillingToJoin.Shared.Data;
using WillingToJoin.Web.Models;
using WillingToJoin.Shared.Services.Contacts;

namespace WillingToJoin.Web.Areas.CRM.Controllers
{
    public class AccountController : Umbraco.Web.Mvc.SurfaceController
    {
        private readonly IAccountService _service;
        public AccountController(IAccountService service)
        {
            _service = service;
        }
        // GET: CRM/Account
        public ActionResult Index()
        {
            return View();
        }

        #region Grid Actions
        public ActionResult Account_Read([DataSourceRequest]DataSourceRequest request)
        {
            var entities = _service.GetAll();
            var objAcc = entities.ToDataSourceResult(request, s => new AccountViewModel
            {
                ID = s.ID,
                ImportedID = s.ImportedID,
                Name = s.Name,
                Type = s.Type,
                BillingStreet = s.BillingStreet,
                BillingCity = s.BillingCity,
                BillingState = s.BillingState,
                BillingPostalCode = s.BillingPostalCode,
                ShippingStreet = s.ShippingStreet,
                ShippingCity = s.ShippingCity,
                ShippingState = s.ShippingState,
                ShippingPostalCode = s.ShippingPostalCode,
                Phone = s.Phone,
                Website = s.Website,
                Facebook = s.Facebook,
                SourceGroup = s.SourceGroup
            });
            return Json(objAcc, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Account_Create([DataSourceRequest] DataSourceRequest request, AccountViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var FirstEntity = new Account
                {
                    ID = model.ID,
                    ImportedID = model.ImportedID,
                    Name = model.Name,
                    Type = model.Type,
                    BillingStreet = model.BillingStreet,
                    BillingCity = model.BillingCity,
                    BillingState = model.BillingState,
                    BillingPostalCode = model.BillingPostalCode,
                    ShippingStreet = model.ShippingStreet,
                    ShippingCity = model.ShippingCity,
                    ShippingState = model.ShippingState,
                    ShippingPostalCode = model.ShippingPostalCode,
                    Phone = model.Phone,
                    Website = model.Website,
                    Facebook = model.Facebook,
                    SourceGroup = model.SourceGroup
                };
                FirstEntity.AccountStatusID = 1;
                FirstEntity = _service.Add(FirstEntity);
                var SecondEntity = new AccountViewModel
                {
                    ID = FirstEntity.ID,
                    ImportedID = FirstEntity.ImportedID,
                    Name = FirstEntity.Name,
                    Type = FirstEntity.Type,
                    BillingStreet = FirstEntity.BillingStreet,
                    BillingCity = FirstEntity.BillingCity,
                    BillingState = FirstEntity.BillingState,
                    BillingPostalCode = FirstEntity.BillingPostalCode,
                    ShippingStreet = FirstEntity.ShippingStreet,
                    ShippingCity = FirstEntity.ShippingCity,
                    ShippingState = FirstEntity.ShippingState,
                    ShippingPostalCode = FirstEntity.ShippingPostalCode,
                    Phone = FirstEntity.Phone,
                    Website = FirstEntity.Website,
                    Facebook = FirstEntity.Facebook,
                    SourceGroup = FirstEntity.SourceGroup
                };
            }
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Account_Update([DataSourceRequest] DataSourceRequest request, AccountViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var FirstEntity = new Account
                {
                    ID = model.ID,
                    ImportedID = model.ImportedID,
                    Name = model.Name,
                    Type = model.Type,
                    BillingStreet = model.BillingStreet,
                    BillingCity = model.BillingCity,
                    BillingState = model.BillingState,
                    BillingPostalCode = model.BillingPostalCode,
                    ShippingStreet = model.ShippingStreet,
                    ShippingCity = model.ShippingCity,
                    ShippingState = model.ShippingState,
                    ShippingPostalCode = model.ShippingPostalCode,
                    Phone = model.Phone,
                    Website = model.Website,
                    Facebook = model.Facebook,
                    SourceGroup = model.SourceGroup
                };
                FirstEntity.AccountStatusID = 1;
                Account existingEntity = _service.Get(model.ID);
                if (existingEntity != null)
                    FirstEntity = _service.Update(FirstEntity);
                else
                    FirstEntity = _service.Add(FirstEntity);
                var SecondEntity = new AccountViewModel()
                {
                    ID = FirstEntity.ID,
                    ImportedID = FirstEntity.ImportedID,
                    Name = FirstEntity.Name,
                    Type = FirstEntity.Type,
                    BillingStreet = FirstEntity.BillingStreet,
                    BillingCity = FirstEntity.BillingCity,
                    BillingState = FirstEntity.BillingState,
                    BillingPostalCode = FirstEntity.BillingPostalCode,
                    ShippingStreet = FirstEntity.ShippingStreet,
                    ShippingCity = FirstEntity.ShippingCity,
                    ShippingState = FirstEntity.ShippingState,
                    ShippingPostalCode = FirstEntity.ShippingPostalCode,
                    Phone = FirstEntity.Phone,
                    Website = FirstEntity.Website,
                    Facebook = FirstEntity.Facebook,
                    SourceGroup = FirstEntity.SourceGroup
                };
            }
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Account_Destroy([DataSourceRequest] DataSourceRequest request, AccountViewModel model)
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