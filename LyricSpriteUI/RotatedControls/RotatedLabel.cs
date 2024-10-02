using SkiaSharp;

namespace LyricSpriteUI.RotatedControls
{
	public class RotatedLabel : RotatedControl
	{
		private SKRect margin;
		private string text = "";
		private SKFont font = new();
		private SKPaint style = new();
		public string Text
		{
			get => text; set
			{
				text = value;
				Resize();
			}
		}
		public SKFont Font
		{
			get => font; set
			{
				font = value;
				Resize();
			}
		}
		public SKPaint TextStyle
		{
			get => style; set
			{
				style = value;
				Resize();
			}
		}
		public SKRect Margin
		{
			get => margin; set
			{
				margin = value;
			}
		}
		public RotatedLabel(string text)
		{
			this.Text = text;
		}
		private void Resize()
		{
				Font.MeasureText(text, out SKRect r, TextStyle);
				Size = r.Size + new SKSize(margin.Left + margin.Right, margin.Top + margin.Bottom);
		}
		public RotatedLabel() : this("") { }
		protected override void OnPaintSurfaceOthers(SKCanvas e)
		{
			Font.MeasureText(text, out SKRect r, TextStyle);
			e.DrawText(text, new(margin.Left, margin.Top - r.Top), Font, TextStyle);
		}
	}
}
