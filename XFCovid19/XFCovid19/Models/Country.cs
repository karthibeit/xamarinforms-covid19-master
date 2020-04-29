using LiteDB;

namespace XFCovid19.Models
{
    public class Country
    {
        public long updated { get; set; }
        [BsonId]
        public string country { get; set; }
        public Countryinfo countryInfo { get; set; }
        public long cases { get; set; }
        public long todayCases { get; set; }
        public long deaths { get; set; }
        public long todayDeaths { get; set; }
        public long recovered { get; set; }
        public long active { get; set; }
        public long critical { get; set; }
        public long casesPerOneMillion { get; set; }
        public long deathsPerOneMillion { get; set; }
        public long tests { get; set; }
        public int testsPerOneMillion { get; set; }
        public string countryPtBR { get; set; }
    }

    public class Countryinfo
    {
        public int? _id { get; set; }
        public string iso2 { get; set; }
        public string iso3 { get; set; }
        public double lat { get; set; }
        public double _long { get; set; }
        public string flag { get; set; }
    }
}
