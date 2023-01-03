namespace DrPet.Web.ViewModels.OrderingHours
{
    public class EditOrderingHour
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan? End { get; set; }
        public string? Comment { get; set; }

        public int DoctorId { get; set; }
    }
}
