using DrPet.Data.Entities.Enums;

namespace DrPet.Web.ViewModels.Animals
{
    public class ViewAnimalModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public AnimalStatus Status { get; set; }
        public SpeciesViewModel Species { get; set; }
        public KindViewModel Kind { get; set; }
        public List<TreatmentViewModel> Treatments { get; set; }
    }

    public class TreatmentViewModel
    {
        public int Id { get; set; }
        public DateTime Appointment { get; set; }
        public DoctorViewModel Doctor { get; set; }
        public decimal Price { get; set; }
    }

    public class DoctorViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class KindViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class SpeciesViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class OwnerAnimalView
    {
        public int OwnerId { get; set; }
    }
}
