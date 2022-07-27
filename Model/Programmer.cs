using System.ComponentModel.DataAnnotations;
namespace CVs.Model
{
    public class Programmer
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        [Display(Name = "FirstName")]
        [Required]
        public string FirstName { get; set; }

        [StringLength(100)]
        [Display(Name = "LastName")]
        [Required]
        public string LastName { get; set; }
        [Display(Name = "Date Of Birth")]
        [Required]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Nationality")]
        [Required]
        public string Nationality { get; set; }

        [Display(Name = "Gender")]
        [Required]
        public string Gender { get; set; }

        [Display(Name = "Programming Skills")]
        public string Programing_Skills { get; set; }

        [EmailAddress]
        [Display(Name = "Email")]
        [Required]

        public string Email { get; set; }

        [Range(0, 100)]
      
        public int Grade { get; set; }

        
        public string image { get; set; }

               
     }
}