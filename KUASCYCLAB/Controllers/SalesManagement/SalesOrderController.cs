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
    public class SalesOrderController : Controller
    {
        private KUASCYCEntities db = new KUASCYCEntities();

        // GET: SalesOrder
        public async Task<ActionResult> Index()
        {
            var salesOrders = db.SalesOrders.Include(s => s.CustomerProfile).Include(s => s.Quotation);
            return View(await salesOrders.ToListAsync());
        }

        // GET: SalesOrder/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesOrder salesOrder = await db.SalesOrders.FindAsync(id);
            if (salesOrder == null)
            {
                return HttpNotFound();
            }
            return View(salesOrder);
        }

        // GET: SalesOrder/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.CustomerProfiles, "CustomerID", "CustomerName");
            ViewBag.QuotationID = new SelectList(db.Quotations, "QuotationID", "BusinessOrdersEmployee");
            return View();
        }

        // POST: SalesOrder/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SalesOrderID,OrderDate,ToName,RecipientPlace,RecipientsPhone,ExpectedReceiptDate,Qty,TotalQty,PurchaseAmount,TotalOrderAmount,Remark,BusinessProcessEmployee,WarehouseDealingEmployee,QuotationID,CustomerID")] SalesOrder salesOrder)
        {
            if (ModelState.IsValid)
            {
                salesOrder.SalesOrderID = Guid.NewGuid();
                db.SalesOrders.Add(salesOrder);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.CustomerProfiles, "CustomerID", "CustomerName", salesOrder.CustomerID);
            ViewBag.QuotationID = new SelectList(db.Quotations, "QuotationID", "BusinessOrdersEmployee", salesOrder.QuotationID);
            return View(salesOrder);
        }

        // GET: SalesOrder/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesOrder salesOrder = await db.SalesOrders.FindAsync(id);
            if (salesOrder == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.CustomerProfiles, "CustomerID", "CustomerName", salesOrder.CustomerID);
            ViewBag.QuotationID = new SelectList(db.Quotations, "QuotationID", "BusinessOrdersEmployee", salesOrder.QuotationID);
            return View(salesOrder);
        }

        // POST: SalesOrder/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SalesOrderID,OrderDate,ToName,RecipientPlace,RecipientsPhone,ExpectedReceiptDate,Qty,TotalQty,PurchaseAmount,TotalOrderAmount,Remark,BusinessProcessEmployee,WarehouseDealingEmployee,QuotationID,CustomerID")] SalesOrder salesOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salesOrder).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.CustomerProfiles, "CustomerID", "CustomerName", salesOrder.CustomerID);
            ViewBag.QuotationID = new SelectList(db.Quotations, "QuotationID", "BusinessOrdersEmployee", salesOrder.QuotationID);
            return View(salesOrder);
        }

        // GET: SalesOrder/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesOrder salesOrder = await db.SalesOrders.FindAsync(id);
            if (salesOrder == null)
            {
                return HttpNotFound();
            }
            return View(salesOrder);
        }

        // POST: SalesOrder/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            SalesOrder salesOrder = await db.SalesOrders.FindAsync(id);
            db.SalesOrders.Remove(salesOrder);
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
