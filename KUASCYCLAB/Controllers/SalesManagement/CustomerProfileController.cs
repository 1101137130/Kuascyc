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
    public class CustomerProfileController : Controller
    {
        private KUASCYCEntities db = new KUASCYCEntities();

        // GET: CustomerProfile
        public async Task<ActionResult> Index()
        {
            return View(await db.CustomerProfiles.ToListAsync());
        }

        // GET: CustomerProfile/Details/5
        public async Task<ActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerProfile customerProfile = await db.CustomerProfiles.FindAsync(id);
            if (customerProfile == null)
            {
                return HttpNotFound();
            }
            return View(customerProfile);
        }

        // GET: CustomerProfile/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerProfile/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CustomerID,CustomerName,ContactsPhone,E_MAIL,Address,ResponsiblePerson,RemittanceAccount")] CustomerProfile customerProfile)
        {
            if (ModelState.IsValid)
            {
                customerProfile.CustomerID = Guid.NewGuid();
                db.CustomerProfiles.Add(customerProfile);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(customerProfile);
        }

        // GET: CustomerProfile/Edit/5
        public async Task<ActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerProfile customerProfile = await db.CustomerProfiles.FindAsync(id);
            if (customerProfile == null)
            {
                return HttpNotFound();
            }
            return View(customerProfile);
        }

        // POST: CustomerProfile/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CustomerID,CustomerName,ContactsPhone,E_MAIL,Address,ResponsiblePerson,RemittanceAccount")] CustomerProfile customerProfile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerProfile).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(customerProfile);
        }

        // GET: CustomerProfile/Delete/5
        public async Task<ActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerProfile customerProfile = await db.CustomerProfiles.FindAsync(id);
            if (customerProfile == null)
            {
                return HttpNotFound();
            }
            return View(customerProfile);
        }

        // POST: CustomerProfile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            CustomerProfile customerProfile = await db.CustomerProfiles.FindAsync(id);
            db.CustomerProfiles.Remove(customerProfile);
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
