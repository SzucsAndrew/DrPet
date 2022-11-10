using DrPet.Bll.Services;
using DrPet.Data.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DrPet.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly OrderingHourService _orderingHourService;
        private readonly DoctorService _doctorService;
        public DateTime CurrentDate { get; private set; }

        public IEnumerable<OrderingHour> OrderingHours { get; private set; }
        public IEnumerable<Doctor> Doctors { get; private set; }

        public IndexModel(ILogger<IndexModel> logger,
            OrderingHourService orderingHourService,
            DoctorService doctorService)
        {
            _logger = logger;
            _orderingHourService = orderingHourService;
            _doctorService = doctorService;
        }

        public async Task OnGetAsync()
        {
            CurrentDate = DateTime.Now;
            OrderingHours = await _orderingHourService.GetOrderingOursAsync(CurrentDate);
            Doctors = await _doctorService.GetDoctors();
        }
    }
}