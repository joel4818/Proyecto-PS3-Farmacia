using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Security;
using System.Web.Mvc;
using ProyectoFarmaciaWeb.Models;

namespace ProyectoFarmaciaWeb.Controllers
{
    public class HomeController : Controller
    {
        private DataBase db = new DataBase();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Login(string message = "")
        {
            ViewBag.Message = message;
            return View();
        }
        [HttpPost]
        public ActionResult Loguearse(string email, string password)
        {

            if(!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                DataBase db = new DataBase();
                
                var user = db.Usuarios.FirstOrDefault(e => e.Nombre_Usuario == email && e.Contrasenia == password);
                if (user != null)
                {
                    //Usuario encontrado
                    FormsAuthentication.SetAuthCookie(user.Nombre_Usuario, true);
                    return RedirectToAction("Index", "Productos");
                }
                else
                {
                    //return Login("No encontramos tus datos");
                    return RedirectToAction("Login", new { message = "Usuario inexistente" });
                }
            }
            else
            {
                return Login("Llena los campos para iniciar sesion");
            }
        }
        //Metodo para cerrar sesion 
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
        public ActionResult Mapa()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios usuarios = db.Usuarios.Find(User.Identity.Name);
            if (usuarios == null)
            {
                return HttpNotFound();
            }
            ViewBag.Codigo_Tipo_Usuario = new SelectList(db.Tipo_Usuario, "Codigo_Tipo_Usuario", "Tipo_Usuario1", usuarios.Codigo_Tipo_Usuario);
            return View();
        }/*
        public ActionResult Edit([Bind(Include = "Nombre_Usuario,Contrasenia,Codigo_Tipo_Usuario")] Usuarios usuarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Codigo_Tipo_Usuario = new SelectList(db.Tipo_Usuario, "Codigo_Tipo_Usuario", "Tipo_Usuario1", usuarios.Codigo_Tipo_Usuario);
            return View(usuarios);
        }*/

    }
}