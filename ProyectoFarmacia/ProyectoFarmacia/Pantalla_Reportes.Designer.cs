namespace ProyectoFarmacia
{
    partial class Pantalla_Reportes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pantalla_Reportes));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMinimizar = new System.Windows.Forms.PictureBox();
            this.btnSalir = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.DGVayuda = new System.Windows.Forms.DataGridView();
            this.DGVayuda2 = new System.Windows.Forms.DataGridView();
            this.btnSinFiltro = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DGVdatosV = new System.Windows.Forms.DataGridView();
            this.btnFiltroProd = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbTipo = new System.Windows.Forms.ComboBox();
            this.btnFiltroTipo = new System.Windows.Forms.Button();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.btnFiltroFecha = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbClie = new System.Windows.Forms.ComboBox();
            this.btnFiltroCli = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbProd = new System.Windows.Forms.ComboBox();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.proyectoFarmaciaDataSet = new ProyectoFarmacia.ProyectoFarmaciaDataSet();
            this.ventaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ventaTableAdapter = new ProyectoFarmacia.ProyectoFarmaciaDataSetTableAdapters.VentaTableAdapter();
            this.cbDia = new System.Windows.Forms.ComboBox();
            this.cbMes = new System.Windows.Forms.ComboBox();
            this.txtAnio = new System.Windows.Forms.TextBox();
            this.txtAnio2 = new System.Windows.Forms.TextBox();
            this.cbMes2 = new System.Windows.Forms.ComboBox();
            this.cbDia2 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVayuda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVayuda2)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVdatosV)).BeginInit();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.proyectoFarmaciaDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ventaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(191)))), ((int)(((byte)(225)))));
            this.panel1.Controls.Add(this.btnMinimizar);
            this.panel1.Controls.Add(this.btnSalir);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1600, 92);
            this.panel1.TabIndex = 0;
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimizar.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimizar.Image")));
            this.btnMinimizar.Location = new System.Drawing.Point(1469, 25);
            this.btnMinimizar.Margin = new System.Windows.Forms.Padding(4);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(53, 49);
            this.btnMinimizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnMinimizar.TabIndex = 8;
            this.btnMinimizar.TabStop = false;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSalir.BackgroundImage")));
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(1531, 25);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(53, 49);
            this.btnSalir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnSalir.TabIndex = 2;
            this.btnSalir.TabStop = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(16, 15);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 59);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(99, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 33);
            this.label1.TabIndex = 6;
            this.label1.Text = "Reportes";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SlateGray;
            this.panel2.Controls.Add(this.DGVayuda);
            this.panel2.Controls.Add(this.DGVayuda2);
            this.panel2.Controls.Add(this.btnSinFiltro);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 92);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1600, 878);
            this.panel2.TabIndex = 1;
            // 
            // DGVayuda
            // 
            this.DGVayuda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVayuda.Location = new System.Drawing.Point(1531, 620);
            this.DGVayuda.Name = "DGVayuda";
            this.DGVayuda.RowTemplate.Height = 24;
            this.DGVayuda.Size = new System.Drawing.Size(26, 14);
            this.DGVayuda.TabIndex = 21;
            // 
            // DGVayuda2
            // 
            this.DGVayuda2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVayuda2.Location = new System.Drawing.Point(1530, 640);
            this.DGVayuda2.Name = "DGVayuda2";
            this.DGVayuda2.RowTemplate.Height = 24;
            this.DGVayuda2.Size = new System.Drawing.Size(26, 14);
            this.DGVayuda2.TabIndex = 1;
            // 
            // btnSinFiltro
            // 
            this.btnSinFiltro.BackColor = System.Drawing.Color.LimeGreen;
            this.btnSinFiltro.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnSinFiltro.FlatAppearance.BorderSize = 0;
            this.btnSinFiltro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.ForestGreen;
            this.btnSinFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSinFiltro.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSinFiltro.ForeColor = System.Drawing.Color.White;
            this.btnSinFiltro.Image = ((System.Drawing.Image)(resources.GetObject("btnSinFiltro.Image")));
            this.btnSinFiltro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSinFiltro.Location = new System.Drawing.Point(743, 662);
            this.btnSinFiltro.Margin = new System.Windows.Forms.Padding(4);
            this.btnSinFiltro.Name = "btnSinFiltro";
            this.btnSinFiltro.Size = new System.Drawing.Size(200, 55);
            this.btnSinFiltro.TabIndex = 20;
            this.btnSinFiltro.Text = "     Sin Filtros";
            this.btnSinFiltro.UseVisualStyleBackColor = false;
            this.btnSinFiltro.Click += new System.EventHandler(this.btnInsertar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.LightSlateGray;
            this.groupBox2.Controls.Add(this.DGVdatosV);
            this.groupBox2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(743, 55);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(780, 599);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Listado de Ventas";
            // 
            // DGVdatosV
            // 
            this.DGVdatosV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVdatosV.Location = new System.Drawing.Point(7, 23);
            this.DGVdatosV.Name = "DGVdatosV";
            this.DGVdatosV.RowTemplate.Height = 24;
            this.DGVdatosV.Size = new System.Drawing.Size(766, 569);
            this.DGVdatosV.TabIndex = 0;
            // 
            // btnFiltroProd
            // 
            this.btnFiltroProd.BackColor = System.Drawing.Color.DarkOrange;
            this.btnFiltroProd.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnFiltroProd.FlatAppearance.BorderSize = 0;
            this.btnFiltroProd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Chocolate;
            this.btnFiltroProd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltroProd.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltroProd.ForeColor = System.Drawing.Color.White;
            this.btnFiltroProd.Image = ((System.Drawing.Image)(resources.GetObject("btnFiltroProd.Image")));
            this.btnFiltroProd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFiltroProd.Location = new System.Drawing.Point(377, 55);
            this.btnFiltroProd.Margin = new System.Windows.Forms.Padding(4);
            this.btnFiltroProd.Name = "btnFiltroProd";
            this.btnFiltroProd.Size = new System.Drawing.Size(147, 43);
            this.btnFiltroProd.TabIndex = 18;
            this.btnFiltroProd.Text = "     Filtrar";
            this.btnFiltroProd.UseVisualStyleBackColor = false;
            this.btnFiltroProd.Click += new System.EventHandler(this.btnFiltroProd_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Controls.Add(this.btnVolver);
            this.panel3.Controls.Add(this.btnExport);
            this.panel3.Controls.Add(this.dtpFecha);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 92);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(675, 878);
            this.panel3.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtAnio2);
            this.groupBox1.Controls.Add(this.cbMes2);
            this.groupBox1.Controls.Add(this.cbDia2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtAnio);
            this.groupBox1.Controls.Add(this.cbMes);
            this.groupBox1.Controls.Add(this.cbDia);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbTipo);
            this.groupBox1.Controls.Add(this.btnFiltroTipo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnFiltroFecha);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbClie);
            this.groupBox1.Controls.Add(this.btnFiltroCli);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbProd);
            this.groupBox1.Controls.Add(this.btnFiltroProd);
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(53, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(550, 475);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 213);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 23);
            this.label5.TabIndex = 29;
            this.label5.Text = "Tipo:";
            // 
            // cbTipo
            // 
            this.cbTipo.FormattingEnabled = true;
            this.cbTipo.Location = new System.Drawing.Point(140, 210);
            this.cbTipo.Name = "cbTipo";
            this.cbTipo.Size = new System.Drawing.Size(217, 31);
            this.cbTipo.TabIndex = 27;
            // 
            // btnFiltroTipo
            // 
            this.btnFiltroTipo.BackColor = System.Drawing.Color.DarkOrange;
            this.btnFiltroTipo.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnFiltroTipo.FlatAppearance.BorderSize = 0;
            this.btnFiltroTipo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Chocolate;
            this.btnFiltroTipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltroTipo.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltroTipo.ForeColor = System.Drawing.Color.White;
            this.btnFiltroTipo.Image = ((System.Drawing.Image)(resources.GetObject("btnFiltroTipo.Image")));
            this.btnFiltroTipo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFiltroTipo.Location = new System.Drawing.Point(377, 204);
            this.btnFiltroTipo.Margin = new System.Windows.Forms.Padding(4);
            this.btnFiltroTipo.Name = "btnFiltroTipo";
            this.btnFiltroTipo.Size = new System.Drawing.Size(147, 43);
            this.btnFiltroTipo.TabIndex = 28;
            this.btnFiltroTipo.Text = "     Filtrar";
            this.btnFiltroTipo.UseVisualStyleBackColor = false;
            this.btnFiltroTipo.Click += new System.EventHandler(this.btnFiltroTipo_Click);
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(214, 708);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(217, 22);
            this.dtpFecha.TabIndex = 26;
            this.dtpFecha.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(77, 328);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 23);
            this.label4.TabIndex = 25;
            this.label4.Text = "Desde:";
            // 
            // btnFiltroFecha
            // 
            this.btnFiltroFecha.BackColor = System.Drawing.Color.DarkOrange;
            this.btnFiltroFecha.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnFiltroFecha.FlatAppearance.BorderSize = 0;
            this.btnFiltroFecha.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Chocolate;
            this.btnFiltroFecha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltroFecha.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltroFecha.ForeColor = System.Drawing.Color.White;
            this.btnFiltroFecha.Image = ((System.Drawing.Image)(resources.GetObject("btnFiltroFecha.Image")));
            this.btnFiltroFecha.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFiltroFecha.Location = new System.Drawing.Point(224, 413);
            this.btnFiltroFecha.Margin = new System.Windows.Forms.Padding(4);
            this.btnFiltroFecha.Name = "btnFiltroFecha";
            this.btnFiltroFecha.Size = new System.Drawing.Size(168, 43);
            this.btnFiltroFecha.TabIndex = 24;
            this.btnFiltroFecha.Text = "     Filtrar";
            this.btnFiltroFecha.UseVisualStyleBackColor = false;
            this.btnFiltroFecha.Click += new System.EventHandler(this.btnFiltroFecha_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 23);
            this.label3.TabIndex = 22;
            this.label3.Text = "CI Cliente:";
            // 
            // cbClie
            // 
            this.cbClie.FormattingEnabled = true;
            this.cbClie.Location = new System.Drawing.Point(140, 138);
            this.cbClie.Name = "cbClie";
            this.cbClie.Size = new System.Drawing.Size(217, 31);
            this.cbClie.TabIndex = 20;
            // 
            // btnFiltroCli
            // 
            this.btnFiltroCli.BackColor = System.Drawing.Color.DarkOrange;
            this.btnFiltroCli.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnFiltroCli.FlatAppearance.BorderSize = 0;
            this.btnFiltroCli.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Chocolate;
            this.btnFiltroCli.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltroCli.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltroCli.ForeColor = System.Drawing.Color.White;
            this.btnFiltroCli.Image = ((System.Drawing.Image)(resources.GetObject("btnFiltroCli.Image")));
            this.btnFiltroCli.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFiltroCli.Location = new System.Drawing.Point(377, 132);
            this.btnFiltroCli.Margin = new System.Windows.Forms.Padding(4);
            this.btnFiltroCli.Name = "btnFiltroCli";
            this.btnFiltroCli.Size = new System.Drawing.Size(147, 43);
            this.btnFiltroCli.TabIndex = 21;
            this.btnFiltroCli.Text = "     Filtrar";
            this.btnFiltroCli.UseVisualStyleBackColor = false;
            this.btnFiltroCli.Click += new System.EventHandler(this.btnFiltroCli_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 23);
            this.label2.TabIndex = 19;
            this.label2.Text = "Producto:";
            // 
            // cbProd
            // 
            this.cbProd.FormattingEnabled = true;
            this.cbProd.Location = new System.Drawing.Point(140, 61);
            this.cbProd.Name = "cbProd";
            this.cbProd.Size = new System.Drawing.Size(217, 31);
            this.cbProd.TabIndex = 0;
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.White;
            this.btnVolver.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnVolver.FlatAppearance.BorderSize = 2;
            this.btnVolver.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolver.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnVolver.Image = ((System.Drawing.Image)(resources.GetObject("btnVolver.Image")));
            this.btnVolver.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVolver.Location = new System.Drawing.Point(189, 580);
            this.btnVolver.Margin = new System.Windows.Forms.Padding(4);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Padding = new System.Windows.Forms.Padding(27, 0, 0, 0);
            this.btnVolver.Size = new System.Drawing.Size(321, 54);
            this.btnVolver.TabIndex = 18;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.White;
            this.btnExport.FlatAppearance.BorderColor = System.Drawing.Color.DodgerBlue;
            this.btnExport.FlatAppearance.BorderSize = 2;
            this.btnExport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(169, 802);
            this.btnExport.Margin = new System.Windows.Forms.Padding(4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Padding = new System.Windows.Forms.Padding(27, 0, 0, 0);
            this.btnExport.Size = new System.Drawing.Size(321, 54);
            this.btnExport.TabIndex = 17;
            this.btnExport.Text = "Exportar PDF";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Visible = false;
            this.btnExport.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // proyectoFarmaciaDataSet
            // 
            this.proyectoFarmaciaDataSet.DataSetName = "ProyectoFarmaciaDataSet";
            this.proyectoFarmaciaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ventaBindingSource
            // 
            this.ventaBindingSource.DataMember = "Venta";
            this.ventaBindingSource.DataSource = this.proyectoFarmaciaDataSet;
            // 
            // ventaTableAdapter
            // 
            this.ventaTableAdapter.ClearBeforeFill = true;
            // 
            // cbDia
            // 
            this.cbDia.FormattingEnabled = true;
            this.cbDia.Location = new System.Drawing.Point(193, 326);
            this.cbDia.Name = "cbDia";
            this.cbDia.Size = new System.Drawing.Size(75, 31);
            this.cbDia.TabIndex = 30;
            // 
            // cbMes
            // 
            this.cbMes.FormattingEnabled = true;
            this.cbMes.Location = new System.Drawing.Point(274, 326);
            this.cbMes.Name = "cbMes";
            this.cbMes.Size = new System.Drawing.Size(77, 31);
            this.cbMes.TabIndex = 31;
            // 
            // txtAnio
            // 
            this.txtAnio.Location = new System.Drawing.Point(357, 325);
            this.txtAnio.MaxLength = 4;
            this.txtAnio.Name = "txtAnio";
            this.txtAnio.Size = new System.Drawing.Size(100, 32);
            this.txtAnio.TabIndex = 32;
            // 
            // txtAnio2
            // 
            this.txtAnio2.Location = new System.Drawing.Point(357, 363);
            this.txtAnio2.MaxLength = 4;
            this.txtAnio2.Name = "txtAnio2";
            this.txtAnio2.Size = new System.Drawing.Size(100, 32);
            this.txtAnio2.TabIndex = 36;
            // 
            // cbMes2
            // 
            this.cbMes2.FormattingEnabled = true;
            this.cbMes2.Location = new System.Drawing.Point(274, 364);
            this.cbMes2.Name = "cbMes2";
            this.cbMes2.Size = new System.Drawing.Size(77, 31);
            this.cbMes2.TabIndex = 35;
            // 
            // cbDia2
            // 
            this.cbDia2.FormattingEnabled = true;
            this.cbDia2.Location = new System.Drawing.Point(193, 364);
            this.cbDia2.Name = "cbDia2";
            this.cbDia2.Size = new System.Drawing.Size(75, 31);
            this.cbDia2.TabIndex = 34;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(77, 366);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 23);
            this.label6.TabIndex = 33;
            this.label6.Text = "Hasta:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(198, 290);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 23);
            this.label7.TabIndex = 37;
            this.label7.Text = "Dia";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(287, 290);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 23);
            this.label8.TabIndex = 38;
            this.label8.Text = "Mes";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(381, 290);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 23);
            this.label9.TabIndex = 39;
            this.label9.Text = "Año";
            // 
            // Pantalla_Reportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1600, 970);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Pantalla_Reportes";
            this.Opacity = 0.9D;
            this.Text = "Pantalla_Productos";
            this.Load += new System.EventHandler(this.Pantalla_Productos_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSalir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVayuda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVayuda2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVdatosV)).EndInit();
            this.panel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.proyectoFarmaciaDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ventaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox btnSalir;
        private System.Windows.Forms.PictureBox btnMinimizar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSinFiltro;
        private System.Windows.Forms.Button btnFiltroProd;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DataGridView DGVdatosV;
        private System.Windows.Forms.DataGridView DGVayuda;
        private System.Windows.Forms.DataGridView DGVayuda2;
        private ProyectoFarmaciaDataSet proyectoFarmaciaDataSet;
        private System.Windows.Forms.BindingSource ventaBindingSource;
        private ProyectoFarmaciaDataSetTableAdapters.VentaTableAdapter ventaTableAdapter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbProd;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnFiltroFecha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbClie;
        private System.Windows.Forms.Button btnFiltroCli;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbTipo;
        private System.Windows.Forms.Button btnFiltroTipo;
        private System.Windows.Forms.TextBox txtAnio;
        private System.Windows.Forms.ComboBox cbMes;
        private System.Windows.Forms.ComboBox cbDia;
        private System.Windows.Forms.TextBox txtAnio2;
        private System.Windows.Forms.ComboBox cbMes2;
        private System.Windows.Forms.ComboBox cbDia2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
    }
}