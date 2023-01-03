using Microsoft.AspNetCore.Mvc.RazorPages;
using DrPet.Bll.Services;
using DrPet.Web.ViewModels.Doctors;
using AutoMapper;

namespace DrPet.Web.Pages.Admin.Doctors
{
    public class IndexModel : PageModel
    {
        private readonly DoctorService _doctorService;
        private readonly IMapper _mapper;

        public IndexModel(DoctorService doctorService, IMapper mapper)
        {
            _doctorService = doctorService;
            _mapper = mapper;
        }

        public IList<DoctorViewModel> Doctors { get;set; }

        public async Task OnGetAsync()
        {
            Doctors = _mapper.Map<IList<DoctorViewModel>>(await _doctorService.GetDoctors());
        }
    }
}
