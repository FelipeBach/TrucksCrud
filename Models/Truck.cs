using System.ComponentModel.DataAnnotations;

namespace TruckCrud.Models
{
    public class Truck : IValidatableObject
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Model { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Manufacture Year")]
        public int ManufectureYear { get; set; } = DateTime.Now.Year;
        [Required]
        [Display(Name = "Model Year")]
        public int ModelYear { get; set; }  
        
        [Display(Name = "Vehicle Plate")]
        public string Plate { get; set; }
        
        [Required]
        public int RegisterNumber { get; set; }

        public IEnumerable<ValidationResult> Validate(
        ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            Validator.TryValidateProperty(this.Model,
                new ValidationContext(this, null, null) { MemberName = "Model" },
                results);
            Validator.TryValidateProperty(this.ModelYear,
                new ValidationContext(this, null, null) { MemberName = "ModelYear" },
                results);

            string[] acceptedModels = new string[2] { "FH", "FM" };
            if (!acceptedModels.Contains(Model))
            {
                results.Add(new ValidationResult("Invalid model value.", new[] { "Model" }));


            }

            if (ModelYear != DateTime.Now.Year && ModelYear != DateTime.Now.Year + 1)
            {
                results.Add(new ValidationResult("Model year should be the current year or the subsequent.", new[] { "ModelYear" }));
            }

            return results;
        }
    }
}
