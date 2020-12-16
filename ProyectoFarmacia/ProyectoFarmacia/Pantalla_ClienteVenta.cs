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
    public partial class Pantalla_ClienteVenta : Form
    {
        public Pantalla_ClienteVenta()
        {
            InitializeComponent();
        }
        int cont = 0;

        private void Pantalla_Productos_Load(object sender, EventArgs e)
        {
            cont = 0;
            CargaDatos();
            DGVayuda.Visible = false;
            CBclie.Enabled = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        public void Deshabilitar2()
        {
            txtCodigo.Enabled = false;
            txtNombre.Enabled = false;
            CBclie.Enabled = false;
            txtCi.Enabled = false;
            txtDireccion.Enabled = false;
            txtTelefono.Enabled = false;
        }

        public void CargaDatos()
        {
            using (ProyectoFarmaciaEntities1 BD = new ProyectoFarmaciaEntities1())
            {
                SqlConnection cn = new SqlConnection("Data Source=DESKTOP-9B5R179; Initial Catalog=ProyectoFarmacia;Integrated Security=true;");
                SqlCommand cmd = new SqlCommand("select * from Cliente ", cn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DGVdatosC.DataSource = dt;
                cn.Close();

                var lst = from d in BD.Cliente
                          select d.Paterno;
                CBclie.DataSource = lst.ToList();
            }
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
        
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Pantalla_Venta formMenu = new Pantalla_Venta();
            formMenu.Show();
            this.Close();
        }

        private void CBclie_TextChanged(object sender, EventArgs e)
        {
            /*Cliente pp = new Cliente();
            using (ProyectoFarmaciaEntities1 bd = new ProyectoFarmaciaEntities1())
            {
                var lstcod = from d in bd.Cliente
                             where d.Paterno.Contains(CBclie.Text)
                             select d;
                DGVayuda.DataSource = lstcod.ToList();

                txtCodigo.Text = DGVayuda.Rows[DGVayuda.CurrentRow.Index].Cells[0].Value.ToString();
                txtNombre.Text = DGVayuda.Rows[DGVayuda.CurrentRow.Index].Cells[1].Value.ToString();
                txtCi.Text = DGVayuda.Rows[DGVayuda.CurrentRow.Index].Cells[3].Value.ToString();
                txtDireccion.Text = DGVayuda.Rows[DGVayuda.CurrentRow.Index].Cells[4].Value.ToString();
                txtTelefono.Text = DGVayuda.Rows[DGVayuda.CurrentRow.Index].Cells[5].Value.ToString();
            }*/
        }

        private void btnProceder_Click(object sender, EventArgs e)
        {
            ClaseCompartida.paterno = CBclie.Text;
            Pantalla_Resumen res = new Pantalla_Resumen();
            res.Show();
            this.Close();           
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ClaseCompartida.tipoCliente = 2;
            Pantalla_Cliente cli = new Pantalla_Cliente();
            cli.Show();
            this.Close();
        }

        private void DGVdatosC_Click(object sender, EventArgs e)
        {
            if (ClaseCompartida.tipoCliente == 0)
            {
                Cliente cli2 = new Cliente();
                string codigo;
                codigo = DGVdatosC.Rows[DGVdatosC.CurrentRow.Index].Cells[0].Value.ToString();
                txtCodigo.Text = codigo;
                using (ProyectoFarmaciaEntities1 DB = new ProyectoFarmaciaEntities1())
                {
                    cli2 = DB.Cliente.Find(Convert.ToInt32(codigo));
                    txtNombre.Text = cli2.Nombre;
                    CBclie.Text = cli2.Paterno;
                    txtCi.Text = Convert.ToString(cli2.NIT_CI);
                    txtDireccion.Text = cli2.Direccion;
                    txtTelefono.Text = Convert.ToString(cli2.Telefono);
                }
                Deshabilitar2();
            }
        }
    }
}
