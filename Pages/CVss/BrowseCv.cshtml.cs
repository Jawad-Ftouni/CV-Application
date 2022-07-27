using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CVs.Model;
using CVs.Data;
namespace CVs.Pages.CVss 
{
    public class BrowseCVModel : PageModel
    {
        public IEnumerable<Programmer> programmers;
        public AppDataBaseContext _db { get; set; }

        public BrowseCVModel(AppDataBaseContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            programmers = _db.Programer;
        }
    }
}
