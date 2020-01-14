using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Graphics.Drawables.Shapes;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamBooksApp.Controls;
using XamBooksApp.Droid.Renderers;
using Color = Android.Graphics.Color;

[assembly: ExportRenderer(typeof(StandardEntry), typeof(StandardEntryRenderer))]

namespace XamBooksApp.Droid.Renderers
{
    public sealed class StandardEntryRenderer : EntryRenderer
    {
        public StandardEntryRenderer(Context context) : base(context)
        {
        }

        protected override FormsEditText CreateNativeControl()
        {
            var control = base.CreateNativeControl();

            var gd = new GradientDrawable();
            gd.SetColor(Color.White);
            gd.SetCornerRadius(30);
            gd.SetStroke(2, Color.LightGray);
            control.SetBackground(gd);

            return control;
        }
    }
}