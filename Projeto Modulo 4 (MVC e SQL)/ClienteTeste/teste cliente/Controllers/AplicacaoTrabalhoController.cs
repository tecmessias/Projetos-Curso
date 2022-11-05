using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using teste_cliente.Models;

namespace teste_cliente.Controllers
{
    public class AplicacaoTrabalhoController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<AplicacaoTrabalho> aplicacaoList = new List<AplicacaoTrabalho>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5260/api/aplicacao"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    aplicacaoList = JsonConvert.DeserializeObject<List<AplicacaoTrabalho>>(apiResponse);
                }
            }

            return View(aplicacaoList);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Get(int id)
        {
            AplicacaoTrabalho aplicacao = new AplicacaoTrabalho();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5260/api/aplicacao/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    aplicacao = JsonConvert.DeserializeObject<AplicacaoTrabalho>(apiResponse);
                }
            }
            return View(aplicacao);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Models.AplicacaoTrabalho aplicacao)
        {
            //if (ModelState.IsValid)
            //{
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(aplicacao), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync("http://localhost:5260/api/aplicacao/", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        aplicacao = JsonConvert.DeserializeObject<AplicacaoTrabalho>(apiResponse);
                    }
                }
            //    return RedirectToAction("Index");
            //}
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            AplicacaoTrabalho aplicacao = new AplicacaoTrabalho();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5260/api/aplicacao/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    aplicacao = JsonConvert.DeserializeObject<AplicacaoTrabalho>(apiResponse);

                }
                return View(aplicacao);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Models.AplicacaoTrabalho aplicacao)
        {
            AplicacaoTrabalho e = new AplicacaoTrabalho();

            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(aplicacao), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PutAsync("http://localhost:5260/api/aplicacao/" + aplicacao.IdAplicacao, content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ViewBag.Result = "Success";
                    e = JsonConvert.DeserializeObject<AplicacaoTrabalho>(apiResponse);
                }
                return RedirectToAction("Index");

            }

            return View(e);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            AplicacaoTrabalho aplicacao = new AplicacaoTrabalho();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5260/api/aplicacao/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    aplicacao = JsonConvert.DeserializeObject<AplicacaoTrabalho>(apiResponse);

                }
                return View(aplicacao);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("http://localhost:5260/api/aplicacao/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("Index");
        }
    }
}
