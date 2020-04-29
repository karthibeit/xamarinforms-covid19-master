using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XFCovid19.Models;

namespace XFCovid19.Interfaces
{
    public interface IRestService
    {
        Task<GlobalTotals> GetGlobalTotals();
        Task<Country> GetTotalsByCountry(string countryISO);
        Task<Indian> GetTotalsByIndiaCountry(string countryISO);
        Task<IEnumerable<Country>> GetAllCountries();
    }
}
