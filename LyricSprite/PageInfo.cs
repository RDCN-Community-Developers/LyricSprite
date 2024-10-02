using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyricSprite
{
	public struct PageInfo(GridCoordinate grid,SKSize card)
	{
		public GridCoordinate grid = grid;
		public SKSize cardSize = card;
		public SKBitmap image;
		public SKBitmap imageGlow;
		public SKBitmap imageOutline;
	}
}
