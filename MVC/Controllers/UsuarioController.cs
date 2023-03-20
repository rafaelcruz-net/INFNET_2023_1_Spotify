using Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace MVC.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: UsuarioController
        public ActionResult Index()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiI0IiwiZW1haWwiOiJ1c2VyQGFsLmluZm5ldC5lZHUuYnIiLCJuYW1lIjoiVGVzdGUgVXNlciIsIm5iZiI6MTY3OTMwODQyOCwiZXhwIjoxNjc5MzEwMjI4LCJpYXQiOjE2NzkzMDg0MjgsImlzcyI6InNwb3RpZnktdG9rZW4ifQ.fdC_3PPyo6WmSFjfbqMFITg9hzkZkquZ0P0AXs4SWH8");
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
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiI0IiwiZW1haWwiOiJ1c2VyQGFsLmluZm5ldC5lZHUuYnIiLCJuYW1lIjoiVGVzdGUgVXNlciIsIm5iZiI6MTY3OTMwODQyOCwiZXhwIjoxNjc5MzEwMjI4LCJpYXQiOjE2NzkzMDg0MjgsImlzcyI6InNwb3RpZnktdG9rZW4ifQ.fdC_3PPyo6WmSFjfbqMFITg9hzkZkquZ0P0AXs4SWH8");
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


                HttpClient httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiI0IiwiZW1haWwiOiJ1c2VyQGFsLmluZm5ldC5lZHUuYnIiLCJuYW1lIjoiVGVzdGUgVXNlciIsIm5iZiI6MTY3OTMwODQyOCwiZXhwIjoxNjc5MzEwMjI4LCJpYXQiOjE2NzkzMDg0MjgsImlzcyI6InNwb3RpZnktdG9rZW4ifQ.fdC_3PPyo6WmSFjfbqMFITg9hzkZkquZ0P0AXs4SWH8");
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
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiI0IiwiZW1haWwiOiJ1c2VyQGFsLmluZm5ldC5lZHUuYnIiLCJuYW1lIjoiVGVzdGUgVXNlciIsIm5iZiI6MTY3OTMwODQyOCwiZXhwIjoxNjc5MzEwMjI4LCJpYXQiOjE2NzkzMDg0MjgsImlzcyI6InNwb3RpZnktdG9rZW4ifQ.fdC_3PPyo6WmSFjfbqMFITg9hzkZkquZ0P0AXs4SWH8");
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

                HttpClient httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiI0IiwiZW1haWwiOiJ1c2VyQGFsLmluZm5ldC5lZHUuYnIiLCJuYW1lIjoiVGVzdGUgVXNlciIsIm5iZiI6MTY3OTMwODQyOCwiZXhwIjoxNjc5MzEwMjI4LCJpYXQiOjE2NzkzMDg0MjgsImlzcyI6InNwb3RpZnktdG9rZW4ifQ.fdC_3PPyo6WmSFjfbqMFITg9hzkZkquZ0P0AXs4SWH8");
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
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiI0IiwiZW1haWwiOiJ1c2VyQGFsLmluZm5ldC5lZHUuYnIiLCJuYW1lIjoiVGVzdGUgVXNlciIsIm5iZiI6MTY3OTMwODQyOCwiZXhwIjoxNjc5MzEwMjI4LCJpYXQiOjE2NzkzMDg0MjgsImlzcyI6InNwb3RpZnktdG9rZW4ifQ.fdC_3PPyo6WmSFjfbqMFITg9hzkZkquZ0P0AXs4SWH8");

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
                HttpClient httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiI0IiwiZW1haWwiOiJ1c2VyQGFsLmluZm5ldC5lZHUuYnIiLCJuYW1lIjoiVGVzdGUgVXNlciIsIm5iZiI6MTY3OTMwODQyOCwiZXhwIjoxNjc5MzEwMjI4LCJpYXQiOjE2NzkzMDg0MjgsImlzcyI6InNwb3RpZnktdG9rZW4ifQ.fdC_3PPyo6WmSFjfbqMFITg9hzkZkquZ0P0AXs4SWH8");
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
    }
}
