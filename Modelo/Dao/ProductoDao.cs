using Modelo.Dto;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Text;

namespace Modelo.Dao
{
    class ProductoDao
    {

        public ProductoDao()
        {
            ConnectorSQLite.CreateTable();
        }
        public List<Producto> verRegistro()
        {
            List<Producto> Productos= new List<Producto>();
            SQLiteConnection conn = ConnectorSQLite.CreateConnection();
            SQLiteCommand command;
            SQLiteDataReader reader;
            command = conn.CreateCommand();
            command.CommandText = "select * from Producto";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Producto producto = new Producto();
                producto.Id = reader.GetInt32(0);
                producto.Nombre = reader.GetString(1);
                producto.Codigo = reader.GetInt32(2);
                producto.Stock = reader.GetBoolean(3);
                producto.FechaVencimiento = reader.GetString(4);
                producto.Descripcion = reader.GetString(5);
                producto.Categoria = reader.GetInt32(6);
                producto.Estado = reader.GetBoolean(7);
                Productos.Add(producto);
            }
            conn.Close();
            return Productos;
        }

        public DataSet dataSet()
        {
            DataSet ds = new DataSet();
            SQLiteDataAdapter da = new SQLiteDataAdapter("select * from Producto", ConnectorSQLite.CreateConnection());
            da.Fill(ds);
            return ds;
        }

        public DataSet filtrar(string buscar)
        {
            DataSet ds = new DataSet();
            SQLiteDataAdapter da = new SQLiteDataAdapter("select * from Producto where Nombre = '" + buscar + "%'", ConnectorSQLite.CreateConnection());
            da.Fill(ds);
            return ds;
        }
        public void agregar(Producto producto)
        {
            SQLiteConnection conn = ConnectorSQLite.CreateConnection();
            SQLiteCommand sqliteCommand;
            sqliteCommand = conn.CreateCommand();
            sqliteCommand.CommandText = "INSERT INTO Categoria( Nombre, Estado) VALUES ('" + producto.Nombre + "', " + producto.Estado + ");";
            sqliteCommand.ExecuteNonQuery();
            conn.Close();
        }

        public void modificar(Producto producto)
        {
            SQLiteConnection conn = ConnectorSQLite.CreateConnection();
            SQLiteCommand sqliteCommand;
            sqliteCommand = conn.CreateCommand();
            sqliteCommand.CommandText = @"UPDATE Categoria set 
                                            Nombre = '" + producto.Nombre + "'," +
                                            "Codigo = " + producto.Codigo + "," +
                                            "Stock = " + producto.Stock + "," +
                                            "Fecha_vencimiento = '" + producto.FechaVencimiento + "'," +
                                            "Descripcion = '" + producto.Descripcion + "'," +
                                            "Categoria = " + producto.Categoria + "," +
                                            "Estado = " + producto.Estado + " " +
                                            "WHERE IdCategoria = " + producto.Id + ";";
            sqliteCommand.ExecuteNonQuery();
            conn.Close();
        }

        public void eliminar(Producto producto)
        {
            SQLiteConnection conn = ConnectorSQLite.CreateConnection();
            SQLiteCommand sqliteCommand;
            sqliteCommand = conn.CreateCommand();
            sqliteCommand.CommandText = "DELETE FROM Categoria WHERE IdCategoria = " + producto.Id + ";";
            sqliteCommand.ExecuteNonQuery();
            conn.Close();
        }
    }
}