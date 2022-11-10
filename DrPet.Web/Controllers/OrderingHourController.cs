using Microsoft.AspNetCore.Mvc;

namespace DrPet.Web.Controllers
{
    [Route("{controller}")]
    public class OrderingHourController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("ReloadOrderingHours")]
        public IActionResult ReloadOrderingHours(int year, int month, int currentPage)
        {
            return ViewComponent("OrderingHour", new { year = year, month = month, currentPage = currentPage });
        }
    }
}
