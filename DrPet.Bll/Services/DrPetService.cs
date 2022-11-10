using DrPet.Data;
using DrPet.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DrPet.Bll.Services
{
    public sealed class DrPetService
    {
        private readonly DrPetDbContext _drPetDbContext;
        public DrPetService(DrPetDbContext drPetDbContext)
        {
            _drPetDbContext = drPetDbContext;
        }

        public async Task<Animal?> AddAnimal(Animal animal)
        {
            if (animal.Id == 0)
            {
                await _drPetDbContext.Animals.AddAsync(animal);
                await _drPetDbContext.SaveChangesAsync();
                return animal;
            }

            return null;
        }

        public async Task<Animal?> UpdateAnimal(Animal animal)
        {
            var animalExist = await _drPetDbContext.Animals.AnyAsync(d => d.Id == animal.Id);
            if (animalExist)
            {
                _drPetDbContext.Animals.Update(animal);
                await _drPetDbContext.SaveChangesAsync();
                return animal;
            }

            return null;
        }

        public async Task<Owner?> AddOwner(Owner owner)
        {
            if (owner.Id == 0)
            {
                await _drPetDbContext.Owners.AddAsync(owner);
                await _drPetDbContext.SaveChangesAsync();
                return owner;
            }

            return null;
        }

        public async Task<Owner?> UpdateOwner(Owner owner)
        {
            var ownerExist = await _drPetDbContext.Owners.AnyAsync(d => d.Id == owner.Id);
            if (ownerExist)
            {
                _drPetDbContext.Owners.Update(owner);
                await _drPetDbContext.SaveChangesAsync();
                return owner;
            }

            return null;
        }

        public async Task<OrderingHour?> AddOrderingHours(OrderingHour orderingHour)
        {
            if (orderingHour.Id == 0)
            {
                await _drPetDbContext.OrderingHours.AddAsync(orderingHour);
                await _drPetDbContext.SaveChangesAsync();
                return orderingHour;
            }

            return null;
        }

        public async Task<OrderingHour?> UpdateOrderingHours(OrderingHour orderingHour)
        {
            var ownerExist = await _drPetDbContext.OrderingHours.AnyAsync(d => d.Id == orderingHour.Id);
            if (ownerExist)
            {
                _drPetDbContext.OrderingHours.Update(orderingHour);
                await _drPetDbContext.SaveChangesAsync();
                return orderingHour;
            }

            return null;
        }

        public async Task<IEnumerable<OrderingHour>> GetOrderingHours(DateTime startDate, DateTime endDate)
        {
            return await _drPetDbContext.OrderingHours
                .Where(x => x.Date >= startDate.Date && x.Date <= endDate.Date)
                .ToListAsync();
        }

        public async Task<Treatment?> AddTreatment(Treatment treatment)
        {
            if (treatment.Id == 0)
            {
                await _drPetDbContext.Treatments.AddAsync(treatment);
                await _drPetDbContext.SaveChangesAsync();
                return treatment;
            }

            return null;
        }

        public async Task<Treatment?> UpdateTreatment(Treatment treatment)
        {
            var ownerExist = await _drPetDbContext.Treatments.AnyAsync(d => d.Id == treatment.Id);
            if (ownerExist)
            {
                _drPetDbContext.Treatments.Update(treatment);
                await _drPetDbContext.SaveChangesAsync();
                return treatment;
            }

            return null;
        }

        public async Task<TreatmentEntry?> AddComment(TreatmentEntry treatmentEntry)
        {
            if (treatmentEntry.Id == 0)
            {
                await _drPetDbContext.TreatmentEntries.AddAsync(treatmentEntry);
                await _drPetDbContext.SaveChangesAsync();
                return treatmentEntry;
            }

            return null;
        }

        public async Task<TreatmentEntry?> UpdateComment(TreatmentEntry treatmentEntry)
        {
            var ownerExist = await _drPetDbContext.TreatmentEntries.AnyAsync(d => d.Id == treatmentEntry.Id);
            if (ownerExist)
            {
                _drPetDbContext.TreatmentEntries.Update(treatmentEntry);
                await _drPetDbContext.SaveChangesAsync();
                return treatmentEntry;
            }

            return null;
        }
    }
}
