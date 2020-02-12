using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace XamBooksApp.Controls
{
    public class GradientToogleButton : GradientButton
    {
        public GradientToogleButton()
        {
            EnableTouchEvents = true;
        }

        public static BindableProperty BarBackgroundColorProperty = BindableProperty.Create(nameof(BarBackgroundColor), typeof(Color),
            typeof(GradientToogleButton), Color.White, BindingMode.OneWay,
            validateValue: (_, value) => value != null, propertyChanged: OnPropertyChangedInvalidate);

        public Color BarBackgroundColor
        {
            get => (Color)GetValue(BarBackgroundColorProperty);
            set => SetValue(BarBackgroundColorProperty, value);
        }


        public static BindableProperty AlternativeTextColorProperty = BindableProperty.Create(nameof(AlternativeTextColor), typeof(Color),
            typeof(GradientToogleButton), Color.Blue, BindingMode.OneWay,
            validateValue: (_, value) => value != null, propertyChanged: OnPropertyChangedInvalidate);

        public Color AlternativeTextColor
        {
            get => (Color)GetValue(AlternativeTextColorProperty);
            set => SetValue(AlternativeTextColorProperty, value);
        }

        public static BindableProperty IsSelectedProperty = BindableProperty.Create(nameof(IsSelected), typeof(bool),
            typeof(GradientToogleButton), false, BindingMode.TwoWay, validateValue: (_, value) => value != null, propertyChanged: OnPropertyChangedInvalidate);

        public bool IsSelected
        {
            get => (bool)GetValue(IsSelectedProperty);
            set => SetValue(IsSelectedProperty, value);
        }

        public static BindableProperty SelectedTextProperty = BindableProperty.Create(nameof(SelectedText), typeof(string),
            typeof(GradientToogleButton), string.Empty, BindingMode.OneWay, propertyChanged: OnPropertyChangedInvalidate);

        public string SelectedText
        {
            get => (string)GetValue(SelectedTextProperty);
            set => SetValue(SelectedTextProperty, value);
        }

        public static BindableProperty UnselectedTextProperty = BindableProperty.Create(nameof(UnselectedText), typeof(string),
            typeof(GradientToogleButton), string.Empty, BindingMode.OneWay, propertyChanged: OnPropertyChangedInvalidate);

        public string UnselectedText
        {
            get => (string)GetValue(UnselectedTextProperty);
            set => SetValue(UnselectedTextProperty, value);
        }


        private static void OnPropertyChangedInvalidate(BindableObject bindable, object oldvalue, object newvalue)
        {
            var control = (GradientToogleButton)bindable;

            if (oldvalue != newvalue)
                control.InvalidateSurface();
        }

        protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
        {
            var info = e.Info;
            var canvas = e.Surface.Canvas;

            float width = (float)Width;
            var scale = CanvasSize.Width / width;


            var cornerRadius = CornerRadius * scale;

            var textSize = FontSize * scale;

            var height = e.Info.Height;

            var str = IsSelected ? SelectedText ?? string.Empty : UnselectedText ?? SelectedText ?? string.Empty;

            canvas.Clear();

            var strokeWidth = 10;

            var controlRect = new SKRect(strokeWidth, strokeWidth, info.Width - strokeWidth, height - strokeWidth);

            var backgroundBar = new SKRoundRect(controlRect, cornerRadius, cornerRadius);

            using (var paint = new SKPaint()
            {
                IsAntialias = true,
                Color = BarBackgroundColor.ToSKColor(),
                Style = SKPaintStyle.StrokeAndFill
            })
            {
                float y = info.Height;

                if (!IsSelected)
                {
                    paint.StrokeWidth = 10;
                    paint.Style = SKPaintStyle.Stroke;
                }

                paint.Shader = SKShader.CreateLinearGradient(
                    new SKPoint(controlRect.Left, controlRect.Top),
                    new SKPoint(controlRect.Right, controlRect.Top),
                    new[]
                    {
                        GradientStartColor.ToSKColor(),
                        GradientEndColor.ToSKColor()
                    },
                    new float[] { 0, 1 },
                    SKShaderTileMode.Clamp);

                canvas.DrawRoundRect(backgroundBar, paint);
            }

            var textPaint = new SKPaint
            {
                Color = TextColor.ToSKColor(),
                TextSize = textSize
            };

            if (!IsSelected)
            {
                textPaint.Shader = SKShader.CreateLinearGradient(
                    new SKPoint(controlRect.Left, controlRect.Top),
                    new SKPoint(controlRect.Right, controlRect.Top),
                    new[]
                    {
                        GradientStartColor.ToSKColor(),
                        GradientEndColor.ToSKColor()
                    },
                    new float[] { 0, 1 },
                    SKShaderTileMode.Clamp);
            }

            var textBounds = new SKRect();

            textPaint.MeasureText(str, ref textBounds);

            var xText = CanvasSize.Width / 2 - textBounds.MidX;

            var yText = info.Height / 2 - textBounds.MidY;

            canvas.DrawText(str, xText, yText, textPaint);
        }

        protected override void OnTouch(SKTouchEventArgs e)
        {
            switch (e.ActionType)
            {
                case SKTouchAction.Released:
                    // end of a stroke
                    IsSelected = !IsSelected;

                    InvalidateSurface();

                    if (Command != null && Command.CanExecute(CommandParameter))
                    {
                        Command.Execute(CommandParameter);
                    }

                    RaiseClickedEvent();

                    break;
            }

            e.Handled = true;
        }

    }
}