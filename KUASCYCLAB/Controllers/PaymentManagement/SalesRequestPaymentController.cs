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
    public class SalesRequestPaymentController : Controller
    {
        private KUASCYCEntities db = new KUASCYCEntities();

        // GET: SalesRequestPayment
        public async Task<ActionResult> Index()
        {
            var salesRequestPayments = db.SalesRequestPayments.Include(s => s.SalesRequestPaymentRecord);
            return View(await salesRequestPayments.ToListAsync());
        }

        // GET: SalesRequestPayment/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesRequestPayment salesRequestPayment = await db.SalesRequestPayments.FindAsync(id);
            if (salesRequestPayment == null)
            {
                return HttpNotFound();
            }
            return View(salesRequestPayment);
        }

        // GET: SalesRequestPayment/Create
        public ActionResult Create()
        {
            ViewBag.SalesRequestPaymentRecordID = new SelectList(db.SalesRequestPaymentRecords, "SalesRequestPaymentRecordID", "Remark");
            return View();
        }

        // POST: SalesRequestPayment/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SalesRequestPaymentID,RequestDate,ExportAccount,Deadline,AccountingStaff,Payer,SalesRequestPaymentRecordID")] SalesRequestPayment salesRequestPayment)
        {
            if (ModelState.IsValid)
            {
                salesRequestPayment.SalesRequestPaymentID = Guid.NewGuid();
                db.SalesRequestPayments.Add(salesRequestPayment);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.SalesRequestPaymentRecordID = new SelectList(db.SalesRequestPaymentRecords, "SalesRequestPaymentRecordID", "Remark", salesRequestPayment.SalesRequestPaymentRecordID);
            return View(salesRequestPayment);
        }

        // GET: SalesRequestPayment/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesRequestPayment salesRequestPayment = await db.SalesRequestPayments.FindAsync(id);
            if (salesRequestPayment == null)
            {
                return HttpNotFound();
            }
            ViewBag.SalesRequestPaymentRecordID = new SelectList(db.SalesRequestPaymentRecords, "SalesRequestPaymentRecordID", "Remark", salesRequestPayment.SalesRequestPaymentRecordID);
            return View(salesRequestPayment);
        }

        // POST: SalesRequestPayment/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SalesRequestPaymentID,RequestDate,ExportAccount,Deadline,AccountingStaff,Payer,SalesRequestPaymentRecordID")] SalesRequestPayment salesRequestPayment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salesRequestPayment).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.SalesRequestPaymentRecordID = new SelectList(db.SalesRequestPaymentRecords, "SalesRequestPaymentRecordID", "Remark", salesRequestPayment.SalesRequestPaymentRecordID);
            return View(salesRequestPayment);
        }

        // GET: SalesRequestPayment/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesRequestPayment salesRequestPayment = await db.SalesRequestPayments.FindAsync(id);
            if (salesRequestPayment == null)
            {
                return HttpNotFound();
            }
            return View(salesRequestPayment);
        }

        // POST: SalesRequestPayment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            SalesRequestPayment salesRequestPayment = await db.SalesRequestPayments.FindAsync(id);
            db.SalesRequestPayments.Remove(salesRequestPayment);
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
