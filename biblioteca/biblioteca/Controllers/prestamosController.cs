using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using biblioteca.Models;

namespace biblioteca.Controllers
{
    public class prestamosController : Controller
    {
        private bibliotecaModel db = new bibliotecaModel();

        // GET: prestamos
        public ActionResult Index()
        {
            var prestamo = db.prestamo.Include(p => p.cliente).Include(p => p.libro);
            return View(prestamo.ToList());
        }

        // GET: prestamos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            prestamo prestamo = db.prestamo.Find(id);
            if (prestamo == null)
            {
                return HttpNotFound();
            }
            return View(prestamo);
        }

        // GET: prestamos/Create
        public ActionResult Create()
        {
            ViewBag.idcliente = new SelectList(db.cliente, "idcliente", "nombre");
            ViewBag.idlibro = new SelectList(db.libro, "idlibro", "titulo");
            return View();
        }

        // POST: prestamos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idprestamo,idcliente,idlibro,fecha_salida,estado,fecha_devolucion")] prestamo prestamo)
        {
            if (ModelState.IsValid)
            {
                prestamo.estado = "Prestado";
                db.prestamo.Add(prestamo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idcliente = new SelectList(db.cliente, "idcliente", "nombre", prestamo.idcliente);
            ViewBag.idlibro = new SelectList(db.libro, "idlibro", "titulo", prestamo.idlibro);
            return View(prestamo);
        }

        // GET: prestamos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            prestamo prestamo = db.prestamo.Find(id);
            if (prestamo == null)
            {
                return HttpNotFound();
            }
            ViewBag.idcliente = new SelectList(db.cliente, "idcliente", "nombre", prestamo.idcliente);
            ViewBag.idlibro = new SelectList(db.libro, "idlibro", "titulo", prestamo.idlibro);
            return View(prestamo);
        }

        // POST: prestamos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idprestamo,idcliente,idlibro,fecha_salida,estado,fecha_devolucion")] prestamo prestamo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prestamo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idcliente = new SelectList(db.cliente, "idcliente", "nombre", prestamo.idcliente);
            ViewBag.idlibro = new SelectList(db.libro, "idlibro", "titulo", prestamo.idlibro);
            return View(prestamo);
        }

        // GET: prestamos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            prestamo prestamo = db.prestamo.Find(id);
            if (prestamo == null)
            {
                return HttpNotFound();
            }
            return View(prestamo);
        }

        // POST: prestamos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            prestamo prestamo = db.prestamo.Find(id);
            db.prestamo.Remove(prestamo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Retorno(int id)
        {
            prestamo prestamo = db.prestamo.Find(id);
            prestamo.estado = "Devuelto";
            prestamo.fecha_devolucion = DateTime.Now.Date;
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
