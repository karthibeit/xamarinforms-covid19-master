using System;
using System.Collections.Generic;
using System.Text;
using XFCovid19.Models;
using XFCovid19.ViewModel;
using XFCovid19.Views;

namespace XFCovid19.ViewModels
{
    public class StateWiseViewModel : BaseViewModel
    {
        private Statewise _statewise;
        public Statewise Statewise
        {
            get => _statewise;
            set
            {
                SetProperty(ref _statewise, value);
            }
        }

        public StateWiseViewModel(Statewise statewise)
        {
            this.Statewise = statewise;
        }
    }
}
