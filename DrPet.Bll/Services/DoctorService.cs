using DrPet.Data;
using DrPet.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DrPet.Bll.Services
{
    public sealed class DoctorService
    {
        private readonly DrPetDbContext _drPetDbContext;

        public DoctorService(DrPetDbContext drPetDbContext)
        {
            _drPetDbContext = drPetDbContext;
        }

        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _drPetDbContext.Doctors.Where(x => x.Fired == false).ToListAsync();
        }

        public async Task<Doctor?> GetDoctor(int id)
        {
            return await _drPetDbContext.Doctors.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
