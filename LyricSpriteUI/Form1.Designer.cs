using SkiaSharp;

namespace LyricSpriteUI
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			lyricViewer1 = new LyricViewer();
			LyricViewerPanel = new GroupBox();
			showLyricOutlineCheckBox = new CheckBox();
			showLyricGlowCheckBox = new CheckBox();
			showLyricCheckBox = new CheckBox();
			resetPreviewButton = new Button();
			typefacePanel = new GroupBox();
			typefaceSlantComboBox = new ComboBox();
			typefaceWidthComboBox = new ComboBox();
			typefaceWeightComboBox = new ComboBox();
			typefaceNameCombo = new ComboBox();
			fontPanel = new GroupBox();
			forceAutoHintCheck = new CheckBox();
			baselineSnapCheck = new CheckBox();
			subpixelCheck = new CheckBox();
			edgingCombo = new ComboBox();
			hintingCombo = new ComboBox();
			skewXNumeric = new NumericUpDown();
			scaleXNumeric = new NumericUpDown();
			emboldenCheckBox = new CheckBox();
			fontSizeNumerics = new NumericUpDown();
			previewLyricTextBox = new TextBox();
			splitCombo = new ComboBox();
			timeLabel = new Label();
			alignCombo = new ComboBox();
			glowSigmaNumeric = new NumericUpDown();
			outlineStrokeWidthNnumeric = new NumericUpDown();
			listBox1 = new ListBox();
			maskFiltersGroup = new GroupBox();
			maskFilterTableGroup = new GroupBox();
			maskFilterClipGroup = new GroupBox();
			maskFilterGammaGroup = new GroupBox();
			maskFilterGammaNumeric = new NumericUpDown();
			maskFilterTypeCombo = new ComboBox();
			maskFilterBlurGroup = new GroupBox();
			maskFilterBlurRadiusNumeric = new NumericUpDown();
			maskFilterBlurTypeCombo = new ComboBox();
			colorFilterGroup = new GroupBox();
			label1 = new Label();
			colorFilterBlendModeGroup = new GroupBox();
			colorFilterBlendModeCombo = new ComboBox();
			colorFilterBlendModeColorPicker = new ColorPicker();
			colorFilterTypeCombo = new ComboBox();
			effectListBox1 = new EffectListBox();
			openLyricFileDialog = new OpenFileDialog();
			saveSpriteFileDialog = new SaveFileDialog();
			inputButton = new Button();
			outputDirectionCombo = new ComboBox();
			spriteSheetMaxXNumeric = new NumericUpDown();
			spriteSheetMaxYNumeric = new NumericUpDown();
			outputSettingsGroup = new GroupBox();
			LyricViewerPanel.SuspendLayout();
			typefacePanel.SuspendLayout();
			fontPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)skewXNumeric).BeginInit();
			((System.ComponentModel.ISupportInitialize)scaleXNumeric).BeginInit();
			((System.ComponentModel.ISupportInitialize)fontSizeNumerics).BeginInit();
			((System.ComponentModel.ISupportInitialize)glowSigmaNumeric).BeginInit();
			((System.ComponentModel.ISupportInitialize)outlineStrokeWidthNnumeric).BeginInit();
			maskFiltersGroup.SuspendLayout();
			maskFilterGammaGroup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)maskFilterGammaNumeric).BeginInit();
			maskFilterBlurGroup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)maskFilterBlurRadiusNumeric).BeginInit();
			colorFilterGroup.SuspendLayout();
			colorFilterBlendModeGroup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)spriteSheetMaxXNumeric).BeginInit();
			((System.ComponentModel.ISupportInitialize)spriteSheetMaxYNumeric).BeginInit();
			outputSettingsGroup.SuspendLayout();
			SuspendLayout();
			// 
			// lyricViewer1
			// 
			lyricViewer1.GridSize = 16;
			lyricViewer1.Location = new Point(428, 10);
			lyricViewer1.Name = "lyricViewer1";
			lyricViewer1.ShadowRadius = 16F;
			lyricViewer1.ShowLyric = true;
			lyricViewer1.ShowLyricGlow = false;
			lyricViewer1.ShowLyricOutline = false;
			lyricViewer1.Size = new Size(572, 296);
			lyricViewer1.TabIndex = 0;
			lyricViewer1.Text = "lyricViewer1";
			// 
			// LyricViewerPanel
			// 
			LyricViewerPanel.Controls.Add(showLyricOutlineCheckBox);
			LyricViewerPanel.Controls.Add(showLyricGlowCheckBox);
			LyricViewerPanel.Controls.Add(showLyricCheckBox);
			LyricViewerPanel.Controls.Add(resetPreviewButton);
			LyricViewerPanel.Location = new Point(428, 312);
			LyricViewerPanel.Name = "LyricViewerPanel";
			LyricViewerPanel.Size = new Size(206, 132);
			LyricViewerPanel.TabIndex = 1;
			LyricViewerPanel.TabStop = false;
			LyricViewerPanel.Text = "预览";
			// 
			// showLyricOutlineCheckBox
			// 
			showLyricOutlineCheckBox.AutoSize = true;
			showLyricOutlineCheckBox.Location = new Point(6, 105);
			showLyricOutlineCheckBox.Name = "showLyricOutlineCheckBox";
			showLyricOutlineCheckBox.Size = new Size(111, 21);
			showLyricOutlineCheckBox.TabIndex = 3;
			showLyricOutlineCheckBox.Text = "显示精灵图描边";
			showLyricOutlineCheckBox.UseVisualStyleBackColor = true;
			showLyricOutlineCheckBox.CheckedChanged += showLyricOutlineCheckBox_CheckedChanged;
			// 
			// showLyricGlowCheckBox
			// 
			showLyricGlowCheckBox.AutoSize = true;
			showLyricGlowCheckBox.Location = new Point(6, 78);
			showLyricGlowCheckBox.Name = "showLyricGlowCheckBox";
			showLyricGlowCheckBox.Size = new Size(123, 21);
			showLyricGlowCheckBox.TabIndex = 2;
			showLyricGlowCheckBox.Text = "显示精灵图外发光";
			showLyricGlowCheckBox.UseVisualStyleBackColor = true;
			showLyricGlowCheckBox.CheckedChanged += showLyricGlowCheckBox_CheckedChanged;
			// 
			// showLyricCheckBox
			// 
			showLyricCheckBox.AutoSize = true;
			showLyricCheckBox.Checked = true;
			showLyricCheckBox.CheckState = CheckState.Checked;
			showLyricCheckBox.Location = new Point(6, 51);
			showLyricCheckBox.Name = "showLyricCheckBox";
			showLyricCheckBox.Size = new Size(87, 21);
			showLyricCheckBox.TabIndex = 1;
			showLyricCheckBox.Text = "显示精灵图";
			showLyricCheckBox.UseVisualStyleBackColor = true;
			showLyricCheckBox.CheckedChanged += showLyricCheckBox_CheckedChanged;
			// 
			// resetPreviewButton
			// 
			resetPreviewButton.Location = new Point(6, 22);
			resetPreviewButton.Name = "resetPreviewButton";
			resetPreviewButton.Size = new Size(75, 23);
			resetPreviewButton.TabIndex = 0;
			resetPreviewButton.Text = "重置位置";
			resetPreviewButton.UseVisualStyleBackColor = true;
			resetPreviewButton.Click += button1_Click;
			// 
			// typefacePanel
			// 
			typefacePanel.Controls.Add(typefaceSlantComboBox);
			typefacePanel.Controls.Add(typefaceWidthComboBox);
			typefacePanel.Controls.Add(typefaceWeightComboBox);
			typefacePanel.Controls.Add(typefaceNameCombo);
			typefacePanel.Location = new Point(6, 22);
			typefacePanel.Name = "typefacePanel";
			typefacePanel.Size = new Size(200, 149);
			typefacePanel.TabIndex = 2;
			typefacePanel.TabStop = false;
			typefacePanel.Text = "字形";
			// 
			// typefaceSlantComboBox
			// 
			typefaceSlantComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			typefaceSlantComboBox.FormattingEnabled = true;
			typefaceSlantComboBox.Location = new Point(8, 115);
			typefaceSlantComboBox.Name = "typefaceSlantComboBox";
			typefaceSlantComboBox.Size = new Size(186, 25);
			typefaceSlantComboBox.TabIndex = 3;
			// 
			// typefaceWidthComboBox
			// 
			typefaceWidthComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			typefaceWidthComboBox.FormattingEnabled = true;
			typefaceWidthComboBox.Location = new Point(8, 84);
			typefaceWidthComboBox.Name = "typefaceWidthComboBox";
			typefaceWidthComboBox.Size = new Size(186, 25);
			typefaceWidthComboBox.TabIndex = 2;
			// 
			// typefaceWeightComboBox
			// 
			typefaceWeightComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			typefaceWeightComboBox.FormattingEnabled = true;
			typefaceWeightComboBox.Location = new Point(8, 53);
			typefaceWeightComboBox.Name = "typefaceWeightComboBox";
			typefaceWeightComboBox.Size = new Size(186, 25);
			typefaceWeightComboBox.TabIndex = 1;
			// 
			// typefaceNameCombo
			// 
			typefaceNameCombo.DropDownStyle = ComboBoxStyle.DropDownList;
			typefaceNameCombo.FormattingEnabled = true;
			typefaceNameCombo.Location = new Point(8, 22);
			typefaceNameCombo.Name = "typefaceNameCombo";
			typefaceNameCombo.Size = new Size(186, 25);
			typefaceNameCombo.TabIndex = 0;
			// 
			// fontPanel
			// 
			fontPanel.Controls.Add(forceAutoHintCheck);
			fontPanel.Controls.Add(baselineSnapCheck);
			fontPanel.Controls.Add(subpixelCheck);
			fontPanel.Controls.Add(edgingCombo);
			fontPanel.Controls.Add(hintingCombo);
			fontPanel.Controls.Add(skewXNumeric);
			fontPanel.Controls.Add(scaleXNumeric);
			fontPanel.Controls.Add(emboldenCheckBox);
			fontPanel.Controls.Add(fontSizeNumerics);
			fontPanel.Controls.Add(typefacePanel);
			fontPanel.Location = new Point(209, 10);
			fontPanel.Name = "fontPanel";
			fontPanel.Size = new Size(213, 437);
			fontPanel.TabIndex = 3;
			fontPanel.TabStop = false;
			fontPanel.Text = "字体";
			// 
			// forceAutoHintCheck
			// 
			forceAutoHintCheck.AutoSize = true;
			forceAutoHintCheck.Location = new Point(14, 407);
			forceAutoHintCheck.Name = "forceAutoHintCheck";
			forceAutoHintCheck.Size = new Size(123, 21);
			forceAutoHintCheck.TabIndex = 11;
			forceAutoHintCheck.Text = "小型字体对齐优化";
			forceAutoHintCheck.UseVisualStyleBackColor = true;
			// 
			// baselineSnapCheck
			// 
			baselineSnapCheck.AutoSize = true;
			baselineSnapCheck.Location = new Point(14, 380);
			baselineSnapCheck.Name = "baselineSnapCheck";
			baselineSnapCheck.Size = new Size(111, 21);
			baselineSnapCheck.TabIndex = 10;
			baselineSnapCheck.Text = "使基线对齐像素";
			baselineSnapCheck.UseVisualStyleBackColor = true;
			// 
			// subpixelCheck
			// 
			subpixelCheck.AutoSize = true;
			subpixelCheck.Location = new Point(14, 353);
			subpixelCheck.Name = "subpixelCheck";
			subpixelCheck.Size = new Size(111, 21);
			subpixelCheck.TabIndex = 9;
			subpixelCheck.Text = "启用亚像素定位";
			subpixelCheck.UseVisualStyleBackColor = true;
			// 
			// edgingCombo
			// 
			edgingCombo.DropDownStyle = ComboBoxStyle.DropDownList;
			edgingCombo.FormattingEnabled = true;
			edgingCombo.Location = new Point(14, 322);
			edgingCombo.Name = "edgingCombo";
			edgingCombo.Size = new Size(186, 25);
			edgingCombo.TabIndex = 8;
			// 
			// hintingCombo
			// 
			hintingCombo.DropDownStyle = ComboBoxStyle.DropDownList;
			hintingCombo.FormattingEnabled = true;
			hintingCombo.Location = new Point(14, 291);
			hintingCombo.Name = "hintingCombo";
			hintingCombo.Size = new Size(186, 25);
			hintingCombo.TabIndex = 7;
			// 
			// skewXNumeric
			// 
			skewXNumeric.DecimalPlaces = 2;
			skewXNumeric.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
			skewXNumeric.Location = new Point(14, 262);
			skewXNumeric.Maximum = new decimal(new int[] { 64, 0, 0, 0 });
			skewXNumeric.Minimum = new decimal(new int[] { 64, 0, 0, int.MinValue });
			skewXNumeric.Name = "skewXNumeric";
			skewXNumeric.Size = new Size(186, 23);
			skewXNumeric.TabIndex = 6;
			// 
			// scaleXNumeric
			// 
			scaleXNumeric.DecimalPlaces = 5;
			scaleXNumeric.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
			scaleXNumeric.Location = new Point(14, 233);
			scaleXNumeric.Maximum = new decimal(new int[] { 64, 0, 0, 0 });
			scaleXNumeric.Name = "scaleXNumeric";
			scaleXNumeric.Size = new Size(186, 23);
			scaleXNumeric.TabIndex = 5;
			scaleXNumeric.Value = new decimal(new int[] { 1, 0, 0, 0 });
			// 
			// emboldenCheckBox
			// 
			emboldenCheckBox.AutoSize = true;
			emboldenCheckBox.Location = new Point(14, 206);
			emboldenCheckBox.Name = "emboldenCheckBox";
			emboldenCheckBox.Size = new Size(63, 21);
			emboldenCheckBox.TabIndex = 4;
			emboldenCheckBox.Text = "伪粗体";
			emboldenCheckBox.UseVisualStyleBackColor = true;
			// 
			// fontSizeNumerics
			// 
			fontSizeNumerics.DecimalPlaces = 1;
			fontSizeNumerics.Increment = new decimal(new int[] { 3, 0, 0, 0 });
			fontSizeNumerics.Location = new Point(14, 177);
			fontSizeNumerics.Maximum = new decimal(new int[] { 1024, 0, 0, 0 });
			fontSizeNumerics.Name = "fontSizeNumerics";
			fontSizeNumerics.Size = new Size(186, 23);
			fontSizeNumerics.TabIndex = 3;
			fontSizeNumerics.Value = new decimal(new int[] { 36, 0, 0, 0 });
			// 
			// previewLyricTextBox
			// 
			previewLyricTextBox.Location = new Point(16, 40);
			previewLyricTextBox.Name = "previewLyricTextBox";
			previewLyricTextBox.Size = new Size(186, 23);
			previewLyricTextBox.TabIndex = 4;
			// 
			// splitCombo
			// 
			splitCombo.DropDownStyle = ComboBoxStyle.DropDownList;
			splitCombo.FormattingEnabled = true;
			splitCombo.Location = new Point(15, 69);
			splitCombo.Name = "splitCombo";
			splitCombo.Size = new Size(187, 25);
			splitCombo.TabIndex = 5;
			// 
			// timeLabel
			// 
			timeLabel.AutoSize = true;
			timeLabel.Enabled = false;
			timeLabel.Location = new Point(15, 97);
			timeLabel.Name = "timeLabel";
			timeLabel.Size = new Size(116, 17);
			timeLabel.TabIndex = 6;
			timeLabel.Text = "显示时间（未完成）";
			// 
			// alignCombo
			// 
			alignCombo.DropDownStyle = ComboBoxStyle.DropDownList;
			alignCombo.FormattingEnabled = true;
			alignCombo.Location = new Point(15, 117);
			alignCombo.Name = "alignCombo";
			alignCombo.Size = new Size(187, 25);
			alignCombo.TabIndex = 7;
			// 
			// glowSigmaNumeric
			// 
			glowSigmaNumeric.DecimalPlaces = 1;
			glowSigmaNumeric.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
			glowSigmaNumeric.Location = new Point(15, 147);
			glowSigmaNumeric.Maximum = new decimal(new int[] { 256, 0, 0, 0 });
			glowSigmaNumeric.Name = "glowSigmaNumeric";
			glowSigmaNumeric.Size = new Size(186, 23);
			glowSigmaNumeric.TabIndex = 8;
			// 
			// outlineStrokeWidthNnumeric
			// 
			outlineStrokeWidthNnumeric.Location = new Point(15, 176);
			outlineStrokeWidthNnumeric.Maximum = new decimal(new int[] { 64, 0, 0, 0 });
			outlineStrokeWidthNnumeric.Name = "outlineStrokeWidthNnumeric";
			outlineStrokeWidthNnumeric.Size = new Size(186, 23);
			outlineStrokeWidthNnumeric.TabIndex = 9;
			// 
			// listBox1
			// 
			listBox1.FormattingEnabled = true;
			listBox1.ItemHeight = 17;
			listBox1.Location = new Point(15, 205);
			listBox1.Name = "listBox1";
			listBox1.Size = new Size(186, 123);
			listBox1.TabIndex = 10;
			// 
			// maskFiltersGroup
			// 
			maskFiltersGroup.Controls.Add(maskFilterTableGroup);
			maskFiltersGroup.Controls.Add(maskFilterClipGroup);
			maskFiltersGroup.Controls.Add(maskFilterGammaGroup);
			maskFiltersGroup.Controls.Add(maskFilterTypeCombo);
			maskFiltersGroup.Controls.Add(maskFilterBlurGroup);
			maskFiltersGroup.Location = new Point(1006, 10);
			maskFiltersGroup.Name = "maskFiltersGroup";
			maskFiltersGroup.Size = new Size(152, 263);
			maskFiltersGroup.TabIndex = 11;
			maskFiltersGroup.TabStop = false;
			maskFiltersGroup.Text = "滤镜";
			// 
			// maskFilterTableGroup
			// 
			maskFilterTableGroup.Enabled = false;
			maskFilterTableGroup.Location = new Point(6, 231);
			maskFilterTableGroup.Name = "maskFilterTableGroup";
			maskFilterTableGroup.Size = new Size(132, 23);
			maskFilterTableGroup.TabIndex = 4;
			maskFilterTableGroup.TabStop = false;
			maskFilterTableGroup.Text = "曲线（没做）";
			// 
			// maskFilterClipGroup
			// 
			maskFilterClipGroup.Enabled = false;
			maskFilterClipGroup.Location = new Point(6, 203);
			maskFilterClipGroup.Name = "maskFilterClipGroup";
			maskFilterClipGroup.Size = new Size(132, 22);
			maskFilterClipGroup.TabIndex = 3;
			maskFilterClipGroup.TabStop = false;
			maskFilterClipGroup.Text = "对比度（没做）";
			// 
			// maskFilterGammaGroup
			// 
			maskFilterGammaGroup.Controls.Add(maskFilterGammaNumeric);
			maskFilterGammaGroup.Location = new Point(6, 146);
			maskFilterGammaGroup.Name = "maskFilterGammaGroup";
			maskFilterGammaGroup.Size = new Size(132, 51);
			maskFilterGammaGroup.TabIndex = 2;
			maskFilterGammaGroup.TabStop = false;
			maskFilterGammaGroup.Text = "锐化";
			// 
			// maskFilterGammaNumeric
			// 
			maskFilterGammaNumeric.DecimalPlaces = 2;
			maskFilterGammaNumeric.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
			maskFilterGammaNumeric.Location = new Point(6, 24);
			maskFilterGammaNumeric.Maximum = new decimal(new int[] { 128, 0, 0, 0 });
			maskFilterGammaNumeric.Name = "maskFilterGammaNumeric";
			maskFilterGammaNumeric.Size = new Size(120, 23);
			maskFilterGammaNumeric.TabIndex = 0;
			maskFilterGammaNumeric.Value = new decimal(new int[] { 1, 0, 0, 0 });
			// 
			// maskFilterTypeCombo
			// 
			maskFilterTypeCombo.DropDownStyle = ComboBoxStyle.DropDownList;
			maskFilterTypeCombo.FormattingEnabled = true;
			maskFilterTypeCombo.Location = new Point(11, 22);
			maskFilterTypeCombo.Name = "maskFilterTypeCombo";
			maskFilterTypeCombo.Size = new Size(121, 25);
			maskFilterTypeCombo.TabIndex = 1;
			// 
			// maskFilterBlurGroup
			// 
			maskFilterBlurGroup.Controls.Add(maskFilterBlurRadiusNumeric);
			maskFilterBlurGroup.Controls.Add(maskFilterBlurTypeCombo);
			maskFilterBlurGroup.Location = new Point(6, 56);
			maskFilterBlurGroup.Name = "maskFilterBlurGroup";
			maskFilterBlurGroup.Size = new Size(132, 84);
			maskFilterBlurGroup.TabIndex = 0;
			maskFilterBlurGroup.TabStop = false;
			maskFilterBlurGroup.Text = "模糊";
			// 
			// maskFilterBlurRadiusNumeric
			// 
			maskFilterBlurRadiusNumeric.DecimalPlaces = 1;
			maskFilterBlurRadiusNumeric.Location = new Point(7, 53);
			maskFilterBlurRadiusNumeric.Maximum = new decimal(new int[] { 128, 0, 0, 0 });
			maskFilterBlurRadiusNumeric.Name = "maskFilterBlurRadiusNumeric";
			maskFilterBlurRadiusNumeric.Size = new Size(120, 23);
			maskFilterBlurRadiusNumeric.TabIndex = 1;
			// 
			// maskFilterBlurTypeCombo
			// 
			maskFilterBlurTypeCombo.DropDownStyle = ComboBoxStyle.DropDownList;
			maskFilterBlurTypeCombo.FormattingEnabled = true;
			maskFilterBlurTypeCombo.Location = new Point(6, 22);
			maskFilterBlurTypeCombo.Name = "maskFilterBlurTypeCombo";
			maskFilterBlurTypeCombo.Size = new Size(121, 25);
			maskFilterBlurTypeCombo.TabIndex = 0;
			// 
			// colorFilterGroup
			// 
			colorFilterGroup.Controls.Add(label1);
			colorFilterGroup.Controls.Add(colorFilterBlendModeGroup);
			colorFilterGroup.Controls.Add(colorFilterTypeCombo);
			colorFilterGroup.Location = new Point(1164, 10);
			colorFilterGroup.Name = "colorFilterGroup";
			colorFilterGroup.Size = new Size(200, 227);
			colorFilterGroup.TabIndex = 12;
			colorFilterGroup.TabStop = false;
			colorFilterGroup.Text = "颜色滤镜";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Enabled = false;
			label1.Location = new Point(12, 149);
			label1.Name = "label1";
			label1.Size = new Size(92, 17);
			label1.TabIndex = 2;
			label1.Text = "其他几个都没做";
			// 
			// colorFilterBlendModeGroup
			// 
			colorFilterBlendModeGroup.Controls.Add(colorFilterBlendModeCombo);
			colorFilterBlendModeGroup.Controls.Add(colorFilterBlendModeColorPicker);
			colorFilterBlendModeGroup.Location = new Point(6, 53);
			colorFilterBlendModeGroup.Name = "colorFilterBlendModeGroup";
			colorFilterBlendModeGroup.Size = new Size(138, 93);
			colorFilterBlendModeGroup.TabIndex = 1;
			colorFilterBlendModeGroup.TabStop = false;
			colorFilterBlendModeGroup.Text = "颜色混合";
			// 
			// colorFilterBlendModeCombo
			// 
			colorFilterBlendModeCombo.DropDownStyle = ComboBoxStyle.DropDownList;
			colorFilterBlendModeCombo.FormattingEnabled = true;
			colorFilterBlendModeCombo.Location = new Point(6, 62);
			colorFilterBlendModeCombo.Name = "colorFilterBlendModeCombo";
			colorFilterBlendModeCombo.Size = new Size(121, 25);
			colorFilterBlendModeCombo.TabIndex = 1;
			// 
			// colorFilterBlendModeColorPicker
			// 
			colorFilterBlendModeColorPicker.Location = new Point(6, 24);
			colorFilterBlendModeColorPicker.Name = "colorFilterBlendModeColorPicker";
			colorFilterBlendModeColorPicker.Size = new Size(32, 32);
			colorFilterBlendModeColorPicker.TabIndex = 0;
			colorFilterBlendModeColorPicker.Text = "colorPicker1";
			// 
			// colorFilterTypeCombo
			// 
			colorFilterTypeCombo.DropDownStyle = ComboBoxStyle.DropDownList;
			colorFilterTypeCombo.FormattingEnabled = true;
			colorFilterTypeCombo.Location = new Point(12, 22);
			colorFilterTypeCombo.Name = "colorFilterTypeCombo";
			colorFilterTypeCombo.Size = new Size(121, 25);
			colorFilterTypeCombo.TabIndex = 0;
			// 
			// effectListBox1
			// 
			effectListBox1.Location = new Point(1224, 417);
			effectListBox1.Name = "effectListBox1";
			effectListBox1.Size = new Size(223, 132);
			effectListBox1.TabIndex = 2;
			effectListBox1.Visible = false;
			// 
			// openLyricFileDialog
			// 
			openLyricFileDialog.FileName = "txt.txt";
			openLyricFileDialog.Filter = "TXT 文本文件|*.txt|歌词文件|*.lrc";
			// 
			// saveSpriteFileDialog
			// 
			saveSpriteFileDialog.FileName = "out";
			saveSpriteFileDialog.Filter = "文件前缀|*";
			// 
			// inputButton
			// 
			inputButton.Location = new Point(18, 11);
			inputButton.Name = "inputButton";
			inputButton.Size = new Size(185, 23);
			inputButton.TabIndex = 13;
			inputButton.Text = "使用配置";
			inputButton.UseVisualStyleBackColor = true;
			inputButton.Click += Run;
			// 
			// outputDirectionCombo
			// 
			outputDirectionCombo.DropDownStyle = ComboBoxStyle.DropDownList;
			outputDirectionCombo.FormattingEnabled = true;
			outputDirectionCombo.Location = new Point(6, 22);
			outputDirectionCombo.Name = "outputDirectionCombo";
			outputDirectionCombo.Size = new Size(186, 25);
			outputDirectionCombo.TabIndex = 14;
			// 
			// spriteSheetMaxXNumeric
			// 
			spriteSheetMaxXNumeric.Location = new Point(6, 53);
			spriteSheetMaxXNumeric.Maximum = new decimal(new int[] { 1048576, 0, 0, 0 });
			spriteSheetMaxXNumeric.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
			spriteSheetMaxXNumeric.Name = "spriteSheetMaxXNumeric";
			spriteSheetMaxXNumeric.Size = new Size(89, 23);
			spriteSheetMaxXNumeric.TabIndex = 15;
			spriteSheetMaxXNumeric.Value = new decimal(new int[] { 4000, 0, 0, 0 });
			// 
			// spriteSheetMaxYNumeric
			// 
			spriteSheetMaxYNumeric.Location = new Point(105, 53);
			spriteSheetMaxYNumeric.Maximum = new decimal(new int[] { 1048576, 0, 0, 0 });
			spriteSheetMaxYNumeric.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
			spriteSheetMaxYNumeric.Name = "spriteSheetMaxYNumeric";
			spriteSheetMaxYNumeric.Size = new Size(89, 23);
			spriteSheetMaxYNumeric.TabIndex = 16;
			spriteSheetMaxYNumeric.Value = new decimal(new int[] { 4000, 0, 0, 0 });
			// 
			// outputSettingsGroup
			// 
			outputSettingsGroup.Controls.Add(outputDirectionCombo);
			outputSettingsGroup.Controls.Add(spriteSheetMaxYNumeric);
			outputSettingsGroup.Controls.Add(spriteSheetMaxXNumeric);
			outputSettingsGroup.Location = new Point(9, 334);
			outputSettingsGroup.Name = "outputSettingsGroup";
			outputSettingsGroup.Size = new Size(200, 121);
			outputSettingsGroup.TabIndex = 17;
			outputSettingsGroup.TabStop = false;
			outputSettingsGroup.Text = "导出设置";
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(7F, 17F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1367, 455);
			Controls.Add(outputSettingsGroup);
			Controls.Add(inputButton);
			Controls.Add(effectListBox1);
			Controls.Add(colorFilterGroup);
			Controls.Add(maskFiltersGroup);
			Controls.Add(listBox1);
			Controls.Add(outlineStrokeWidthNnumeric);
			Controls.Add(glowSigmaNumeric);
			Controls.Add(alignCombo);
			Controls.Add(timeLabel);
			Controls.Add(splitCombo);
			Controls.Add(previewLyricTextBox);
			Controls.Add(fontPanel);
			Controls.Add(LyricViewerPanel);
			Controls.Add(lyricViewer1);
			FormBorderStyle = FormBorderStyle.FixedSingle;
			MaximizeBox = false;
			Name = "Form1";
			Text = "歌词精灵图生成器";
			Load += Form1_Load;
			LyricViewerPanel.ResumeLayout(false);
			LyricViewerPanel.PerformLayout();
			typefacePanel.ResumeLayout(false);
			fontPanel.ResumeLayout(false);
			fontPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)skewXNumeric).EndInit();
			((System.ComponentModel.ISupportInitialize)scaleXNumeric).EndInit();
			((System.ComponentModel.ISupportInitialize)fontSizeNumerics).EndInit();
			((System.ComponentModel.ISupportInitialize)glowSigmaNumeric).EndInit();
			((System.ComponentModel.ISupportInitialize)outlineStrokeWidthNnumeric).EndInit();
			maskFiltersGroup.ResumeLayout(false);
			maskFilterGammaGroup.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)maskFilterGammaNumeric).EndInit();
			maskFilterBlurGroup.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)maskFilterBlurRadiusNumeric).EndInit();
			colorFilterGroup.ResumeLayout(false);
			colorFilterGroup.PerformLayout();
			colorFilterBlendModeGroup.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)spriteSheetMaxXNumeric).EndInit();
			((System.ComponentModel.ISupportInitialize)spriteSheetMaxYNumeric).EndInit();
			outputSettingsGroup.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private LyricViewer lyricViewer1;
		private GroupBox LyricViewerPanel;
		private Button resetPreviewButton;
		private CheckBox showLyricOutlineCheckBox;
		private CheckBox showLyricGlowCheckBox;
		private CheckBox showLyricCheckBox;
		private GroupBox typefacePanel;
		private ComboBox typefaceNameCombo;
		private ComboBox typefaceWeightComboBox;
		private ComboBox typefaceWidthComboBox;
		private ComboBox typefaceSlantComboBox;
		private GroupBox fontPanel;
		private TextBox previewLyricTextBox;
		private NumericUpDown fontSizeNumerics;
		private NumericUpDown scaleXNumeric;
		private CheckBox emboldenCheckBox;
		private NumericUpDown skewXNumeric;
		private CheckBox subpixelCheck;
		private ComboBox edgingCombo;
		private ComboBox hintingCombo;
		private CheckBox forceAutoHintCheck;
		private CheckBox baselineSnapCheck;
		private ComboBox splitCombo;
		private Label timeLabel;
		private ComboBox alignCombo;
		private NumericUpDown glowSigmaNumeric;
		private NumericUpDown outlineStrokeWidthNnumeric;
		private ListBox listBox1;
		private GroupBox maskFiltersGroup;
		private GroupBox maskFilterBlurGroup;
		private ComboBox maskFilterBlurTypeCombo;
		private NumericUpDown maskFilterBlurRadiusNumeric;
		private ComboBox maskFilterTypeCombo;
		private GroupBox maskFilterGammaGroup;
		private NumericUpDown maskFilterGammaNumeric;
		private GroupBox maskFilterClipGroup;
		private GroupBox maskFilterTableGroup;
		private GroupBox colorFilterGroup;
		private ComboBox colorFilterTypeCombo;
		private GroupBox colorFilterBlendModeGroup;
		private ColorPicker colorFilterBlendModeColorPicker;
		private ComboBox colorFilterBlendModeCombo;
		private EffectListBox effectListBox1;
		private Label label1;
		private OpenFileDialog openLyricFileDialog;
		private SaveFileDialog saveSpriteFileDialog;
		private Button inputButton;
		private ComboBox outputDirectionCombo;
		private NumericUpDown spriteSheetMaxXNumeric;
		private NumericUpDown spriteSheetMaxYNumeric;
		private GroupBox outputSettingsGroup;
	}
}
