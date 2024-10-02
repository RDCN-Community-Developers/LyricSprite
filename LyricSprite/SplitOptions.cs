using System.ComponentModel;

namespace LyricSprite
{
	public enum SplitOptions
	{
		/// <summary>
		/// Each sentence is rendered into a single expression and deduplicated.
		/// </summary>
		[Description("完整")]
		WholeSentence,
		/// <summary>
		/// Each char is rendered into a single expression and deduplicated.
		/// </summary>
		[Description("以字符分割")]
		SplitByChar,
		/// <summary>
		/// Each word (separated by a space) is rendered into a single expression and deduplicated.
		/// </summary>
		[Description("以空格分割")]
		SplitBySpace,
		/// <summary>
		/// Each part (separated by a slash) is rendered into a single expression and deduplicated.
		/// </summary>
		[Description("以斜线分割")]
		SplitBySlash,
		/// <summary>
		/// Each sentence is rendered into multiple expressions with one more char than the previous one and deduplicated.
		/// </summary>
		[Description("逐字符递进")]
		ProgressiveSplitByChar,
		/// <summary>
		/// Each sentence is rendered into multiple expressions with one more word (separated by a space) than the previous one and deduplicated.
		/// </summary>
		[Description("逐空格递进")]
		ProgressiveSplitBySpace,
		/// <summary>
		/// Each sentence is rendered into multiple expressions with one more part (separated by a slash) than the previous one and deduplicated.
		/// </summary>
		[Description("逐斜线递进")]
		ProgressiveSplitBySlash,
	}
}