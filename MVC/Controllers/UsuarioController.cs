using Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace MVC.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: UsuarioController
        public ActionResult Index()
        {
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetAsync("https://localhost:7031/api/usuarios").Result;

            if (response.IsSuccessStatusCode == false)
                throw new Exception("Erro ao tentar chamar a api do usuário");

            var jsonString = response.Content.ReadAsStringAsync().Result;

            var result = JsonSerializer.Deserialize<List<Usuario>>(jsonString);

            return View(result);
        }

        // GET: UsuarioController/Details/5
        public ActionResult Details(int id)
        {
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetAsync($"https://localhost:7031/api/usuarios/{id}").Result;

            if (response.IsSuccessStatusCode == false)
                throw new Exception("Erro ao tentar chamar a api do usuário");

            var jsonString = response.Content.ReadAsStringAsync().Result;

            var result = JsonSerializer.Deserialize<Usuario>(jsonString);

            return View(result);

        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
