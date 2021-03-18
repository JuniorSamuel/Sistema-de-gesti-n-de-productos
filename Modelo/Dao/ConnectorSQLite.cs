using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;

namespace Modelo.Dao
{
    public class ConnectorSQLite
    {
        // public SQLiteConnection connection = new SQLiteConnection("Data Source = ../Database/data.db");

        //SQLiteConnection sqliteConn;
        public static SQLiteConnection CreateConnection()
        {
            SQLiteConnection sqliteConn;
            sqliteConn = new SQLiteConnection("Data Source=datos.db; Version = 3; New = True; Compress = True;");
            try
            {
                sqliteConn.Open();
            }
            catch
            {

            }
            return sqliteConn;
        }

        //
        public static void CreateTable()
        {
            SQLiteCommand sqliteCommand;
            string createSQL = @"
            CREATE TABLE 'Categoria' (
                'IdCategoria'   INTEGER,
	            'Nombre'    TEXT,
	            'Estado'    INTEGER,
	             PRIMARY KEY('idCategoria' AUTOINCREMENT)
            );
            CREATE TABLE 'Producto' ( 
                'IdProducto'    INTEGER,	
                'Nombre'    TEXT,	
                'Codigo'    INTEGER,	
                'Stock' INTEGER,	
                'Fecha_vencimiento' TEXT,
	            'Descripcion'   TEXT,
	            'Categoria' INTEGER,
	            'Estado'    INTEGER,
            PRIMARY KEY('idProducto' AUTOINCREMENT),
            FOREIGN KEY('Categoria') REFERENCES Categoria(idCategoria) 
            ); ";
            sqliteCommand = ConnectorSQLite.CreateConnection().CreateCommand();
            sqliteCommand.CommandText = createSQL;
            try
            {
                sqliteCommand.ExecuteNonQuery();

            }
            catch
            {

            }
        }
    }
}
