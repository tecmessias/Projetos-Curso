using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MigracaoSiteCurso.Pages
{
    public class paginationModel : PageModel
    {
        private readonly ILogger<CursosModel> _logger;

        public paginationModel(ILogger<CursosModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
        }
    }
}