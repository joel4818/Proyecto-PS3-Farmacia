using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoFarmaciaWeb.Models;

namespace ProyectoFarmaciaWeb.Controllers
{
    public class ProductosController : Controller
    {
        private DataBase db = new DataBase();

        // GET: Productos
        public ActionResult Index()
        {
            var producto = db.Producto.Include(p => p.Categoria).Include(p => p.Proveedor);
            return View(producto.ToList());
        }

        // GET: Productos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // GET: Productos/Create
        public ActionResult Create()
        {
            ViewBag.Codigo_Categoria = new SelectList(db.Categoria, "Codigo_Categoria", "Nombre_Categoria");
            ViewBag.Codigo_Proveedor = new SelectList(db.Proveedor, "Codigo_Proveedor", "Nombre_Proveedor");
            return View();
        }

        // POST: Productos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Codigo_Producto,Nombre_Producto,Fecha_Vencimiento,Stock,Precio_Unitario,Codigo_Categoria,Codigo_Proveedor,Descripcion")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Producto.Add(producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Codigo_Categoria = new SelectList(db.Categoria, "Codigo_Categoria", "Nombre_Categoria", producto.Codigo_Categoria);
            ViewBag.Codigo_Proveedor = new SelectList(db.Proveedor, "Codigo_Proveedor", "Nombre_Proveedor", producto.Codigo_Proveedor);
            return View(producto);
        }

        // GET: Productos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.Codigo_Categoria = new SelectList(db.Categoria, "Codigo_Categoria", "Nombre_Categoria", producto.Codigo_Categoria);
            ViewBag.Codigo_Proveedor = new SelectList(db.Proveedor, "Codigo_Proveedor", "Nombre_Proveedor", producto.Codigo_Proveedor);
            return View(producto);
        }

        // POST: Productos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Codigo_Producto,Nombre_Producto,Fecha_Vencimiento,Stock,Precio_Unitario,Codigo_Categoria,Codigo_Proveedor,Descripcion")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Codigo_Categoria = new SelectList(db.Categoria, "Codigo_Categoria", "Nombre_Categoria", producto.Codigo_Categoria);
            ViewBag.Codigo_Proveedor = new SelectList(db.Proveedor, "Codigo_Proveedor", "Nombre_Proveedor", producto.Codigo_Proveedor);
            return View(producto);
        }

        // GET: Productos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Producto producto = db.Producto.Find(id);
            db.Producto.Remove(producto);
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
        



        public ActionResult Carrtio(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }
        public ActionResult Carrito(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }


        public ActionResult Aumentar(int cantidad)
        {
            cantidad++;
            return RedirectToAction("Index", cantidad);
        }
        
    }
}
