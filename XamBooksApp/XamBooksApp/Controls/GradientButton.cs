using System;
using System.Windows.Input;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace XamBooksApp.Controls
{
    public class GradientButton : SKCanvasView
    {
        public GradientButton()
        {
            EnableTouchEvents = true;
        }
        public static BindableProperty CornerRadiusProperty = BindableProperty.Create(nameof(CornerRadius), typeof(float),
            typeof(GradientToogleButton), 5f, BindingMode.OneWay,
            validateValue: (_, value) => value != null && (float)value >= 0,
            propertyChanged: OnPropertyChangedInvalidate);

        public float CornerRadius
        {
            get => (float)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }


        public static BindableProperty FontSizeProperty = BindableProperty.Create(nameof(FontSize), typeof(float),
            typeof(GradientToogleButton), 12f, BindingMode.OneWay,
            validateValue: (_, value) => value != null && (float)value >= 0,
            propertyChanged: OnPropertyChangedInvalidate);

        public float FontSize
        {
            get => (float)GetValue(FontSizeProperty);
            set => SetValue(FontSizeProperty, value);
        }

        public static BindableProperty GradientStartColorProperty = BindableProperty.Create(nameof(GradientStartColor), typeof(Color),
            typeof(GradientToogleButton), Color.Purple, BindingMode.OneWay,
            validateValue: (_, value) => value != null, propertyChanged: OnPropertyChangedInvalidate);

        public Color GradientStartColor
        {
            get => (Color)GetValue(GradientStartColorProperty);
            set => SetValue(GradientStartColorProperty, value);
        }

        public static BindableProperty GradientEndColorProperty = BindableProperty.Create(nameof(GradientEndColor), typeof(Color),
            typeof(GradientToogleButton), Color.Blue, BindingMode.OneWay,
            validateValue: (_, value) => value != null, propertyChanged: OnPropertyChangedInvalidate);

        public Color GradientEndColor
        {
            get => (Color)GetValue(GradientEndColorProperty);
            set => SetValue(GradientEndColorProperty, value);
        }

        public static BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color),
            typeof(GradientToogleButton), Color.Blue, BindingMode.OneWay,
            validateValue: (_, value) => value != null, propertyChanged: OnPropertyChangedInvalidate);

        public Color TextColor
        {
            get => (Color)GetValue(TextColorProperty);
            set => SetValue(TextColorProperty, value);
        }

        public static BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand),
            typeof(GradientToogleButton), null, BindingMode.OneWay);

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public static BindableProperty CommandParameterProperty = BindableProperty.Create(nameof(CommandParameter), typeof(object),
            typeof(GradientToogleButton), null, BindingMode.OneWay);

        public object CommandParameter
        {
            get => GetValue(CommandParameterProperty);
            set => SetValue(CommandParameterProperty, value);
        }

        public static BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string),
            typeof(GradientToogleButton), string.Empty, BindingMode.OneWay, propertyChanged: OnPropertyChangedInvalidate);

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
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

            var str = Text ?? string.Empty;

            canvas.Clear();

            var strokeWidth = 10;

            var controlRect = new SKRect(strokeWidth, strokeWidth, info.Width - strokeWidth, height - strokeWidth);

            var backgroundBar = new SKRoundRect(controlRect, cornerRadius, cornerRadius);

            using (var paint = new SKPaint()
            {
                IsAntialias = true,
                Color = Color.White.ToSKColor(),
                Style = SKPaintStyle.StrokeAndFill
            })
            {
                float y = info.Height;

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

        protected void RaiseClickedEvent()
        {
            Clicked?.Invoke(this, new TappedEventArgs(CommandParameter));
        }

        public event EventHandler<TappedEventArgs> Clicked;
    }
}