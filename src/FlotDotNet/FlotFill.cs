namespace FlotDotNet
{
    using System.Diagnostics;
    using FlotDotNet.Infrastruture;
    using Newtonsoft.Json;

    /// <summary>
    /// Defines how a shape is to be filled.
    /// </summary>
    [JsonConverter(typeof(FlotConverter))]
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + "()}")]
    public sealed class FlotFill
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FlotFill"/> class with a specified opacity.
        /// </summary>
        /// <param name="opacity">The opacity.</param>
        public FlotFill(double opacity)
        {
            Opacity = opacity;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FlotFill"/> class with a specified fill value.
        /// </summary>
        /// <param name="fill">Whether the shape is filled.</param>
        public FlotFill(bool fill)
        {
            Fill = fill;
        }

        /// <summary>
        /// Gets the opacity, anumber between 0 (fully transparent) and 1 (fully opaque).
        /// </summary>
        [JsonIgnore]
        public double? Opacity { get; }

        /// <summary>
        /// Gets a value indicating whether the shape is filled.
        /// </summary>
        [JsonIgnore]
        public bool? Fill { get; }

        /// <summary>
        /// Creates a new <see cref="FlotFill"/> object with the given opacity.
        /// </summary>
        /// <param name="opacity">The opacity.</param>
        public static implicit operator FlotFill(double opacity) => new FlotFill(opacity);

        /// <summary>
        /// Creates a new <see cref="FlotFill"/> object with the given fill vale.
        /// </summary>
        /// <param name="fill">Whether the shape is filled.</param>
        public static implicit operator FlotFill(bool fill) => new FlotFill(fill);

        private object Serialize()
        {
            if (Opacity.HasValue)
            {
                return Opacity;
            }
            else
            {
                return Fill;
            }
        }

        private object DebuggerDisplay() => Serialize();
    }
}