using DrPet.Data;
using DrPet.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DrPet.Bll.Services
{
    public class KindService
    {
        private readonly DrPetDbContext _drPetDbContext;

        public KindService(DrPetDbContext drPetDbContext)
        {
            _drPetDbContext = drPetDbContext;
        }

        public async Task<IList<Kind>> GetAllKindAsync()
        {
            return await _drPetDbContext.Kinds.ToListAsync();
        }
    }
}
