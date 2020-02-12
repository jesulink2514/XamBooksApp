using Prism.Mvvm;

namespace XamBooksApp.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        public string Title { get; set; } = "Home";
        public int SelectedViewModelIndex { get; set; }
    }

    
}
