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
    public class HeroiController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Heroi
        public async Task<ActionResult> Index()
        {
            var herois = db.Herois.Include(h => h.Universo);
            return View(await herois.ToListAsync());
        }

        // GET: Heroi/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Heroi heroi = await db.Herois.FindAsync(id);
            if (heroi == null)
            {
                return HttpNotFound();
            }
            return View(heroi);
        }

        // GET: Heroi/Create
        public ActionResult Create()
        {
            ViewBag.UniversoID = new SelectList(db.Universoes, "UniversoID", "Nome");
            return View();
        }

        // POST: Heroi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "HeroiID,UniversoID,Nome")] Heroi heroi)
        {
            if (ModelState.IsValid)
            {
                db.Herois.Add(heroi);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.UniversoID = new SelectList(db.Universoes, "UniversoID", "Nome", heroi.UniversoID);
            return View(heroi);
        }

        // GET: Heroi/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Heroi heroi = await db.Herois.FindAsync(id);
            if (heroi == null)
            {
                return HttpNotFound();
            }
            ViewBag.UniversoID = new SelectList(db.Universoes, "UniversoID", "Nome", heroi.UniversoID);
            return View(heroi);
        }

        // POST: Heroi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "HeroiID,UniversoID,Nome")] Heroi heroi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(heroi).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.UniversoID = new SelectList(db.Universoes, "UniversoID", "Nome", heroi.UniversoID);
            return View(heroi);
        }

        // GET: Heroi/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Heroi heroi = await db.Herois.FindAsync(id);
            if (heroi == null)
            {
                return HttpNotFound();
            }
            return View(heroi);
        }

        // POST: Heroi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Heroi heroi = await db.Herois.FindAsync(id);
            db.Herois.Remove(heroi);
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
