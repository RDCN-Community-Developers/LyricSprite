namespace LyricSpriteUI
{
	partial class EffectListBox
	{
		/// <summary> 
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region 组件设计器生成的代码

		/// <summary> 
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			itemsListBox = new ListBox();
			addButton = new Button();
			addTypeCombo = new ComboBox();
			removeButton = new Button();
			effectNameTextBox = new TextBox();
			SuspendLayout();
			// 
			// itemsListBox
			// 
			itemsListBox.FormattingEnabled = true;
			itemsListBox.ItemHeight = 17;
			itemsListBox.Location = new Point(3, 61);
			itemsListBox.Name = "itemsListBox";
			itemsListBox.Size = new Size(120, 89);
			itemsListBox.TabIndex = 0;
			// 
			// addButton
			// 
			addButton.Location = new Point(3, 3);
			addButton.Name = "addButton";
			addButton.Size = new Size(75, 23);
			addButton.TabIndex = 1;
			addButton.Text = "添加";
			addButton.UseVisualStyleBackColor = true;
			// 
			// addTypeCombo
			// 
			addTypeCombo.DropDownStyle = ComboBoxStyle.DropDownList;
			addTypeCombo.FormattingEnabled = true;
			addTypeCombo.Location = new Point(225, 3);
			addTypeCombo.Name = "addTypeCombo";
			addTypeCombo.Size = new Size(121, 25);
			addTypeCombo.TabIndex = 2;
			// 
			// removeButton
			// 
			removeButton.Enabled = false;
			removeButton.Location = new Point(3, 32);
			removeButton.Name = "removeButton";
			removeButton.Size = new Size(75, 23);
			removeButton.TabIndex = 3;
			removeButton.Text = "移除";
			removeButton.UseVisualStyleBackColor = true;
			// 
			// effectNameTextBox
			// 
			effectNameTextBox.Location = new Point(84, 5);
			effectNameTextBox.Name = "effectNameTextBox";
			effectNameTextBox.Size = new Size(135, 23);
			effectNameTextBox.TabIndex = 4;
			effectNameTextBox.Text = "新效果";
			// 
			// EffectListBox
			// 
			AutoScaleDimensions = new SizeF(7F, 17F);
			AutoScaleMode = AutoScaleMode.Font;
			Controls.Add(effectNameTextBox);
			Controls.Add(removeButton);
			Controls.Add(addTypeCombo);
			Controls.Add(addButton);
			Controls.Add(itemsListBox);
			Name = "EffectListBox";
			Size = new Size(349, 153);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private ListBox itemsListBox;
		private Button addButton;
		private ComboBox addTypeCombo;
		private Button removeButton;
		private TextBox effectNameTextBox;
	}
}
