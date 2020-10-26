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
    public partial class Pantalla_Productos : Form
    {
        public Pantalla_Productos()
        {
            InitializeComponent();
        }
        int cont = 0;

        private void Pantalla_Productos_Load(object sender, EventArgs e)
        {
            Deshabilitar();
            CargaDatos();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        public void CargaDatos()
        {
            using (ProyectoFarmaciaEntities1 BD = new ProyectoFarmaciaEntities1())
            {
                var lst = from d in BD.Proveedor
                          select d.Nombre_Proveedor;
                CBprov.DataSource = lst.ToList();

                var lst2 = from f in BD.Producto
                           select f;
                DGVdatosP.DataSource = lst2.ToList();

                var lst3 = from g in BD.Categoria
                          select g.Nombre_Categoria;
                txtCategoria.DataSource = lst3.ToList();
            }
            ClaseCompartida.tipoProd = 0;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        public void Habilitar()
        {
            txtNombre.Enabled = true;
            txtFecha.Enabled = true;
            txtStock.Enabled = true;
            txtPrecio.Enabled = true;
            txtCategoria.Enabled = true;
            CBprov.Enabled = true;
            txtDesc.Enabled = true;
            btnGuardar.Visible = true;

            Producto pp = new Producto();
            using (ProyectoFarmaciaEntities1 bd = new ProyectoFarmaciaEntities1())
            {
                var max = (from g in bd.Producto
                           select g.Codigo_Producto).Max();
                int maxi = Convert.ToInt32(max);
                txtCodigo.Text = Convert.ToString(maxi + 1);
            }
        }

        public void Deshabilitar()
        {
            txtCodigo.Enabled = false;
            txtNombre.Enabled = false;
            txtFecha.Enabled = false;
            txtStock.Enabled = false;
            txtPrecio.Enabled = false;
            txtCategoria.Enabled = false;
            CBprov.Enabled = false;
            txtDesc.Enabled = false;
            btnGuardar.Visible = false;

            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtStock.Text = "";
            txtPrecio.Text = "";
            txtCategoria.Text = "";
            CBprov.Text = "";
            txtDesc.Text = "";
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            cont = 1;
            Habilitar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (cont == 0)
            {
                Pantalla_Menu menu = new Pantalla_Menu();
                menu.Show();
                this.Close();
            }
            else
            {
                Deshabilitar();
                cont = 0;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            cont = 0;
            if (txtCodigo.Text != "" && txtNombre.Text != "" && txtFecha.Text != "" &&
                txtStock.Text != "" && txtPrecio.Text != "" && txtDesc.Text != "" &&
                CBprov.Text != "")
            {
                using (ProyectoFarmaciaEntities1 DB = new ProyectoFarmaciaEntities1())
                {
                    Producto emp = new Producto();
                    emp.Codigo_Producto = Convert.ToInt32(txtCodigo.Text);
                    emp.Nombre_Producto = txtNombre.Text;
                    emp.Fecha_Vencimiento = Convert.ToDateTime(txtFecha.Text);
                    emp.Stock = Convert.ToInt32(txtStock.Text);
                    emp.Precio_Unitario = Convert.ToInt32(txtPrecio.Text);
                    emp.Codigo_Categoria = Convert.ToInt32(a1);
                    emp.Codigo_Proveedor = Convert.ToInt32(a2);
                    emp.Descripcion = txtDesc.Text;
                    DB.Producto.Add(emp);
                    DB.SaveChanges();
                }
                MessageBox.Show("Registro Realizado!!!");
                CargaDatos();
                Deshabilitar();
            }
            else
            {
                MessageBox.Show("Faltan datos!!!");
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
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

        string a1, a2;

        private void CBprov_TextChanged(object sender, EventArgs e)
        {
            Categoria pp = new Categoria();
            using (ProyectoFarmaciaEntities1 bd = new ProyectoFarmaciaEntities1())
            {
                var lstcod = from d in bd.Proveedor
                             where d.Nombre_Proveedor.Contains(CBprov.Text)
                             select d;
                DGVayuda2.DataSource = lstcod.ToList();
                a2 = DGVayuda2.Rows[DGVayuda2.CurrentRow.Index].Cells[0].Value.ToString();
            }
        }

        private void DGVdatosP_Click(object sender, EventArgs e)
        {
            txtCategoria.Visible = false;
            CBprov.Visible = false;

            txtCat2.Visible = true;
            txtProv.Visible = true;
            ClaseCompartida.tipoProd = 1;
            Producto prod2 = new Producto();
            string codigo;
            codigo = DGVdatosP.Rows[DGVdatosP.CurrentRow.Index].Cells[0].Value.ToString();
            txtCodigo.Text = codigo;
            using (ProyectoFarmaciaEntities1 DB = new ProyectoFarmaciaEntities1())
            {
                prod2 = DB.Producto.Find(Convert.ToInt32(codigo));
                txtNombre.Text = prod2.Nombre_Producto;
                txtFecha.Text = Convert.ToString(prod2.Fecha_Vencimiento);
                txtStock.Text = Convert.ToString(prod2.Stock);
                txtPrecio.Text = Convert.ToString(prod2.Precio_Unitario);
                txtCat2.Text = Convert.ToString(prod2.Codigo_Categoria);
                txtProv.Text = Convert.ToString(prod2.Codigo_Proveedor);
                txtDesc.Text = prod2.Descripcion;
            }
        }

        private void txtCategoria_TextChanged(object sender, EventArgs e)
        {
            Categoria pp = new Categoria();
            using (ProyectoFarmaciaEntities1 bd = new ProyectoFarmaciaEntities1())
            {
                var lstcod = from d in bd.Categoria
                             where d.Nombre_Categoria.Contains(txtCategoria.Text)
                             select d;
                DGVayuda.DataSource = lstcod.ToList();
                a1 = DGVayuda.Rows[DGVayuda.CurrentRow.Index].Cells[0].Value.ToString();
            }
        }
    }
}
