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
    public class PurchaseController : Controller
    {
        private KUASCYCEntities db = new KUASCYCEntities();

        // GET: Purchase
        public async Task<ActionResult> Index()
        {
            var purchases = db.Purchases.Include(p => p.PurchaseRequisition).Include(p => p.Supplier);
            return View(await purchases.ToListAsync());
        }

        // GET: Purchase/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase purchase = await db.Purchases.FindAsync(id);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            return View(purchase);
        }

        // GET: Purchase/Create
        public ActionResult Create()
        {
            ViewBag.PurchaseRequisitionID = new SelectList(db.PurchaseRequisitions, "PurchaseRequisitionID", "PurchaseQuantity");
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "SupplierName");
            return View();
        }

        // POST: Purchase/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PurchaseID,PurchaseDate,LimitedReceiptDate,PurchaseAmount,TotalPurchaseAmount,ReceiptLocation,Remark,PurchasingDepartmentEmployee,SupplierEmployee,SupplierID,PurchaseRequisitionID")] Purchase purchase)
        {
            if (ModelState.IsValid)
            {
                purchase.PurchaseID = Guid.NewGuid();
                db.Purchases.Add(purchase);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.PurchaseRequisitionID = new SelectList(db.PurchaseRequisitions, "PurchaseRequisitionID", "PurchaseQuantity", purchase.PurchaseRequisitionID);
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "SupplierName", purchase.SupplierID);
            return View(purchase);
        }

        // GET: Purchase/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase purchase = await db.Purchases.FindAsync(id);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            ViewBag.PurchaseRequisitionID = new SelectList(db.PurchaseRequisitions, "PurchaseRequisitionID", "PurchaseQuantity", purchase.PurchaseRequisitionID);
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "SupplierName", purchase.SupplierID);
            return View(purchase);
        }

        // POST: Purchase/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PurchaseID,PurchaseDate,LimitedReceiptDate,PurchaseAmount,TotalPurchaseAmount,ReceiptLocation,Remark,PurchasingDepartmentEmployee,SupplierEmployee,SupplierID,PurchaseRequisitionID")] Purchase purchase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchase).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PurchaseRequisitionID = new SelectList(db.PurchaseRequisitions, "PurchaseRequisitionID", "PurchaseQuantity", purchase.PurchaseRequisitionID);
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "SupplierName", purchase.SupplierID);
            return View(purchase);
        }

        // GET: Purchase/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Purchase purchase = await db.Purchases.FindAsync(id);
            if (purchase == null)
            {
                return HttpNotFound();
            }
            return View(purchase);
        }

        // POST: Purchase/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Purchase purchase = await db.Purchases.FindAsync(id);
            db.Purchases.Remove(purchase);
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
