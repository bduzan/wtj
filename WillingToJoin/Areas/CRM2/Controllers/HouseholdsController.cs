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
    public class HouseholdsController : Controller
    {
        private WTJContext db = new WTJContext();
        private readonly IHouseholdService _service;
        private readonly IMapper _mapper;

        public HouseholdsController(IHouseholdService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: /CRM2/Households/
        public ActionResult Index()
        {
            //var households = db.Households.Include(h => h.HouseholdStatu).Take(10);
            //ViewBag.households = db.Households.Include(h => h.HouseholdStatu).Take(10);
            //return View(households.ToList());
            return View();
        }

        // GET: /CRM2/Households/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                //PopulateHouseholdStatus();
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Household household = db.Households.Find(id);
            if (household == null)
            {
                return HttpNotFound();
            }

            var householdDetails = _mapper.Map<HouseholdsDetailsViewModel>(household);

            return View(householdDetails);
        }

        public void PopulateHouseholdStatus()
        {
            WTJContext context = new WTJContext();
            var statuses = context.HouseholdStatuses.ToList();
            List<SelectListItem> householdStatuses = statuses.Select(status => new SelectListItem
            {
                Value = status.HouseholdStatusID.ToString(),
                Text = status.Name
            }).ToList();

            ViewData["householdStatuses"] = householdStatuses;
        }

        public ActionResult HouseholdsDetails_Read([DataSourceRequest]DataSourceRequest request)
        {
            var entities = _service.GetAll();
            return Json(entities.ToDataSourceResult(request, s => _mapper.Map<HouseholdsDetailsViewModel>(s)));
        }

        public ActionResult Households_Read([DataSourceRequest]DataSourceRequest request)
        {
            var entities = _service.GetAll();
            return Json(entities.ToDataSourceResult(request, s => _mapper.Map<HouseholdsViewModel>(s)));
        }

        // GET: /CRM2/Households/Create
        public ActionResult Create()
        {
            ViewBag.HouseholdStatusID = new SelectList(db.HouseholdStatuses, "HouseholdStatusID", "Name");
            return View();
        }

        // POST: /CRM2/Households/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,ImportedID,OwnerID,Name,Npo02FormulaMailingAddress,Npo02HouseholdEmail,Npo02HouseholdPhone,Npo02MailingCity,Npo02MailingPostalCode,Npo02MailingState,Npo02MailingStreet,Npo02FormalGreeting,Npo02InformalGreeting,CvmReID,ExportedToCvm,Note,CvmFormalGreeting,CvmInformalGreeting,GroupSource,HouseholdStatusID")] Household household)
        {
            if (ModelState.IsValid)
            {
                db.Households.Add(household);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HouseholdStatusID = new SelectList(db.HouseholdStatuses, "HouseholdStatusID", "Name", household.HouseholdStatusID);
            return View(household);
        }

        // GET: /CRM2/Households/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Household household = db.Households.Find(id);
            if (household == null)
            {
                return HttpNotFound();
            }
            ViewBag.HouseholdStatusID = new SelectList(db.HouseholdStatuses, "HouseholdStatusID", "Name", household.HouseholdStatusID);
            return View(household);
        }

        // POST: /CRM2/Households/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,ImportedID,OwnerID,Name,Npo02FormulaMailingAddress,Npo02HouseholdEmail,Npo02HouseholdPhone,Npo02MailingCity,Npo02MailingPostalCode,Npo02MailingState,Npo02MailingStreet,Npo02FormalGreeting,Npo02InformalGreeting,CvmReID,ExportedToCvm,Note,CvmFormalGreeting,CvmInformalGreeting,GroupSource,HouseholdStatusID")] Household household)
        {
            if (ModelState.IsValid)
            {
                db.Entry(household).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HouseholdStatusID = new SelectList(db.HouseholdStatuses, "HouseholdStatusID", "Name", household.HouseholdStatusID);
            return View(household);
        }

        // GET: /CRM2/Households/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Household household = db.Households.Find(id);
            if (household == null)
            {
                return HttpNotFound();
            }
            return View(household);
        }

        // POST: /CRM2/Households/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Household household = db.Households.Find(id);
            db.Households.Remove(household);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
