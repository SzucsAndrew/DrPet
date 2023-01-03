using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DrPet.Bll.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using DrPet.Web.ViewModels.Animals;
using AutoMapper;
using DrPet.Data.Entities;

namespace DrPet.Web.Pages.Assistant.Animals
{
    public class CreateModel : PageModel
    {
        private readonly AnimalService _animalService;
        private readonly SpeciesService _speciesService;
        private readonly KindService _kindService;
        private readonly OwnerService _ownerService;
        private readonly IMapper _mapper;

        public CreateModel(
            AnimalService animalService,
            SpeciesService speciesService,
            KindService kindService,
            OwnerService ownerService,
            IMapper mapper)
        {
            _animalService = animalService;
            _speciesService = speciesService;
            _kindService = kindService;
            _ownerService = ownerService;
            _mapper = mapper;
        }

        public async Task<IActionResult> OnGet()
        {
            await LoadData();
            return Page();
        }

        [BindProperty]
        public CreateAnimalModel Animal { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var animal = _mapper.Map<Animal>(Animal);
                await _animalService.AddOrUpdateAnimal(animal);
                return RedirectToPage("./Index");
            }

            await LoadData();
            return Page();
        }

        private async Task LoadData()
        {
            ViewData["Kinds"] = new SelectList(await _kindService.GetAllKindAsync(), "Id", "Name");
            ViewData["Species"] = new SelectList(await _speciesService.GetAllSpeciesAsync(), "Id", "Name");
            ViewData["Owners"] = new SelectList(await _ownerService.GetOwners(), "Id", "Name");
        }

    }
}
