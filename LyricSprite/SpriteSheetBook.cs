using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyricSprite
{
	public class SpriteSheetBook
	{
		public int PageCount = 0;
		public readonly List<PageInfo> pageInfos = [];
		public readonly Dictionary<string, PageIndex> pageNumbers = [];
	}
}
