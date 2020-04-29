﻿using Flurl;
using Flurl.Http;
using Microsoft.AppCenter.Crashes;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XFCovid19.Helpers;
using XFCovid19.Interfaces;
using XFCovid19.Models;

namespace XFCovid19.Services
{
    public class RestService : IRestService
    {
        public async Task<GlobalTotals> GetGlobalTotals()
        {
           // await Task.Delay(2000);

            try
            {
                var response = await Constants.BASE_URL
                    .AppendPathSegment("all")
                    .WithTimeout(TimeSpan.FromSeconds(30))
                    .GetJsonAsync<GlobalTotals>();

                return response;
            }
            catch (FlurlHttpException ex)
            {
                Crashes.TrackError(ex);
            
            var error = ex.Message;
                return null;
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                var error = ex.Message;
                return null;
            }
        }

        public async Task<Country> GetTotalsByCountry(string countryISO)
        {
           // await Task.Delay(2000);

            try
            {
               

                    var response = await Constants.BASE_URL
                    .AppendPathSegment($"countries/{countryISO}")
                    .WithTimeout(TimeSpan.FromSeconds(30))
                    .GetJsonAsync<Country>();
                if (countryISO == "IN")
                {
                    var response2 = await Constants.BASE_URL_INDIA
                    .AppendPathSegment($"data.json")
                    .WithTimeout(TimeSpan.FromSeconds(30))
                    .GetJsonAsync<Indian>();

                    response.cases = response2.CasesTimeSeries.LastOrDefault()?.Totalconfirmed ?? 0;
                    
                }

                return response;
            }
            catch (FlurlHttpException ex)
            {
                Crashes.TrackError(ex);
                var error = ex.Message;
                return null;
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                var error = ex.Message;
                return null;
            }
        }
        public async Task<Indian> GetTotalsByIndiaCountry(string countryISO)
        {
            await Task.Delay(2000);

            try
            {

               
                var response = await Constants.BASE_URL_INDIA
                    .AppendPathSegment($"data.json")
                    .WithTimeout(TimeSpan.FromSeconds(30))
                    .GetJsonAsync<Indian>();

                //indiaReport.Country.cases = response.CasesTimeSeries.LastOrDefault()?.Totalconfirmed ?? 0;
                //indiaReport.Country.recovered = response.CasesTimeSeries.LastOrDefault()?.Totalrecovered ?? 0;
                //indiaReport.Country.deaths = response.CasesTimeSeries.LastOrDefault()?.Totaldeceased ?? 0;
                //indiaReport.Statewise = response.Statewise.ToList();



                return response;
            }
            catch (FlurlHttpException ex)
            {
                Crashes.TrackError(ex);
                var error = ex.Message;
                return null;
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                var error = ex.Message;
                return null;
            }
        }

        public async Task<IEnumerable<Country>> GetAllCountries()
        {
            await Task.Delay(2000);

            try
            {
                var response = await Constants.BASE_URL
                    .AppendPathSegment("countries")
                    .WithTimeout(TimeSpan.FromSeconds(30))
                    .GetJsonAsync<IList<Country>>();

                return response;
            }
            catch (FlurlHttpException ex)
            {
                Crashes.TrackError(ex);
                var error = ex.Message;
                return null;
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex);
                var error = ex.Message;
                return null;
            }
        }
    }
}
