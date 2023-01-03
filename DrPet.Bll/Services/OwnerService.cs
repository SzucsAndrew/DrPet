using DrPet.Data;
using DrPet.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DrPet.Bll.Services
{
    public class OwnerService
    {
        private readonly DrPetDbContext _drPetDbContext;
        public OwnerService(DrPetDbContext drPetDbContext)
        {
            _drPetDbContext = drPetDbContext;
        }

        public async Task<IList<Owner>> GetOwners()
        {
            return await _drPetDbContext.Owners.ToListAsync();
        }

        public async Task<IList<Owner>> GetOwners(int animalId)
        {
            return await _drPetDbContext.OwnerAnimals
                .Include(x => x.Owner)
                .Where(x => x.AnimalId == animalId)
                .Select(x => x.Owner)
                .ToListAsync();
        }
    }
}
