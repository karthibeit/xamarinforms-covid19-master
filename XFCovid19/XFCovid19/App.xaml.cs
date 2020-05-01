using Plugin.Multilingual;
using System.Globalization;
using Xamarin.Essentials;
using Xamarin.Forms;
using XFCovid19.Resources;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.WindowsAzure.MobileServices;

namespace XFCovid19
{
    public partial class App : Application
    {
        public static string AppCultureInfo;
       
        
        public App()
        {
            InitializeComponent();

            AppCultureInfo = Preferences.Get("appLanguage", "ta-IN");
            AppResources.Culture = new CultureInfo(AppCultureInfo);
            CrossMultilingual.Current.CurrentCultureInfo = new CultureInfo(AppCultureInfo);
            MainPage = new AppShell();
            //MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            AppCenter.Start("android=16c4f2a3-f087-433f-bacb-320350f43287;" +
                   "uwp={Your UWP App secret here};" +
                   "ios={Your iOS App secret here}",
                   typeof(Analytics), typeof(Crashes));
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
        //static void OnPushNotificationReceived(object sender, PushNotificationReceivedEventArgs e)
        //{
        //    Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
        //    {
        //        var message = e.Message;
        //        if (e.CustomData != null && e.CustomData.Count > 0)
        //        {
        //            message += "\nCustom data = {" + string.Join(",", e.CustomData.Select(kv => kv.Key + "=" + kv.Value)) + "}";
        //        }
        //        Current.MainPage.DisplayAlert(e.Title, message, "OK");
        //    });
        //}

        
    }
}
