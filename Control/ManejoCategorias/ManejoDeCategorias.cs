using System;
using System.Collections.Generic;
using System.Text;
using Modelo.Dto;
using Modelo.Dao;
using System.Data.Sql;
namespace Sistema_de_gestion_de_productos.Control
{
    class ManejoDeCategorias
    {
        public void insertar(string nombre, string estado)
        {
            Categoria nuevaCat = new Categoria();
            nuevaCat.Nombre = nombre;
            bool evaluadorEstado;
            if (estado == "Activo") { evaluadorEstado = true; } else { evaluadorEstado = false; }
            nuevaCat.Estado = evaluadorEstado;

            CategoriaDao metodos = new CategoriaDao();
            metodos.agregar(nuevaCat);
        }

        
    }
}
