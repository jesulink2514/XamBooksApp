using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using XamBooksApp.Models;

namespace XamBooksApp.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        public float Radius { get; set; }
        public float Percentage { get; set; }

        public List<AuthorViewModel> TopAuthors { get; set; } = SampleAuthors.All
            .ToList();

        public List<Book> LatestBooks { get; set; } = Books.All.ToList();

        public HomePageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
        }
    }

    public class AuthorViewModel : Author
    {
        public bool Following { get; set; }
    }
}
