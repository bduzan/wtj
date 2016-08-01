using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.Web.Mvc;
using WillingToJoin.Shared.Data;
using WillingToJoin.Shared.Domain;
using WillingToJoin.Shared.Services.Contacts;
using WillingToJoin.Areas.CRM2.Models;

namespace WillingToJoin.Areas.CRM2.Controllers
{
    public class ContactsController : Controller
    {
        private readonly IContactService _service;
        private readonly IMapper _mapper;

        public ContactsController(IContactService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        //public ActionResult Contacts_Read([DataSourceRequest]DataSourceRequest request)
        //{
        //    var entities = _service.GetAll();
        //    return Json(entities.ToDataSourceResult(request, s => _mapper.Map<ContactsViewModel>(s)));
        //}

        public ActionResult Contacts_Read([DataSourceRequest]DataSourceRequest request, int id)
        {
            var entities = _service.GetAll().Where(c => c.HouseholdID == id);
            return Json(entities.ToDataSourceResult(request, s => _mapper.Map<ContactsViewModel>(s)));
        }

        // GET: CRM2/Contacts
        public ActionResult Index()
        {
            return View();
        }

        // GET: CRM2/Contacts/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Contacts_Create([DataSourceRequest] DataSourceRequest request, ContactsViewModel model, int hid)
        {
            if (model != null && ModelState.IsValid)
            {
                model.HouseholdID = hid;
                var entity = _mapper.Map<Contact>(model);
                entity = _service.Add(entity);
                model = _mapper.Map<ContactsViewModel>(entity);
            }
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        // POST: CRM2/Contacts/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Contacts_Update([DataSourceRequest] DataSourceRequest request, ContactsViewModel model)
        {
            if (model != null && ModelState.IsValid)
            {
                Contact entity = _mapper.Map<Contact>(model);
                //Contact existingEntity = _service.Get(model.ID);
                //if (existingEntity != null)
                    entity = _service.Update(entity);
                //else
                //    entity = _service.Add(entity);
                model = _mapper.Map<ContactsViewModel>(entity);
            }

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CRM2/Contacts/Delete/5
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Contacts_Destroy([DataSourceRequest] DataSourceRequest request, ContactsViewModel model)
        {
            if (model != null)
            {
                var entity = _service.Get(model.ID);
                if (entity != null)
                    _service.Delete(entity);
            }
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
