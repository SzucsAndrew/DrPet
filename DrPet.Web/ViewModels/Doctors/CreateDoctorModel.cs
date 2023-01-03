using System.ComponentModel.DataAnnotations;

namespace DrPet.Web.ViewModels.Doctors
{
    public class CreateDoctorModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [MaxLength(100)]
        public string? Introduce { get; set; }
        [MaxLength(250)]
        public string? ImageName { get; set; }
    }
}
