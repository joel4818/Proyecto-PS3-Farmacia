using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using ProyectoFarmacia.Entity;

namespace ProyectoFarmacia
{
    public partial class Pantalla_Recibo : Form
    {
        public Pantalla_Recibo()
        {
            InitializeComponent();
        }

        //Movimiento del formulario
        int posY = 0;
        int posX = 0;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                posX = e.X;
                posY = e.Y;
            }
            else
            {
                Left = Left + (e.X - posX);
                Top = Top + (e.Y - posY);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            Producto prod = new Producto();
            using (ProyectoFarmaciaEntities1 DB = new ProyectoFarmaciaEntities1())
            {
                for (int i = 0; i < ClaseCompartida.carrito; i++)
                {
                    prod = DB.Producto.Find(ClaseCompartida.productos[i, 0]);

                    Venta emp1 = new Venta();
                    emp1.Codigo_Venta = Convert.ToInt32(txtCodigo.Text)+i;
                    emp1.Codigo_Cliente = Convert.ToInt32(txtCodigoC.Text);
                    emp1.Id_Personas = Convert.ToInt32(txtID.Text);
                    emp1.Codigo_Producto = prod.Codigo_Producto;
                    emp1.Codigo_Detalle_Venta = Convert.ToInt32(txtCodigoD.Text);
                    emp1.Cantidad = ClaseCompartida.productos[i,1];
                    emp1.Fecha_Venta = Convert.ToDateTime(txtFecha.Text);
                    emp1.Tipo_Venta = txtTipo.Text;
                    DB.Venta.Add(emp1);
                    DB.SaveChanges();
                } 
                
            }
            Pantalla_Menu menu = new Pantalla_Menu();
            menu.Show();
            this.Close();
        }

        private void Pantalla_Login_Load(object sender, EventArgs e)
        {
            Producto prod = new Producto();
            using (ProyectoFarmaciaEntities1 bd = new ProyectoFarmaciaEntities1())
            {
                var max = (from g in bd.Venta
                           select g.Codigo_Venta).Max();
                int maxi = Convert.ToInt32(max);
                txtCodigo.Text = Convert.ToString(maxi + 1);

                txtCodigoC.Text = ClaseCompartida.paterno;
                txtID.Text = Convert.ToString(ClaseCompartida.ID);
                txtProd.Text = Convert.ToString(ClaseCompartida.nombreProducto);
                txtCodigoD.Text = Convert.ToString(ClaseCompartida.codigoDetalle);
                txtCantidad.Text = Convert.ToString(ClaseCompartida.cantidadVenta);
                txtFecha.Text = Convert.ToString(DateTime.Now);
                txtTipo.Text = "Local";
            }
        }
    }
}
