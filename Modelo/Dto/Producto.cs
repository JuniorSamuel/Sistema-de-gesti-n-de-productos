using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Dto
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Codigo { get; set; }
        public bool Stock { get; set; }
        public string FechaVencimiento { get; set; }
        public string Descripcion { get; set; }
        public int Categoria { get; set; }
        public bool Estado { get; set; }
    }
}