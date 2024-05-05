using Newtonsoft.Json;
using Practica06_IS_RAZOR_CLIENTE.Models;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
// NOMBRE APELLIDOS: CRISTHIAN PROAÑO
// PARALELO: 
// SI – INTEGRACIÓN DE SISTEMAS 
// FECHA: 04/05/2024
// PRÁCTICA No. # 6

namespace Practica06_IS_RAZOR_CLIENTE.Controllers
{
    public class ProductosController : Controller
    {

        // GET: Productos

        public async Task<ActionResult> Index()
        {
            var productos = await Deserializar();
            return View(productos);
        }

        private async Task<List<Productos>> Deserializar()
        {
            string url = "http://localhost:50231/api/Productos";
            using (HttpClient client = new HttpClient())
            {
                string getDatos = await client.GetStringAsync(url);
                List<Productos> listaProductos = JsonConvert.DeserializeObject<List<Productos>>(getDatos);
                return listaProductos;
            }
        }

      

        // GET: Productos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Productos/Create
        public ActionResult Create()
        {
            return View();
        }

        private void Serializar(Productos producto)
        {
            string url = "http://localhost:50231/api/Productos";
            string verb = "POST";
            WebClient webClient = new WebClient();
            string JsonDatos = JsonConvert.SerializeObject(producto);

            UTF8Encoding encoding = new UTF8Encoding();
            Byte[] bytes = encoding.GetBytes(JsonDatos);
            webClient.Headers.Add("content-type", "application/json");
            webClient.UploadData(url,verb,bytes);
        
        }
        // POST: Productos/Create
        [HttpPost]
        public ActionResult Create(Productos producto)
        {
            if (producto == null || producto.Name == null || producto.Price == 0)
            {
                ViewBag.Error = "El producto no puede ser nulo y debe tener todos los campos requeridos.";
                return View(producto);
            }

            // Código para enviar el producto al servidor
            Serializar(producto);
            return RedirectToAction("Index");
        }

        // GET: Productos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Productos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Productos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Productos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
