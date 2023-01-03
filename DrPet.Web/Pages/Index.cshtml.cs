using AutoMapper;
using DrPet.Bll.Services;
using DrPet.Data.Entities;
using DrPet.Web.ViewModels.Doctors;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DrPet.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly DoctorService _doctorService;
        private readonly IMapper _mapper;
        public IEnumerable<DoctorViewModel> Doctors { get; private set; }

        public IndexModel(
            DoctorService doctorService,
            IMapper mapper)
        {
            _doctorService = doctorService;
            _mapper = mapper;
        }

        public async Task OnGetAsync()
        {
            Doctors = _mapper.Map< IEnumerable<DoctorViewModel>>(await _doctorService.GetDoctors());
        }
    }
}