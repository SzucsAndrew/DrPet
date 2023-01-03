using Microsoft.AspNetCore.Mvc.RazorPages;
using DrPet.Bll.Services;
using AutoMapper;
using DrPet.Web.ViewModels.Animals;

namespace DrPet.Web.Pages.Assistant.Animals
{
    public class IndexModel : PageModel
    {
        private readonly AnimalService _animalService;
        private readonly IMapper _mapper;

        public IndexModel(AnimalService animalService, IMapper mapper)
        {
            _animalService = animalService;
            _mapper = mapper;
        }

        public IList<ViewAnimalModel> Animal { get; set; }

        public async Task OnGetAsync()
        {
            Animal = _mapper.Map<IList<ViewAnimalModel>>(await _animalService.GetAnimalsWithTreatmentAsync());
        }
    }
}
