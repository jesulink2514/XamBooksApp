using System.ComponentModel;
using Android.Content;
using Android.Graphics.Drawables;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamBooksApp.Controls;
using XamBooksApp.Droid.Renderers;

[assembly: ExportRenderer(typeof(StandardEntry), typeof(StandardEntryRenderer))]

namespace XamBooksApp.Droid.Renderers
{
    public class StandardEntryRenderer : EntryRenderer
    {
        public StandardEntryRenderer(Context context) : base(context)
        {
        }

        public StandardEntry ElementV2 => Element as StandardEntry;
        protected override FormsEditText CreateNativeControl()
        {
            var control = base.CreateNativeControl();
            UpdateBackground(control);
            return control;
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == StandardEntry.CornerRadiusProperty.PropertyName)
            {
                UpdateBackground();
            }else if (e.PropertyName == StandardEntry.BorderThicknessProperty.PropertyName)
            {
                UpdateBackground();
            }else if (e.PropertyName == StandardEntry.BorderColorProperty.PropertyName)
            {
                UpdateBackground();
            }
                    
            base.OnElementPropertyChanged(sender, e);
        }
        
        protected override void UpdateBackgroundColor()
        {
            UpdateBackground();
        }
        protected void UpdateBackground(FormsEditText control)
        {
            if (control == null) return;

            var gd = new GradientDrawable();
            gd.SetColor(Element.BackgroundColor.ToAndroid());
            gd.SetCornerRadius(Context.ToPixels(ElementV2.CornerRadius));
            gd.SetStroke((int)Context.ToPixels(ElementV2.BorderThickness), ElementV2.BorderColor.ToAndroid());
            control.SetBackground(gd);

            var padTop = (int)Context.ToPixels(ElementV2.Padding.Top);
            var padBottom = (int)Context.ToPixels(ElementV2.Padding.Bottom);
            var padLeft = (int)Context.ToPixels(ElementV2.Padding.Left);
            var padRight = (int)Context.ToPixels(ElementV2.Padding.Right);
            
            control.SetPadding(padLeft,padTop,padRight,padBottom);
        }
        protected void UpdateBackground()
        {
            UpdateBackground(Control);
        }
    }
}