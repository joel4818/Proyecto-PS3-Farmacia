using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ProyectoFarmacia
{
    public partial class Pantalla_Menu : Form
    {
        public Pantalla_Menu()
        {
            InitializeComponent();
            Diseño_Submenu();
            
        }

        //Mover Formulario
        int posY = 0;
        int posX = 0;
        private void Contenedor_Titulo_MouseMove(object sender, MouseEventArgs e)
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
            WindowState = FormWindowState.Minimized;
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            btnMaximizar.Visible = true;
            btnRestaurar.Visible = false;
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (Contenedor_Menu.Width == 260)
            {
                Contenedor_Menu.Width = 0;
            }
            else
            {
                Contenedor_Menu.Width = 260;
            }
        }

        private void Diseño_Submenu()
        {
            Panel_Submenu.Visible = false;
        }

        private void Ocultar_Submenu()
        {
            if (Panel_Submenu.Visible == true)
            {
                Panel_Submenu.Visible = false;
            }
        }

        private void Mostrar_Submenu(Panel Submenu)
        {
            if (Submenu.Visible == false)
            {
                Ocultar_Submenu();
                Submenu.Visible = true;
            }
            else
            {
                Submenu.Visible = false;
            }
        }

        private void btnPersonal_Click(object sender, EventArgs e)
        {
            Mostrar_Submenu(Panel_Submenu);
        }

        private void btnAdministrador_Click(object sender, EventArgs e)
        {
            Ocultar_Submenu();
        }

        private void btnFacultativo_Click(object sender, EventArgs e)
        {
            Ocultar_Submenu();
        }

        private void btnNoFacultativo_Click(object sender, EventArgs e)
        {
            Ocultar_Submenu();
        }

        private void btnRepartidor_Click(object sender, EventArgs e)
        {
            Ocultar_Submenu();
        }

        private int numeroImagen = 1;

        private void Carga_Siguiente_Imagen()
        {
            if (numeroImagen == 6)
            {
                numeroImagen = 1;

            }
            pctImages.ImageLocation = string.Format(@"Images\{0}.jpg", numeroImagen);
            numeroImagen++;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Carga_Siguiente_Imagen();
        }

        private void Pantalla_Menu_Load(object sender, EventArgs e)
        {
            timer2.Enabled = true;
            txtHora.BackColor = Color.Transparent;  
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            txtHora.Text = DateTime.Now.ToString("hh:mm:ss");
            txtFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            Pantalla_Productos formProd = new Pantalla_Productos();
            formProd.Show();
            this.Hide();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            Pantalla_Venta formVenta = new Pantalla_Venta();
            formVenta.Show();
            this.Hide();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            ClaseCompartida.tipoCliente = 0;
            Pantalla_Cliente formVenta = new Pantalla_Cliente();
            formVenta.Show();
            this.Hide();
        }
    }
}
