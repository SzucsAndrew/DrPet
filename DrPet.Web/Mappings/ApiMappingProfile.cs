using AutoMapper;
using DrPet.Data.Entities;
using DrPet.Web.ViewModels;
using DrPet.Web.ViewModels.Animals;
using DrPet.Web.ViewModels.Doctors;
using DrPet.Web.ViewModels.Medicines;
using DrPet.Web.ViewModels.OrderingHours;
using DrPet.Web.ViewModels.Treatments;

namespace DrPet.Web.Mappings
{
    public class ApiMappingProfile : Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<TreatmentDetailViewModel, Treatment>();
            CreateMap<TreatmentEntryDetailViewModel, TreatmentEntry>();
            CreateMap<Treatment, ViewModels.Treatments.TreatmentViewModel>();

            CreateMap<CreateAnimalModel, Animal>()
                .ForMember(ca => ca.OwnerAnimals, d => d.MapFrom(t => t.Owners.
                Select(x => new OwnerAnimal { OwnerId = x })));

            CreateMap<EditAnimalModel, Animal>()
                .ForMember(ca => ca.OwnerAnimals, d => d.MapFrom(t => t.Owners.
                Select(x => new OwnerAnimal { OwnerId = x })));
            CreateMap<Animal, EditAnimalModel>()
                .ForMember(ca => ca.Owners, d => d.MapFrom(t => t.OwnerAnimals.
                Select(x => x.OwnerId)));

            CreateMap<Animal, DetailAnimalModel>()
                .ForMember(a => a.Kind, d => d.MapFrom(t => t.Kind.Name))
                .ForMember(a => a.Species, d => d.MapFrom(t => t.Species.Name));
            CreateMap<Animal, DeleteAnimalModel>();
            CreateMap<Animal, ViewAnimalModel>();
            CreateMap<Treatment, ViewModels.Animals.TreatmentViewModel>();
            CreateMap<Doctor, ViewModels.Animals.DoctorViewModel>();
            CreateMap<OwnerAnimal, OwnerAnimalView>();
            CreateMap<Species, ViewModels.Animals.SpeciesViewModel>();
            CreateMap<Kind, ViewModels.Animals.KindViewModel>();

            CreateMap<Doctor, ViewModels.Doctors.DoctorViewModel>();
            CreateMap<Doctor, DeleteDoctorModel>();
            CreateMap<CreateDoctorModel, Doctor>();
            CreateMap<EditDoctorModel, Doctor>();
            CreateMap<Doctor, EditDoctorModel>();
            CreateMap<Doctor, DetailDoctorModel>();

            CreateMap<EditOrderingHour, OrderingHour>();
            CreateMap<OrderingHour, EditOrderingHour>();

            CreateMap<MedicineRecipeViewModel, MedicineRecipe>();
            CreateMap<MedicineRecipe, MedicineRecipeViewModel>();
            CreateMap<Species, ViewModels.SpeciesViewModel>();
            CreateMap<Kind, ViewModels.KindViewModel>();

            CreateMap<Owner, OwnerViewModel>();
        }
    }
}
