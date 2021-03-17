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
            int i = 0;
            while (reader.Read())
            {            
                System.Windows.Forms.MessageBox.Show(reader.GetInt32(0)+"");               
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
                System.Windows.Forms.MessageBox.Show(Productos[i].ToString());
                i += 1;
            }
            //eliminar(2);            
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
                                            "WHERE IdCategoria = " + producto.Id + ";";
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

        public void eliminar(int Id)
        {
            SQLiteConnection conn = ConnectorSQLite.CreateConnection();
            SQLiteCommand sqliteCommand;
            sqliteCommand = conn.CreateCommand();
            sqliteCommand.CommandText = "DELETE FROM Producto WHERE IdProducto = " + Id + ";";
            sqliteCommand.ExecuteNonQuery();
            conn.Close();
        }
    }
}