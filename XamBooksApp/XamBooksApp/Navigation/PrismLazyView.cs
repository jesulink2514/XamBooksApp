using System;
using Sharpnado.Presentation.Forms.CustomViews;
using Xamarin.Forms;

namespace XamBooksApp.Navigation
{
    public class PrismLazyView<TView> : ALazyView where TView : View, new()
    {
        public override void LoadView()
        {
            this.IsLoaded = true;

            var view = App.Current.Container.Resolve(typeof(TView)) as TView;
            this.Content = (View) view ?? throw new NullReferenceException();
        }

        protected override void OnBindingContextChanged()
        {
            //Cancel default behavior to preserve Prism ViewModel
        }
    }
}
