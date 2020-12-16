using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoFarmaciaWeb.Models
{
    public class ClaseCompartida
    {
        public static String canditdadVenta;
        public static int tipoCliente;
        public static int tipoProd;
        public static String nombreProducto;
        public static String paterno;
        public static int ID;

        public static int codigoDetalle;
        public static float montoTotal;
        public static String descripcionDetalle;

        public static int[,] productos = new int[6, 2];
        public static int carrito;
        public static int[] idProducto = new int[6];
        public static int[] Cantidad = new int[6];
        
    }
}