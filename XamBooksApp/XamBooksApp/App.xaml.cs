using Prism;
using Prism.Ioc;
using XamBooksApp.ViewModels;
using XamBooksApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XamBooksApp
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavPage/MainPage");
            //await NavigationService.NavigateAsync("LoginPage1");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<NavPage>();
            containerRegistry.RegisterForNavigation<LoginPage1, LoginPage1ViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage2, LoginPage2ViewModel>();
        }
    }
}
