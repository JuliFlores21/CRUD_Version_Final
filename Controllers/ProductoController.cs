using CRUD_Version_Final.Models;
using CRUD_Version_Final.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_Version_Final.Controllers
{
    public class ProductoController : Controller
    {
        // GET: ProductoController
        public IActionResult Index()
        {
            return View(Util.Utils.ListaProducto);
        }

        // GET: ProductoController/Details/5
        public IActionResult Details(int IdProducto)
        {
            Producto p = Util.Utils.ListaProducto.Find(x => x.IdProducto == IdProducto);
            if (p != null)
            {
                return View(p);

            }
            return RedirectToAction("Index");
        }

        // GET: ProductoController/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Producto producto)
        {
            int cant= Utils.ListaProducto.Count();
            producto.IdProducto = cant+1;
            Util.Utils.ListaProducto.Add(producto);
            return RedirectToAction("Index");
        }

        // GET: ProductoController/Edit/5
        public IActionResult Edit(int IdProducto)
        {
            Producto p = Util.Utils.ListaProducto.Find(x => x.IdProducto == IdProducto);
            if (p != null)
            {
                return View(p);
                
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Producto producto)
        {
            Producto p = Util.Utils.ListaProducto.Find(x => x.IdProducto == producto.IdProducto);
            if (p != null)
            {
                p.Nombre = producto.Nombre;
                p.Cantidad = producto.Cantidad;
                p.Descripcion = producto.Descripcion;
                return RedirectToAction("Index");
            }
            return View();
        }
        // GET: ProductoController/Delete/5
        public IActionResult Delete(int IdProducto)
        {
            Producto p = Util.Utils.ListaProducto.Find(x => x.IdProducto==IdProducto);
            if (p != null)
            {
                Util.Utils.ListaProducto.Remove(p);
            }
            return RedirectToAction("Index");
        }

       
    }
}
