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
    public class InquiryController : Controller
    {
        private KUASCYCEntities db = new KUASCYCEntities();

        // GET: Inquiry
        [Authorize]
        public async Task<ActionResult> Index()
        {
            var inquiries = db.Inquiries.Include(i => i.Product);
            return View(await inquiries.ToListAsync());
        }

        // GET: Inquiry/Details/5
        [Authorize]
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inquiry inquiry = await db.Inquiries.FindAsync(id);
            if (inquiry == null)
            {
                return HttpNotFound();
            }
            return View(inquiry);
        }
        public static string message = "";
        // GET: Inquiry/Create
        public ActionResult Create()
        {
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName");
            ViewBag.Message = message;
            message="";
            return View();
        }

        // POST: Inquiry/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "InquiryID,InquiryName,InquiryDate,ContactsPhone,E_MAIL,Qty,TotalQty,Remark,ProductID")] Inquiry inquiry)
        {
            if (ModelState.IsValid)
            {
               
                message = "新增成功!"; 
                inquiry.InquiryID = Guid.NewGuid();
                db.Inquiries.Add(inquiry);
                await db.SaveChangesAsync();
                return RedirectToAction("Create");
            }

            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", inquiry.ProductID);
            return View(inquiry);
        }

        // GET: Inquiry/Edit/5
        [Authorize]
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inquiry inquiry = await db.Inquiries.FindAsync(id);
            if (inquiry == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", inquiry.ProductID);
            return View(inquiry);
        }

        // POST: Inquiry/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "InquiryID,InquiryName,InquiryDate,ContactsPhone,E_MAIL,Qty,TotalQty,Remark,ProductID")] Inquiry inquiry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inquiry).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", inquiry.ProductID);
            return View(inquiry);
        }

        // GET: Inquiry/Delete/5
        [Authorize]
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inquiry inquiry = await db.Inquiries.FindAsync(id);
            if (inquiry == null)
            {
                return HttpNotFound();
            }
            return View(inquiry);
        }

        // POST: Inquiry/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            Inquiry inquiry = await db.Inquiries.FindAsync(id);
            db.Inquiries.Remove(inquiry);
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
