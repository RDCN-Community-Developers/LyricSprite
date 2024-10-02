namespace LyricSpriteUI
{
	public partial class EffectListBox : UserControl
	{
		public event EventHandler<(string name, string type)> AddButtonClicked;
		public struct Item(string name, object value)
		{
			public string Name { get; set; } = name;
			public object Value { get; set; } = value;
			public override readonly string ToString() => Name;
		}
		private readonly List<Item> _items = [];
		public EffectListBox()
		{
			InitializeComponent();
			itemsListBox.SelectedIndexChanged += SelectedIndexChanged;
			addButton.Click += OnAddButtonClicked;
		}
		private void OnAddButtonClicked(object? sender,EventArgs e)
		{
			Invoke(AddButtonClicked,sender,(effectNameTextBox.Text,addTypeCombo.Text));
		}
		public Func<Enum, object> Func { get; set; } = i => i;
		public void InitEnum<TEnum>() where TEnum : struct, Enum => addTypeCombo.InitEnum<TEnum>();
		public void GetEnum<TEnum>() where TEnum : struct, Enum => addTypeCombo.GetEnum<TEnum>();
		public void Add(Item item) => _items.Add(item);
		public IEnumerable<TEffect> GetItems<TEffect>() => _items.Select(i=>i.Value).Cast<TEffect>();
		public TEffect? MergeEffects<TEffect>(Func<TEffect, TEffect, TEffect> func) where TEffect : class
		{
			if (_items.Count == 0) return null;
			TEffect effect = (TEffect)_items[0].Value;
			for (int i = 1; i < _items.Count; i++)
				effect = func(effect, (TEffect)_items[i].Value);
			return effect;
		}
		protected override void OnSizeChanged(EventArgs e)
		{
			int controlerWidth = this.Width - addButton.Width - addButton.Margin.Horizontal;
			int coltrolerLeft = addButton.Right + addButton.Margin.Right;
			itemsListBox.Height = this.Height - addButton.Height - addButton.Margin.Vertical - removeButton.Height - removeButton.Margin.Vertical - itemsListBox.Margin.Vertical;
			itemsListBox.Width = Width - itemsListBox.Margin.Horizontal;
			effectNameTextBox.Width = controlerWidth / 2 - effectNameTextBox.Margin.Horizontal;
			effectNameTextBox.Left = coltrolerLeft;
			addTypeCombo.Width = controlerWidth / 2 - addTypeCombo.Margin.Horizontal;
			addTypeCombo.Left = coltrolerLeft + controlerWidth / 2;
		}
		public void SelectedIndexChanged(object? sender, EventArgs e) => removeButton.Enabled = itemsListBox.SelectedIndex >= 0;
	}
}
