using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HeroisCRUD.Models;

namespace HeroisCRUD.Controllers
{
    public class UniversoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Universo
        public async Task<ActionResult> Index()
        {
            return View(await db.Universoes.ToListAsync());
        }

        // GET: Universo/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Universo universo = await db.Universoes.FindAsync(id);
            if (universo == null)
            {
                return HttpNotFound();
            }
            return View(universo);
        }

        // GET: Universo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Universo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "UniversoID,Nome")] Universo universo)
        {
            if (ModelState.IsValid)
            {
                db.Universoes.Add(universo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(universo);
        }

        // GET: Universo/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Universo universo = await db.Universoes.FindAsync(id);
            if (universo == null)
            {
                return HttpNotFound();
            }
            return View(universo);
        }

        // POST: Universo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "UniversoID,Nome")] Universo universo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(universo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(universo);
        }

        // GET: Universo/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Universo universo = await db.Universoes.FindAsync(id);
            if (universo == null)
            {
                return HttpNotFound();
            }
            return View(universo);
        }

        // POST: Universo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Universo universo = await db.Universoes.FindAsync(id);
            db.Universoes.Remove(universo);
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
