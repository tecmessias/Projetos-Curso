using BibliotecaMVCEF;
using BibliotecaMVCEF.Models;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaWeb.Controllers
{
    public class LeitorController : Controller
    {
        private LeitorService oLeitorService = new LeitorService();
        public IActionResult Index()
        {
            List<Leitor> oListLeitor = oLeitorService.oRepositoryLeitor.SelecionarTodos();
            return View(oListLeitor);
        }

        
        public IActionResult Create()
        {
           
            return View();
        }

        [HttpPost]
        public IActionResult Create(Leitor model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            oLeitorService.oRepositoryLeitor.Incluir(model);

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            Leitor oLeitor = oLeitorService.oRepositoryLeitor.SelecionarPK(id);


            return View(oLeitor);
        }

        public IActionResult Edit(int id)
        {
            Leitor oLeitor = oLeitorService.oRepositoryLeitor.SelecionarPK(id);


            return View(oLeitor);
        }

        [HttpPost]
        public IActionResult Edit(Leitor model)
        {
            Leitor oLeitor = oLeitorService.oRepositoryLeitor.Alterar(model);

            int id = oLeitor.Id;

            return RedirectToAction("Details", new {id});
        }

        public IActionResult Delete(int id)
        {
            oLeitorService.oRepositoryLeitor.Excluir(id);
            return RedirectToAction("index");
        }
    }
}
