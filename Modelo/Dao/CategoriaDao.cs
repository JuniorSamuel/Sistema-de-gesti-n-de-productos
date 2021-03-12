using Modelo.Dto;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Text;

namespace Modelo.Dao
{
    class CategoriaDao
    {
        public CategoriaDao()
        {
            ConnectorSQLite.CreateTable();
        }

        public ArrayList verRegistro()
        {
            ArrayList Categorias = new ArrayList();
            SQLiteConnection conn = ConnectorSQLite.CreateConnection();
            SQLiteCommand command;
            SQLiteDataReader reader;
            command = conn.CreateCommand();
            command.CommandText = "select * from Categoria";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Categoria categoria = new Categoria();
                categoria.Id = reader.GetInt32(0);
                categoria.Nombre = reader.GetString(1);
                categoria.Estado = reader.GetBoolean(2);
                Categorias.Add(categoria);
            }
            conn.Close();
            return Categorias;
        }

        public void agregar(Categoria categoria)
        {
            SQLiteConnection conn = ConnectorSQLite.CreateConnection();
            SQLiteCommand sqliteCommand;
            sqliteCommand = conn.CreateCommand();
            sqliteCommand.CommandText = "INSERT INTO Categoria( Nombre, Estado) VALUES ('" + categoria.Nombre + "', " + categoria.Estado + ");";
            sqliteCommand.ExecuteNonQuery();
            conn.Close();
        }

        public void modificar(Categoria categoria)
        {
            SQLiteConnection conn = ConnectorSQLite.CreateConnection();
            SQLiteCommand sqliteCommand;
            sqliteCommand = conn.CreateCommand();
            sqliteCommand.CommandText = "UPDATE Categoria set Nombre = '" + categoria.Nombre + "', Estado = " + categoria.Estado + " WHERE IdCategoria = " + categoria.Id + ";";
            sqliteCommand.ExecuteNonQuery();
            conn.Close();
        }

        public void eliminar(Categoria categoria)
        {
            SQLiteConnection conn = ConnectorSQLite.CreateConnection();
            SQLiteCommand sqliteCommand;
            sqliteCommand = conn.CreateCommand();
            sqliteCommand.CommandText = "DELETE FROM Categoria WHERE IdCategoria = " + categoria.Id + ";";
            sqliteCommand.ExecuteNonQuery();
            conn.Close();
        }

    }

}