using LyricSprite;
using SkiaSharp;
using System.ComponentModel;
using System.Reflection;
using static LyricSprite.Extensions;

namespace LyricSpriteUI
{
	public partial class Form1 : Form
	{
		readonly SKFontManager fontManager = SKFontManager.Default;
		readonly bool initialized = false;
		public Form1()
		{
			InitializeComponent();

			typefaceNameCombo.Items.AddRange(fontManager.FontFamilies.ToArray());
			typefaceNameCombo.SelectedIndex = 0;
			typefaceWeightComboBox.InitEnum<SKFontStyleWeight>();
			typefaceWidthComboBox.InitEnum<SKFontStyleWidth>();
			typefaceSlantComboBox.InitEnum<SKFontStyleSlant>();
			hintingCombo.InitEnum<SKFontHinting>();
			edgingCombo.InitEnum<SKFontEdging>();
			splitCombo.InitEnum<SplitOptions>();
			alignCombo.InitEnum<SKTextAlign>();
			outputDirectionCombo.InitEnum<OutputDirection>();

			maskFilterTypeCombo.InitEnum<MaskFilterTypes>();
			maskFilterBlurTypeCombo.InitEnum<SKBlurStyle>();

			effectListBox1.InitEnum<ColorFilterTypes>();
			colorFilterTypeCombo.InitEnum<ColorFilterTypes>();
			colorFilterBlendModeCombo.InitEnum<SKBlendMode>();


			typefaceNameCombo.SelectedIndexChanged += UpdateLyric;
			typefaceWeightComboBox.SelectedIndexChanged += UpdateLyric;
			typefaceWidthComboBox.SelectedIndexChanged += UpdateLyric;
			typefaceSlantComboBox.SelectedIndexChanged += UpdateLyric;

			previewLyricTextBox.TextChanged += UpdateLyric;

			fontSizeNumerics.ValueChanged += UpdateLyric;
			emboldenCheckBox.CheckedChanged += UpdateLyric;
			scaleXNumeric.ValueChanged += UpdateLyric;
			skewXNumeric.ValueChanged += UpdateLyric;
			hintingCombo.SelectedIndexChanged += UpdateLyric;
			edgingCombo.SelectedIndexChanged += UpdateLyric;
			subpixelCheck.CheckedChanged += UpdateLyric;
			baselineSnapCheck.CheckedChanged += UpdateLyric;
			forceAutoHintCheck.CheckedChanged += UpdateLyric;

			splitCombo.SelectedIndexChanged += UpdateLyric;
			alignCombo.SelectedIndexChanged += UpdateLyric;
			glowSigmaNumeric.ValueChanged += UpdateLyric;
			outlineStrokeWidthNnumeric.ValueChanged += UpdateLyric;

			maskFilterTypeCombo.SelectedIndexChanged += UpdateLyric;
			maskFilterBlurTypeCombo.SelectedIndexChanged += UpdateLyric;
			maskFilterBlurRadiusNumeric.ValueChanged += UpdateLyric;
			maskFilterGammaNumeric.ValueChanged += UpdateLyric;

			colorFilterTypeCombo.SelectedIndexChanged += UpdateLyric;
			colorFilterBlendModeColorPicker.ColorChanged += UpdateLyric;
			colorFilterBlendModeCombo.SelectedIndexChanged += UpdateLyric;

			initialized = true;
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			//Lyric lyric = new("Test测试")
			//{
			//	SplitOption = SplitOptions.ProgressiveSplitByChar,
			//	Time = TimeSpan.FromSeconds(2),
			//	Align = SKTextAlign.Center,
			//	GlowSigma = 3,
			//	OutlineStrokeWidth = 0,
			//	Font = new()
			//	{
			//		Typeface = SKTypeface.FromFamilyName(
			//			"Unifont",                             // 字体名
			//			SKFontStyleWeight.Normal,                   // 字重
			//			SKFontStyleWidth.Normal,                    // 字宽
			//			SKFontStyleSlant.Upright                    // 变体
			//			),
			//		Embolden = false,                                // 伪粗体
			//		Size = 100,                                      // 字体大小
			//		ScaleX = 1f,                                  // 水平比例
			//		SkewX = 0f,                                 // 水平倾斜系数
			//		Hinting = SKFontHinting.Full,
			//		Edging = SKFontEdging.Alias,                    // LCD 点阵优化
			//		Subpixel = true,                                // 启用压像素定位
			//		BaselineSnap = true,                            // 基线对齐像素
			//		ForceAutoHinting = true,                        // 小型字体对齐优化
			//	},
			//	Style = new()
			//	{
			//		//BlendMode = SKBlendMode.Multiply,                                       // 混合模式
			//		Color = new SKColor(0, 255, 255),                                         // 前景色

			//		//Style = SKPaintStyle.Fill,                                              // 绘制样式
			//		//StrokeCap = SKStrokeCap.Round,                                          // 端点样式
			//		//StrokeJoin = SKStrokeJoin.Round,                                        // 连接样式
			//		//StrokeMiter = 1,                                                        // 斜接样式
			//		//StrokeWidth = 0,                                                        // 描边宽度

			//		//MaskFilter = SKMaskFilter.CreateBlur(SKBlurStyle.Solid, 2),             // 蒙版效果如遮罩

			//		//PathEffect = SKPathEffect.CreateDash([2, 2], 1),                                                                            // 路径效果

			//		Shader = SKShader.CreateLinearGradient(new(0, 0), new(128, 0), [new(0, 255, 0), new(0, 255, 255)], SKShaderTileMode.Mirror),// 着色器

			//		IsAntialias = false,                                                                                                          // 抗锯齿
			//	}
			//};

			////SKMaskFilter filter = SKMaskFilter.CreateBlur(SKBlurStyle.Normal, 2f);//模糊
			////SKMaskFilter filter1 = SKMaskFilter.CreateGamma(2f);//伽马
			////SKMaskFilter filter2 = SKMaskFilter.CreateClip(2, 3);//颜色范围限制，对比度
			////SKMaskFilter filter3 = SKMaskFilter.CreateTable([1, 2]);//曲线

			////SKPathEffect path = SKPathEffect.CreateCorner(3);//圆角
			////												 //...

			////SKBlender blender = SKBlender.CreateBlendMode(SKBlendMode.Src);//混合模式
			////SKBlender blender1 = SKBlender.CreateArithmetic(0, 1, 2, 3, false);//混合模式

			////SKColorFilter colorFilter = SKColorFilter.CreateHighContrast();//颜色通道过滤
			////															   //...

			////SKShader shader1 = SKShader.CreateBitmap(new(1, 1));//图片着色器
			////SKShader shader2 = SKShader.CreateSweepGradient(new(0, 0), [new(0, 255, 0), new(0, 255, 255)]);//旋转渐变
			////SKShader shader3 = SKShader.CreateRadialGradient();//中心渐变
			////SKShader shader4 = SKShader.CreateTwoPointConicalGradient();//两点锥形渐变
			////SKShader shader5 = SKShader.CreateLinearGradient();//线性渐变
			////SKShader shader6 = SKShader.CreatePerlinNoiseFractalNoise();//柏林噪声
			////SKShader shader7 = SKShader.CreatePerlinNoiseTurbulence();//湍流噪声
			////SKShader shader8 = SKShader.CreateColor();//单色
			////SKShader shader9 = SKShader.CreateColorFilter();//滤色
			////SKShader shader10 = SKShader.CreateCompose(shader1, shader1);//混合 SrcOver

			////SKShader shader = SKShader.CreateBlend(blender, shader1, shader2); // 混合


			//SpriteSheetCanvas builder = new(OutputDirection.Vertical, maxWidth: 1000, maxHeight: 400)
			//{
			//	Margin = new(20, 20, 20, 20)
			//};

			//builder.DrawLyric(lyric);
			//builder.DrawLyric(lyric);
			//builder.DrawLyric(lyric);
			//builder.DrawLyric(lyric);
			//builder.DrawLyric(lyric);
			//SpriteSheetBook book = builder.Build();

			//int i = 0;
			//foreach (var page in book.pageInfos)
			//{
			//	page.image.Save($"out_{i}.png");
			//	page.imageGlow.Save($"out_{i}_glow.png");
			//	page.imageOutline.Save($"out_{i}_outline.png");
			//	i++;
			//}

			//SKRect bound = lyric.Bounds;

			//SKSize size = bound.Size;

			//SKRect card = SKRect.Create(size);
			//card.Offset(400, 100);

			//SKBitmap bitmap = new((int)1920, (int)1080);
			//SKCanvas canvas = new(bitmap);

			//UITextRender.RendBackground(canvas, new(1920, 1080));
			//UITextRender.RendCard(canvas, card, 10, SKColors.Black);
			//UITextRender.RendLyric(canvas, lyric, card);
			//UITextRender.RendLyricGlow(canvas, lyric, card);
			//UITextRender.RendLyricOutline(canvas, lyric, card);

			//bitmap.Save("show.png");
			//lyricViewer1.Lyric = lyric;

			//colorFilterBlendModeColorPicker.Color = SKColors.Red;

			lyricViewer1.CardPosition = SKRect.Create(new SKSize(352, 198));
			previewLyricTextBox.Text = "输入以预览效果";
		}
		//public void Test(object? sender, EventArgs e)
		//{
		//}
		private void button1_Click(object sender, EventArgs e) => lyricViewer1.ResetPosition();
		private void showLyricCheckBox_CheckedChanged(object sender, EventArgs e) => lyricViewer1.ShowLyric = showLyricCheckBox.Checked;
		private void showLyricGlowCheckBox_CheckedChanged(object sender, EventArgs e) => lyricViewer1.ShowLyricGlow = showLyricGlowCheckBox.Checked;
		private void showLyricOutlineCheckBox_CheckedChanged(object sender, EventArgs e) => lyricViewer1.ShowLyricOutline = showLyricOutlineCheckBox.Checked;
		private void UpdateLyric(object? sender, EventArgs e)
		{
			if (initialized)
			{
				lyricViewer1.Lyric = GetShowingLyric();
				listBox1.Items.Clear();
				listBox1.Items.AddRange([.. lyricViewer1.Lyric.Split]);
				Invalidate();
			}
		}
		private SKTypeface GetTypeface()
		{
			return SKTypeface.FromFamilyName(
				(string?)typefaceNameCombo.SelectedItem ?? "",
				typefaceWeightComboBox.GetEnum<SKFontStyleWeight>(),
				typefaceWidthComboBox.GetEnum<SKFontStyleWidth>(),
				typefaceSlantComboBox.GetEnum<SKFontStyleSlant>()
				);
		}
		private SKFont GetFont()
		{
			return new()
			{
				Typeface = GetTypeface(),
				Size = (float)fontSizeNumerics.Value,
				Embolden = emboldenCheckBox.Checked,
				ScaleX = (float)scaleXNumeric.Value,
				SkewX = (float)skewXNumeric.Value,
				Hinting = hintingCombo.GetEnum<SKFontHinting>(),
				Edging = edgingCombo.GetEnum<SKFontEdging>(),
				Subpixel = subpixelCheck.Checked,
				BaselineSnap = baselineSnapCheck.Checked,
				ForceAutoHinting = forceAutoHintCheck.Checked,
			};
		}
		private SKPaint GetStyle()
		{
			return new()
			{
				Shader = null,// SKShader.CreateSweepGradient(new(50, 50), [new(0, 255, 0), new(0, 255, 255), new(255, 255, 255)]),
				MaskFilter = GetMaskFilter(),
				ColorFilter = GetColorFilter(),
			};
		}
		private Lyric GetShowingLyric()
		{
			return new()
			{
				Text = previewLyricTextBox.Text,
				SplitOption = splitCombo.GetEnum<SplitOptions>(),
				Align = alignCombo.GetEnum<SKTextAlign>(),
				GlowSigma = (float)glowSigmaNumeric.Value,
				OutlineStrokeWidth = (float)outlineStrokeWidthNnumeric.Value,
				Font = GetFont(),
				Style = GetStyle(),
			};
		}
		private void Run(object sender, EventArgs e)
		{
			if (openLyricFileDialog.ShowDialog() != DialogResult.OK)
				return;

			string extension = Path.GetExtension(openLyricFileDialog.FileName);
			if (extension is not (".txt" or ".lrc"))
			{
				MessageBox.Show("此文件后缀不正确。");
			}
			List<Lyric> lyrics = LyricReader.Read(openLyricFileDialog.FileName);
			int i = 0;
			while (i < lyrics.Count)
			{
				Lyric lyric = lyricViewer1.Lyric;
				lyric.Text = lyrics[i].Text;
				lyrics[i] = lyric;
				i++;
			}
			SpriteSheetCanvas canvas = new(
				outputDirectionCombo.GetEnum<OutputDirection>(),
				(int)spriteSheetMaxXNumeric.Value,
				(int)spriteSheetMaxYNumeric.Value);
			canvas.DrawLyrics(lyrics);
			SpriteSheetBook book = canvas.Build();

			if (saveSpriteFileDialog.ShowDialog() != DialogResult.OK)
				return;

			string filename = saveSpriteFileDialog.FileName;
			if (book.pageInfos.Count > 1)
				for (int p = 0; p < book.pageInfos.Count; p++)
				{
					PageInfo page = book.pageInfos[p];
					page.image.Save(filename + $"_{p}.png");
					page.imageGlow.Save(filename + $"_{p}_glow.png");
					page.imageOutline.Save(filename + $"_{p}_outline.png");
				}
			else
			{
				book.pageInfos[0].image.Save(filename + ".png");
				book.pageInfos[0].imageGlow.Save(filename + "_glow.png");
				book.pageInfos[0].imageOutline.Save(filename + "_outline.png");
			}
		}
	}
	public static class Extensions
	{
		public static void InitEnum<TEnum>(this ComboBox e) where TEnum : struct, Enum
		{
			Type type = typeof(TEnum);
			var memberInfo = type.GetFields(BindingFlags.Static | BindingFlags.Public);
			foreach (var member in memberInfo)
			{
				DescriptionAttribute? attr = member.GetCustomAttribute<DescriptionAttribute>();
				e.Items.Add(attr == null ? member.Name : attr.Description);
			}
			e.SelectedIndex = 0;
		}
		public static TEnum GetEnum<TEnum>(this ComboBox e) where TEnum : struct, Enum
		{
			Type type = typeof(TEnum);
			MemberInfo? memberInfo = type.GetMembers()
				.SingleOrDefault(i =>
					i.GetCustomAttribute<DescriptionAttribute>()?.Description == (string?)e.SelectedItem ||
					i.Name == (string?)e.SelectedItem);
			return memberInfo != null ? Enum.Parse<TEnum>(memberInfo.Name ?? "") :
				throw new NotImplementedException();
		}
	}
}
