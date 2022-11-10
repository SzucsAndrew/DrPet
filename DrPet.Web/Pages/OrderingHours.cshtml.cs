using DrPet.Bll.Services;
using DrPet.Data.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DrPet.Web.Pages
{
    public class OrderingHoursModel : PageModel
    {
        private readonly OrderingHourService _orderingHourService;

        public IEnumerable<OrderingHour> OrderingHours { get; set; }
        public DateOnly CurrentDate;

        public OrderingHoursModel(OrderingHourService orderingHourService)
        {
            _orderingHourService = orderingHourService;
        }

        public async Task OnGet(int year, int month)
        {
            CurrentDate = new DateOnly(year, month, 1);
            OrderingHours = await _orderingHourService.GetOrderingHoursAsync(CurrentDate.Year, CurrentDate.Month);
        }
    }
}
