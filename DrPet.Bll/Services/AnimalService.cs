using DrPet.Data;
using DrPet.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DrPet.Bll.Services
{
    public class AnimalService
    {
        private readonly DrPetDbContext _drPetDbContext;

        public AnimalService(DrPetDbContext drPetDbContext)
        {
            _drPetDbContext = drPetDbContext;
        }

        public async Task<IList<Animal>> GetAnimalsAsync()
        {
            return await _drPetDbContext.Animals
                .Include(a => a.OwnerAnimals)
                .Include(a => a.Kind)
                .Include(a => a.Species)
                .Where(x => !x.IsDeleted)
                .Select(x =>
                    new Animal
                    {
                        Id = x.Id,
                        Name = x.Name,
                        BirthDate = x.BirthDate,
                        Comment = x.Comment,
                        KindId = x.KindId,
                        Kind = x.Kind,
                        SpeciesId = x.SpeciesId,
                        Species = x.Species,
                        Status = x.Status,
                        OwnerAnimals = x.OwnerAnimals
                    })
                .ToListAsync();
        }

        public async Task<IList<Animal>> GetAnimalsWithTreatmentAsync()
        {
            return await _drPetDbContext.Animals
                .Include(a => a.OwnerAnimals)
                .Include(a => a.Kind)
                .Include(a => a.Species)
                .Where(x => !x.IsDeleted)
                .Select(x =>
                    new Animal
                    {
                        Id = x.Id,
                        Name = x.Name,
                        BirthDate = x.BirthDate,
                        Comment = x.Comment,
                        KindId = x.KindId,
                        Kind = x.Kind,
                        SpeciesId = x.SpeciesId,
                        Species = x.Species,
                        Status = x.Status,
                        Treatments = x.Treatments.Select(t => new Treatment
                        {
                            Id = t.Id,
                            Appointment = t.Appointment,
                            Doctor = new Doctor
                            {
                                Id = t.DoctorId,
                                Name = t.Doctor.Name,
                            },
                            Price = t.Price
                        }).ToList(),
                        OwnerAnimals = x.OwnerAnimals
                    })
                .ToListAsync();
        }

        public async Task<Animal?> GetAnimalAsync(int id)
        {
            return await _drPetDbContext.Animals
                .Include(a => a.OwnerAnimals)
                .Include(a => a.Kind)
                .Include(a => a.Species)
                .Where(x => !x.IsDeleted)
                .Select(x =>
                    new Animal
                    {
                        Id = x.Id,
                        Name = x.Name,
                        BirthDate = x.BirthDate,
                        Comment = x.Comment,
                        KindId = x.KindId,
                        Kind = x.Kind,
                        SpeciesId = x.SpeciesId,
                        Species = x.Species,
                        Status = x.Status,
                        OwnerAnimals = x.OwnerAnimals
                    })
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task DeleteAnimal(int id)
        {
            var animal = await _drPetDbContext.Animals.FirstOrDefaultAsync(x => x.Id == id);
            if (animal != null)
            {
                animal.IsDeleted = true;
                await _drPetDbContext.SaveChangesAsync(); 
            }
        }

        public async Task AddOrUpdateAnimal(Animal animal)
        {
            EntityEntry<Animal> entry;
            if (animal.Id != 0)
            {
                entry = _drPetDbContext.Entry<Animal>(await _drPetDbContext.Animals.FindAsync(animal.Id));
            }
            else
            {
                entry = _drPetDbContext.Add(new Animal());
            }

            entry.CurrentValues.SetValues(animal);

            if (animal.OwnerAnimals.Count > 0)
            {
                if (entry.Entity.OwnerAnimals == null)
                {
                    foreach (var ownerAnimal in animal.OwnerAnimals)
                    {
                        _drPetDbContext.OwnerAnimals.Add(new OwnerAnimal
                        {
                            AnimalId = entry.Entity.Id,
                            OwnerId = ownerAnimal.OwnerId
                        });
                    }
                }
                else
                {
                    var newOwnerAnimals = animal.OwnerAnimals.Where(x => !entry.Entity.OwnerAnimals.Any(t => t.OwnerId == x.OwnerId) == true).ToList();
                    var removedOwnerAnimals = entry.Entity.OwnerAnimals.Where(x => !animal.OwnerAnimals.Any(t => t.OwnerId == x.OwnerId)).Select(x => x.OwnerId).ToList();
                    if (newOwnerAnimals.Any())
                    {
                        foreach (var ownerAnimal in newOwnerAnimals)
                        {
                            _drPetDbContext.OwnerAnimals.Add(new OwnerAnimal
                            {
                                AnimalId = entry.Entity.Id,
                                OwnerId = ownerAnimal.OwnerId
                            });
                        }
                    }

                    if (removedOwnerAnimals.Any())
                    {
                        var removedElements = entry.Entity.OwnerAnimals.Where(x => removedOwnerAnimals.Contains(x.OwnerId));
                        foreach (var removeElement in removedElements)
                        {
                            _drPetDbContext.OwnerAnimals.Remove(removeElement);
                        }
                    }
                }
            }

            await _drPetDbContext.SaveChangesAsync();
        }
    }
}
