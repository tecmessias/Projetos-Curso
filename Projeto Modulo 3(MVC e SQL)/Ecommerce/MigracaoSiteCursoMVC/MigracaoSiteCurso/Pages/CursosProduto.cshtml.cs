using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MigracaoSiteCurso.Pages
{
    public class CursosModelP : PageModel
    {
        private readonly ILogger<CursosModel> _logger;

        public CursosModelP(ILogger<CursosModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
        }
    }
}
