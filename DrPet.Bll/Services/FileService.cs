using Microsoft.AspNetCore.Http;

namespace DrPet.Bll.Services
{
    public class FileService
    {
        public string SaveImage(string uploadsFolder, IFormFile photo)
        {
            var uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                photo.CopyTo(fileStream);
            }

            return uniqueFileName;
        }

        public void RemoveImage(string imagePath)
        {
            if (!string.IsNullOrWhiteSpace(imagePath))
            {
                if (File.Exists(imagePath))
                {
                    File.Delete(imagePath);
                }
            }
        }
    }
}
