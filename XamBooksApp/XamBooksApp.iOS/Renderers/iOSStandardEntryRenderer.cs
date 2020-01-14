using UIKit;
using Xamarin.Forms.Platform.iOS;

namespace XamBooksApp.iOS.Renderers
{
    // ReSharper disable once InconsistentNaming
    public sealed class iOSStandardEntryRenderer: EntryRenderer
    {
        protected override UITextField CreateNativeControl()
        {
            var control = base.CreateNativeControl();

            control.Layer.CornerRadius = 30.0f;
            //control.Layer.BorderWidth = 2.0f;
            //control.Layer.BorderColor = UIColor.Red.CGColor;

            return control;
        }
    }
}