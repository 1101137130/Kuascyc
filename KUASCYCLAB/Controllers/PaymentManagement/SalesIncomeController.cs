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
    public class SalesIncomeController : Controller
    {
        private KUASCYCEntities db = new KUASCYCEntities();

        // GET: SalesIncome
        public async Task<ActionResult> Index()
        {
            var salesIncomes = db.SalesIncomes.Include(s => s.SalesRequestPayment);
            return View(await salesIncomes.ToListAsync());
        }

        // GET: SalesIncome/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesIncome salesIncome = await db.SalesIncomes.FindAsync(id);
            if (salesIncome == null)
            {
                return HttpNotFound();
            }
            return View(salesIncome);
        }

        // GET: SalesIncome/Create
        public ActionResult Create()
        {
            ViewBag.SalesRequestPaymentID = new SelectList(db.SalesRequestPayments, "SalesRequestPaymentID", "Payer");
            return View();
        }

        // POST: SalesIncome/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SalesIncomeID,Date,Remark,Payer,AccountingDepartmentEmployee,SalesRequestPaymentID")] SalesIncome salesIncome)
        {
            if (ModelState.IsValid)
            {
                salesIncome.SalesIncomeID = Guid.NewGuid();
                db.SalesIncomes.Add(salesIncome);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.SalesRequestPaymentID = new SelectList(db.SalesRequestPayments, "SalesRequestPaymentID", "Payer", salesIncome.SalesRequestPaymentID);
            return View(salesIncome);
        }

        // GET: SalesIncome/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesIncome salesIncome = await db.SalesIncomes.FindAsync(id);
            if (salesIncome == null)
            {
                return HttpNotFound();
            }
            ViewBag.SalesRequestPaymentID = new SelectList(db.SalesRequestPayments, "SalesRequestPaymentID", "Payer", salesIncome.SalesRequestPaymentID);
            return View(salesIncome);
        }

        // POST: SalesIncome/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SalesIncomeID,Date,Remark,Payer,AccountingDepartmentEmployee,SalesRequestPaymentID")] SalesIncome salesIncome)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salesIncome).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.SalesRequestPaymentID = new SelectList(db.SalesRequestPayments, "SalesRequestPaymentID", "Payer", salesIncome.SalesRequestPaymentID);
            return View(salesIncome);
        }

        // GET: SalesIncome/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesIncome salesIncome = await db.SalesIncomes.FindAsync(id);
            if (salesIncome == null)
            {
                return HttpNotFound();
            }
            return View(salesIncome);
        }

        // POST: SalesIncome/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            SalesIncome salesIncome = await db.SalesIncomes.FindAsync(id);
            db.SalesIncomes.Remove(salesIncome);
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
