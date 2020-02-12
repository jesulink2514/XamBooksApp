using System;
using SkiaRate;
using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace XamBooksApp.Controls
{
    public class RatingViewV2: RatingView
    {
        private float ItemWidth { get; set; }

        private float ItemHeight { get; set; }

        private float CanvasScale { get; set; }

        private SKColor SKColorOn { get; set; } = MaterialColors.Amber;

        private SKColor SKOutlineOnColor { get; set; } = SKColors.Transparent;

        private SKColor SKOutlineOffColor { get; set; } = MaterialColors.Grey;
        protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
        {
            var canvas = e.Surface.Canvas;
            var width = e.Info.Width;
            var height = e.Info.Height;

            canvas.Clear(this.CanvasBackgroundColor);

            var path = SKPath.ParseSvgPathData(this.Path);

            var itemWidth = ((width - (this.Count - 1) * this.Spacing)) / this.Count;
            var scaleX = (itemWidth / (path.Bounds.Width));
            scaleX = (itemWidth - scaleX * this.StrokeWidth) / path.Bounds.Width;

            this.ItemHeight = height;
            var scaleY = this.ItemHeight / (path.Bounds.Height);
            scaleY = (this.ItemHeight - scaleY * this.StrokeWidth) / (path.Bounds.Height);

            this.CanvasScale = Math.Min(scaleX, scaleY);
            this.ItemWidth = path.Bounds.Width * this.CanvasScale;

            canvas.Scale(this.CanvasScale);
            canvas.Translate(this.StrokeWidth / 2, this.StrokeWidth / 2);
            canvas.Translate(-path.Bounds.Left, 0);
            canvas.Translate(0, -path.Bounds.Top);

            using (var strokePaint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = this.SKOutlineOnColor,
                StrokeWidth = this.StrokeWidth,
                StrokeJoin = SKStrokeJoin.Round,
                IsAntialias = true,
            })
            using (var fillPaint = new SKPaint
            {
                Style = SKPaintStyle.Fill,
                Color = this.SKColorOn,
                IsAntialias = true,
            })
            {
                for (int i = 0; i < this.Count; i++)
                {
                    if (i <= this.Value - 1) // Full
                    {
                        canvas.DrawPath(path, fillPaint);
                        canvas.DrawPath(path, strokePaint);
                    }
                    else if (i < this.Value) //Partial
                    {
                        float filledPercentage = (float)(this.Value - Math.Truncate(this.Value));
                        strokePaint.Color = this.SKOutlineOffColor;
                        canvas.DrawPath(path, strokePaint);

                        using (var rectPath = new SKPath())
                        {
                            var rect = SKRect.Create(path.Bounds.Left + path.Bounds.Width * filledPercentage, path.Bounds.Top, path.Bounds.Width * (1 - filledPercentage), this.ItemHeight);
                            rectPath.AddRect(rect);
                            canvas.ClipPath(rectPath, SKClipOperation.Difference);
                            canvas.DrawPath(path, fillPaint);
                        }
                    }
                    else //Empty
                    {
                        strokePaint.Color = this.SKOutlineOffColor;
                        canvas.DrawPath(path, strokePaint);
                    }

                    canvas.Translate((this.ItemWidth + this.Spacing) / this.CanvasScale, 0);
                }
            }
        }
    }
}
