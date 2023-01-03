using DrPet.Web.ViewModels.Doctors;
using Microsoft.AspNetCore.Mvc;

namespace DrPet.Web.ViewComponents
{
    public class DoctorListViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(IList<DoctorViewModel> doctors)
        {
            return View(doctors);
        }
    }
}
