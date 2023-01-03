using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DrPet.Bll.Services;
using DrPet.Web.ViewModels.Doctors;
using AutoMapper;
using DrPet.Data.Entities;
using Ganss.Xss;

namespace DrPet.Web.Pages.Admin.Doctors
{
    public class CreateModel : PageModel
    {
        private readonly DoctorService _doctorService;
        private readonly IWebHostEnvironment _webHostEnviroment;
        private readonly FileService _fileService;
        private readonly IMapper _mapper;

        public CreateModel(
            DoctorService doctorService,
            IWebHostEnvironment webHostEnvironment,
            FileService fileService,
            IMapper mapper)
        {
            _doctorService = doctorService;
            _webHostEnviroment = webHostEnvironment;
            _fileService = fileService;
            _mapper = mapper;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CreateDoctorModel Doctor { get; set; }

        [BindProperty]
        public IFormFile Photo { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid) return Page();

            SavePhoto();
            if (Doctor.Introduce != null)
            {
                Doctor.Introduce = new HtmlSanitizer().Sanitize(Doctor.Introduce);
            }
            var doctor = _mapper.Map<Doctor>(Doctor);
            await _doctorService.AddOrUpdateDoctorAsync(doctor);

            return RedirectToPage("./Index");
        }

        private void SavePhoto()
        {
            string uploadsFolder = Path.Combine(_webHostEnviroment.WebRootPath, "images", "profiles");
            Doctor.ImageName = _fileService.SaveImage(uploadsFolder, Photo);
        }
    }
}
