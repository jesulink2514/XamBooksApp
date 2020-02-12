using Prism;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Navigation;
using Sharpnado.Presentation.Forms.RenderedViews;
using XamBooksApp.ViewModels;
using XamBooksApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XamBooksApp
{
    public partial class App
    {
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<NavPage>();
            containerRegistry.RegisterForNavigation<LoginPage1, LoginPage1ViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage2, LoginPage2ViewModel>();
            containerRegistry.Register<HomePage>();
            containerRegistry.Register<HomePageViewModel>();
            containerRegistry.Register<MyProfilePage>();
            containerRegistry.Register<MyProfilePageViewModel>();
            containerRegistry.Register<MyBooksPage>();
            containerRegistry.Register<MyBooksPageViewModel>();
        }
    }
}
