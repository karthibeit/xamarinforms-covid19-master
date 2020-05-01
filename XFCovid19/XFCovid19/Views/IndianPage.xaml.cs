using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFCovid19.Interfaces;
using XFCovid19.Models;
using XFCovid19.Services;
using XFCovid19.ViewModels;

namespace XFCovid19.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IndianPage : ContentPage
    {
        IndianPageViewModel indiaViewModel;
        IFirebaseAnalytics eventTracker;
        public IndianPage()
        {

            InitializeComponent();
            
            eventTracker = DependencyService.Get<IFirebaseAnalytics>();
            BindingContext = indiaViewModel = new IndianPageViewModel(new RestService());
        }
        protected override async void OnAppearing()
        {
            ActivityIndicator activityIndicator = new ActivityIndicator { Color = Color.Orange, IsRunning = true };
            indiaViewModel.ChangeLanguageApp();
            eventTracker.SendEvent("indiaViewModel");
            await indiaViewModel.GetTotalsByIndiaCountry("IN");
            StateSearchList.ItemsSource = indiaViewModel.StateWiseListView;
            activityIndicator.IsRunning = false;


        }
        async void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var sateWisePage = new StateWisePage(e.SelectedItem as Statewise);
            await Navigation.PushModalAsync(sateWisePage);
        }
        void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            StateSearchList.ItemsSource = indiaViewModel.StateWiseListView.Where(a => a.State.ToLower().Contains(e.NewTextValue.ToLower()));
        }
    }
}