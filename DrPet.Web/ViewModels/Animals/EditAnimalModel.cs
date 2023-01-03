using DrPet.Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace DrPet.Web.ViewModels.Animals
{
    public class EditAnimalModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(3)]
        public string Name { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public AnimalStatus Status { get; set; }
        [MaxLength(300)]
        public string? Comment { get; set; }
        [Required]
        public int SpeciesId { get; set; }
        [Required]
        public int KindId { get; set; }
        [Required]
        [MinLength(1)]
        public List<int> Owners { get; set; }
    }
}
