using SkiaSharp;

namespace LyricSpriteUI.RotatedControls
{
    public class RotatedMouseEventArgs(MouseButtons button, float x, float y, int delta) : EventArgs
    {
        private readonly float x = x;
        private readonly float y = y;
        private readonly int delta = delta;
        private readonly MouseButtons b = button;
        public SKPoint Location => new(x, y);
        public float X => x;
        public float Y => y;
        public int Delta => delta;
        public MouseButtons Button => b;
        public RotatedMouseEventArgs(MouseButtons button, SKPoint p, int delta) : this(button, p.X, p.Y, delta) { }
    }
}
