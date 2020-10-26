using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFarmacia
{
    public static class ClaseCompartida
    {
        public static String cantidadVenta;
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
    }
}
