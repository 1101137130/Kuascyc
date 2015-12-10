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
    public class ProductionOrderController : Controller
    {
        private KUASCYCEntities db = new KUASCYCEntities();

        // GET: ProductionOrder
        public async Task<ActionResult> Index()
        {
            var productionOrders = db.ProductionOrders.Include(p => p.BOMList);
            return View(await productionOrders.ToListAsync());
        }

        // GET: ProductionOrder/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductionOrder productionOrder = await db.ProductionOrders.FindAsync(id);
            if (productionOrder == null)
            {
                return HttpNotFound();
            }
            return View(productionOrder);
        }

        // GET: ProductionOrder/Create
        public ActionResult Create()
        {
            ViewBag.BOMID = new SelectList(db.BOMLists, "BOMID", "MaterialName");
            return View();
        }

        // POST: ProductionOrder/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ProductionOrderID,StartProductionDate,Closingdate,ProductionProductName,ProductionProductSpecifications,QuantityProduction,TotalQuantityProduction,CangguanApplyEmployee,ProductionProcessingEmployee,Remark,BOMID")] ProductionOrder productionOrder)
        {
            if (ModelState.IsValid)
            {
                productionOrder.ProductionOrderID = Guid.NewGuid();
                db.ProductionOrders.Add(productionOrder);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.BOMID = new SelectList(db.BOMLists, "BOMID", "MaterialName", productionOrder.BOMID);
            return View(productionOrder);
        }

        // GET: ProductionOrder/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductionOrder productionOrder = await db.ProductionOrders.FindAsync(id);
            if (productionOrder == null)
            {
                return HttpNotFound();
            }
            ViewBag.BOMID = new SelectList(db.BOMLists, "BOMID", "MaterialName", productionOrder.BOMID);
            return View(productionOrder);
        }

        // POST: ProductionOrder/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ProductionOrderID,StartProductionDate,Closingdate,ProductionProductName,ProductionProductSpecifications,QuantityProduction,TotalQuantityProduction,CangguanApplyEmployee,ProductionProcessingEmployee,Remark,BOMID")] ProductionOrder productionOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productionOrder).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.BOMID = new SelectList(db.BOMLists, "BOMID", "MaterialName", productionOrder.BOMID);
            return View(productionOrder);
        }

        // GET: ProductionOrder/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductionOrder productionOrder = await db.ProductionOrders.FindAsync(id);
            if (productionOrder == null)
            {
                return HttpNotFound();
            }
            return View(productionOrder);
        }

        // POST: ProductionOrder/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            ProductionOrder productionOrder = await db.ProductionOrders.FindAsync(id);
            db.ProductionOrders.Remove(productionOrder);
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
