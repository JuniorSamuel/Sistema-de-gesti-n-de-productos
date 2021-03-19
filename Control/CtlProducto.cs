using Modelo.Dao;
using Modelo.Dto;
using Sistema_de_gestion_de_productos.Vista;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Sistema_de_gestion_de_productos.Control
{
    class CtlProducto
    {
        private ProductoDao producto;
        Producto contenedor;
        private Form2 vistaPro;        

        public CtlProducto(Form2 vistaPro)
        {
            this.vistaPro = vistaPro;
            vistaPro.Load += new EventHandler(cargarDatos);
            vistaPro.btAgregar.Click += new EventHandler(agregar);
            vistaPro.btEliminar.Click += new EventHandler(eliminar);
            vistaPro.btModificar.Click += new EventHandler(modificar);
            vistaPro.dataGridProducto.CellClick += new DataGridViewCellEventHandler(selectdata);
            producto = new ProductoDao();
            contenedor = new Producto();    
        }

        private void cargarDatos(object sender, EventArgs e)
        {
            CategoriaDao categoria = new CategoriaDao();
            vistaPro.dataGridProducto.DataSource = producto.verRegistro();         
            foreach (Categoria c in categoria.verRegistro())
            {
                vistaPro.cbCategoria.Items.Add( c.Id);                
            }
            
        }

        private void agregar(object sender, EventArgs e)
        {
            contenedor.Nombre = vistaPro.txtNombre.Text;
            contenedor.Stock = vistaPro.cbEstado.SelectedItem.Equals("Activo");
            contenedor.FechaVencimiento = vistaPro.dtFecha.Text;
            contenedor.Descripcion = vistaPro.txtDescripcion.Text;
            contenedor.Categoria = Int32.Parse(vistaPro.cbCategoria.Text);
            contenedor.Estado = vistaPro.cbEstado.SelectedItem.Equals("Activo");
            producto.agregar(contenedor);
            System.Windows.Forms.MessageBox.Show("Producto Agregado.");
            vistaPro.dataGridProducto.DataSource = producto.verRegistro();
        }

        private void modificar(object sender, EventArgs e)
        {
            contenedor.Id = Int32.Parse(vistaPro.txtID.Text);
            contenedor.Nombre = vistaPro.txtNombre.Text;
            contenedor.Stock = vistaPro.cbEstado.SelectedItem.Equals("Activo");
            contenedor.FechaVencimiento = vistaPro.dtFecha.Text;
            contenedor.Descripcion = vistaPro.txtDescripcion.Text;
            contenedor.Categoria = Int32.Parse(vistaPro.cbCategoria.Text);
            contenedor.Estado = vistaPro.cbEstado.SelectedItem.Equals("Activo");
            producto.modificar(contenedor);
            System.Windows.Forms.MessageBox.Show("Producto Modificado.");
            vistaPro.dataGridProducto.DataSource = producto.verRegistro();
        }
        private void selectdata(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (vistaPro.dataGridProducto.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    vistaPro.dataGridProducto.CurrentRow.Selected = true;
                    vistaPro.txtID.Text = vistaPro.dataGridProducto.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                    vistaPro.txtNombre.Text = vistaPro.dataGridProducto.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                    if (vistaPro.dataGridProducto.Rows[e.RowIndex].Cells[2].FormattedValue.ToString() == "True")
                    {
                        vistaPro.cbEstado.SelectedIndex = 0;
                    }
                    else
                    {
                        vistaPro.cbEstado.SelectedIndex = 1;
                    }
                }
            }
            catch
            {

            }
        }
        private void eliminar(object sender, EventArgs e)
        {
            contenedor.Id = Int32.Parse(vistaPro.txtID.Text);
            producto.eliminar(contenedor);
            System.Windows.Forms.MessageBox.Show("Producto Eliminado.");
            vistaPro.dataGridProducto.DataSource = producto.verRegistro();
        }

        private void buscar(object sender, EventArgs e)
        {
            contenedor.Nombre = vistaPro.txtBuscar.Text;
            vistaPro.dataGridProducto.DataSource = producto.filtrar(vistaPro.txtBuscar.Text);
            System.Windows.Forms.MessageBox.Show("Producto Encontrado.");
        }

        //Metodos de apoyo

        private bool valorVerdad(string value)
        {
            return value == "Activo";
        }
    }
}

