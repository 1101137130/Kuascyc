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
    public class SalesIncomeRecordController : Controller
    {
        private KUASCYCEntities db = new KUASCYCEntities();

        // GET: SalesIncomeRecord
        public async Task<ActionResult> Index()
        {
            var salesIncomeRecords = db.SalesIncomeRecords.Include(s => s.SalesIncome);
            return View(await salesIncomeRecords.ToListAsync());
        }

        // GET: SalesIncomeRecord/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesIncomeRecord salesIncomeRecord = await db.SalesIncomeRecords.FindAsync(id);
            if (salesIncomeRecord == null)
            {
                return HttpNotFound();
            }
            return View(salesIncomeRecord);
        }

        // GET: SalesIncomeRecord/Create
        public ActionResult Create()
        {
            ViewBag.SalesIncomeID = new SelectList(db.SalesIncomes, "SalesIncomeID", "Remark");
            return View();
        }

        // POST: SalesIncomeRecord/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SalesIncomeRecordID,Date,AccountNumber,Remark,AccountingDepartmentEmployee,SalesIncomeID")] SalesIncomeRecord salesIncomeRecord)
        {
            if (ModelState.IsValid)
            {
                salesIncomeRecord.SalesIncomeRecordID = Guid.NewGuid();
                db.SalesIncomeRecords.Add(salesIncomeRecord);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.SalesIncomeID = new SelectList(db.SalesIncomes, "SalesIncomeID", "Remark", salesIncomeRecord.SalesIncomeID);
            return View(salesIncomeRecord);
        }

        // GET: SalesIncomeRecord/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesIncomeRecord salesIncomeRecord = await db.SalesIncomeRecords.FindAsync(id);
            if (salesIncomeRecord == null)
            {
                return HttpNotFound();
            }
            ViewBag.SalesIncomeID = new SelectList(db.SalesIncomes, "SalesIncomeID", "Remark", salesIncomeRecord.SalesIncomeID);
            return View(salesIncomeRecord);
        }

        // POST: SalesIncomeRecord/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SalesIncomeRecordID,Date,AccountNumber,Remark,AccountingDepartmentEmployee,SalesIncomeID")] SalesIncomeRecord salesIncomeRecord)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salesIncomeRecord).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.SalesIncomeID = new SelectList(db.SalesIncomes, "SalesIncomeID", "Remark", salesIncomeRecord.SalesIncomeID);
            return View(salesIncomeRecord);
        }

        // GET: SalesIncomeRecord/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesIncomeRecord salesIncomeRecord = await db.SalesIncomeRecords.FindAsync(id);
            if (salesIncomeRecord == null)
            {
                return HttpNotFound();
            }
            return View(salesIncomeRecord);
        }

        // POST: SalesIncomeRecord/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            SalesIncomeRecord salesIncomeRecord = await db.SalesIncomeRecords.FindAsync(id);
            db.SalesIncomeRecords.Remove(salesIncomeRecord);
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
