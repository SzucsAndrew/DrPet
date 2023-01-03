using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DrPet.Bll.Services;
using DrPet.Web.ViewModels.Animals;
using AutoMapper;

namespace DrPet.Web.Pages.Assistant.Animals
{
    public class DeleteModel : PageModel
    {
        private readonly AnimalService _animalService;
        private readonly IMapper _mapper;

        public DeleteModel(AnimalService animalService, IMapper mapper)
        {
            _animalService = animalService;
            _mapper = mapper;
        }

        [BindProperty]
        public DeleteAnimalModel Animal { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = await _animalService.GetAnimalAsync(id.Value);

            if (animal == null)
            {
                return NotFound();
            }
            else 
            {
                Animal = _mapper.Map<DeleteAnimalModel>(animal);
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _animalService.DeleteAnimal(id.Value);

            return RedirectToPage("./Index");
        }
    }
}
