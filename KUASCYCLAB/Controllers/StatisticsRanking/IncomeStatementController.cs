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

namespace KUASCYCLAB.Controllers.StatisticsRanking
{
    [Authorize]
    public class IncomeStatementController : Controller
    {
        private KUASCYCEntities db = new KUASCYCEntities();

        // GET: IncomeStatement
        public async Task<ActionResult> Index()
        {
            var incomeStatements = db.IncomeStatements.Include(i => i.InventoryRecord).Include(i => i.MaterialInventoryRecord).Include(i => i.PurchaseInvoice).Include(i => i.PurchaseInvoice1).Include(i => i.PurchaseRequestPayment).Include(i => i.SalesIncomeRecord).Include(i => i.SalesInvoice_);
            return View(await incomeStatements.ToListAsync());
        }

        // GET: IncomeStatement/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncomeStatement incomeStatement = await db.IncomeStatements.FindAsync(id);
            if (incomeStatement == null)
            {
                return HttpNotFound();
            }
            return View(incomeStatement);
        }

        // GET: IncomeStatement/Create
        public ActionResult Create()
        {
            ViewBag.InventoryRecordID = new SelectList(db.InventoryRecords, "InventoryRecordID", "ProductStocks");
            ViewBag.MaterialInventoryRecordID = new SelectList(db.MaterialInventoryRecords, "MaterialInventoryRecordID", "MaterialName");
            ViewBag.PurchaseInvoiceID = new SelectList(db.PurchaseInvoices, "PurchaseInvoiceID", "InvoiceNumber");
            ViewBag.PurchaseInvoiceID = new SelectList(db.PurchaseInvoices, "PurchaseInvoiceID", "InvoiceNumber");
            ViewBag.PurchaseRequestPaymentID = new SelectList(db.PurchaseRequestPayments, "PurchaseRequestPaymentID", "ImportAccount");
            ViewBag.SalesIncomeRecordID = new SelectList(db.SalesIncomeRecords, "SalesIncomeRecordID", "AccountNumber");
            ViewBag.SalesInvoiceID = new SelectList(db.SalesInvoice_, "SalesInvoiceID", "UniformID");
            return View();
        }

        // POST: IncomeStatement/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IncomeStatementID,AnnualStatistics,PreTaxIncome,NetIncome,AccountingDepartmentEmployee,SalesIncomeRecordID,PurchaseRequestPaymentID,PurchaseInvoiceID,SalesInvoiceID,InventoryRecordID,MaterialInventoryRecordID")] IncomeStatement incomeStatement)
        {
            if (ModelState.IsValid)
            {
                incomeStatement.IncomeStatementID = Guid.NewGuid();
                db.IncomeStatements.Add(incomeStatement);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.InventoryRecordID = new SelectList(db.InventoryRecords, "InventoryRecordID", "ProductStocks", incomeStatement.InventoryRecordID);
            ViewBag.MaterialInventoryRecordID = new SelectList(db.MaterialInventoryRecords, "MaterialInventoryRecordID", "MaterialName", incomeStatement.MaterialInventoryRecordID);
            ViewBag.PurchaseInvoiceID = new SelectList(db.PurchaseInvoices, "PurchaseInvoiceID", "InvoiceNumber", incomeStatement.PurchaseInvoiceID);
            ViewBag.PurchaseInvoiceID = new SelectList(db.PurchaseInvoices, "PurchaseInvoiceID", "InvoiceNumber", incomeStatement.PurchaseInvoiceID);
            ViewBag.PurchaseRequestPaymentID = new SelectList(db.PurchaseRequestPayments, "PurchaseRequestPaymentID", "ImportAccount", incomeStatement.PurchaseRequestPaymentID);
            ViewBag.SalesIncomeRecordID = new SelectList(db.SalesIncomeRecords, "SalesIncomeRecordID", "AccountNumber", incomeStatement.SalesIncomeRecordID);
            ViewBag.SalesInvoiceID = new SelectList(db.SalesInvoice_, "SalesInvoiceID", "UniformID", incomeStatement.SalesInvoiceID);
            return View(incomeStatement);
        }

        // GET: IncomeStatement/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncomeStatement incomeStatement = await db.IncomeStatements.FindAsync(id);
            if (incomeStatement == null)
            {
                return HttpNotFound();
            }
            ViewBag.InventoryRecordID = new SelectList(db.InventoryRecords, "InventoryRecordID", "ProductStocks", incomeStatement.InventoryRecordID);
            ViewBag.MaterialInventoryRecordID = new SelectList(db.MaterialInventoryRecords, "MaterialInventoryRecordID", "MaterialName", incomeStatement.MaterialInventoryRecordID);
            ViewBag.PurchaseInvoiceID = new SelectList(db.PurchaseInvoices, "PurchaseInvoiceID", "InvoiceNumber", incomeStatement.PurchaseInvoiceID);
            ViewBag.PurchaseInvoiceID = new SelectList(db.PurchaseInvoices, "PurchaseInvoiceID", "InvoiceNumber", incomeStatement.PurchaseInvoiceID);
            ViewBag.PurchaseRequestPaymentID = new SelectList(db.PurchaseRequestPayments, "PurchaseRequestPaymentID", "ImportAccount", incomeStatement.PurchaseRequestPaymentID);
            ViewBag.SalesIncomeRecordID = new SelectList(db.SalesIncomeRecords, "SalesIncomeRecordID", "AccountNumber", incomeStatement.SalesIncomeRecordID);
            ViewBag.SalesInvoiceID = new SelectList(db.SalesInvoice_, "SalesInvoiceID", "UniformID", incomeStatement.SalesInvoiceID);
            return View(incomeStatement);
        }

