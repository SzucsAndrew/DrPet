using DrPet.Data.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace DrPet.Web.ViewModels.Animals
{
    public class CreateAnimalModel
    {
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
        public IList<int> Owners { get; set; }
    }
}
