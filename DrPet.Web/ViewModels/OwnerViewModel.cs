namespace DrPet.Web.ViewModels
{
    public class OwnerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Place { get; set; }
        public string? Comment { get; set; }
    }
}
