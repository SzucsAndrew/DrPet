using DrPet.Data.Entities.Enums;

namespace DrPet.Web.ViewModels.Animals
{
    public class DetailAnimalModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public AnimalStatus Status { get; set; }
        public string? Comment { get; set; }
        public string Species { get; set; }
        public string Kind { get; set; }
    }
}
