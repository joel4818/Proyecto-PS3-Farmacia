using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoFarmaciaWeb.Models;

namespace ProyectoFarmaciaWeb.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            //DataBase
            DataBase db = new DataBase();

            var listuser =  db.Usuarios.ToList();
            
            return new JsonResult
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = listuser
            };
        }
    }
}