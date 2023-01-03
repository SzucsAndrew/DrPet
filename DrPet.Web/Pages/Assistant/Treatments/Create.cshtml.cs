using AutoMapper;
using DrPet.Bll.Services;
using DrPet.Data.Entities;
using DrPet.Web.Helpers;
using DrPet.Web.ViewModels.Treatments;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DrPet.Web.Pages.Assistant.Treatments
{
    public class CreateModel : PageModel
    {
        private readonly TreatmentService _treatmentService;
        private readonly AnimalService _animalService;
        private readonly DoctorService _doctorService;
        private readonly OwnerService _ownerService;
        private readonly IMapper _mapper;
        public CreateModel(
            TreatmentService treatmentService,
            AnimalService animalService,
            DoctorService doctorService,
            OwnerService ownerService,
            IMapper mapper)
        {
            _treatmentService = treatmentService;
            _animalService = animalService;
            _doctorService = doctorService;
            _ownerService = ownerService;
            _mapper = mapper;
        }

        public async Task<IActionResult> OnGetAsync(int animalId)
        {
            var animalDetails = await _animalService.GetAnimalAsync(animalId);
            if (animalDetails == null)
            {
                return NotFound();
            }

            await LoadFields(animalDetails);
            return Page();
        }

        [BindProperty]
        public TreatmentDetailViewModel Treatment { get; set; }

        public async Task<IActionResult> OnPostAsync(int animalId)
        {
            var animalDetails = await _animalService.GetAnimalAsync(animalId);
            if (animalDetails == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var treatment = _mapper.Map<Treatment>(Treatment);
                await _treatmentService.SaveOrUpdateTreatment(treatment);

                return RedirectToPage(PageHelper.Animals.Index);
            }

            await LoadFields(animalDetails);
            return Page();
        }

        private async Task LoadFields(Animal animalDetails)
        {
            Treatment = new TreatmentDetailViewModel
            {
                AnimalId = animalDetails.Id,
                Appointment = DateTime.UtcNow
            };

            var owners = await _ownerService.GetOwners(animalDetails.Id);
            ViewData["Owners"] = new SelectList(owners, "Id", "Name", owners.FirstOrDefault());
            ViewData["Doctors"] = new SelectList(await _doctorService.GetDoctors(), "Id", "Name");
            ViewData["Animals"] = new SelectList(new[] { animalDetails }, "Id", "Name");
        }
    }
}
