namespace FlotDotNet
{
    using System;

    /// <summary>
    /// Scaling of the brightness and the opacity of a color.
    /// </summary>
    public sealed class FlotScaling
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FlotScaling"/> class with a specified opacity and brightness.
        /// </summary>
        /// <param name="opacity">The opaticy.</param>
        /// <param name="brightness">The brightness.</param>
        /// <exception cref="ArgumentOutOfRangeException">If both <paramref name="brightness"/> and <paramref name="opacity"/> are null.</exception>
        public FlotScaling(double? opacity, double? brightness)
        {
            if (opacity == null && brightness == null)
            {
                throw new ArgumentOutOfRangeException(nameof(brightness));
            }

            Opacity = opacity;
            Brightness = brightness;
        }

        /// <summary>
        /// Gets the opacity.
        /// </summary>
        public double? Opacity { get; }

        /// <summary>
        /// Gets the brightness.
        /// </summary>
        public double? Brightness { get; }
    }
}