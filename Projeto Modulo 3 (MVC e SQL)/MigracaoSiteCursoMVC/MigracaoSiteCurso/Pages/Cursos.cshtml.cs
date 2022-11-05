using JW;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MigracaoSiteCurso.Pages
{
    public class CursosModel : PageModel
    {
        //private readonly ILogger<CursosModel> _logger;

        /*public CursosModel(ILogger<CursosModel> logger)
        {
            _logger = logger;
        }*/


        public List<Dictionary<string, Object>> Items = new List<Dictionary<string, Object>>();
        public Pager Pager { get; set; }
        public SelectList TotalItemsList { get; set; }
        public int TotalItems { get; set; }
        public SelectList PageSizeList { get; set; }
        public int PageSize { get; set; }
        public SelectList MaxPagesList { get; set; }
        public int MaxPages { get; set; }


        public void OnGet(int p = 1)
        {
               
                // properties for pager parameter controls
                TotalItemsList = new SelectList(new[] { 10, 150, 500, 100});
                TotalItems = HttpContext.Session.GetInt32("TotalItems") ?? 150;
                PageSizeList = new SelectList(new[] { 1, 5, 10, 20, 50, 100});
                PageSize = HttpContext.Session.GetInt32("PageSize") ?? 10;
                MaxPagesList = new SelectList(new[] { 1, 5, 10, 20, 50, 100});
                MaxPages = HttpContext.Session.GetInt32("MaxPages") ?? 10;

                // generate list of sample items to be paged

                List<Dictionary<string, Object>> lstItems = Business.GetCatalog();

                // get pagination info for the current page

                Pager = new Pager(lstItems.Count(), p, PageSize, MaxPages);
                                
                for (int i = (Pager.CurrentPage - 1) * Pager.PageSize; i < (Pager.CurrentPage - 1) * Pager.PageSize + Pager.PageSize; i++)
                {
                    if (i >= lstItems.Count) break;
                    Items.Add(lstItems[i]);
                }

            

             IActionResult OnPost(int totalItems, int pageSize, int maxPages)
            {
                // update pager parameters for session and redirect back to 'OnGet'
                HttpContext.Session.SetInt32("TotalItems", totalItems);
                HttpContext.Session.SetInt32("PageSize", pageSize);
                HttpContext.Session.SetInt32("MaxPages", maxPages);
                return Redirect("/Cursos");
            }
        }
    }
}
