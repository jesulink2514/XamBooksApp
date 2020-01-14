using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using CoreGraphics;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamBooksApp.iOS.Renderers;

[assembly: ExportRenderer(typeof(SearchBar), typeof(iOSStandardSearchBarRenderer))]

namespace XamBooksApp.iOS.Renderers
{
    public sealed class iOSStandardSearchBarRenderer : SearchBarRenderer
    {
        protected override void SetBackgroundColor(Color color)
        {
            base.SetBackgroundColor(color);

            if (Control == null)
                return;

            Control.BarTintColor = UIColor.Clear;
            Control.BackgroundColor = UIColor.Clear;
            Control.Translucent = true;

            if (Control.ValueForKey(new NSString("searchField")) is UITextField textField)
            {
                textField.BackgroundColor = color.ToUIColor();
                textField.Layer.BorderWidth = 1.0f;
                textField.Layer.BorderColor = UIColor.LightGray.CGColor;
                textField.Layer.CornerRadius = 8.0f;
            }

            UpdateCancelButton();
        }
	}
}