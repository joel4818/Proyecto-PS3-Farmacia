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
    public partial class Pantalla_Confirmar : Form
    {
        public Pantalla_Confirmar()
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
        int contador = 0;
        private void btnIngresar_Click(object sender, EventArgs e)
        {            
            if (txtUsuario.Text != "")
            {
                Usuarios user = new Usuarios();
                using (ProyectoFarmaciaEntities1 DB = new ProyectoFarmaciaEntities1())
                {
                    if (DB.Usuarios.Find(txtUsuario.Text) != null)
                    {
                        user = DB.Usuarios.Find(txtUsuario.Text);
                        ClaseCompartida.tipoUser = Convert.ToInt32(user.Codigo_Tipo_Usuario);
                        ClaseCompartida.nomUser = txtUsuario.Text;
                        ClaseCompartida.formaUser = 0;
                        contador = 0;
                        Pantalla_Usuarios formProd = new Pantalla_Usuarios();
                        formProd.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Usuario Inexistente");
                        if (contador < 2)
                        {
                            contador++;
                        }
                        else
                        {
                            Pantalla_Login formProd = new Pantalla_Login();
                            formProd.Show();
                            this.Close();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe llenar todos los campos existentes");
            }
            
        }

        private void Pantalla_Login_Load(object sender, EventArgs e)
        {
            
        }
    }
}
