using AutoMapper;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.Web.Mvc;
using WillingToJoin.Areas.CRM.Models;
using WillingToJoin.Shared.Data;
using WillingToJoin.Shared.Domain;
using WillingToJoin.Shared.Services.Contacts;

namespace WillingToJoin.Areas.CRM.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _service;
        private readonly IMapper _mapper;
        public AccountController(IAccountService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
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
            return Json(entities.ToDataSourceResult(request, s => _mapper.Map<AccountViewModel>(s)));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Account_Create([DataSourceRequest] DataSourceRequest request, AccountViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var entity = _mapper.Map<Account>(model);
                entity = _service.Add(entity);
                model = _mapper.Map<AccountViewModel>(entity);
            }
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Account_Update([DataSourceRequest] DataSourceRequest request, AccountViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                Account entity = _mapper.Map<Account>(model);
                Account existingEntity = _service.Get(model.ID);
                if (existingEntity != null)
                    entity = _service.Update(entity);
                else
                    entity = _service.Add(entity);
                model = _mapper.Map<AccountViewModel>(entity);
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