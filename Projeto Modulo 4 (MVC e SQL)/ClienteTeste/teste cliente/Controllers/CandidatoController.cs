using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using teste_cliente.Models;

namespace teste_cliente.Controllers
{
    public class CandidatoController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<Candidato> candidatoList = new List<Candidato>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5260/api/Candidato"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    candidatoList = JsonConvert.DeserializeObject<List<Candidato>>(apiResponse);
                }
            }

            return View(candidatoList);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Get(int id)
        {
            Candidato candidato = new Candidato();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5260/api/Candidato/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    candidato = JsonConvert.DeserializeObject<Candidato>(apiResponse);
                }
            }
            return View(candidato);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Models.Candidato candidato)
        {
            if (ModelState.IsValid)
            {
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(candidato), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync("http://localhost:5260/api/Candidato/", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        candidato = JsonConvert.DeserializeObject<Candidato>(apiResponse);
                    }
                }
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Candidato candidato = new Candidato();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5260/api/Candidato/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    candidato = JsonConvert.DeserializeObject<Candidato>(apiResponse);

                }
                return View(candidato);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Models.Candidato candidato)
        {
            Candidato e = new Candidato();

            using (var httpClient = new HttpClient())
            {


                StringContent content = new StringContent(JsonConvert.SerializeObject(candidato), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PutAsync("http://localhost:5260/api/Candidato/" + candidato.IdCandidato, content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ViewBag.Result = "Success";
                    e = JsonConvert.DeserializeObject<Candidato>(apiResponse);
                }
                return RedirectToAction("Index");

            }

            return View(e);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            Candidato candidato = new Candidato();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5260/api/Candidato/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    candidato = JsonConvert.DeserializeObject<Candidato>(apiResponse);

                }
                return View(candidato);
            }
        }




        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("http://localhost:5260/api/Candidato/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("Index");
        }





    }
}
