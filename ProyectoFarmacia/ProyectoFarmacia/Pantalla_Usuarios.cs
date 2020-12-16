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
    public partial class Pantalla_Usuarios : Form
    {
        public Pantalla_Usuarios()
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
            if (txtUsuario.Text != "" && txtContra.Text != "" && txtContra2.Text != "")
            {
                if (txtContra.Text == txtContra2.Text)
                {
                    if (ClaseCompartida.formaUser == 0)
                    {
                        Usuarios user = new Usuarios();
                        using (ProyectoFarmaciaEntities1 DB = new ProyectoFarmaciaEntities1())
                        {
                            user.Nombre_Usuario = txtUsuario.Text;
                            user.Contrasenia = txtContra.Text;
                            user.Codigo_Tipo_Usuario = Convert.ToInt32(txtTipoUser.Text);
                            DB.Entry(user).State = System.Data.Entity.EntityState.Modified;
                            DB.SaveChanges();
                            MessageBox.Show("Contraseña actualizada!!!");
                            Pantalla_Login menu = new Pantalla_Login();
                            menu.Show();
                            this.Close();
                        }
                    }
                    else
                    {
                        Usuarios user = new Usuarios();
                        using (ProyectoFarmaciaEntities1 DB = new ProyectoFarmaciaEntities1())
                        {
                            user.Nombre_Usuario = txtUsuario.Text;
                            user.Contrasenia = txtContra.Text;
                            user.Codigo_Tipo_Usuario = Convert.ToInt32(txtTipoUser.Text);
                            DB.Usuarios.Add(user);
                            DB.SaveChanges();
                            MessageBox.Show("Usuario Creado!!!");
                            Pantalla_Menu menu = new Pantalla_Menu();
                            menu.Show();
                            this.Close();
                        }
                    }
                    
                }
                else
                {
                    MessageBox.Show("Ambas contraseñas no coinciden");
                }                
            }
            else
            {
                MessageBox.Show("Debe llenar todos los campos existentes");
            }
            
        }

        private void Pantalla_Login_Load(object sender, EventArgs e)
        {
            if (ClaseCompartida.formaUser == 0)
            {
                txtUsuario.Enabled = false;
                using (ProyectoFarmaciaEntities1 bd = new ProyectoFarmaciaEntities1())
                {
                    txtUsuario.Text = ClaseCompartida.nomUser;
                    txtTipoUser.Text = Convert.ToString(ClaseCompartida.tipoUser);
                }
            }
            else
            {
                txtUsuario.Enabled = true;
                using (ProyectoFarmaciaEntities1 bd = new ProyectoFarmaciaEntities1())
                {
                    txtUsuario.Text = "";
                    txtTipoUser.Text = Convert.ToString(ClaseCompartida.tipoUser);
                }
            }
        }
    }
}
