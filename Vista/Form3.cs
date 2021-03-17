using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Modelo.Dao;
namespace Sistema_de_gestion_de_productos.Vista
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            CategoriaDao prueba = new CategoriaDao();
            dataGridView1.DataSource = prueba.verRegistro();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Control.ManejoDeCategorias Insertor = new Control.ManejoDeCategorias();
            Insertor.insertar(textBox9.Text, cbxEstadoCat.SelectedIndex.ToString());
            
        }
    }
}
