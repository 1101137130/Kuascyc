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

namespace KUASCYCLAB.Controllers.PaymentManagement
{
    [Authorize]
    public class PurchaseRequestPaymentController : Controller
    {
        private KUASCYCEntities db = new KUASCYCEntities();

        // GET: PurchaseRequestPayment
        public async Task<ActionResult> Index()
        {
            var purchaseRequestPayments = db.PurchaseRequestPayments.Include(p => p.Purchase);
            return View(await purchaseRequestPayments.ToListAsync());
        }

        // GET: PurchaseRequestPayment/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseRequestPayment purchaseRequestPayment = await db.PurchaseRequestPayments.FindAsync(id);
            if (purchaseRequestPayment == null)
            {
                return HttpNotFound();
            }
            return View(purchaseRequestPayment);
        }

        // GET: PurchaseRequestPayment/Create
        public ActionResult Create()
        {
            ViewBag.PurchaseID = new SelectList(db.Purchases, "PurchaseID", "Remark");
            return View();
        }

        // POST: PurchaseRequestPayment/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PurchaseRequestPaymentID,RequestDate,ImportAccount,Deadline,Remark,PurchasingDepartmentEmployee,AccountingDepartmentEmployee,PurchaseID")] PurchaseRequestPayment purchaseRequestPayment)
        {
            if (ModelState.IsValid)
            {
                purchaseRequestPayment.PurchaseRequestPaymentID = Guid.NewGuid();
                db.PurchaseRequestPayments.Add(purchaseRequestPayment);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.PurchaseID = new SelectList(db.Purchases, "PurchaseID", "Remark", purchaseRequestPayment.PurchaseID);
            return View(purchaseRequestPayment);
        }

        // GET: PurchaseRequestPayment/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseRequestPayment purchaseRequestPayment = await db.PurchaseRequestPayments.FindAsync(id);
            if (purchaseRequestPayment == null)
            {
                return HttpNotFound();
            }
            ViewBag.PurchaseID = new SelectList(db.Purchases, "PurchaseID", "Remark", purchaseRequestPayment.PurchaseID);
            return View(purchaseRequestPayment);
        }

        // POST: PurchaseRequestPayment/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PurchaseRequestPaymentID,RequestDate,ImportAccount,Deadline,Remark,PurchasingDepartmentEmployee,AccountingDepartmentEmployee,PurchaseID")] PurchaseRequestPayment purchaseRequestPayment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchaseRequestPayment).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PurchaseID = new SelectList(db.Purchases, "PurchaseID", "Remark", purchaseRequestPayment.PurchaseID);
            return View(purchaseRequestPayment);
        }

        // GET: PurchaseRequestPayment/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseRequestPayment purchaseRequestPayment = await db.PurchaseRequestPayments.FindAsync(id);
            if (purchaseRequestPayment == null)
            {
                return HttpNotFound();
            }
            return View(purchaseRequestPayment);
        }

        // POST: PurchaseRequestPayment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            PurchaseRequestPayment purchaseRequestPayment = await db.PurchaseRequestPayments.FindAsync(id);
            db.PurchaseRequestPayments.Remove(purchaseRequestPayment);
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
