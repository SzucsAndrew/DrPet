using DrPet.Data;
using DrPet.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DrPet.Bll.Services
{
    public class TreatmentService
    {
        private readonly DrPetDbContext _drPetDbContext;

        public TreatmentService(DrPetDbContext drPetDbContext)
        {
            _drPetDbContext = drPetDbContext;
        }

        public async Task SaveOrUpdateTreatment(Treatment treatment)
        {
            EntityEntry<Treatment> entry;
            if (treatment.Id != 0)
            {
                entry = _drPetDbContext.Entry<Treatment>(await _drPetDbContext.Treatments.FindAsync(treatment.Id));
            }
            else
            {
                entry = _drPetDbContext.Add(new Treatment());
            }

            entry.CurrentValues.SetValues(treatment);

            await _drPetDbContext.SaveChangesAsync();
        }

        public async Task<Treatment?> GetTreatmentDetails(int id)
        {
            return await _drPetDbContext.Treatments.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}