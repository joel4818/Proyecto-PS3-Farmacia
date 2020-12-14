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
    public partial class Pantalla_Proveedores : Form
    {
        public Pantalla_Proveedores()
        {
            InitializeComponent();
        }

        private void Pantalla_Productos_Load(object sender, EventArgs e)
        {
            CargaDatos();
            if (ClaseCompartida.tipoCliente == 1)
            {
                btnInsertar.Visible = false;
                btnEditar.Visible = false;
                btnEliminar.Visible = false;
                GBdatos.Enabled = true;
            }
            else
            {
                btnInsertar.Visible = true;
                btnEditar.Visible = true;
                btnEliminar.Visible = true;
                GBdatos.Enabled = false;
            }
            DGVayuda.Visible = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        public void Blanco()
        {
            //txtCodigo.Text = "";
            txtNombre.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
        }

        public void HabilitaBTN()
        {
            btnInsertar.Visible = false;
            btnEditar.Visible = false;
            btnEliminar.Visible = false;
            btnGuardar.Visible = true;
        }
        public void DeshabilitaBTN()
        {
            btnInsertar.Visible = true;
            btnEditar.Visible = true;
            btnEliminar.Visible = true;
            btnGuardar.Visible = false;
        }

        public void CargaDatos()
        {
            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-9B5R179; Initial Catalog=ProyectoFarmacia;Integrated Security=true;");
            SqlCommand cmd = new SqlCommand("select * from Proveedor ", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DGVdatosA.DataSource = dt;
            cn.Close();
            
            if (ClaseCompartida.tipoCliente == 1)
            {
                using (ProyectoFarmaciaEntities1 BD = new ProyectoFarmaciaEntities1())
                {
                    var lst2 = from d in BD.Cliente
                               select d;
                    //DGVdatosA.DataSource = lst2.ToList();
                    var max = (from d in BD.Proveedor
                               select d.Codigo_Proveedor).Max();
                    int maxi = Convert.ToInt32(max);
                    txtCodigo.Text = Convert.ToString(maxi + 1);
                }
                HabilitaBTN();
            }
            else
            {
                using (ProyectoFarmaciaEntities1 BD = new ProyectoFarmaciaEntities1())
                {
                    var lst2 = from d in BD.Cliente
                               select d;
                    //DGVdatosA.DataSource = lst2.ToList();
                    var max = (from d in BD.Proveedor
                               select d.Codigo_Proveedor).Max();
                    int maxi = Convert.ToInt32(max);
                    txtCodigo.Text = Convert.ToString(maxi + 1);
                }
                DeshabilitaBTN();
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int m = 0;
            if (tipoC == 0)
            {
                if (txtCodigo.Text != "" && txtNombre.Text != "" &&
                    txtDireccion.Text != "" && txtTelefono.Text != "")
                {
                    Persona cli1 = new Persona();
                    using (ProyectoFarmaciaEntities1 DB = new ProyectoFarmaciaEntities1())
                    {
                        Proveedor emp = new Proveedor();
                        emp.Codigo_Proveedor = Convert.ToInt32(txtCodigo.Text);
                        emp.Nombre_Proveedor = txtNombre.Text;
                        emp.Direccion = txtDireccion.Text;
                        emp.Telefono = Convert.ToInt32(txtTelefono.Text);
                        DB.Proveedor.Add(emp);
                        DB.SaveChanges();
                        //DB.Entry(emp).State = System.Data.Entity.EntityState.Modified;
                        //DB.SaveChanges();
                        MessageBox.Show("Registro Realizado!!!");
                        //emp1.Show();
                        CargaDatos();
                        GBdatos.Enabled = false;
                        DeshabilitaBTN();
                        Blanco();
                    }
                }
                else
                {
                    MessageBox.Show("Faltan datos!!!");
                }
            }
            else
            {
                if (txtCodigo.Text != "" && txtNombre.Text != "" &&
                    txtDireccion.Text != "" && txtTelefono.Text != "")
                {
                    Persona cli1 = new Persona();
                    using (ProyectoFarmaciaEntities1 DB = new ProyectoFarmaciaEntities1())
                    {
                        Proveedor emp = new Proveedor();
                        emp.Codigo_Proveedor = Convert.ToInt32(txtCodigo.Text);
                        emp.Nombre_Proveedor = txtNombre.Text;
                        emp.Direccion = txtDireccion.Text;
                        emp.Telefono = Convert.ToInt32(txtTelefono.Text);
                        DB.Entry(emp).State = System.Data.Entity.EntityState.Modified;
                        DB.SaveChanges();

                        MessageBox.Show("Registro Modificado!!!");
                        CargaDatos();
                        //emp1.Show();
                        GBdatos.Enabled = false;
                        DeshabilitaBTN();
                        Blanco();
                    }
                }
                else
                {
                    MessageBox.Show("Faltan datos!!!");
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            
            if (ClaseCompartida.tipoCliente == 1)
            {
                Pantalla_ClienteVenta form = new Pantalla_ClienteVenta();
                form.Show();
                this.Close();
            }
            if (ClaseCompartida.tipoCliente == 0)
            {
                Pantalla_Menu form = new Pantalla_Menu();
                form.Show();
                this.Close();
            }
            if (ClaseCompartida.tipoCliente == 2)
            {
                CargaDatos();
                DeshabilitaBTN();
                Blanco();
                ClaseCompartida.tipoCliente = 0;
                GBdatos.Enabled = false;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
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

        int tipoC = 0;
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            CargaDatos();
            GBdatos.Enabled = true;
            ClaseCompartida.tipoCliente = 2;
            HabilitaBTN();
            tipoC = 0;
            Blanco();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //CargaDatos();
            GBdatos.Enabled = true;
            ClaseCompartida.tipoCliente = 2;
            HabilitaBTN();
            tipoC = 1;
        }

        private void DGVdatosC_Click(object sender, EventArgs e)
        {
            if (ClaseCompartida.tipoCliente == 0)
            {
                Proveedor cli2 = new Proveedor();
                string codigo;
                codigo = DGVdatosA.Rows[DGVdatosA.CurrentRow.Index].Cells[0].Value.ToString();
                txtCodigo.Text = codigo;
                using (ProyectoFarmaciaEntities1 DB = new ProyectoFarmaciaEntities1())
                {
                    cli2 = DB.Proveedor.Find(Convert.ToInt32(codigo));
                    txtNombre.Text = cli2.Nombre_Proveedor;
                    txtDireccion.Text = cli2.Direccion;
                    txtTelefono.Text = Convert.ToString(cli2.Telefono);
                }
            }            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult Respuesta;
            if (txtCodigo.Text != "")
            {
                Respuesta = MessageBox.Show("Esta seguro de eliminar el Dato", "Eliminar", MessageBoxButtons.YesNo);
                if (Respuesta == DialogResult.Yes)
                {
                    using (ProyectoFarmaciaEntities1 DB = new ProyectoFarmaciaEntities1())
                    {
                        Proveedor EliminarPersona = DB.Proveedor.Find(Convert.ToInt32(txtCodigo.Text));
                        DB.Proveedor.Remove(EliminarPersona);
                        DB.SaveChanges();
                        MessageBox.Show("Dato eliminado");
                        Blanco();
                    }
                    CargaDatos();
                }
            }
            else
            {
                MessageBox.Show("Debe Seleccionar item");
            }
        }
    }
}
