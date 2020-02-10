using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;

namespace XamBooksApp.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        public float Radius { get; set; }
        public float Percentage { get; set; }

        public List<string> Items { get; set; } = new List<string>
        {
            "Item 1",
            "Item 2",
            "Item 3",
            "Item 4",
            "Item 5",
            "Item 6"
        };

        public HomePageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
        }
    }
}
