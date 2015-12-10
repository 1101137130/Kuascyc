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
    [Authorize]
    public class QuotationController : Controller
    {
        private KUASCYCEntities db = new KUASCYCEntities();

        // GET: Quotation
        public async Task<ActionResult> Index()
        {
            var quotations = db.Quotations.Include(q => q.Inquiry);
            return View(await quotations.ToListAsync());
        }

        // GET: Quotation/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quotation quotation = await db.Quotations.FindAsync(id);
            if (quotation == null)
            {
                return HttpNotFound();
            }
            return View(quotation);
        }

        // GET: Quotation/Create
        public ActionResult Create()
        {
            ViewBag.InquiryID = new SelectList(db.Inquiries, "InquiryID", "InquiryName");
            return View();
        }

        // POST: Quotation/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "QuotationID,BusinessOrdersEmployee,QuoteDate,OfferAmount,Remark,InquiryID")] Quotation quotation)
        {
            if (ModelState.IsValid)
            {
                quotation.QuotationID = Guid.NewGuid();
                db.Quotations.Add(quotation);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.InquiryID = new SelectList(db.Inquiries, "InquiryID", "InquiryName", quotation.InquiryID);
            return View(quotation);
        }

        // GET: Quotation/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quotation quotation = await db.Quotations.FindAsync(id);
            if (quotation == null)
            {
                return HttpNotFound();
            }
            ViewBag.InquiryID = new SelectList(db.Inquiries, "InquiryID", "InquiryName", quotation.InquiryID);
            return View(quotation);
        }

        // POST: Quotation/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "QuotationID,BusinessOrdersEmployee,QuoteDate,OfferAmount,Remark,InquiryID")] Quotation quotation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quotation).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.InquiryID = new SelectList(db.Inquiries, "InquiryID", "InquiryName", quotation.InquiryID);
            return View(quotation);
        }

        // GET: Quotation/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quotation quotation = await db.Quotations.FindAsync(id);
            if (quotation == null)
            {
                return HttpNotFound();
            }
            return View(quotation);
        }

        // POST: Quotation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Quotation quotation = await db.Quotations.FindAsync(id);
            db.Quotations.Remove(quotation);
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
