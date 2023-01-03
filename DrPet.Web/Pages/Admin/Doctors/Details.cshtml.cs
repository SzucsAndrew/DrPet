using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DrPet.Bll.Services;
using DrPet.Web.ViewModels.Doctors;
using AutoMapper;

namespace DrPet.Web.Pages.Admin.Doctors
{
    public class DetailsModel : PageModel
    {
        private readonly DoctorService _doctorService;
        private readonly IMapper _mapper;

        public DetailsModel(DoctorService doctorService, IMapper mapper)
        {
            _doctorService = doctorService;
            _mapper = mapper;
        }

      public DetailDoctorModel Doctor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _doctorService.GetDoctor(id.Value);
            if (doctor == null)
            {
                return NotFound();
            }
            else 
            {
                Doctor = _mapper.Map<DetailDoctorModel>(doctor);
            }
            return Page();
        }
    }
}
