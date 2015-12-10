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
    public class MaterialInventoryRecordController : Controller
    {
        private KUASCYCEntities db = new KUASCYCEntities();

        // GET: MaterialInventoryRecord
        public async Task<ActionResult> Index()
        {
            var materialInventoryRecords = db.MaterialInventoryRecords.Include(m => m.ProductionOrder).Include(m => m.StorageVoucher).Include(m => m.Supplier).Include(m => m.Supplier1);
            return View(await materialInventoryRecords.ToListAsync());
        }

        // GET: MaterialInventoryRecord/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaterialInventoryRecord materialInventoryRecord = await db.MaterialInventoryRecords.FindAsync(id);
            if (materialInventoryRecord == null)
            {
                return HttpNotFound();
            }
            return View(materialInventoryRecord);
        }

        // GET: MaterialInventoryRecord/Create
        public ActionResult Create()
        {
            ViewBag.ProductionOrderID = new SelectList(db.ProductionOrders, "ProductionOrderID", "ProductionProductName");
            ViewBag.ReceiptID = new SelectList(db.StorageVouchers, "StorageVoucherID", "WarehouseStaff");
            ViewBag.VendorID = new SelectList(db.Suppliers, "SupplierID", "SupplierName");
            ViewBag.VendorID = new SelectList(db.Suppliers, "SupplierID", "SupplierName");
            return View();
        }

        // POST: MaterialInventoryRecord/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "MaterialInventoryRecordID,MaterialName,MaterialSpecifications,Inventory,SafetyStock,LastRecordedDate,CangguanLastRecordName,VendorID,ReceiptID,ProductionOrderID")] MaterialInventoryRecord materialInventoryRecord)
        {
            if (ModelState.IsValid)
            {
                materialInventoryRecord.MaterialInventoryRecordID = Guid.NewGuid();
                db.MaterialInventoryRecords.Add(materialInventoryRecord);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ProductionOrderID = new SelectList(db.ProductionOrders, "ProductionOrderID", "ProductionProductName", materialInventoryRecord.ProductionOrderID);
            ViewBag.ReceiptID = new SelectList(db.StorageVouchers, "StorageVoucherID", "WarehouseStaff", materialInventoryRecord.ReceiptID);
            ViewBag.VendorID = new SelectList(db.Suppliers, "SupplierID", "SupplierName", materialInventoryRecord.VendorID);
            ViewBag.VendorID = new SelectList(db.Suppliers, "SupplierID", "SupplierName", materialInventoryRecord.VendorID);
            return View(materialInventoryRecord);
        }

        // GET: MaterialInventoryRecord/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaterialInventoryRecord materialInventoryRecord = await db.MaterialInventoryRecords.FindAsync(id);
            if (materialInventoryRecord == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductionOrderID = new SelectList(db.ProductionOrders, "ProductionOrderID", "ProductionProductName", materialInventoryRecord.ProductionOrderID);
            ViewBag.ReceiptID = new SelectList(db.StorageVouchers, "StorageVoucherID", "WarehouseStaff", materialInventoryRecord.ReceiptID);
            ViewBag.VendorID = new SelectList(db.Suppliers, "SupplierID", "SupplierName", materialInventoryRecord.VendorID);
            ViewBag.VendorID = new SelectList(db.Suppliers, "SupplierID", "SupplierName", materialInventoryRecord.VendorID);
            return View(materialInventoryRecord);
        }

        // POST: MaterialInventoryRecord/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "MaterialInventoryRecordID,MaterialName,MaterialSpecifications,Inventory,SafetyStock,LastRecordedDate,CangguanLastRecordName,VendorID,ReceiptID,ProductionOrderID")] MaterialInventoryRecord materialInventoryRecord)
        {
            if (ModelState.IsValid)
            {
                db.Entry(materialInventoryRecord).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ProductionOrderID = new SelectList(db.ProductionOrders, "ProductionOrderID", "ProductionProductName", materialInventoryRecord.ProductionOrderID);
            ViewBag.ReceiptID = new SelectList(db.StorageVouchers, "StorageVoucherID", "WarehouseStaff", materialInventoryRecord.ReceiptID);
            ViewBag.VendorID = new SelectList(db.Suppliers, "SupplierID", "SupplierName", materialInventoryRecord.VendorID);
            ViewBag.VendorID = new SelectList(db.Suppliers, "SupplierID", "SupplierName", materialInventoryRecord.VendorID);
            return View(materialInventoryRecord);
        }

        // GET: MaterialInventoryRecord/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaterialInventoryRecord materialInventoryRecord = await db.MaterialInventoryRecords.FindAsync(id);
            if (materialInventoryRecord == null)
            {
                return HttpNotFound();
            }
            return View(materialInventoryRecord);
        }

        // POST: MaterialInventoryRecord/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            MaterialInventoryRecord materialInventoryRecord = await db.MaterialInventoryRecords.FindAsync(id);
            db.MaterialInventoryRecords.Remove(materialInventoryRecord);
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
