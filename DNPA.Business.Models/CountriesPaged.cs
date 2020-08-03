namespace DNPA.Business.Models
{
    public class CountriesPaged
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public string OrderBy { get; set; }
    }
}
