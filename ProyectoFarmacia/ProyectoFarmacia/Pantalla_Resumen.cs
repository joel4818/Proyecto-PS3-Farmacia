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
    public partial class Pantalla_Resumen : Form
    {
        public Pantalla_Resumen()
        {
            InitializeComponent();
        }

        private void Pantalla_Productos_Load(object sender, EventArgs e)
        {
            txtAyuda.Text = ClaseCompartida.nombreProducto;
            txtAyuda2.Text = ClaseCompartida.paterno;
            txtAyuda3.Text = ClaseCompartida.cantidadVenta;
            DGVayuda.Visible = false;
            DGVayuda2.Visible = false;
            txtAyuda.Visible = false;
            txtAyuda2.Visible = false;
            txtAyuda3.Visible = false;

            Producto pp = new Producto();
            Cliente cc = new Cliente();
            Detalle_Venta dv = new Detalle_Venta();
            using (ProyectoFarmaciaEntities1 bd = new ProyectoFarmaciaEntities1())
            {
                /*var lstcod = from d in bd.Producto
                             where d.Nombre_Producto.Contains(txtAyuda.Text)
                             select d;
                DGVayuda.DataSource = lstcod.ToList();
                txtCodigo.Text = DGVayuda.Rows[DGVayuda.CurrentRow.Index].Cells[0].Value.ToString();
                txtNombreP.Text = DGVayuda.Rows[DGVayuda.CurrentRow.Index].Cells[1].Value.ToString();
                txtFecha.Text = DGVayuda.Rows[DGVayuda.CurrentRow.Index].Cells[2].Value.ToString();
                txtStock.Text = DGVayuda.Rows[DGVayuda.CurrentRow.Index].Cells[3].Value.ToString();
                txtPrecio.Text = DGVayuda.Rows[DGVayuda.CurrentRow.Index].Cells[4].Value.ToString();
                txtCategoria.Text = DGVayuda.Rows[DGVayuda.CurrentRow.Index].Cells[5].Value.ToString();
                txtProveedor.Text = DGVayuda.Rows[DGVayuda.CurrentRow.Index].Cells[6].Value.ToString();
                txtDesc.Text = DGVayuda.Rows[DGVayuda.CurrentRow.Index].Cells[7].Value.ToString();
                txt.Text = txtAyuda3.Text;
                */
                var lstcod2 = from f in bd.Cliente
                              where f.Paterno.Contains(txtAyuda2.Text)
                              select f;
                DGVayuda2.DataSource = lstcod2.ToList();

                txtCodigoC.Text = DGVayuda2.Rows[DGVayuda2.CurrentRow.Index].Cells[0].Value.ToString();
                txtNombre.Text = DGVayuda2.Rows[DGVayuda2.CurrentRow.Index].Cells[1].Value.ToString();
                txtPaterno.Text = DGVayuda2.Rows[DGVayuda2.CurrentRow.Index].Cells[2].Value.ToString();
                txtCi.Text = DGVayuda2.Rows[DGVayuda2.CurrentRow.Index].Cells[3].Value.ToString();
                txtDireccion.Text = DGVayuda2.Rows[DGVayuda2.CurrentRow.Index].Cells[4].Value.ToString();
                txtTelefono.Text = DGVayuda2.Rows[DGVayuda2.CurrentRow.Index].Cells[5].Value.ToString();

                var max = (from g in bd.Detalle_Venta
                           select g.Codigo_Detalle).Max();
                int maxi = Convert.ToInt32(max);
                txtAyuda4.Text = Convert.ToString(maxi + 1);

                int total = 0, total2 = 0;
                for (int i = 0; i < ClaseCompartida.carrito; i++)
                {
                    pp = bd.Producto.Find(ClaseCompartida.productos[i,0]);
                    total2 = (ClaseCompartida.productos[i, 1]) * Convert.ToInt32(pp.Precio_Unitario);
                    total = total + total2;
                }
                txtAyuda5.Text = Convert.ToString(total);
                CargaDatos();
            }
        }

        public void CargaDatos()
        {
            Producto prod = new Producto();
            using (ProyectoFarmaciaEntities1 DB = new ProyectoFarmaciaEntities1())
            {
                prod = DB.Producto.Find(ClaseCompartida.productos[cont,0]);
                txtNombreP.Text = prod.Nombre_Producto;
                txtCodigo.Text = Convert.ToString(prod.Codigo_Producto);
                txtPrecio.Text = Convert.ToString(prod.Precio_Unitario);
                txt.Text = Convert.ToString(ClaseCompartida.productos[cont, 1]);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Pantalla_ClienteVenta formMenu = new Pantalla_ClienteVenta();
            formMenu.Show();
            this.Close();
        }

        private void btnProceder_Click(object sender, EventArgs e)
        {
            if (txtAyuda6.Text == "")
            {
                MessageBox.Show("Debe escribir una descripcion para el Detalle");
            }
            else
            {
                Producto emp = new Producto();
                using (ProyectoFarmaciaEntities1 DB = new ProyectoFarmaciaEntities1())
                {
                    for (int i = 0; i < ClaseCompartida.carrito; i++)
                    {
                        emp = DB.Producto.Find(ClaseCompartida.productos[i, 0]);
                        emp.Stock = emp.Stock - ClaseCompartida.productos[i,1];
                        DB.Entry(emp).State = System.Data.Entity.EntityState.Modified;
                        DB.SaveChanges();
                    }                    

                    Detalle_Venta emp1 = new Detalle_Venta();
                    emp1.Codigo_Detalle = Convert.ToInt32(txtAyuda4.Text);
                    emp1.Monto_Total = Convert.ToInt32(txtAyuda5.Text);
                    emp1.Descripcion = txtAyuda6.Text;
                    DB.Detalle_Venta.Add(emp1);
                    DB.SaveChanges();
                }
                ClaseCompartida.nombreProducto = txtCodigo.Text;
                ClaseCompartida.paterno = txtCodigoC.Text;
                ClaseCompartida.codigoDetalle = Convert.ToInt32(txtAyuda4.Text);

                MessageBox.Show("Venta realizada satisfactoriamente");
                Pantalla_Recibo formMenu = new Pantalla_Recibo();
                formMenu.Show();
                this.Close();
            }            
        }

        int cont = 0;
        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (cont == ClaseCompartida.carrito-1)
            {
                cont = 0;
                CargaDatos();
            }
            else
            {
                cont++;
                CargaDatos();
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (cont == 0)
            {
                cont = ClaseCompartida.carrito-1;
                CargaDatos();
            }
            else
            {
                cont--;
                CargaDatos();
            }
        }
    }
}
