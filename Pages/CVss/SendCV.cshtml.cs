using CVs.Data;
using CVs.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using CVs.imageservice;
using CVs.services;


namespace CVs.Pages.CVss
{
    public class SendCVModel : PageModel
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

        
        private readonly AppDataBaseContext DB;
        private readonly IImageUploadService ImS;
        private readonly GradeService gradeservice;
        [BindProperty]
        public List<string> CheckedSkills { get; set; }

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

        public SendCVModel(AppDataBaseContext db, GradeService gd, IImageUploadService ims)
        {
            DB = db;
            gradeservice = gd;
            ImS = ims;
        }
        public void OnGet()
        {
            Random rnd = new Random();

            x = rnd.Next(1, 21);
            y = rnd.Next(20, 51);

            v = x + y;
          
        }

        public async Task<IActionResult> OnPost(IFormFile Im)
        {
              if(sum != v)
              {
                  ModelState.AddModelError("Sum Validation", "The Summation is incorrect");
              }

              if(Programmer.Email != ConfirmEmail)
              {
                  ModelState.AddModelError("Email Validation", "The Email is incorrect");
              }


            

            if (ModelState.IsValid) {
                if (Im != null)
                {
                    Programmer.image = await ImS.UploadImageAsync(Im);
                }
                Programmer.Grade = gradeservice.CalculateGrade(Programmer, CheckedSkills);
                Programmer.Programing_Skills = gradeservice.GenerateSkills(CheckedSkills);
                await DB.Programer.AddAsync(Programmer);
                await DB.SaveChangesAsync();
            return RedirectToPage("BrowseCv");
            }
            else
            {
                return Page();
            }
        }
        

    }
}
