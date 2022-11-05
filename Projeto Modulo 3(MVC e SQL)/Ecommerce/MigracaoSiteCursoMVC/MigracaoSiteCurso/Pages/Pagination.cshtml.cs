using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using JW;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace MigracaoSiteCurso
{
    public class PaginationModel : PageModel
    {
        //public IEnumerable<string> Items { get; set; }
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
            TotalItemsList = new SelectList(new[] { 10, 150, 500, 1000, 5000, 10000, 50000, 100000, 1000000 });
            TotalItems = HttpContext.Session.GetInt32("TotalItems") ?? 150;
            PageSizeList = new SelectList(new[] { 1, 5, 10, 20, 50, 100, 200, 500, 1000 });
            PageSize = HttpContext.Session.GetInt32("PageSize") ?? 10;
            MaxPagesList = new SelectList(new[] { 1, 5, 10, 20, 50, 100, 200, 500 });
            MaxPages = HttpContext.Session.GetInt32("MaxPages") ?? 10;

            // generate list of sample items to be paged
            //var lstItems = Enumerable.Range(1, TotalItems).Select(x => "Item " + x);
            List<Dictionary<string, Object>> lstItems = Business.GetCatalog();
            // get pagination info for the current page
            Pager = new Pager(lstItems.Count(), p, PageSize, MaxPages);

            /*List<Dictionary<string, Object>> GetCatalog()
            {
                string connString = "Initial Catalog=Cursos;Data Source=ALENOTE;Integrated Security=true";
                SqlConnection cn = BD.OpenBD(connString);
                return BD.ToListDictionary(cn, "SELECT * FROM curso");
            }*/

            // assign the current page of items to the Items property
            //Items = lstItems.Skip((Pager.CurrentPage - 1) * Pager.PageSize).Take(Pager.PageSize);

            for (int i = (Pager.CurrentPage - 1) * Pager.PageSize; i < (Pager.CurrentPage - 1) * Pager.PageSize + Pager.PageSize; i++)
            {
                if (i >= lstItems.Count) break;
                Items.Add(lstItems[i]);
            }

        }

        public IActionResult OnPost(int totalItems, int pageSize, int maxPages)
        {
            // update pager parameters for session and redirect back to 'OnGet'
            HttpContext.Session.SetInt32("TotalItems", totalItems);
            HttpContext.Session.SetInt32("PageSize", pageSize);
            HttpContext.Session.SetInt32("MaxPages", maxPages);
            return Redirect("/Pagination");
        }
    }
}
