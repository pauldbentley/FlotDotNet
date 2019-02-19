namespace FlotDotNet
{
    public sealed class FlotColorScaling
    {
        public FlotColorScaling(double opacity, double brightness)
        {
            Opacity = opacity;
            Brightness = brightness;
        }

        public double? Opacity { get; }

        public double? Brightness { get; }
    }
}