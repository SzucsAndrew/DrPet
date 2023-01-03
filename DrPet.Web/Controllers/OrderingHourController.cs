using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DrPet.Web.Controllers
{
    [Route("{controller}")]
    [AllowAnonymous]
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
            return ViewComponent("OrderingHour", new { year, month, currentPage });
        }

        //TODO:
        //get pagination context
        //get doctor order pagination
    }
}
