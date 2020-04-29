
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFCovid19.Interfaces;
using XFCovid19.Services;
using XFCovid19.ViewModels;
using XFCovid19.Views;

namespace XFCovid19
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        MainPageViewModel viewModel;
        IFirebaseAnalytics eventTracker;
        public MainPage()
        {
            InitializeComponent();
           
            BindingContext = viewModel = new MainPageViewModel(new RestService());
        }

        protected override async void OnAppearing()
        {

           
            viewModel.SubscribeChangeLanguage();
            await viewModel.GetAll();
        }

        protected override void OnDisappearing()
        {
            viewModel.OnDisappearing();
        }

        private bool isOpen = false;
        private async void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            if (isOpen == false)
            {
                isOpen = true;
                //Scale to smaller
                await ((Frame)sender).ScaleTo(0.8, 50, Easing.Linear);
                //Wait a moment
                await Task.Delay(100);
                //Scale to normal
                await ((Frame)sender).ScaleTo(1, 50, Easing.Linear);

                //Show FloatMenuItem1
                FloatMenuItem1.IsVisible = true;
                await FloatMenuItem1.TranslateTo(0, 0, 100);
                await FloatMenuItem1.TranslateTo(0, -20, 100);
                await FloatMenuItem1.TranslateTo(0, 0, 200);

                
            }
            else
            {
                isOpen = false;
                //Scale to smaller
                await ((Frame)sender).ScaleTo(0.8, 50, Easing.Linear);
                //Wait a moment
                await Task.Delay(100);
                //Scale to normal
                await ((Frame)sender).ScaleTo(1, 50, Easing.Linear);

                //Hide FloatMenuItem1
                await FloatMenuItem1.TranslateTo(0, 0, 100);
                await FloatMenuItem1.TranslateTo(0, -20, 100);
                await FloatMenuItem1.TranslateTo(0, 0, 200);
                FloatMenuItem1.IsVisible = false;

               
            }

        }

        private async void FloatMenuItem1Tap_OnTapped(object sender, EventArgs e)
        {
            var eventTracker = DependencyService.Get<IFirebaseAnalytics>();
            LabelStatus.Text = "India";
            eventTracker.SendEvent("Click1");
            await Navigation.PushModalAsync(new IndianPage());



        }

      
    }
}
