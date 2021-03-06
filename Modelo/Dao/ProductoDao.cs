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
            
                ConnectorSQLite.CreateTable();
                List<Producto> Productos = new List<Producto>();
                SQLiteConnection conn = ConnectorSQLite.CreateConnection();
                SQLiteCommand command;
                SQLiteDataReader reader;
                command = conn.CreateCommand();

                command.CommandText = "select * from Producto";
            try
            {
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Productos.Add(new Producto(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetInt32(2),
                    reader.GetBoolean(3),
                    reader.GetString(4),
                    reader.GetString(5),
                    reader.GetInt32(6),
                    reader.GetBoolean(7)
                    ));

                }
            }
            catch (SQLiteException e)
            {
                System.Windows.Forms.MessageBox.Show(e.ToString());
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

        public List<Producto> filtrar(string buscar)
        {
            List<Producto> Productos = new List<Producto>();
            SQLiteConnection conn = ConnectorSQLite.CreateConnection();
            SQLiteCommand command;
            SQLiteDataReader reader;
            command = conn.CreateCommand();
            command.CommandText = "select * from Producto where Nombre Like '" + buscar + "%'";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Productos.Add(new Producto(
                reader.GetInt32(0),
                reader.GetString(1),
                reader.GetInt32(2),
                reader.GetBoolean(3),
                reader.GetString(4),
                reader.GetString(5),
                reader.GetInt32(6),
                reader.GetBoolean(7)
                ));

            }
            conn.Close();
            return Productos;
        }

        public void agregar(Producto producto)
        {
            SQLiteConnection conn = ConnectorSQLite.CreateConnection();
            SQLiteCommand sqliteCommand;
            sqliteCommand = conn.CreateCommand();
            sqliteCommand.CommandText = @"INSERT INTO Producto( Nombre, Codigo, Stock, Fecha_vencimiento, Descripcion, Categoria, Estado) VALUES ("+
                "'" + producto.Nombre + "', " +
                "" + producto.Codigo + ", " +
                "" + producto.Stock + ", " +
                "'" + producto.FechaVencimiento + "', " +
                "'" + producto.Descripcion + "', " +
                "" + producto.Categoria + ", " +
                "" + producto.Estado + ");";
            sqliteCommand.ExecuteNonQuery();            
            conn.Close();
        }

        public void modificar(Producto producto)
        {
            SQLiteConnection conn = ConnectorSQLite.CreateConnection();
            SQLiteCommand sqliteCommand;
            sqliteCommand = conn.CreateCommand();
            sqliteCommand.CommandText = @"UPDATE Producto set 
                                            Nombre = '" + producto.Nombre + "'," +
                                            "Codigo = " + producto.Codigo + "," +
                                            "Stock = " + producto.Stock + "," +
                                            "Fecha_vencimiento = '" + producto.FechaVencimiento + "'," +
                                            "Descripcion = '" + producto.Descripcion + "'," +
                                            "Categoria = " + producto.Categoria + "," +
                                            "Estado = " + producto.Estado + " " +
                                            "WHERE IdProducto = " + producto.Id + ";";
            sqliteCommand.ExecuteNonQuery();
            conn.Close();
        }

        public void eliminar(Producto producto)
        {
            SQLiteConnection conn = ConnectorSQLite.CreateConnection();
            SQLiteCommand sqliteCommand;
            sqliteCommand = conn.CreateCommand();
            sqliteCommand.CommandText = "DELETE FROM Producto WHERE IdProducto = " + producto.Id + ";";
            sqliteCommand.ExecuteNonQuery();
            conn.Close();
        }
    }
}
