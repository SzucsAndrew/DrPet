using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DrPet.Bll.Services;
using DrPet.Web.ViewModels.Doctors;
using AutoMapper;
using DrPet.Data.Entities;
using System.ComponentModel.DataAnnotations;
using DrPet.Web.ViewModels.OrderingHours;
using Ganss.Xss;

namespace DrPet.Web.Pages.Admin.Doctors
{
    public class EditModel : PageModel
    {
        private readonly DoctorService _doctorService;
        private readonly OrderingHourService _orderingHourService;
        private readonly IWebHostEnvironment _webHostEnviroment;
        private readonly FileService _fileService;
        private readonly IMapper _mapper;

        public EditModel(
            DoctorService doctorService,
            OrderingHourService orderingHourService,
            IWebHostEnvironment webHostEnvironment,
            FileService fileService,
            IMapper mapper)
        {
            _doctorService = doctorService;
            _orderingHourService = orderingHourService;
            _webHostEnviroment = webHostEnvironment;
            _fileService = fileService;
            _mapper = mapper;
        }

        [BindProperty]
        public EditDoctorModel Doctor { get; set; }

        [BindProperty]
        public IFormFile? Photo { get; set; }
        [BindProperty]
        [UIHint("OrderingHourEditor")]
        public IList<EditOrderingHour> OrderingHours { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor =  await _doctorService.GetDoctor(id.Value);
            if (doctor == null)
            {
                return NotFound();
            }
            await LoadData(doctor, id.Value);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var doctor = await _doctorService.GetDoctor(Doctor.Id);
            if (doctor == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                SavePhotoAsync(doctor);
                if (Doctor.Introduce != null) {
                    Doctor.Introduce = new HtmlSanitizer().Sanitize(Doctor.Introduce);
                }
                await _doctorService.AddOrUpdateDoctorAsync(_mapper.Map<Doctor>(Doctor));
                await _orderingHourService.Update(_mapper.Map<IList<OrderingHour>>(OrderingHours));
                return RedirectToPage("./Index");
            }

            await LoadData(doctor, Doctor.Id);
            return Page();
        }

        private void SavePhotoAsync(Doctor doctor)
        {
            if (Photo != null)
            {
                var uploadsFolder = Path.Combine(_webHostEnviroment.WebRootPath, "images", "profiles");

                RemoveOldPhoto(doctor, uploadsFolder);

                Doctor.ImageName = _fileService.SaveImage(uploadsFolder, Photo);
            }
        }

        private void RemoveOldPhoto(Doctor doctor, string uploadsFolder)
        {
            if (!string.IsNullOrWhiteSpace(doctor.ImageName))
            {
                var oldFilePath = Path.Combine(uploadsFolder, doctor.ImageName);
                _fileService.RemoveImage(oldFilePath);
            }
        }

        private async Task LoadData(Doctor doctor, int id)
        {
            Doctor = _mapper.Map<EditDoctorModel>(doctor);
            OrderingHours = _mapper.Map<IList<EditOrderingHour>>(await _orderingHourService.GetAllOrderingHours(id));
        }
    }
}
