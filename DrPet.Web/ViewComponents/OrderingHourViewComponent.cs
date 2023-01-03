using DrPet.Bll.Models;
using DrPet.Bll.Services;
using DrPet.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DrPet.Web.ViewComponents
{
    public class OrderingHourViewComponent : ViewComponent//Todo:update
    {
        private readonly OrderingHourService _orderingHourService;

        public PaginationModel<OrderingHour> PaginationOrderingHours { get; set; }
        public DateOnly CurrentDate;

        public OrderingHourViewComponent(OrderingHourService orderingHourService)
        {
            _orderingHourService = orderingHourService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int year, int month, int currentPage)
        {
            CurrentDate = new DateOnly(year, month, 1);
            PaginationOrderingHours = await _orderingHourService.GetOrderingHoursPaginationAsync(CurrentDate, currentPage);

            return View(this);
        }
    }
}
