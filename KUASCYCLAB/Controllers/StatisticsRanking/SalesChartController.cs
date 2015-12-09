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

namespace KUASCYCLAB.Controllers.StatisticsRanking
{
    public class SalesChartController : Controller
    {
        private KUASCYCEntities db = new KUASCYCEntities();

        // GET: SalesChart
        public async Task<ActionResult> Index()
        {
            var salesCharts = db.SalesCharts.Include(s => s.PackingList);
            return View(await salesCharts.ToListAsync());
        }

        // GET: SalesChart/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesChart salesChart = await db.SalesCharts.FindAsync(id);
            if (salesChart == null)
            {
                return HttpNotFound();
            }
            return View(salesChart);
        }

        // GET: SalesChart/Create
        public ActionResult Create()
        {
            ViewBag.PackingListID = new SelectList(db.PackingLists, "PackingListID", "Deliveryman");
            return View();
        }

        // POST: SalesChart/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "SalesChartsID,AnnualRanking,TopRanking,LessPopularRanking,TopRankingName,LessPopularRankingName,TopProductSpecifications,Less_popular_Product_Specifications,PackingListID")] SalesChart salesChart)
        {
            if (ModelState.IsValid)
            {
                salesChart.SalesChartsID = Guid.NewGuid();
                db.SalesCharts.Add(salesChart);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.PackingListID = new SelectList(db.PackingLists, "PackingListID", "Deliveryman", salesChart.PackingListID);
            return View(salesChart);
        }

        // GET: SalesChart/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesChart salesChart = await db.SalesCharts.FindAsync(id);
            if (salesChart == null)
            {
                return HttpNotFound();
            }
            ViewBag.PackingListID = new SelectList(db.PackingLists, "PackingListID", "Deliveryman", salesChart.PackingListID);
            return View(salesChart);
        }

        // POST: SalesChart/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "SalesChartsID,AnnualRanking,TopRanking,LessPopularRanking,TopRankingName,LessPopularRankingName,TopProductSpecifications,Less_popular_Product_Specifications,PackingListID")] SalesChart salesChart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salesChart).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PackingListID = new SelectList(db.PackingLists, "PackingListID", "Deliveryman", salesChart.PackingListID);
            return View(salesChart);
        }

        // GET: SalesChart/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesChart salesChart = await db.SalesCharts.FindAsync(id);
            if (salesChart == null)
            {
                return HttpNotFound();
            }
            return View(salesChart);
        }

        // POST: SalesChart/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            SalesChart salesChart = await db.SalesCharts.FindAsync(id);
            db.SalesCharts.Remove(salesChart);
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
