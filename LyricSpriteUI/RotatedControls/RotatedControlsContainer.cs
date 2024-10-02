using LyricSpriteUI.RotatedControls;
using SkiaSharp;
using SkiaSharp.Views.Desktop;

namespace LyricSpriteUI
{
	/// <summary>
	/// 暂时弃用（
	/// 这玩意还没做完
	/// </summary>
	public partial class RotatedControlsContainer : SKControl
	{
		private SKSize _size;
		private SKPoint _point;
		private SKPoint _pivot;
		private float _angle;
		private SKColor borderColor;
		private float borderWidth;
		private bool border;
		private float borderRadius;
		private SKColor backgroundColor = DefaultBackColor.ToSKColor();
		private bool hovering = false;
		private bool active = false;
		private int hoveringIndex = -1;
		private readonly PrimaryRotatedControlCollection children;
		public PrimaryRotatedControlCollection Children => children;
		private ShadowInfo shadow;
		private float Radius
		{
			get => (float)Math.Sqrt(_size.Width * _size.Width + _size.Height * _size.Height);
		}
		public SKColor BackgroundColor
		{
			get => backgroundColor; set
			{
				backgroundColor = value;
				Invalidate();
			}
		}
		public SKColor BorderColor
		{
			get => borderColor; set
			{
				borderColor = value;
				Invalidate();
			}
		}
		public SKColor HoveringColor { get; set; }
		public SKColor ActiveColor { get; set; }
		public float BorderRadius
		{
			get => borderRadius; set
			{
				borderRadius = value;
				Invalidate();
			}
		}
		public bool Border
		{
			get => border; set
			{
				border = value;
				Invalidate();
			}
		}
		public float BorderWidth
		{
			get => borderWidth; set
			{
				borderWidth = value;
				Invalidate();
			}
		}
		public SKSize PCSize
		{
			get => _size;
			set
			{
				_size = value;
				Invalidate();
			}
		}
		public SKPoint PCLocation
		{
			get => _point;
			set
			{
				_point = value;
				Location = (SKPointI.Round(_point - _pivot - new SKPoint(Radius, Radius))).ToDrawingPoint();
				Invalidate();
			}
		}
		public SKPoint PCPivot
		{
			get => _pivot;
			set
			{
				_pivot = value;
				Location = (SKPointI.Round(_point - _pivot - new SKPoint(Radius, Radius))).ToDrawingPoint();
				Invalidate();
			}
		}
		public float PCAngle
		{
			get => _angle;
			set
			{
				_angle = value;
				Invalidate();
			}
		}
		public float PCWidth => _size.Width;
		public float PCHeight => _size.Height;
		public SKRect PCBounds => new(
			_point.X - _pivot.X,
			_point.Y - _pivot.Y,
			_point.X - _pivot.X + _size.Width,
			_point.Y - _pivot.Y + _size.Height
			);
		public SKPoint LeftTop => Rotate(new(PCBounds.Left, PCBounds.Top), _pivot, _angle);
		public SKPoint RightTop => Rotate(new(PCBounds.Right, PCBounds.Top), _pivot, _angle);
		public SKPoint LeftBottom => Rotate(new(PCBounds.Left, PCBounds.Bottom), _pivot, _angle);
		public SKPoint RightBottom => Rotate(new(PCBounds.Right, PCBounds.Bottom), _pivot, _angle);
		public ShadowInfo Shadow
		{
			get => shadow; set
			{
				shadow = value;
				Invalidate();
			}
		}
		protected override void OnMouseDown(MouseEventArgs e)
		{
			SKPoint p = e.Location.ToSKPoint();
			p = Translate(p);
			if (SKRect.Create(_size).Contains(p))
			{
				bool handled = false;
				int index = children.Count - 1;
				while (!handled && index >= 0)
				{
					if (children[index].TranslateContains(p))
					{
						children[index].RaiseMouseDown(new(e.Button, children[index].Translate(p), e.Delta));
						handled = true;
					}
					index--;
				}
				if (!handled)
					active = true;
				Invalidate();
			}
		}
		protected override void OnMouseUp(MouseEventArgs e)
		{
			SKPoint p = e.Location.ToSKPoint();
			p = Translate(p);
			bool handled = false;
			int index = children.Count - 1;
			while (!handled && index >= 0)
			{
				if (children[index].TranslateContains(p))
				{
					handled = true;
					break;
				}
				index--;
			}
			if (handled)
			{
				children[index].RaiseMouseUp(new(e.Button, children[index].Translate(p), e.Delta));
			}
			Invalidate();
			active = false;
		}
		protected override void OnMouseMove(MouseEventArgs e)
		{
			SKPoint p = e.Location.ToSKPoint();
			p = Translate(p);
			hovering = SKRect.Create(_size).Contains(p);
			active = active && hovering;
			if (hovering)
			{
				bool handled = false;
				int index = children.Count - 1;
				while (!handled && index >= 0)
				{
					if (children[index].TranslateContains(p))
					{
						handled = true;
						break;
					}
					index--;
				}
				if (handled)
				{
					if (hoveringIndex == index)
					{
						children[index].RaiseMouseMove(new(e.Button, children[index].Translate(p), e.Delta));
					}
					else
					{
						children[index].RaiseMouseEnter(e);
						if (hoveringIndex >= 0)
							children[hoveringIndex].RaiseMouseLeave(e);
					}
					hovering = false;
				}
				else
				{
					if (hoveringIndex >= 0)
						children[hoveringIndex].RaiseMouseLeave(e);
					index = -1;
				}
				hoveringIndex = index;
			}
			Invalidate();
		}
		protected override void OnMouseLeave(EventArgs e)
		{
			hovering = false;
			active = false;
			if (hoveringIndex >= 0)
				children[hoveringIndex].RaiseMouseLeave(e);
			Invalidate();
		}
		public bool Contains(SKPoint p)
		{
			return SKRect.Create(_size).Contains(p);
		}
		private SKPoint Translate(SKPoint p)
		{
			p.Offset(-Width / 2, -Width / 2);
			p = Rotate(p, _angle);
			p.Offset(_size.Width / 2, _size.Height / 2);
			return p;
		}
		protected override void OnLocationChanged(EventArgs e)
		{
			_point = Location.ToSKPoint() + new SKPoint(Radius, Radius);
			base.OnLocationChanged(e);
		}
		protected override void OnSizeChanged(EventArgs e)
		{
			Size = new Size((int)(Math.Max(Width, Shadow.Offset.X + Shadow.Sigma.X)), (int)(Math.Max(Width, Shadow.Offset.Y + Shadow.Sigma.Y)));
			_size = new SKSize(
				(Size.Width - Shadow.Offset.X - Shadow.Sigma.Y) * (float)Math.Sqrt(0.5),
				(Size.Width - Shadow.Offset.Y - Shadow.Sigma.Y) * (float)Math.Sqrt(0.5));
			_pivot = new SKPoint(Radius * (float)Math.Sqrt(0.5) / 2, Radius * (float)Math.Sqrt(0.5) / 2);
			base.OnSizeChanged(e);
		}
		private static SKPoint Rotate(SKPoint point, float angle)
		{
			return new(
				point.X * (float)Math.Cos(angle) +
				point.Y * (float)Math.Sin(angle),
				point.X * (float)-Math.Sin(angle) +
				point.Y * (float)Math.Cos(angle)
			);
		}
		private static SKPoint Rotate(SKPoint point, SKPoint pivot, float angle) => Rotate(point - pivot, angle) + pivot;
		public RotatedControlsContainer()
		{
			InitializeComponent();
			children = new(this);
		}
		protected override void OnPaintBackground(PaintEventArgs pevent)
		{
			pevent.Graphics.Clear(Parent?.BackColor ?? BackColor);
		}
		protected override void OnPaintSurface(SKPaintSurfaceEventArgs e)
		{
			SKCanvas canvas = e.Surface.Canvas;
			SKPoint shadowOffset = Shadow.Offset;
			shadowOffset = Rotate(shadowOffset, _angle);
			SKPaint backgroundPaint = new()
			{
				IsStroke = true,
				StrokeWidth = 3,
				Color = active ? ActiveColor : hovering ? HoveringColor : BackgroundColor,
				Style = SKPaintStyle.Fill,
				ImageFilter = SKImageFilter.CreateDropShadow(
					shadowOffset.X, shadowOffset.Y,
					Shadow.Sigma.X, Shadow.Sigma.Y,
					SKColors.Black.WithAlpha(127)),
				IsAntialias = true,
			};
			SKPaint borderPaint = new()
			{
				IsStroke = true,
				StrokeWidth = 3,
				Color = BorderColor,
				Style = SKPaintStyle.Stroke,
				IsAntialias = true,
			};
			SKRoundRect roure = new(SKRect.Create(_size), BorderRadius);
			canvas.Clear();
			canvas.Save();
			canvas.Translate(Width / 2, Width / 2);
			canvas.RotateRadians(_angle);
			canvas.Translate(-_size.Width / 2, -_size.Height / 2);
			canvas.DrawRoundRect(roure, backgroundPaint);
			canvas.Save();
			canvas.ClipRoundRect(roure, antialias: true);
			foreach (RotatedControl control in children)
			{
				control.OnPaintSurface(canvas, shadow);
			}
			canvas.Restore();

			if (Border)
				canvas.DrawRoundRect(roure, borderPaint);
			canvas.Restore();
		}
	}
}
