namespace FlotDotNet
{
    using System;
    using System.Diagnostics;
    using FlotDotNet.Infrastruture;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Provides options to sort the legend entries.
    ///
    /// Legend entries appear in the same order as their series by default.
    /// If "sorted" is "reverse" then they appear in the opposite order from their series.
    /// To sort them alphabetically, you can specify true, "ascending" or "descending", where true and "ascending" are equivalent.
    ///
    /// You can also provide your own comparator function that accepts two objects with "label" and "color" properties,
    /// and returns zero if they are equal, a positive value if the first is greater than the second,
    /// and a negative value if the first is less than the second.
    /// </summary>
    [JsonConverter(typeof(FlotConverter))]
    [DebuggerDisplay("{" + nameof(DebuggerDisplay) + "()}")]
    public sealed class FlotLegendSorting
    {
        /// <summary>
        /// The legend entries are sorted alphabetically in ascending order.
        /// </summary>
        public static readonly FlotLegendSorting Ascending = new FlotLegendSorting("ascending");

        /// <summary>
        /// The legend entries are sorted alphabetically in descending order.
        /// </summary>
        public static readonly FlotLegendSorting Descending = new FlotLegendSorting("descending");

        /// <summary>
        /// The legend entries appear in the opposite order from their series.
        /// </summary>
        public static readonly FlotLegendSorting Reverse = new FlotLegendSorting("reverse");

        /// <summary>
        /// Initializes a new instance of the <see cref="FlotLegendSorting"/> class with a given boolean value.
        /// </summary>
        /// <param name="value">The value.</param>
        public FlotLegendSorting(bool value)
        {
            BooleanValue = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FlotLegendSorting"/> class with a given string value.
        /// </summary>
        /// <param name="value">The value.</param>
        public FlotLegendSorting(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }

            StringValue = value;
        }

        /// <summary>
        /// Gets the boolean value.
        /// </summary>
        [JsonIgnore]
        public bool? BooleanValue { get; }

        /// <summary>
        /// Gets the string value.
        /// </summary>
        [JsonIgnore]
        public string StringValue { get; }

        /// <summary>
        /// Conversion from <see cref="string"/> to <see cref="FlotLegendSorting"/>.
        /// </summary>
        /// <param name="value">The sorting string.</param>
        public static implicit operator FlotLegendSorting(string value) => new FlotLegendSorting(value);

        /// <summary>
        /// Conversion from <see cref="bool"/> to <see cref="FlotLegendSorting"/>.
        /// </summary>
        /// <param name="value">The boolean value.</param>
        public static implicit operator FlotLegendSorting(bool value) => new FlotLegendSorting(value);

        private object Serialize()
        {
            if (BooleanValue.HasValue)
            {
                return BooleanValue.Value;
            }

            if (StringValue == Ascending.StringValue || StringValue == Descending.StringValue || StringValue == Reverse.StringValue)
            {
                return StringValue;
            }

            return new JRaw(StringValue);
        }

        private object DebuggerDisplay()
        {
            if (BooleanValue.HasValue)
            {
                return BooleanValue.Value;
            }

            return StringValue;
        }
    }
}
