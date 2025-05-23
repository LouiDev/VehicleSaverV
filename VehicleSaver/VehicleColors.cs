using VehicleSaver.Serilization;

namespace VehicleSaver
{
    public class VehicleColors
    {
        public int ColorCombination { get; set; }
        public int ColorCombinationCount { get; set; }
        public int PrimaryColor { get; set; }
        public int SecondaryColor { get; set; }
        public int PearlescentColor { get; set; }
        public int RimColor { get; set; }
        public int DashboardColor { get; set; }
        public int TrimColor { get; set; }
        public SerilizableColor CustomPrimaryColor { get; set; }
        public SerilizableColor CustomSecondaryColor { get; set; }
        public SerilizableColor NeonLightsColor { get; set; }
        public SerilizableColor TireSmokeColor { get; set; }
    }
}
