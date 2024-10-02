using LyricSprite;
using SkiaSharp;
using SkiaSharp.Views.Desktop;

namespace LyricSpriteUI
{
	public partial class LyricViewer : SKControl
	{
		private Lyric _lyric;
		public int GridSize { get; set; } = 16;
		public float ShadowRadius { get; set; } = 10;
		public SKColor CardColor { get; set; } = SKColors.White;
		public SKColor WarningCardColor { get; set; } = SKColors.Red;
		public SKRect CardPosition { get; set; } = new();
		private bool dragging = false;
		private int hoveringCorner = -1;
		private SKPoint draggingPosition = new();
		private bool showLyric = true;
		private bool showLyricGlow = false;
		private bool showLyricOutline = false;
		public bool ShowLyric
		{
			get => showLyric; set
			{
				showLyric = value;
				Invalidate();
			}
		}
		public bool ShowLyricGlow
		{
			get => showLyricGlow; set
			{
				showLyricGlow = value;
				Invalidate();
			}
		}
		public bool ShowLyricOutline
		{
			get => showLyricOutline; set
			{
				showLyricOutline = value;
				Invalidate();
			}
		}
		public Lyric Lyric
		{
			get
			{
				return _lyric;
			}
			set
			{
				_lyric = value;
				Invalidate();
			}
		}
		public LyricViewer()
		{
			InitializeComponent();
			_lyric = new(Text);
			ResetPosition();
		}
		public void ResetPosition()
		{
			SKRect r = _lyric.Bounds;
			r.Offset(
				-_lyric.Bounds.Location.X + ShadowRadius,
				-_lyric.Bounds.Location.Y + ShadowRadius);
			CardPosition = r;
			Invalidate();
		}
		protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
		{
			SKRect card = CardPosition;
			SKCanvas canvas = e.Surface.Canvas;
			UITextRender.RendBackground(canvas, Size.ToSKSize(), GridSize);
			UITextRender.RendCard(canvas, card, ShadowRadius, (_lyric.CanDraw(CardPosition) ? CardColor : WarningCardColor).WithAlpha(127));
			UITextRender.RendLyricBounds(canvas, _lyric, card);
			if (showLyricOutline)
				UITextRender.RendLyricOutline(canvas, _lyric, card);
			if (showLyricGlow)
				UITextRender.RendLyricGlow(canvas, _lyric, card);
			if (showLyric)
				UITextRender.RendLyric(canvas, _lyric, card);
//#if DEBUG
//			SKPoint p = new(200, 200);
//			canvas.DrawText(_lyric.Text, p, _lyric.Align, _lyric.Font, _lyric.Style);
//			float w = _lyric.Font.MeasureText(_lyric.Text, out SKRect bt, _lyric.Style);
//			SKRect b = bt;
//			b.Offset(p);
//			SKPaint bp = new() { Color = SKColors.Red, IsStroke = true, StrokeWidth = 1 };
//			SKPaint lp = new() { Color = SKColors.Green, IsStroke = true, StrokeWidth = 1 };
//			canvas.DrawRect(b, bp);
//			canvas.DrawLine(b.Left, b.Top - _lyric.Bounds.Top, b.Right, b.Top - _lyric.Bounds.Top, lp);
//			canvas.DrawLine(b.Left - _lyric.Bounds.Left, b.Top, b.Left - _lyric.Bounds.Left, b.Bottom, lp);
//			canvas.DrawLine(b.Right - w,b.Bottom+1,b.Right,b.Bottom+1, lp);
//#endif

		}
		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				draggingPosition = e.Location.ToSKPoint();
				dragging = true;
			}
		}
		protected override void OnMouseMove(MouseEventArgs e)
		{
			SKPoint p = e.Location.ToSKPoint();
			SKPoint d = p - draggingPosition;
			SKRect c = CardPosition;
			float s = 5;
			if ((!dragging))
				if (new SKRect(c.Left - s, c.Top - 5, c.Left + 5, c.Top + 5).Contains(p))
					hoveringCorner = 0;
				else if (new SKRect(c.Right - s, c.Top - s, c.Right + s, c.Top + s).Contains(p))
					hoveringCorner = 1;
				else if (new SKRect(c.Left - s, c.Bottom - s, c.Left + s, c.Bottom + s).Contains(p))
					hoveringCorner = 2;
				else if (new SKRect(c.Right - s, c.Bottom - s, c.Right + s, c.Bottom + s).Contains(p))
					hoveringCorner = 3;
				else if (new SKRect(c.Left - s, c.Top - s, c.Left + s, c.Bottom + s).Contains(p))
					hoveringCorner = 4;
				else if (new SKRect(c.Left - s, c.Top - s, c.Right + s, c.Top + s).Contains(p))
					hoveringCorner = 5;
				else if (new SKRect(c.Right - s, c.Top - s, c.Right + s, c.Bottom + s).Contains(p))
					hoveringCorner = 6;
				else if (new SKRect(c.Left - s, c.Bottom - s, c.Right + s, c.Bottom + s).Contains(p))
					hoveringCorner = 7;
				else if (c.Contains(p))
					hoveringCorner = 8;
				else
					hoveringCorner = -1;
			switch (hoveringCorner)
			{
				case 0:
					Cursor = Cursors.SizeNWSE;
					if (dragging)
					{
						c.Left += d.X;
						c.Top += d.Y;
						draggingPosition = e.Location.ToSKPoint();
					}
					break;
				case 1:
					Cursor = Cursors.SizeNESW;
					if (dragging)
					{
						c.Right += d.X;
						c.Top += d.Y;
						draggingPosition = e.Location.ToSKPoint();
					}
					break;
				case 2:
					Cursor = Cursors.SizeNESW;
					if (dragging)
					{
						c.Left += d.X;
						c.Bottom += d.Y;
						draggingPosition = e.Location.ToSKPoint();
					}
					break;
				case 3:
					Cursor = Cursors.SizeNWSE;
					if (dragging)
					{
						c.Right += d.X;
						c.Bottom += d.Y;
						draggingPosition = e.Location.ToSKPoint();
					}
					break;
				case 4:
					Cursor = Cursors.SizeWE;
					if (dragging)
					{
						c.Left += d.X;
						draggingPosition = e.Location.ToSKPoint();
					}
					break;
				case 5:
					Cursor = Cursors.SizeNS;
					if (dragging)
					{
						c.Top += d.Y;
						draggingPosition = e.Location.ToSKPoint();
					}
					break;
				case 6:
					Cursor = Cursors.SizeWE;
					if (dragging)
					{
						c.Right += d.X;
						draggingPosition = e.Location.ToSKPoint();
					}
					break;
				case 7:
					Cursor = Cursors.SizeNS;
					if (dragging)
					{
						c.Bottom += d.Y;
						draggingPosition = e.Location.ToSKPoint();
					}
					break;
				case 8:
					Cursor = Cursors.SizeAll;
					if (dragging)
					{
						c.Left += d.X;
						c.Top += d.Y;
						c.Right += d.X;
						c.Bottom += d.Y;
						draggingPosition = e.Location.ToSKPoint();
					}
					break;
				default:
					Cursor = Cursors.Default;
					break;
			}
			CardPosition = c;
			Invalidate();
		}
		protected override void OnMouseUp(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				dragging = false;
			}
		}
	}
}
