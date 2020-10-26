using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFarmacia
{
    public partial class Pantalla_Inicio : Form
    {
        public Pantalla_Inicio()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            while (this.Opacity > 0) 
            {
                this.Opacity -= 0.00001;
            }
            this.Hide();
            Pantalla_Login pl = new Pantalla_Login();
            pl.Show();
            timer1.Stop();
        }

        private void Pantalla_Inicio_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer1.Start();
        }

       
    }
}
