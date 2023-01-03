using System.ComponentModel.DataAnnotations;

namespace DrPet.Web.ViewModels.Treatments
{
    public class TreatmentDetailViewModel
    {
        [Required]
        public decimal Price { get; set; }
        [Required]
        public DateTime Appointment { get; set; }
        public string? Comment { get; set; }
        [Required]
        public int DoctorId { get; set; }
        [Required]
        public int AnimalId { get; set; }
        [Required]
        public int OwnerId { get; set; }
    }
}
