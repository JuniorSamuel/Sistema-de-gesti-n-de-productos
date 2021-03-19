using Modelo.Dao;
using Modelo.Dto;
using Sistema_de_gestion_de_productos.Vista;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Sistema_de_gestion_de_productos.Control
{
    class CtlProducto
    {
        private ProductoDao producto;
        private Form2 vistaPro;        

        public CtlProducto(Form2 vistaPro)
        {
            this.vistaPro = vistaPro;
            vistaPro.Load += new EventHandler(cargarDatos);
            vistaPro.btAgregar.Click += new EventHandler(agregar);

            producto = new ProductoDao();            
        }

        private void cargarDatos(object sender, EventArgs e)
        {
            CategoriaDao categoria = new CategoriaDao();
            vistaPro.dataGridProductor.DataSource = producto.verRegistro();                      
            foreach (Categoria c in categoria.verRegistro())
            {
                vistaPro.cbCategoria.Items.Add( c.Id);                
            }
            
        }

        private void agregar(object sender, EventArgs e)
        {
            producto.agregar( new Producto(
                0,
                vistaPro.txtNombre.Text,
                Int32.Parse(vistaPro.txtCodigo.Text),
                vistaPro.cbStock.Text == "Activo",
                vistaPro.dtFecha.Text,
                vistaPro.txtDescripcion.Text,
                Int32.Parse(vistaPro.cbCategoria.Text),
                vistaPro.cbEstado.Text == "Activo"
                ));
            vistaPro.dataGridProductor.DataSource = producto.verRegistro();           
        }

        private void modificar(object sender, EventArgs e)
        {
        
            
        }

        private void eliminar(object sender, EventArgs e)
        {

        }

        private void buscar(object sender, EventArgs e)
        {
        

        }

        //Metodos de apoyo

        private bool valorVerdad(string value)
        {
            return value == "Activo";
        }
    }
}

