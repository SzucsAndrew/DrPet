using DrPet.Data;
using DrPet.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DrPet.Bll.Services
{
    public class MedicineRecipeService
    {
        private readonly DrPetDbContext _drPetDbContext;

        public MedicineRecipeService(DrPetDbContext drPetDbContext)
        {
            _drPetDbContext = drPetDbContext;
        }

        public async Task<IList<MedicineRecipe>> GetAllMedicineRecipe()
        {
            return await _drPetDbContext.MedicineRecipes.ToListAsync();
        }
    }
}
