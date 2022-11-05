using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using teste_cliente.Models;

namespace teste_cliente.Controllers
{
    public class CvController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<CV> cvList = new List<CV>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5260/api/cv"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    cvList = JsonConvert.DeserializeObject<List<CV>>(apiResponse);
                }
            }

            return View(cvList);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return View();
        }

        //Get com id CV
        [HttpPost]
        public async Task<IActionResult> Get(int id)
        {
            CV cv = new CV();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5260/api/Cv/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    cv = JsonConvert.DeserializeObject<CV>(apiResponse);
                }
            }
            return View(cv);
        }
        //get idCandiato
        //[HttpGet]
        //public IActionResult GetCandidato()
        //{
        //    return View();
        //}
        [HttpGet]
        public async Task<IActionResult> GetCandidato(int idCandidato)
        {
            CV cv = new CV();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5260/api/cv/IdCandidato" + idCandidato))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    cv = JsonConvert.DeserializeObject<CV>(apiResponse);
                }
            }
            return View(cv);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(CV cv)
        {
            //if (ModelState.IsValid)
            //{
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(cv), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PostAsync("http://localhost:5260/api/cv/", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        cv = JsonConvert.DeserializeObject<CV>(apiResponse);
                    }
                }
            //    return RedirectToAction("Index");
            //}
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            CV cv = new CV();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5260/api/cv/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    cv = JsonConvert.DeserializeObject<CV>(apiResponse);

                }
                return View(cv);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Models.CV cv)
        {
            CV e = new CV();

            using (var httpClient = new HttpClient())
            {


                StringContent content = new StringContent(JsonConvert.SerializeObject(cv), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PutAsync("http://localhost:5260/api/Candidato/" + cv.IdCV, content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ViewBag.Result = "Success";
                    e = JsonConvert.DeserializeObject<CV>(apiResponse);
                }
                return RedirectToAction("Index");

            }

            return View(e);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            CV cv = new CV();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5260/api/CV/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    cv = JsonConvert.DeserializeObject<CV>(apiResponse);

                }
                return View(cv);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("http://localhost:5260/api/Cv/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("Index");
        }
    }
}
