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
    public class SalesReturnController : Controller
    {
        private KUASCYCEntities db = new KUASCYCEntities();

        // GET: SalesReturn
        public async Task<ActionResult> Index()
        {
            var salesReturns = db.SalesReturns.Include(s => s.PackingList);
            return View(await salesReturns.ToListAsync());
        }

        // GET: SalesReturn/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesReturn salesReturn = await db.SalesReturns.FindAsync(id);
            if (salesReturn == null)
            {
                return HttpNotFound();
            }
            return View(salesReturn);
        }

        // GET: SalesReturn/Create
        public ActionResult Create()
        {
            ViewBag.PackingListID = new SelectList(db.PackingLists, "PackingListID", "Deliveryman");
            return View();
        }

        // POST: SalesReturn/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SalesReturnsID,ReturnDate,ReturnsNames,ReturnPersonPhone,ReturnReason,ReturnQty,ReturnTotalQty,ReturnMoney,ReturnsTotalAmount,Remark,BusinessProcessEmployee,PackingListID")] SalesReturn salesReturn)
        {
            if (ModelState.IsValid)
            {
                salesReturn.SalesReturnsID = Guid.NewGuid();
                db.SalesReturns.Add(salesReturn);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.PackingListID = new SelectList(db.PackingLists, "PackingListID", "Deliveryman", salesReturn.PackingListID);
            return View(salesReturn);
        }

        // GET: SalesReturn/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesReturn salesReturn = await db.SalesReturns.FindAsync(id);
            if (salesReturn == null)
            {
                return HttpNotFound();
            }
            ViewBag.PackingListID = new SelectList(db.PackingLists, "PackingListID", "Deliveryman", salesReturn.PackingListID);
            return View(salesReturn);
        }

        // POST: SalesReturn/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SalesReturnsID,ReturnDate,ReturnsNames,ReturnPersonPhone,ReturnReason,ReturnQty,ReturnTotalQty,ReturnMoney,ReturnsTotalAmount,Remark,BusinessProcessEmployee,PackingListID")] SalesReturn salesReturn)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salesReturn).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PackingListID = new SelectList(db.PackingLists, "PackingListID", "Deliveryman", salesReturn.PackingListID);
            return View(salesReturn);
        }

        // GET: SalesReturn/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesReturn salesReturn = await db.SalesReturns.FindAsync(id);
            if (salesReturn == null)
            {
                return HttpNotFound();
            }
            return View(salesReturn);
        }

        // POST: SalesReturn/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            SalesReturn salesReturn = await db.SalesReturns.FindAsync(id);
            db.SalesReturns.Remove(salesReturn);
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
