using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DrPet.Bll.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using DrPet.Web.ViewModels.Animals;
using AutoMapper;
using DrPet.Web.ViewModels;
using KindViewModel = DrPet.Web.ViewModels.KindViewModel;
using SpeciesViewModel = DrPet.Web.ViewModels.SpeciesViewModel;
using DrPet.Data.Entities;

namespace DrPet.Web.Pages.Assistant.Animals
{
    public class EditModel : PageModel
    {
        private readonly AnimalService _animalService;
        private readonly SpeciesService _speciesService;
        private readonly KindService _kindService;
        private readonly OwnerService _ownerService;
        private readonly IMapper _mapper;

        public EditModel(
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

        [BindProperty]
        public EditAnimalModel Animal { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal =  await _animalService.GetAnimalAsync(id.Value);
            if (animal == null)
            {
                return NotFound();
            }

            Animal = _mapper.Map<EditAnimalModel>(animal);
            await LoadData(animal);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var animal = await _animalService.GetAnimalAsync(Animal.Id);
            if (animal == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _animalService.AddOrUpdateAnimal(_mapper.Map<Animal>(Animal));
                return RedirectToPage("./Index");
            }

            await LoadData(animal);
            return Page();
        }

        private async Task LoadData(Animal animal)
        {
            ViewData["Kinds"] = new SelectList(_mapper.Map<IList<KindViewModel>>(await _kindService.GetAllKindAsync()), "Id", "Name");
            ViewData["Species"] = new SelectList(_mapper.Map<IList<SpeciesViewModel>>(await _speciesService.GetAllSpeciesAsync()), "Id", "Name");
            ViewData["Owners"] = new MultiSelectList(_mapper.Map<IList<OwnerViewModel>>(await _ownerService.GetOwners()), "Id", "Name", animal.OwnerAnimals.Select(x => x.OwnerId));
        }
    }
}
