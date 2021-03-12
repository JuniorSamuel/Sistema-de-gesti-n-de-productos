
namespace Control
{
    public class Producto
    {

        //Clase Producto.
        //Eddy Manuel Peña Ortega. 2019-8868 

        private string NombreProducto, FechaVencimiento, Descripcion, Codigo, CategoriaID, ProductoEstado;
        private int ProductoID, Stock;

        public Producto()
        {
        }

        public Producto(int ProductoID, string NombreProducto, string Codigo, int Stock, string FechaVencimiento, string Descripcion, string CategoriaID, string ProductoEstado)
        {
            this.ProductoID = ProductoID;
            this.NombreProducto = NombreProducto;
            this.Codigo = Codigo;
            this.Stock = Stock;
            this.FechaVencimiento = FechaVencimiento;
            this.Descripcion = Descripcion;
            this.CategoriaID = CategoriaID;
            this.ProductoEstado = ProductoEstado;
        }

        public int getProductoID()
        {
            return ProductoID;
        }

        public void setProductoID(int ProductoID)
        {
            this.ProductoID = ProductoID;
        }

        public string getNombreProducto()
        {
            return NombreProducto;
        }

        public void setNombreProducto(string NombreProducto)
        {
            this.NombreProducto = NombreProducto;
        }

        public string getCodigo()
        {
            return Codigo;
        }

        public void setCodigo(string Codigo)
        {
            this.Codigo = Codigo;
        }

        public int getStock()
        {
            return Stock;
        }

        public void setStock(int Stock)
        {
            this.Stock = Stock;
        }

        public string getFechaVencimiento()
        {
            return FechaVencimiento;
        }

        public void setFechaVencimiento(string FechaVencimiento)
        {
            this.FechaVencimiento = FechaVencimiento;
        }

        public string getDescripcion()
        {
            return Descripcion;
        }

        public void setDescripcion(string Descripcion)
        {
            this.Descripcion = Descripcion;
        }

        public string getCategoriaID()
        {
            return CategoriaID;
        }

        public void setCategoriaID(string CategoriaID)
        {
            this.CategoriaID = CategoriaID;
        }

        public string getProductoEstado()
        {
            return ProductoEstado;
        }

        public void setProductoEstado(string ProductoEstado)
        {
            this.ProductoEstado = ProductoEstado;
        }

    }
}