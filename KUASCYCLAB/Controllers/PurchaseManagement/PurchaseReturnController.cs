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

namespace KUASCYCLAB.Controllers.PurchaseManagement
{
    [Authorize]
    public class PurchaseReturnController : Controller
    {
        private KUASCYCEntities db = new KUASCYCEntities();

        // GET: PurchaseReturn
        public async Task<ActionResult> Index()
        {
            var purchaseReturns = db.PurchaseReturns.Include(p => p.Purchase);
            return View(await purchaseReturns.ToListAsync());
        }

        // GET: PurchaseReturn/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseReturn purchaseReturn = await db.PurchaseReturns.FindAsync(id);
            if (purchaseReturn == null)
            {
                return HttpNotFound();
            }
            return View(purchaseReturn);
        }

        // GET: PurchaseReturn/Create
        public ActionResult Create()
        {
            ViewBag.PurchaseID = new SelectList(db.Purchases, "PurchaseID", "Remark");
            return View();
        }

        // POST: PurchaseReturn/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PurchaseReturnsID,PurchaseReturnsDate,PurchaseReturnsQuantity,PurchaseReturnsTotalQuantity,PurchaseReturnsReason,ReplenishmentLimitedDate,Remark,PurchaseID")] PurchaseReturn purchaseReturn)
        {
            if (ModelState.IsValid)
            {
                purchaseReturn.PurchaseReturnsID = Guid.NewGuid();
                db.PurchaseReturns.Add(purchaseReturn);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.PurchaseID = new SelectList(db.Purchases, "PurchaseID", "PurchaseAmount", purchaseReturn.PurchaseID);
            return View(purchaseReturn);
        }

        // GET: PurchaseReturn/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseReturn purchaseReturn = await db.PurchaseReturns.FindAsync(id);
            if (purchaseReturn == null)
            {
                return HttpNotFound();
            }
            ViewBag.PurchaseID = new SelectList(db.Purchases, "PurchaseID", "PurchaseAmount", purchaseReturn.PurchaseID);
            return View(purchaseReturn);
        }

        // POST: PurchaseReturn/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PurchaseReturnsID,PurchaseReturnsDate,PurchaseReturnsQuantity,PurchaseReturnsTotalQuantity,PurchaseReturnsReason,ReplenishmentLimitedDate,Remark,PurchaseID")] PurchaseReturn purchaseReturn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchaseReturn).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PurchaseID = new SelectList(db.Purchases, "PurchaseID", "PurchaseAmount", purchaseReturn.PurchaseID);
            return View(purchaseReturn);
        }

        // GET: PurchaseReturn/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseReturn purchaseReturn = await db.PurchaseReturns.FindAsync(id);
            if (purchaseReturn == null)
            {
                return HttpNotFound();
            }
            return View(purchaseReturn);
        }

        // POST: PurchaseReturn/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            PurchaseReturn purchaseReturn = await db.PurchaseReturns.FindAsync(id);
            db.PurchaseReturns.Remove(purchaseReturn);
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
