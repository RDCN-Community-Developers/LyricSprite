using System.ComponentModel;

namespace LyricSprite
{
	public enum OutputDirection
	{
		[Description("横向排布")]
		Horizontal,
		[Description("纵向排布")]
		Vertical,
		[Description("紧凑横向排布")]
		PackedHorizontal,
		[Description("紧凑纵向排布")]
		PackedVertical,
	}
}
