using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using teste_cliente.Models;

namespace teste_cliente.Controllers
{
    public class FotoController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<Foto> fotoList = new List<Foto>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5260/api/Foto"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    fotoList = JsonConvert.DeserializeObject<List<Foto>>(apiResponse);
                }
            }

            return View(fotoList);
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Models.Foto foto, IFormFile file)
        {

            if (Request.Form.Files.Count > 0)
            {
                file = Request.Form.Files.FirstOrDefault();
                var dataStream = new MemoryStream();
                file.CopyToAsync(dataStream);
                foto.FotoPerfil = dataStream.ToArray();
            }

            using (var httpClient = new HttpClient())
            {

                StringContent content = new StringContent(JsonConvert.SerializeObject(foto), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("http://localhost:5260/api/Foto/", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    foto = JsonConvert.DeserializeObject<Foto>(apiResponse);
                }
            }
            return RedirectToAction("Index");
        }
    }
}
