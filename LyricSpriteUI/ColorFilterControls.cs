using SkiaSharp;
using System.ComponentModel;
using System.Runtime.Serialization;
namespace LyricSpriteUI
{
	public enum ColorFilterTypes
	{
		[Description("无")]
		None = 0,
		[Description("颜色混合")]
		BlendMode,
		[Description("亮度")]
		Lighting,
		[Description("对比度")]
		HighContrast,
		[Description("黑白")]
		LumarColor,
	}
	public class ColorFilterContainer(ColorFilterTypes type, string name = "")
	{
		public ColorFilterTypes Type { get; } = type;
		public string Name { get; set; } = name;
		public SKColorFilter Value { get; set; }		= type switch
		{
			ColorFilterTypes.BlendMode => SKColorFilter.CreateBlendMode(
				SKColors.White,
				SKBlendMode.Src
				),
			ColorFilterTypes.Lighting => SKColorFilter.CreateLighting(
				SKColors.White, 
				SKColors.White),
			ColorFilterTypes.HighContrast => SKColorFilter.CreateHighContrast(new SKHighContrastConfig()
			{
				Contrast = 0f,
				Grayscale = false,
				InvertStyle = SKHighContrastConfigInvertStyle.NoInvert
			}),
			ColorFilterTypes.LumarColor => SKColorFilter.CreateLumaColor(),
			_ => throw new NotSupportedException(),
		};
		public override string ToString() => Name;
	}
	partial class Form1
	{
		private SKColorFilter? GetColorFilter() => colorFilterTypeCombo.GetEnum<ColorFilterTypes>() switch
		{
			ColorFilterTypes.BlendMode => SKColorFilter.CreateBlendMode(
				colorFilterBlendModeColorPicker.Color,
				colorFilterBlendModeCombo.GetEnum<SKBlendMode>()
				),
			ColorFilterTypes.Lighting => SKColorFilter.CreateLighting(SKColor.Empty, SKColor.Empty),
			ColorFilterTypes.HighContrast => SKColorFilter.CreateHighContrast(new SKHighContrastConfig()
			{
				Contrast = 0f,
				Grayscale = false,
				InvertStyle = SKHighContrastConfigInvertStyle.NoInvert
			}),
			ColorFilterTypes.LumarColor => SKColorFilter.CreateLumaColor(),
			_ => null,
		};
	}
}