using BibliotecaMVCEF;
using BibliotecaMVCEF.Models;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaWeb.Controllers
{
    public class ObraController : Controller
    {
        private ObrasService oObrasService = new ObrasService();
        public IActionResult Index()
        {
            List<Obras> oListObras = oObrasService.oRepositoryObras.SelecionarTodos();
            return View(oListObras);
        }


        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Obras model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            oObrasService.oRepositoryObras.Incluir(model);

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            Obras oObras = oObrasService.oRepositoryObras.SelecionarPK(id);


            return View(oObras);
        }

        public IActionResult Edit(int id)
        {
            Obras oObras = oObrasService.oRepositoryObras.SelecionarPK(id);


            return View(oObras);
        }

        [HttpPost]
        public IActionResult Edit(Obras model)
        {
            Obras oObras = oObrasService.oRepositoryObras.Alterar(model);

            int id = oObras.Id;

            return RedirectToAction("Details", new { id });
        }

        public IActionResult Delete(int id)
        {
            oObrasService.oRepositoryObras.Excluir(id);
            return RedirectToAction("index");
        }
    }
}
