using System;
using System.Collections.Generic;
using System.Data;
using Kendo.Mvc.UI;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WillingToJoin.Shared.Data;
using WillingToJoin.Shared.Services.Contacts;
using Kendo.Mvc.Extensions;
using AutoMapper;
using WillingToJoin.Areas.CRM2.Models;

namespace WillingToJoin.Areas.CRM2.Controllers
{
    public class DonationsController : Controller
    {
        private readonly IDonationService _service;
        private readonly IMapper _mapper;

        public DonationsController(IDonationService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public ActionResult Donations_Read([DataSourceRequest]DataSourceRequest request, int id)
        {
            var entities = _service.GetAll().Where(c => c.HouseholdID == id);
            return Json(entities.ToDataSourceResult(request, s => _mapper.Map<DonationsViewModel>(s)));
        }

        // GET: CRM2/Donations/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Donations_Create([DataSourceRequest] DataSourceRequest request, DonationsViewModel model, int did)
        {
            if (model != null && ModelState.IsValid)
            {
                model.HouseholdID = did;
                var entity = _mapper.Map<Transaction>(model);
                entity = _service.Add(entity);
                model = _mapper.Map<DonationsViewModel>(entity);
            }
            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        // POST: CRM2/Donations/Create
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

        // GET: CRM2/Donations/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CRM2/Donations/Edit/5
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

        // GET: CRM2/Donations/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CRM2/Donations/Delete/5
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
