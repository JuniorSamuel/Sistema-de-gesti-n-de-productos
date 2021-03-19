using Modelo.Dao;
using Modelo.Dto;
using Sistema_de_gestion_de_productos.Vista;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Sistema_de_gestion_de_productos.Control
{
    class CtlCategoria
    {
        CategoriaDao categoria;
        Categoria Contenedor;
        Form3 vista;
        public CtlCategoria(Form3 vista)
        {
            this.vista = vista;
            vista.Load += new EventHandler(cargarDatos);
            vista.bnAgregar.Click += new EventHandler(agregar);           
            vista.btnEliminar.Click += new EventHandler(EliminarDatos);
            vista.btnModificar.Click += new EventHandler(ModificarDatos);
            vista.txtBuscarCat.TextChanged += new EventHandler(BuscarDatos);
            vista.dataGridCategotia.CellClick += new DataGridViewCellEventHandler(selectdata);
            
            categoria = new CategoriaDao();
            Contenedor = new Categoria();
        }

        private void selectdata(object sender, DataGridViewCellEventArgs e)
        {
            if (vista.dataGridCategotia.Rows[e.RowIndex].Cells[e.ColumnIndex].Value !=null)
            {
                vista.dataGridCategotia.CurrentRow.Selected = true;
                vista.txtID.Text = vista.dataGridCategotia.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                vista.txtNombre.Text = vista.dataGridCategotia.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                
               
                if (vista.dataGridCategotia.Rows[e.RowIndex].Cells[2].FormattedValue.ToString() == "True")
                {
                    vista.cbEstado.SelectedIndex = 0;
                }
                else
                {
                    vista.cbEstado.SelectedIndex = 1;
                }
            }
        }

        private void cargarDatos(object sender, EventArgs e)
        {
            vista.dataGridCategotia.DataSource = categoria.verRegistro();                    
                        
        }
        private void BuscarDatos(object sender, EventArgs e)
        {
            Contenedor.Nombre = vista.txtBuscarCat.Text;
            vista.dataGridCategotia.DataSource = categoria.filtrar(Contenedor);

        }

     
        private void ModificarDatos(object sender, EventArgs e)
        {
            Contenedor.Id = int.Parse(vista.txtID.Text);
            Contenedor.Nombre = vista.txtNombre.Text;
            Contenedor.Estado = vista.cbEstado.SelectedItem.Equals("Activo");
            categoria.modificar(Contenedor);
            vista.dataGridCategotia.DataSource = categoria.verRegistro();

        }
    private void EliminarDatos(object sender, EventArgs e)
        {
            Contenedor.Id = int.Parse(vista.txtID.Text);
            categoria.eliminar(Contenedor);
            
            vista.dataGridCategotia.DataSource = categoria.verRegistro();
        }

        private void agregar(object sender, EventArgs e)
        {
            Contenedor.Nombre = vista.txtNombre.Text;
            Contenedor.Estado = vista.cbEstado.SelectedItem.Equals("Activo");
            categoria.agregar(Contenedor);
            vista.dataGridCategotia.DataSource =categoria.verRegistro();

            System.Windows.Forms.MessageBox.Show("Agregado");
        }
    }
}
