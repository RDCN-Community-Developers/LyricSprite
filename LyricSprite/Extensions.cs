using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyricSprite
{
	public static class Extensions
	{
		public static void Save(this SKBitmap image, string path)
		{
			using FileStream stream = new FileInfo(path).OpenWrite();
			image.Encode(SKEncodedImageFormat.Png, 100).SaveTo(stream);
		}
	}
}
