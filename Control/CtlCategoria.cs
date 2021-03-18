using Modelo.Dao;
using Modelo.Dto;
using Sistema_de_gestion_de_productos.Vista;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema_de_gestion_de_productos.Control
{
    class CtlCategoria
    {
        CategoriaDao categoria;
        Categoria cat;
        Form3 vista;
        public CtlCategoria(Form3 vista)
        {
            this.vista = vista;
            vista.Load += new EventHandler(cargarDatos);
            vista.bnAgregar.Click += new EventHandler(agregar);
            //vista.button2.Click += new EventHandler();
            categoria = new CategoriaDao();
            cat = new Categoria();
        }

      

        private void cargarDatos(object sender, EventArgs e)
        {
            vista.dataGridCategotia.DataSource = categoria.verRegistro();                    
                        
        }

        private void agregar(object sender, EventArgs e)
        {
            cat.Nombre = vista.txtNombre.Text;
            cat.Estado = vista.cbEstado.SelectedItem.Equals("Activo");
            categoria.agregar(cat);
            vista.dataGridCategotia.DataSource =categoria.verRegistro();

            System.Windows.Forms.MessageBox.Show("Agregado");
        }
    }
}
