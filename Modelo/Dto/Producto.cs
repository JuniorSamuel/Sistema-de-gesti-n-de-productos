using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Dto
{
    public class Producto
    {
        //Propiedades
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Codigo { get; set; }
        public bool Stock { get; set; }
        public string FechaVencimiento { get; set; }
        public string Descripcion { get; set; }
        public int Categoria { get; set; }
        public bool Estado { get; set; }

        //Contrustor
        public Producto(int Id, string Nombre, int Codigo, bool Stock, string Fecha, string Descripcion, int Categoria, bool Estado)
        {
            this.Id = Id;
            this.Nombre = Nombre;
            this.Codigo = Codigo;
            this.Stock = Stock;
            this.FechaVencimiento = Fecha;
            this.Descripcion = Descripcion;
            this.Categoria = Categoria;
            this.Estado = Estado;
        }

        public Producto()
        {

        }
    }    
}