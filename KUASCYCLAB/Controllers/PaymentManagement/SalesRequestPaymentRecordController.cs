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
    public class SalesRequestPaymentRecordController : Controller
    {
        private KUASCYCEntities db = new KUASCYCEntities();

        // GET: SalesRequestPaymentRecord
        public async Task<ActionResult> Index()
        {
            var salesRequestPaymentRecords = db.SalesRequestPaymentRecords.Include(s => s.PackingList);
            return View(await salesRequestPaymentRecords.ToListAsync());
        }

        // GET: SalesRequestPaymentRecord/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesRequestPaymentRecord salesRequestPaymentRecord = await db.SalesRequestPaymentRecords.FindAsync(id);
            if (salesRequestPaymentRecord == null)
            {
                return HttpNotFound();
            }
            return View(salesRequestPaymentRecord);
        }

        // GET: SalesRequestPaymentRecord/Create
        public ActionResult Create()
        {
            ViewBag.PackingListID = new SelectList(db.PackingLists, "PackingListID", "Deliveryman");
            return View();
        }

        // POST: SalesRequestPaymentRecord/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SalesRequestPaymentRecordID,Date,Status,Remark,AccountingDepartmentEmployee,PackingListID")] SalesRequestPaymentRecord salesRequestPaymentRecord)
        {
            if (ModelState.IsValid)
            {
                salesRequestPaymentRecord.SalesRequestPaymentRecordID = Guid.NewGuid();
                db.SalesRequestPaymentRecords.Add(salesRequestPaymentRecord);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.PackingListID = new SelectList(db.PackingLists, "PackingListID", "Deliveryman", salesRequestPaymentRecord.PackingListID);
            return View(salesRequestPaymentRecord);
        }

        // GET: SalesRequestPaymentRecord/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesRequestPaymentRecord salesRequestPaymentRecord = await db.SalesRequestPaymentRecords.FindAsync(id);
            if (salesRequestPaymentRecord == null)
            {
                return HttpNotFound();
            }
            ViewBag.PackingListID = new SelectList(db.PackingLists, "PackingListID", "Deliveryman", salesRequestPaymentRecord.PackingListID);
            return View(salesRequestPaymentRecord);
        }

        // POST: SalesRequestPaymentRecord/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SalesRequestPaymentRecordID,Date,Status,Remark,AccountingDepartmentEmployee,PackingListID")] SalesRequestPaymentRecord salesRequestPaymentRecord)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salesRequestPaymentRecord).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PackingListID = new SelectList(db.PackingLists, "PackingListID", "Deliveryman", salesRequestPaymentRecord.PackingListID);
            return View(salesRequestPaymentRecord);
        }

        // GET: SalesRequestPaymentRecord/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesRequestPaymentRecord salesRequestPaymentRecord = await db.SalesRequestPaymentRecords.FindAsync(id);
            if (salesRequestPaymentRecord == null)
            {
                return HttpNotFound();
            }
            return View(salesRequestPaymentRecord);
        }

        // POST: SalesRequestPaymentRecord/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            SalesRequestPaymentRecord salesRequestPaymentRecord = await db.SalesRequestPaymentRecords.FindAsync(id);
            db.SalesRequestPaymentRecords.Remove(salesRequestPaymentRecord);
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
