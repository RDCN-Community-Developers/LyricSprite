using SkiaSharp;

namespace LyricSprite
{
	public class SpriteSheetCanvas(
		OutputDirection direction,
		int maxWidth = int.MaxValue,
		int maxHeight = int.MaxValue)
	{
		private OutputDirection direction = direction;
		private readonly int width = maxWidth;
		private readonly int height = maxHeight;

		private readonly List<Lyric> lyricsToDraw = [];
		private SKRectI currentMaxTextRect = new();
		private readonly SpriteSheetBook book = new();
		public SKRectI Margin { get; set; } = new();
		public SpriteSheetCanvas(OutputDirection direction, SKSizeI maxSize) : this(direction, maxSize.Width, maxSize.Height) { }
		public SpriteSheetCanvas(OutputDirection direction) : this(direction, int.MaxValue, int.MaxValue) { }
		public void DrawLyrics(IEnumerable<Lyric> lyrics)
		{
			foreach(Lyric lyric in lyrics)
				DrawLyric(lyric);
		}
		public void DrawLyric(Lyric lyric)
		{
			Lyric source = lyric;
			foreach (string line in lyric.Split)
			{
				Lyric copy = source;
				copy.Text = line;
				if (!book.pageNumbers.ContainsKey(line) && !lyricsToDraw.Any(i => i.Text == line))
					DrawSingleLyric(copy);
			}
		}
		public void DrawSingleLyric(Lyric lyric)
		{
			SKRectI measureRect = SKRectI.Ceiling(lyric.Bounds);
			bool lessHold = CanHold(currentMaxTextRect.Size, out GridCoordinate imageSize);
			bool moreHold = CanHold(SKRectI.Union(currentMaxTextRect, measureRect).Size, out var _, true);
			if (!lessHold)
				throw new NotSupportedException($"Image size too big, at \"{lyric}\"");
			else if (!moreHold)
			{
				Flush(imageSize, currentMaxTextRect);
				currentMaxTextRect = new();
			}
			currentMaxTextRect.Union(measureRect);
			lyricsToDraw.Add(lyric);
		}
		private bool CanHold(SKSizeI maxTextSize, out GridCoordinate minCardGrid, bool more = false)
		{
			GridCoordinate maxStruct = RowColumnSize(AddMargin(maxTextSize, Margin));
			bool can = lyricsToDraw.Count + (more ? 1 : 0) <= maxStruct.Count;
			switch (direction)
			{
				case OutputDirection.Horizontal:
					minCardGrid = new(
						Math.Min(lyricsToDraw.Count, maxStruct.Column),
						(int)Math.Ceiling(lyricsToDraw.Count / (float)maxStruct.Column));
					break;
				case OutputDirection.Vertical:
					minCardGrid = new(
						(int)Math.Ceiling(lyricsToDraw.Count / (float)maxStruct.Row),
						Math.Min(lyricsToDraw.Count, maxStruct.Row));
					break;
				case OutputDirection.PackedHorizontal or OutputDirection.PackedVertical:
					int r = 1;
					int c = 1;
					do
					{
						if (r * maxTextSize.Width < c * maxTextSize.Height) r += 1;
						else c += 1;
					} while (r * c < maxStruct.Count);
					minCardGrid = new(r, c);
					break;
				default:
					minCardGrid = new();
					break;
			}
			return can;
		}
		GridCoordinate RowColumnSize(SKSize maxTextSize)
		{
			int maxRow = (int)Math.Floor(width / maxTextSize.Width);
			int maxCol = (int)Math.Floor(height / maxTextSize.Height);
			return new(maxRow, maxCol);
		}
		private void Flush(GridCoordinate imageStruct, SKRectI textSize)
		{
			int drawIndex = 0;
			SKSizeI cardSize = AddMargin(textSize.Size, Margin);
			SKBitmap bitmap = new(imageStruct.Column * cardSize.Width, imageStruct.Row * cardSize.Height);
			SKBitmap bitmapGlow = new(imageStruct.Column * cardSize.Width, imageStruct.Row * cardSize.Height);
			SKBitmap bitmapOutline = new(imageStruct.Column * cardSize.Width, imageStruct.Row * cardSize.Height);
			SKCanvas canvas = new(bitmap);
			SKCanvas canvasGlow = new(bitmapGlow);
			SKCanvas canvasOutline = new(bitmapOutline);
			do
			{
				SKRect bound = textSize;
				int baseline = -textSize.Top;
				bound.Offset(Margin.Left, Margin.Top);
				bound.Offset(0, -textSize.Top);
				bound.Offset(direction switch
				{
					OutputDirection.Horizontal or OutputDirection.PackedHorizontal => new(
						(drawIndex % imageStruct.Column) * (cardSize.Width),
						(drawIndex / imageStruct.Column) * (cardSize.Height)),
					OutputDirection.Vertical or OutputDirection.PackedVertical => new(
						(drawIndex / imageStruct.Row) * (cardSize.Width),
						(drawIndex % imageStruct.Row) * (cardSize.Height)),
					_ => throw new NotImplementedException(),
				});
#if DEBUG
				canvas.DrawRect(bound, new() { Style = SKPaintStyle.Stroke, Color = SKColors.Red });
				canvasGlow.DrawRect(bound, new() { Style = SKPaintStyle.Stroke, Color = SKColors.Red });
				canvasOutline.DrawRect(bound, new() { Style = SKPaintStyle.Stroke, Color = SKColors.Red });
#endif
				lyricsToDraw[0].Draw(canvas, bound, baseline);
				lyricsToDraw[0].DrawGlow(canvasGlow, bound, baseline);
				lyricsToDraw[0].DrawOutline(canvasOutline, bound, baseline);
				book.pageNumbers[lyricsToDraw[0].Text] = new(book.PageCount - 1, drawIndex);
				lyricsToDraw.RemoveAt(0);
				drawIndex++;
			} while (lyricsToDraw.Count > 0);
			book.pageInfos.Add(new(new(imageStruct.Row, imageStruct.Column), cardSize)
			{
				image = bitmap,
				imageGlow = bitmapGlow,
				imageOutline = bitmapOutline,
			});
			book.PageCount++;
		}
		public SpriteSheetBook Build()
		{
			bool canHold = CanHold(currentMaxTextRect.Size, out GridCoordinate s);
			if (!canHold)
				throw new NotSupportedException($"Image size too big, at \"{lyricsToDraw.First()}\"");
			Flush(s, currentMaxTextRect);
			currentMaxTextRect = new();
			return book;
		}
		private static SKSizeI AddMargin(SKSizeI size, SKRectI margin) => new(
				size.Width + margin.Left + margin.Right,
				size.Height + margin.Top + margin.Bottom);
	}
}
