using Microsoft.AspNetCore.Mvc;
using BibliotecaMVCEF;
using BibliotecaMVCEF.Models;
using BibliotecaWeb.Models;

namespace BibliotecaWeb.Controllers
{
    public class RequisicoesController : Controller
    {
        private RequisicoesService oRequisicoesService = new RequisicoesService();
        private RepositoryVRequisicoesObraService _service = new RepositoryVRequisicoesObraService();

        public IActionResult Index()
        {
           List<VRequisicoesObra> oListVRequisicoesObra =  _service.oRepositoryVRequisicoesObra.SelecionarTodos();
            return View(oListVRequisicoesObra);
        }

        public IActionResult Create()
        {
            RequisicoesViewModel oRequisicoesViewModel = new RequisicoesViewModel();
            List<Obras> oListObras = _service.oRepositoryObras.SelecionarTodos();
            List<Leitor> oListLeitor = _service.oRepositoryLeitor.SelecionarTodos();

            oRequisicoesViewModel.oListLeitor = oListLeitor;
            oRequisicoesViewModel.oListObras = oListObras;
            oRequisicoesViewModel.DataRequisicao = DateTime.Now;
            oRequisicoesViewModel.DataDevolucao = DateTime.Now.AddDays(4);


            

            return View(oRequisicoesViewModel);
        }

        [HttpPost]
        public IActionResult Create(RequisicoesViewModel oRequisicoesViewModel)
        {

            Requisicoes oRequisicoes = new Requisicoes();

            oRequisicoes.DataRequisicao = oRequisicoesViewModel.DataRequisicao;
            oRequisicoes.DataDevolucao = oRequisicoesViewModel.DataDevolucao;
            oRequisicoes.Devolvido = false;
            

            oRequisicoes.IdLeitor = oRequisicoesViewModel.idLeitor;
            oRequisicoes.IdObra = oRequisicoesViewModel.idObras;
            
            

            /*if (!ModelState.IsValid)
            {
                return View();
            }*/

            _service.oRepositoryRequisicoes.Incluir(oRequisicoes);

            
            return RedirectToAction("Index");
        }

            public IActionResult Edit(int id)
        {
            RequisicoesViewModel oRequisicoesViewModel = new RequisicoesViewModel();

            oRequisicoesViewModel.oListLeitor = _service.oRepositoryLeitor.SelecionarTodos();
            oRequisicoesViewModel.oListObras = _service.oRepositoryObras.SelecionarTodos();

            VRequisicoesObra oVRequisicoesObra = _service.oRepositoryVRequisicoesObra.SelecionarPK(id);

            oRequisicoesViewModel.oVRequisicoesObra = oVRequisicoesObra;

            //VRequisicoesObra oVRequisicoesObra = _service.oRepositoryVRequisicoesObra.SelecionarPK(id);
            
            return View(oVRequisicoesObra);


        }


        [HttpPost]
        public IActionResult Edit(VRequisicoesObra Model)
        {

            VRequisicoesObra oVRequisicoesObra = _service.oRepositoryVRequisicoesObra.Alterar(Model);
            int id = oVRequisicoesObra.Id;

            //_service.oRepositoryVRequisicoesObra.Alterar(oRequisicoesViewModel.oVRequisicoesObra);

            return RedirectToAction("Index", new { id });
        }






    }
}
