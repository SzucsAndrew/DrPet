using DrPet.Data;
using DrPet.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DrPet.Bll.Services
{
    public class SpeciesService
    {
        private readonly DrPetDbContext _drPetDbContext;

        public SpeciesService(DrPetDbContext drPetDbContext)
        {
            _drPetDbContext = drPetDbContext;
        }

        public async Task<IList<Species>> GetAllSpeciesAsync()
        {
            return await _drPetDbContext.Specieses.ToListAsync();
        }
    }
}
