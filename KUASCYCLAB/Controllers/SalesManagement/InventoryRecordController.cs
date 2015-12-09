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

namespace KUASCYCLAB.Controllers.SalesManagement
{
    public class InventoryRecordController : Controller
    {
        private KUASCYCEntities db = new KUASCYCEntities();

        // GET: InventoryRecord
        public async Task<ActionResult> Index()
        {
            var inventoryRecords = db.InventoryRecords.Include(i => i.InventoryReceipt).Include(i => i.Product).Include(i => i.Product1).Include(i => i.PackingList).Include(i => i.PackingList1);
            return View(await inventoryRecords.ToListAsync());
        }

        // GET: InventoryRecord/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InventoryRecord inventoryRecord = await db.InventoryRecords.FindAsync(id);
            if (inventoryRecord == null)
            {
                return HttpNotFound();
            }
            return View(inventoryRecord);
        }

        // GET: InventoryRecord/Create
        public ActionResult Create()
        {
            ViewBag.InventorySingle = new SelectList(db.InventoryReceipts, "InventoryReceiptID", "ProductionInChargeOfName");
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName");
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName");
            ViewBag.ShipperID = new SelectList(db.PackingLists, "PackingListID", "Deliveryman");
            ViewBag.ShipperID = new SelectList(db.PackingLists, "PackingListID", "Deliveryman");
            return View();
        }

        // POST: InventoryRecord/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "InventoryRecordID,ProductStocks,SafetyStock,LastRecordedDate,WarehouseRecordName,ProductID,InventorySingle,ShipperID")] InventoryRecord inventoryRecord)
        {
            if (ModelState.IsValid)
            {
                inventoryRecord.InventoryRecordID = Guid.NewGuid();
                db.InventoryRecords.Add(inventoryRecord);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.InventorySingle = new SelectList(db.InventoryReceipts, "InventoryReceiptID", "ProductionInChargeOfName", inventoryRecord.InventorySingle);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", inventoryRecord.ProductID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", inventoryRecord.ProductID);
            ViewBag.ShipperID = new SelectList(db.PackingLists, "PackingListID", "Deliveryman", inventoryRecord.ShipperID);
            ViewBag.ShipperID = new SelectList(db.PackingLists, "PackingListID", "Deliveryman", inventoryRecord.ShipperID);
            return View(inventoryRecord);
        }

        // GET: InventoryRecord/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InventoryRecord inventoryRecord = await db.InventoryRecords.FindAsync(id);
            if (inventoryRecord == null)
            {
                return HttpNotFound();
            }
            ViewBag.InventorySingle = new SelectList(db.InventoryReceipts, "InventoryReceiptID", "ProductionInChargeOfName", inventoryRecord.InventorySingle);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", inventoryRecord.ProductID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", inventoryRecord.ProductID);
            ViewBag.ShipperID = new SelectList(db.PackingLists, "PackingListID", "Deliveryman", inventoryRecord.ShipperID);
            ViewBag.ShipperID = new SelectList(db.PackingLists, "PackingListID", "Deliveryman", inventoryRecord.ShipperID);
            return View(inventoryRecord);
        }

        // POST: InventoryRecord/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "InventoryRecordID,ProductStocks,SafetyStock,LastRecordedDate,WarehouseRecordName,ProductID,InventorySingle,ShipperID")] InventoryRecord inventoryRecord)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inventoryRecord).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.InventorySingle = new SelectList(db.InventoryReceipts, "InventoryReceiptID", "ProductionInChargeOfName", inventoryRecord.InventorySingle);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", inventoryRecord.ProductID);
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", inventoryRecord.ProductID);
            ViewBag.ShipperID = new SelectList(db.PackingLists, "PackingListID", "Deliveryman", inventoryRecord.ShipperID);
            ViewBag.ShipperID = new SelectList(db.PackingLists, "PackingListID", "Deliveryman", inventoryRecord.ShipperID);
            return View(inventoryRecord);
        }

        // GET: InventoryRecord/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InventoryRecord inventoryRecord = await db.InventoryRecords.FindAsync(id);
            if (inventoryRecord == null)
            {
                return HttpNotFound();
            }
            return View(inventoryRecord);
        }

        // POST: InventoryRecord/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            InventoryRecord inventoryRecord = await db.InventoryRecords.FindAsync(id);
            db.InventoryRecords.Remove(inventoryRecord);
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