        // POST: IncomeStatement/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IncomeStatementID,AnnualStatistics,PreTaxIncome,NetIncome,AccountingDepartmentEmployee,SalesIncomeRecordID,PurchaseRequestPaymentID,PurchaseInvoiceID,SalesInvoiceID,InventoryRecordID,MaterialInventoryRecordID")] IncomeStatement incomeStatement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(incomeStatement).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.InventoryRecordID = new SelectList(db.InventoryRecords, "InventoryRecordID", "ProductStocks", incomeStatement.InventoryRecordID);
            ViewBag.MaterialInventoryRecordID = new SelectList(db.MaterialInventoryRecords, "MaterialInventoryRecordID", "MaterialName", incomeStatement.MaterialInventoryRecordID);
            ViewBag.PurchaseInvoiceID = new SelectList(db.PurchaseInvoices, "PurchaseInvoiceID", "InvoiceNumber", incomeStatement.PurchaseInvoiceID);
            ViewBag.PurchaseInvoiceID = new SelectList(db.PurchaseInvoices, "PurchaseInvoiceID", "InvoiceNumber", incomeStatement.PurchaseInvoiceID);
            ViewBag.PurchaseRequestPaymentID = new SelectList(db.PurchaseRequestPayments, "PurchaseRequestPaymentID", "ImportAccount", incomeStatement.PurchaseRequestPaymentID);
            ViewBag.SalesIncomeRecordID = new SelectList(db.SalesIncomeRecords, "SalesIncomeRecordID", "AccountNumber", incomeStatement.SalesIncomeRecordID);
            ViewBag.SalesInvoiceID = new SelectList(db.SalesInvoice_, "SalesInvoiceID", "UniformID", incomeStatement.SalesInvoiceID);
            return View(incomeStatement);
        }

        // GET: IncomeStatement/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncomeStatement incomeStatement = await db.IncomeStatements.FindAsync(id);
            if (incomeStatement == null)
            {
                return HttpNotFound();
            }
            return View(incomeStatement);
        }

        // POST: IncomeStatement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            IncomeStatement incomeStatement = await db.IncomeStatements.FindAsync(id);
            db.IncomeStatements.Remove(incomeStatement);
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
