using System.Collections;

namespace LyricSpriteUI.RotatedControls
{
    public class PrimaryRotatedControlCollection(RotatedControlsContainer container) : IList<RotatedControl>
    {
        private readonly List<RotatedControl> children = [];
        public RotatedControl this[int index]
        {
            get => children[index];
            set
            {
                children[index] = value;
            }
        }
        public RotatedControlsContainer Owner { get; } = container;
        public int Count => children.Count;
        public bool IsReadOnly => false;
        public void Add(RotatedControl item)
        {
            children.Add(item);
        }
        public void Clear()
        {
            while (children.Count > 0)
            {
                children[0].Parent = null;
                children.RemoveAt(0);
            }
        }
        public bool Contains(RotatedControl item) => children.Contains(item);
        public void CopyTo(RotatedControl[] array, int arrayIndex) => children.CopyTo(array, arrayIndex);
        public IEnumerator<RotatedControl> GetEnumerator() => children.GetEnumerator();
        public int IndexOf(RotatedControl item) => children.IndexOf(item);
        public void Insert(int index, RotatedControl item)
        {
            children.Insert(index, item);
        }
        public bool Remove(RotatedControl item)
        {
            item.Parent = null;
            return children.Remove(item);
        }
        public void RemoveAt(int index)
        {
            children[index].Parent = null;
            children.RemoveAt(index);
        }
        IEnumerator IEnumerable.GetEnumerator() => children.GetEnumerator();
    }
}
