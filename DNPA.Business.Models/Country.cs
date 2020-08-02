using System;

namespace DNPA.Business.Models
{
    public class Country
    {
        public Guid CountryID { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public string CountryCode3 { get; set; }
        public string Capital { get; set; }
        public string ContinentCode { get; set; }
        public int Area { get; set; }
        public int Population { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencyName { get; set; }
        public string Languages { get; set; }
    }
}
