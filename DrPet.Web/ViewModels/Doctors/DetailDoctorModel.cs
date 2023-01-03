namespace DrPet.Web.ViewModels.Doctors
{
    public class DetailDoctorModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Introduce { get; set; }
        public string? ImageName { get; set; }
    }
}
