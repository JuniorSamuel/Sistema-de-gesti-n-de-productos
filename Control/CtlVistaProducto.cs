using Modelo.Dao;
using Sistema_de_gestion_de_productos.Vista;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Sistema_de_gestion_de_productos.Control
{
    class CtlVistaProducto
    {
        private Form4 vista4;
        private ProductoDao producto;
        public CtlVistaProducto(Form4 form4)
        {
            vista4 = form4;
            producto = new ProductoDao();
            vista4.Load += new EventHandler(cargarDatos);
            vista4.textBox1.TextChanged += new EventHandler(buscar);
        }

        private void buscar(object sender, EventArgs e)
        {            
            vista4.dataGridVistaProducto.DataSource = producto.filtrar(vista4.textBox1.Text);
            vista4.dataGridVistaProducto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void cargarDatos(object sender, EventArgs e)
        {
            vista4.dataGridVistaProducto.DataSource = producto.verRegistro();
            vista4.dataGridVistaProducto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
