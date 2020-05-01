using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFCovid19.Models;
using XFCovid19.ViewModels;

namespace XFCovid19.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StateWisePage : ContentPage
    {
        StateWiseViewModel StateWiseViewModel;
        public StateWisePage()
        {
            InitializeComponent();
        }
        public StateWisePage(Statewise statewise)
        {
            InitializeComponent();
            StateWiseViewModel = new StateWiseViewModel(statewise);
            this.BindingContext = StateWiseViewModel;

        }
    }
}