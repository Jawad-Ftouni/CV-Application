using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CVs.Model;
using CVs.Data;
namespace CVs.Pages.CVss
{
    public class ViewModel : PageModel
    {
        [BindProperty]
        public Programmer programmer { get; set; }
        private readonly AppDataBaseContext _db;

        public ViewModel(AppDataBaseContext db)
        {
            _db = db;
        }

        public void OnGet(int id)
        {
            programmer = _db.Programer.Find(id);
        }
    }
}
