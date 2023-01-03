using DrPet.Data;
using DrPet.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DrPet.Bll.Services
{
    public class TreatmentEntryService
    {
        private readonly DrPetDbContext _drPetDbContext;

        public TreatmentEntryService(DrPetDbContext drPetDbContext)
        {
            _drPetDbContext = drPetDbContext;
        }

        public async Task SaveOrUpdateTreatment(TreatmentEntry treatmentEntry)
        {
            EntityEntry<TreatmentEntry> entry;
            if (treatmentEntry.Id != 0)
            {
                entry = _drPetDbContext.Entry<TreatmentEntry>(await _drPetDbContext.TreatmentEntries.FindAsync(treatmentEntry.Id));
            }
            else
            {
                entry = _drPetDbContext.Add(new TreatmentEntry());
            }

            entry.CurrentValues.SetValues(treatmentEntry);

            await _drPetDbContext.SaveChangesAsync();
        }

        public async Task<IList<TreatmentEntry>> GetAllTreatmentEntries(int treatmentId)
        {
            return await _drPetDbContext.TreatmentEntries
                .Where(x => x.TreatmentId == treatmentId)
                .OrderByDescending(x => x.Id)
                .ToListAsync();
        }
    }
}
