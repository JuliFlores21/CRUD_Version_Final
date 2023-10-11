using CRUD_Version_Final.Models;

namespace CRUD_Version_Final.Util
{
    public class Utils
    {
        public static List<Producto> ListaProducto = new List<Producto>()
        {
            new Producto()
            {
                IdProducto = 1,
                Nombre= "Producto 1",
                Descripcion="Descripcion",
                Cantidad=1
            },
            new Producto()
            {
                IdProducto = 2,
                Nombre= "Producto 2",
                Descripcion="Descripcion",
                Cantidad=2
            }
        };
    }
}
