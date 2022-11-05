using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using teste_cliente.Models;

namespace teste_cliente.Controllers
{
    public class OfertaEmpregoController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<OfertaEmprego> ofertaList = new List<OfertaEmprego>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5260/api/Oferta"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ofertaList = JsonConvert.DeserializeObject<List<OfertaEmprego>>(apiResponse);
                }
            }

            return View(ofertaList);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Get(int id)
        {
            OfertaEmprego oferta = new OfertaEmprego();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5260/api/Oferta/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    oferta = JsonConvert.DeserializeObject<OfertaEmprego>(apiResponse);
                }
            }
            return View(oferta);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Models.OfertaEmprego oferta)
        {
            //if (ModelState.IsValid)
            //{
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(oferta), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync("http://localhost:5260/api/Oferta/", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        oferta = JsonConvert.DeserializeObject<OfertaEmprego>(apiResponse);
                    }
                }
            //    //return RedirectToAction("Index");
            //}
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            OfertaEmprego oferta = new OfertaEmprego();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5260/api/Oferta/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    oferta = JsonConvert.DeserializeObject<OfertaEmprego>(apiResponse);

                }
                return View(oferta);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Models.OfertaEmprego oferta)
        {
            Candidato e = new Candidato();

            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(oferta), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PutAsync("http://localhost:5260/api/Oferta/" + oferta.IdOferta, content))
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
            OfertaEmprego oferta = new OfertaEmprego();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5260/api/Oferta/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    oferta = JsonConvert.DeserializeObject<OfertaEmprego>(apiResponse);

                }
                return View(oferta);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("http://localhost:5260/api/Oferta/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("Index");
        }
    }
}
