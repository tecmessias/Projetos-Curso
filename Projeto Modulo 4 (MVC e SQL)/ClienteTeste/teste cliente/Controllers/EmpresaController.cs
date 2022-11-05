using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using teste_cliente.Models;

namespace teste_cliente.Controllers
{
    public class EmpresaController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<Empresa> empresaList = new List<Empresa>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5260/api/Empresa"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    empresaList = JsonConvert.DeserializeObject<List<Empresa>>(apiResponse);
                }
            }

            return View(empresaList);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Get(int id)
        {
            Empresa empresa = new Empresa();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5260/api/Empresa/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    empresa = JsonConvert.DeserializeObject<Empresa>(apiResponse);
                }
            }
            return View(empresa);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Models.Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(empresa), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync("http://localhost:5260/api/Empresa/", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        empresa = JsonConvert.DeserializeObject<Empresa>(apiResponse);
                    }
                }
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Empresa empresa = new Empresa();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5260/api/Empresa/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    empresa = JsonConvert.DeserializeObject<Empresa>(apiResponse);

                }
                return View(empresa);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Models.Empresa empresa)
        {
            Empresa e = new Empresa();

            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(empresa), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PutAsync("http://localhost:5260/api/Empresa/" + empresa.IdEmpresa, content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ViewBag.Result = "Success";
                    e = JsonConvert.DeserializeObject<Empresa>(apiResponse);
                }
                return RedirectToAction("Index");

            }

            return View(e);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            Empresa empresa = new Empresa();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5260/api/Empresa/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    empresa = JsonConvert.DeserializeObject<Empresa>(apiResponse);

                }
                return View(empresa);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("http://localhost:5260/api/Empresa/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("Index");
        }


    }
}
