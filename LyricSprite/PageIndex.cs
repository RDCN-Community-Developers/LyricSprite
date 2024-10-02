using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyricSprite
{
	public struct PageIndex(int page,int index)
	{
		public int Page = page;
		public int Index = index;
	}
}
