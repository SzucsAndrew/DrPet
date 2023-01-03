using AutoMapper;
using DrPet.Bll.Services;
using DrPet.Data.Entities;
using DrPet.Web.ViewModels.Doctors;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DrPet.Web.Pages
{
    public class DoctorOrderingHoursModel : PageModel
    {
        private readonly OrderingHourService _orderingHourService;
        private readonly DoctorService _doctorService;
        private readonly IMapper _mapper;

        public IEnumerable<OrderingHour> OrderingHours { get; private set; }
        public DoctorViewModel? Doctor { get; private set; }

        public DoctorOrderingHoursModel(OrderingHourService orderingHourService, DoctorService doctorService, IMapper mapper)
        {
            _orderingHourService = orderingHourService;
            _doctorService = doctorService;
            _mapper = mapper;
        }

        public async Task OnGetAsync(int id)
        {
            Doctor = _mapper.Map<DoctorViewModel?>(await _doctorService.GetDoctor(id));
            OrderingHours = await _orderingHourService.GetFuturingOrderingOursByDoctorAsync(id, DateTime.UtcNow);
        }
    }
}
