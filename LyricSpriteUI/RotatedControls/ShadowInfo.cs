using SkiaSharp;

namespace LyricSpriteUI.RotatedControls
{
	public struct ShadowInfo
	{
		public SKPoint Offset { get; init; }
		public SKPoint Sigma { get; init; }
		public float Angle { get; set; }
		public ShadowInfo OffsetAngle(float angle)
		{
			return new()
			{
				Offset = Offset,
				Sigma = Sigma,
				Angle = Angle + angle,
			};
		}
		public ShadowInfo MultipyDepth(float depth)
		{
			return new()
			{
				Offset = new(Offset.X * depth, Offset.Y * depth),
				Sigma = new(Sigma.X * depth, Sigma.Y * depth),
				Angle = Angle,
			};
		}
	}
}
