using DrPet.Bll.Services;
using DrPet.Data.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DrPet.Web.Pages
{
    public class DoctorOrderingHoursModel : PageModel
    {
        public readonly OrderingHourService _orderingHourService;
        public readonly DoctorService _doctorService;

        public IEnumerable<OrderingHour> OrderingHours { get; private set; }
        public Doctor? Doctor { get; private set; }

        public DoctorOrderingHoursModel(OrderingHourService orderingHourService, DoctorService doctorService)
        {
            _orderingHourService = orderingHourService;
            _doctorService = doctorService;
        }

        public async Task OnGetAsync(int id)
        {
            Doctor = await _doctorService.GetDoctor(id);
            OrderingHours = await _orderingHourService.GetFuturingOrderingOursByDoctorAsync(id, DateTime.UtcNow);
        }
    }
}
