using CVs.Data;
using CVs.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;


namespace CVs.Pages.CVss
{
    public class DeleteModel : PageModel
    {
        public IEnumerable<SelectListItem> Natio { get; set; }
         = new List<SelectListItem>()
         {
                new SelectListItem{Value= "Lebanon", Text="Lebanon"},
                new SelectListItem{Value= "Palastine", Text="Palastine"},
                new SelectListItem{Value= "Japanese", Text="Japanese"},
                new SelectListItem{Value= "USA", Text="USA"},
                new SelectListItem{Value= "UK", Text="UK"}
         };

        public List<string> skills { get; set; }
          = new List<string>()
          {
                "PHP",
                "C",
                "C++",
                "Java",
                "C#"
          };
        [BindProperty]
        public Programmer Programmer { get; set; }

        [BindProperty]
        [EmailAddress]
        [Required]
        public string ConfirmEmail { get; set; }

        [BindProperty]
        public int x { get; set; }

        [BindProperty]

        public int y { get; set; }

        [BindProperty]
        public int v { get; set; }
        [BindProperty]
        public int sum { get; set; }

        private readonly AppDataBaseContext DB;


      

        public DeleteModel(AppDataBaseContext db)
        {
            DB = db;
        }
        public void OnGet(int id)
        {
           

            Programmer = DB.Programer.Find(id);

        }

        public async Task<IActionResult> OnPost()
        {
           
           
               var programmerdb = DB.Programer.Find(Programmer.Id);
                if(programmerdb != null)
                {
                    DB.Programer.Remove(programmerdb);
                    await DB.SaveChangesAsync();
                return RedirectToPage("BrowseCv");
                }
                return RedirectToPage("Delete");
            
            return Page();
        }


    }
}
