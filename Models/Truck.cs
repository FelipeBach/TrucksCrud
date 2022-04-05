using System.ComponentModel.DataAnnotations;

namespace TruckCrud.Models
{
    public class Truck: IValidatableObject
    {
        [Required]        
        public int Id { get; set; }
        [Required]        
        public string Model { get; set; } = string.Empty;
        [Required]
        [Display(Name ="Manufacture Year")]
        public int ManufectureYear { get; set; } = 2022;
        [Required]
        [Display(Name = "Model Year")]
        public int ModelYear { get; set; }

        public IEnumerable<ValidationResult> Validate(
        ValidationContext validationContext)
        {            
            string[] acceptedModels = new string[2] { "FH", "FM" };
            if (!acceptedModels.Contains(Model))
            {
                yield return
                    new ValidationResult("Invalid model value.", new[] { "Model" });
            }
        }        
    }
}
