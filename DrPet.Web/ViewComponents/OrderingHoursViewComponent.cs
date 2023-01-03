using DrPet.Bll.Services;
using Microsoft.AspNetCore.Mvc;

namespace DrPet.Web.ViewComponents
{
    public class OrderingHoursViewComponent : ViewComponent
    {
        private readonly OrderingHourService _orderingHourService;
        public OrderingHoursViewComponent(OrderingHourService orderingHourService)
        {
            _orderingHourService = orderingHourService;
        }

        public async Task<IViewComponentResult> InvokeAsync(DateTime dateTime)
        {
            var orderingHours = await _orderingHourService.GetOrderingOursAsync(dateTime);
            return View(orderingHours);
        }
    }
}
