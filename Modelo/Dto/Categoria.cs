using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Dto
{
    class Categoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }

        public Categoria(int Id, string Nombre, bool Estado)
        {
            this.Id = Id;
            this.Nombre = Nombre;
            this.Estado = Estado;
        }
        public Categoria()
        {

        }
    }   
}
