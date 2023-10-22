using System.ComponentModel.DataAnnotations;
using Character_Management.MVC.Services.Base;


namespace Character_Management.MVC.Models
{
    public class CreateCharacterTypeVM
    {
        [Required]
        [Display(Name = "Type")]
        public string Type { get; set; }

        

        
    }
}
