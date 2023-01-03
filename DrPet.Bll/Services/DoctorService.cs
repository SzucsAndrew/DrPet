using DrPet.Data;
using DrPet.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DrPet.Bll.Services
{
    public sealed class DoctorService
    {
        private readonly DrPetDbContext _drPetDbContext;

        public DoctorService(DrPetDbContext drPetDbContext)
        {
            _drPetDbContext = drPetDbContext;
        }

        public async Task DeteleDoctor(int id)
        {
            var doctor = await _drPetDbContext.Doctors.SingleOrDefaultAsync(x => x.Id == id && !x.Fired);
            if (doctor != null)
            {
                doctor.Fired = true;
                await _drPetDbContext.SaveChangesAsync();
            }
        }

        public async Task AddOrUpdateDoctorAsync(Doctor doctor)
        {
            EntityEntry<Doctor> entry;
            if (doctor.Id != 0)
            {
                entry = _drPetDbContext.Entry<Doctor>(await _drPetDbContext.Doctors.FindAsync(doctor.Id));
            }
            else
            {
                entry = _drPetDbContext.Add(new Doctor());
            }
            
            entry.CurrentValues.SetValues(doctor);

            await _drPetDbContext.SaveChangesAsync();
        }

        public async Task<IList<Doctor>> GetDoctors()
        {
            return await _drPetDbContext.Doctors.Where(x => x.Fired == false).ToListAsync();
        }

        public async Task<Doctor?> GetDoctor(int id)
        {
            return await _drPetDbContext.Doctors.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
