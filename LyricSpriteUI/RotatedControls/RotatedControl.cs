using SkiaSharp;
using System.Runtime.CompilerServices;

namespace LyricSpriteUI.RotatedControls
{
	public class RotatedControl
	{
		protected class Animator
		{

		}
		private float _angle;
		private SKPoint _pivot;
		private SKPoint _point;
		private SKSize _size;
		private bool active = false;
		private SKColor backgroundColor = SKColors.White;
		private bool border;
		private SKColor borderColor;
		private float borderRadius;
		private float borderWidth;
		private bool hovering = false;
		private int hoveringIndex = -1;
		private float shadowDistance;
		private float depth = 1;
		public SKColor ActiveColor { get; set; }
		public float Angle
		{
			get => _angle;
			set
			{
				_angle = value;
				Invalidate();
			}
		}
		public SKColor BackgroundColor
		{
			get => backgroundColor; set
			{
				backgroundColor = value;
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
		public SKColor BorderColor
		{
			get => borderColor; set
			{
				borderColor = value;
				Invalidate();
			}
		}
		public float BorderRadius
		{
			get => borderRadius; set
			{
				borderRadius = value;
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
		public float Height
		{
			get
			{
				return _size.Height;
			}
			set
			{
				_size.Height = value;
				Invalidate();
			}
		}
		public float ShadowDistance
		{
			get => shadowDistance; set
			{
				shadowDistance = value;
				Invalidate();
			}
		}
		public SKColor HoveringColor { get; set; }
		public SKPoint LeftBottom => Rotate(new(PCBounds.Left, PCBounds.Bottom), _pivot, _angle);
		public SKPoint LeftTop => Rotate(new(PCBounds.Left, PCBounds.Top), _pivot, _angle);
		public SKPoint Location
		{
			get => _point;
			set
			{
				_point = value;
				Invalidate();
			}
		}
		public RotatedControl? Parent { get; internal set; }
		public RotatedControlCollection Children { get; internal set; }
		public SKRect PCBounds => new(
			_point.X - _pivot.X,
			_point.Y - _pivot.Y,
			_point.X - _pivot.X + _size.Width,
			_point.Y - _pivot.Y + _size.Height
			);
		public SKPoint Pivot
		{
			get => _pivot;
			set
			{
				_pivot = value;
				Invalidate();
			}
		}
		public SKPoint RightBottom => Rotate(new(PCBounds.Right, PCBounds.Bottom), _pivot, _angle);
		public SKPoint RightTop => Rotate(new(PCBounds.Right, PCBounds.Top), _pivot, _angle);
		public SKSize Size
		{
			get => _size;
			set
			{
				_size = value;
				Invalidate();
			}
		}
		public float Width
		{
			get
			{
				return _size.Width;
			}
			set
			{
				_size.Width = value;
				Invalidate();
			}
		}
		private float Radius
		{
			get => (float)Math.Sqrt(_size.Width * _size.Width + _size.Height * _size.Height);
		}
		public virtual SKPath Path
		{
			get
			{
				SKPath path = new();
				SKRoundRect roure = new(SKRect.Create(_size), BorderRadius);
				path.AddRoundRect(roure);
				path.Offset(-_pivot.X, -_pivot.Y);
				path.Transform(
					new SKMatrix(
						(float)Math.Cos(_angle), (float)-Math.Sin(_angle), 0,
						(float)Math.Sin(_angle), (float)Math.Cos(_angle), 0,
						0, 0, 1
						)
					);
				path.Offset(_point.X, _point.Y);
				return path;
			}
		}
		public float Depth
		{
			get => depth; set
			{
				depth = value;
				Invalidate();
			}
		}
		public int AnimationTime;

		public event EventHandler<RotatedMouseEventArgs> MouseDown;
		public event EventHandler MouseEnter;
		public event EventHandler MouseLeave;
		public event EventHandler<RotatedMouseEventArgs> MouseMove;
		public event EventHandler<RotatedMouseEventArgs> MouseUp;

		public RotatedControl()
		{
			MouseDown += OnMouseDown;
			MouseUp += OnMouseUp;
			MouseEnter += OnMouseEnter;
			MouseLeave += OnMouseLeave;
			MouseMove += OnMouseMove;
			Children = new(this);
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
		public bool Contains(SKPoint p)
		{
			return SKRect.Create(_size).Contains(p);
		}
		public bool TranslateContains(SKPoint p)
		{
			return Contains(Translate(p));
		}
		public SKPoint Translate(SKPoint p)
		{
			p.Offset(-_point.X, -_point.Y);
			p = Rotate(p, _angle);
			p.Offset(_pivot.X, _pivot.Y);
			return p;
		}
		public async void Invalidate([CallerMemberName] string name = "")
		{
			await Task.Run(() => Animate(name, []));
		}
		private static IEnumerable<SKPoint> Ease(SKPoint from, SKPoint to, int time)
		{
			for (int i = 0; i < time; i++)
				yield return new(
				(float)LyricSpriteUI.Ease.Calculate(LyricSpriteUI.Ease.EaseType.OutQuad, i / time, from.X, to.X),
				(float)LyricSpriteUI.Ease.Calculate(LyricSpriteUI.Ease.EaseType.OutQuad, i / time, from.Y, to.Y)
				);
		}
		internal void RaiseMouseDown(RotatedMouseEventArgs e) => MouseDown?.Invoke(this, e);
		internal void RaiseMouseUp(RotatedMouseEventArgs e) => MouseUp?.Invoke(this, e);
		internal void RaiseMouseEnter(EventArgs e) => MouseEnter?.Invoke(this, e);
		internal void RaiseMouseLeave(EventArgs e) => MouseLeave?.Invoke(this, e);
		internal void RaiseMouseMove(RotatedMouseEventArgs e) => MouseMove?.Invoke(this, e);
		protected virtual void Animate(string propertyName, object[] values)
		{
			foreach (var item in values)
			{
				this.GetType().GetProperty(propertyName)?.SetValue(this, item);
				Task.Delay(10);
			}
		}
		protected virtual void OnMouseDown(object? sender, RotatedMouseEventArgs e)
		{
			SKPoint p = e.Location;
			if (SKRect.Create(_size).Contains(p))
			{
				bool handled = false;
				int index = 0;
				while (!handled && index < Children.Count)
				{
					if (Children[index].TranslateContains(p))
					{
						Children[index].RaiseMouseDown(new(e.Button, Children[index].Translate(p), e.Delta));
						handled = true;
					}
					index++;
				}
				if (!handled)
					active = true;
				Invalidate();
			}
		}
		protected virtual void OnMouseEnter(object? sender, EventArgs e)
		{
			hovering = true;
			active = false;
			Invalidate();
		}
		protected virtual void OnMouseLeave(object? sender, EventArgs e)
		{
			hovering = false;
			active = false;
			foreach (RotatedControl control in Children)
				control.RaiseMouseLeave(e);
			Invalidate();
		}
		protected virtual void OnMouseMove(object? sender, RotatedMouseEventArgs e)
		{
			SKPoint p = e.Location;
			hovering = SKRect.Create(_size).Contains(p);
			active = active && hovering;
			if (hovering)
			{
				bool handled = false;
				int index = 0;
				while (!handled && index < Children.Count)
				{
					if (Children[index].TranslateContains(p))
					{
						handled = true;
						break;
					}
					index++;
				}
				if (handled)
				{
					if (hoveringIndex == index)
					{
						Children[index].RaiseMouseMove(new(e.Button, Children[index].Translate(p), e.Delta));
					}
					else
					{
						Children[index].RaiseMouseEnter(e);
						if (hoveringIndex >= 0)
							Children[hoveringIndex].RaiseMouseLeave(e);
					}
					hovering = false;
				}
				else
				{
					if (hoveringIndex >= 0)
						Children[hoveringIndex].RaiseMouseLeave(e);
					index = -1;
				}
				hoveringIndex = index;
			}
			Invalidate();
		}
		protected virtual void OnMouseUp(object? sender, RotatedMouseEventArgs e)
		{
			SKPoint p = e.Location;
			bool handled = false;
			int index = 0;
			while (!handled && index < Children.Count)
			{
				if (Children[index].TranslateContains(p))
				{
					Children[index].RaiseMouseUp(new(e.Button, Children[index].Translate(p), e.Delta));
					handled = true;
				}
				index++;
			}
			Invalidate();
			active = false;
		}
		protected virtual void OnPaintSurfaceOthers(SKCanvas e) { }
		internal protected virtual void OnPaintSurface(SKCanvas e, ShadowInfo shadow)
		{
			SKCanvas canvas = e;
			SKPoint shadowOffset = shadow.Offset;
			shadowOffset = Rotate(shadowOffset, _angle + shadow.Angle);
			SKPaint backgroundPaint = new()
			{
				IsStroke = true,
				StrokeWidth = 3,
				Color = active ? ActiveColor : hovering ? HoveringColor : backgroundColor,
				Style = SKPaintStyle.Fill,
				ImageFilter = SKImageFilter.CreateDropShadow(
					shadowOffset.X, shadowOffset.Y,
					shadow.Sigma.X, shadow.Sigma.Y,
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
			SKRoundRect roure = new(SKRect.Create(_size), borderRadius);
			canvas.Save();
			canvas.Translate(_point.X, _point.Y);
			canvas.RotateRadians(_angle);
			canvas.Translate(-_pivot.X, -_pivot.Y);
			canvas.DrawRoundRect(roure, backgroundPaint);
			canvas.Save();

			canvas.ClipRoundRect(roure, antialias: true);
			OnPaintSurfaceOthers(canvas);

			foreach (RotatedControl control in Children.Reverse())
				control.OnPaintSurface(canvas, shadow.OffsetAngle(_angle));
			canvas.Restore();

			if (Border)
				canvas.DrawRoundRect(roure, borderPaint);
			canvas.Restore();
		}
	}
}