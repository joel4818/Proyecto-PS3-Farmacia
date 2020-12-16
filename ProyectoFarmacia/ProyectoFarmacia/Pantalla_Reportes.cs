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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace ProyectoFarmacia
{
    public partial class Pantalla_Reportes : Form
    {
        public Pantalla_Reportes()
        {
            InitializeComponent();
        }
        int cont = 0;

        private void Pantalla_Productos_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'proyectoFarmaciaDataSet.Venta' Puede moverla o quitarla según sea necesario.
            this.ventaTableAdapter.Fill(this.proyectoFarmaciaDataSet.Venta);
            //Deshabilitar();
            CargaDatos();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        public void ExportarPDF(DataGridView dgw, string filename)
        {
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
            PdfPTable pdfTable = new PdfPTable(dgw.Columns.Count);
            pdfTable.DefaultCell.Padding = 4;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;

            iTextSharp.text.Font text = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);
            //Add header
            foreach (DataGridViewColumn column in dgw.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, text));
                cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                pdfTable.AddCell(cell);
            }

            //Add datarow
            foreach (DataGridViewRow row in dgw.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    pdfTable.AddCell(new Phrase(cell.Value.ToString(), text));
                }
            }

            var sfd = new SaveFileDialog();
            sfd.FileName = filename;
            sfd.DefaultExt = ".pdf";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                {
                    Document pdfdoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                    PdfWriter.GetInstance(pdfdoc, stream);
                    pdfdoc.Open();
                    pdfdoc.Add(pdfTable);
                    pdfdoc.Close();
                    stream.Close();
                }
            }
        }

        public void CargaDatos()
        {            
            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-9B5R179; Initial Catalog=ProyectoFarmacia;Integrated Security=true;");
            SqlCommand cmd = new SqlCommand("select v.Codigo_Venta as 'Codigo Venta'," +
                "c.NIT_CI as 'Cliente'," +
                "p.Paterno + ' ' + p.Nombre as 'Persona'," +
                "pr.Nombre_Producto as 'Producto'," +
                "v.Codigo_Detalle_Venta as 'Detalle Venta'," +
                "v.Cantidad as 'Cantidad'," +
                "v.Fecha_Venta as 'Fecha'," +
                "v.Tipo_Venta as 'Tipo' " +
                "from Venta v " +
                "inner join Cliente c " +
                "on v.Codigo_Cliente = c.Codigo_Cliente " +
                "inner join Persona p " +
                "on v.Id_Personas = p.Id_Personas " +
                "inner join Producto pr " +
                "on v.Codigo_Producto = pr.Codigo_Producto ", cn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            DGVdatosV.DataSource = dt;
            cn.Close();

            using (ProyectoFarmaciaEntities1 BD = new ProyectoFarmaciaEntities1())
            {
                var lst = from d in BD.Producto
                          select d.Nombre_Producto;
                cbProd.DataSource = lst.ToList();

                var lst2 = from d in BD.Cliente
                          select d.NIT_CI;
                cbClie.DataSource = lst2.ToList();

                cbTipo.Items.Add("Local");
                cbTipo.Items.Add("Domicilio");
            }

            cbDia.Items.Add('1');cbDia.Items.Add('2');cbDia.Items.Add('3');cbDia.Items.Add('4');
            cbDia.Items.Add('5');cbDia.Items.Add('6');cbDia.Items.Add('7');cbDia.Items.Add('8');
            cbDia.Items.Add('9'); cbDia.Items.Add("10"); cbDia.Items.Add("11"); cbDia.Items.Add("12");
            cbDia.Items.Add("13"); cbDia.Items.Add("14"); cbDia.Items.Add("15"); cbDia.Items.Add("16");
            cbDia.Items.Add("17"); cbDia.Items.Add("18"); cbDia.Items.Add("19"); cbDia.Items.Add("20");
            cbDia.Items.Add("21"); cbDia.Items.Add("22"); cbDia.Items.Add("23"); cbDia.Items.Add("24");
            cbDia.Items.Add("25"); cbDia.Items.Add("26"); cbDia.Items.Add("27"); cbDia.Items.Add("28");
            cbDia.Items.Add("29"); cbDia.Items.Add("30"); cbDia.Items.Add("31");

            cbMes.Items.Add('1'); cbMes.Items.Add('2'); cbMes.Items.Add('3'); cbMes.Items.Add('4');
            cbMes.Items.Add('5'); cbMes.Items.Add('6'); cbMes.Items.Add('7'); cbMes.Items.Add('8');
            cbMes.Items.Add('9'); cbMes.Items.Add("10"); cbMes.Items.Add("11"); cbMes.Items.Add("12");

            cbDia2.Items.Add('1'); cbDia2.Items.Add('2'); cbDia2.Items.Add('3'); cbDia2.Items.Add('4');
            cbDia2.Items.Add('5'); cbDia2.Items.Add('6'); cbDia2.Items.Add('7'); cbDia2.Items.Add('8');
            cbDia2.Items.Add('9'); cbDia2.Items.Add("10"); cbDia2.Items.Add("11"); cbDia2.Items.Add("12");
            cbDia2.Items.Add("13"); cbDia2.Items.Add("14"); cbDia2.Items.Add("15"); cbDia2.Items.Add("16");
            cbDia2.Items.Add("17"); cbDia2.Items.Add("18"); cbDia2.Items.Add("19"); cbDia2.Items.Add("20");
            cbDia2.Items.Add("21"); cbDia2.Items.Add("22"); cbDia2.Items.Add("23"); cbDia2.Items.Add("24");
            cbDia2.Items.Add("25"); cbDia2.Items.Add("26"); cbDia2.Items.Add("27"); cbDia2.Items.Add("28");
            cbDia2.Items.Add("29"); cbDia2.Items.Add("30"); cbDia2.Items.Add("31");

            cbMes2.Items.Add('1'); cbMes2.Items.Add('2'); cbMes2.Items.Add('3'); cbMes2.Items.Add('4');
            cbMes2.Items.Add('5'); cbMes2.Items.Add('6'); cbMes2.Items.Add('7'); cbMes2.Items.Add('8');
            cbMes2.Items.Add('9'); cbMes2.Items.Add("10"); cbMes2.Items.Add("11"); cbMes2.Items.Add("12");
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
        /*
        public void Habilitar()
        {
            txtNombre.Enabled = true;
            txtFecha.Enabled = true;
            txtStock.Enabled = true;
            txtPrecio.Enabled = true;
            txtCategoria.Enabled = true;
            CBprov.Enabled = true;
            txtDesc.Enabled = true;
            btnExport.Visible = true;

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
            btnExport.Visible = false;

            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtStock.Text = "";
            txtPrecio.Text = "";
            txtCategoria.Text = "";
            CBprov.Text = "";
            txtDesc.Text = "";
        }
        */
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            CargaDatos();
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
                //Deshabilitar();
                cont = 0;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ExportarPDF(DGVdatosV, "Reporte Ventas");
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

        private void btnFiltroCli_Click(object sender, EventArgs e)
        {
            using (ProyectoFarmaciaEntities1 bd = new ProyectoFarmaciaEntities1())
            {
                if (cbClie.Text != "")
                {
                    SqlConnection cn = new SqlConnection("Data Source=DESKTOP-9B5R179; Initial Catalog=ProyectoFarmacia;Integrated Security=true;");
                    SqlCommand cmd = new SqlCommand("select v.Codigo_Venta as 'Codigo Venta'," +
                        "c.NIT_CI as 'Cliente'," +
                        "p.Paterno + ' ' + p.Nombre as 'Persona'," +
                        "pr.Nombre_Producto as 'Producto'," +
                        "v.Codigo_Detalle_Venta as 'Detalle Venta'," +
                        "v.Cantidad as 'Cantidad'," +
                        "v.Fecha_Venta as 'Fecha'," +
                        "v.Tipo_Venta as 'Tipo' " +
                        "from Venta v " +
                        "inner join Cliente c " +
                        "on v.Codigo_Cliente = c.Codigo_Cliente " +
                        "inner join Persona p " +
                        "on v.Id_Personas = p.Id_Personas " +
                        "inner join Producto pr " +
                        "on v.Codigo_Producto = pr.Codigo_Producto " +
                        "where c.NIT_CI = '" + cbClie.Text + "'", cn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    DGVdatosV.DataSource = dt;
                    cn.Close();
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un filtro correspondiente");
                }
            }
        }

        private void btnFiltroTipo_Click(object sender, EventArgs e)
        {
            using (ProyectoFarmaciaEntities1 bd = new ProyectoFarmaciaEntities1())
            {
                if (cbTipo.Text != "")
                {
                    SqlConnection cn = new SqlConnection("Data Source=DESKTOP-9B5R179; Initial Catalog=ProyectoFarmacia;Integrated Security=true;");
                    SqlCommand cmd = new SqlCommand("select v.Codigo_Venta as 'Codigo Venta'," +
                        "c.NIT_CI as 'Cliente'," +
                        "p.Paterno + ' ' + p.Nombre as 'Persona'," +
                        "pr.Nombre_Producto as 'Producto'," +
                        "v.Codigo_Detalle_Venta as 'Detalle Venta'," +
                        "v.Cantidad as 'Cantidad'," +
                        "v.Fecha_Venta as 'Fecha'," +
                        "v.Tipo_Venta as 'Tipo' " +
                        "from Venta v " +
                        "inner join Cliente c " +
                        "on v.Codigo_Cliente = c.Codigo_Cliente " +
                        "inner join Persona p " +
                        "on v.Id_Personas = p.Id_Personas " +
                        "inner join Producto pr " +
                        "on v.Codigo_Producto = pr.Codigo_Producto " +
                        "where v.Tipo_Venta = '" + cbTipo.Text + "'", cn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    DGVdatosV.DataSource = dt;
                    cn.Close();
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un filtro correspondiente");
                }
            }
        }

        private void btnFiltroFecha_Click(object sender, EventArgs e)
        {
            using (ProyectoFarmaciaEntities1 bd = new ProyectoFarmaciaEntities1())
            {
                if (cbDia.Text != "" && cbMes.Text != "" && txtAnio.Text != "" &&
                    cbDia2.Text != "" && cbMes2.Text != "" && txtAnio2.Text != "")
                {
                    SqlConnection cn = new SqlConnection("Data Source=DESKTOP-9B5R179; Initial Catalog=ProyectoFarmacia;Integrated Security=true;");
                    SqlCommand cmd = new SqlCommand("set dateformat dmy " +
                        "select v.Codigo_Venta as 'Codigo Venta'," +
                        "c.NIT_CI as 'Cliente'," +
                        "p.Paterno + ' ' + p.Nombre as 'Persona'," +
                        "pr.Nombre_Producto as 'Producto'," +
                        "v.Codigo_Detalle_Venta as 'Detalle Venta'," +
                        "v.Cantidad as 'Cantidad'," +
                        "v.Fecha_Venta as 'Fecha'," +
                        "v.Tipo_Venta as 'Tipo' " +
                        "from Venta v " +
                        "inner join Cliente c " +
                        "on v.Codigo_Cliente = c.Codigo_Cliente " +
                        "inner join Persona p " +
                        "on v.Id_Personas = p.Id_Personas " +
                        "inner join Producto pr " +
                        "on v.Codigo_Producto = pr.Codigo_Producto " +
                        "where v.Fecha_Venta Between CAST(Concat(" + cbDia.Text + ",'-'," + cbMes.Text + ",'-'," + txtAnio.Text + ") AS datetime) " + 
                        "and CAST(Concat(" + cbDia2.Text + ",'-'," + cbMes2.Text + ",'-'," + txtAnio2.Text + ") AS datetime) ", cn);
                        //"where v.Fecha_Venta = '" + Convert.ToDateTime(dtpFecha.Text) + "'", cn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    DGVdatosV.DataSource = dt;
                    cn.Close();
                }
                else
                {
                    MessageBox.Show("Debe llenar todos los campos necesarios");
                }
            }
        }

        private void btnFiltroProd_Click(object sender, EventArgs e)
        {
            using (ProyectoFarmaciaEntities1 bd = new ProyectoFarmaciaEntities1())
            {
                if (cbProd.Text != "")
                {
                    SqlConnection cn = new SqlConnection("Data Source=DESKTOP-9B5R179; Initial Catalog=ProyectoFarmacia;Integrated Security=true;");
                    SqlCommand cmd = new SqlCommand("select v.Codigo_Venta as 'Codigo Venta'," +
                        "c.NIT_CI as 'Cliente'," +
                        "p.Paterno + ' ' + p.Nombre as 'Persona'," +
                        "pr.Nombre_Producto as 'Producto'," +
                        "v.Codigo_Detalle_Venta as 'Detalle Venta'," +
                        "v.Cantidad as 'Cantidad'," +
                        "v.Fecha_Venta as 'Fecha'," +
                        "v.Tipo_Venta as 'Tipo' " +
                        "from Venta v " +
                        "inner join Cliente c " +
                        "on v.Codigo_Cliente = c.Codigo_Cliente " +
                        "inner join Persona p " +
                        "on v.Id_Personas = p.Id_Personas " +
                        "inner join Producto pr " +
                        "on v.Codigo_Producto = pr.Codigo_Producto " +
                        "where pr.Nombre_Producto = '" + cbProd.Text + "'", cn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    DGVdatosV.DataSource = dt;
                    cn.Close();
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un filtro correspondiente");
                }
            }
        }
        /*
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
   codigo = DGVdatosV.Rows[DGVdatosV.CurrentRow.Index].Cells[0].Value.ToString();
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
}*/
    }
}
