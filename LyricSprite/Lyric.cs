using SkiaSharp;
using System.Text.RegularExpressions;

namespace LyricSprite
{
	public partial struct Lyric(TimeSpan time, string text = "")
	{
		private static readonly SKPaint boundStyle = new()
		{
			Color = SKColors.Red,
			IsStroke = true,
			IsAntialias = true,
			StrokeWidth = 2,
		};
		public string Text { get; set; } = text;
		public TimeSpan Time { get; set; } = time;
		public SplitOptions SplitOption { get; set; }
		public SKFont Font { get; set; } = new();
		public SKPaint Style { get; set; } = new();
		public SKTextAlign Align { get; set; } = SKTextAlign.Center;
		public Lyric(string text = "") : this(TimeSpan.Zero, text) { }
		public float GlowSigma { get; set; } = 0;
		public float OutlineStrokeWidth { get; set; } = 0;
		public readonly bool CanDraw(SKRect rect) =>
			rect.Width >= Bounds.Width &&
			rect.Height >= Bounds.Height;
		public readonly void Draw(SKCanvas canvas, SKRect rect) => Draw(canvas, rect, -Bounds.Top);
		public readonly void DrawGlow(SKCanvas canvas, SKRect rect) => DrawGlow(canvas, rect, -Bounds.Top);
		public readonly void DrawOutline(SKCanvas canvas, SKRect rect) => DrawOutline(canvas, rect, -Bounds.Top);
		public readonly void DrawBounds(SKCanvas canvas, SKRect rect) => DrawBounds(canvas, rect, -Bounds.Top);
		public readonly void Draw(SKCanvas canvas, SKRect rect, float baseline)
		{
			if (CanDraw(rect))
			{
				canvas.DrawText(
					Text,
					new(GetX(rect), rect.Top + baseline),
					Align,
					Font,
					Style);
			}
		}
		public readonly void DrawGlow(SKCanvas canvas, SKRect rect, float baseline)
		{
			if (CanDraw(rect))
			{
				float x = GetX(rect);
				SKMaskFilter storedFilter = Style.MaskFilter;
				SKColor storedColor = Style.Color;
				Style.MaskFilter = SKMaskFilter.CreateBlur(SKBlurStyle.Outer, GlowSigma);
				Style.Color = SKColors.White;
				canvas.DrawText(
					Text,
					new(x, rect.Top + baseline),
					Align,
					Font,
					Style);
				Style.MaskFilter = storedFilter;
				Style.Color = storedColor;
			}
		}
		public readonly void DrawOutline(SKCanvas canvas, SKRect rect, float baseline)
		{
			if (CanDraw(rect))
			{
				float x = GetX(rect);
				SKColor storedColor = Style.Color;
				SKPaintStyle storedStyle = Style.Style;
				float storedStrokeWidth = Style.StrokeWidth;
				Style.Color = SKColors.White;
				Style.Style = SKPaintStyle.Stroke;
				Style.StrokeWidth = OutlineStrokeWidth;
				canvas.DrawText(
					Text,
					new(x, rect.Top + baseline),
					Align,
					Font,
					Style);
				Style.Color = storedColor;
				Style.Style = storedStyle;
				Style.StrokeWidth = storedStrokeWidth;
			}
		}
		public readonly void DrawBounds(SKCanvas canvas, SKRect rect, float baseline)
		{
			SKRect motifiedBound = Bounds;
			motifiedBound.Offset(Align switch
			{
				SKTextAlign.Left => rect.Left,
				SKTextAlign.Center => rect.MidX - Bounds.Width / 2,
				SKTextAlign.Right => rect.Right - Bounds.Width,
				_ => throw new NotImplementedException(),
			} - Bounds.Left, rect.Top + baseline);
			canvas.DrawRect(motifiedBound, boundStyle);
		}
		private readonly float GetX(SKRect rect) => Align switch
		{
			SKTextAlign.Left => rect.Left,
			SKTextAlign.Center => rect.MidX - (Bounds.Width - Width) / 2,
			SKTextAlign.Right => rect.Right - (Bounds.Width - Width),
			_ => throw new NotImplementedException(),
		} - Bounds.Left;
		public readonly List<string> Split => SplitOption switch
		{
			SplitOptions.WholeSentence => [Text],
			SplitOptions.SplitByChar => [.. Text.Select(i => i.ToString())],
			SplitOptions.SplitBySpace => [.. Text.Split('\n')
				.SelectMany(i => WordSplitRegex().Split(i))
				.Select(i => i.Replace("\\n", "\n"))],
			SplitOptions.SplitBySlash => [.. SlashSplitRegex().Split(Text)],
			SplitOptions.ProgressiveSplitByChar => [.. ProgressiveBuild([.. Text.Select(i => i.ToString())])],
			SplitOptions.ProgressiveSplitBySpace => [.. ProgressiveBuild(WordSplitRegex().Split(Text), " ")],
			SplitOptions.ProgressiveSplitBySlash => [.. ProgressiveBuild(Text.Split('\n').
				SelectMany(i => WordSplitRegex().Split(i))
				.Select(i => i.Replace("\\n", "\n")).ToArray())],
			_ => throw new NotSupportedException(),
		};
		private static List<string> ProgressiveBuild(string[] texts, string separator = "")
		{
			List<string> result = [];
			for (int i = 1; i <= texts.Length; i++)
				result.Add(string.Join(separator, texts[0..i]));
			return result;
		}
		public readonly SKRect Bounds
		{
			get
			{
				Font.MeasureText(Text, out SKRect rect, Style);
				rect.Left -= GlowOutlineWidth;
				rect.Top -= GlowOutlineWidth;
				rect.Right += GlowOutlineWidth;
				rect.Bottom += GlowOutlineWidth;
				return rect;
			}
		}
		public readonly float Width => Font.MeasureText(Text, out SKRect _, Style);
		private readonly float GlowOutlineWidth => Math.Max(GlowSigma * 3, OutlineStrokeWidth);
		public override readonly string ToString() => Text;
		[GeneratedRegex(@"\s+")]
		private static partial Regex WordSplitRegex();
		[GeneratedRegex(@"((\\\/)|[^\/])+")]
		private static partial Regex SlashSplitRegex();
	}
}
