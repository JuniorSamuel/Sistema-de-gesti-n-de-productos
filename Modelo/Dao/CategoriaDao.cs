using Modelo.Dto;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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

        public List<Categoria> verRegistro()
        {
            ConnectorSQLite.CreateTable();
            List<Categoria> Categorias = new List<Categoria>();
            SQLiteConnection conn = ConnectorSQLite.CreateConnection();
            SQLiteCommand command;
            SQLiteDataReader reader;
            command = conn.CreateCommand();
            command.CommandText = "select * from Categoria";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Categorias.Add( new Categoria(
                reader.GetInt32(0),
                reader.GetString(1),
                reader.GetBoolean(2)
                ));                
            }
            conn.Close();
            return Categorias;
        }

        public DataTable dataSet()
        {
            DataTable ds = new DataTable();
            SQLiteDataAdapter da = new SQLiteDataAdapter("select * from Categoria", ConnectorSQLite.CreateConnection());
            da.Fill(ds);
            return ds;
        }

        public List<Categoria> filtrar(Categoria categoria)
        {
            List<Categoria> Categorias = new List<Categoria>();
            SQLiteConnection conn = ConnectorSQLite.CreateConnection();
            SQLiteCommand command;
            SQLiteDataReader reader;
            command = conn.CreateCommand();
            command.CommandText = "select * from Categoria where Nombre Like '" + categoria.Nombre + "%'";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Categorias.Add(new Categoria(
                reader.GetInt32(0),
                reader.GetString(1),
                reader.GetBoolean(2)
                ));
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