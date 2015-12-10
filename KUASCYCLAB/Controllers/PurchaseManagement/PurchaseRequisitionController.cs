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
    public class PurchaseRequisitionController : Controller
    {
        private KUASCYCEntities db = new KUASCYCEntities();

        // GET: PurchaseRequisition
        public async Task<ActionResult> Index()
        {
            return View(await db.PurchaseRequisitions.ToListAsync());
        }

        // GET: PurchaseRequisition/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseRequisition purchaseRequisition = await db.PurchaseRequisitions.FindAsync(id);
            if (purchaseRequisition == null)
            {
                return HttpNotFound();
            }
            return View(purchaseRequisition);
        }

        // GET: PurchaseRequisition/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PurchaseRequisition/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PurchaseRequisitionID,ApplicationDate,PurchaseQuantity,TotalPurchaseQuantity,Remark,CangguanEmployee,PurchasingDepartmentEmployee")] PurchaseRequisition purchaseRequisition)
        {
            if (ModelState.IsValid)
            {
                purchaseRequisition.PurchaseRequisitionID = Guid.NewGuid();
                db.PurchaseRequisitions.Add(purchaseRequisition);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(purchaseRequisition);
        }

        // GET: PurchaseRequisition/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseRequisition purchaseRequisition = await db.PurchaseRequisitions.FindAsync(id);
            if (purchaseRequisition == null)
            {
                return HttpNotFound();
            }
            return View(purchaseRequisition);
        }

        // POST: PurchaseRequisition/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PurchaseRequisitionID,ApplicationDate,PurchaseQuantity,TotalPurchaseQuantity,Remark,CangguanEmployee,PurchasingDepartmentEmployee")] PurchaseRequisition purchaseRequisition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchaseRequisition).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(purchaseRequisition);
        }

        // GET: PurchaseRequisition/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseRequisition purchaseRequisition = await db.PurchaseRequisitions.FindAsync(id);
            if (purchaseRequisition == null)
            {
                return HttpNotFound();
            }
            return View(purchaseRequisition);
        }

        // POST: PurchaseRequisition/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            PurchaseRequisition purchaseRequisition = await db.PurchaseRequisitions.FindAsync(id);
            db.PurchaseRequisitions.Remove(purchaseRequisition);
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
