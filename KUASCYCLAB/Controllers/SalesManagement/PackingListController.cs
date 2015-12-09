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
    public class PackingListController : Controller
    {
        private KUASCYCEntities db = new KUASCYCEntities();

        // GET: PackingList
        public async Task<ActionResult> Index()
        {
            var packingLists = db.PackingLists.Include(p => p.SalesOrder);
            return View(await packingLists.ToListAsync());
        }

        // GET: PackingList/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PackingList packingList = await db.PackingLists.FindAsync(id);
            if (packingList == null)
            {
                return HttpNotFound();
            }
            return View(packingList);
        }

        // GET: PackingList/Create
        public ActionResult Create()
        {
            ViewBag.SalesOrderID = new SelectList(db.SalesOrders, "SalesOrderID", "ToName");
            return View();
        }

        // POST: PackingList/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PackingListID,DeliveryDate,Deliveryman,WarehouseStaff,BusinessProcessEmployee,Remark,SalesOrderID")] PackingList packingList)
        {
            if (ModelState.IsValid)
            {
                packingList.PackingListID = Guid.NewGuid();
                db.PackingLists.Add(packingList);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.SalesOrderID = new SelectList(db.SalesOrders, "SalesOrderID", "ToName", packingList.SalesOrderID);
            return View(packingList);
        }

        // GET: PackingList/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PackingList packingList = await db.PackingLists.FindAsync(id);
            if (packingList == null)
            {
                return HttpNotFound();
            }
            ViewBag.SalesOrderID = new SelectList(db.SalesOrders, "SalesOrderID", "ToName", packingList.SalesOrderID);
            return View(packingList);
        }

        // POST: PackingList/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PackingListID,DeliveryDate,Deliveryman,WarehouseStaff,BusinessProcessEmployee,Remark,SalesOrderID")] PackingList packingList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(packingList).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.SalesOrderID = new SelectList(db.SalesOrders, "SalesOrderID", "ToName", packingList.SalesOrderID);
            return View(packingList);
        }

        // GET: PackingList/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PackingList packingList = await db.PackingLists.FindAsync(id);
            if (packingList == null)
            {
                return HttpNotFound();
            }
            return View(packingList);
        }

        // POST: PackingList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            PackingList packingList = await db.PackingLists.FindAsync(id);
            db.PackingLists.Remove(packingList);
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
