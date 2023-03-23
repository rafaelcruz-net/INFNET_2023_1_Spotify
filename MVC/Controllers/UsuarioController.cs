using Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace MVC.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {
        // GET: UsuarioController
        public ActionResult Index()
        {
            var httpClient = PrepareRequest();

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
            var httpClient = PrepareRequest();

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
        public ActionResult Create(Usuario model)
        {
            if (ModelState.IsValid == false)
                return View(model);

            try
            {
                var json = JsonSerializer.Serialize<Usuario>(model);
                StringContent content = new StringContent(json, new MediaTypeHeaderValue("application/json"));

                var httpClient = PrepareRequest();
                
                var response = httpClient.PostAsync($"https://localhost:7031/api/usuarios", content).Result;

                if (response.IsSuccessStatusCode == false)
                    throw new Exception("Erro ao tentar chamar a api do usuário");

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
            var httpClient = PrepareRequest();
            
            var response = httpClient.GetAsync($"https://localhost:7031/api/usuarios/{id}").Result;

            if (response.IsSuccessStatusCode == false)
                throw new Exception("Erro ao tentar chamar a api do usuário");

            var jsonString = response.Content.ReadAsStringAsync().Result;

            var result = JsonSerializer.Deserialize<Usuario>(jsonString);

            return View(result);
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Usuario model)
        {
            try
            {
                var json = JsonSerializer.Serialize<Usuario>(model);
                StringContent content = new StringContent(json, new MediaTypeHeaderValue("application/json"));

                var httpClient = PrepareRequest();
              
                var response = httpClient.PutAsync($"https://localhost:7031/api/usuarios/{id}", content).Result;

                if (response.IsSuccessStatusCode == false)
                    throw new Exception("Erro ao tentar chamar a api do usuário");


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
            var httpClient = PrepareRequest();

            var response = httpClient.GetAsync($"https://localhost:7031/api/usuarios/{id}").Result;

            if (response.IsSuccessStatusCode == false)
                throw new Exception("Erro ao tentar chamar a api do usuário");

            var jsonString = response.Content.ReadAsStringAsync().Result;

            var result = JsonSerializer.Deserialize<Usuario>(jsonString);

            return View(result);
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var httpClient = PrepareRequest();

                var response = httpClient.DeleteAsync($"https://localhost:7031/api/usuarios/{id}").Result;

                if (response.IsSuccessStatusCode == false)
                    throw new Exception("Erro ao tentar chamar a api do usuário");

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private string GetToken()
        {
            var user = new
            {
                email = "user_mvc@teste.com",
                password = "123456"
            };

            var body = new StringContent(JsonSerializer.Serialize(user), new MediaTypeHeaderValue("application/json"));

            HttpClient httpClient = new HttpClient();
            var response = httpClient.PostAsync("https://localhost:7031/api/token", body).Result;

            if (response.IsSuccessStatusCode == false)
                throw new Exception("Erro ao tentar chamar a api do usuário");

            var json = response.Content.ReadAsStringAsync().Result;

            var token = JsonSerializer.Deserialize<Token>(json);

            return token.AccessToken;
        }

        private HttpClient PrepareRequest()
        {
            var token = GetToken();

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", $"Bearer {token}");

            return httpClient;
        }
    }

    public class Token
    {
        [JsonPropertyName("accessToken")]
        public string AccessToken { get; set; }
    }
}
