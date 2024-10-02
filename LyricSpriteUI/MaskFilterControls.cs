using SkiaSharp;
using System.ComponentModel;
namespace LyricSpriteUI
{
	internal enum MaskFilterTypes
	{
		[Description("无")]
		None = 0,
		[Description("模糊")]
		Blur,
		[Description("锐化")]
		Gamma,
		[Description("对比度")]
		Clip,
		[Description("曲线")]
		Table,
	}
	partial class Form1
	{
		private SKMaskFilter? GetMaskFilter() =>
			maskFilterTypeCombo.GetEnum<MaskFilterTypes>() switch
			{
				MaskFilterTypes.Blur => SKMaskFilter.CreateBlur(
					maskFilterBlurTypeCombo.GetEnum<SKBlurStyle>(),
					(float)maskFilterBlurRadiusNumeric.Value
					),
				MaskFilterTypes.Gamma => SKMaskFilter.CreateGamma(
					(float)maskFilterGammaNumeric.Value
					),
				MaskFilterTypes.Clip => SKMaskFilter.CreateClip(
					0,
					100
					),
				MaskFilterTypes.Table => SKMaskFilter.CreateTable(
					Enumerable.Range(0, 256).Select(i => (byte)i).ToArray()
					),
				_ => null,
			};
	}
}