using biblioteca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace biblioteca.Controllers
{
    public class librosController : Controller
    {
        private bibliotecaModel db = new bibliotecaModel();
        // GET: libros
        public ActionResult Index()
        {
            return View(db.libro.ToList());
        }

        public ActionResult New()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult New([Bind(Include ="idlibro, titulo, autor, paginas, estado, fecha_pub")]libro libro)
        {
            if (ModelState.IsValid)
            {
                libro.estado = "Activo";
                db.libro.Add(libro);
                db.SaveChanges();
                TempData["mensaje"] = "¡Libro Guardado!";
                return RedirectToAction("New");
            }
            return View(libro);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
                libro lib = db.libro.Find(id);
                db.libro.Remove(lib);
                db.SaveChanges();

                return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            
            libro lib = db.libro.Find(id);
            if(lib != null)
            {
                return View(lib);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idlibro, titulo, autor, paginas, estado, fecha_pub")] libro libro)
        {
            if (ModelState.IsValid)
            {
                libro.estado = "Activo";
                db.Entry(libro).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                TempData["mensaje"] = "¡Libro modificado!";
                //return RedirectToAction("Index");
            }
            return View(libro);
        }
    }
}