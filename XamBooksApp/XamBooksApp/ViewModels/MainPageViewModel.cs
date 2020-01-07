using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XamBooksApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private float _percentage;

        public float Percentage
        {
            get => _percentage;
            set
            {
                _percentage = value;
                RaisePropertyChanged();
            }
        }
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
        }
    }
}
