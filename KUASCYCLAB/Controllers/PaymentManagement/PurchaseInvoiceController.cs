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
    public class PurchaseInvoiceController : Controller
    {
        private KUASCYCEntities db = new KUASCYCEntities();

        // GET: PurchaseInvoice
        public async Task<ActionResult> Index()
        {
            var purchaseInvoices = db.PurchaseInvoices.Include(p => p.Purchase);
            return View(await purchaseInvoices.ToListAsync());
        }

        // GET: PurchaseInvoice/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseInvoice purchaseInvoice = await db.PurchaseInvoices.FindAsync(id);
            if (purchaseInvoice == null)
            {
                return HttpNotFound();
            }
            return View(purchaseInvoice);
        }

        // GET: PurchaseInvoice/Create
        public ActionResult Create()
        {
            ViewBag.PurchaseID = new SelectList(db.Purchases, "PurchaseID", "Remark");
            return View();
        }

        // POST: PurchaseInvoice/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PurchaseInvoiceID,InvoiceNumber,InvoiceDate,VATcharges,PurchasingDepartmentEmployee,AccountingDepartmentEmployee,PurchaseID")] PurchaseInvoice purchaseInvoice)
        {
            if (ModelState.IsValid)
            {
                purchaseInvoice.PurchaseInvoiceID = Guid.NewGuid();
                db.PurchaseInvoices.Add(purchaseInvoice);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.PurchaseID = new SelectList(db.Purchases, "PurchaseID", "PurchaseAmount", purchaseInvoice.PurchaseID);
            return View(purchaseInvoice);
        }

        // GET: PurchaseInvoice/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseInvoice purchaseInvoice = await db.PurchaseInvoices.FindAsync(id);
            if (purchaseInvoice == null)
            {
                return HttpNotFound();
            }
            ViewBag.PurchaseID = new SelectList(db.Purchases, "PurchaseID", "Remark", purchaseInvoice.PurchaseID);
            return View(purchaseInvoice);
        }

        // POST: PurchaseInvoice/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PurchaseInvoiceID,InvoiceNumber,InvoiceDate,VATcharges,PurchasingDepartmentEmployee,AccountingDepartmentEmployee,PurchaseID")] PurchaseInvoice purchaseInvoice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchaseInvoice).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PurchaseID = new SelectList(db.Purchases, "PurchaseID", "PurchaseAmount", purchaseInvoice.PurchaseID);
            return View(purchaseInvoice);
        }

        // GET: PurchaseInvoice/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseInvoice purchaseInvoice = await db.PurchaseInvoices.FindAsync(id);
            if (purchaseInvoice == null)
            {
                return HttpNotFound();
            }
            return View(purchaseInvoice);
        }

        // POST: PurchaseInvoice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            PurchaseInvoice purchaseInvoice = await db.PurchaseInvoices.FindAsync(id);
            db.PurchaseInvoices.Remove(purchaseInvoice);
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
