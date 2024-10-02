using SkiaSharp;

namespace LyricSprite
{
	public static class UITextRender
	{
		public static void RendLyric(SKCanvas canvas, Lyric lyric, SKRect rect) => lyric.Draw(canvas, rect);
		public static void RendLyricGlow(SKCanvas canvas, Lyric lyric, SKRect rect) => lyric.DrawGlow(canvas, rect);
		public static void RendLyricOutline(SKCanvas canvas, Lyric lyric, SKRect rect) => lyric.DrawOutline(canvas, rect);
		public static void RendLyricBounds(SKCanvas canvas, Lyric lyric, SKRect rect) => lyric.DrawBounds(canvas, rect);
		public static void RendCard(SKCanvas canvas, SKRect rect, float shadowRadius) => RendCard(canvas, rect, shadowRadius, SKColors.White.WithAlpha(127));
		public static void RendCard(SKCanvas canvas, SKRect rect, float shadowRadius, SKColor cardColor) =>
			canvas.DrawRect(rect, new()
			{
				ImageFilter = SKImageFilter.CreateDropShadow(0, shadowRadius / 2, shadowRadius, shadowRadius, SKColors.Black.WithAlpha(191)),
				Color = cardColor,
			});
		public static void RendBackground(SKCanvas canvas, SKSize canvasSize, int meshSize = 16)
		{
			GrayMesh mesh = new(meshSize);
			for (int x = 0; x < canvasSize.Width; x += meshSize * 2)
				for (int y = 0; y < canvasSize.Height; y += meshSize * 2)
					canvas.DrawDrawable(mesh, x, y);
		}
	}
}