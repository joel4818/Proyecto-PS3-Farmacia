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
using System.Data.SqlClient;

namespace ProyectoFarmacia
{
    public partial class Pantalla_Venta : Form
    {
        public Pantalla_Venta()
        {
            InitializeComponent();
        }

        private void Pantalla_Productos_Load(object sender, EventArgs e)
        {
            CargaDatos();
            DGVayuda.Visible = false;
        }

        public void CargaDatos()
        {
            using (ProyectoFarmaciaEntities1 BD = new ProyectoFarmaciaEntities1())
            {
                var lst = from d in BD.Producto
                          select d.Nombre_Producto;
                CBprod.DataSource = lst.ToList();
                var lst2 = from d in BD.Producto
                           select d;
                DGVdatosP.DataSource = lst2.ToList();

                SqlConnection cn = new SqlConnection("Data Source=DESKTOP-9B5R179; Initial Catalog=ProyectoFarmacia;Integrated Security=true;");
                SqlCommand cmd = new SqlCommand("select * from Producto ", cn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DGVdatosP.DataSource = dt;
                cn.Close();
            }
            //txtNventa.Text = cont.ToString();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void CBprod_TextChanged(object sender, EventArgs e)
        {
            Producto pp = new Producto();
            using (ProyectoFarmaciaEntities1 bd = new ProyectoFarmaciaEntities1())
            {
                var lstcod = from d in bd.Producto
                             where d.Nombre_Producto.Contains(CBprod.Text)
                             select d;
                DGVayuda.DataSource = lstcod.ToList();
                txtCodigo.Text = DGVayuda.Rows[DGVayuda.CurrentRow.Index].Cells[0].Value.ToString();
                txtFecha.Text = DGVayuda.Rows[DGVayuda.CurrentRow.Index].Cells[2].Value.ToString();
                txtStock.Text = DGVayuda.Rows[DGVayuda.CurrentRow.Index].Cells[3].Value.ToString();
                txtPrecio.Text = DGVayuda.Rows[DGVayuda.CurrentRow.Index].Cells[4].Value.ToString();
                txtCategoria.Text = DGVayuda.Rows[DGVayuda.CurrentRow.Index].Cells[5].Value.ToString();
                txtProveedor.Text = DGVayuda.Rows[DGVayuda.CurrentRow.Index].Cells[6].Value.ToString();
                txtDesc.Text = DGVayuda.Rows[DGVayuda.CurrentRow.Index].Cells[7].Value.ToString();
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

        private void txtCant_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar)) //Al pulsar teclas como Borrar y eso.
            {
                e.Handled = false; //Se acepta (todo OK)
            }
            else //Para todo lo demas
            {
                e.Handled = true; //No se acepta (si pulsas cualquier otra cosa pues no se envia)
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Pantalla_Menu formMenu = new Pantalla_Menu();
            formMenu.Show();
            this.Close();
        }

        private void btnProceder_Click(object sender, EventArgs e)
        {
            ClaseCompartida.nombreProducto = CBprod.Text;
            ClaseCompartida.cantidadVenta = txtCant.Text;
            if (Convert.ToInt32(txtCarrito.Text) <= 0)
            {
                MessageBox.Show("No agrego algun producto a su carrito");
            }
            else
            {
                ClaseCompartida.carrito = Convert.ToInt32(txtCarrito.Text);
                Pantalla_ClienteVenta formMenu = new Pantalla_ClienteVenta();
                formMenu.Show();
                this.Close();               
            }            
        }

        int cont = 0;
        private void btnCarrito_Click(object sender, EventArgs e)
        {
            if (cont <= 5)
            {
                if (txtCant.Text != "")
                {
                    if (Convert.ToInt32(txtCant.Text) >= Convert.ToInt32(txtStock.Text))
                    {
                        MessageBox.Show("No existe tal cantidad en el inventario");
                    }
                    else
                    {
                        ClaseCompartida.productos[cont, 0] = Convert.ToInt32(txtCodigo.Text);
                        ClaseCompartida.productos[cont, 1] = Convert.ToInt32(txtCant.Text);

                        textBox1.Text = Convert.ToString(ClaseCompartida.productos[cont, 0]);
                        textBox2.Text = Convert.ToString(ClaseCompartida.productos[cont, 1]);
                        cont++;
                        txtCarrito.Text = Convert.ToString(cont);
                        btnProceder.Visible = true;
                    }
                }
                else
                {
                    MessageBox.Show("Debe introducir una cantidad deseada");
                }                                
            }
            else
            {
                MessageBox.Show("Cantidad limite de Articulos a comprar");
            }
        }
    }
}
