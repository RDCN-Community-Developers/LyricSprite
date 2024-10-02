using SkiaSharp;

namespace LyricSprite
{
	public struct GridCoordinate(int row, int column)
	{
		public int Row { get; set; } = row;
		public int Column { get; set; } = column;
		public readonly int Count => Row * Column;
		public static SKPoint operator *(GridCoordinate left, SKPoint right) => new(left.Column * right.X, left.Row * right.Y);
		public static SKPoint operator *(SKPoint left, GridCoordinate right) => right * left;
		public static SKPointI operator *(GridCoordinate left, SKPointI right) => new(left.Column * right.X, left.Row * right.Y);
		public static SKPointI operator *(SKPointI left, GridCoordinate right) => right * left;
		public static SKSize operator *(GridCoordinate left, SKSize right) => new(left.Column * right.Width, left.Row * right.Height);
		public static SKSize operator *(SKSize left, GridCoordinate right) => right * left;
		public static SKSizeI operator *(GridCoordinate left, SKSizeI right) => new(left.Column * right.Width, left.Row * right.Height);
		public static SKSizeI operator *(SKSizeI left, GridCoordinate right) => right * left;
	}
}
