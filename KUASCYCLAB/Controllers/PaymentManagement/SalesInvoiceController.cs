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
    public class SalesInvoiceController : Controller
    {
        private KUASCYCEntities db = new KUASCYCEntities();

        // GET: SalesInvoice
        public async Task<ActionResult> Index()
        {
            var salesInvoice_ = db.SalesInvoice_.Include(s => s.SalesRequestPaymentRecord);
            return View(await salesInvoice_.ToListAsync());
        }

        // GET: SalesInvoice/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesInvoice_ salesInvoice_ = await db.SalesInvoice_.FindAsync(id);
            if (salesInvoice_ == null)
            {
                return HttpNotFound();
            }
            return View(salesInvoice_);
        }

        // GET: SalesInvoice/Create
        public ActionResult Create()
        {
            ViewBag.SalesRequestPaymentID = new SelectList(db.SalesRequestPaymentRecords, "SalesRequestPaymentRecordID", "Remark");
            return View();
        }

        // POST: SalesInvoice/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SalesInvoiceID,UniformID,InvoiceDate,OutputTaxCharges,AccountingDepartmentHandleEmployee,PayName,SalesRequestPaymentID")] SalesInvoice_ salesInvoice_)
        {
            if (ModelState.IsValid)
            {
                salesInvoice_.SalesInvoiceID = Guid.NewGuid();
                db.SalesInvoice_.Add(salesInvoice_);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.SalesRequestPaymentID = new SelectList(db.SalesRequestPaymentRecords, "SalesRequestPaymentRecordID", "Remark", salesInvoice_.SalesRequestPaymentID);
            return View(salesInvoice_);
        }

        // GET: SalesInvoice/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesInvoice_ salesInvoice_ = await db.SalesInvoice_.FindAsync(id);
            if (salesInvoice_ == null)
            {
                return HttpNotFound();
            }
            ViewBag.SalesRequestPaymentID = new SelectList(db.SalesRequestPaymentRecords, "SalesRequestPaymentRecordID", "Remark", salesInvoice_.SalesRequestPaymentID);
            return View(salesInvoice_);
        }

        // POST: SalesInvoice/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SalesInvoiceID,UniformID,InvoiceDate,OutputTaxCharges,AccountingDepartmentHandleEmployee,PayName,SalesRequestPaymentID")] SalesInvoice_ salesInvoice_)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salesInvoice_).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.SalesRequestPaymentID = new SelectList(db.SalesRequestPaymentRecords, "SalesRequestPaymentRecordID", "Remark", salesInvoice_.SalesRequestPaymentID);
            return View(salesInvoice_);
        }

        // GET: SalesInvoice/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesInvoice_ salesInvoice_ = await db.SalesInvoice_.FindAsync(id);
            if (salesInvoice_ == null)
            {
                return HttpNotFound();
            }
            return View(salesInvoice_);
        }

        // POST: SalesInvoice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            SalesInvoice_ salesInvoice_ = await db.SalesInvoice_.FindAsync(id);
            db.SalesInvoice_.Remove(salesInvoice_);
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
