using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamBooksApp.Controls;
using XamBooksApp.iOS.Renderers;

[assembly: ExportRenderer(typeof(StandardEntry), typeof(iOSStandardEntryRenderer))]
namespace XamBooksApp.iOS.Renderers
{
    // ReSharper disable once InconsistentNaming
    public sealed class iOSStandardEntryRenderer: EntryRenderer
    {
        protected override UITextField CreateNativeControl()
        {
            var control = base.CreateNativeControl();

            control.Layer.CornerRadius = 8.0f;
            control.Layer.BorderWidth = 1.0f;
            control.Layer.BorderColor = UIColor.LightGray.CGColor;

            return control;
        }
    }
}