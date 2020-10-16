using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Contact4.Models;

namespace Contact4.Controllers
{
    public class ContactDepartsController : Controller
    {
        private Contact4Context db = new Contact4Context();

        // GET: ContactDeparts
        public ActionResult Index()
        {
            var contactDeparts = db.ContactDeparts.Include(c => c.Contacts).Include(c => c.Departs);
            return View(contactDeparts.ToList());
        }

        // GET: ContactDeparts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactDepart contactDepart = db.ContactDeparts.Find(id);
            if (contactDepart == null)
            {
                return HttpNotFound();
            }
            return View(contactDepart);
        }

        // GET: ContactDeparts/Create
        public ActionResult Create()
        {
            ViewBag.ContactoId = new SelectList(db.Contactoes, "Id", "Nombre");
            ViewBag.DepartamentoId = new SelectList(db.Departamentoes, "Id", "NameDepartamento");
            return View();
        }

        // POST: ContactDeparts/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ContactoId,DepartamentoId")] ContactDepart contactDepart)
        {
            if (ModelState.IsValid)
            {
                db.ContactDeparts.Add(contactDepart);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContactoId = new SelectList(db.Contactoes, "Id", "Nombre", contactDepart.ContactoId);
            ViewBag.DepartamentoId = new SelectList(db.Departamentoes, "Id", "NameDepartamento", contactDepart.DepartamentoId);
            return View(contactDepart);
        }

        // GET: ContactDeparts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactDepart contactDepart = db.ContactDeparts.Find(id);
            if (contactDepart == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContactoId = new SelectList(db.Contactoes, "Id", "Nombre", contactDepart.ContactoId);
            ViewBag.DepartamentoId = new SelectList(db.Departamentoes, "Id", "NameDepartamento", contactDepart.DepartamentoId);
            return View(contactDepart);
        }

        // POST: ContactDeparts/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ContactoId,DepartamentoId")] ContactDepart contactDepart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactDepart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContactoId = new SelectList(db.Contactoes, "Id", "Nombre", contactDepart.ContactoId);
            ViewBag.DepartamentoId = new SelectList(db.Departamentoes, "Id", "NameDepartamento", contactDepart.DepartamentoId);
            return View(contactDepart);
        }

        // GET: ContactDeparts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactDepart contactDepart = db.ContactDeparts.Find(id);
            if (contactDepart == null)
            {
                return HttpNotFound();
            }
            return View(contactDepart);
        }

        // POST: ContactDeparts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContactDepart contactDepart = db.ContactDeparts.Find(id);
            db.ContactDeparts.Remove(contactDepart);
            db.SaveChanges();
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
