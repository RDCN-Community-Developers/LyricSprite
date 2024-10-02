using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyricSprite
{
	internal class GrayMesh(int size):SKDrawable
	{
		private readonly int _size = size;
		protected override void OnDraw(SKCanvas canvas)
		{
			canvas.DrawRect(0, 0, _size, _size, new() { Color = SKColors.DarkGray });
			canvas.DrawRect(0, _size, _size, _size, new() { Color = SKColors.LightGray });
			canvas.DrawRect(_size, 0, _size, _size, new() { Color = SKColors.LightGray });
			canvas.DrawRect(_size, _size, _size, _size, new() { Color = SKColors.DarkGray });
		}
	}
}
