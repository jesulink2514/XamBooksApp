using Android.Content;
using Android.Graphics.Drawables;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamBooksApp.Droid.Renderers;
using Color = Android.Graphics.Color;

[assembly: ExportRenderer(typeof(SearchBar), typeof(DroidStandardSearchBarRenderer))]
namespace XamBooksApp.Droid.Renderers
{
    public class DroidStandardSearchBarRenderer: SearchBarRenderer
    {
        public DroidStandardSearchBarRenderer(Context context):base(context)
        {
        }

        protected override SearchView CreateNativeControl()
        {
            var control = base.CreateNativeControl();

            SetBackground(control,Element.BackgroundColor.ToAndroid());

            return control;
        }
        public override void SetBackgroundColor(Color color)
        {
            if (Control == null) return;

            SetBackground(Control,color);
        }

        private void SetBackground(SearchView control, Color color)
        {
            var searchPlateId = control.Context.Resources.GetIdentifier("android:id/search_plate", null, null);

            var searchPlate = control.FindViewById(searchPlateId);
            searchPlate.SetBackgroundColor(Color.Transparent);

            var gd = new GradientDrawable();
            gd.SetColor(color);
            gd.SetCornerRadius(30);
            gd.SetStroke(2, Color.LightGray);
            
            //control.SetBackground(gd);

            var shadow = control.GenerateBackgroundWithShadow(
                Color.White,
                60f, 
                Color.LightGray, 
                10, 
                GravityFlags.Center);

            control.SetClipToPadding(false);

            control.SetBackground(shadow);
        }
    }
}