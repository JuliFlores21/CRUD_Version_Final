using CRUD_Version_Final.Models;
using CRUD_Version_Final.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CRUD_Version_Final.Controllers
{
    public class ProductoController : Controller
    {
        Uri baseAddress = new Uri("http://localhost:5249/api");
        private readonly HttpClient _cliente;
        public ProductoController()
        {
            _cliente = new HttpClient();
            _cliente.BaseAddress = baseAddress;
        }
        // GET: ProductoController
        [HttpGet]
        public IActionResult Index()
        {
            List<Producto> ListaProductos= new List<Producto>();
            HttpResponseMessage respone = _cliente.GetAsync(_cliente.BaseAddress+"/Producto").Result;
            if (respone.IsSuccessStatusCode)
            {
                string data =respone.Content.ReadAsStringAsync().Result;
                ListaProductos=JsonConvert.DeserializeObject<List<Producto>>(data);
            }
            return View(ListaProductos);
        }

        // GET: ProductoController/Details/5
        public IActionResult Details(int IdProducto)
        {
            Producto p;
            HttpResponseMessage respone = _cliente.GetAsync(_cliente.BaseAddress + "/Producto/" + IdProducto).Result;
            if (respone.IsSuccessStatusCode)
            {
                string data = respone.Content.ReadAsStringAsync().Result;
                p = JsonConvert.DeserializeObject<Producto>(data);
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
            HttpResponseMessage respone = _cliente.PostAsJsonAsync(_cliente.BaseAddress+"/Producto", producto).Result;
            return RedirectToAction("Index");
        }

        // GET: ProductoController/Edit/5
        public async Task< IActionResult> Edit(int IdProducto)
        {
            Producto nuevo = await _cliente.GetFromJsonAsync<Producto>(_cliente.BaseAddress + "/Producto/" + IdProducto);
            if (nuevo != null)
            {
               
                return View(nuevo);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Producto producto)
        {
            HttpResponseMessage respone = _cliente.PutAsJsonAsync(_cliente.BaseAddress + "/Producto/" + producto.IdProducto,producto).Result;
            return RedirectToAction("Index");
        }
        // GET: ProductoController/Delete/5
        public IActionResult Delete(int IdProducto)
        {
            HttpResponseMessage respone = _cliente.DeleteAsync(_cliente.BaseAddress+"/Producto/"+IdProducto).Result;
            return RedirectToAction("Index");
        }

       
    }
}
