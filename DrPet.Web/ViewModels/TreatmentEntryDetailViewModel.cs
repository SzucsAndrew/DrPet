using DrPet.Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace DrPet.Web.ViewModels
{
    public class TreatmentEntryDetailViewModel
    {
        [Required]
        public int TreatmentId { get; set; }
        [Required]
        public TreatmentEntryType TreatmentEntryType { get; set; }
        public int? MedicineRecipeId { get; set; }
        public TimeSpan? Duration { get; set; }
        [MaxLength(300)]
        public string? Comment { get; set; }
        public int? PrevTreatmentEntryId { get; set; }
    }
}
