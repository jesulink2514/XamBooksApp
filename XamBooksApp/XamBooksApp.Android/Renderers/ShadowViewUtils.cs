using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Graphics.Drawables.Shapes;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Content;
using Android.Views;
using Android.Widget;

namespace XamBooksApp.Droid.Renderers
{
    public static class ShadowUtils
    {
        public static Drawable GenerateBackgroundWithShadow(
            this View view, 
            Color backgroundColor,
            float cornerRadius,
            Color shadowColor,
            int elevation,
            GravityFlags shadowGravity)
        {
            float[] outerRadius = {cornerRadius, cornerRadius, cornerRadius,
                cornerRadius, cornerRadius, cornerRadius, cornerRadius,
                cornerRadius};

            var backgroundPaint = new Paint();
            backgroundPaint.SetStyle(Paint.Style.Fill);
            backgroundPaint.SetShadowLayer(cornerRadius, 0, 0, backgroundColor);

            var shapeDrawablePadding = new Rect
            {
                Left = elevation, 
                Right = elevation
            };

            int dy = 0;

            switch (shadowGravity)
            {
                case GravityFlags.Center:
                    shapeDrawablePadding.Top = elevation;
                    shapeDrawablePadding.Bottom = elevation;
                    dy = 0;
                    break;
                case GravityFlags.Top:
                    shapeDrawablePadding.Top = elevation * 2;
                    shapeDrawablePadding.Bottom = elevation;
                    dy = -1 * elevation / 3;
                    break;
                case GravityFlags.Bottom:
                    shapeDrawablePadding.Top = elevation;
                    shapeDrawablePadding.Bottom = elevation * 2;
                    dy = elevation / 3;
                    break;
            }

            var shapeDrawable = new ShapeDrawable();
            shapeDrawable.SetPadding(shapeDrawablePadding);

            shapeDrawable.Paint.Color = backgroundColor;
            shapeDrawable.Paint.SetShadowLayer(cornerRadius / 3, 0, dy, shadowColor);

            view.SetLayerType(LayerType.Software, shapeDrawable.Paint);

            shapeDrawable.Shape = new RoundRectShape(outerRadius, null, null);

            var drawable = new LayerDrawable(new Drawable[] { shapeDrawable });
            
            drawable.SetLayerInset(0, elevation, elevation * 2, elevation, elevation * 2);

            return drawable;

        }
    }
}