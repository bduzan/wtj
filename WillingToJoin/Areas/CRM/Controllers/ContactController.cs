
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
    public class ContactController : Controller
    {
        private readonly IContactService _service;
        private readonly IMapper _mapper;
        public ContactController(IContactService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: CRM/Contact
        public ActionResult Index()
        {
            return View();
        }

        #region Grid Actions
        public ActionResult Contact_Read([DataSourceRequest]DataSourceRequest request)
        {
            var entities = _service.GetAll();
            return Json(entities.ToDataSourceResult(request, s => _mapper.Map<ContactViewModel>(s)));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Contact_Create([DataSourceRequest] DataSourceRequest request, ContactViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var entity = _mapper.Map<Contact>(model);
                entity = _service.Add(entity);
                model = _mapper.Map<ContactViewModel>(entity);
            }
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Contact_Update([DataSourceRequest] DataSourceRequest request, ContactViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                Contact entity = _mapper.Map<Contact>(model);
                Contact existingEntity = _service.Get(model.ID);
                if (existingEntity != null)
                    entity = _service.Update(entity);
                else
                    entity = _service.Add(entity);
                model = _mapper.Map<ContactViewModel>(entity);
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