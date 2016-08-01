using System.Collections.Generic;
using AutoMapper;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.Linq;
using System.Web.Mvc;
using WillingToJoin.Areas.CRM.Models;
using WillingToJoin.Shared.Data;
using WillingToJoin.Shared.Domain;
using WillingToJoin.Shared.Services.Contacts;

namespace WillingToJoin.Areas.CRM.Controllers
{
    public class HouseholdController : Controller
    {
        private readonly IHouseholdService _service;
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;
        public HouseholdController(IHouseholdService service, IContactService contactService, IMapper mapper)
        {
            _service = service;
            _contactService = contactService;
            _mapper = mapper;
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

        public ActionResult HouseholdNote_Read([DataSourceRequest]DataSourceRequest request)
        {
            return null; //Json(GetOrders().ToDataSourceResult(request));
        }

        #region Grid Actions
        public ActionResult HierarchyBinding_Contacts(int householdID, [DataSourceRequest] DataSourceRequest request)
        {
            var entities = _contactService.GetAll();
            return Json(entities.Where<Contact>(w => w.HouseholdID == householdID)
                .ToDataSourceResult(request, s => _mapper.Map<ContactViewModel>(s)));
        }

        public ActionResult Household_Read([DataSourceRequest]DataSourceRequest request)
        {
            var entities = _service.GetAll();
            return Json(entities.ToDataSourceResult(request, s => _mapper.Map<HouseholdViewModel>(s)));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Household_Create([DataSourceRequest] DataSourceRequest request, HouseholdViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                var entity = _mapper.Map<Household>(model);
                entity = _service.Add(entity);
                model = _mapper.Map<HouseholdViewModel>(entity);
            }
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Household_Update([DataSourceRequest] DataSourceRequest request, HouseholdViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                Household entity = _mapper.Map<Household>(model);
                Household existingEntity = _service.Get(model.ID);
                if (existingEntity != null)
                    entity = _service.Update(entity);
                else
                    entity = _service.Add(entity);
                model = _mapper.Map<HouseholdViewModel>(entity);
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