using AutoMapper;
using DrPet.Bll.Services;
using DrPet.Data.Entities;
using DrPet.Web.Helpers;
using DrPet.Web.ViewModels;
using DrPet.Web.ViewModels.Treatments;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DrPet.Web.Pages.Assistant.TreatmentEntries
{
    public class CreateModel : PageModel
    {
        private readonly TreatmentService _treatmentService;
        private readonly TreatmentEntryService _treatmentEntryService;
        private readonly MedicineRecipeService _medicineRecipeService;
        private readonly IMapper _mapper;

        public CreateModel(
            TreatmentEntryService treatmentEntryService,
            TreatmentService treatmentService,
            MedicineRecipeService medicineRecipeService,
            IMapper mapper)
        {
            _treatmentEntryService = treatmentEntryService;
            _treatmentService = treatmentService;
            _medicineRecipeService = medicineRecipeService;
            _mapper = mapper;
        }

        public async Task<IActionResult> OnGetAsync(int treatmentId)
        {
            var treatment = await _treatmentService.GetTreatmentDetails(treatmentId);
            if (treatment == null)
            {
                return NotFound();
            }

            await LoadFields(treatment);
            return Page();
        }

        [BindProperty]
        public TreatmentEntryDetailViewModel TreatmentEntryDetailViewModel { get; set; }

        public async Task<IActionResult> OnPostAsync(int treatmentId)
        {
            var treatment = await _treatmentService.GetTreatmentDetails(treatmentId);
            if (treatment == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var treatmentEntry = _mapper.Map<TreatmentEntry>(TreatmentEntryDetailViewModel);
                await _treatmentEntryService.SaveOrUpdateTreatment(treatmentEntry);
                return RedirectToPage(PageHelper.Animals.Index);
            }

            await LoadFields(treatment);
            return Page();
        }

        private async Task LoadFields(Treatment treatment)
        {
            var treatmentViewModel = _mapper.Map<TreatmentViewModel>(treatment);
            ViewData["Treatments"] = new SelectList(new[] { treatmentViewModel }, "Id", "Id");
            ViewData["MedicineRecipes"] = new SelectList(await _medicineRecipeService.GetAllMedicineRecipe(), "Id", "Id");
            ViewData["PrevTreatmentEntrys"] = await GetAllTreatmentEntryDetails(treatment.Id);
        }

        private async Task<List<SelectListItem>> GetAllTreatmentEntryDetails(int treatmentDetailId)
        {
            var treatmentEntryDetails = await _treatmentEntryService.GetAllTreatmentEntries(treatmentDetailId);
            var list = treatmentEntryDetails.Select(x => new SelectListItem
            {
                Text = x.Id.ToString(),
                Value = x.Id.ToString()
            }).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "",
                Value = null,
                Selected = true
            });

            return list;
        }
    }
}
