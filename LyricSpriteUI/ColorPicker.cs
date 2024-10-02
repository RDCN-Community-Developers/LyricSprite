using LyricSprite;
using SkiaSharp;
using SkiaSharp.Views.Desktop;

namespace LyricSpriteUI
{
	public partial class ColorPicker : SKControl
	{
		private readonly ColorPickerForm c;
		protected override Size DefaultSize => new(32, 32);
		private readonly int pickerWidth = 150;
		private readonly int scrollBarWidth = 30;
		private readonly float radius = 5;
		public event EventHandler ColorChanged;
		public SKColor Color
		{
			get => c.c.Color;
			set => c.c.Color = value;
		}
		public ColorPicker()
		{
			InitializeComponent();
			c = new(this);
			ColorChanged += OnColorChanged;
		}
		protected override void OnMouseDown(MouseEventArgs e)
		{
			c.Show();
		}
		protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
		{
			SKCanvas canvas = e.Surface.Canvas;
			UITextRender.RendBackground(canvas, Size.ToSKSize());
			canvas.DrawColor(Color, SKBlendMode.SrcOver);
		}
		protected virtual void OnColorChanged(object? sender, EventArgs e) { }
		private class ColorPickerForm : Form
		{
			private readonly ColorPicker p;
			public readonly ColorPickerPanel c;
			public ColorPickerForm(ColorPicker parent)
			{
				FormBorderStyle = FormBorderStyle.None;
				ControlBox = false;
				TopLevel = true;
				this.p = parent;
				Size = new(this.p.pickerWidth + this.p.scrollBarWidth, this.p.pickerWidth + this.p.scrollBarWidth);
				c = new(this);
				this.Controls.Add(c);
			}
			protected override void OnLostFocus(EventArgs e) => Hide();
			protected override void OnVisibleChanged(EventArgs e) => Location = p.PointToScreen(p.Location);
			public class ColorPickerPanel : SKControl
			{
				float x = 0;  // 100
				float y = 0;  // 100
				float h = 0;  // 360
				byte a = 255;
				private readonly ColorPickerForm p;
				public SKColor Color
				{
					get => SKColor.FromHsv(h, Math.Clamp(x, 0, 100), Math.Clamp(100 - y, 0, 100), a);
					set
					{
						byte a = value.Alpha;
						value.ToHsv(out float h, out float s, out float v);
						this.h = h;
						this.x = s;
						this.y = 100f - v;
						this.a = a;
					}
				}
				private int mdown = -1;
				public ColorPickerPanel(ColorPickerForm parent)
				{
					this.p = parent;
					Size = parent.Size;
				}
				protected override void OnLostFocus(EventArgs e) => p.Hide();
				protected override void OnMouseDown(MouseEventArgs e)
				{
					if (e.Button == MouseButtons.Left)
					{
						SKPoint p = e.Location.ToSKPoint();
						if (new SKRect(0, 0, this.p.p.pickerWidth, this.p.p.pickerWidth).Contains(p))
							mdown = 0;
						else if (new SKRect(this.p.p.pickerWidth + 1, 0, this.p.p.pickerWidth + this.p.p.scrollBarWidth, this.p.p.pickerWidth).Contains(p))
							mdown = 1;
						else if (new SKRect(0, this.p.p.pickerWidth + 1, this.p.p.pickerWidth, this.p.p.pickerWidth + this.p.p.scrollBarWidth).Contains(p))
							mdown = 2;
						else
							mdown = -1;
						DraggingColor(e.Location.ToSKPoint());
					}
				}
				protected override void OnMouseMove(MouseEventArgs e)
				{
					DraggingColor(e.Location.ToSKPoint());
				}
				protected override void OnMouseUp(MouseEventArgs e)
				{
					if (e.Button == MouseButtons.Left)
					{
						DraggingColor(e.Location.ToSKPoint());
						mdown = -1;
						p.p.Invalidate();
					}
				}
				private void DraggingColor(SKPoint p)
				{
					switch (mdown)
					{
						case 0:
							x = Math.Clamp(p.X * 100f / this.p.p.pickerWidth, 0, 100);
							y = Math.Clamp(p.Y * 100f / this.p.p.pickerWidth, 0, 100);
							break;
						case 1:
							h = Math.Clamp(p.Y * 360 / this.p.p.pickerWidth, 0, 360);
							break;
						case 2:
							a = (byte)Math.Clamp((p.X * 255 / this.p.p.pickerWidth), 0, 255);
							break;
						default:
							break;
					}
					if (mdown >= 0)
					{
						Invalidate();
						this.p.p.ColorChanged.Invoke(this, new());
					}
				}
				protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
				{
					SKPaint ps = new();
					SKCanvas canvas = e.Surface.Canvas;
					UITextRender.RendBackground(canvas, Size.ToSKSize());
					for (int i = 0; i <= this.p.p.pickerWidth; i++)
						for (int j = 0; j <= this.p.p.pickerWidth; j++)
						{
							ps.Color = SKColor.FromHsv(
								h,
								i * 100f / this.p.p.pickerWidth,
								100f - j * 100f / this.p.p.pickerWidth,
								a
								);
							canvas.DrawPoint(new(i, j), ps);
						}
					for (int i = 0; i <= this.p.p.pickerWidth; i++)
					{
						ps.Color = SKColor.FromHsv(
									i * 360 / this.p.p.pickerWidth,
									x * 100f / this.p.p.pickerWidth,
									100f - y * 100f / this.p.p.pickerWidth,
									a);
						canvas.DrawLine(
							this.p.p.pickerWidth + 1,
							i,
							this.p.p.pickerWidth + this.p.p.scrollBarWidth,
							i,
							ps);
						ps.Color = Color.WithAlpha((byte)(i * 255 / this.p.p.pickerWidth));
						canvas.DrawLine(
							i,
							this.p.p.pickerWidth + 1,
							i,
							this.p.p.pickerWidth + this.p.p.scrollBarWidth,
							ps);
					}
					ps.Color = Color;
					canvas.DrawRect(
						this.p.p.pickerWidth + 1,
						this.p.p.pickerWidth + 1,
						this.p.p.pickerWidth + this.p.p.scrollBarWidth,
						this.p.p.pickerWidth + this.p.p.scrollBarWidth,
						ps);
					ps.ImageFilter = SKImageFilter.CreateDropShadow(0, 3, this.p.p.radius, this.p.p.radius, SKColors.Black);
					ps.IsAntialias = true;
					canvas.DrawCircle(x * this.p.p.pickerWidth / 100f, y * this.p.p.pickerWidth / 100f, this.p.p.radius, ps);
					canvas.DrawRoundRect(
						new(new(
							this.p.p.pickerWidth + 1 - this.p.p.radius,
							h / 360 * this.p.p.pickerWidth - this.p.p.radius,
							this.p.p.pickerWidth + this.p.p.scrollBarWidth + this.p.p.radius,
							h / 360 * this.p.p.pickerWidth + this.p.p.radius
							), this.p.p.radius),
							ps);
					canvas.DrawRoundRect(
						new(new(
							(a / 255f) * this.p.p.pickerWidth - this.p.p.radius,
							this.p.p.pickerWidth + 1 - this.p.p.radius,
							(a / 255f) * this.p.p.pickerWidth + this.p.p.radius,
							this.p.p.pickerWidth + this.p.p.scrollBarWidth + this.p.p.radius
							), this.p.p.radius),
							ps);
				}
			}
		}
	}
}
