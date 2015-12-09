using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KUASCYCLAB.Models;

namespace KUASCYCLAB.Controllers.ProduceStroage
{
    public class StorageVoucherController : Controller
    {
        private KUASCYCEntities db = new KUASCYCEntities();

        // GET: StorageVoucher
        public async Task<ActionResult> Index()
        {
            var storageVouchers = db.StorageVouchers.Include(s => s.Purchase1);
            return View(await storageVouchers.ToListAsync());
        }

        // GET: StorageVoucher/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StorageVoucher storageVoucher = await db.StorageVouchers.FindAsync(id);
            if (storageVoucher == null)
            {
                return HttpNotFound();
            }
            return View(storageVoucher);
        }

        // GET: StorageVoucher/Create
        public ActionResult Create()
        {
            ViewBag.PurchaseID = new SelectList(db.Purchases, "PurchaseID", "PurchaseAmount");
            return View();
        }

        // POST: StorageVoucher/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "StorageVoucherID,WarehouseStaff,Purchase,StorageDate,PurchaseID")] StorageVoucher storageVoucher)
        {
            if (ModelState.IsValid)
            {
                storageVoucher.StorageVoucherID = Guid.NewGuid();
                db.StorageVouchers.Add(storageVoucher);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.PurchaseID = new SelectList(db.Purchases, "PurchaseID", "PurchaseAmount", storageVoucher.PurchaseID);
            return View(storageVoucher);
        }

        // GET: StorageVoucher/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StorageVoucher storageVoucher = await db.StorageVouchers.FindAsync(id);
            if (storageVoucher == null)
            {
                return HttpNotFound();
            }
            ViewBag.PurchaseID = new SelectList(db.Purchases, "PurchaseID", "PurchaseAmount", storageVoucher.PurchaseID);
            return View(storageVoucher);
        }

        // POST: StorageVoucher/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "StorageVoucherID,WarehouseStaff,Purchase,StorageDate,PurchaseID")] StorageVoucher storageVoucher)
        {
            if (ModelState.IsValid)
            {
                db.Entry(storageVoucher).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PurchaseID = new SelectList(db.Purchases, "PurchaseID", "PurchaseAmount", storageVoucher.PurchaseID);
            return View(storageVoucher);
        }

        // GET: StorageVoucher/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StorageVoucher storageVoucher = await db.StorageVouchers.FindAsync(id);
            if (storageVoucher == null)
            {
                return HttpNotFound();
            }
            return View(storageVoucher);
        }

        // POST: StorageVoucher/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            StorageVoucher storageVoucher = await db.StorageVouchers.FindAsync(id);
            db.StorageVouchers.Remove(storageVoucher);
            await db.SaveChangesAsync();
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
