using System.Drawing;

namespace VehicleSaver.Serilization
{
    public class SerilizableColor
    {
        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }
        public byte A { get; set; }

        public SerilizableColor() { }

        public SerilizableColor(Color color)
        {
            R = color.R;
            G = color.G;
            B = color.B;
            A = color.A;
        }

        public Color ToColor() => Color.FromArgb(A, R, G, B);
    }
}
