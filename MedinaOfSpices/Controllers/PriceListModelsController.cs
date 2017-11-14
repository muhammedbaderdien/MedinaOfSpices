using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MedinaOfSpices.Models;

namespace MedinaOfSpices.Controllers
{
    public class PriceListModelsController : Controller
    {
		private readonly PriceListDbContext db = new PriceListDbContext();

		// GET: PriceListModels
		public async Task<ActionResult> Index()
        {
            return View(await db.PriceListModels.ToListAsync());
        }

        // GET: PriceListModels/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var priceListModel = await db.PriceListModels.FindAsync(id);
            if (priceListModel == null)
            {
                return HttpNotFound();
            }
            return View(priceListModel);
        }

        // GET: PriceListModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PriceListModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Title,Description,Weight,Price")] PriceListModel priceListModel)
        {
            if (ModelState.IsValid)
            {
                db.PriceListModels.Add(priceListModel);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(priceListModel);
        }

        // GET: PriceListModels/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			var priceListModel = await db.PriceListModels.FindAsync(id);
            if (priceListModel == null)
            {
                return HttpNotFound();
            }
            return View(priceListModel);
        }

        // POST: PriceListModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Title,Description,Weight,Price")] PriceListModel priceListModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(priceListModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(priceListModel);
        }

        // GET: PriceListModels/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			var priceListModel = await db.PriceListModels.FindAsync(id);
            if (priceListModel == null)
            {
                return HttpNotFound();
            }
            return View(priceListModel);
        }

        // POST: PriceListModels/Delete/5
        [HttpPost, ActionName(nameof(Delete))]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var priceListModel = await db.PriceListModels.FindAsync(id);
            db.PriceListModels.Remove(priceListModel);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
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
