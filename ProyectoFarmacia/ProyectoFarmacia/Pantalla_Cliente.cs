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
    public partial class Pantalla_Cliente : Form
    {
        public Pantalla_Cliente()
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
            txtPaterno.Text = "";
            txtCi.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
        }

        public void HabilitaBTN()
        {
            btnInsertar.Visible = false;
            btnEditar.Visible = false;
            btnEliminar.Visible = false;
            btnGuardar.Visible = true;

            txtCodigo.Enabled = false;
            txtNombre.Enabled = true;
            txtPaterno.Enabled = true;
            txtCi.Enabled = true;
            txtDireccion.Enabled = true;
            txtTelefono.Enabled = true;

            if (tipoA == 0)
            {
                using (ProyectoFarmaciaEntities1 bd = new ProyectoFarmaciaEntities1())
                {
                    var max = (from g in bd.Cliente
                               select g.Codigo_Cliente).Max();
                    int maxi = Convert.ToInt32(max);
                    txtCodigo.Text = Convert.ToString(maxi + 1);
                }
            }
            else
            {
                using (ProyectoFarmaciaEntities1 bd = new ProyectoFarmaciaEntities1())
                {
                    var max = (from g in bd.Cliente
                               select g.Codigo_Cliente).Max();
                    int maxi = Convert.ToInt32(max);
                    //txtCodigo.Text = Convert.ToString(maxi + 1);
                }
            }
        }
        public void DeshabilitaBTN()
        {
            btnInsertar.Visible = true;
            btnEditar.Visible = true;
            btnEliminar.Visible = true;
            btnGuardar.Visible = false;
        }

        public void Deshabilitar2()
        {
            txtCodigo.Enabled = false;
            txtNombre.Enabled = false;
            txtPaterno.Enabled = false;
            txtCi.Enabled = false;
            txtDireccion.Enabled = false;
            txtTelefono.Enabled = false;
            btnGuardar.Visible = false;
            btnInsertar.Visible = true;
            btnEditar.Visible = true;
            btnEliminar.Visible = true;
        }

        public void CargaDatos()
        {
            if (ClaseCompartida.tipoCliente == 0)
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

                    var max = (from d in BD.Cliente
                               select d.Codigo_Cliente).Max();
                    int maxi = Convert.ToInt32(max);
                    txtCodigo.Text = Convert.ToString(maxi + 1);
                }
                DeshabilitaBTN();
            }
            else
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

                    var max = (from d in BD.Cliente
                               select d.Codigo_Cliente).Max();
                    int maxi = Convert.ToInt32(max);
                    txtCodigo.Text = Convert.ToString(maxi + 1);
                }
                HabilitaBTN();
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
            if (ClaseCompartida.tipoCliente == 0)
            {
                if (tipoA == 0)
                {
                    if (txtCodigo.Text != "" && txtNombre.Text != "" && txtPaterno.Text != "" &&
                    txtCi.Text != "" && txtDireccion.Text != "" && txtTelefono.Text != "")
                    {
                        Cliente cli1 = new Cliente();
                        using (ProyectoFarmaciaEntities1 DB = new ProyectoFarmaciaEntities1())
                        {
                            var max = (from d in DB.Cliente
                                       select d.Codigo_Cliente).Max();
                            int maxi = Convert.ToInt32(max);

                            for (int n = 1; n <= maxi; n++)
                            {
                                cli1 = DB.Cliente.Find(n);

                                if (txtCi.Text == Convert.ToString(cli1.NIT_CI))
                                {
                                    //MessageBox.Show("Existe ya uno");
                                    m = 1;
                                    n = maxi + 1;
                                }
                                else
                                {
                                    //MessageBox.Show("Es Nuevo");
                                    m = 0;
                                }
                            }

                            if (m == 0)
                            {
                                Cliente emp = new Cliente();
                                emp.Codigo_Cliente = Convert.ToInt32(txtCodigo.Text);
                                emp.Nombre = txtNombre.Text;
                                emp.Paterno = txtPaterno.Text;
                                emp.NIT_CI = Convert.ToInt32(txtCi.Text);
                                emp.Direccion = txtDireccion.Text;
                                emp.Telefono = Convert.ToInt32(txtTelefono.Text);
                                DB.Cliente.Add(emp);
                                DB.SaveChanges();
                                //DB.Entry(emp).State = System.Data.Entity.EntityState.Modified;
                                //DB.SaveChanges();

                                MessageBox.Show("Registro Realizado!!!");
                                Cliente emp1 = new Cliente();
                                
                                CargaDatos();
                                DeshabilitaBTN();
                                GBdatos.Enabled = false;
                                //emp1.Show();
                            }
                            else
                            {
                                MessageBox.Show("El carnet introducido ya fue registrado");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Faltan datos!!!");
                    }
                }
                else
                {
                    if (txtCodigo.Text != "" && txtNombre.Text != "" && txtPaterno.Text != "" &&
                    txtCi.Text != "" && txtDireccion.Text != "" && txtTelefono.Text != "")
                    {
                        Cliente cli1 = new Cliente();
                        using (ProyectoFarmaciaEntities1 DB = new ProyectoFarmaciaEntities1())
                        {
                            /*
                            var max = (from d in DB.Cliente
                                       select d.Codigo_Cliente).Max();
                            int maxi = Convert.ToInt32(max);

                            for (int n = 1; n <= maxi; n++)
                            {
                                cli1 = DB.Cliente.Find(n);

                                if (txtCi.Text == Convert.ToString(cli1.NIT_CI))
                                {
                                    //MessageBox.Show("Existe ya uno");
                                    m = 1;
                                    n = maxi + 1;
                                }
                                else
                                {
                                    //MessageBox.Show("Es Nuevo");
                                    m = 0;
                                }
                            }*/
                            
                            Cliente emp = new Cliente();
                            emp.Codigo_Cliente = Convert.ToInt32(txtCodigo.Text);
                            emp.Nombre = txtNombre.Text;
                            emp.Paterno = txtPaterno.Text;
                            emp.NIT_CI = Convert.ToInt32(txtCi.Text);
                            emp.Direccion = txtDireccion.Text;
                            emp.Telefono = Convert.ToInt32(txtTelefono.Text);
                            DB.Entry(emp).State = System.Data.Entity.EntityState.Modified;
                            DB.SaveChanges();

                            MessageBox.Show("Registro Modificado!!!");
                            Cliente emp1 = new Cliente();

                            CargaDatos();
                            DeshabilitaBTN();
                            GBdatos.Enabled = false;
                            //emp1.Show();
                            /*
                            if (m == 0)
                            {
                                
                            }
                            else
                            {
                                MessageBox.Show("El carnet introducido ya fue registrado");
                            }*/
                        }
                    }
                    else
                    {
                        MessageBox.Show("Faltan datos!!!");
                    }
                }
                
            }
            else
            {
                if (txtCodigo.Text != "" && txtNombre.Text != "" && txtPaterno.Text != "" &&
                txtCi.Text != "" && txtDireccion.Text != "" && txtTelefono.Text != "")
                {
                    Cliente cli1 = new Cliente();
                    using (ProyectoFarmaciaEntities1 DB = new ProyectoFarmaciaEntities1())
                    {                        
                        var max = (from d in DB.Cliente
                                   select d.Codigo_Cliente).Max();
                        int maxi = Convert.ToInt32(max);

                        for (int n = 1; n <= maxi; n++)
                        {
                            cli1 = DB.Cliente.Find(n);

                            if (txtCi.Text == Convert.ToString(cli1.NIT_CI))
                            {
                                //MessageBox.Show("Existe ya uno");
                                m = 1;
                                n = maxi + 1;
                            }
                            else
                            {
                                //MessageBox.Show("Es Nuevo");
                                m = 0;
                            }
                        }

                        if (m == 0)
                        {
                            Cliente emp = new Cliente();
                            emp.Codigo_Cliente = Convert.ToInt32(txtCodigo.Text);
                            emp.Nombre = txtNombre.Text;
                            emp.Paterno = txtPaterno.Text;
                            emp.NIT_CI = Convert.ToInt32(txtCi.Text);
                            emp.Direccion = txtDireccion.Text;
                            emp.Telefono = Convert.ToInt32(txtTelefono.Text);
                            DB.Cliente.Add(emp);
                            DB.SaveChanges();
                            //DB.Entry(emp).State = System.Data.Entity.EntityState.Modified;
                            //DB.SaveChanges();

                            MessageBox.Show("Registro Realizado!!!");

                            //emp1.Show();

                            Pantalla_ClienteVenta form = new Pantalla_ClienteVenta();
                            form.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("El carnet introducido ya fue registrado");
                        }
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
            
            if (ClaseCompartida.tipoCliente == 0)
            {
                if (tipoA == 0)
                {
                    CargaDatos();
                    DeshabilitaBTN();
                    Blanco();
                    GBdatos.Enabled = false;
                    tipoA = 2;
                }
                else if (tipoA == 1)
                {
                    CargaDatos();
                    DeshabilitaBTN();
                    Blanco();
                    GBdatos.Enabled = false;
                    tipoA = 2;
                }
                else
                {
                    Pantalla_Menu form = new Pantalla_Menu();
                    form.Show();
                    this.Close();
                }
            }
            else
            {
                Pantalla_ClienteVenta form = new Pantalla_ClienteVenta();
                form.Show();
                this.Close();                
            }
        }

        private void txtCi_KeyPress(object sender, KeyPressEventArgs e)
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

        int tipoA = 2;
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            GBdatos.Enabled = true;
            ClaseCompartida.tipoCliente = 0;            
            tipoA = 0;
            Blanco();
            CargaDatos();
            HabilitaBTN();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            //CargaDatos();
            GBdatos.Enabled = true;
            ClaseCompartida.tipoCliente = 0;
            HabilitaBTN();
            tipoA = 1;
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
                    txtPaterno.Text = cli2.Paterno;
                    txtCi.Text = Convert.ToString(cli2.NIT_CI);
                    txtDireccion.Text = cli2.Direccion;
                    txtTelefono.Text = Convert.ToString(cli2.Telefono);
                }
                Deshabilitar2();
            }            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult Respuesta;
            if (txtCodigo.Text != "")
            {
                Respuesta = MessageBox.Show("Esta seguro de eliminar el Cliente", "Eliminar", MessageBoxButtons.YesNo);
                if (Respuesta == DialogResult.Yes)
                {
                    using (ProyectoFarmaciaEntities1 DB = new ProyectoFarmaciaEntities1())
                    {
                        Cliente EliminarPersona = DB.Cliente.Find(Convert.ToInt32(txtCodigo.Text));
                        DB.Cliente.Remove(EliminarPersona);
                        DB.SaveChanges();
                        MessageBox.Show("Dato eliminado");
                        Blanco();
                    }
                    CargaDatos();
                    tipoA = 2;
                }
            }
            else
            {
                MessageBox.Show("Debe Seleccionar item");
            }
        }
    }
}
