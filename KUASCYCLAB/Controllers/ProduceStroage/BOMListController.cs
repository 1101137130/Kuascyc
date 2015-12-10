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

namespace KUASCYCLAB.Controllers.ProduceStroage
{
    [Authorize]
    public class BOMListController : Controller
    {
        private KUASCYCEntities db = new KUASCYCEntities();

        // GET: BOMList
        public async Task<ActionResult> Index()
        {
            var bOMLists = db.BOMLists.Include(b => b.Product);
            return View(await bOMLists.ToListAsync());
        }

        // GET: BOMList/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOMList bOMList = await db.BOMLists.FindAsync(id);
            if (bOMList == null)
            {
                return HttpNotFound();
            }
            return View(bOMList);
        }

        // GET: BOMList/Create
        public ActionResult Create()
        {
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName");
            return View();
        }

        // POST: BOMList/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "BOMID,MaterialName,MaterialQuantity,ProductID")] BOMList bOMList)
        {
            if (ModelState.IsValid)
            {
                bOMList.BOMID = Guid.NewGuid();
                db.BOMLists.Add(bOMList);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", bOMList.ProductID);
            return View(bOMList);
        }

        // GET: BOMList/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOMList bOMList = await db.BOMLists.FindAsync(id);
            if (bOMList == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", bOMList.ProductID);
            return View(bOMList);
        }

        // POST: BOMList/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "BOMID,MaterialName,MaterialQuantity,ProductID")] BOMList bOMList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bOMList).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ProductID = new SelectList(db.Products, "ProductID", "ProductName", bOMList.ProductID);
            return View(bOMList);
        }

        // GET: BOMList/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BOMList bOMList = await db.BOMLists.FindAsync(id);
            if (bOMList == null)
            {
                return HttpNotFound();
            }
            return View(bOMList);
        }

        // POST: BOMList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            BOMList bOMList = await db.BOMLists.FindAsync(id);
            db.BOMLists.Remove(bOMList);
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
