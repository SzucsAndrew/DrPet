namespace DrPet.Bll.Models
{
    public class PaginationModel<T>
    {
        public IEnumerable<T> Results { get; set; }
        public int CurrentPage { get; set; }
        public int TotalOfPage { get; set; }
    }
}
