using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoFarmaciaWeb.Models;

namespace ProyectoFarmaciaWeb.Controllers
{
    public class CarritoController : Controller
    {
        // GET: Carrito
        private DataBase db = new DataBase();

        //[HttpPost]
        //public JsonResult AgregarCarrito(int id, int cantidad)
        //{
        //    if (Session["carrito"] == null)
        //    {
        //        List<CarritoItem> compras = new List<CarritoItem>();
        //        compras.Add(new CarritoItem(db.Producto.Find(id), cantidad));
        //        Session["carrito"] = compras;
        //    }
        //    else
        //    {
        //        List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];
        //        int IndexExistente = getIndex(id);
        //        if (IndexExistente == -1)
        //            compras.Add(new CarritoItem(db.Producto.Find(id), 1));
        //        else
        //            compras[IndexExistente].Cantidad += cantidad;
        //        Session["carrito"] = compras;
        //    }
        //    return Json(new { response = true }, JsonRequestBehavior.AllowGet);
        //}

        //[HttpGet]
        //public ActionResult AgregarCarrito()
        //{
        //    return View();
        //}

        public ActionResult AgregarCarrito(int id)
        {
            //cmd.Open();
            if (Session["carrito"] == null)
            {
                List<CarritoItem> compras = new List<CarritoItem>();
                ClaseCompartida.tipoCliente = id;
                compras.Add(new CarritoItem(db.Producto.Find(id), 1));
                Session["carrito"] = compras;
            }
            else
            {
                List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];
                ClaseCompartida.tipoCliente = id;
                int IndexExistente = getIndex(id);
                if (IndexExistente == -1)
                    compras.Add(new CarritoItem(db.Producto.Find(id), 1));
                else
                    compras[IndexExistente].Cantidad += 1;
                Session["carrito"] = compras;
            }
            return View();
        }


        public ActionResult Delete(int id)
        {
            List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];
            compras.RemoveAt(getIndex(id));
            return View("AgregarCarrito");
        }
        
        public ActionResult FinalizarCompra(string direc, string desc)
        {
            List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];
            if (compras != null && compras.Count > 0)
            {
                for (int i = 0; i < compras.Count; i++)
                {


                    Detalle_Venta dventa = new Detalle_Venta();
                    var maxDetalle = (from g in db.Detalle_Venta
                                      select g.Codigo_Detalle).Max();
                    int maxDetallei = Convert.ToInt32(maxDetalle);

                    dventa.Codigo_Detalle = maxDetallei + 1;
                    dventa.Monto_Total = compras.Sum(x => x.Producto.Precio_Unitario * x.Cantidad);
                    dventa.Descripcion = ClaseCompartida.tipoCliente.ToString();

                    Venta nuevaVenta = new Venta();
                    //Sacar el maximo de nuestra tabla Venta
                    var maxVenta = (from g in db.Venta
                                    select g.Codigo_Venta).Max();
                    int maxVentai = Convert.ToInt32(maxVenta);
                    nuevaVenta.Codigo_Venta = maxVentai + 1;// Codigo Venta

                    nuevaVenta.Codigo_Cliente = 10; 
                    nuevaVenta.Id_Personas = 1; 

                    nuevaVenta.Codigo_Producto = ClaseCompartida.tipoCliente;
                                       

                    //nuevaVenta.Detalle_Venta = (from detalle in compras
                    //                            select new Detalle_Venta
                    //                            {
                    //                                Codigo_Detalle = maxDetallei + 1,
                    //                                Monto_Total = Convert.ToDouble(detalle.Cantidad * detalle.Producto.Precio_Unitario),
                    //                                Descripcion = detalle.Producto.Nombre_Producto
                    //                            });

                    nuevaVenta.Codigo_Detalle_Venta = maxDetallei + 1;
                    nuevaVenta.Cantidad = compras.Sum(x => x.Cantidad);
                    nuevaVenta.Fecha_Venta = DateTime.Now;
                    nuevaVenta.Tipo_Venta = "Linea";


                    Ubicacion_Pedido ubicacion = new Ubicacion_Pedido();
                    var maxUbicacion = (from g in db.Ubicacion_Pedido
                                        select g.Codigo_Ubicacion).Max();
                    int maxUbicacion1 = Convert.ToInt32(maxUbicacion);
                    ubicacion.Codigo_Ubicacion = maxUbicacion1 + 1;

                    
                    ubicacion.Descripcion = direc + ", " + desc;

                    Detalle_Pedido detalle_Pedido = new Detalle_Pedido();
                    var max = (from g in db.Detalle_Pedido
                               select g.Codigo_Detalle).Max();
                    int maxDP1 = Convert.ToInt32(max);
                    detalle_Pedido.Codigo_Detalle = maxDP1 + 1;
                    detalle_Pedido.Estado_Pedido = "Por entregar";
                    detalle_Pedido.Subtotal = compras.Sum(x => x.Producto.Precio_Unitario * x.Cantidad);

                    Comprobante comprobante = new Comprobante();
                    var maxComprobante = (from g in db.Comprobante
                                 select g.Numero_Comprobante).Max();
                    int maxComprobante1 = Convert.ToInt32(maxComprobante);
                    comprobante.Numero_Comprobante = maxComprobante1 + 1;
                    comprobante.Fecha_Emision = DateTime.Now;
                    comprobante.Estado = "En camino";
                    comprobante.Detalle = "Compra satisfactoria";

                    pedido pedido = new pedido();
                    var maxPedido = (from g in db.pedido
                                     select g.Codigo_Pedido).Max();
                    int maxPedido1 = Convert.ToInt32(maxPedido);
                    pedido.Codigo_Pedido = maxPedido + 1;
                    pedido.Fecha_Hora_Pedido = DateTime.Now;
                    pedido.Fecha_Hora_Entrega= DateTime.Now;
                    pedido.Codigo_Direccion_Pedido = maxUbicacion1 + 1;
                    pedido.Codigo_Personas = 1;
                    pedido.Codigo_Detalle_Pedido = maxDP1 + 1;
                    pedido.Codigo_Cliente = 4;
                    pedido.Codigo_Venta = maxVentai + 1;
                    pedido.Numero_Comprobante = maxComprobante1 + 1;

                    db.Detalle_Venta.Add(dventa);
                    db.Venta.Add(nuevaVenta);
                    db.Ubicacion_Pedido.Add(ubicacion);
                    db.Detalle_Pedido.Add(detalle_Pedido);
                    db.Comprobante.Add(comprobante);
                    db.pedido.Add(pedido);


                    db.SaveChanges();
                    Session["carrito"] = new List<CarritoItem>();
                }
            }
            return View();
        }

        public ActionResult Finalizar()
        {
            return View();
        }

        private int getIndex(int id)
        {
            List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];
            for (int i = 0; i < compras.Count; i++)
            {
                if (compras[i].Producto.Codigo_Producto == id)
                    return i;
            }

            return -1;
        }

        //System.IO.MemoryStream ms = new System.IO.MemoryStream(prod2.imagen);
        //imgPro.Image = BadImageFormatException.FromStream(ms);

    }
}