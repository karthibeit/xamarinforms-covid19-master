using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XFCovid19.Helpers;
using XFCovid19.Interfaces;
using XFCovid19.Models;
using XFCovid19.ViewModel;

namespace XFCovid19.ViewModels
{
    class IndianPageViewModel : BaseViewModel
    {
        private IRestService _service;

        public IndianPageViewModel(IRestService restService)
        {
            _service = restService;


        }
        public async Task GetTotalsByIndiaCountry(string countryISO2)
        {
            var response = await _service.GetTotalsByIndiaCountry(countryISO2);
            
            SetTotalIndianCountry(response);
        }
        public void ChangeLanguageApp()
        {
            //Title = TranslateExtension.TranslateText("MainHeader");
            //LastUpdateHeader = $"{TranslateExtension.TranslateText("MainHeaderSubtitle")} {GlobalTotals.updated.TransformLongToDateTime().FormatDateTime(App.AppCultureInfo)}";
            //GlobalUpdateHeader = TranslateExtension.TranslateText("GlobalUpdateHeader");
            ConfirmedHeader = TranslateExtension.TranslateText("ConfirmedHeader");
            RecoveredHeader = TranslateExtension.TranslateText("RecoveredHeader");
            DeathsHeader = TranslateExtension.TranslateText("DeathsHeader");
            //RefreshHeader = TranslateExtension.TranslateText("RefreshHeader");
            //CountryNameSelected = TranslateExtension.TranslateText(Country.country);
            //LastUpdateSubtitleCountry = $"{TranslateExtension.TranslateText("MainHeaderSubtitle")} {Country.updated.TransformLongToDateTime().FormatDateTime(App.AppCultureInfo)}";
            //LearnAboutCovid = TranslateExtension.TranslateText("LearnAboutCovid");
            //ReadMoreCovid = TranslateExtension.TranslateText("ReadMoreCovid");
            //HashTagCovid = TranslateExtension.TranslateText("HashTagCovid");
        }
        private void SetTotalIndianCountry(Indian response)
        {
            if (response != null)
            {
                StateWiseListView = new ObservableCollection<Statewise>();
                var lastest =  response.CasesTimeSeries.LastOrDefault().Dailyconfirmed;
                
                //Country = response;
                //LastUpdateSubtitleCountry = $"{TranslateExtension.TranslateText("CountrySubtitle")} {Country.updated.TransformLongToDateTime().FormatDateTime(App.AppCultureInfo)}";
                CountryConfirmed = response.CasesTimeSeries.LastOrDefault().Totalconfirmed.TransformLongToString();
                CountryRecovered = response.CasesTimeSeries.LastOrDefault().Totalrecovered.TransformLongToString();
                CountryDeaths = response.CasesTimeSeries.LastOrDefault().Totaldeceased.TransformLongToString();
                foreach (var item in response.Statewise)
                    StateWiseListView.Add(item);
                 
                //CountryFlag = response.countryInfo.flag;
                //CountryNameSelected = TranslateExtension.TranslateText(Country.country);
            }
            else
            {
                //LastUpdateSubtitleCountry = "------------------------------";
                CountryConfirmed = "-";
                CountryRecovered = "-";
                CountryDeaths = "-";
            }
        }
        private ObservableCollection<Statewise> _stateWiseListView;
        public ObservableCollection<Statewise> StateWiseListView
        {
            get { return _stateWiseListView; }
            set { SetProperty(ref _stateWiseListView, value); }
        }
        private string _confirmedHeader;
        public string ConfirmedHeader
        {
            get { return _confirmedHeader; }
            set { SetProperty(ref _confirmedHeader, value); }
        }
        private string _countryConfirmed;
        public string CountryConfirmed
        {
            get { return _countryConfirmed; }
            set { SetProperty(ref _countryConfirmed, value); }
        }
        private string _recoveredHeader;
        public string RecoveredHeader
        {
            get { return _recoveredHeader; }
            set { SetProperty(ref _recoveredHeader, value); }
        }
        private string _countryRecovered;
        public string CountryRecovered
        {
            get { return _countryRecovered; }
            set { SetProperty(ref _countryRecovered, value); }
        }
        private string _deathsHeader;
        public string DeathsHeader
        {
            get { return _deathsHeader; }
            set { SetProperty(ref _deathsHeader, value); }
        }
        private string _countryDeaths;
        public string CountryDeaths
        {
            get { return _countryDeaths; }
            set { SetProperty(ref _countryDeaths, value); }
        }
    }
}
