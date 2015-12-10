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
    [Authorize]
    public class InventoryReceiptController : Controller
    {
        private KUASCYCEntities db = new KUASCYCEntities();

        // GET: InventoryReceipt
        public async Task<ActionResult> Index()
        {
            var inventoryReceipts = db.InventoryReceipts.Include(i => i.ProductionOrder);
            return View(await inventoryReceipts.ToListAsync());
        }

        // GET: InventoryReceipt/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InventoryReceipt inventoryReceipt = await db.InventoryReceipts.FindAsync(id);
            if (inventoryReceipt == null)
            {
                return HttpNotFound();
            }
            return View(inventoryReceipt);
        }

        // GET: InventoryReceipt/Create
        public ActionResult Create()
        {
            ViewBag.ProductionOrderID = new SelectList(db.ProductionOrders, "ProductionOrderID", "ProductionProductName");
            return View();
        }

        // POST: InventoryReceipt/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "InventoryReceiptID,ProductionInChargeOfName,WarehouseResponsibleName,InventoryDate,ProductionOrderID")] InventoryReceipt inventoryReceipt)
        {
            if (ModelState.IsValid)
            {
                inventoryReceipt.InventoryReceiptID = Guid.NewGuid();
                db.InventoryReceipts.Add(inventoryReceipt);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ProductionOrderID = new SelectList(db.ProductionOrders, "ProductionOrderID", "ProductionProductName", inventoryReceipt.ProductionOrderID);
            return View(inventoryReceipt);
        }

        // GET: InventoryReceipt/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InventoryReceipt inventoryReceipt = await db.InventoryReceipts.FindAsync(id);
            if (inventoryReceipt == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductionOrderID = new SelectList(db.ProductionOrders, "ProductionOrderID", "ProductionProductName", inventoryReceipt.ProductionOrderID);
            return View(inventoryReceipt);
        }

        // POST: InventoryReceipt/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "InventoryReceiptID,ProductionInChargeOfName,WarehouseResponsibleName,InventoryDate,ProductionOrderID")] InventoryReceipt inventoryReceipt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inventoryReceipt).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ProductionOrderID = new SelectList(db.ProductionOrders, "ProductionOrderID", "ProductionProductName", inventoryReceipt.ProductionOrderID);
            return View(inventoryReceipt);
        }

        // GET: InventoryReceipt/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InventoryReceipt inventoryReceipt = await db.InventoryReceipts.FindAsync(id);
            if (inventoryReceipt == null)
            {
                return HttpNotFound();
            }
            return View(inventoryReceipt);
        }

        // POST: InventoryReceipt/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            InventoryReceipt inventoryReceipt = await db.InventoryReceipts.FindAsync(id);
            db.InventoryReceipts.Remove(inventoryReceipt);
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
