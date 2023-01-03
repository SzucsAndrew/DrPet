using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DrPet.Bll.Services;
using DrPet.Web.ViewModels.Animals;
using AutoMapper;

namespace DrPet.Web.Pages.Assistant.Animals
{
    public class DetailsModel : PageModel
    {
        private readonly AnimalService _animalService;
        private readonly IMapper _mapper;

        public DetailsModel(AnimalService animalService, IMapper mapper)
        {
            _animalService = animalService;
            _mapper = mapper;
        }

        public DetailAnimalModel Animal { get; set; }

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

            Animal = _mapper.Map<DetailAnimalModel>(animal);
            return Page();
        }
    }
}
