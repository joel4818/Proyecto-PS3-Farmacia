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
    public partial class Pantalla_Login : Form
    {
        public Pantalla_Login()
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

        private void txtUser_Enter(object sender, EventArgs e)
        {
            if (txtUser.Text == "Usuario")
            {
                txtUser.Text = "";
                txtUser.ForeColor = Color.Black;
            }
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                txtUser.Text = "Usuario";
                txtUser.ForeColor = Color.DimGray;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Contraseña")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Black;
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Contraseña";
                txtPassword.ForeColor = Color.DimGray;
                txtPassword.UseSystemPasswordChar = false;
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

        public void LimpiarTexto()
        {
            txtUser.Clear();
            txtPassword.Clear();
        }
        public void HabilitarOpciones()
        {
            txtUser.Enabled = true;
            txtPassword.Enabled = true;
        }

        
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuarios autentificar = new Usuarios();
                using (ProyectoFarmaciaEntities1 BD = new ProyectoFarmaciaEntities1())
                {
                    if (BD.Usuarios.Find(txtUser.Text) != null)
                    {
                        autentificar = BD.Usuarios.Find(txtUser.Text);
                        if (txtPassword.Text == autentificar.Contrasenia)
                        {
                            if (autentificar.Codigo_Tipo_Usuario == 1)
                            {
                                ClaseCompartida.ID = Convert.ToInt32(autentificar.Codigo_Tipo_Usuario);
                                MessageBox.Show("Bienvenido Administrador " + txtUser.Text);
                                
                                Pantalla_Menu formMenu = new Pantalla_Menu();
                                formMenu.Show();
                                this.Hide();

                                
                            }
                            else if (autentificar.Codigo_Tipo_Usuario == 2)
                            {
                                ClaseCompartida.ID = Convert.ToInt32(autentificar.Codigo_Tipo_Usuario);
                                MessageBox.Show("Bienvenido PF " + txtUser.Text);
                                Pantalla_Menu formMenu = new Pantalla_Menu();
                                formMenu.btnReporte.Enabled = false;

                                this.Hide();
                                formMenu.Show();
                            }
                            else if (autentificar.Codigo_Tipo_Usuario == 3)
                            {
                                ClaseCompartida.ID = Convert.ToInt32(autentificar.Codigo_Tipo_Usuario);
                                MessageBox.Show("Bienvenido PNF " + txtUser.Text);
                                Pantalla_Menu formMenu = new Pantalla_Menu();
                                formMenu.btnPersonal.Enabled = false;
                                formMenu.btnProveedores.Enabled = false;
                                formMenu.btnReporte.Enabled = false;
                                this.Hide();
                                formMenu.Show();
                            }
                            else if (autentificar.Codigo_Tipo_Usuario == 5)
                            {
                                MessageBox.Show("Este usuario no tiene permitido el Acceso");
                            }
                            else
                            {
                                MessageBox.Show("Usuario Incorrecto");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Contraseña Incorrecta");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Usuario Inexistente");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error vuelva a intentarlo");
            }
        }

        private void Pantalla_Login_Load(object sender, EventArgs e)
        { 
        }

        //Mostrar y ocultar Contraseña
        private void btnMostrar_Click(object sender, EventArgs e)
        {
            if (txtPassword.UseSystemPasswordChar == true)
            {
                txtPassword.UseSystemPasswordChar = false;
                btnMostrar.ImageLocation = string.Format(@"Images\novisible.png");
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
                btnMostrar.ImageLocation = string.Format(@"Images\visible.png");
            }
            txtPassword.Focus();
        }

        private void linkContraseña_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Pantalla_Confirmar formProd = new Pantalla_Confirmar();
            formProd.Show();
            this.Close();
        }
    }
}
